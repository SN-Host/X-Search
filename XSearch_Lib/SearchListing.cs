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
            Domain = new Domain(delegate { });
            DomainId = Domain.DomainId;
            StatusId = Status.StatusId;
        }

        public SearchListing(string title, Domain domain, string url, DateTime dateTime)
        {
            Title = title;
            Domain = domain;
            DomainId = Domain.DomainId;
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

        [Browsable(false)]
        public DateTime DateTimeRetrieved { get; set; } = DateTime.MinValue;

        /// <summary>
        /// Exists for access by UI elements.
        /// </summary>
        [XmlIgnore]
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

        /// <summary>
        /// Used in saving/loading to reunite search listings with their domains.
        /// </summary>
        [Browsable(false)]
        public string DomainId { get; set; }

        /// <summary>
        /// Used in saving/loading reunite search listings with their statuses.
        /// </summary>
        [Browsable(false)]
        public string StatusId { get; set; }

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
        public Domain Domain { get; set; }

        [Browsable(false)]
        [XmlIgnore]
        public ListingStatus Status { get; set; } = CommonStatus.UnevaluatedStatus;

    }
}
