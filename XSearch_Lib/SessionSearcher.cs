using System.Text;
using System.Text.RegularExpressions;
using HtmlAgilityPack;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V131.Memory;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using static XSearch_Lib.SearchHandler;
using static XSearch_Lib.XSearch_Strings;

namespace XSearch_Lib
{
    public class SessionSearcher
    {
        // CONSTANTS //

        /// <summary>
        /// Number of concurrent tasks that can be performed at once in multithreaded processes such as domain querying.
        /// </summary>
        private static readonly int concurrentTaskLimit = 5;

        // FIELDS //

        /// <summary>
        /// Handles errors related to searches.
        /// </summary>
        /// <param name="domain">The session with the error</param>
        /// <param name="eArgs">Details about the error.</param>
        public delegate void SearchErrorHandler(Session session, ErrorReportArgs eArgs);

        /// <summary>
        /// Event to raise when a pull is attempted but requirements aren't met.
        /// </summary>
        public event SearchErrorHandler OnPullFailedAttempt = delegate { };

        /// <summary>
        /// Logs details about ongoing searches.
        /// </summary>
        /// <param name="searcher">The searcher with the log.</param>
        /// <param name="eArgs">Log details.</param>
        public delegate void SearchLogHandler(SessionSearcher searcher, SearchLogArgs sArgs);

        /// <summary>
        /// Event when a new message should be logged about a search in this session.
        /// </summary>
        public event SearchLogHandler OnNewSearchUpdateLog = delegate { };

        /// <summary>
        /// Acts as an interface for search listing operations to ensure syncing across threads.
        /// </summary>
        /// <param name="searchlistings">The search listings to perform an operation on.</param>
        public delegate void SearchListingsHandler(IEnumerable<SearchListing> searchlistings);

        /// <summary>
        /// Event when new search results have been found and should be added to the session in the main thread.
        /// </summary>
        public event SearchListingsHandler OnNewSearchResults = delegate { };
        
        /// <summary>
        /// List of webdrivers currently in use by the program.
        /// </summary>
        private static List<IWebDriver> webDrivers = new List<IWebDriver>(); 

        /// <summary>
        /// Total tasks to complete in the current search process.
        /// </summary>
        private int currentTasksTotal = 0;

        /// <summary>
        /// Tasks that have been completed in the current search process.
        /// </summary>
        private int currentCompletedTasks = 0;

        /// <summary>
        /// Holds a list of notes on pull failures (if any).
        /// </summary>
        private List<ErrorReportArgs> pullFailureNotes = new List<ErrorReportArgs>();

        // CONSTRUCTOR //

        public SessionSearcher(Session session)
        {
            Session = session;
        }

