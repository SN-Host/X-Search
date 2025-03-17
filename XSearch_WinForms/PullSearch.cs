using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XSearch_Lib;

namespace XSearch_WinForms
{
    public partial class PullSearch : Form
    {
        public PullSearch()
        {
            InitializeComponent();
        }

        private void PullSearch_Load(object sender, EventArgs e)
        {
            // Ensure search information reflects current session properties.
            searchTermTextBox.Text = Program.CurrentSession.Searcher.SearchTerm;
            pageCountNumericUpDown.Value = Program.CurrentSession.Searcher.PagesToSearch;
        }

        private async void pullSearchButton_Click(object sender, EventArgs e)
        {
            Session session = Program.CurrentSession;

            // Update session parameters.
            session.Searcher.SearchTerm = searchTermTextBox.Text;
            session.Searcher.PagesToSearch = (int)pageCountNumericUpDown.Value;

            // Early exit for unsatisfied pull condiitons.
            if (!session.Searcher.PullRequirementsSatisfied())
            {
                return;
            }

            // Close window before beginning search.
            Close();

            // Search.
            await session.Searcher.PullSearch();
        }
    }
}
