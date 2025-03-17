using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using System.Drawing.Drawing2D;
using System.IO;
using static XSearch_WinForms.Workspace;
using System.ComponentModel;
using XSearch_Lib;

namespace XSearch_WinForms
{

    public partial class MainForm : Form
    {
        // FIELDS //

        /// <summary>
        /// The form currently framed in the main viewport.
        /// </summary>
        private Form currentFramedForm;

        /// <summary>
        /// Current option selected from the main menu for highlighting purposes.
        /// </summary>
        private Button selectedMainMenuButton;

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
        /// The workspace pane currently associated the main form.
        /// </summary>
        private Workspace Workspace { get; set; }

        /// <summary>
        /// The domains pane currently associated the main form.
        /// </summary>
        private Domains Domains { get; set; }

        public MainForm()
        {
            InitializeComponent();

            // Initialize main program tabs.
            Workspace = new Workspace(this);
            Domains = new Domains(this);

            // Frame workspace by default.
            ChangeFrame(workspaceButton, Workspace, Workspace.controlPanel, Workspace.Text);

            // Handle events for failed searches.
            Program.CurrentSession.Searcher.OnPullFailedAttempt += GenericErrorMessage;

            // Handle events for update search log updates.
            Program.CurrentSession.Searcher.OnNewSearchMessage += UpdateSearchLog;
        }

        /// <summary>
        /// Handles search logging events raised by the library.
        /// </summary>
        public void UpdateSearchLog(SessionSearcher searcher, SearchLogArgs sArgs)
        {
            statusReportLabel.Text = $"[{searcher.CurrentSearchTask}]\n" + sArgs.Text;
            searchProgressLabel.Text = $"{searcher.SearchProgress}%";
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
        public void ApplySelectedButtonColor(Button curSelection, ref Button oldSelection, Color newColor, Color? possibleDefaultColor = null)
        {
            // Use class default if parameter wasn't given.
            if (!(possibleDefaultColor is Color defaultColor))
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
        /// <param name="button">The button this request is coming from.</param>
        /// <param name="form">The form to frame.</param>
        /// <param name="controlPanel">The panel from the child form containing its toolbox options.</param>
        /// <param name="frameLabelText">The text to change frameLabel to.</param>
        public void ChangeFrame(Button button, Form form, Panel controlPanel, string frameLabelText)
        {
            WinformsUIUtilities.FrameForm(framingPanel, ref currentFramedForm, form);
            WinformsUIUtilities.FramePanel(selectionSettingsPanel, controlPanel);

            // Ensure the button the request came from is highlighted.
            ApplySelectedButtonColor(button, ref selectedMainMenuButton, SelectedButtonColor);

            // Change frameLabel's text to reflect the frame change.
            frameLabel.Text = frameLabelText;
        }

        /// <summary>
        /// Changes the framed menu to the workspace.
        /// </summary>
        private void workspaceButton_Click(object sender, EventArgs e)
        {
            ChangeFrame((Button)sender, Workspace, Workspace.controlPanel, Workspace.Text);
        }

        /// <summary>
        /// Changes the framed menu to the domains menu.
        /// </summary>
        private void domainsButton_Click(object sender, EventArgs e)
        {
            ChangeFrame((Button)sender, Domains, Domains.controlPanel, Domains.Text);
        }

        /// <summary>
        /// Will link to documentation in the future.
        /// </summary>
        private void helpButton_Click(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// Will provide program settings in the future.
        /// </summary>
        private void settingsButton_Click(object sender, EventArgs e)
        {
        }
        
    }
}