        ~SessionSearcher()
        {
            foreach (IWebDriver driver in webDrivers)
            {
                TerminateDriver(driver);
            }
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
        private string _currentSearchTask = Log_Header_Ready;

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
        /// Set to true when the searcher should cancel a pull.
        /// </summary>
        public bool ShouldCancelPull 
        { 
            get
            {
                return _shouldCancelPull;
            }
            set
            {
                if (value == true)
                {
                    OnNewSearchUpdateLog(this, new SearchLogArgs("Cancelling pull..."));
                }
                _shouldCancelPull = value;
            }
        }
        private bool _shouldCancelPull = false;

        /// <summary>
        /// The search term to use during a pull, as provided by the user.
        /// </summary>
        public string SearchTerm { get; set; } = string.Empty;

        public bool RunHeadless { get; set; } = true;

        /// <summary>
        /// String to deliver when a pull is finished. This will normally be a completion message unless the pull was cancelled or it failed.
        /// </summary>
        public string PullFinishedString 
        { 
            get
            {
                if (_shouldCancelPull)
                {
                    return Pull_Cancelled;
                }
                if (!CurrentPullSuccessful)
                {
                    StringBuilder pullFailedMessage = new StringBuilder();

                    pullFailedMessage.AppendLine(Pull_Failed);

                    foreach (ErrorReportArgs note in pullFailureNotes)
                    {
                        pullFailedMessage.AppendLine($"{note.ErrorTitle}: {note.ErrorText}");
                    }

                    return pullFailedMessage.ToString();
                }
                return Pull_Complete;
            } 
        }

        public bool CurrentPullSuccessful { get; set; } = true;

        /// <summary>
        /// The number of results to pull per domain, as provided by the user.
        /// </summary>
        public int ResultsToPullPerDomain { get; set; } = 50;

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

            // Return control to caller so the setup process doesn't block the program.
            await Task.Yield();

            // Update the current search task string indicator for search update logs.
            _currentSearchTask = Log_Header_PullPrep;

            // Ensure there is a limit on domains to process concurrently.
            SemaphoreSlim throttler = new SemaphoreSlim(initialCount: concurrentTaskLimit);
            List<Task> allTasks = new List<Task>();

            foreach (Domain domain in Session.DomainProfile.ActiveDomains)
            {
                await throttler.WaitAsync();

                allTasks.Add(
                    Task.Run(() =>
                    {
                        OnNewSearchUpdateLog(this, new SearchLogArgs($"Creating FireFox driver for domain {domain.Label}."));
                        FirefoxDriver driver = CreateFirefoxDriver();

                        try
                        {
                            SearchDomain(domain, driver);
                        }
                        // If at any point we encounter an error page (typically due to having lost connection), we should handle the exception and not search this domain any further.
                        catch (UnknownErrorException ex) when (ex.Message.StartsWith("Reached error page:"))
                        {
                            OnNewSearchUpdateLog(this, new SearchLogArgs($"Error page encountered at {domain.Label}. Exception message follows: \n{ex.Message}"));
                            pullFailureNotes.Add(new ErrorReportArgs($"{domain.Label}:", "Encountered error page. Please verify Internet connection and try again."));
                            CurrentPullSuccessful = false;
                        }
                        finally
                        {
                            TerminateDriver(driver);
                            throttler.Release();
                        }
                    }));
            }

            await Task.WhenAll(allTasks);

            _currentSearchTask = Log_Header_Ready;
            OnNewSearchUpdateLog(this, new SearchLogArgs(PullFinishedString));

            // Reset volatile search variables.
            CurrentPullSuccessful = true;
            CurrentlyPulling = false;
            ShouldCancelPull = false;
        }

        /// <summary>
        /// Creates a Firefox driver with the default settings used by the program.
        /// </summary>
        public FirefoxDriver CreateFirefoxDriver()
        {
            FirefoxOptions ffOptions = new FirefoxOptions();

            if (RunHeadless)
            {
                ffOptions.AddArgument("-headless");
            }

            FirefoxDriverService ffDriverService = FirefoxDriverService.CreateDefaultService();
            ffDriverService.HideCommandPromptWindow = true;

            FirefoxDriver driver = new FirefoxDriver(ffDriverService, ffOptions);

            webDrivers.Add(driver);

            return driver;
        }

        public ChromeDriver CreateChromeDriver()
        {
            ChromeOptions cOptions = new ChromeOptions();

            if (RunHeadless)
            {
                cOptions.AddArgument("-headless");
            }

            ChromeDriverService cDriverService = ChromeDriverService.CreateDefaultService();
            cDriverService.HideCommandPromptWindow = true;

            ChromeDriver driver = new ChromeDriver(cDriverService, cOptions);

            webDrivers.Add(driver);

            // Currently doesn't seem to do anything.
            driver.ExecuteCdpCommand("Network.setUserAgentOverride", new Dictionary<string, object>
            {
                ["userAgent"] = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/83.0.4103.97 Safari/537.36"
            });

            return driver;
        }

        /// <summary>
        /// Raises an event to add new search listings to the session.
        /// </summary>
        /// <param name="searchListings">Search listings to add to the session.</param>
        /// <returns>The search listings to be added to the session.</returns>
        public IEnumerable<SearchListing> TryAddSearchListings(IEnumerable<SearchListing> searchListings, Domain domain)
        {
            List<SearchListing> listingsToAdd = new List<SearchListing>();
            foreach (SearchListing searchListing in searchListings)
            {
                // Check if we should cancel the pull.
                if (ShouldCancelPull)
                {
                    return listingsToAdd;
                }

                // Don't allow any listings already contained in the search listing list. 
                if (Session.SearchListings.Where(x => x.Url == searchListing.Url).Any())
                {
                    OnNewSearchUpdateLog(this, new SearchLogArgs($"Pulled duplicate search listing:\n{searchListing.Title}\n{searchListing.Url}"));
                    continue;
                }

                if (!Regex.IsMatch(searchListing.Url, domain.ListingUrlPattern))
                {
                    continue;
                }

                listingsToAdd.Add(searchListing);
            }

            OnNewSearchResults(listingsToAdd);

            return listingsToAdd;
        }

