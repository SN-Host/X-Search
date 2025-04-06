using System;
using System.ComponentModel;
using System.Net;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Serialization;
using HtmlAgilityPack;
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

        public void ChangeListingStatus(SearchListing listingToSort, ListingStatus newStatus, bool resort = true)
        {
            // Find item for status change.
            // TODO: Split into a method inside SearchListing for cleanliness.
            listingToSort.Status = newStatus;
            listingToSort.StatusId = newStatus.StatusId;

            // Early exit if this isn't a resort.
            if (!resort)
            {
                return;
            }

            // TODO: Reconsider sort approaches; this is a bit slow.

            // Remove the status to be changed from the list if we didn't already do so.
            SearchListings.Remove(listingToSort);

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
        
        public void SaveToFile(Stream stream, bool saveDomainProfilePath = true)
        {
            if (saveDomainProfilePath)
            {
                DomainProfilePath = DomainProfile.LastFilePath;
            }

            XmlSerializer serializer = new XmlSerializer(typeof(Session));

            serializer.Serialize(stream, this);
            
            stream.Close();
        }

        public void LoadFromFile(Stream stream)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Session));

            Session? session = serializer.Deserialize(stream) as Session;

            if (session == null)
            {
                return;
            }

            // Clear current search listings to make way for the new.
            SearchListings.Clear();

            foreach (SearchListing listing in session.SearchListings)
            {
                if (CommonStatus.IdToStatus.TryGetValue(listing.StatusId, out ListingStatus? status))
                {
                    listing.Status = status;
                }
                SearchListings.Add(listing);
            }

            stream.Close();
        }

        public static Session? TryGetSessionFromStream(Stream stream)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Session));

            Session? session = serializer.Deserialize(stream) as Session;

            if (session == null)
            {
                return session;
            }

            foreach (SearchListing listing in session.SearchListings)
            {
                if (CommonStatus.IdToStatus.TryGetValue(listing.StatusId, out ListingStatus? status) && status != null)
                {
                    listing.Status = status;
                }
            }

            stream.Close();

            return session;
        }
    }
}
