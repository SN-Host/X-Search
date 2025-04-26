using XSearch_Lib;

namespace XSearch_WinForms
{
    public partial class PullSearch : Form
    {
        public PullSearch()
        {
            InitializeComponent();

            // Ensure that all of the form's controls are double buffered for optimized rendering.
            WinformsUIUtilities.SetAllControlsDoubleBuffered(this);
        }

        private void PullSearch_Load(object sender, EventArgs e)
        {
            // Ensure search information reflects current session properties.
            searchTermTextBox.Text = Program.CurrentSession.Searcher.SearchTerm;
            resultsPerDomainNumericUpDown.Value = Program.CurrentSession.Searcher.ResultsToPullPerDomain;
        }

        private async void pullSearchButton_Click(object sender, EventArgs e)
        {
            Session session = Program.CurrentSession;

            // Update session parameters.
            session.Searcher.SearchTerm = searchTermTextBox.Text;
            session.Searcher.ResultsToPullPerDomain = (int)resultsPerDomainNumericUpDown.Value;

            // Early exit for unsatisfied pull condiitons.
            if (!session.Searcher.PullRequirementsSatisfied())
            {
                return;
            }

            // Close window before beginning search.
            Close();

            // Search.
            //await Task.Run(delegate { session.Searcher.PullSearch(); });
            await session.Searcher.PullSearch();
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
