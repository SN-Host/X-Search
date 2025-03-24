namespace XSearch_WinForms
{
    partial class Domains
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            dataGridViewPanel = new Panel();
            mainDataGridView = new DataGridView();
            activeDataGridViewColumn = new DataGridViewCheckBoxColumn();
            domainLabelDataGridViewColumn = new DataGridViewTextBoxColumn();
            searchUrlPatternDataGridViewColumn = new DataGridViewTextBoxColumn();
            listingUrlPatternDataGridViewColumn = new DataGridViewTextBoxColumn();
            controlPanel = new Panel();
            loadDomainsButton = new Button();
            saveDomainsButton = new Button();
            clearDomainsButton = new Button();
            removeDomainButton = new Button();
            addNewDomainButton = new Button();
            enableDomainButton = new Button();
            editorPanel = new Panel();
            controlContainerPanel = new Panel();
            domainFieldsPanel = new Panel();
            pageCountMultiplierPanel = new Panel();
            pageCountMultiplierNumericUpDown = new NumericUpDown();
            pageCountMultiplierLabel = new Label();
            listingUrlPanel = new Panel();
            listingUrlTextBox = new TextBox();
            listingUrlLabel = new Label();
            searchUrlPanel = new Panel();
            searchUrlTextBox = new TextBox();
            searchUrlLabel = new Label();
            labelPanel = new Panel();
            labelTextBox = new TextBox();
            labelLabel = new Label();
            domainEditorHeaderLabel = new Label();
            mainTooltip = new ToolTip(components);
            dataGridViewPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)mainDataGridView).BeginInit();
            controlPanel.SuspendLayout();
            editorPanel.SuspendLayout();
            controlContainerPanel.SuspendLayout();
            domainFieldsPanel.SuspendLayout();
            pageCountMultiplierPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pageCountMultiplierNumericUpDown).BeginInit();
            listingUrlPanel.SuspendLayout();
            searchUrlPanel.SuspendLayout();
            labelPanel.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridViewPanel
            // 
            dataGridViewPanel.Controls.Add(mainDataGridView);
            dataGridViewPanel.Dock = DockStyle.Fill;
            dataGridViewPanel.Location = new Point(165, 0);
            dataGridViewPanel.Name = "dataGridViewPanel";
            dataGridViewPanel.Padding = new Padding(10);
            dataGridViewPanel.Size = new Size(817, 475);
            dataGridViewPanel.TabIndex = 5;
            // 
            // mainDataGridView
            // 
            mainDataGridView.AllowUserToAddRows = false;
            mainDataGridView.AllowUserToOrderColumns = true;
            mainDataGridView.AllowUserToResizeRows = false;
            mainDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            mainDataGridView.BackgroundColor = Color.FromArgb(180, 180, 210);
            mainDataGridView.BorderStyle = BorderStyle.None;
            mainDataGridView.CellBorderStyle = DataGridViewCellBorderStyle.Sunken;
            mainDataGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI Variable Text Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(50, 50, 100);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(100, 100, 200);
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            mainDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            mainDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            mainDataGridView.Columns.AddRange(new DataGridViewColumn[] { activeDataGridViewColumn, domainLabelDataGridViewColumn, searchUrlPatternDataGridViewColumn, listingUrlPatternDataGridViewColumn });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(230, 230, 245);
            dataGridViewCellStyle2.Font = new Font("Segoe UI Variable Text Semibold", 11.25F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(50, 50, 60);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(100, 100, 200);
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            mainDataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            mainDataGridView.Dock = DockStyle.Fill;
            mainDataGridView.Location = new Point(10, 10);
            mainDataGridView.Name = "mainDataGridView";
            mainDataGridView.RowHeadersVisible = false;
            mainDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            mainDataGridView.ShowCellErrors = false;
            mainDataGridView.ShowRowErrors = false;
            mainDataGridView.Size = new Size(797, 455);
            mainDataGridView.TabIndex = 2;
            // 
            // activeDataGridViewColumn
            // 
            activeDataGridViewColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            activeDataGridViewColumn.DataPropertyName = "Active";
            activeDataGridViewColumn.FillWeight = 25F;
            activeDataGridViewColumn.HeaderText = "Active";
            activeDataGridViewColumn.Name = "activeDataGridViewColumn";
            activeDataGridViewColumn.Width = 70;
            // 
            // domainLabelDataGridViewColumn
            // 
            domainLabelDataGridViewColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            domainLabelDataGridViewColumn.DataPropertyName = "Label";
            domainLabelDataGridViewColumn.FillWeight = 75F;
            domainLabelDataGridViewColumn.HeaderText = "Domain label";
            domainLabelDataGridViewColumn.Name = "domainLabelDataGridViewColumn";
            domainLabelDataGridViewColumn.ReadOnly = true;
            domainLabelDataGridViewColumn.Resizable = DataGridViewTriState.True;
            // 
            // searchUrlPatternDataGridViewColumn
            // 
            searchUrlPatternDataGridViewColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            searchUrlPatternDataGridViewColumn.DataPropertyName = "SearchUrlPattern";
            searchUrlPatternDataGridViewColumn.FillWeight = 75F;
            searchUrlPatternDataGridViewColumn.HeaderText = "Search URL pattern";
            searchUrlPatternDataGridViewColumn.Name = "searchUrlPatternDataGridViewColumn";
            searchUrlPatternDataGridViewColumn.ReadOnly = true;
            // 
            // listingUrlPatternDataGridViewColumn
            // 
            listingUrlPatternDataGridViewColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            listingUrlPatternDataGridViewColumn.DataPropertyName = "ListingUrlPattern";
            listingUrlPatternDataGridViewColumn.FillWeight = 75F;
            listingUrlPatternDataGridViewColumn.HeaderText = "Listing URL pattern";
            listingUrlPatternDataGridViewColumn.Name = "listingUrlPatternDataGridViewColumn";
            listingUrlPatternDataGridViewColumn.ReadOnly = true;
            // 
            // controlPanel
            // 
            controlPanel.AutoScroll = true;
            controlPanel.Controls.Add(loadDomainsButton);
            controlPanel.Controls.Add(saveDomainsButton);
            controlPanel.Controls.Add(clearDomainsButton);
            controlPanel.Controls.Add(removeDomainButton);
            controlPanel.Controls.Add(addNewDomainButton);
            controlPanel.Controls.Add(enableDomainButton);
            controlPanel.Dock = DockStyle.Left;
            controlPanel.Location = new Point(0, 0);
            controlPanel.Margin = new Padding(0);
            controlPanel.Name = "controlPanel";
            controlPanel.Size = new Size(165, 655);
            controlPanel.TabIndex = 4;
            controlPanel.Visible = false;
            // 
            // loadDomainsButton
            // 
            loadDomainsButton.Dock = DockStyle.Top;
            loadDomainsButton.Enabled = false;
            loadDomainsButton.FlatAppearance.BorderSize = 0;
            loadDomainsButton.FlatStyle = FlatStyle.Flat;
            loadDomainsButton.Font = new Font("Segoe UI Variable Text", 10F);
            loadDomainsButton.Image = Properties.Resources.placeholder_25x25_dark;
            loadDomainsButton.ImageAlign = ContentAlignment.MiddleLeft;
            loadDomainsButton.Location = new Point(0, 180);
            loadDomainsButton.Name = "loadDomainsButton";
            loadDomainsButton.Padding = new Padding(5, 0, 0, 0);
            loadDomainsButton.Size = new Size(165, 36);
            loadDomainsButton.TabIndex = 7;
            loadDomainsButton.Text = "  Load domains";
            loadDomainsButton.TextImageRelation = TextImageRelation.ImageBeforeText;
            loadDomainsButton.UseVisualStyleBackColor = true;
            // 
            // saveDomainsButton
            // 
            saveDomainsButton.Dock = DockStyle.Top;
            saveDomainsButton.Enabled = false;
            saveDomainsButton.FlatAppearance.BorderSize = 0;
            saveDomainsButton.FlatStyle = FlatStyle.Flat;
            saveDomainsButton.Font = new Font("Segoe UI Variable Text", 10F);
            saveDomainsButton.Image = Properties.Resources.placeholder_25x25_dark;
            saveDomainsButton.ImageAlign = ContentAlignment.MiddleLeft;
            saveDomainsButton.Location = new Point(0, 144);
            saveDomainsButton.Name = "saveDomainsButton";
            saveDomainsButton.Padding = new Padding(5, 0, 0, 0);
            saveDomainsButton.Size = new Size(165, 36);
            saveDomainsButton.TabIndex = 6;
            saveDomainsButton.Text = "  Save domains";
            saveDomainsButton.TextImageRelation = TextImageRelation.ImageBeforeText;
            saveDomainsButton.UseVisualStyleBackColor = true;
            // 
            // clearDomainsButton
            // 
            clearDomainsButton.Dock = DockStyle.Top;
            clearDomainsButton.FlatAppearance.BorderSize = 0;
            clearDomainsButton.FlatStyle = FlatStyle.Flat;
            clearDomainsButton.Font = new Font("Segoe UI Variable Text", 10F);
            clearDomainsButton.Image = Properties.Resources.placeholder_25x25_dark;
            clearDomainsButton.ImageAlign = ContentAlignment.MiddleLeft;
            clearDomainsButton.Location = new Point(0, 108);
            clearDomainsButton.Name = "clearDomainsButton";
            clearDomainsButton.Padding = new Padding(5, 0, 0, 0);
            clearDomainsButton.Size = new Size(165, 36);
            clearDomainsButton.TabIndex = 8;
            clearDomainsButton.Text = "  Clear domains";
            clearDomainsButton.TextImageRelation = TextImageRelation.ImageBeforeText;
            clearDomainsButton.UseVisualStyleBackColor = true;
            clearDomainsButton.Click += clearDomainsButton_Click;
            // 
            // removeDomainButton
            // 
            removeDomainButton.Dock = DockStyle.Top;
            removeDomainButton.FlatAppearance.BorderSize = 0;
            removeDomainButton.FlatStyle = FlatStyle.Flat;
            removeDomainButton.Font = new Font("Segoe UI Variable Text", 10F);
            removeDomainButton.Image = Properties.Resources.placeholder_25x25_dark;
            removeDomainButton.ImageAlign = ContentAlignment.MiddleLeft;
            removeDomainButton.Location = new Point(0, 72);
            removeDomainButton.Name = "removeDomainButton";
            removeDomainButton.Padding = new Padding(5, 0, 0, 0);
            removeDomainButton.Size = new Size(165, 36);
            removeDomainButton.TabIndex = 4;
            removeDomainButton.Text = "  Remove domain";
            removeDomainButton.TextImageRelation = TextImageRelation.ImageBeforeText;
            removeDomainButton.UseVisualStyleBackColor = true;
            removeDomainButton.Click += removeDomainButton_Click;
            // 
            // addNewDomainButton
            // 
            addNewDomainButton.Dock = DockStyle.Top;
            addNewDomainButton.FlatAppearance.BorderSize = 0;
            addNewDomainButton.FlatStyle = FlatStyle.Flat;
            addNewDomainButton.Font = new Font("Segoe UI Variable Text", 10F);
            addNewDomainButton.Image = Properties.Resources.placeholder_25x25_dark;
            addNewDomainButton.ImageAlign = ContentAlignment.MiddleLeft;
            addNewDomainButton.Location = new Point(0, 36);
            addNewDomainButton.Name = "addNewDomainButton";
            addNewDomainButton.Padding = new Padding(5, 0, 0, 0);
            addNewDomainButton.Size = new Size(165, 36);
            addNewDomainButton.TabIndex = 3;
            addNewDomainButton.Text = "  Add domain";
            addNewDomainButton.TextImageRelation = TextImageRelation.ImageBeforeText;
            addNewDomainButton.UseVisualStyleBackColor = true;
            addNewDomainButton.Click += addNewDomainButton_Click;
            // 
            // enableDomainButton
            // 
            enableDomainButton.Dock = DockStyle.Top;
            enableDomainButton.FlatAppearance.BorderSize = 0;
            enableDomainButton.FlatStyle = FlatStyle.Flat;
            enableDomainButton.Font = new Font("Segoe UI Variable Text", 10F);
            enableDomainButton.Image = Properties.Resources.placeholder_25x25_dark;
            enableDomainButton.ImageAlign = ContentAlignment.MiddleLeft;
            enableDomainButton.Location = new Point(0, 0);
            enableDomainButton.Name = "enableDomainButton";
            enableDomainButton.Padding = new Padding(5, 0, 0, 0);
            enableDomainButton.Size = new Size(165, 36);
            enableDomainButton.TabIndex = 5;
            enableDomainButton.Text = "  Enable domain";
            enableDomainButton.TextImageRelation = TextImageRelation.ImageBeforeText;
            enableDomainButton.UseVisualStyleBackColor = true;
            enableDomainButton.Click += enableDomainButton_Click;
            // 
            // editorPanel
            // 
            editorPanel.Controls.Add(controlContainerPanel);
            editorPanel.Controls.Add(domainEditorHeaderLabel);
            editorPanel.Dock = DockStyle.Bottom;
            editorPanel.Location = new Point(165, 475);
            editorPanel.Name = "editorPanel";
            editorPanel.Padding = new Padding(5);
            editorPanel.Size = new Size(817, 180);
            editorPanel.TabIndex = 6;
            // 
            // controlContainerPanel
            // 
            controlContainerPanel.Controls.Add(domainFieldsPanel);
            controlContainerPanel.Dock = DockStyle.Fill;
            controlContainerPanel.Location = new Point(5, 35);
            controlContainerPanel.Name = "controlContainerPanel";
            controlContainerPanel.Padding = new Padding(5);
            controlContainerPanel.Size = new Size(807, 140);
            controlContainerPanel.TabIndex = 7;
            // 
            // domainFieldsPanel
            // 
            domainFieldsPanel.AutoScroll = true;
            domainFieldsPanel.Controls.Add(pageCountMultiplierPanel);
            domainFieldsPanel.Controls.Add(listingUrlPanel);
            domainFieldsPanel.Controls.Add(searchUrlPanel);
            domainFieldsPanel.Controls.Add(labelPanel);
            domainFieldsPanel.Dock = DockStyle.Fill;
            domainFieldsPanel.Location = new Point(5, 5);
            domainFieldsPanel.Name = "domainFieldsPanel";
            domainFieldsPanel.Size = new Size(797, 130);
            domainFieldsPanel.TabIndex = 14;
            // 
            // pageCountMultiplierPanel
            // 
            pageCountMultiplierPanel.AutoScroll = true;
            pageCountMultiplierPanel.Controls.Add(pageCountMultiplierNumericUpDown);
            pageCountMultiplierPanel.Controls.Add(pageCountMultiplierLabel);
            pageCountMultiplierPanel.Dock = DockStyle.Top;
            pageCountMultiplierPanel.Location = new Point(0, 96);
            pageCountMultiplierPanel.Name = "pageCountMultiplierPanel";
            pageCountMultiplierPanel.Padding = new Padding(5);
            pageCountMultiplierPanel.Size = new Size(797, 32);
            pageCountMultiplierPanel.TabIndex = 20;
            // 
            // pageCountMultiplierNumericUpDown
            // 
            pageCountMultiplierNumericUpDown.Dock = DockStyle.Fill;
            pageCountMultiplierNumericUpDown.Font = new Font("Segoe UI", 10F);
            pageCountMultiplierNumericUpDown.Location = new Point(172, 5);
            pageCountMultiplierNumericUpDown.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            pageCountMultiplierNumericUpDown.Name = "pageCountMultiplierNumericUpDown";
            pageCountMultiplierNumericUpDown.Size = new Size(620, 25);
            pageCountMultiplierNumericUpDown.TabIndex = 4;
            pageCountMultiplierNumericUpDown.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // pageCountMultiplierLabel
            // 
            pageCountMultiplierLabel.BackColor = Color.FromArgb(250, 250, 255);
            pageCountMultiplierLabel.Dock = DockStyle.Left;
            pageCountMultiplierLabel.Font = new Font("Segoe UI Variable Display Semib", 10F, FontStyle.Bold);
            pageCountMultiplierLabel.ImageAlign = ContentAlignment.TopLeft;
            pageCountMultiplierLabel.Location = new Point(5, 5);
            pageCountMultiplierLabel.Name = "pageCountMultiplierLabel";
            pageCountMultiplierLabel.Padding = new Padding(5, 0, 5, 0);
            pageCountMultiplierLabel.Size = new Size(167, 22);
            pageCountMultiplierLabel.TabIndex = 3;
            pageCountMultiplierLabel.Text = "Page count multiplier";
            pageCountMultiplierLabel.TextAlign = ContentAlignment.TopRight;
            // 
            // listingUrlPanel
            // 
            listingUrlPanel.AutoScroll = true;
            listingUrlPanel.Controls.Add(listingUrlTextBox);
            listingUrlPanel.Controls.Add(listingUrlLabel);
            listingUrlPanel.Dock = DockStyle.Top;
            listingUrlPanel.Location = new Point(0, 64);
            listingUrlPanel.Name = "listingUrlPanel";
            listingUrlPanel.Padding = new Padding(5);
            listingUrlPanel.Size = new Size(797, 32);
            listingUrlPanel.TabIndex = 19;
            // 
            // listingUrlTextBox
            // 
            listingUrlTextBox.Dock = DockStyle.Fill;
            listingUrlTextBox.Font = new Font("Segoe UI", 10F);
            listingUrlTextBox.Location = new Point(172, 5);
            listingUrlTextBox.Name = "listingUrlTextBox";
            listingUrlTextBox.Size = new Size(620, 25);
            listingUrlTextBox.TabIndex = 4;
            // 
            // listingUrlLabel
            // 
            listingUrlLabel.BackColor = Color.FromArgb(250, 250, 255);
            listingUrlLabel.Dock = DockStyle.Left;
            listingUrlLabel.Font = new Font("Segoe UI Variable Display Semib", 10F, FontStyle.Bold);
            listingUrlLabel.ImageAlign = ContentAlignment.TopLeft;
            listingUrlLabel.Location = new Point(5, 5);
            listingUrlLabel.Name = "listingUrlLabel";
            listingUrlLabel.Padding = new Padding(5, 0, 5, 0);
            listingUrlLabel.Size = new Size(167, 22);
            listingUrlLabel.TabIndex = 3;
            listingUrlLabel.Text = "Listing URL pattern:";
            listingUrlLabel.TextAlign = ContentAlignment.TopRight;
            // 
            // searchUrlPanel
            // 
            searchUrlPanel.AutoScroll = true;
            searchUrlPanel.Controls.Add(searchUrlTextBox);
            searchUrlPanel.Controls.Add(searchUrlLabel);
            searchUrlPanel.Dock = DockStyle.Top;
            searchUrlPanel.Location = new Point(0, 32);
            searchUrlPanel.Name = "searchUrlPanel";
            searchUrlPanel.Padding = new Padding(5);
            searchUrlPanel.Size = new Size(797, 32);
            searchUrlPanel.TabIndex = 17;
            // 
            // searchUrlTextBox
            // 
            searchUrlTextBox.Dock = DockStyle.Fill;
            searchUrlTextBox.Font = new Font("Segoe UI", 10F);
            searchUrlTextBox.Location = new Point(172, 5);
            searchUrlTextBox.Name = "searchUrlTextBox";
            searchUrlTextBox.Size = new Size(620, 25);
            searchUrlTextBox.TabIndex = 5;
            searchUrlTextBox.KeyUp += searchUrlTextBox_KeyUp;
            // 
            // searchUrlLabel
            // 
            searchUrlLabel.BackColor = Color.FromArgb(250, 250, 255);
            searchUrlLabel.Dock = DockStyle.Left;
            searchUrlLabel.Font = new Font("Segoe UI Variable Display Semib", 10F, FontStyle.Bold);
            searchUrlLabel.ImageAlign = ContentAlignment.TopLeft;
            searchUrlLabel.Location = new Point(5, 5);
            searchUrlLabel.Name = "searchUrlLabel";
            searchUrlLabel.Padding = new Padding(5, 0, 5, 0);
            searchUrlLabel.Size = new Size(167, 22);
            searchUrlLabel.TabIndex = 3;
            searchUrlLabel.Text = "Search URL pattern:";
            searchUrlLabel.TextAlign = ContentAlignment.TopRight;
            // 
            // labelPanel
            // 
            labelPanel.AutoScroll = true;
            labelPanel.Controls.Add(labelTextBox);
            labelPanel.Controls.Add(labelLabel);
            labelPanel.Dock = DockStyle.Top;
            labelPanel.Location = new Point(0, 0);
            labelPanel.Name = "labelPanel";
            labelPanel.Padding = new Padding(5);
            labelPanel.Size = new Size(797, 32);
            labelPanel.TabIndex = 16;
            // 
            // labelTextBox
            // 
            labelTextBox.Dock = DockStyle.Fill;
            labelTextBox.Font = new Font("Segoe UI", 10F);
            labelTextBox.Location = new Point(172, 5);
            labelTextBox.Name = "labelTextBox";
            labelTextBox.Size = new Size(620, 25);
            labelTextBox.TabIndex = 5;
            // 
            // labelLabel
            // 
            labelLabel.BackColor = Color.FromArgb(250, 250, 255);
            labelLabel.Dock = DockStyle.Left;
            labelLabel.Font = new Font("Segoe UI Variable Display Semib", 10F, FontStyle.Bold);
            labelLabel.Location = new Point(5, 5);
            labelLabel.Name = "labelLabel";
            labelLabel.Padding = new Padding(5, 0, 5, 0);
            labelLabel.Size = new Size(167, 22);
            labelLabel.TabIndex = 3;
            labelLabel.Text = "Domain label:";
            labelLabel.TextAlign = ContentAlignment.TopRight;
            // 
            // domainEditorHeaderLabel
            // 
            domainEditorHeaderLabel.BackColor = Color.FromArgb(100, 100, 150);
            domainEditorHeaderLabel.Dock = DockStyle.Top;
            domainEditorHeaderLabel.Font = new Font("Segoe UI Variable Text Semibold", 11.25F, FontStyle.Bold);
            domainEditorHeaderLabel.ForeColor = Color.FromArgb(250, 250, 255);
            domainEditorHeaderLabel.Location = new Point(5, 5);
            domainEditorHeaderLabel.Name = "domainEditorHeaderLabel";
            domainEditorHeaderLabel.Padding = new Padding(5);
            domainEditorHeaderLabel.Size = new Size(807, 30);
            domainEditorHeaderLabel.TabIndex = 9;
            domainEditorHeaderLabel.Text = "Domain editor";
            domainEditorHeaderLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Domains
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.FromArgb(250, 250, 255);
            ClientSize = new Size(982, 655);
            Controls.Add(dataGridViewPanel);
            Controls.Add(editorPanel);
            Controls.Add(controlPanel);
            DoubleBuffered = true;
            Name = "Domains";
            Text = "Domains";
            dataGridViewPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)mainDataGridView).EndInit();
            controlPanel.ResumeLayout(false);
            editorPanel.ResumeLayout(false);
            controlContainerPanel.ResumeLayout(false);
            domainFieldsPanel.ResumeLayout(false);
            pageCountMultiplierPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pageCountMultiplierNumericUpDown).EndInit();
            listingUrlPanel.ResumeLayout(false);
            listingUrlPanel.PerformLayout();
            searchUrlPanel.ResumeLayout(false);
            searchUrlPanel.PerformLayout();
            labelPanel.ResumeLayout(false);
            labelPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel dataGridViewPanel;
        private DataGridView mainDataGridView;
        internal Panel controlPanel;
        private Button clearAllButton;
        private Button uncrossButton;
        private Button crossButton;
        private Button webPreviewButton;
        private Button addNewDomainButton;
        private Button removeDomainButton;
        private Button enableDomainButton;
        private Panel editorPanel;
        private Panel controlContainerPanel;
        private Label domainEditorHeaderLabel;
        private Panel domainFieldsPanel;
        private Panel searchUrlPanel;
        private Label searchUrlLabel;
        private Panel labelPanel;
        private Label labelLabel;
        private Button loadDomainsButton;
        private Button saveDomainsButton;
        private Panel listingUrlPanel;
        private TextBox listingUrlTextBox;
        private Label listingUrlLabel;
        private ToolTip mainTooltip;
        private TextBox searchUrlTextBox;
        private TextBox labelTextBox;
        private DataGridViewCheckBoxColumn activeDataGridViewColumn;
        private DataGridViewTextBoxColumn domainLabelDataGridViewColumn;
        private DataGridViewTextBoxColumn searchUrlPatternDataGridViewColumn;
        private DataGridViewTextBoxColumn listingUrlPatternDataGridViewColumn;
        private Button clearDomainsButton;
        private Panel pageCountMultiplierPanel;
        private NumericUpDown pageCountMultiplierNumericUpDown;
        private Label pageCountMultiplierLabel;
    }
}