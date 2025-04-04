using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using XSearch_Lib;
using static XSearch_Lib.CommonStatus;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static XSearch_WinForms.Domains;
using Microsoft.Web.WebView2.Core;
using System.Diagnostics;
using static System.Windows.Forms.LinkLabel;
using System.Reflection;

namespace XSearch_WinForms
{
    public partial class Settings : Form
    {

        /// <summary>
        /// Gets or sets whether the UI tooltips are shown or not.
        /// </summary>
        public bool ShowTooltips { get; set; } = true;

        public Settings()
        {
            InitializeComponent();

            headlessCheckBox.DataBindings.Add(nameof(headlessCheckBox.Checked), Program.CurrentSession.Searcher, nameof(SessionSearcher.RunHeadless));
            toggleTooltipsCheckBox.DataBindings.Add(nameof(toggleTooltipsCheckBox.Checked), this, nameof(ShowTooltips));
        }

        private void headlessCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.UseHeadlessBrowsing = headlessCheckBox.Checked;
            Properties.Settings.Default.Save();
        }

        private void toggleTooltipsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.ShowTooltips = toggleTooltipsCheckBox.Checked;
            Properties.Settings.Default.Save();
        }
    }
}
