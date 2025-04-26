using System.ComponentModel;
using XSearch_Lib;
using TextBox = System.Windows.Forms.TextBox;

namespace XSearch_WinForms
{
    public partial class Domains : Form
    {
        // FIELDS // 

        /// <summary>
        /// Names of columns to display in the main datagridview.
        /// </summary>
        private static readonly string[] displayedColumns =
        [
            nameof(Domain.Active),
            nameof(Domain.Label),
            nameof(Domain.SearchUrlPattern),
            nameof(Domain.ListingUrlPattern),
        ];

        // PROPERTIES //

        /// <summary>
        /// The index of the currently selected row on the domain datagridview.
        /// </summary>
        public int CurrentRowIndex => mainDataGridView.CurrentCell?.RowIndex ?? -1;

        /// <summary>
        /// More concise accessor for session domains.
        /// </summary>
        private BindingList<Domain> sessionDomains
        {
            get
            {
                return Program.CurrentSession.DomainProfile.Domains;
            }
        }

        /// <summary>
        /// Gets the domain equivalent to the currently selected row, if any.
        /// </summary>
        private Domain? selectedDomain
        {
            get
            {
                return CurrentRowIndex < 0 ? null : sessionDomains[CurrentRowIndex];
            }
        }

        /// <summary>
        /// Gets a collection of all currently selected row indices.
        /// </summary>
        public IEnumerable<int> CurrentlySelectedRowIndices
        {
            get
            {
                foreach (DataGridViewRow row in mainDataGridView.SelectedRows)
                {
                    yield return row.Index;
                }
            }
        }

        public Domains(MainForm mainForm)
        {
            InitializeComponent();

            BindData();

            // Ensure that only members of Domain corresponding to items in our displayedColumns list render.

            foreach (DataGridViewColumn column in mainDataGridView.Columns)
            {
                if (!displayedColumns.Contains(column.DataPropertyName))
                {
                    column.Visible = false;
                }
            }

            // Update image sizes based on client DPI, since Windows Forms is not good at handling this automatically.
            float uiScale = WinformsUIUtilities.CalculateUIScaleFromClientDPI(this);
            WinformsUIUtilities.ResizeImageListForDPIChange(mainImageList, uiScale);
        }

        public void BindData()
        {
            // Bind control data to internal values.
            BindingSource bindingSource = new BindingSource()
            {
                DataSource = Program.CurrentSession.DomainProfile.Domains
            };

            mainDataGridView.DataSource = Program.CurrentSession.DomainProfile.Domains;

            bindingSource.ResetBindings(false);

            // Clear databindings in case they were set once already
            labelTextBox.DataBindings.Clear();
            searchUrlTextBox.DataBindings.Clear();
            listingUrlTextBox.DataBindings.Clear();
            xpathEditorTextBox.DataBindings.Clear();

            // Setting this property ensures our textboxes will update the DataGridView in real time.
            labelTextBox.DataBindings.DefaultDataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged;
            searchUrlTextBox.DataBindings.DefaultDataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged;
            listingUrlTextBox.DataBindings.DefaultDataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged;
            xpathEditorTextBox.DataBindings.DefaultDataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged;

            // These databindings are essential for allowing our textboxes to directly modify domain data.
            labelTextBox.DataBindings.Add(nameof(labelTextBox.Text), mainDataGridView.DataSource, nameof(Domain.Label));
            searchUrlTextBox.DataBindings.Add(nameof(searchUrlTextBox.Text), mainDataGridView.DataSource, nameof(Domain.SearchUrlPattern));
            listingUrlTextBox.DataBindings.Add(nameof(listingUrlTextBox.Text), mainDataGridView.DataSource, nameof(Domain.ListingUrlPattern));
            xpathEditorTextBox.DataBindings.Add(nameof(xpathEditorTextBox.Text), mainDataGridView.DataSource, nameof(Domain.NoSearchResultsXpath));

        }

        /// <summary>
        /// General method for any time search URL patterns are rejected.
        /// </summary>
        public void SearchUrlPatternRejected(Domain domain, ErrorReportArgs eArgs)
        {
            HandleTooltips(true, searchUrlTextBox, eArgs.ErrorTitle, eArgs.ErrorText);
        }

        /// <summary>
        /// Adds a new domain to the current profile.
        /// </summary>
        private void addNewDomainButton_Click(object sender, EventArgs e)
        {
            sessionDomains.Add(new Domain(SearchUrlPatternRejected));
        }

        /// <summary>
        /// Removes the currently selected domains from the current profile.
        /// </summary>
        private void removeDomainButton_Click(object sender, EventArgs e)
        {
            int count = mainDataGridView.SelectedRows.Count;

            if (count <= 0)
            {
                return;
            }

            DialogResult clear = MessageBox.Show($"Clear {count} {(count > 1 ? "domains" : "domain")}?", "Clear domains?", MessageBoxButtons.YesNo);

            if (clear == DialogResult.Yes)
            {
                foreach (DataGridViewRow row in mainDataGridView.SelectedRows)
                {
                    sessionDomains.RemoveAt(row.Index);
                }
            }

        }

        private void enableDomainButton_Click(object sender, EventArgs e)
        {
            ToggleSelectedDomains();
        }

