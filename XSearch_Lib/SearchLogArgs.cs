namespace XSearch_Lib
{
    /// <summary>
    /// Holds information related to pull updates.
    /// </summary>
    public class SearchLogArgs
    {
        public string Text
        {
            get
            {
                return _text;
            }
        }
        private string _text;

        public int? ListingsPulledSoFar
        {
            get
            {
                return _listingsPulledSoFar;
            }
        }
        private int? _listingsPulledSoFar;

        public Domain? Domain
        {
            get 
            {
                return _domain;
            }
        }
        public Domain? _domain;

        public SearchLogArgs(string text, int? listingsPulledSoFar = null, Domain? domain = null)
        {
            _text = text;
            _listingsPulledSoFar = listingsPulledSoFar;
            _domain = domain;
        }
    }

}
