using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XSearch_Lib
{
    // TODO: Remove possible nulls
    public class SearchListing
    {

        // CONSTANTS //

        public static readonly string DefaultTitle = "Unknown title";

        public static readonly string FetchingTitle = "Fetching title...";

        public static readonly string FailedTitleFetch = "Title fetch failed";

        // FIELDS //

        /// <summary>
        /// Determines whether this listing's title has been retrieved from the HTML source or not.
        /// </summary>
        public bool TitleGrabbed = false;

        // CONSTRUCTORS //

        public SearchListing(Domain domain, string url)
        {
            Domain = domain;
            Url = url;
        }

        // PROPERTIES //

        public string DomainName
        {
            get
            {
                return Domain.Label;
            }
            set
            {
                Domain.Label = value;
            }
        }

        public string Title { get; set; } = DefaultTitle;

        public string StatusImage
        {
            get
            {
                return string.IsNullOrEmpty(Status?.ImagePath) ? null : Status.ImagePath;
            }
            set
            {
                if (Status != null)
                {
                    Status.ImagePath = value;
                }
            }
        }

        public string Url { get; set; } = string.Empty;

        [Browsable(false)]
        public Domain Domain { get; set; }

        [Browsable(false)]
        public ListingStatus Status { get; set; } = CommonStatus.NewStatus;

    }
}
