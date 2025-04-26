namespace XSearch_Lib
{

    /// <summary>
    /// Collection of built-in status types commom throughout the application.
    /// TODO: Consider replacing with a user modified system.
    /// </summary>
    public static class CommonStatus
    {
        /// <summary>
        /// For items that have been crossed. Lowest sort priority.
        /// </summary>
        public static ListingStatus CrossedStatus = new ListingStatus("X", "CrossedStatusBubble", 0, nameof(CrossedStatus));

        /// <summary>
        /// For items yet to be evaluated. Highest sort priority.
        /// </summary>
        public static ListingStatus UnevaluatedStatus = new ListingStatus("O", "UnevaluatedStatusBubble", 1, nameof(UnevaluatedStatus));
        
        /// <summary>
        /// Used in resolving Status IDs between sessions.
        /// </summary>
        public static Dictionary<string, ListingStatus> IdToStatus = new Dictionary<string, ListingStatus>();

        static CommonStatus()
        {
            IdToStatus.Add(CrossedStatus.StatusId, CrossedStatus);
            IdToStatus.Add(UnevaluatedStatus.StatusId, UnevaluatedStatus);
        }


    }
}
