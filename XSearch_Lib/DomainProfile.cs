using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using HtmlAgilityPack;
using static XSearch_Lib.SearchHandler;

namespace XSearch_Lib
{
    /// <summary>
    /// Intended to hold information about domain profiles for saving/loading purposes, once implemented.
    /// </summary>
    public class DomainProfile
    {
        /// <summary>
        /// Must be left public so DataGridViews can use this as a datasource.
        /// </summary>
        public BindingList<Domain> Domains { get; set; } = new BindingList<Domain>();

    }
}
