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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using System.Runtime.InteropServices;

namespace XSearch_WinForms
{
    public partial class Workspace : Form
    {

        // FIELDS //

        /// <summary>
        /// The current instance of the webpage preview window.
        /// </summary>
        private PagePreview pagePreview = new PagePreview();

        /// <summary>
        /// The current instance of the pull search window.
        /// </summary>
        private PullSearch pullSearch = new PullSearch();

        private MainForm mainForm;

        // PROPERTIES //

        /// <summary>
        /// Gets the current row index of the main DataGridView, or -1 if no index is selected.
        /// </summary>
        public int CurrentRowIndex => mainDataGridView.CurrentCell?.RowIndex ?? -1;

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

        /// <summary>
        /// Concise reference to current session.
        /// </summary>
        private Session CurrentSession
        {
            get
            {
                return Program.CurrentSession;
            }
        }

        /// <summary>
        /// Concise reference to current session's search listings.
        /// </summary>
        private BindingList<SearchListing> SearchListings
        {
            get
            {
                return CurrentSession.SearchListings;
            }
        }

        public Workspace(MainForm parent)
        {
            InitializeComponent();

            Type controlType = mainDataGridView.GetType();
            PropertyInfo? pi = controlType.GetProperty("DoubleBuffered",
                BindingFlags.Instance | BindingFlags.NonPublic);
            pi?.SetValue(mainDataGridView, true, null);

            // Do not autogenerate columns to ensure proper ordering.
            mainDataGridView.AutoGenerateColumns = false;

            mainForm = parent;

            // Ensure our DataGridView is linked to our session's search listings
            BindData();

            // Update image sizes based on client DPI, since Windows Forms is not good at handling this automatically.
            float uiScale = WinformsUIUtilities.CalculateUIScaleFromClientDPI(this);
            WinformsUIUtilities.ResizeImageListForDPIChange(mainImageList, uiScale);
            WinformsUIUtilities.ResizeImageListForDPIChange(statusImageList, uiScale);
        }

        public void BindData()
        {
            BindingSource bindingSource = new BindingSource()
            {
                DataSource = SearchListings
            };

            bindingSource.AllowNew = true;

            mainDataGridView.DataSource = bindingSource;
        }

        /// <summary>
        /// Checks if the page preview is active.
        /// </summary>
        public bool PagePreviewActive()
        {
            if (pagePreview == null)
            {
                return false;
            }

            if (pagePreview.IsDisposed)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Checks if the pull search menu is active.
        /// </summary>
        public bool PullSearchWindowActive()
        {
            if (pullSearch == null)
            {
                return false;
            }

            if (pullSearch.IsDisposed)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Updates the webpage preview's source when the selected item is changed in the DataGridView.
        /// </summary>
        private void mainDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            UpdateWebPreview();
            UpdateRowInfo();
        }

        private void UpdateWebPreview()
        {
            if (!PagePreviewActive())
            {
                return;
            }

            Uri? newSource = new Uri("about:blank");

            if (SearchListings.Count > 0)
            {
                newSource = new Uri((SearchListings[CurrentRowIndex < 0 ? 0 : CurrentRowIndex] as SearchListing).Url);
            }

            pagePreview.previewWebView.Source = newSource;
        }

        /// <summary>
        /// Responsible for filling the "row info" info panel.
        /// </summary>
        private void UpdateRowInfo()
        {
            int selectedRowCount = mainDataGridView.SelectedRows.Count;

            if (selectedRowCount <= 0)
            {
                mainForm.rowInfoLabel.Text = string.Empty;
                return;
            }

            string text = $"Row {mainDataGridView.SelectedRows[0].Index}";

            if (selectedRowCount > 1)
            {
                int max = mainDataGridView.SelectedRows[0].Index + 1;
                int min = mainDataGridView.SelectedRows[mainDataGridView.SelectedRows.Count - 1].Index + 1;

                text = $"Rows {min}-{max}, count {mainDataGridView.SelectedRows.Count}";
            }

            mainForm.rowInfoLabel.Text = text;
        }

        /// <summary>
        /// Opens the web preview window.
        /// </summary>
        private void webPreviewButton_Click(object sender, EventArgs e)
        {
            if (!PagePreviewActive())
            {
                pagePreview = new PagePreview();
            }
            pagePreview.Show();

            UpdateWebPreview();
        }

        /// <summary>
        /// Crosses an item using library calls.
        /// </summary>
        private void crossButton_Click(object sender, EventArgs e)
        {
            CrossOrUncrossSelectedRows(forcedStatus: CrossedStatus);
        }

        /// <summary>
        /// Uncrosses an item using library calls.
        /// </summary>
        private void uncrossButton_Click(object sender, EventArgs e)
        {
            CrossOrUncrossSelectedRows(forcedStatus: UnevaluatedStatus);
        }

        /// <summary>
        /// Handles workspace hotkeys.
        /// </summary>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            // TODO: Replace hard references with a dictionary, linked to keybindings customizable in the settings menu. Here, keys are the name of the setting and values are the Key
            // Other hotkey ideas:
            // Home - first listing
            // End - last listing
            // Control + S - Save
            // Control + O - Open

            // Quick crossing/uncrossing functionality.
            if (keyData == (Keys.Space | Keys.Control))
            {
                CrossOrUncrossSelectedRows();

                return true;
            }

            // Allow enter to take you to a workspace link.
            if (keyData == Keys.Enter)
            {
                foreach (int index in CurrentlySelectedRowIndices)
                {
                    Process.Start(new ProcessStartInfo(SearchListings[index].Url) { UseShellExecute = true });
                }

                return true;
            }

            // Allow default handling of keystrokes if our shortcuts weren't used.
            return base.ProcessCmdKey(ref msg, keyData);
        }

