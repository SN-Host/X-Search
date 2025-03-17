using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public SearchLogArgs(string text)
        {
            _text = text;
        }
    }

}
