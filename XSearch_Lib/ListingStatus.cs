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
    /// Holds information on a listing's status.
    /// </summary>
    public class ListingStatus
    {
        /// <summary>
        /// Text-only display for this status if more complex rendering is not available.
        /// </summary>
        public string TextSymbol = string.Empty;

        /// <summary>
        /// Relative path to this status' representative image.
        /// May be used in different ways depending on the UI.
        /// </summary>
        public string ImagePath = string.Empty;

        /// <summary>
        /// Sorting index that determines the order in which listings are automatically sorted.
        /// </summary>
        public int SortIndex = 0;

        /// <summary>
        /// Unique identifier for a status.
        /// TODO: Implement verification with PatternedStrings. Probably same for domains.
        /// </summary>
        private string statusId = string.Empty;


        /// <summary>
        /// Parameterless constructor for XML serialization. Should not be used to make functional instances.
        /// </summary>
        private ListingStatus() 
        { 
        }

        public ListingStatus(string textSymbol, string imagePath, int sortIndex, string id)
        {
            TextSymbol = textSymbol;
            ImagePath = imagePath;
            SortIndex = sortIndex;
            statusId = id;
        }

        /// <summary>
        /// Unique internal identifier for this status.
        /// Used to unite SearchListings with their statuses across sessions.
        /// </summary>
        public string StatusId
        {
            get
            {
                return statusId;
            }
            set
            {
                statusId = value;
            }

        }
    }
}
