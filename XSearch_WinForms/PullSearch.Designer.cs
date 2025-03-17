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
            editorPanel = new Panel();
            controlContainerPanel = new Panel();
            searchTermContainerPanel = new Panel();
            pullSearchButton = new Button();
            pageCountPanel = new Panel();
            pageCountNumericUpDown = new NumericUpDown();
            pageCountLabel = new Label();
            searchTermPanel = new Panel();
            searchTermTextBox = new TextBox();
            searchTermLabel = new Label();
            pullSearchHeaderLabel = new Label();
            editorPanel.SuspendLayout();
            controlContainerPanel.SuspendLayout();
            searchTermContainerPanel.SuspendLayout();
            pageCountPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pageCountNumericUpDown).BeginInit();
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
            editorPanel.Size = new Size(430, 158);
            editorPanel.TabIndex = 7;
            // 
            // controlContainerPanel
            // 
            controlContainerPanel.Controls.Add(searchTermContainerPanel);
            controlContainerPanel.Dock = DockStyle.Fill;
            controlContainerPanel.Location = new Point(5, 35);
            controlContainerPanel.Name = "controlContainerPanel";
            controlContainerPanel.Padding = new Padding(5);
            controlContainerPanel.Size = new Size(420, 118);
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
            searchTermContainerPanel.Size = new Size(410, 108);
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
            pullSearchButton.Size = new Size(410, 36);
            pullSearchButton.TabIndex = 22;
            pullSearchButton.Text = "   Pull now";
            pullSearchButton.TextImageRelation = TextImageRelation.ImageBeforeText;
            pullSearchButton.UseVisualStyleBackColor = false;
            pullSearchButton.Click += pullSearchButton_Click;
            // 
            // pageCountPanel
            // 
            pageCountPanel.AutoScroll = true;
            pageCountPanel.Controls.Add(pageCountNumericUpDown);
            pageCountPanel.Controls.Add(pageCountLabel);
            pageCountPanel.Dock = DockStyle.Top;
            pageCountPanel.Location = new Point(0, 35);
            pageCountPanel.Name = "pageCountPanel";
            pageCountPanel.Padding = new Padding(5);
            pageCountPanel.Size = new Size(410, 35);
            pageCountPanel.TabIndex = 20;
            // 
            // pageCountNumericUpDown
            // 
            pageCountNumericUpDown.Dock = DockStyle.Fill;
            pageCountNumericUpDown.Location = new Point(139, 5);
            pageCountNumericUpDown.Name = "pageCountNumericUpDown";
            pageCountNumericUpDown.Size = new Size(266, 27);
            pageCountNumericUpDown.TabIndex = 4;
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
            pageCountLabel.Size = new Size(134, 25);
            pageCountLabel.TabIndex = 3;
            pageCountLabel.Text = "Pages to search:";
            pageCountLabel.TextAlign = ContentAlignment.MiddleRight;
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
            searchTermPanel.Size = new Size(410, 35);
            searchTermPanel.TabIndex = 19;
            // 
            // searchTermTextBox
            // 
            searchTermTextBox.Dock = DockStyle.Fill;
            searchTermTextBox.Font = new Font("Segoe UI", 10F);
            searchTermTextBox.Location = new Point(139, 5);
            searchTermTextBox.Name = "searchTermTextBox";
            searchTermTextBox.Size = new Size(266, 25);
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
            searchTermLabel.Size = new Size(134, 25);
            searchTermLabel.TabIndex = 3;
            searchTermLabel.Text = "Search term:";
            searchTermLabel.TextAlign = ContentAlignment.MiddleRight;
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
            pullSearchHeaderLabel.Size = new Size(420, 30);
            pullSearchHeaderLabel.TabIndex = 9;
            pullSearchHeaderLabel.Text = "Pull Search";
            pullSearchHeaderLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // PullSearch
            // 
            AcceptButton = pullSearchButton;
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.FromArgb(250, 250, 255);
            ClientSize = new Size(430, 158);
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
            ((System.ComponentModel.ISupportInitialize)pageCountNumericUpDown).EndInit();
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
        private NumericUpDown pageCountNumericUpDown;
        private Button pullSearchButton;
    }
}