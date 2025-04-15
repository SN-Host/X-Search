using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using System.Drawing.Drawing2D;
using System.IO;
using static XSearch_WinForms.Workspace;
using System.ComponentModel;
using XSearch_Lib;
using OpenQA.Selenium.DevTools.V131.Network;
using System.Diagnostics;
using System;

namespace XSearch_WinForms
{

    public partial class MainForm : Form
    {
        // FIELDS //

        /// <summary>
        /// The form currently framed in the main viewport.
        /// </summary>
        private Form? currentFramedForm;

        /// <summary>
        /// Current option selected from the main menu for highlighting purposes.
        /// </summary>
        private Button? selectedMainMenuButton;

        // PROPERTIES //

        /// <summary>
        /// Default color for selected buttons.
        /// </summary>
        public static Color SelectedButtonColor { get; set; } = Color.FromArgb(230, 230, 240);

        /// <summary>
        /// Default color for buttons.
        /// </summary>
        public static Color DefaultButtonColor { get; set; } = Color.FromArgb(250, 250, 255);

        /// <summary>
        /// Default color for field entry textboxes.
        /// </summary>
        public static Color DefaultFieldEntryColor { get; set; } = Color.White;

        /// <summary>
        /// Default color for invalid field entry textboxes.
        /// </summary>
        public static Color InvalidFieldEntryColor { get; set; } = Color.FromArgb(255, 200, 200);

        /// <summary>
        /// Active workspace pane instance.
        /// </summary>
        private Workspace Workspace { get; set; }

        /// <summary>
        /// Active domains pane instance.
        /// </summary>
        private Domains Domains { get; set; }

        /// <summary>
        /// Active settings pane instance.
        /// </summary>
        private Settings Settings { get; set; }

        public MainForm()
        {
            InitializeComponent();

            // Initialize main program tabs.
            Workspace = new Workspace(this);
            Domains = new Domains(this);
            Settings = new Settings();

            LoadSettings();

            // Frame workspace by default.
            ChangeFrame(workspaceButton, Workspace, Workspace.controlPanel, Workspace.Text);

            // Handle events for failed searches.
            Program.CurrentSession.Searcher.OnPullFailedAttempt += GenericErrorMessage;

            // Handle events for update search log updates.
            Program.CurrentSession.Searcher.OnNewSearchUpdateLog += UpdateSearchLog;

            // Handle events for new search results.
            Program.CurrentSession.Searcher.OnNewSearchResults += OnNewSearchResults;
        }

        public void LoadSettings()
        {
            Program.CurrentSession.Searcher.RunHeadless = Properties.Settings.Default.UseHeadlessBrowsing;
            Settings.ShowTooltips = Properties.Settings.Default.ShowTooltips;
            Settings.AutoSave = Properties.Settings.Default.AutoSave;

            if (Properties.Settings.Default.AutoSave)
            {
                TryAutoSaveOrLoad(loading: true);
            }
        }

        public void TryAutoSaveOrLoad(bool loading = true, bool forced = false)
        {
            if (!Settings.AutoSave && !forced)
            {
                return;
            }

            string path = Settings.DefaultAutoSavePath;

            if (!string.IsNullOrEmpty(Settings.AutoSavePath))
            {
                path = Settings.AutoSavePath;
            }

            TryAutoSaveOrLoadSession(path, loading);
            TryAutoSaveOrLoadDomainProfile(path, Domains.SearchUrlPatternRejected, loading);
        }

        public void TryAutoSaveOrLoadSession(string path, bool loading = true)
        {
            string expectedSessionPath = path + $"\\{Settings.DefaultAutoSaveSessionFileName}";
            bool fileExists = File.Exists(expectedSessionPath);

            if (!fileExists && loading == true)
            {
                MessageBox.Show($"No autosave file found at {expectedSessionPath}", "Session autoload failed");
                return;
            }

            Directory.CreateDirectory(path);

            if (loading)
            {
                Stream sessionLoader = File.OpenRead(expectedSessionPath);
                Program.CurrentSession.LoadFromFile(sessionLoader);
            }
            else
            {
                if (fileExists)
                {
                    File.SetAttributes(expectedSessionPath, FileAttributes.Normal);
                    File.Delete(expectedSessionPath);
                }
                Stream sessionSaver = File.OpenWrite(expectedSessionPath);
                Program.CurrentSession.SaveToFile(sessionSaver);
            }
        }

