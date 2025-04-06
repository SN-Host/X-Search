using System.ComponentModel;
using System.Text.RegularExpressions;
using static XSearch_Lib.XSearch_Strings;

namespace XSearch_Lib
{
    public class Domain : INotifyPropertyChanged
    {
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
        /// Event to raise when a property is changed. Necessary to ensure the DataGridView updates properly.
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        private bool _active = false;

        private string _label = Domain_Default_Label;

        private string _listingUrlPattern = string.Empty;

        // PROPERTIES //

        /// <summary>
        /// Unique internal identifier for this domain.
        /// Used to unite SearchListings with their domains across sessions.
        /// </summary>
        public string DomainId { get; set; } = Domain_Default_Id;

        /// <summary>
        /// Whether this domain is to be included in new pulls.
        /// </summary>
        public bool Active
        {
            get
            {
                return _active;
            }
            set 
            {
                _active = value;
                NotifyPropertyChanged(nameof(Active));
            } 
        }

        /// <summary>
        /// User readable label for this domain.
        /// </summary>
        public string Label 
        { 
            get
            {
                return _label;
            }
            set
            {
                _label = value;
                NotifyPropertyChanged(nameof(Label));
            }
        } 

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
                NotifyPropertyChanged(nameof(SearchUrlPattern));
            }
        }

        /// <summary>
        /// Gets or sets the listing URL regex pattern. This is a regex expression for which href atts in the source HTML are required to match to be added.
        /// </summary>
        public string ListingUrlPattern 
        { 
            get
            {
                return _listingUrlPattern;
            }
            set
            {
                _listingUrlPattern = value;
                NotifyPropertyChanged(nameof(ListingUrlPattern));
            }
        }

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
            int placeholdersInUrl = Regex.Matches(resolvedSearchUrl, DomainUrl_SearchTerm_PlaceholderPattern).Count;

            // Placeholder count must match the count of the delimited terms for delimited substitution.
            // Otherwise, we will simply use the whole search term for every placeholder.
            if (placeholdersInUrl != delimitedTerms.Length)
            {
                delimitedTerms = [searchTerm];
            }

            // Replace each instance of the placeholder pattern with delimited search terms of the appropriate index.
            string escape = Regex.Escape(DomainUrl_SearchTerm_PlaceholderPattern);
            int termIndex = 0;
            string result = Regex.Replace(SearchUrlPattern, escape, (m) => delimitedTerms[termIndex + 1 >= delimitedTerms.Length ? termIndex : termIndex++]);

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

        /// <summary>
        /// Essential to ensuring that the DataGridView can update the domain display in real time.
        /// </summary>
        private void NotifyPropertyChanged(string p)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(p));
        }
    }
}