using System;
using System.ComponentModel;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using HtmlAgilityPack;
using static XSearch_Lib.SearchHandler;
using static XSearch_Lib.Strings;

namespace XSearch_Lib
{
    public class Session
    {

        // CONSTRUCTOR //
        public Session()
        {
            Searcher = new SessionSearcher(this);
        }

        // PROPERTIES //

        /// <summary>
        /// Master list of all pulled search listings.
        /// </summary>
        public BindingList<SearchListing> SearchListings { get; set; } = new BindingList<SearchListing>();

        /// <summary>
        /// Current domain profile.
        /// </summary>
        public DomainProfile DomainProfile { get; set; } = new DomainProfile();

        /// <summary>
        /// The SessionSearcher instance responsible for carrying out this session's searches.
        /// </summary>
        public SessionSearcher Searcher { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <param name="newStatus"></param>
        /// <param name="resort"></param>
        public void ChangeStatusAtListingIndex(int index, ListingStatus newStatus, bool resort = true)
        {
            // Early exit if an invalid index was given.
            if (index < 0 || index > SearchListings.Count - 1)
            {
                return;
            }

            // Early exit if status change is unnecessary.
            if (SearchListings[index].Status == newStatus)
            {
                return;
            }

            // Find item for status change.
            SearchListing listingToSort = SearchListings[index];
            listingToSort.Status = newStatus;

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
                if (SearchListings[newIndex].Status.Index < listingToSort.Status.Index)
                {
                    break;
                }

                // Otherwise, move to the next element.
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
    }
}
