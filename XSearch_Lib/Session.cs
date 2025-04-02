using System;
using System.ComponentModel;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Serialization;
using HtmlAgilityPack;
using static XSearch_Lib.SearchHandler;
using static XSearch_Lib.XSearch_Strings;

namespace XSearch_Lib
{
    public class Session
    {

        // TODO: XML Serializer Generator tool https://learn.microsoft.com/en-us/dotnet/standard/serialization/xml-serializer-generator-tool-sgen-exe

        // CONSTRUCTOR //

        public Session()
        {
            Searcher = new SessionSearcher(this);
            if (DomainProfilePath != null && File.Exists(DomainProfilePath))
            {
                // Logic here to open profile from path
            }
        }

        // PROPERTIES //

        /// <summary>
        /// Current session managed by the program.
        /// </summary>
        public static Session? CurrentSession { get; set; }

        /// <summary>
        /// Master list of all pulled search listings.
        /// </summary>
        public BindingList<SearchListing> SearchListings { get; set; } = new BindingList<SearchListing>();

        /// <summary>
        /// File path of the previously used domain profile for this session, if applicable, for use in saving/loading.
        /// </summary>
        public string? DomainProfilePath { get; set; } = null;

        /// <summary>
        /// Current domain profile.
        /// </summary>
        [XmlIgnore]
        public DomainProfile DomainProfile { get; set; } = new DomainProfile();

        /// <summary>
        /// The SessionSearcher instance responsible for carrying out this session's searches.
        /// </summary>
        [XmlIgnore]
        public SessionSearcher Searcher { get; set; }

        public void ChangeStatusAtListingIndex(int index, ListingStatus newStatus, bool resort = true)
        {
            // Early exit if an invalid index was given.
            if (index < 0 || index > SearchListings.Count - 1)
            {
                return;
            }

            // Find item for status change.
            // TODO: Split into a method inside SearchListing for cleanliness.
            SearchListing listingToSort = SearchListings[index];
            listingToSort.Status = newStatus;
            listingToSort.StatusId = newStatus.StatusId;

            // Early exit if this isn't a resort.
            if (!resort)
            {
                return;
            }
            
            // TODO: Reconsider sort approaches.

            // Remove the status to be changed from the list.
            SearchListings.RemoveAt(index);
            int newIndex = 0;

            while (newIndex < SearchListings.Count)
            {
                // Exit the loop as soon as we find an entry with an index higher than our listing's new index.
                if (SearchListings[newIndex].Status.SortIndex < listingToSort.Status.SortIndex)
                {
                    break;
                }

                // Otherwise, move to the next index.
                newIndex++;
            }

            // Do insertion.
            SearchListings.Insert(newIndex, listingToSort);
        }

        /// <summary>
        /// Changes statuses for multiple SearchListings by index.
        /// </summary>
        /// <param name="indexes">The indexes of SearchListings to change.</param>
        /// <param name="newStatus">The new status to apply.</param>
        /// <param name="resort">Whether the items whose statuses have changed should be resorted.</param>
        public void ChangeStatusAtListingIndexes(IEnumerable<int> indexes, ListingStatus newStatus, bool resort = true)
        {
            foreach (int index in indexes)
            {
                ChangeStatusAtListingIndex(index, newStatus, resort);
            }
        }
        
        public void SaveSession(Stream stream, bool saveDomainProfilePath = true)
        {
            if (saveDomainProfilePath)
            {
                DomainProfilePath = DomainProfile.LastFilePath;
            }

            XmlSerializer serializer = new XmlSerializer(typeof(Session));

            serializer.Serialize(stream, this);
            
            stream.Close();
        }
    }
}
