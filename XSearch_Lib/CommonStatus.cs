using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XSearch_Lib
{
 
    /// <summary>
    /// Collection of Built-in status types commom throughout the application.
    /// </summary>
    public static class CommonStatus
    {

        /// <summary>
        /// For items that have been crossed. Lowest sort priority.
        /// </summary>
        public static ListingStatus CrossedStatus = new ListingStatus()
        {
            TextSymbol = "X",
            ImagePath = "X",
            Index = 0
        };

        /// <summary>
        /// For items marked unevaluated. Highest sort priority.
        /// </summary>
        public static ListingStatus NewStatus = new ListingStatus()
        {
            TextSymbol = "O",
            ImagePath = "O",
            Index = 1
        };

    }
}
