using System;
using System.ComponentModel;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using HtmlAgilityPack;
using static XSearch_Lib.SearchHandler;
using static XSearch_Lib.Strings;

namespace XSearch_Lib
{
    public class SessionSearcher
    {
        // CONSTANTS //

        /// <summary>
        /// Default time to call Task.Delay to throttle searching.
        /// </summary>
        private static readonly int timeBetweenNewSearchTasks = 1000;

        /// <summary>
        /// Default time to call Task.Delay to throttle title grabbing.
        /// </summary>
        private static readonly int timeBetweenNewTitleGrabTasks = 10000;

        // FIELDS //

        /// <summary>
        /// Handles errors related to sessions.
        /// </summary>
        /// <param name="domain">The session with the error</param>
        /// <param name="eArgs">Details about the error.</param>
        public delegate void SessionErrorHandler(Session session, ErrorReportArgs eArgs);

        /// <summary>
        /// Event to raise when a pull is attempted but requirements aren't met.
        /// </summary>
        public event SessionErrorHandler OnPullFailedAttempt = delegate { };

        /// <summary>
        /// Logs details about ongoing searches.
        /// </summary>
        /// <param name="searcher">The searcher with the log.</param>
        /// <param name="eArgs">Log details.</param>
        public delegate void SearchLogHandler(SessionSearcher searcher, SearchLogArgs sArgs);

        /// <summary>
        /// Event when a new message should be logged about a search in this session.
        /// </summary>
        public event SearchLogHandler OnNewSearchMessage = delegate { };

        /// <summary>
        /// Total tasks to complete in the current search process.
        /// </summary>
        private int currentTasksTotal = 0;

        /// <summary>
        /// Tasks that have been completed in the current search process.
        /// </summary>
        private int currentCompletedTasks = 0;

        /// <summary>
        /// Descriptive string representing the search task currently in progress.
        /// </summary>
        public string _currentSearchTask = Log_Header_Ready;

        // CONSTRUCTOR //

        public SessionSearcher(Session session)
        {
            Session = session;
        }

        // PROPERTIES //

        /// <summary>
        /// The session handled by this instance.
        /// </summary>
        public Session Session { get; private set; }

        /// <summary>
        /// Returns a descriptive string representing the task currently in progress.
        /// </summary>
        public string CurrentSearchTask
        {
            get
            {
                return _currentSearchTask;
            }
        }

        /// <summary>
        /// Returns an integer from 0-100 representing current search progress.
        /// Not currently functional; rework will come with Selenium move.
        /// </summary>
        public float SearchProgress
        {
            get 
            {
                if (currentTasksTotal == 0)
                {
                    return 0f;
                }
                return (float)(currentCompletedTasks / currentTasksTotal) * 100f;
            }
        }

        /// <summary>
        /// Set when the searcher is in the process of pulling.
        /// </summary>
        public bool CurrentlyPulling { get; set; } = false;

        
        /// <summary>
        /// The search term to use during a pull, as provided by the user.
        /// </summary>
        public string SearchTerm { get; set; } = string.Empty;

        /// <summary>
        /// The number of pages to search during a pull, as provided by the user.
        /// </summary>
        public int PagesToSearch { get; set; } = 0;

        /// <summary>
        /// Pulls a new search from active domains using current session settings.
        /// </summary>
        public async Task PullSearch()
        {
            // Do not pull if requirements aren't satisfied.
            if (!PullRequirementsSatisfied())
            {
                return;
            }

            CurrentlyPulling = true;



            // Fetch any new search listings.
            List<Task> tasks = new List<Task>();

            await PullFromSearchPages();

            // Attempt to fetch the titles of all currently pulled search listings without titles.
            await TryUpdateSearchListingTitles();

            CurrentlyPulling = false;

            // Currently won't work as expected - our async methods are beginning as soon as they're loaded into an IEnumerable. This will need to change.
            _currentSearchTask = Log_Header_Ready;
            OnNewSearchMessage(this, new SearchLogArgs($"Pull complete."));
        }

