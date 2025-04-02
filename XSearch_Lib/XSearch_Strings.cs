using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Drawing;

namespace XSearch_Lib
{
    /// <summary>
    /// General collection of constant or nearly constant library strings.
    /// </summary>
    public static class XSearch_Strings
    {
        // Failed pulls

        public static readonly string Error_OnPullInProgress_Title = "Pull in progress";
        public static readonly string Error_OnPullInProgress_Text = "A pull is already in progress.";

        public static readonly string Error_OnSearchTermEmpty_Title = "No Search Term";
        public static readonly string Error_OnSearchTermEmpty_Text = "No search term was provided for the requested pull.";

        public static readonly string Error_OnZeroPagesSelected_Title = "No Pages to Search";
        public static readonly string Error_OnZeroPagesSelected_Text = "No pages to search were provided for the requested pull.";

        public static readonly string Error_OnNoActiveDomains_Title = "No Active Domains";
        public static readonly string Error_OnNoActiveDomains_Text = "No domains are active for searching.";

        // Pull log messages 

        public static readonly string Pull_Complete = "Pull complete.";
        public static readonly string Pull_Cancelled = "Pull cancelled.";
        public static readonly string Pull_Failed = "Pull failed.";

        public static readonly string Log_Header_Ready = "Ready to pull";
        public static readonly string Log_Header_PullPrep = "Preparing to pull";
        public static readonly string Log_Header_SearchPagePulling = "Pulling search pages";
        public static readonly string Log_Header_TitleFetching = "Fetching titles";

        // Defaults 

        public static readonly string Listing_Default_Title = "No title pulled";
        public static readonly string Listing_Default_Url = "data:text/plain;base64,SGVsbG8sIHdvcmxk";
        public static readonly string Domain_Default_Id = "NO_ID";
        public static readonly string Domain_Default_Label = "Unnamed Domain";

        // Domain strings

        /// <summary>
        /// Placeholder pattern for search URL page count.
        /// Largely deprecated.
        /// </summary>
        public const string DomainUrl_PageCount_PlaceholderPattern = "<<pageCount>>";

        /// <summary>
        /// Placeholder pattern for search URL search term.
        /// </summary>
        public const string DomainUrl_SearchTerm_PlaceholderPattern = "<<searchTerm>>";

        public const string Tooltip_Title_Generic_Error = "Invalid tooltip title";
        public const string Tooltip_Body_Generic_Error = "Invalid tooltip body text.";

    }
}
