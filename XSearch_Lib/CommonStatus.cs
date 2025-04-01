using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XSearch_Lib
{
 
    /// <summary>
    /// Collection of built-in status types commom throughout the application.
    /// </summary>
    public static class CommonStatus
    {

        /// <summary>
        /// For items that have been crossed. Lowest sort priority.
        /// </summary>
        public static ListingStatus CrossedStatus = new ListingStatus("X", "X", 0, nameof(CrossedStatus));

        /// <summary>
        /// For items that have yet to be evaluated. Highest sort priority.
        /// </summary>
        public static ListingStatus UnevaluatedStatus = new ListingStatus("O", "O", 1, nameof(UnevaluatedStatus));

    }
}
