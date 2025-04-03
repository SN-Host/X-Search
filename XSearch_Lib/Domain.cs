using System;
using System.ComponentModel;
using System.Data;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Serialization;
using static XSearch_Lib.XSearch_Strings;

namespace XSearch_Lib
{
    public class Domain
    {

        // CONSTANTS //

        // TODO: Convert to readonly props as part of a static class. https://stackoverflow.com/questions/1724025/whats-the-best-way-to-store-a-group-of-constants-that-my-program-uses

        /// <summary>
        /// Placeholder pattern for search URL page count.
        /// Largely deprecated.
        /// </summary>
        public const string URL_PAGECOUNT_PLACEHOLDER_PATTERN = "<<pageCount>>";

        /// <summary>
        /// Placeholder pattern for search URL search term.
        /// </summary>
        public const string URL_SEARCHTERM_PLACEHOLDER_PATTERN = "<<searchTerm>>";

        /// <summary>
        /// Generic title for any error-handling tooltips that weren't given a more specific title.
        /// </summary>
        public const string TOOLTIP_TITLE_GENERIC_ERROR = "Invalid tooltip title";

        /// <summary>
        /// Generic body for any error-handling tooltips that weren't given a more specific body.
        /// </summary>
        public const string TOOLTIP_BODY_GENERIC_ERROR = "Invalid tooltip body text.";

        /// <summary>
        /// Defines the placeholder patterns expected by search patterns.
        /// Used to be larger and a strict requirement, but is now merely a suggestion for flexibility.
        /// </summary>
        private static readonly HashSet<string> RequiredSearchPlaceholderPatterns =
        [
            URL_SEARCHTERM_PLACEHOLDER_PATTERN
        ];

        // FIELDS //

        /// <summary>
        /// Handles errors related to domains.
        /// </summary>
        /// <param name="domain">The domain with the error</param>
        /// <param name="eArgs">Details about the error.</param>
        public delegate void DomainErrorHandler(Domain domain, ErrorReportArgs eArgs);

        /// <summary>
        /// Event to raise when a search URL pattern is rejected.
        /// </summary>
        public event DomainErrorHandler OnSearchUrlPatternRejected = delegate { };

        // PROPERTIES //

        /// <summary>
        /// Unique internal identifier for this domain.
        /// Used to unite SearchListings with their domains across sessions.
        /// </summary>
        public string DomainId { get; set; } = Domain_Default_Id;

        /// <summary>
        /// Whether this domain is to be included in new pulls.
        /// </summary>
        public bool Active { get; set; } = false;

        /// <summary>
        /// User readable label for this domain.
        /// </summary>
        public string Label { get; set; } = Domain_Default_Label;

        /// <summary>
        /// Gets or sets the search URL pattern, containing all placeholders necessary for searching. 
        /// </summary>
        public string SearchUrlPattern
        {
            get
            {
                return SearchUrlPatternedString.RawPattern;
            }

            set
            {
                SearchUrlPatternedString.RawPattern = value;
            }
        }

        /// <summary>
        /// Gets or sets the listing URL regex pattern. This is a regex expression for which href atts in the source HTML are required to match to be added.
        /// </summary>
        public string ListingUrlPattern { get; set; } = string.Empty;

        /// <summary>
        /// Holds data pertaining to the domain's expected search URL pattern.
        /// </summary>
        [Browsable(false)]
        public PatternedString SearchUrlPatternedString { get; set; } = new PatternedString();

        /// <summary>
        /// List of xpath queries that should be run to find clickable elements that will hopefully yield more results on a given domain when no more search results can be found.
        /// </summary>
        public BindingList<string> NoSearchResultsXpath { get; set; } = new BindingList<string>();

        /// <summary>
        /// Parameterless constructor for XML serialization only. Do not call.
        /// </summary>
        private Domain() 
        {
        }

        /// <summary>
        /// Default constructor, requiring a GUI handler for when a search URL pattern is rejected.
        /// </summary>
        /// <param name="label">User-facing label for the domain.</param>
        /// <param name="onSearchUrlPatternRejected">Action to take when a search URL pattern is rejected. Can be assigned an empty delegate if need be.</param>
        public Domain(Action<Domain, ErrorReportArgs> onSearchUrlPatternRejected, string? label = null)
        {
            DomainId = Guid.NewGuid().ToString();
            Label = label ?? Label;
            OnSearchUrlPatternRejected += (sender, e) => onSearchUrlPatternRejected(sender, e);
            SearchUrlPatternedString = new PatternedString(RequiredSearchPlaceholderPatterns, delegate (ErrorReportArgs eArgs) { OnSearchUrlPatternRejected(this, eArgs); });
            SearchUrlPatternedString.AllowInvalidRawPatternSets = true;
        }

        /// <summary>
        /// Builds a search URL for this domain given a search term and page count.
        /// </summary>
        /// <param name="searchTerm">The search term to substitute. Spaces serve as delimiters in the case of multiple placeholders being given.</param>
        /// <returns>The search URL with all placeholders resolved.</returns>
        public string GetResolvedSearchUrl(string searchTerm)
        {
            string resolvedSearchUrl = SearchUrlPattern;

            // Determine the separate words were in our search term, delimited by a space.
            string[] delimitedTerms = searchTerm.Split(" ");

            // Determine the count of search term placeholders in the search URL pattern given for this domain.
            int placeholdersInUrl = Regex.Matches(resolvedSearchUrl, URL_SEARCHTERM_PLACEHOLDER_PATTERN).Count;

            // If there's a discrepancy in the number of placeholders in the URL pattern or the query,
            // we'll use the original search term to fill in all placeholders.
            if (placeholdersInUrl != delimitedTerms.Length)
            {
                delimitedTerms = [searchTerm];
            }

            // Define our escape term for Regex to interpret literally; the placeholder pattern.
            string escape = Regex.Escape(URL_SEARCHTERM_PLACEHOLDER_PATTERN);

            // Replace each instance of the placeholder pattern with delimited search terms of the appropriate index.
            int termIndex = 0;
            string result = Regex.Replace(SearchUrlPattern, escape, (m) => delimitedTerms[termIndex + 1 >= delimitedTerms.Length ? termIndex : termIndex++]);

            // Return what we've come up with.
            return result;
        }

        public override bool Equals(object? obj)
        {
            return obj is Domain domain &&
                   Label == domain.Label &&
                   SearchUrlPattern == domain.SearchUrlPattern &&
                   ListingUrlPattern == domain.ListingUrlPattern &&
                   EqualityComparer<PatternedString>.Default.Equals(SearchUrlPatternedString, domain.SearchUrlPatternedString) &&
                   EqualityComparer<BindingList<string>>.Default.Equals(NoSearchResultsXpath, domain.NoSearchResultsXpath);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Label, SearchUrlPattern, ListingUrlPattern, SearchUrlPatternedString, NoSearchResultsXpath);
        }
    }
}