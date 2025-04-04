namespace XSearch_WinForms
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            infoPanel = new Panel();
            toolsContainerPanel = new Panel();
            selectionSettingsPanel = new Panel();
            workspaceToolLabel = new Label();
            statusContainerPanel = new Panel();
            statusPanel = new Panel();
            statusReportPanel = new Panel();
            statusReportLabel = new Label();
            currentStatusHeader = new Label();
            searchProgressPanel = new Panel();
            searchProgressLabel = new Label();
            searchProgressHeaderLabel = new Label();
            rowInfoPanel = new Panel();
            rowInfoLabel = new Label();
            rowInfoHeaderLabel = new Label();
            statusTitleLabel = new Label();
            controlContainerPanel = new Panel();
            controlPanel = new Panel();
            indexContainerPanel = new Panel();
            helpButton = new Button();
            settingsButton = new Button();
            domainsButton = new Button();
            workspaceButton = new Button();
            titlePanel = new Panel();
            titleLabel = new Label();
            workspaceContainerPanel = new Panel();
            framingPanel = new Panel();
            frameLabel = new Label();
            infoPanel.SuspendLayout();
            toolsContainerPanel.SuspendLayout();
            statusContainerPanel.SuspendLayout();
            statusPanel.SuspendLayout();
            statusReportPanel.SuspendLayout();
            searchProgressPanel.SuspendLayout();
            rowInfoPanel.SuspendLayout();
            controlContainerPanel.SuspendLayout();
            controlPanel.SuspendLayout();
            indexContainerPanel.SuspendLayout();
            titlePanel.SuspendLayout();
            workspaceContainerPanel.SuspendLayout();
            SuspendLayout();
            // 
            // infoPanel
            // 
            infoPanel.BackColor = Color.Transparent;
            infoPanel.Controls.Add(toolsContainerPanel);
            infoPanel.Controls.Add(statusContainerPanel);
            infoPanel.Controls.Add(controlContainerPanel);
            infoPanel.Dock = DockStyle.Left;
            infoPanel.Location = new Point(15, 15);
            infoPanel.Name = "infoPanel";
            infoPanel.Padding = new Padding(0, 0, 10, 0);
            infoPanel.Size = new Size(200, 713);
            infoPanel.TabIndex = 0;
            // 
            // toolsContainerPanel
            // 
            toolsContainerPanel.Controls.Add(selectionSettingsPanel);
            toolsContainerPanel.Controls.Add(workspaceToolLabel);
            toolsContainerPanel.Dock = DockStyle.Fill;
            toolsContainerPanel.Location = new Point(0, 205);
            toolsContainerPanel.Margin = new Padding(0);
            toolsContainerPanel.Name = "toolsContainerPanel";
            toolsContainerPanel.Padding = new Padding(0, 5, 0, 5);
            toolsContainerPanel.Size = new Size(190, 260);
            toolsContainerPanel.TabIndex = 2;
            // 
            // selectionSettingsPanel
            // 
            selectionSettingsPanel.BackColor = Color.FromArgb(250, 250, 255);
            selectionSettingsPanel.Dock = DockStyle.Fill;
            selectionSettingsPanel.Location = new Point(0, 35);
            selectionSettingsPanel.Margin = new Padding(0);
            selectionSettingsPanel.Name = "selectionSettingsPanel";
            selectionSettingsPanel.Size = new Size(190, 220);
            selectionSettingsPanel.TabIndex = 0;
            // 
            // workspaceToolLabel
            // 
            workspaceToolLabel.BackColor = Color.FromArgb(100, 100, 150);
            workspaceToolLabel.Dock = DockStyle.Top;
            workspaceToolLabel.Font = new Font("Segoe UI Variable Text Semibold", 11.25F, FontStyle.Bold);
            workspaceToolLabel.ForeColor = Color.FromArgb(250, 250, 255);
            workspaceToolLabel.Location = new Point(0, 5);
            workspaceToolLabel.Name = "workspaceToolLabel";
            workspaceToolLabel.Size = new Size(190, 30);
            workspaceToolLabel.TabIndex = 8;
            workspaceToolLabel.Text = "Toolbox";
            workspaceToolLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // statusContainerPanel
            // 
            statusContainerPanel.BackColor = Color.Transparent;
            statusContainerPanel.Controls.Add(statusPanel);
            statusContainerPanel.Dock = DockStyle.Bottom;
            statusContainerPanel.Location = new Point(0, 465);
            statusContainerPanel.Margin = new Padding(0);
            statusContainerPanel.Name = "statusContainerPanel";
            statusContainerPanel.Padding = new Padding(0, 5, 0, 0);
            statusContainerPanel.Size = new Size(190, 248);
            statusContainerPanel.TabIndex = 1;
            // 
            // statusPanel
            // 
            statusPanel.BackColor = Color.FromArgb(250, 250, 255);
            statusPanel.Controls.Add(statusReportPanel);
            statusPanel.Controls.Add(searchProgressPanel);
            statusPanel.Controls.Add(rowInfoPanel);
            statusPanel.Controls.Add(statusTitleLabel);
            statusPanel.Dock = DockStyle.Fill;
            statusPanel.Location = new Point(0, 5);
            statusPanel.Name = "statusPanel";
            statusPanel.Size = new Size(190, 243);
            statusPanel.TabIndex = 0;
            // 
            // statusReportPanel
            // 
            statusReportPanel.AutoScroll = true;
            statusReportPanel.Controls.Add(statusReportLabel);
            statusReportPanel.Controls.Add(currentStatusHeader);
            statusReportPanel.Dock = DockStyle.Fill;
            statusReportPanel.Location = new Point(0, 30);
            statusReportPanel.Name = "statusReportPanel";
            statusReportPanel.Padding = new Padding(5);
            statusReportPanel.Size = new Size(190, 108);
            statusReportPanel.TabIndex = 1;
            // 
            // statusReportLabel
            // 
            statusReportLabel.AutoSize = true;
            statusReportLabel.BackColor = Color.FromArgb(250, 250, 255);
            statusReportLabel.Dock = DockStyle.Top;
            statusReportLabel.Font = new Font("Segoe UI Variable Text", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            statusReportLabel.Location = new Point(5, 22);
            statusReportLabel.MaximumSize = new Size(170, 0);
            statusReportLabel.Name = "statusReportLabel";
            statusReportLabel.Padding = new Padding(5, 0, 5, 0);
            statusReportLabel.Size = new Size(57, 17);
            statusReportLabel.TabIndex = 5;
            statusReportLabel.Text = "Ready.";
            // 
            // currentStatusHeader
            // 
            currentStatusHeader.BackColor = Color.FromArgb(250, 250, 255);
            currentStatusHeader.Dock = DockStyle.Top;
            currentStatusHeader.Font = new Font("Segoe UI Variable Display Semib", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            currentStatusHeader.Location = new Point(5, 5);
            currentStatusHeader.Name = "currentStatusHeader";
            currentStatusHeader.Padding = new Padding(5, 0, 5, 0);
            currentStatusHeader.Size = new Size(180, 17);
            currentStatusHeader.TabIndex = 3;
            currentStatusHeader.Text = "Current status";
            currentStatusHeader.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // searchProgressPanel
            // 
            searchProgressPanel.Controls.Add(searchProgressLabel);
            searchProgressPanel.Controls.Add(searchProgressHeaderLabel);
            searchProgressPanel.Dock = DockStyle.Bottom;
            searchProgressPanel.Location = new Point(0, 138);
            searchProgressPanel.Name = "searchProgressPanel";
            searchProgressPanel.Padding = new Padding(5);
            searchProgressPanel.Size = new Size(190, 50);
            searchProgressPanel.TabIndex = 2;
            // 
            // searchProgressLabel
            // 
            searchProgressLabel.BackColor = Color.FromArgb(250, 250, 255);
            searchProgressLabel.Dock = DockStyle.Top;
            searchProgressLabel.Font = new Font("Segoe UI Variable Text", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            searchProgressLabel.Location = new Point(5, 22);
            searchProgressLabel.Name = "searchProgressLabel";
            searchProgressLabel.Padding = new Padding(5, 0, 5, 0);
            searchProgressLabel.Size = new Size(180, 21);
            searchProgressLabel.TabIndex = 4;
            // 
            // searchProgressHeaderLabel
            // 
            searchProgressHeaderLabel.BackColor = Color.FromArgb(250, 250, 255);
            searchProgressHeaderLabel.Dock = DockStyle.Top;
            searchProgressHeaderLabel.Font = new Font("Segoe UI Variable Display Semib", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            searchProgressHeaderLabel.Location = new Point(5, 5);
            searchProgressHeaderLabel.Name = "searchProgressHeaderLabel";
            searchProgressHeaderLabel.Padding = new Padding(5, 0, 5, 0);
            searchProgressHeaderLabel.Size = new Size(180, 17);
            searchProgressHeaderLabel.TabIndex = 3;
            searchProgressHeaderLabel.Text = "Progress";
            // 
            // rowInfoPanel
            // 
            rowInfoPanel.Controls.Add(rowInfoLabel);
            rowInfoPanel.Controls.Add(rowInfoHeaderLabel);
            rowInfoPanel.Dock = DockStyle.Bottom;
            rowInfoPanel.Location = new Point(0, 188);
            rowInfoPanel.Name = "rowInfoPanel";
            rowInfoPanel.Padding = new Padding(5);
            rowInfoPanel.Size = new Size(190, 55);
            rowInfoPanel.TabIndex = 6;
            // 
            // rowInfoLabel
            // 
            rowInfoLabel.BackColor = Color.FromArgb(250, 250, 255);
            rowInfoLabel.Dock = DockStyle.Top;
            rowInfoLabel.Font = new Font("Segoe UI Variable Text", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rowInfoLabel.Location = new Point(5, 22);
            rowInfoLabel.Name = "rowInfoLabel";
            rowInfoLabel.Padding = new Padding(5, 0, 5, 0);
            rowInfoLabel.Size = new Size(180, 21);
            rowInfoLabel.TabIndex = 4;
            // 
            // rowInfoHeaderLabel
            // 
            rowInfoHeaderLabel.BackColor = Color.FromArgb(250, 250, 255);
            rowInfoHeaderLabel.Dock = DockStyle.Top;
            rowInfoHeaderLabel.Font = new Font("Segoe UI Variable Display Semib", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            rowInfoHeaderLabel.Location = new Point(5, 5);
            rowInfoHeaderLabel.Name = "rowInfoHeaderLabel";
            rowInfoHeaderLabel.Padding = new Padding(5, 0, 5, 0);
            rowInfoHeaderLabel.Size = new Size(180, 17);
            rowInfoHeaderLabel.TabIndex = 3;
            rowInfoHeaderLabel.Text = "Row info";
            // 
            // statusTitleLabel
            // 
            statusTitleLabel.BackColor = Color.FromArgb(100, 100, 150);
            statusTitleLabel.Dock = DockStyle.Top;
            statusTitleLabel.ForeColor = Color.FromArgb(250, 250, 255);
            statusTitleLabel.Location = new Point(0, 0);
            statusTitleLabel.Name = "statusTitleLabel";
            statusTitleLabel.Padding = new Padding(5);
            statusTitleLabel.Size = new Size(190, 30);
            statusTitleLabel.TabIndex = 0;
            statusTitleLabel.Text = "Status";
            statusTitleLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // controlContainerPanel
            // 
            controlContainerPanel.BackColor = Color.Transparent;
            controlContainerPanel.Controls.Add(controlPanel);
            controlContainerPanel.Dock = DockStyle.Top;
            controlContainerPanel.Location = new Point(0, 0);
            controlContainerPanel.Margin = new Padding(0);
            controlContainerPanel.Name = "controlContainerPanel";
            controlContainerPanel.Padding = new Padding(0, 0, 0, 5);
            controlContainerPanel.Size = new Size(190, 205);
            controlContainerPanel.TabIndex = 0;
            // 
            // controlPanel
            // 
            controlPanel.AutoScroll = true;
            controlPanel.BackColor = Color.FromArgb(250, 250, 255);
            controlPanel.Controls.Add(indexContainerPanel);
            controlPanel.Controls.Add(titlePanel);
            controlPanel.Dock = DockStyle.Fill;
            controlPanel.Location = new Point(0, 0);
            controlPanel.Name = "controlPanel";
            controlPanel.Size = new Size(190, 200);
            controlPanel.TabIndex = 0;
            // 
            // indexContainerPanel
            // 
            indexContainerPanel.AutoScroll = true;
            indexContainerPanel.Controls.Add(helpButton);
            indexContainerPanel.Controls.Add(settingsButton);
            indexContainerPanel.Controls.Add(domainsButton);
            indexContainerPanel.Controls.Add(workspaceButton);
            indexContainerPanel.Dock = DockStyle.Fill;
            indexContainerPanel.Location = new Point(0, 39);
            indexContainerPanel.Name = "indexContainerPanel";
            indexContainerPanel.Padding = new Padding(0, 10, 0, 10);
            indexContainerPanel.Size = new Size(190, 161);
            indexContainerPanel.TabIndex = 1;
            // 
            // helpButton
            // 
            helpButton.BackColor = Color.FromArgb(250, 250, 255);
            helpButton.Dock = DockStyle.Top;
            helpButton.Enabled = false;
            helpButton.FlatAppearance.BorderSize = 0;
            helpButton.FlatStyle = FlatStyle.Flat;
            helpButton.Font = new Font("Segoe UI Variable Text", 10F);
            helpButton.Image = Properties.Resources.placeholder_25x25_dark;
            helpButton.ImageAlign = ContentAlignment.MiddleLeft;
            helpButton.Location = new Point(0, 118);
            helpButton.Name = "helpButton";
            helpButton.Padding = new Padding(5, 0, 0, 0);
            helpButton.Size = new Size(190, 36);
            helpButton.TabIndex = 7;
            helpButton.Text = "   Help";
            helpButton.TextImageRelation = TextImageRelation.ImageBeforeText;
            helpButton.UseVisualStyleBackColor = false;
            helpButton.Click += helpButton_Click;
            // 
            // settingsButton
            // 
            settingsButton.BackColor = Color.FromArgb(250, 250, 255);
            settingsButton.Dock = DockStyle.Top;
            settingsButton.FlatAppearance.BorderSize = 0;
            settingsButton.FlatStyle = FlatStyle.Flat;
            settingsButton.Font = new Font("Segoe UI Variable Text", 10F);
            settingsButton.Image = Properties.Resources.placeholder_25x25_dark;
            settingsButton.ImageAlign = ContentAlignment.MiddleLeft;
            settingsButton.Location = new Point(0, 82);
            settingsButton.Name = "settingsButton";
            settingsButton.Padding = new Padding(5, 0, 0, 0);
            settingsButton.Size = new Size(190, 36);
            settingsButton.TabIndex = 6;
            settingsButton.Text = "   Settings";
            settingsButton.TextImageRelation = TextImageRelation.ImageBeforeText;
            settingsButton.UseVisualStyleBackColor = false;
            settingsButton.Click += settingsButton_Click;
            // 
            // domainsButton
            // 
            domainsButton.BackColor = Color.FromArgb(250, 250, 255);
            domainsButton.Dock = DockStyle.Top;
            domainsButton.FlatAppearance.BorderSize = 0;
            domainsButton.FlatStyle = FlatStyle.Flat;
            domainsButton.Font = new Font("Segoe UI Variable Text", 10F);
            domainsButton.Image = Properties.Resources.placeholder_25x25_dark;
            domainsButton.ImageAlign = ContentAlignment.MiddleLeft;
            domainsButton.Location = new Point(0, 46);
            domainsButton.Name = "domainsButton";
            domainsButton.Padding = new Padding(5, 0, 0, 0);
            domainsButton.Size = new Size(190, 36);
            domainsButton.TabIndex = 3;
            domainsButton.Text = "   Domains";
            domainsButton.TextImageRelation = TextImageRelation.ImageBeforeText;
            domainsButton.UseVisualStyleBackColor = false;
            domainsButton.Click += domainsButton_Click;
            // 
            // workspaceButton
            // 
            workspaceButton.BackColor = Color.FromArgb(250, 250, 255);
            workspaceButton.Dock = DockStyle.Top;
            workspaceButton.FlatAppearance.BorderSize = 0;
            workspaceButton.FlatStyle = FlatStyle.Flat;
            workspaceButton.Font = new Font("Segoe UI Variable Text", 10F);
            workspaceButton.Image = Properties.Resources.placeholder_25x25_dark;
            workspaceButton.ImageAlign = ContentAlignment.MiddleLeft;
            workspaceButton.Location = new Point(0, 10);
            workspaceButton.Name = "workspaceButton";
            workspaceButton.Padding = new Padding(5, 0, 0, 0);
            workspaceButton.Size = new Size(190, 36);
            workspaceButton.TabIndex = 2;
            workspaceButton.Text = "   Workspace";
            workspaceButton.TextImageRelation = TextImageRelation.ImageBeforeText;
            workspaceButton.UseVisualStyleBackColor = false;
            workspaceButton.Click += workspaceButton_Click;
            // 
            // titlePanel
            // 
            titlePanel.AutoScroll = true;
            titlePanel.Controls.Add(titleLabel);
            titlePanel.Dock = DockStyle.Top;
            titlePanel.Location = new Point(0, 0);
            titlePanel.Name = "titlePanel";
            titlePanel.Size = new Size(190, 39);
            titlePanel.TabIndex = 0;
            // 
            // titleLabel
            // 
            titleLabel.BackColor = Color.FromArgb(50, 50, 80);
            titleLabel.Dock = DockStyle.Fill;
            titleLabel.Font = new Font("Segoe UI Variable Display Semil", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            titleLabel.ForeColor = Color.FromArgb(250, 250, 255);
            titleLabel.Location = new Point(0, 0);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(190, 39);
            titleLabel.TabIndex = 0;
            titleLabel.Text = "X-SEARCH";
            titleLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // workspaceContainerPanel
            // 
            workspaceContainerPanel.BackColor = Color.FromArgb(250, 250, 255);
            workspaceContainerPanel.Controls.Add(framingPanel);
            workspaceContainerPanel.Controls.Add(frameLabel);
            workspaceContainerPanel.Dock = DockStyle.Fill;
            workspaceContainerPanel.Location = new Point(215, 15);
            workspaceContainerPanel.Name = "workspaceContainerPanel";
            workspaceContainerPanel.Size = new Size(676, 713);
            workspaceContainerPanel.TabIndex = 1;
            // 
            // framingPanel
            // 
            framingPanel.BackColor = Color.FromArgb(250, 250, 255);
            framingPanel.Dock = DockStyle.Fill;
            framingPanel.Location = new Point(0, 39);
            framingPanel.Name = "framingPanel";
            framingPanel.Padding = new Padding(10);
            framingPanel.Size = new Size(676, 674);
            framingPanel.TabIndex = 0;
            // 
            // frameLabel
            // 
            frameLabel.BackColor = Color.FromArgb(100, 100, 150);
            frameLabel.Dock = DockStyle.Top;
            frameLabel.Font = new Font("Segoe UI Variable Text Light", 15F, FontStyle.Bold);
            frameLabel.ForeColor = Color.FromArgb(250, 250, 255);
            frameLabel.Location = new Point(0, 0);
            frameLabel.Name = "frameLabel";
            frameLabel.Size = new Size(676, 39);
            frameLabel.TabIndex = 1;
            frameLabel.Text = "Workspace";
            frameLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.FromArgb(250, 250, 255);
            BackgroundImage = Properties.Resources.daybg;
            BackgroundImageLayout = ImageLayout.Center;
            ClientSize = new Size(906, 743);
            Controls.Add(workspaceContainerPanel);
            Controls.Add(infoPanel);
            DoubleBuffered = true;
            Font = new Font("Segoe UI Variable Text Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ForeColor = Color.FromArgb(50, 50, 100);
            Margin = new Padding(5);
            Name = "MainForm";
            Padding = new Padding(15);
            SizeGripStyle = SizeGripStyle.Show;
            Text = "X-Search";
            infoPanel.ResumeLayout(false);
            toolsContainerPanel.ResumeLayout(false);
            statusContainerPanel.ResumeLayout(false);
            statusPanel.ResumeLayout(false);
            statusReportPanel.ResumeLayout(false);
            statusReportPanel.PerformLayout();
            searchProgressPanel.ResumeLayout(false);
            rowInfoPanel.ResumeLayout(false);
            controlContainerPanel.ResumeLayout(false);
            controlPanel.ResumeLayout(false);
            indexContainerPanel.ResumeLayout(false);
            titlePanel.ResumeLayout(false);
            workspaceContainerPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel infoPanel;
        private Panel controlContainerPanel;
        private Panel containerStatusPanel;
        private Panel workspaceContainerPanel;
        private Panel controlPanel;
        private Panel titlePanel;
        private Label titleLabel;
        private Panel indexContainerPanel;
        private Button workspaceButton;
        private Button button8;
        private Button button7;
        private Button domainsButton;
        private Panel statusContainerPanel;
        private Panel statusPanel;
        private Panel searchProgressPanel;
        private Label searchProgressLabel;
        private Label searchProgressHeaderLabel;
        private Panel statusReportPanel;
        private Label currentStatusHeader;
        private Label statusTitleLabel;
        private Panel framingPanel;
        private Button settingsButton;
        private Panel toolsContainerPanel;
        private Panel selectionSettingsPanel;
        private Label frameLabel;
        private Label workspaceToolLabel;
        private Button helpButton;
        private Label statusReportLabel;
        private Panel rowInfoPanel;
        private Label rowInfoHeaderLabel;
        internal Label rowInfoLabel;
    }
}