        public void CrossOrUncrossSelectedRows(ListingStatus? forcedStatus = null)
        {
            List<SearchListing> listingsToChange = new List<SearchListing>();
            ListingStatus newStatus = forcedStatus == null ? UnevaluatedStatus : forcedStatus;

            foreach (int index in CurrentlySelectedRowIndices)
            {
                listingsToChange.Add(SearchListings[index]);

                // If we're not forcing a status and any of the listings are uncrossed, we should cross all.
                if (forcedStatus == null && SearchListings[index].Status == UnevaluatedStatus)
                {
                    newStatus = CrossedStatus;
                }
            }

            foreach (SearchListing listing in listingsToChange)
            {
                CurrentSession.ChangeListingStatus(listing, newStatus);
            }
        }

        /// <summary>
        /// Allows strings to be used as resource paths for the purposes of displaying image columns.
        /// </summary>
        private void mainDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.mainDataGridView.Columns[e.ColumnIndex] is DataGridViewImageColumn)
            {
                string imageName = (e.Value ?? string.Empty).ToString().Trim();
                if (!string.IsNullOrEmpty(imageName))
                {
                    if (statusImageList.Images.ContainsKey($"{imageName}.png"))
                    {
                        e.Value = statusImageList.Images[$"{imageName}.png"];
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// Opens the dialog to pull a search, or else searches with current settings if shift is held.
        /// </summary>
        private async void pullSearchButton_Click(object sender, EventArgs e)
        {
            // Allow a shortcut.
            if (ModifierKeys == Keys.Shift)
            {
                await Program.CurrentSession.Searcher.PullSearch();
            }
            else
            {
                if (!PullSearchWindowActive())
                {
                    pullSearch = new PullSearch();
                }
                pullSearch.ShowDialog();
            }
        }

        /// <summary>
        /// Clears listings at selected indexes.
        /// </summary>
        private void clearListingButton_Click(object sender, EventArgs e)
        {
            int count = mainDataGridView.SelectedRows.Count;

            if (count <= 0)
            {
                return;
            }

            DialogResult clear = MessageBox.Show($"Clear {count} {(count > 1 ? "listings" : "listing")}? \n(Note: Clearing listings will cause X-Search to pull them again later!)", "Clear listings?", MessageBoxButtons.YesNo);

            if (clear == DialogResult.Yes)
            {
                foreach (DataGridViewRow row in mainDataGridView.SelectedRows)
                {
                    SearchListings.RemoveAt(row.Index);
                }
            }
        }

        /// <summary>
        /// Cancels any ongoing pulls.
        /// </summary>
        private void cancelPullButton_Click(object sender, EventArgs e)
        {
            if (!CurrentSession.Searcher.ShouldCancelPull && CurrentSession.Searcher.CurrentlyPulling)
            {
                CurrentSession.Searcher.ShouldCancelPull = true;
            }
            else
            {
                MessageBox.Show("No pull in progress.", "Cannot cancel");
            }
        }

        /// <summary>
        /// Handles pulled listing searches.
        /// </summary>
        private void searchTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            mainDataGridView.ClearSelection();
            int searchColumnIndex = mainDataGridView.Columns["titleDataGridViewColumn"].Index;
            string searchValue = searchTextBox.Text;

            // Return with cleared selection if searchbox is empty.
            if (string.IsNullOrEmpty(searchValue))
            {
                return;
            }

            try
            {
                foreach (DataGridViewRow row in mainDataGridView.Rows)
                {
                    for (int i = 0; i < row.Cells.Count; i++)
                    {
                        if (row.Cells[i].Value != null && row.Cells[searchColumnIndex]?.Value?.ToString()?.ToLower().IndexOf(searchValue, StringComparison.OrdinalIgnoreCase) >= 0)
                        {
                            int rowIndex = row.Index;
                            mainDataGridView.Rows[rowIndex].Selected = true;
                            break;
                        }

                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        /// <summary>
        /// Allows the workspace DataGridView to display image paths from ListingStatus objects.
        /// </summary>
        private void mainDataGridView_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            if (e.RowIndex == mainDataGridView.RowCount - 1)
            {
                return;
            }

            SearchListing listingTmp = Program.CurrentSession.SearchListings[e.RowIndex];

            switch (mainDataGridView.Columns[e.ColumnIndex].DataPropertyName)
            {
                case nameof(SearchListing.Status):
                    e.Value = listingTmp.Status;
                    break;

                case nameof(SearchListing.DomainName):
                    e.Value = listingTmp.DomainName;
                    break;

                case nameof(SearchListing.Title):
                    e.Value = listingTmp.Title;
                    break;

                case nameof(SearchListing.Url):
                    e.Value = listingTmp.Url;
                    break;

                case nameof(SearchListing.RetrievalTimeString):
                    e.Value = listingTmp.RetrievalTimeString;
                    break;
            }
        }

        /// <summary>
        /// Handles saving using WinForms save file dialogs.
        /// </summary>
        private void saveSessionButton_Click(object sender, EventArgs e)
        {
            sessionSaveFileDialog.FileName = $"New Session {DateTime.Now.ToString("MM'-'dd'-'yyyy")}";

            string path = Path.GetFullPath(Path.Combine(Application.ExecutablePath, "..\\Sessions"));
            Directory.CreateDirectory(path);

            sessionSaveFileDialog.InitialDirectory = path;
            sessionSaveFileDialog.ShowDialog();

            if (sessionSaveFileDialog.FileName != string.Empty)
            {
                Stream writer = sessionSaveFileDialog.OpenFile();

                CurrentSession.SaveToFile(writer);
            }
        }

        /// <summary>
        /// Handles saving using WinForms open file dialogs.
        /// </summary>
        private void loadSessionButton_Click(object sender, EventArgs e)
        {
            string path = Path.GetFullPath(Path.Combine(Application.ExecutablePath, "..\\Sessions"));
            Directory.CreateDirectory(path);

            sessionOpenFileDialog.InitialDirectory = path;
            sessionOpenFileDialog.ShowDialog();

            if (sessionOpenFileDialog.FileName != string.Empty)
            {
                Stream reader = sessionOpenFileDialog.OpenFile();

                CurrentSession.LoadFromFile(reader);
            }
        }

        /// <summary>
        /// Quicksave button to force an autosave.
        /// </summary>
        private void quickSaveButton_Click(object sender, EventArgs e)
        {
            mainForm.TryAutoSaveOrLoad(loading: false, forced: true);
        }

        /// <summary>
        /// Quickload button to force an autoload.
        /// </summary>
        private void quickLoadButton_Click(object sender, EventArgs e)
        {
            mainForm.TryAutoSaveOrLoad(loading: true, forced: true);
        }

        /// <summary>
        /// Helps prevent the workspace from lagging while being resized.
        /// </summary>
        private void Workspace_ResizeBegin(object sender, EventArgs e)
        {
            SuspendLayout();
        }

        /// <summary>
        /// Helps prevent the workspace from lagging while being resized.
        /// </summary>
        private void Workspace_ResizeEnd(object sender, EventArgs e)
        {
            ResumeLayout();
        }

        private void mainDataGridView_Scroll(object sender, ScrollEventArgs e)
        {
            mainForm.CurScrollPos = e.NewValue;
        }
    }
}
