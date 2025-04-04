using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Web.WebView2.Core;
using XSearch_Lib;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static XSearch_WinForms.Workspace;
using TextBox = System.Windows.Forms.TextBox;

namespace XSearch_WinForms
{
    public partial class Domains : Form
    {
        // CONSTANTS //

        /// <summary>
        /// Default hover time for tooltips.
        /// </summary>
        private int TOOLTIP_HOVERTIME = 5000;

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


            // TODO: Remove for release
            // For debug testing and demo purposes only because profiles are not currently implemented, I've added two default domains.
            // See below for the long list of domains I attempted to add, but ran into problems with.
            /*
            Domain eBay = new Domain(SearchUrlPatternRejected)
            {
                Label = "Ebay",
                ListingUrlPattern = $"/itm/",
                SearchUrlPattern = $"https://www.ebay.com/sch/i.html?_nkw={Domain.URL_SEARCHTERM_PLACEHOLDER_PATTERN}&_pgn=1",
                NoSearchResultsXpath = new BindingList<string>()
                {
                    "//nav/a[@class=\"pagination__next icon-link\"]"
                }
            };

            Domain craigsList = new Domain(SearchUrlPatternRejected)
            {
                Label = "Craigslist",
                ListingUrlPattern = $"/d/",
                SearchUrlPattern = $"https://houston.craigslist.org/search/cta?query={Domain.URL_SEARCHTERM_PLACEHOLDER_PATTERN}#search=2~gallery~1",
            };

            Domain offerUp = new Domain(SearchUrlPatternRejected)
            {
                Label = "Offerup",
                ListingUrlPattern = $"/item/detail/",
                SearchUrlPattern = $"https://offerup.com/search?q={Domain.URL_SEARCHTERM_PLACEHOLDER_PATTERN}",
            };

            Domain carsCom = new Domain(SearchUrlPatternRejected)
            {
                Label = "Cars.com (Toyota vehicles)",
                ListingUrlPattern = $"/vehicledetail/",
                SearchUrlPattern = $"\r\nhttps://www.cars.com/shopping/results/?_unused_include_shippable=&_unused_keyword=&_unused_list_price_max=&_unused_list_price_min=&_unused_makes[]=&_unused_maximum_distance=&_unused_mileage_max=&_unused_models[]=&_unused_monthly_payment=&_unused_stock_type=&_unused_year_min=&_unused_zip=&dealer_id=&include_shippable=true&keyword=&list_price_max=&list_price_min=&makes[]=toyota&maximum_distance=50&mileage_max=&models[]={Domain.URL_SEARCHTERM_PLACEHOLDER_PATTERN}-{Domain.URL_SEARCHTERM_PLACEHOLDER_PATTERN}&monthly_payment=&page=1&page_size=20&sort=best_match_desc&stock_type=used&year_max=2010&year_min=&zip=77041",
                NoSearchResultsXpath = new BindingList<string>()
                {
                    "//*[@id=\"next_paginate\"]"
                }
            };

            Domain edmunds = new Domain(SearchUrlPatternRejected)
            {
                Label = "Edmunds (Toyota vehicles)",
                ListingUrlPattern = $"/vin/",
                SearchUrlPattern = $"https://www.edmunds.com/inventory/srp.html?inventorytype=used%2Ccpo&make=toyota&model={Domain.URL_SEARCHTERM_PLACEHOLDER_PATTERN}|{Domain.URL_SEARCHTERM_PLACEHOLDER_PATTERN}&pagenumber=1",
                NoSearchResultsXpath = new BindingList<string>()
                {
                    "//nav/ul/li/a[@aria-label=\"Go to the next page\"]"
                }
            };

            Domain fbMarketplace = new Domain(SearchUrlPatternRejected)
            {
                Label = "Facebook Marketplace",
                ListingUrlPattern = $"/marketplace/item/",
                SearchUrlPattern = $"https://www.facebook.com/marketplace/houston/search/?query={Domain.URL_SEARCHTERM_PLACEHOLDER_PATTERN}%20{Domain.URL_SEARCHTERM_PLACEHOLDER_PATTERN}&pagen=1",
                NoSearchResultsXpath = new BindingList<string>()
                {
                    "//div[@aria-label=\"Close\"][@role=\"button\"]"
                }
            };

            Program.CurrentSession.DomainProfile.Domains.Add(eBay);
            Program.CurrentSession.DomainProfile.Domains.Add(craigsList);
            Program.CurrentSession.DomainProfile.Domains.Add(offerUp);
            Program.CurrentSession.DomainProfile.Domains.Add(carsCom);
            Program.CurrentSession.DomainProfile.Domains.Add(edmunds);
            Program.CurrentSession.DomainProfile.Domains.Add(fbMarketplace);

            // Below are some examples of domains that immediately identify X-Search as a bot, and are thus currently unscrapable.

            Domain indeed = new Domain(SearchUrlPatternRejected)
            {
                Label = "Indeed.com",
                ListingUrlPattern = @"/viewjob?",
                SearchUrlPattern = $"https://www.indeed.com/jobs?q={Domain.URL_SEARCHTERM_PLACEHOLDER_PATTERN}&l=houston%2C+tx&radius=35&vjk=74f724e50cbcc7b3&start=",
            };

            Domain linkedin = new Domain(SearchUrlPatternRejected)
            {
                Label = "Linkedin",
                ListingUrlPattern = $"/jobs/view/",
                SearchUrlPattern = $"https://www.linkedin.com/jobs/search?keywords={Domain.URL_SEARCHTERM_PLACEHOLDER_PATTERN}&location=Houston&geoId=103743442&position=1&pageNum=1",
            };

            Domain autotempest = new Domain(SearchUrlPatternRejected)
            {
                Label = "Autotempest",
                ListingUrlPattern = $"/details/",
                SearchUrlPattern = $"https://www.autotempest.com/results?make={Domain.URL_SEARCHTERM_PLACEHOLDER_PATTERN}&model={Domain.URL_SEARCHTERM_PLACEHOLDER_PATTERN}&zip=77041&radius=50",
            };

            Domain zillow = new Domain(SearchUrlPatternRejected)
            {
                Label = "Zillow",
                ListingUrlPattern = $"/homedetails/",
                SearchUrlPattern = $"https://www.zillow.com/houston-tx-77041/1_p/?searchQueryState=%7B%22pagination%22%3A%7B%22currentPage%22%3A2%7D%2C%22isMapVisible%22%3Atrue%2C%22mapBounds%22%3A%7B%22west%22%3A-95.66721740551758%2C%22east%22%3A-95.46637359448242%2C%22south%22%3A29.805973092052174%2C%22north%22%3A29.94053580720247%7D%2C%22regionSelection%22%3A%5B%7B%22regionId%22%3A91690%2C%22regionType%22%3A7%7D%5D%2C%22filterState%22%3A%7B%22sort%22%3A%7B%22value%22%3A%22globalrelevanceex%22%7D%2C%22beds%22%3A%7B%22min%22%3A2%7D%2C%22baths%22%3A%7B%22min%22%3A2%7D%7D%2C%22isListVisible%22%3Atrue%2C%22mapZoom%22%3A13%2C%22usersSearchTerm%22%3A%22Houston%20TX%2077041%22%7D",
            };
            */
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
            HandleTooltipsForInvalidTextBox(true, searchUrlTextBox, eArgs.ErrorTitle, eArgs.ErrorText);
        }