        /// <summary>
        /// Overload of <see cref="TryAddSearchListings"/> for only a single searchListing.
        /// </summary>
        /// <param name="searchListing">The SearchListing to add.</param>
        /// <returns>The SearchListings successfully added by the attempt.</returns>
        public IEnumerable<SearchListing> TryAddSearchListings(SearchListing searchListing, Domain domain)
        {
            return TryAddSearchListings([searchListing], domain);
        }
        
        /// <summary>
        /// Ensures an IWebDriver is properly disposed of.
        /// </summary>
        /// <param name="driver">The webDriver to dispose.</param>
        public void TerminateDriver(IWebDriver driver)
        {
            driver.Quit();
            if (webDrivers.Contains(driver))
            {
                webDrivers.Remove(driver);
            }
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

            // No results to pull.
            if (ResultsToPullPerDomain <= 0)
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

        /// <summary>
        /// Performs a search over an entire domain for as long as there are results to grab and we haven't reached the target.
        /// Intended to be run on its own thread with Task.Run.
        /// </summary>
        /// <param name="domain">The domain to query.</param>
        /// <param name="driver">The Selenium WebDriver instance to use to drive this domain's searches.</param>
        public void SearchDomain(Domain domain, IWebDriver driver)
        {
            OnNewSearchUpdateLog(this, new SearchLogArgs($"Setting up search for domain {domain.Label}."));

            // Replace any placeholders in the domain's search URL pattern with the current search term.
            string searchUrl = domain.GetResolvedSearchUrl(SearchTerm);

            // Determine if the given URL is valid and early exit if not.
            bool result = Uri.TryCreate(searchUrl, UriKind.Absolute, out Uri? testUri)
                && (testUri?.Scheme == Uri.UriSchemeHttp || testUri?.Scheme == Uri.UriSchemeHttps);

            if (!result)
            {
                OnNewSearchUpdateLog(this, new SearchLogArgs($"Search url {searchUrl} for domain {domain} was invalid. Skipping."));
                return;
            }

            //Go to the starting search URL.
            driver.Navigate().GoToUrl(searchUrl);
            
            driver.Manage().Window.Maximize();

            // Make note of the handle of the page we're using to fetch listings.
            string currentPageSearchHandle = driver.CurrentWindowHandle;

            // Keep track of links we've visited and new listings we've collected in this session.
            List<string> visitedHrefs = new List<string>();
            List<SearchListing> domainListingsPulledSoFar = new List<SearchListing>();

            // Attempt to find all listing links.
            List<IWebElement> linksToCheck = SearchForListingsUntilTimeout(domain, driver);

            // If we reach this point, we're cleared to begin the pull, so we inform the logger.
            _currentSearchTask = Log_Header_SearchPagePulling;
            OnNewSearchUpdateLog(this, new SearchLogArgs($"Beginning pull for domain {domain} at search URL {searchUrl}. {linksToCheck.Count} links found."));

            do
            {

                // Check if we should cancel the pull.
                if (ShouldCancelPull)
                {
                    return;
                }

                try
                {
                    IWebElement linkToCheck = linksToCheck[0];

                    // Determine that the current link to check is valid nefore processing it.
                    string? possibleHref = linkToCheck.GetAttribute("href");
                    if (possibleHref is string href && !visitedHrefs.Contains(href))
                    {
                        IJavaScriptExecutor js = (IJavaScriptExecutor)driver;

                        // Focus --> Control + Enter is important because it's much more consistent than MoveToElement and Click.
                        // Any site with reasonable accessibility should respond to it.

                        js.ExecuteScript("arguments[0].focus();", linksToCheck[0]);

                        new Actions(driver)
                        .KeyDown(Keys.LeftControl)
                        .KeyDown(Keys.Enter)
                        .KeyUp(Keys.Enter)
                        .KeyUp(Keys.LeftControl)
                        .Build()
                        .Perform();

                        IList<string> otherWindowHandles = new List<string>(driver.WindowHandles).Where(x => x != currentPageSearchHandle).ToList();
                        foreach (string windowHandle in otherWindowHandles)
                        {
                            // Check if we should cancel the pull.
                            if (ShouldCancelPull)
                            {
                                return;
                            }

                            SearchListing searchListing = BuildSearchListingFromOpenedWindow(driver, windowHandle, domain);

                            domainListingsPulledSoFar.Add(searchListing);
                            visitedHrefs.Add(href);

                            // Check if we should cancel the pull again.
                            if (ShouldCancelPull)
                            {
                                return;
                            }

                            if (TryAddSearchListings(searchListing, domain).Any())
                            {
                                OnNewSearchUpdateLog(this, new SearchLogArgs($"Successfully pulled new search listing:\n{searchListing.Title}\n{searchListing.Url}"));
                            }

                            // Close the current window.
                            driver.Close();
                        }
                    }

                }
                catch (StaleElementReferenceException)
                {
                    OnNewSearchUpdateLog(this, new SearchLogArgs($"Link element for domain {domain.Label} was found stale while attempting to collect listings."));
                }
                /*
                if (!ElementCompletelyVisible(driver, linksToCheck[i]))
                {*/

                driver.SwitchTo().Window(currentPageSearchHandle);

                linksToCheck.RemoveAt(0);

                // Stop searching if we've found enough listings.
                if (domainListingsPulledSoFar.Count >= ResultsToPullPerDomain)
                {
                    OnNewSearchUpdateLog(this, new SearchLogArgs($"Pull complete for domain {domain.Label} after collecting {domainListingsPulledSoFar.Count} listings."));
                    break;
                }    

                // Check for any links that may have loaded since we finished processing the last grabbed batch.
                if (linksToCheck.Count == 0)
                {
                    linksToCheck = GetMatchingListingLinks(domain, driver).Where(x => !visitedHrefs.Contains(x.GetAttribute("href"))).ToList();
                }

                // If we still didn't find any listings on the load search, try pressing any buttons we're commanded to at this point.
                if (linksToCheck.Count == 0)
                {
                    linksToCheck = ProcessDomainNoSearchResultsXpath(domain, driver);
                }
                
                // Ensure current search page handle is updated, as we may have changed pages.
                currentPageSearchHandle = driver.CurrentWindowHandle;
            }
            while (linksToCheck.Count > 0);
        }

        /// <summary>
        /// Handles standard procedures for marking a pull as failed.
        /// </summary>
        /// <param name="domain">The domain contributing a failure note.</param>
        /// <param name="failureNoteMessage">The summarized reason for the failure to provide at end of the pull.</param>
        /// <param name="updateLogMessage">The message for the failure to be given at the time of failure.</param>
        public void FailPull(Domain domain, string failureNoteMessage, string updateLogMessage)
        {
            OnNewSearchUpdateLog(this, new SearchLogArgs(updateLogMessage));
            pullFailureNotes.Add(new ErrorReportArgs($"{domain.Label}", failureNoteMessage));
            CurrentPullSuccessful = false;
        }

        public List<IWebElement> SearchForListingsUntilTimeout(Domain domain, IWebDriver driver)
        {
            // Attempt to find all listing links.
            List<IWebElement> linksToCheck = new List<IWebElement>();
            try
            {

                new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(d =>
                {
                    linksToCheck = GetMatchingListingLinks(domain, d);
                    return linksToCheck.Any();
                });

            }
            // Fail pull for this domain if we time out while searching for listing links.
            catch (WebDriverTimeoutException ex)
            {
                string message = $"Timed out while searching for any listing links at domain {domain.Label}.";
                FailPull(domain, message, message + $" Exception message follows: \n{ex.Message}");
            }

            return linksToCheck;
        }

        public List<IWebElement> ProcessDomainNoSearchResultsXpath(Domain domain, IWebDriver driver)
        {
            // Represents any new elements found after executing the 
            List<IWebElement> elementsAfterXpathCheck = new List<IWebElement>();
            List<string> xpathLeftToCheck = domain.NoSearchResultsXpath.ToList();

            // Find any elements with in the xpath searches provided.
            while (elementsAfterXpathCheck.Count <= 0 && xpathLeftToCheck.Count > 0)
            {
                try
                {
                    IWebElement element = driver.FindElement(By.XPath(xpathLeftToCheck[0]));

                    IJavaScriptExecutor js = (IJavaScriptExecutor)driver;

                    js.ExecuteScript("arguments[0].focus();", element);
                    js.ExecuteScript("arguments[0].click();", element);
                }
                catch (NoSuchElementException)
                {
                    OnNewSearchUpdateLog(this, new SearchLogArgs($"Failed to find element with xpath {xpathLeftToCheck[0]} in domain {domain.Label}."));
                }

                elementsAfterXpathCheck = SearchForListingsUntilTimeout(domain, driver);
                xpathLeftToCheck.RemoveAt(0);
            }

            // Return anything found (or the empty list if nothing was provided.
            return elementsAfterXpathCheck;

        }

        /// <summary>
        /// Attempts to build a SearchListing from an opened window handle.
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="windowHandle"></param>
        /// <returns></returns>
        public SearchListing BuildSearchListingFromOpenedWindow(IWebDriver driver, string windowHandle, Domain domain, int maxTries = 5, int retries = 0)
        {
            driver.SwitchTo().Window(windowHandle);
            /*new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(
                d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState")?.Equals("complete") ?? false);*/

                    string title = string.Empty;
            string url = string.Empty;

            while (retries <= maxTries)
            {
                // Attempt to fetch the title and URL for the new listing.
                try
                {
                    new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(
                        d => !string.IsNullOrEmpty(d.Title) && !string.IsNullOrEmpty(d.Url));

                    title = driver.Title;
                    url = new Uri(driver.Url).GetLeftPart(UriPartial.Path);

                    // Make sure we escape the loop.
                    break;
                }
                // If we time out, reload the page and try again up to the maximum number of retries.
                catch (WebDriverTimeoutException)
                {
                    driver.Navigate().Refresh();
                    OnNewSearchUpdateLog(this, new SearchLogArgs($"Timed out while trying to fetch listing from {domain.Label}. Reloading page and trying again. Retries: {retries}"));
                    BuildSearchListingFromOpenedWindow(driver, windowHandle, domain, maxTries, ++retries);
                }
            }

            if (retries > maxTries)
            {
                FailPull(domain,
                    $"Failed to fetch listing details from {domain.Label}.",
                    $"Failed to fetch listing details from {domain.Label} after {retries} tries due to repeated timeouts. Defaulting.");

                title = Listing_Default_Title;
                url = driver.Url ?? Listing_Default_Url;
            }

            return new SearchListing(title, domain.Label, url, DateTime.Now);

        }

        public bool ElementCompletelyVisible(IWebDriver driver, IWebElement element)
        {
            int elementLeftBound = element.Location.X;
            int elementTopBound = element.Location.Y;
            int elementWidth = element.Size.Width;
            int elementHeight = element.Size.Height;
            int elementRightBound = elementLeftBound + elementWidth;
            int elementBottomBound = elementTopBound + elementHeight;
            
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            long winUpperBound = (long)js.ExecuteScript("return window.pageYOffset", element);
            long winLeftBound = (long)js.ExecuteScript("return window.pageXOffset", element);
            long winWidth = (long)js.ExecuteScript("return document.documentElement.clientWidth", element);
            long winHeight = (long)js.ExecuteScript("return document.documentElement.clientHeight", element);
            long winRightBound = winLeftBound + winWidth;
            long winBottomBound = winUpperBound + winHeight;

            return 
                winLeftBound <= elementLeftBound &&
                winRightBound >= elementRightBound &&
                winUpperBound <= elementTopBound &&
                winBottomBound >= elementBottomBound;
        }

        /// <summary>
        /// Returns a list of all links on a webdriver's page that match domain listing URL patterns.
        /// </summary>
        /// <param name="driver">The webdriver to find elements on.</param>
        /// <param name="domain">The domain to use the listing pattern from.</param>
        /// <returns></returns>
        public List<IWebElement> GetMatchingListingLinks(Domain domain, IWebDriver driver, bool retry = true)
        {
            List<IWebElement> allLinks = new List<IWebElement>();
            List<IWebElement> matchingLinks = new List<IWebElement>();
            List<string> hrefs = new List<string>();

            try
            {
                allLinks = driver.FindElements(By.TagName("a")).OrderBy(x => x.Location.Y).ToList();

                // Early exit if no links were found.
                if (!allLinks.Any())
                {
                    return matchingLinks;
                }

                // Determine which links should be returned from those found.
                foreach (IWebElement link in allLinks)
                {
                    // Don't return any links without href attributes.
                    if (link.GetAttribute("href") is not string href)
                    {
                        continue;
                    }

                    // Don't return any links that don't match the listing URL pattern.
                    if (!Regex.IsMatch(href, domain.ListingUrlPattern))
                    {
                        continue;
                    }

                    // Only add those links that have passed all conditions.
                    matchingLinks.Add(link);
                    hrefs.Add(href);
                }

            }
            catch (StaleElementReferenceException ex)
            {
                //Retry once if exception caught.
                if (retry)
                {
                    return GetMatchingListingLinks(domain, driver, retry: false);
                }

                FailPull(domain,
                    "Listing links became stale.",
                    $"Stale listing returned by FindElements when getting matching listing links. Exception follows: \n{ex.Message}");
                return allLinks;
            }

            return matchingLinks;
        }
    }
}
