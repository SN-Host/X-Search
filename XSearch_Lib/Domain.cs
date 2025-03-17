using System.ComponentModel;
using System.Data;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace XSearch_Lib
{
    public class Domain
    {

        // CONSTANTS //

        // TODO: Convert to readonly props as part of a static class. https://stackoverflow.com/questions/1724025/whats-the-best-way-to-store-a-group-of-constants-that-my-program-uses

        /// <summary>
        /// Placeholder pattern for search URL page count.
        /// </summary>
        public const string URL_PAGECOUNT_PLACEHOLDER_PATTERN = "<<pageCount>>";

        /// <summary>
        /// Placeholder pattern for search URL search term.
        /// </summary>
        public const string URL_SEARCHTERM_PLACEHOLDER_PATTERN = "<<searchTerm>>";

        /// <summary>
        /// Generic title for any error-handling tooltips that weren't given a more specific title.
        /// </summary>
        public const string TOOLTIP_TITLE_GENERIC_ERROR = "Error";

        /// <summary>
        /// Generic body for any error-handling tooltips that weren't given a more specific body.
        /// </summary>
        public const string TOOLTIP_BODY_GENERIC_ERROR = "Invalid data.";

        /// <summary>
        /// Defines the placeholder patterns expected by search patterns.
        /// </summary>
        private static readonly HashSet<string> RequiredSearchPlaceholderPatterns =
        [
            URL_PAGECOUNT_PLACEHOLDER_PATTERN,
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

        /// <summary>
        /// Event to raise when a listing URL pattern is rejected.
        /// </summary>
        public event DomainErrorHandler OnListingUrlPatternRejected = delegate { };

        // PROPERTIES //

        /// <summary>
        /// Whether this domain is to be included in new pulls.
        /// </summary>
        public bool Active { get; set; } = false;

        /// <summary>
        /// User readable label for this domain.
        /// </summary>
        public string Label { get; set; } = string.Empty;

        /// <summary>
        /// Holds data pertaining to the domain's expected search URL pattern.
        /// </summary>
        [Browsable(false)]
        public PatternedString SearchUrlPatternedString { get; set; }

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
        /// Gets or sets the page count multiplier. This applies a multiplier to any page count placeholders when this domain is being handled.
        /// Useful for websites that track result delivery by gallery count, such as Craigslist.
        /// </summary>
        public decimal PageCountMultiplier { get; set; } = 1;

        /// <summary>
        /// Default constructor, requiring a GUI handler for when a search URL pattern is rejected.
        /// </summary>
        /// <param name="onSearchUrlPatternRejected">Action to take when a search URL pattern is rejected. Can be assigned an empty delegate if need be.</param>
        public Domain(Action<Domain, ErrorReportArgs> onSearchUrlPatternRejected)
        {
            OnSearchUrlPatternRejected += (sender, e) => onSearchUrlPatternRejected(sender, e);
            SearchUrlPatternedString = new PatternedString(RequiredSearchPlaceholderPatterns, delegate (ErrorReportArgs eArgs) { OnSearchUrlPatternRejected(this, eArgs); });
            SearchUrlPatternedString.AllowInvalidRawPatternSets = true;
        }

        /// <summary>
        /// Builds a search URL for this domain given a search term and page count.
        /// </summary>
        /// <param name="searchTerm">The search term to substitute.</param>
        /// <param name="pageCount">The page count to substitute.</param>
        /// <returns></returns>
        public string GetResolvedSearchUrl(string searchTerm, int pageCount)
        {
            string resolvedSearchUrl = SearchUrlPattern;

            // Replace search term placeholder.
            resolvedSearchUrl = resolvedSearchUrl.Replace(URL_SEARCHTERM_PLACEHOLDER_PATTERN, searchTerm);

            // Replace pageCount placeholder.
            resolvedSearchUrl = resolvedSearchUrl.Replace(URL_PAGECOUNT_PLACEHOLDER_PATTERN, (pageCount * PageCountMultiplier).ToString());

            return resolvedSearchUrl;
        }

    }
}