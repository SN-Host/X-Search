using XSearch_Lib;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace XSearch_WinForms
{

    public partial class MainForm : Form
    {
        // FIELDS //

        /// <summary>
        /// Index of topmost item in the current scroll position in the workspace DataGridView.
        /// </summary>
        public int CurScrollPos = 0;

        /// <summary>
        /// The form currently framed in the main viewport.
        /// </summary>
        private Form? currentFramedForm;

        /// <summary>
        /// Current option selected from the main menu for highlighting purposes.
        /// </summary>
        private Button? currentIndexSelection;

        /// <summary>
        /// Original color before
        /// </summary>
        private Color? currentIndexSelectionOriginalColor; 
        
        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, bool wParam, IntPtr lParam);

        private const int WM_SETREDRAW = 0x000B;

        // PROPERTIES //

        /// <summary>
        /// Default color for the text of selected buttons.
        /// </summary>
        public static Color SelectedButtonTextColor => Color.FromArgb(150, 150, 200);

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

            // Ensure that all of the form's controls are double buffered for optimized rendering.
            WinformsUIUtilities.SetAllControlsDoubleBuffered(this);

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

            // Update image sizes based on client DPI, since Windows Forms is not good at handling this automatically.
            float uiScale = WinformsUIUtilities.CalculateUIScaleFromClientDPI(this);
            WinformsUIUtilities.ResizeImageListForDPIChange(mainImageList, uiScale);
        }

        /// <summary>
        /// Ensures user config options and autosave/autoload functionality is respected on startup.
        /// </summary>
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

        /// <summary>
        /// 
        /// </summary>
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
                Invoke(new System.Windows.Forms.MethodInvoker(() => { OnNewSearchResults(searchListings); }));
                return;
            }
            foreach (SearchListing sl in searchListings)
            {
                AddNewListing(sl);
            }
        }


        /// <summary>
        /// Adds new search listings on the UI thread while preventing the datagridview from automatically scrolling to any selected listings when updated.
        /// </summary>
        private void AddNewListing(SearchListing sl)
        {
            DataGridView dgv = Workspace.mainDataGridView;

            // Suspending rendering during updating is important to ensuring we don't see any flickering before the row index is restored.
            SendMessage(dgv.Handle, WM_SETREDRAW, false, IntPtr.Zero);

            int rowIndex = dgv.FirstDisplayedScrollingRowIndex;

            // Insert the new listing and ensure it is sorted correctly.
            Program.CurrentSession.SearchListings.Insert(0, sl);
            Program.CurrentSession.ChangeListingStatus(sl, sl.Status);

            dgv.FirstDisplayedScrollingRowIndex = rowIndex;

            SendMessage(dgv.Handle, WM_SETREDRAW, true, IntPtr.Zero);
            dgv.Refresh();
        }

        /// <summary>
        /// Safely handles new search logging events raised by webdriver threads opened in the library.
        /// </summary>
        public void UpdateSearchLog(SessionSearcher searcher, SearchLogArgs sArgs)
        {
            // Ensure calls from other threads are handled properly.
            if (InvokeRequired)
            {
                Invoke(new System.Windows.Forms.MethodInvoker(() => { UpdateSearchLog(searcher, sArgs); }));
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

        public void IndexButtonSelected(Button selectedButton)
        {
            if (selectedButton == currentIndexSelection)
            {
                return;
            }

            // Ensure the original index selection is reverted.
            if (currentIndexSelection != null && currentIndexSelectionOriginalColor != null)
            {
                currentIndexSelection.ForeColor = (Color)currentIndexSelectionOriginalColor;
            }

            currentIndexSelection = selectedButton;
            currentIndexSelectionOriginalColor = selectedButton.ForeColor;

            selectedButton.ForeColor = SelectedButtonTextColor;
        }

        /// <summary>
        /// Frames a child form in the main form's viewport.
        /// </summary>
        public void ChangeFrame(Button button, Form form, Panel controlPanel, string frameLabelText)
        {
            WinformsUIUtilities.FrameForm(framingPanel, ref currentFramedForm, form);
            WinformsUIUtilities.FramePanel(selectionSettingsPanel, controlPanel);

            currentFramedForm = form;

            // Ensure the button the request came from is highlighted.
            //ApplySelectedButtonColor(button, ref selectedMainMenuButton, SelectedButtonColor);
            IndexButtonSelected(button);

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

        private void MainForm_ResizeBegin(object sender, EventArgs e)
        {
            // Suspending drawing this way creates a bunch of ugly black boxes, but it is significantly more responsive than the alternative of SuspendLayout.
            // Still unsure which implementation is better.
            // The best implementation is really just not using Windows Forms for this UI.
            SendMessage(Handle, WM_SETREDRAW, false, IntPtr.Zero);
        }

        private void MainForm_ResizeEnd(object sender, EventArgs e)
        {
            SendMessage(Handle, WM_SETREDRAW, true, IntPtr.Zero);
            Refresh();
        }
    }
}
