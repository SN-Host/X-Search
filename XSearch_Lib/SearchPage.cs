using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XSearch_Lib
{
    /// <summary>
    /// Holds data on search pages queried during pulls.
    /// </summary>
    public class SearchPage
    {
        public string Url { get; set; }
        public Domain Domain { get; set; }

        public SearchPage(string url,  Domain domain)
        {
            Url = url;
            Domain = domain;
        }
    }
}