        public void TryAutoSaveOrLoadDomainProfile(string path, Action<Domain, ErrorReportArgs> onSearchUrlPatternRejected, bool loading = true)
        {
            string expectedDomainProfilePath = path + $"\\{Settings.DefaultAutoSaveDomainProfileFileName}";
            bool fileExists = File.Exists(expectedDomainProfilePath);

            if (!fileExists && loading == true)
            {
                MessageBox.Show($"No autosave file found at {expectedDomainProfilePath}", "Domain profile autoload failed");
                return;
            }

            Directory.CreateDirectory(path);

            if (loading)
            {
                Stream domainProfileLoader = File.OpenRead(expectedDomainProfilePath);
                Program.CurrentSession.DomainProfile.LoadFromFile(domainProfileLoader, onSearchUrlPatternRejected);
            }
            else
            {
                if (fileExists)
                {
                    File.SetAttributes(expectedDomainProfilePath, FileAttributes.Normal);
                    File.Delete(expectedDomainProfilePath);
                }
                Stream domainProfileSaver = File.OpenWrite(expectedDomainProfilePath);
                Program.CurrentSession.DomainProfile.SaveToFile(domainProfileSaver, expectedDomainProfilePath);
            }
        }

        /// <summary>
        /// Handles new search result events raised by webdriver threads opened in the library.
        /// </summary>
        public void OnNewSearchResults(IEnumerable<SearchListing> searchListings)
        {
            // Ensure calls from other threads are handled properly.
            if (InvokeRequired)
            {
                // Note to self: It doesn't seem that this call has much of a negative performance impact. It takes about 4ms to run, so marshalling the thread events back to the UI thread shouldn't be that big of a deal.
                Invoke(new MethodInvoker(() => { OnNewSearchResults(searchListings); }));
                return;
            }
            foreach (SearchListing sl in searchListings)
            {
                // Insert the new listing and ensure it is sorted correctly.
                Program.CurrentSession.SearchListings.Insert(0, sl);
                Program.CurrentSession.ChangeListingStatus(sl, sl.Status);
            }
        }

        /// <summary>
        /// Safely handles new search logging events raised by webdriver threads opened in the library.
        /// </summary>
        public void UpdateSearchLog(SessionSearcher searcher, SearchLogArgs sArgs)
        {
            // Ensure calls from other threads are handled properly.
            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(() => { UpdateSearchLog(searcher, sArgs); }));
                return;
            }
            currentStatusHeader.Text = $"{searcher.CurrentSearchTask}";
            statusReportLabel.Text = sArgs.Text;
            searchProgressLabel.Text = searcher.SearchProgress;
        }

        /// <summary>
        /// Displays an error message based on the provided ErrorReportArgs.
        /// </summary>
        public void GenericErrorMessage(Session session, ErrorReportArgs eArgs)
        {
            MessageBox.Show(eArgs.ErrorText, eArgs.ErrorTitle);
        }

        /// <summary>
        /// Changes a button's color to imply selection.
        /// </summary>
        public void ApplySelectedButtonColor(Button curSelection, ref Button oldSelection, Color newColor, Color? defaultColorOverride = null)
        {
            // Use class default if parameter wasn't given.
            if (defaultColorOverride is not Color defaultColor)
            {
                defaultColor = DefaultButtonColor;
            }

            curSelection.BackColor = newColor;

            if (oldSelection != null)
            {
                oldSelection.BackColor = defaultColor;
            }

            oldSelection = curSelection;
        }

        /// <summary>
        /// Frames a child form in the main form's viewport.
        /// </summary>
        public void ChangeFrame(Button button, Form form, Panel controlPanel, string frameLabelText)
        {
            WinformsUIUtilities.FrameForm(framingPanel, ref currentFramedForm, form);
            WinformsUIUtilities.FramePanel(selectionSettingsPanel, controlPanel);

            // Ensure the button the request came from is highlighted.
            //ApplySelectedButtonColor(button, ref selectedMainMenuButton, SelectedButtonColor);

            // Change frameLabel's text to reflect the frame change.
            frameLabel.Text = frameLabelText;
        }

        private void workspaceButton_Click(object sender, EventArgs e)
        {
            ChangeFrame((Button)sender, Workspace, Workspace.controlPanel, Workspace.Text);
        }

        private void domainsButton_Click(object sender, EventArgs e)
        {
            ChangeFrame((Button)sender, Domains, Domains.controlPanel, Domains.Text);
        }

        private void settingsButton_Click(object sender, EventArgs e)
        {
            ChangeFrame((Button)sender, Settings, new Panel(), Settings.Text);
        }

        /// <summary>
        /// Links to user documentation.
        /// TODO: Open a file instead if the server can't be reached.
        /// </summary>
        private void helpButton_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://github.com/SN-Host/X-Search/blob/master/README.md") { UseShellExecute = true });
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

        /// <summary>
        /// Autosaves session and domain data on form close.
        /// </summary>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            TryAutoSaveOrLoad(loading: false);
        }
    }
}
