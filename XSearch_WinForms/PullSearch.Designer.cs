namespace XSearch_WinForms
{
    partial class PullSearch
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PullSearch));
            editorPanel = new Panel();
            controlContainerPanel = new Panel();
            searchTermContainerPanel = new Panel();
            pullSearchButton = new Button();
            pageCountPanel = new Panel();
            resultsPerDomainNumericUpDown = new NumericUpDown();
            pageCountLabel = new Label();
            searchTermPanel = new Panel();
            searchTermTextBox = new TextBox();
            searchTermLabel = new Label();
            pullSearchHeaderLabel = new Label();
            mainToolTip = new ToolTip(components);
            editorPanel.SuspendLayout();
            controlContainerPanel.SuspendLayout();
            searchTermContainerPanel.SuspendLayout();
            pageCountPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)resultsPerDomainNumericUpDown).BeginInit();
            searchTermPanel.SuspendLayout();
            SuspendLayout();
            // 
            // editorPanel
            // 
            editorPanel.Controls.Add(controlContainerPanel);
            editorPanel.Controls.Add(pullSearchHeaderLabel);
            editorPanel.Dock = DockStyle.Fill;
            editorPanel.Location = new Point(0, 0);
            editorPanel.Name = "editorPanel";
            editorPanel.Padding = new Padding(5);
            editorPanel.Size = new Size(502, 159);
            editorPanel.TabIndex = 7;
            // 
            // controlContainerPanel
            // 
            controlContainerPanel.Controls.Add(searchTermContainerPanel);
            controlContainerPanel.Dock = DockStyle.Fill;
            controlContainerPanel.Location = new Point(5, 35);
            controlContainerPanel.Name = "controlContainerPanel";
            controlContainerPanel.Padding = new Padding(5);
            controlContainerPanel.Size = new Size(492, 119);
            controlContainerPanel.TabIndex = 7;
            // 
            // searchTermContainerPanel
            // 
            searchTermContainerPanel.AutoScroll = true;
            searchTermContainerPanel.Controls.Add(pullSearchButton);
            searchTermContainerPanel.Controls.Add(pageCountPanel);
            searchTermContainerPanel.Controls.Add(searchTermPanel);
            searchTermContainerPanel.Dock = DockStyle.Fill;
            searchTermContainerPanel.Location = new Point(5, 5);
            searchTermContainerPanel.Name = "searchTermContainerPanel";
            searchTermContainerPanel.Size = new Size(482, 109);
            searchTermContainerPanel.TabIndex = 14;
            // 
            // pullSearchButton
            // 
            pullSearchButton.BackColor = Color.FromArgb(200, 200, 240);
            pullSearchButton.Dock = DockStyle.Top;
            pullSearchButton.FlatAppearance.BorderSize = 0;
            pullSearchButton.FlatStyle = FlatStyle.Flat;
            pullSearchButton.Font = new Font("Segoe UI Variable Display", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            pullSearchButton.Image = Properties.Resources.placeholder_25x25_dark;
            pullSearchButton.ImageAlign = ContentAlignment.MiddleRight;
            pullSearchButton.Location = new Point(0, 70);
            pullSearchButton.Name = "pullSearchButton";
            pullSearchButton.Padding = new Padding(5, 0, 0, 0);
            pullSearchButton.Size = new Size(482, 36);
            pullSearchButton.TabIndex = 22;
            pullSearchButton.Text = "   Pull now";
            pullSearchButton.TextImageRelation = TextImageRelation.ImageBeforeText;
            pullSearchButton.UseVisualStyleBackColor = false;
            pullSearchButton.Click += pullSearchButton_Click;
            // 
            // pageCountPanel
            // 
            pageCountPanel.AutoScroll = true;
            pageCountPanel.Controls.Add(resultsPerDomainNumericUpDown);
            pageCountPanel.Controls.Add(pageCountLabel);
            pageCountPanel.Dock = DockStyle.Top;
            pageCountPanel.Location = new Point(0, 35);
            pageCountPanel.Name = "pageCountPanel";
            pageCountPanel.Padding = new Padding(5);
            pageCountPanel.Size = new Size(482, 35);
            pageCountPanel.TabIndex = 20;
            // 
            // resultsPerDomainNumericUpDown
            // 
            resultsPerDomainNumericUpDown.Dock = DockStyle.Fill;
            resultsPerDomainNumericUpDown.Increment = new decimal(new int[] { 25, 0, 0, 0 });
            resultsPerDomainNumericUpDown.Location = new Point(201, 5);
            resultsPerDomainNumericUpDown.Maximum = new decimal(new int[] { 500, 0, 0, 0 });
            resultsPerDomainNumericUpDown.Name = "resultsPerDomainNumericUpDown";
            resultsPerDomainNumericUpDown.Size = new Size(276, 27);
            resultsPerDomainNumericUpDown.TabIndex = 4;
            resultsPerDomainNumericUpDown.Value = new decimal(new int[] { 50, 0, 0, 0 });
            // 
            // pageCountLabel
            // 
            pageCountLabel.BackColor = Color.FromArgb(250, 250, 255);
            pageCountLabel.Dock = DockStyle.Left;
            pageCountLabel.Font = new Font("Segoe UI Variable Display Semib", 10F, FontStyle.Bold);
            pageCountLabel.ImageAlign = ContentAlignment.TopLeft;
            pageCountLabel.Location = new Point(5, 5);
            pageCountLabel.Name = "pageCountLabel";
            pageCountLabel.Padding = new Padding(5, 0, 5, 0);
            pageCountLabel.Size = new Size(196, 25);
            pageCountLabel.TabIndex = 3;
            pageCountLabel.Text = "Results to check per domain:";
            pageCountLabel.TextAlign = ContentAlignment.MiddleRight;
            mainToolTip.SetToolTip(pageCountLabel, "The number of results to query for each domain.\r\n\r\nDuplicate listings will not be pulled, but will still count toward this number.");
            // 
            // searchTermPanel
            // 
            searchTermPanel.AutoScroll = true;
            searchTermPanel.Controls.Add(searchTermTextBox);
            searchTermPanel.Controls.Add(searchTermLabel);
            searchTermPanel.Dock = DockStyle.Top;
            searchTermPanel.Location = new Point(0, 0);
            searchTermPanel.Name = "searchTermPanel";
            searchTermPanel.Padding = new Padding(5);
            searchTermPanel.Size = new Size(482, 35);
            searchTermPanel.TabIndex = 19;
            // 
            // searchTermTextBox
            // 
            searchTermTextBox.Dock = DockStyle.Fill;
            searchTermTextBox.Font = new Font("Segoe UI", 10F);
            searchTermTextBox.Location = new Point(201, 5);
            searchTermTextBox.Name = "searchTermTextBox";
            searchTermTextBox.Size = new Size(276, 25);
            searchTermTextBox.TabIndex = 4;
            // 
            // searchTermLabel
            // 
            searchTermLabel.BackColor = Color.FromArgb(250, 250, 255);
            searchTermLabel.Dock = DockStyle.Left;
            searchTermLabel.Font = new Font("Segoe UI Variable Display Semib", 10F, FontStyle.Bold);
            searchTermLabel.ImageAlign = ContentAlignment.TopLeft;
            searchTermLabel.Location = new Point(5, 5);
            searchTermLabel.Name = "searchTermLabel";
            searchTermLabel.Padding = new Padding(5, 0, 5, 0);
            searchTermLabel.Size = new Size(196, 25);
            searchTermLabel.TabIndex = 3;
            searchTermLabel.Text = "Search term:";
            searchTermLabel.TextAlign = ContentAlignment.MiddleRight;
            mainToolTip.SetToolTip(searchTermLabel, resources.GetString("searchTermLabel.ToolTip"));
            // 
            // pullSearchHeaderLabel
            // 
            pullSearchHeaderLabel.BackColor = Color.FromArgb(100, 100, 150);
            pullSearchHeaderLabel.Dock = DockStyle.Top;
            pullSearchHeaderLabel.Font = new Font("Segoe UI Variable Text Semibold", 11.25F, FontStyle.Bold);
            pullSearchHeaderLabel.ForeColor = Color.FromArgb(250, 250, 255);
            pullSearchHeaderLabel.Location = new Point(5, 5);
            pullSearchHeaderLabel.Name = "pullSearchHeaderLabel";
            pullSearchHeaderLabel.Padding = new Padding(5);
            pullSearchHeaderLabel.Size = new Size(492, 30);
            pullSearchHeaderLabel.TabIndex = 9;
            pullSearchHeaderLabel.Text = "Pull Search";
            pullSearchHeaderLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // mainToolTip
            // 
            mainToolTip.Popup += mainToolTip_Popup;
            // 
            // PullSearch
            // 
            AcceptButton = pullSearchButton;
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.FromArgb(250, 250, 255);
            ClientSize = new Size(502, 159);
            Controls.Add(editorPanel);
            Font = new Font("Segoe UI Variable Text Semibold", 11.25F, FontStyle.Bold);
            ForeColor = Color.FromArgb(50, 50, 100);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Margin = new Padding(4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "PullSearch";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Pull Search";
            Load += PullSearch_Load;
            editorPanel.ResumeLayout(false);
            controlContainerPanel.ResumeLayout(false);
            searchTermContainerPanel.ResumeLayout(false);
            pageCountPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)resultsPerDomainNumericUpDown).EndInit();
            searchTermPanel.ResumeLayout(false);
            searchTermPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel editorPanel;
        private Panel controlContainerPanel;
        private Panel searchTermContainerPanel;
        private Panel searchTermPanel;
        private TextBox searchTermTextBox;
        private Label searchTermLabel;
        private Label pullSearchHeaderLabel;
        private Panel pageCountPanel;
        private Label pageCountLabel;
        private NumericUpDown resultsPerDomainNumericUpDown;
        private Button pullSearchButton;
        private ToolTip mainToolTip;
    }
}