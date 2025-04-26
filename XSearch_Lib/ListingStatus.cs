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
        /// Unique internal identifier for this status.
        /// Convention is to use nameof in the status declaration.
        /// Used to unite SearchListings with their statuses across sessions.
        /// </summary>
        public string StatusId = Guid.NewGuid().ToString();

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
            StatusId = id;
        }
    }
}
