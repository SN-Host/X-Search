using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using static XSearch_Lib.XSearch_Strings;

namespace XSearch_Lib
{
    // TODO: Remove possible nulls
    public class SearchListing
    {
        // CONSTRUCTORS //

        /// <summary>
        /// Exists only for the purposes of XML serialization. Do not use to create new instances.
        /// </summary>
        private SearchListing() 
        {
            StatusId = Status.StatusId;
        }

        public SearchListing(string title, string domainName, string url, DateTime dateTime)
        {
            Title = title;
            DomainName = domainName;
            StatusId = Status.StatusId;
            Url = url;
            DateTimeRetrieved = dateTime;
        }

        // PROPERTIES //

        public string Title { get; set; } = Listing_Default_Title;

        public string Url { get; set; } = string.Empty;

        public string RetrievalTimeString 
        { 
            get
            {
                return DateTimeRetrieved.ToString(@"MM\/dd\/yyyy h\:mm tt");
            }
        }
        public string DomainName { get; set; } = Domain_Default_Label;

        [Browsable(false)]
        public DateTime DateTimeRetrieved { get; set; } = DateTime.MinValue;
        /// <summary>
        /// Used in saving/loading reunite search listings with their statuses.
        /// </summary>
        [Browsable(false)]
        public string StatusId { get; set; } = nameof(CommonStatus.UnevaluatedStatus);

        [XmlIgnore]
        public string StatusImage
        {
            get
            {
                string path = string.Empty;

                if (!string.IsNullOrEmpty(Status.ImagePath))
                {
                    path = Status.ImagePath;
                }

                return path;
            }
            set
            {
                if (Status != null)
                {
                    Status.ImagePath = value;
                }
            }
        }

        [Browsable(false)]
        [XmlIgnore]
        public ListingStatus Status { get; set; } = CommonStatus.UnevaluatedStatus;

    }
}