        /// <summary>
        /// Adds a new domain to the current profile.
        /// </summary>
        private void addNewDomainButton_Click(object sender, EventArgs e)
        {
            sessionDomains.Add(new Domain(SearchUrlPatternRejected));
        }

        /// <summary>
        /// Removes the currently selected domain from the current profile.
        /// </summary>
        private void removeDomainButton_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in mainDataGridView.SelectedRows)
            {
                sessionDomains.RemoveAt(row.Index);
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
                if (sessionDomains[row.Index].Active == false)
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
        /// <param name="shouldShowToolTip">True to make sure the tooltip is shown, false to make sure it's hidden.</param>
        /// <param name="textbox">The textbox to apply the tooltip to.</param>
        /// <param name="title">The title of the tooltip.</param>
        /// <param name="body">The body text of the tooltip.</param>
        private async void HandleTooltipsForInvalidTextBox(bool shouldShowToolTip, TextBox textbox, string? title = null, string? body = null)
        {
            // Early exit if the form is not visible to display changes.
            if (!Visible)
            {
                return;
            }
            if (!shouldShowToolTip)
            {
                errorTooltip.Hide(textbox);
                textbox.BackColor = MainForm.DefaultFieldEntryColor;
            }
            else
            {
                errorTooltip.ToolTipTitle = title;
                errorTooltip.Show(body, textbox, 0, (int)(-textbox.Height * 1.75), TOOLTIP_HOVERTIME);
                textbox.BackColor = MainForm.InvalidFieldEntryColor;
                await Task.Delay(TOOLTIP_HOVERTIME);
                textbox.BackColor = MainForm.DefaultFieldEntryColor;
            }
        }

        /// <summary>
        /// Provides real-time feedback about search URL patterns.
        /// </summary>
        private void searchUrlTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (sessionDomains[CurrentRowIndex].SearchUrlPatternedString.RawPatternPredicate(searchUrlTextBox.Text))
            {
                HandleTooltipsForInvalidTextBox(false, searchUrlTextBox);
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
            // TODO: Make a method for these control calls and call them within the handlers instead of calling the handlers directly
            xpathEditorComboBox_SelectedIndexChanged(sender, e);
        }

        private void saveDomainsButton_Click(object sender, EventArgs e)
        {

            domainsSaveFileDialog.Title = $"New Domain Profile {DateTime.Now.ToString("MM'-'dd'-'yyyy")}";
            domainsSaveFileDialog.FileName = $"New Domain Profile {DateTime.Now.ToString("MM'-'dd'-'yyyy")}";

            string path = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "..\\Domains"));
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
            domainsOpenFileDialog.Title = "Load session";

            string path = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "..\\Domains"));
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
            if (keyData == (Keys.Space))
            {
                ToggleSelectedDomains();
                return true;
            }

            // Allow default handling of keystrokes if our shortcuts weren't used.
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
