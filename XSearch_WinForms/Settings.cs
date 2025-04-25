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
        public static readonly string DefaultAutoSavePath = Path.GetFullPath(Path.Combine(Application.ExecutablePath, "..\\AutoSaves"));
        public static readonly string DefaultAutoSaveSessionFileName = "LastSession.xssp";
        public static readonly string DefaultAutoSaveDomainProfileFileName = "LastDomainProfile.xsdp";

        /// <summary>
        /// Gets or sets whether X-Search runs its webdrivers in headless mode or not.
        /// </summary>
        public bool RunHeadless
        {
            get
            {
                return Program.CurrentSession.Searcher.RunHeadless;
            }
            set
            {
                Program.CurrentSession.Searcher.RunHeadless = value;
            }
        }

        /// <summary>
        /// Gets or sets whether the UI tooltips are shown or not.
        /// </summary>
        public bool ShowTooltips { get; set; } = true;

        /// <summary>
        /// Gets or sets whether the application should be automatically saving/loading or not.
        /// </summary>
        public bool AutoSave { get; set; } = true;

        /// <summary>
        /// Gets or sets the path the application should generate autosave files to.
        /// </summary>
        public string AutoSavePath { get; set; } = string.Empty;

        public Settings()
        {
            InitializeComponent();

            headlessCheckBox.DataBindings.Add(nameof(headlessCheckBox.Checked), this, nameof(RunHeadless));
            toggleTooltipsCheckBox.DataBindings.Add(nameof(toggleTooltipsCheckBox.Checked), this, nameof(ShowTooltips));
            autoSaveCheckBox.DataBindings.Add(nameof(autoSaveCheckBox.Checked), this, nameof(AutoSave));
            autoSavePathTextBox.DataBindings.Add(nameof(autoSavePathTextBox.Text), this, nameof(AutoSavePath));

            // Ensure that all of the form's controls are double buffered for optimized rendering.
            WinformsUIUtilities.SetAllControlsDoubleBuffered(this);
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

        private void autoSaveCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.AutoSave = autoSaveCheckBox.Checked;
            Properties.Settings.Default.Save();
        }

        /// <summary>
        /// Prevents tooltips from showing up if they're disabled.
        /// </summary>
        private void mainToolTip_Popup(object sender, PopupEventArgs e)
        {
            if (Properties.Settings.Default.ShowTooltips == false)
            {
                e.Cancel = true;
            }
        }

        private void autoSavePathTextBox_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.AutoSaveCustomPath = autoSavePathTextBox.Text;
            Properties.Settings.Default.Save();
        }
    }
}
