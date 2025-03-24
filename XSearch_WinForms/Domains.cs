using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
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
        /// The index of the currently selected row on the domain datagridview.
        /// </summary>
        public int CurrentRowIndex => mainDataGridView.CurrentCell?.RowIndex ?? -1;

        /// <summary>
        /// Names of columns to display in the main datagridview.
        /// </summary>
        private static readonly string[] displayedColumns =
        [
            nameof(Domain.Active),
            nameof(Domain.Label),
            nameof(Domain.SearchUrlPattern),
            nameof(Domain.ListingUrlPattern)
        ];

        // PROPERTIES //

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

        public Domains(MainForm mainForm)
        {
            InitializeComponent();

            // Bind control data to internal values.
            BindingSource bindingSource = new BindingSource()
            {
                DataSource = sessionDomains
            };

            mainDataGridView.DataSource = bindingSource;

            // Setting this property ensures our textboxes will update the DataGridView in real time.
            labelTextBox.DataBindings.DefaultDataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged;
            searchUrlTextBox.DataBindings.DefaultDataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged;
            listingUrlTextBox.DataBindings.DefaultDataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged;
            pageCountMultiplierNumericUpDown.DataBindings.DefaultDataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged;

            // These databindings are essential for allowing our textboxes to directly modify domain data.
            labelTextBox.DataBindings.Add(nameof(labelTextBox.Text), mainDataGridView.DataSource, nameof(Domain.Label));
            searchUrlTextBox.DataBindings.Add(nameof(searchUrlTextBox.Text), mainDataGridView.DataSource, nameof(Domain.SearchUrlPattern));
            listingUrlTextBox.DataBindings.Add(nameof(listingUrlTextBox.Text), mainDataGridView.DataSource, nameof(Domain.ListingUrlPattern));
            pageCountMultiplierNumericUpDown.DataBindings.Add(nameof(pageCountMultiplierNumericUpDown.Value), mainDataGridView.DataSource, nameof(Domain.PageCountMultiplier));

            // For debug testing and demo purposes only because profiles are not currently implemented, I've added two default domains.
            // See below for the long list of domains I attempted to add, but ran into problems with.

            Domain eBay = new Domain(SearchUrlPatternRejected)
            {
                Label = "Ebay",
                ListingUrlPattern = $"/itm/",
                SearchUrlPattern = $"https://www.ebay.com/sch/i.html?_nkw={Domain.URL_SEARCHTERM_PLACEHOLDER_PATTERN}&_pgn={Domain.URL_PAGECOUNT_PLACEHOLDER_PATTERN}",
            };
            Domain craigsList = new Domain(SearchUrlPatternRejected)
            {
                Label = "Craigslist",
                ListingUrlPattern = $"/d/",
                SearchUrlPattern = $"https://houston.craigslist.org/search/cta?query={Domain.URL_SEARCHTERM_PLACEHOLDER_PATTERN}#search=2~gallery~{Domain.URL_PAGECOUNT_PLACEHOLDER_PATTERN}",
                PageCountMultiplier = 5
            };
            // This domain filters my requests using cloudflare.
            Domain offerUp = new Domain(SearchUrlPatternRejected)
            {
                Label = "Offerup",
                ListingUrlPattern = $"/item/detail/",
                SearchUrlPattern = $"https://offerup.com/search?q={Domain.URL_SEARCHTERM_PLACEHOLDER_PATTERN}",
            };
            // This domain fails to return results, giving an System.Net.Http.HttpRequestException: 'An error occurred while sending the request.' The host is "forcibly closing the connection."
            Domain carsCom = new Domain(SearchUrlPatternRejected)
            {
                Label = "Cars.com",
                ListingUrlPattern = $"/vehicledetail/",
                SearchUrlPattern = $"\r\nhttps://www.cars.com/shopping/results/?_unused_include_shippable=&_unused_keyword=&_unused_list_price_max=&_unused_list_price_min=&_unused_makes[]=&_unused_maximum_distance=&_unused_mileage_max=&_unused_models[]=&_unused_monthly_payment=&_unused_stock_type=&_unused_year_min=&_unused_zip=&dealer_id=&include_shippable=true&keyword=&list_price_max=&list_price_min=&makes[]=toyota&maximum_distance=50&mileage_max=&models[]=toyota-camry&monthly_payment=&page={Domain.URL_PAGECOUNT_PLACEHOLDER_PATTERN}&page_size=20&sort=best_match_desc&stock_type=used&year_max=2010&year_min=&zip=77041",
            };
            // This domain filters my requests using cloudflare.
            Domain zillow = new Domain(SearchUrlPatternRejected)
            {
                Label = "Zillow",
                ListingUrlPattern = $"/homedetails/",
                SearchUrlPattern = $"https://www.zillow.com/houston-tx-77041/{Domain.URL_PAGECOUNT_PLACEHOLDER_PATTERN}_p/?searchQueryState=%7B%22pagination%22%3A%7B%22currentPage%22%3A2%7D%2C%22isMapVisible%22%3Atrue%2C%22mapBounds%22%3A%7B%22west%22%3A-95.66721740551758%2C%22east%22%3A-95.46637359448242%2C%22south%22%3A29.805973092052174%2C%22north%22%3A29.94053580720247%7D%2C%22regionSelection%22%3A%5B%7B%22regionId%22%3A91690%2C%22regionType%22%3A7%7D%5D%2C%22filterState%22%3A%7B%22sort%22%3A%7B%22value%22%3A%22globalrelevanceex%22%7D%2C%22beds%22%3A%7B%22min%22%3A2%7D%2C%22baths%22%3A%7B%22min%22%3A2%7D%7D%2C%22isListVisible%22%3Atrue%2C%22mapZoom%22%3A13%2C%22usersSearchTerm%22%3A%22Houston%20TX%2077041%22%7D",
            };
            // This returns the same error as the Cars.com domain.
            Domain edmunds = new Domain(SearchUrlPatternRejected)
            {
                Label = "Edmunds",
                ListingUrlPattern = $"/vin/",
                SearchUrlPattern = $"https://www.edmunds.com/inventory/srp.html?inventorytype=used%2Ccpo&make=toyota&model=toyota|camry&pagenumber={Domain.URL_PAGECOUNT_PLACEHOLDER_PATTERN}",
            };
            // This domain quietly rejects my requests.
            Domain autotrader = new Domain(SearchUrlPatternRejected)
            {
                Label = "Autotrader",
                ListingUrlPattern = $"/vehicle/",
                SearchUrlPattern = $"https://www.autotrader.com/cars-for-sale/all-cars/by-owner/toyota/camry/houston-tx?zip=77001#search=2~gallery~{Domain.URL_PAGECOUNT_PLACEHOLDER_PATTERN}",
            };
            // This domain filters my requests using cloudflare.
            Domain indeed = new Domain(SearchUrlPatternRejected)
            {
                Label = "Indeed.com",
                ListingUrlPattern = @"/viewjob?",
                SearchUrlPattern = $"https://www.indeed.com/jobs?q={Domain.URL_SEARCHTERM_PLACEHOLDER_PATTERN}&l=houston%2C+tx&radius=35&vjk=74f724e50cbcc7b3&start={Domain.URL_PAGECOUNT_PLACEHOLDER_PATTERN}",
                PageCountMultiplier = 10
            };
            // This domain returns only a redirect script.
            Domain linkedin = new Domain(SearchUrlPatternRejected)
            {
                Label = "Linkedin",
                ListingUrlPattern = $"/jobs/view/",
                SearchUrlPattern = $"https://www.linkedin.com/jobs/search?keywords={Domain.URL_SEARCHTERM_PLACEHOLDER_PATTERN}&location=Houston&geoId=103743442&position=1&pageNum={Domain.URL_PAGECOUNT_PLACEHOLDER_PATTERN}",
            };

            Program.CurrentSession.DomainProfile.Domains.Add(eBay);
            Program.CurrentSession.DomainProfile.Domains.Add(craigsList);
            Program.CurrentSession.DomainProfile.Domains.Add(offerUp);
            Program.CurrentSession.DomainProfile.Domains.Add(carsCom);
            Program.CurrentSession.DomainProfile.Domains.Add(zillow);
            Program.CurrentSession.DomainProfile.Domains.Add(edmunds);
            Program.CurrentSession.DomainProfile.Domains.Add(autotrader);
            Program.CurrentSession.DomainProfile.Domains.Add(indeed);
            Program.CurrentSession.DomainProfile.Domains.Add(linkedin);

            // Ensure that only members of Domain corresponding to items in our displayedColumns list render.

            foreach (DataGridViewColumn column in mainDataGridView.Columns)
            {
                if (!displayedColumns.Contains(column.DataPropertyName))
                {
                    column.Visible = false;
                }
            }

            // Below are some domains I've tested but fail to return search results for reasons specified.
            // I am hoping that switching to Selenium Webdriver will allow me to overcome at least most of these.

            // This domain does not return the expected search page.
            Domain autotempest = new Domain(SearchUrlPatternRejected)
            {
                Label = "Autotempest",
                ListingUrlPattern = $"/details/",
                SearchUrlPattern = $"https://www.autotempest.com/results?make=toyota&model=camry&zip=77041&radius=50",
            };

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
            if (CurrentRowIndex < 0) 
            {
                return;
            }
            sessionDomains.RemoveAt(CurrentRowIndex);
        }

        /// <summary>
        /// Enables the currently selected domain for searching.
        /// </summary>
        private void enableDomainButton_Click(object sender, EventArgs e)
        {
            sessionDomains[CurrentRowIndex].Active = !sessionDomains[CurrentRowIndex].Active;
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
                mainTooltip.Hide(textbox);
                textbox.BackColor = MainForm.DefaultFieldEntryColor;
            }
            else
            {
                mainTooltip.ToolTipTitle = title;
                mainTooltip.Show(body, textbox, 0, (int)(-textbox.Height * 1.75), TOOLTIP_HOVERTIME);
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
                //searchUrlTextBox.DataBindings[0].ReadValue();
            }

            //searchUrlTextBox.DataBindings[0].WriteValue();
        }
        
        /// <summary>
        /// Clears all domains in the current profile.
        /// </summary>
        private void clearDomainsButton_Click(object sender, EventArgs e)
        {
            sessionDomains.Clear();
        }



    }
}
