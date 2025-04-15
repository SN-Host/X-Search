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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            infoPanel = new Panel();
            toolsContainerPanel = new Panel();
            selectionSettingsPanel = new Panel();
            workspaceToolLabelPanel = new Panel();
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
            statusTitleLabelPanel = new Panel();
            statusTitleLabel = new Label();
            controlContainerPanel = new Panel();
            controlPanel = new Panel();
            indexContainerPanel = new Panel();
            helpButton = new Button();
            mainImageList = new ImageList(components);
            settingsButton = new Button();
            domainsButton = new Button();
            workspaceButton = new Button();
            titlePanel = new Panel();
            titlePictureBox = new PictureBox();
            titleLabel = new Label();
            workspaceContainerPanel = new Panel();
            framingPanel = new Panel();
            frameLabelPanel = new Panel();
            frameLabel = new Label();
            mainToolTip = new ToolTip(components);
            infoPanel.SuspendLayout();
            toolsContainerPanel.SuspendLayout();
            workspaceToolLabelPanel.SuspendLayout();
            statusContainerPanel.SuspendLayout();
            statusPanel.SuspendLayout();
            statusReportPanel.SuspendLayout();
            searchProgressPanel.SuspendLayout();
            rowInfoPanel.SuspendLayout();
            statusTitleLabelPanel.SuspendLayout();
            controlContainerPanel.SuspendLayout();
            controlPanel.SuspendLayout();
            indexContainerPanel.SuspendLayout();
            titlePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)titlePictureBox).BeginInit();
            workspaceContainerPanel.SuspendLayout();
            frameLabelPanel.SuspendLayout();
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
            toolsContainerPanel.Controls.Add(workspaceToolLabelPanel);
            toolsContainerPanel.Dock = DockStyle.Fill;
            toolsContainerPanel.Location = new Point(0, 253);
            toolsContainerPanel.Margin = new Padding(0);
            toolsContainerPanel.Name = "toolsContainerPanel";
            toolsContainerPanel.Padding = new Padding(0, 5, 0, 5);
            toolsContainerPanel.Size = new Size(190, 212);
            toolsContainerPanel.TabIndex = 2;
            // 
            // selectionSettingsPanel
            // 
            selectionSettingsPanel.BackColor = Color.Transparent;
            selectionSettingsPanel.BackgroundImage = Properties.Resources.BG5;
            selectionSettingsPanel.BackgroundImageLayout = ImageLayout.Stretch;
            selectionSettingsPanel.Dock = DockStyle.Fill;
            selectionSettingsPanel.Location = new Point(0, 44);
            selectionSettingsPanel.Margin = new Padding(0);
            selectionSettingsPanel.Name = "selectionSettingsPanel";
            selectionSettingsPanel.Size = new Size(190, 163);
            selectionSettingsPanel.TabIndex = 0;
            // 
            // workspaceToolLabelPanel
            // 
            workspaceToolLabelPanel.BackColor = Color.Transparent;
            workspaceToolLabelPanel.BackgroundImage = Properties.Resources.BG8;
            workspaceToolLabelPanel.BackgroundImageLayout = ImageLayout.Stretch;
            workspaceToolLabelPanel.Controls.Add(workspaceToolLabel);
            workspaceToolLabelPanel.Dock = DockStyle.Top;
            workspaceToolLabelPanel.Location = new Point(0, 5);
            workspaceToolLabelPanel.Name = "workspaceToolLabelPanel";
            workspaceToolLabelPanel.Size = new Size(190, 39);
            workspaceToolLabelPanel.TabIndex = 9;
            // 
            // workspaceToolLabel
            // 
            workspaceToolLabel.BackColor = Color.Transparent;
            workspaceToolLabel.Dock = DockStyle.Fill;
            workspaceToolLabel.Font = new Font("Segoe UI Variable Text Semibold", 11.25F, FontStyle.Bold);
            workspaceToolLabel.ForeColor = Color.FromArgb(50, 50, 80);
            workspaceToolLabel.Location = new Point(0, 0);
            workspaceToolLabel.Name = "workspaceToolLabel";
            workspaceToolLabel.Size = new Size(190, 39);
            workspaceToolLabel.TabIndex = 8;
            workspaceToolLabel.Text = "Toolbox";
            workspaceToolLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // statusContainerPanel
            // 
            statusContainerPanel.BackColor = Color.Transparent;
            statusContainerPanel.Controls.Add(statusPanel);
            statusContainerPanel.Controls.Add(statusTitleLabelPanel);
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
            statusPanel.BackgroundImage = Properties.Resources.BG5;
            statusPanel.BackgroundImageLayout = ImageLayout.Stretch;
            statusPanel.Controls.Add(statusReportPanel);
            statusPanel.Controls.Add(searchProgressPanel);
            statusPanel.Controls.Add(rowInfoPanel);
            statusPanel.Dock = DockStyle.Fill;
            statusPanel.Location = new Point(0, 44);
            statusPanel.Name = "statusPanel";
            statusPanel.Padding = new Padding(5);
            statusPanel.Size = new Size(190, 204);
            statusPanel.TabIndex = 0;
            // 
            // statusReportPanel
            // 
            statusReportPanel.AutoScroll = true;
            statusReportPanel.BackColor = Color.Transparent;
            statusReportPanel.Controls.Add(statusReportLabel);
            statusReportPanel.Controls.Add(currentStatusHeader);
            statusReportPanel.Dock = DockStyle.Fill;
            statusReportPanel.ForeColor = Color.FromArgb(50, 50, 80);
            statusReportPanel.Location = new Point(5, 5);
            statusReportPanel.Name = "statusReportPanel";
            statusReportPanel.Padding = new Padding(5);
            statusReportPanel.Size = new Size(180, 89);
            statusReportPanel.TabIndex = 1;
            mainToolTip.SetToolTip(statusReportPanel, "Last message logged by a pull.");
            // 
            // statusReportLabel
            // 
            statusReportLabel.AutoSize = true;
            statusReportLabel.BackColor = Color.Transparent;
            statusReportLabel.Dock = DockStyle.Top;
            statusReportLabel.Font = new Font("Segoe UI Variable Text", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            statusReportLabel.ForeColor = Color.FromArgb(50, 50, 80);
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
            currentStatusHeader.BackColor = Color.Transparent;
            currentStatusHeader.Dock = DockStyle.Top;
            currentStatusHeader.Font = new Font("Segoe UI Variable Display Semib", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            currentStatusHeader.ForeColor = Color.FromArgb(50, 50, 80);
            currentStatusHeader.Location = new Point(5, 5);
            currentStatusHeader.Name = "currentStatusHeader";
            currentStatusHeader.Padding = new Padding(5, 0, 5, 0);
            currentStatusHeader.Size = new Size(170, 17);
            currentStatusHeader.TabIndex = 3;
            currentStatusHeader.Text = "Current status";
            currentStatusHeader.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // searchProgressPanel
            // 
            searchProgressPanel.BackColor = Color.Transparent;
            searchProgressPanel.Controls.Add(searchProgressLabel);
            searchProgressPanel.Controls.Add(searchProgressHeaderLabel);
            searchProgressPanel.Dock = DockStyle.Bottom;
            searchProgressPanel.Location = new Point(5, 94);
            searchProgressPanel.Name = "searchProgressPanel";
            searchProgressPanel.Padding = new Padding(5);
            searchProgressPanel.Size = new Size(180, 50);
            searchProgressPanel.TabIndex = 2;
            mainToolTip.SetToolTip(searchProgressPanel, "Number of fetched listings to target listings from current or previous pull.");
            // 
            // searchProgressLabel
            // 
            searchProgressLabel.BackColor = Color.Transparent;
            searchProgressLabel.Dock = DockStyle.Top;
            searchProgressLabel.Font = new Font("Segoe UI Variable Text", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            searchProgressLabel.Location = new Point(5, 22);
            searchProgressLabel.Name = "searchProgressLabel";
            searchProgressLabel.Padding = new Padding(5, 0, 5, 0);
            searchProgressLabel.Size = new Size(170, 21);
            searchProgressLabel.TabIndex = 4;
            // 
            // searchProgressHeaderLabel
            // 
            searchProgressHeaderLabel.BackColor = Color.Transparent;
            searchProgressHeaderLabel.Dock = DockStyle.Top;
            searchProgressHeaderLabel.Font = new Font("Segoe UI Variable Display Semib", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            searchProgressHeaderLabel.ForeColor = Color.FromArgb(50, 50, 80);
            searchProgressHeaderLabel.Location = new Point(5, 5);
            searchProgressHeaderLabel.Name = "searchProgressHeaderLabel";
            searchProgressHeaderLabel.Padding = new Padding(5, 0, 5, 0);
            searchProgressHeaderLabel.Size = new Size(170, 17);
            searchProgressHeaderLabel.TabIndex = 3;
            searchProgressHeaderLabel.Text = "Progress";
            // 
            // rowInfoPanel
            // 
            rowInfoPanel.BackColor = Color.Transparent;
            rowInfoPanel.Controls.Add(rowInfoLabel);
            rowInfoPanel.Controls.Add(rowInfoHeaderLabel);
            rowInfoPanel.Dock = DockStyle.Bottom;
            rowInfoPanel.Location = new Point(5, 144);
            rowInfoPanel.Name = "rowInfoPanel";
            rowInfoPanel.Padding = new Padding(5);
            rowInfoPanel.Size = new Size(180, 55);
            rowInfoPanel.TabIndex = 6;
            mainToolTip.SetToolTip(rowInfoPanel, "Information on currently selected rows in the workspace.");
            // 
            // rowInfoLabel
            // 
            rowInfoLabel.BackColor = Color.Transparent;
            rowInfoLabel.Dock = DockStyle.Top;
            rowInfoLabel.Font = new Font("Segoe UI Variable Text", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rowInfoLabel.Location = new Point(5, 22);
            rowInfoLabel.Name = "rowInfoLabel";
            rowInfoLabel.Padding = new Padding(5, 0, 5, 0);
            rowInfoLabel.Size = new Size(170, 21);
            rowInfoLabel.TabIndex = 4;
            // 
            // rowInfoHeaderLabel
            // 
            rowInfoHeaderLabel.BackColor = Color.Transparent;
            rowInfoHeaderLabel.Dock = DockStyle.Top;
            rowInfoHeaderLabel.Font = new Font("Segoe UI Variable Display Semib", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            rowInfoHeaderLabel.ForeColor = Color.FromArgb(50, 50, 80);
            rowInfoHeaderLabel.Location = new Point(5, 5);
            rowInfoHeaderLabel.Name = "rowInfoHeaderLabel";
            rowInfoHeaderLabel.Padding = new Padding(5, 0, 5, 0);
            rowInfoHeaderLabel.Size = new Size(170, 17);
            rowInfoHeaderLabel.TabIndex = 3;
            rowInfoHeaderLabel.Text = "Row info";
            // 
            // statusTitleLabelPanel
            // 
            statusTitleLabelPanel.BackColor = Color.Transparent;
            statusTitleLabelPanel.BackgroundImage = Properties.Resources.BG8;
            statusTitleLabelPanel.BackgroundImageLayout = ImageLayout.Stretch;
            statusTitleLabelPanel.Controls.Add(statusTitleLabel);
            statusTitleLabelPanel.Dock = DockStyle.Top;
            statusTitleLabelPanel.Location = new Point(0, 5);
            statusTitleLabelPanel.Name = "statusTitleLabelPanel";
            statusTitleLabelPanel.Size = new Size(190, 39);
            statusTitleLabelPanel.TabIndex = 10;
            // 
            // statusTitleLabel
            // 
            statusTitleLabel.BackColor = Color.Transparent;
            statusTitleLabel.Dock = DockStyle.Fill;
            statusTitleLabel.ForeColor = Color.FromArgb(50, 50, 80);
            statusTitleLabel.Location = new Point(0, 0);
            statusTitleLabel.Name = "statusTitleLabel";
            statusTitleLabel.Padding = new Padding(5);
            statusTitleLabel.Size = new Size(190, 39);
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
            controlContainerPanel.Size = new Size(190, 253);
            controlContainerPanel.TabIndex = 0;
            // 
            // controlPanel
            // 
            controlPanel.AutoScroll = true;
            controlPanel.BackgroundImageLayout = ImageLayout.Stretch;
            controlPanel.Controls.Add(indexContainerPanel);
            controlPanel.Controls.Add(titlePanel);
            controlPanel.Dock = DockStyle.Fill;
            controlPanel.Location = new Point(0, 0);
            controlPanel.Name = "controlPanel";
            controlPanel.Size = new Size(190, 248);
            controlPanel.TabIndex = 0;
            // 
            // indexContainerPanel
            // 
            indexContainerPanel.AutoScroll = true;
            indexContainerPanel.BackColor = Color.Transparent;
            indexContainerPanel.BackgroundImage = Properties.Resources.BG5;
            indexContainerPanel.BackgroundImageLayout = ImageLayout.Stretch;
            indexContainerPanel.Controls.Add(helpButton);
            indexContainerPanel.Controls.Add(settingsButton);
            indexContainerPanel.Controls.Add(domainsButton);
            indexContainerPanel.Controls.Add(workspaceButton);
            indexContainerPanel.Dock = DockStyle.Fill;
            indexContainerPanel.Location = new Point(0, 43);
            indexContainerPanel.Name = "indexContainerPanel";
            indexContainerPanel.Padding = new Padding(0, 10, 0, 10);
            indexContainerPanel.Size = new Size(190, 205);
            indexContainerPanel.TabIndex = 1;
            // 
            // helpButton
            // 
            helpButton.BackColor = Color.Transparent;
            helpButton.Dock = DockStyle.Top;
            helpButton.FlatAppearance.BorderSize = 0;
            helpButton.FlatStyle = FlatStyle.Flat;
            helpButton.ForeColor = Color.FromArgb(50, 50, 80);
            helpButton.ImageAlign = ContentAlignment.MiddleLeft;
            helpButton.ImageKey = "HelpIcon.png";
            helpButton.ImageList = mainImageList;
            helpButton.Location = new Point(0, 145);
            helpButton.Name = "helpButton";
            helpButton.Padding = new Padding(5, 0, 0, 0);
            helpButton.Size = new Size(190, 45);
            helpButton.TabIndex = 7;
            helpButton.Text = "   Help";
            helpButton.TextImageRelation = TextImageRelation.ImageBeforeText;
            mainToolTip.SetToolTip(helpButton, "View X-Search documentation and support.");
            helpButton.UseVisualStyleBackColor = false;
            helpButton.Click += helpButton_Click;
            // 
            // mainImageList
            // 
            mainImageList.ColorDepth = ColorDepth.Depth32Bit;
            mainImageList.ImageStream = (ImageListStreamer)resources.GetObject("mainImageList.ImageStream");
            mainImageList.TransparentColor = Color.Transparent;
            mainImageList.Images.SetKeyName(0, "DomainsIcon.png");
            mainImageList.Images.SetKeyName(1, "WorkspaceIcon.png");
            mainImageList.Images.SetKeyName(2, "SettingsIcon.png");
            mainImageList.Images.SetKeyName(3, "HelpIcon.png");
            mainImageList.Images.SetKeyName(4, "Test.png");
            mainImageList.Images.SetKeyName(5, "BG.png");
            mainImageList.Images.SetKeyName(6, "BG9.png");
            // 
            // settingsButton
            // 
            settingsButton.BackColor = Color.Transparent;
            settingsButton.Dock = DockStyle.Top;
            settingsButton.FlatAppearance.BorderSize = 0;
            settingsButton.FlatStyle = FlatStyle.Flat;
            settingsButton.ForeColor = Color.FromArgb(50, 50, 80);
            settingsButton.ImageAlign = ContentAlignment.MiddleLeft;
            settingsButton.ImageKey = "SettingsIcon.png";
            settingsButton.ImageList = mainImageList;
            settingsButton.Location = new Point(0, 100);
            settingsButton.Name = "settingsButton";
            settingsButton.Padding = new Padding(5, 0, 0, 0);
            settingsButton.Size = new Size(190, 45);
            settingsButton.TabIndex = 6;
            settingsButton.Text = "   Settings";
            settingsButton.TextImageRelation = TextImageRelation.ImageBeforeText;
            mainToolTip.SetToolTip(settingsButton, "Configure X-Search.");
            settingsButton.UseVisualStyleBackColor = false;
            settingsButton.Click += settingsButton_Click;
            // 
            // domainsButton
            // 
            domainsButton.BackColor = Color.Transparent;
            domainsButton.Dock = DockStyle.Top;
            domainsButton.FlatAppearance.BorderSize = 0;
            domainsButton.FlatStyle = FlatStyle.Flat;
            domainsButton.ForeColor = Color.FromArgb(50, 50, 80);
            domainsButton.ImageAlign = ContentAlignment.MiddleLeft;
            domainsButton.ImageKey = "DomainsIcon.png";
            domainsButton.ImageList = mainImageList;
            domainsButton.Location = new Point(0, 55);
            domainsButton.Name = "domainsButton";
            domainsButton.Padding = new Padding(5, 0, 0, 0);
            domainsButton.Size = new Size(190, 45);
            domainsButton.TabIndex = 3;
            domainsButton.Text = "   Domains";
            domainsButton.TextImageRelation = TextImageRelation.ImageBeforeText;
            mainToolTip.SetToolTip(domainsButton, "Configure (or load) configurations for web domains to pull results from.");
            domainsButton.UseVisualStyleBackColor = false;
            domainsButton.Click += domainsButton_Click;
            // 
            // workspaceButton
            // 
            workspaceButton.BackColor = Color.Transparent;
            workspaceButton.Dock = DockStyle.Top;
            workspaceButton.FlatAppearance.BorderSize = 0;
            workspaceButton.FlatStyle = FlatStyle.Flat;
            workspaceButton.ForeColor = Color.FromArgb(50, 50, 80);
            workspaceButton.ImageAlign = ContentAlignment.MiddleLeft;
            workspaceButton.ImageKey = "WorkspaceIcon.png";
            workspaceButton.ImageList = mainImageList;
            workspaceButton.Location = new Point(0, 10);
            workspaceButton.Name = "workspaceButton";
            workspaceButton.Padding = new Padding(5, 0, 0, 0);
            workspaceButton.Size = new Size(190, 45);
            workspaceButton.TabIndex = 2;
            workspaceButton.Text = "   Workspace";
            workspaceButton.TextImageRelation = TextImageRelation.ImageBeforeText;
            mainToolTip.SetToolTip(workspaceButton, "Pull and evaluate listings.");
            workspaceButton.UseVisualStyleBackColor = false;
            workspaceButton.Click += workspaceButton_Click;
            // 
            // titlePanel
            // 
            titlePanel.AutoScroll = true;
            titlePanel.BackgroundImage = Properties.Resources.BG9;
            titlePanel.BackgroundImageLayout = ImageLayout.Stretch;
            titlePanel.Controls.Add(titlePictureBox);
            titlePanel.Controls.Add(titleLabel);
            titlePanel.Dock = DockStyle.Top;
            titlePanel.Location = new Point(0, 0);
            titlePanel.Name = "titlePanel";
            titlePanel.Padding = new Padding(5);
            titlePanel.Size = new Size(190, 43);
            titlePanel.TabIndex = 0;
            // 
            // titlePictureBox
            // 
            titlePictureBox.BackgroundImage = Properties.Resources.XSearchF;
            titlePictureBox.BackgroundImageLayout = ImageLayout.Zoom;
            titlePictureBox.Dock = DockStyle.Fill;
            titlePictureBox.Location = new Point(5, 5);
            titlePictureBox.Name = "titlePictureBox";
            titlePictureBox.Size = new Size(180, 33);
            titlePictureBox.TabIndex = 1;
            titlePictureBox.TabStop = false;
            // 
            // titleLabel
            // 
            titleLabel.BackColor = Color.Transparent;
            titleLabel.Dock = DockStyle.Fill;
            titleLabel.Font = new Font("Segoe UI Variable Display Semil", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            titleLabel.ForeColor = Color.FromArgb(250, 250, 255);
            titleLabel.Location = new Point(5, 5);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(180, 33);
            titleLabel.TabIndex = 0;
            titleLabel.Text = "X-SEARCH";
            titleLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // workspaceContainerPanel
            // 
            workspaceContainerPanel.BackColor = Color.Transparent;
            workspaceContainerPanel.Controls.Add(framingPanel);
            workspaceContainerPanel.Controls.Add(frameLabelPanel);
            workspaceContainerPanel.Dock = DockStyle.Fill;
            workspaceContainerPanel.Location = new Point(215, 15);
            workspaceContainerPanel.Name = "workspaceContainerPanel";
            workspaceContainerPanel.Size = new Size(676, 713);
            workspaceContainerPanel.TabIndex = 1;
            // 
            // framingPanel
            // 
            framingPanel.BackColor = Color.FromArgb(250, 250, 255);
            framingPanel.BackgroundImageLayout = ImageLayout.Stretch;
            framingPanel.Dock = DockStyle.Fill;
            framingPanel.Location = new Point(0, 39);
            framingPanel.Name = "framingPanel";
            framingPanel.Padding = new Padding(10);
            framingPanel.Size = new Size(676, 674);
            framingPanel.TabIndex = 0;
            // 
            // frameLabelPanel
            // 
            frameLabelPanel.BackColor = Color.Transparent;
            frameLabelPanel.BackgroundImage = Properties.Resources.BG8;
            frameLabelPanel.BackgroundImageLayout = ImageLayout.Stretch;
            frameLabelPanel.Controls.Add(frameLabel);
            frameLabelPanel.Dock = DockStyle.Top;
            frameLabelPanel.Location = new Point(0, 0);
            frameLabelPanel.Name = "frameLabelPanel";
            frameLabelPanel.Size = new Size(676, 39);
            frameLabelPanel.TabIndex = 1;
            // 
            // frameLabel
            // 
            frameLabel.BackColor = Color.Transparent;
            frameLabel.Dock = DockStyle.Top;
            frameLabel.Font = new Font("Segoe UI Variable Display", 16F, FontStyle.Bold);
            frameLabel.ForeColor = Color.FromArgb(50, 50, 80);
            frameLabel.Location = new Point(0, 0);
            frameLabel.Name = "frameLabel";
            frameLabel.Size = new Size(676, 39);
            frameLabel.TabIndex = 1;
            frameLabel.Text = "Workspace";
            frameLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // mainToolTip
            // 
            mainToolTip.Popup += mainToolTip_Popup;
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
            Font = new Font("Segoe UI Variable Text Semibold", 10F, FontStyle.Bold);
            ForeColor = Color.FromArgb(0, 0, 20);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(5);
            Name = "MainForm";
            Padding = new Padding(15);
            SizeGripStyle = SizeGripStyle.Show;
            Text = "X-Search";
            FormClosing += MainForm_FormClosing;
            infoPanel.ResumeLayout(false);
            toolsContainerPanel.ResumeLayout(false);
            workspaceToolLabelPanel.ResumeLayout(false);
            statusContainerPanel.ResumeLayout(false);
            statusPanel.ResumeLayout(false);
            statusReportPanel.ResumeLayout(false);
            statusReportPanel.PerformLayout();
            searchProgressPanel.ResumeLayout(false);
            rowInfoPanel.ResumeLayout(false);
            statusTitleLabelPanel.ResumeLayout(false);
            controlContainerPanel.ResumeLayout(false);
            controlPanel.ResumeLayout(false);
            indexContainerPanel.ResumeLayout(false);
            titlePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)titlePictureBox).EndInit();
            workspaceContainerPanel.ResumeLayout(false);
            frameLabelPanel.ResumeLayout(false);
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
        private ToolTip mainToolTip;
        private ImageList mainImageList;
        private Panel frameLabelPanel;
        private Panel workspaceToolLabelPanel;
        private Panel statusTitleLabelPanel;
        private PictureBox titlePictureBox;
    }
}
