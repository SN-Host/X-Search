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
        private ThreadedBindingList<SearchListing> SearchListings
        {
            get
            {
                return CurrentSession.SearchListings;
            }
        }

        public Workspace(MainForm mainForm)
        {
            InitializeComponent();

            // Ensure our DataGridView is linked to our session's search listings
            BindData();

            //  Ensure double buffering is enabled using reflection.
            Type dgvType = mainDataGridView.GetType();
            PropertyInfo? pi = dgvType.GetProperty("DoubleBuffered",
                BindingFlags.Instance | BindingFlags.NonPublic);
            pi?.SetValue(mainDataGridView, true, null);
        }

        public void BindData()
        {
            BindingSource bindingSource = new BindingSource()
            {
                DataSource = SearchListings
            };

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
        /// TODO: Replace with a nullable prop, most likely.
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
        /// Opens the web preview window.
        /// </summary>
        private void webPreviewButton_Click(object sender, EventArgs e)
        {
            if (!PagePreviewActive())
            {
                pagePreview = new PagePreview();
            }
            pagePreview.Show();
        }

        /// <summary>
        /// Crosses an item using library calls.
        /// </summary>
        private void crossButton_Click(object sender, EventArgs e)
        {
            CurrentSession.ChangeStatusAtListingIndexes(CurrentlySelectedRowIndices, CrossedStatus);
        }

        /// <summary>
        /// Uncrosses an item using library calls.
        /// </summary>
        private void uncrossButton_Click(object sender, EventArgs e)
        {
            CurrentSession.ChangeStatusAtListingIndexes(CurrentlySelectedRowIndices, UnevaluatedStatus);
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
                foreach (int index in CurrentlySelectedRowIndices)
                {
                    // TODO: We want to add this data checking to make it a property of a status definition.
                    // They should have a method that runs to determine how they interact with other statuses, or maybe sets of lists.
                    // Then we can bake it into ChangeStatusAtListingIndex.
                    if (SearchListings[index].Status == UnevaluatedStatus)
                    {
                        CurrentSession.ChangeStatusAtListingIndex(index, CrossedStatus);
                    }
                    else
                    {
                        CurrentSession.ChangeStatusAtListingIndex(index, UnevaluatedStatus);
                    }
                }

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

        /// <summary>
        /// Allows strings to be used as resource paths for the purposes of displaying status images.
        /// </summary>
        private void mainDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.mainDataGridView.Columns[e.ColumnIndex] is DataGridViewImageColumn)
            {
                // TODO: Replace with WindowsFormsApplication1.Properties.Resources refs
                string imagePath = (e.Value ?? string.Empty).ToString().Trim();
                if (!string.IsNullOrEmpty(imagePath))
                {
                    e.Value = XSearch_WinForms.Properties.Resources.ResourceManager.GetObject(imagePath);
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
                await CurrentSession.Searcher.PullSearch();
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
        /// Clears a listing at the selected index.
        /// </summary>
        private void clearListingButton_Click(object sender, EventArgs e)
        {
            DialogResult clear = MessageBox.Show($"Clear {SearchListings[CurrentRowIndex].Title} of domain {SearchListings[CurrentRowIndex].DomainName}?", "Clear listing?", MessageBoxButtons.YesNo);

            if (clear == DialogResult.Yes)
            {
                SearchListings.RemoveAt(CurrentRowIndex);
            }
        }

        /// <summary>
        /// Clears all listings.
        /// </summary>
        private void clearAllButton_Click(object sender, EventArgs e)
        {
            DialogResult clear = MessageBox.Show($"Clear all listings?", "Clear listings?", MessageBoxButtons.YesNo);

            if (clear == DialogResult.Yes)
            {
                SearchListings.Clear();
            }
        }

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

        private void saveSessionButton_Click(object sender, EventArgs e)
        {
            sessionSaveFileDialog.Title = $"New Session {DateTime.Now.ToString("MM'-'dd'-'yyyy")}";
            sessionSaveFileDialog.FileName = $"New Session {DateTime.Now.ToString("MM'-'dd'-'yyyy")}";

            string path = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "..\\Sessions"));
            Directory.CreateDirectory(path);

            sessionSaveFileDialog.InitialDirectory = path;
            sessionSaveFileDialog.ShowDialog();

            if (sessionSaveFileDialog.FileName != string.Empty)
            {
                Stream writer = sessionSaveFileDialog.OpenFile();

                CurrentSession.SaveToFile(writer);
            }
        }

        private void loadSessionButton_Click(object sender, EventArgs e)
        {
            sessionOpenFileDialog.Title = "Load session";

            string path = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "..\\Sessions"));
            Directory.CreateDirectory(path);

            sessionOpenFileDialog.InitialDirectory = path;
            sessionOpenFileDialog.ShowDialog();

            if (sessionOpenFileDialog.FileName != string.Empty)
            {
                Stream reader = sessionOpenFileDialog.OpenFile();

                CurrentSession.LoadFromFile(reader);
            }
        }
    }
}
