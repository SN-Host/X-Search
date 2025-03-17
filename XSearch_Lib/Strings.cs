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
    public static class Strings
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

        public static readonly string Log_Header_Ready = "Ready to pull";
        public static readonly string Log_Header_SearchPagePulling = "Pulling search pages";
        public static readonly string Log_Header_TitleFetching = "Fetching titles";


    }
}