        /// <summary>
        /// Determines if a pull can be made, calling event handlers to warn about the failed pull attempt.
        /// </summary>
        /// <returns>True if a pull can be made, false otherwise.</returns>
        public bool PullRequirementsSatisfied()
        {
            // Pull already in progress.
            if (CurrentlyPulling)
            {
                OnPullFailedAttempt(Session, new ErrorReportArgs(Error_OnPullInProgress_Title, Error_OnPullInProgress_Text));
                return false;
            }

            // No search term provided.
            if (string.IsNullOrEmpty(SearchTerm))
            {
                OnPullFailedAttempt(Session, new ErrorReportArgs(Error_OnSearchTermEmpty_Title, Error_OnSearchTermEmpty_Text));
                return false;
            }

            // No pages to search.
            if (PagesToSearch <= 0)
            {
                OnPullFailedAttempt(Session, new ErrorReportArgs(Error_OnZeroPagesSelected_Title, Error_OnZeroPagesSelected_Text));
                return false;
            }

            // No active domains to search.
            if (!Session.DomainProfile.Domains.Where(x => x.Active).Any())
            {
                OnPullFailedAttempt(Session, new ErrorReportArgs(Error_OnNoActiveDomains_Title, Error_OnNoActiveDomains_Text));
                return false;
            }

            // Conditions passed.
            return true;
        }

        public async Task PullFromSearchPages()
        {
            _currentSearchTask = Log_Header_SearchPagePulling;

            // Determine which domains are active and need to be pulled from.
            List<Domain> activeDomains = Session.DomainProfile.Domains.Where(x => x.Active).ToList();

            OnNewSearchMessage(this, new SearchLogArgs($"Beginning search page listing pulls for {activeDomains.Count} domains."));

            // Build the search pages we intend to search by filling in our placeholders.
            List<SearchPage> searchPages = new List<SearchPage>();
            foreach (Domain domain in activeDomains)
            {
                // First ensure that this domain's search URLs are valid at all.
                string searchUrl = domain.GetResolvedSearchUrl(SearchTerm, 1);

                bool result = Uri.TryCreate(searchUrl, UriKind.Absolute, out Uri? testUri)
                && (testUri?.Scheme == Uri.UriSchemeHttp || testUri?.Scheme == Uri.UriSchemeHttps);

                // If the search URL pattern was invalid, don't proceed with this domain.
                if (!result)
                {
                    OnNewSearchMessage(this, new SearchLogArgs($"Search url {searchUrl} for domain {domain} was invalid. Skipping."));
                    continue;
                }

                // Otherwise, generate uris for all pages of all domains for the given search term.
                for (int curPage = 1; curPage <= PagesToSearch; curPage++)
                {
                    string url = domain.GetResolvedSearchUrl(SearchTerm, curPage);
                    if (!searchPages.Where(x => x.Url == url).Any())
                    {
                        searchPages.Add(new SearchPage(url, domain));
                    }
                }
            }

            // Compile a list of tasks representing the search pages to query for listings.
            IEnumerable<Task<List<SearchListing>>> downloadListingTasksQuery =
                from searchPage in searchPages
                select ParseSearchPageForListingLinks(new Uri(searchPage.Url), searchPage.Domain);

            // Represents the tasks to download listings from search pages that still need to be completed.
            List<Task<List<SearchListing>>> remainingDownloadListingTasks = downloadListingTasksQuery.ToList();

            // Represents the listings for which we need to fetch titles.
            List<SearchListing> searchListingsToGetTitlesFor = new List<SearchListing>();

            OnNewSearchMessage(this, new SearchLogArgs($"Pulling listings from {remainingDownloadListingTasks.Count} pages."));

            // Main loop for pulling listings from search pages.
            while (remainingDownloadListingTasks.Any())
            {
                // When any of the tasks have finished...
                Task<List<SearchListing>> finishedListingTask = await Task.WhenAny(remainingDownloadListingTasks);

                // Remove finished task from to-do lists.
                remainingDownloadListingTasks.Remove(finishedListingTask);

                List<SearchListing> searchListings = await finishedListingTask;

                // Insert the retrieved listings into our session's SearchListings.
                foreach (SearchListing searchListing in searchListings)
                {
                    Session.SearchListings.Insert(0, searchListing);
                    searchListingsToGetTitlesFor.Insert(0, searchListing);
                }
            }

            OnNewSearchMessage(this, new SearchLogArgs($"Search listing pulls complete."));

        }