        /// <summary>
        /// Toggles the currently selected domain as active for searching.
        /// </summary>
        private void ToggleSelectedDomains()
        {
            // Final state we're going to set all buttons to.
            bool newToggleState = false;

            List<Domain> domainsToToggle = new List<Domain>();

            // Determine toggling behavior.
            foreach (DataGridViewRow row in mainDataGridView.SelectedRows)
            {
                domainsToToggle.Add(sessionDomains[row.Index]);

                // If any of the rows are inactive, we should enable all.
                if (newToggleState == false && !sessionDomains[row.Index].Active)
                {
                    newToggleState = true;
                }
            }

            // Perform actual toggle.
            foreach (Domain domain in domainsToToggle)
            {
                domain.Active = newToggleState;
            }
        }

        /// <summary>
        /// General handler for tooltips over invalid textboxes.
        /// </summary>
        private void HandleTooltips(bool shouldShowToolTip, TextBox textbox, string? title = null, string? body = null)
        {
            // Early exit if the form is not visible to display changes.
            if (!Visible)
            {
                return;
            }

            WinformsUIUtilities.HandleTooltipsForInvalidTextBox(errorTooltip, shouldShowToolTip, textbox, title, body);
        }

        /// <summary>
        /// Provides real-time feedback about search URL patterns.
        /// </summary>
        private void searchUrlTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (sessionDomains[CurrentRowIndex].SearchUrlPatternedString.RawPatternPredicate(searchUrlTextBox.Text))
            {
                HandleTooltips(false, searchUrlTextBox);
            }
        }

        /// <summary>
        /// Clears all domains in the current profile.
        /// </summary>
        private void clearDomainsButton_Click(object sender, EventArgs e)
        {
            sessionDomains.Clear();
        }

        private void mainDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (selectedDomain == null || selectedDomain.NoSearchResultsXpath.Count <= 0)
            {
                xpathEditorComboBox.DataSource = null;
                xpathEditorTextBox.Text = string.Empty;
                return;
            }
            BindingSource bs = new BindingSource();
            bs.DataSource = selectedDomain?.NoSearchResultsXpath;
            xpathEditorComboBox.DataSource = bs;
        }

        private void addNewXpathButton_Click(object sender, EventArgs e)
        {
            if (selectedDomain == null)
            {
                return;
            }
            selectedDomain.NoSearchResultsXpath.Insert(0, string.Empty);
            mainDataGridView_SelectionChanged(sender, e);
            xpathEditorComboBox.SelectedIndex = 0;
        }

        private void xpathEditorComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (selectedDomain == null)
            {
                return;
            }
            if (selectedDomain.NoSearchResultsXpath.Count == 0)
            {
                return;
            }
            if (xpathEditorComboBox.SelectedIndex < 0)
            {
                return;
            }
            xpathEditorTextBox.Text = xpathEditorComboBox.Text;
        }

        private void xpathEditorTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (selectedDomain == null)
            {
                return;
            }
            if (xpathEditorComboBox.SelectedIndex < 0)
            {
                addNewXpathButton_Click(sender, e);
            }
            selectedDomain.NoSearchResultsXpath[xpathEditorComboBox.SelectedIndex] = xpathEditorTextBox.Text;
        }

        private void deleteXpathButton_Click(object sender, EventArgs e)
        {
            if (selectedDomain == null)
            {
                return;
            }
            if (xpathEditorComboBox.SelectedIndex < 0)
            {
                return;
            }
            selectedDomain.NoSearchResultsXpath.RemoveAt(xpathEditorComboBox.SelectedIndex);

            xpathEditorComboBox_SelectedIndexChanged(sender, e);
        }

        private void saveDomainsButton_Click(object sender, EventArgs e)
        {
            domainsSaveFileDialog.FileName = $"New Domain Profile {DateTime.Now.ToString("MM'-'dd'-'yyyy")}";

            string path = Path.GetFullPath(Path.Combine(Application.ExecutablePath, "..\\Domains"));
            Directory.CreateDirectory(path);

            domainsSaveFileDialog.InitialDirectory = path;
            domainsSaveFileDialog.ShowDialog();

            if (domainsSaveFileDialog.FileName != string.Empty)
            {
                Stream writer = domainsSaveFileDialog.OpenFile();

                Program.CurrentSession.DomainProfile.SaveToFile(writer, Path.GetFullPath(domainsSaveFileDialog.FileName));
            }
        }

        private void loadDomainsButton_Click(object sender, EventArgs e)
        {
            string path = Path.GetFullPath(Path.Combine(Application.ExecutablePath, "..\\Domains"));
            Directory.CreateDirectory(path);

            domainsOpenFileDialog.InitialDirectory = path;
            domainsOpenFileDialog.ShowDialog();

            if (domainsOpenFileDialog.FileName != string.Empty)
            {
                Stream reader = domainsOpenFileDialog.OpenFile();

                Program.CurrentSession.DomainProfile.LoadFromFile(reader, SearchUrlPatternRejected);
            }

            BindData();
        }

        /// <summary>
        /// Handles domain hotkeys.
        /// </summary>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            // TODO: Replace hard references with a dictionary, linked to keybindings customizable in the settings menu. Here, keys are the name of the setting and values are the Key

            // Quick enable/disable domains.
            if (keyData == (Keys.Space | Keys.Control))
            {
                ToggleSelectedDomains();
                return true;
            }

            // Allow default handling of keystrokes if our shortcuts weren't used.
            return base.ProcessCmdKey(ref msg, keyData);
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
    }
}