        /// <summary>
        /// Attempts to update listing titles for any search listings in the session.
        /// </summary>
        public async Task TryUpdateSearchListingTitles()
        {
            // Update current search task.
            _currentSearchTask = Log_Header_TitleFetching;

            // Compile a list of title update tasks.
            IEnumerable<Task<bool>> downloadListingTitlesTasksQuery =
                from searchListing in Session.SearchListings
                where !searchListing.TitleGrabbed
                select ParseListingPageForTitles(searchListing);

            List<Task<bool>> remainingDownloadTitlesTasks = downloadListingTitlesTasksQuery.ToList();

            OnNewSearchMessage(this, new SearchLogArgs($"Attempting to pull titles for {remainingDownloadTitlesTasks.Count} listings."));

            // Continue to await results so long as there are tasks remaining to be completed.
            while (remainingDownloadTitlesTasks.Any())
            {
                // Handle any completed tasks.
                Task<bool> finishedTitlingTask = await Task.WhenAny(remainingDownloadTitlesTasks);

                remainingDownloadTitlesTasks.Remove(finishedTitlingTask);
            }

            OnNewSearchMessage(this, new SearchLogArgs($"Listing title pulls complete."));
        }

        /// <summary>
        /// Retrieves and parses a SearchListing's associated HTML for a webpage title.
        /// </summary>
        /// <param name="searchListing">The SearchListing to check.</param>
        /// <returns>True only if a title could be retrieved from the document.</returns>
        private async Task<bool> ParseListingPageForTitles(SearchListing searchListing)
        {
            // Indicate that this title is being fetched.
            searchListing.Title = SearchListing.FetchingTitle;

            // Try to get web request at matched URL.
            HttpResponseMessage response = await SharedClient.GetAsync(searchListing.Url);

            currentCompletedTasks++;

            // Throw exception if URL can't be resolved.
            if (response == null || !response.IsSuccessStatusCode)
            {
                // TODO: Message
                searchListing.Title = SearchListing.FailedTitleFetch;
                OnNewSearchMessage(this, new SearchLogArgs($"Failed to pull title for the following URL: {searchListing.Url}"));
                return false;
                //throw new Exception($"Failed to load URL: {listingUrl}");
            }

            // From the content of the listing, retrieve the title.

            string listingContent = await response.Content.ReadAsStringAsync();

            searchListing.Title = Regex.Match(listingContent, @"\<title\b[^>]*\>\s*(?<Title>[\s\S]*?)\</title\>",
            RegexOptions.IgnoreCase).Groups["Title"].Value;

            searchListing.TitleGrabbed = true;
            OnNewSearchMessage(this, new SearchLogArgs($"Title pulled:\n {searchListing.Title}."));

            return true;
        }

        private async Task<List<SearchListing>> ParseSearchPageForListingLinks(Uri searchPageUri, Domain domain)
        {
            // Try to get web request at matched URL.
            HttpResponseMessage response = await SharedClient.GetAsync(searchPageUri);

            // Throw exception if URL can't be resolved.
            if (response == null || !response.IsSuccessStatusCode)
            {
                OnNewSearchMessage(this, new SearchLogArgs($"Could not reach domain {domain.Label}."));
                return new List<SearchListing>();
                //throw new Exception($"Failed to load URL: {listingUrl}");
            }

            // Load the HTML document and locate any href attributes.

            string listingContent = await response.Content.ReadAsStringAsync();

            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(listingContent);

            List<string> listingUrls = htmlDoc.DocumentNode
                .SelectNodes("//a[@href]")
                .Select(node => node.GetAttributeValue("href", string.Empty))
                .Distinct()
                .ToList();

            // Load the found href attributes into a list for processing.

            List<SearchListing> searchListings = new List<SearchListing>();

            foreach (string listingUrl in listingUrls)
            {
                bool result = Uri.TryCreate(listingUrl, UriKind.Absolute, out Uri? testUri)
                    && (testUri?.Scheme == Uri.UriSchemeHttp || testUri?.Scheme == Uri.UriSchemeHttps);

                // Early exit if the URL can't be resolved.
                if (!result || testUri == null)
                {
                    continue;
                }

                // Change testUri into a non-null instance.
                Uri uriResult = testUri;

                // Early exit if the URL doesn't match the regex pattern.
                if (!Regex.IsMatch(listingUrl, domain.ListingUrlPattern))
                {
                    continue;
                }

                // Early exit if we've already fetched this search listing.
                if (Session.SearchListings.Where(x => x.Url == listingUrl).Any())
                {
                    continue;
                };

                // Otherwise, we've found a new listing and can safely add it to our list.

                searchListings.Add(new SearchListing(domain, listingUrl));
                OnNewSearchMessage(this, new SearchLogArgs($"{searchListings.Count} search listings pulled from the following URL: {listingUrl}"));
            }

            return searchListings;


        }
    }
}
