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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Domains));
            dataGridViewPanel = new Panel();
            mainDataGridView = new DataGridView();
            activeDataGridViewColumn = new DataGridViewCheckBoxColumn();
            domainLabelDataGridViewColumn = new DataGridViewTextBoxColumn();
            searchUrlPatternDataGridViewColumn = new DataGridViewTextBoxColumn();
            listingUrlPatternDataGridViewColumn = new DataGridViewTextBoxColumn();
            controlPanel = new Panel();
            loadDomainsButton = new Button();
            saveDomainsButton = new Button();
            removeDomainButton = new Button();
            addNewDomainButton = new Button();
            enableDomainButton = new Button();
            editorPanel = new Panel();
            controlContainerPanel = new Panel();
            domainFieldsPanel = new Panel();
            xpathEditorPanel = new Panel();
            xpathEditorTextBox = new TextBox();
            xpathEditorContainerPanelTop = new Panel();
            xpathEditorComboBox = new ComboBox();
            xpathButtonsPanel = new Panel();
            deleteXpathButton = new Button();
            addNewXpathButton = new Button();
            xpathEditorLabel = new Label();
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
            errorTooltip = new ToolTip(components);
            infoToolTip = new ToolTip(components);
            domainsSaveFileDialog = new SaveFileDialog();
            domainsOpenFileDialog = new OpenFileDialog();
            mainToolTip = new ToolTip(components);
            dataGridViewPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)mainDataGridView).BeginInit();
            controlPanel.SuspendLayout();
            editorPanel.SuspendLayout();
            controlContainerPanel.SuspendLayout();
            domainFieldsPanel.SuspendLayout();
            xpathEditorPanel.SuspendLayout();
            xpathEditorContainerPanelTop.SuspendLayout();
            xpathButtonsPanel.SuspendLayout();
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
            dataGridViewPanel.Size = new Size(817, 420);
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
            mainDataGridView.Size = new Size(797, 400);
            mainDataGridView.TabIndex = 2;
            mainDataGridView.SelectionChanged += mainDataGridView_SelectionChanged;
            // 
            // activeDataGridViewColumn
            // 
            activeDataGridViewColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            activeDataGridViewColumn.DataPropertyName = "Active";
            activeDataGridViewColumn.FillWeight = 30F;
            activeDataGridViewColumn.HeaderText = "Active";
            activeDataGridViewColumn.Name = "activeDataGridViewColumn";
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
            searchUrlPatternDataGridViewColumn.HeaderText = "Starting URL";
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
            loadDomainsButton.FlatAppearance.BorderSize = 0;
            loadDomainsButton.FlatStyle = FlatStyle.Flat;
            loadDomainsButton.Font = new Font("Segoe UI Variable Text", 10F);
            loadDomainsButton.Image = Properties.Resources.placeholder_25x25_dark;
            loadDomainsButton.ImageAlign = ContentAlignment.MiddleLeft;
            loadDomainsButton.Location = new Point(0, 144);
            loadDomainsButton.Name = "loadDomainsButton";
            loadDomainsButton.Padding = new Padding(5, 0, 0, 0);
            loadDomainsButton.Size = new Size(165, 36);
            loadDomainsButton.TabIndex = 7;
            loadDomainsButton.Text = "  Load domains";
            loadDomainsButton.TextImageRelation = TextImageRelation.ImageBeforeText;
            mainToolTip.SetToolTip(loadDomainsButton, "Load a domain profile from an existing file.");
            loadDomainsButton.UseVisualStyleBackColor = true;
            loadDomainsButton.Click += loadDomainsButton_Click;
            // 
            // saveDomainsButton
            // 
            saveDomainsButton.Dock = DockStyle.Top;
            saveDomainsButton.FlatAppearance.BorderSize = 0;
            saveDomainsButton.FlatStyle = FlatStyle.Flat;
            saveDomainsButton.Font = new Font("Segoe UI Variable Text", 10F);
            saveDomainsButton.Image = Properties.Resources.placeholder_25x25_dark;
            saveDomainsButton.ImageAlign = ContentAlignment.MiddleLeft;
            saveDomainsButton.Location = new Point(0, 108);
            saveDomainsButton.Name = "saveDomainsButton";
            saveDomainsButton.Padding = new Padding(5, 0, 0, 0);
            saveDomainsButton.Size = new Size(165, 36);
            saveDomainsButton.TabIndex = 6;
            saveDomainsButton.Text = "  Save domains";
            saveDomainsButton.TextImageRelation = TextImageRelation.ImageBeforeText;
            mainToolTip.SetToolTip(saveDomainsButton, "Save the current domain profile to a file for later use.");
            saveDomainsButton.UseVisualStyleBackColor = true;
            saveDomainsButton.Click += saveDomainsButton_Click;
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
            mainToolTip.SetToolTip(removeDomainButton, "Removes any currently selected domains from the list entirely.");
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
            mainToolTip.SetToolTip(addNewDomainButton, "Adds a new (blank) domain for configuration.");
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
            enableDomainButton.Text = "  Toggle active";
            enableDomainButton.TextImageRelation = TextImageRelation.ImageBeforeText;
            mainToolTip.SetToolTip(enableDomainButton, "Toggles currently selected domains for pulling.");
            enableDomainButton.UseVisualStyleBackColor = true;
            enableDomainButton.Click += enableDomainButton_Click;
            // 
            // editorPanel
            // 
            editorPanel.Controls.Add(controlContainerPanel);
            editorPanel.Controls.Add(domainEditorHeaderLabel);
            editorPanel.Dock = DockStyle.Bottom;
            editorPanel.Location = new Point(165, 420);
            editorPanel.Name = "editorPanel";
            editorPanel.Padding = new Padding(5);
            editorPanel.Size = new Size(817, 235);
            editorPanel.TabIndex = 6;
            // 
            // controlContainerPanel
            // 
            controlContainerPanel.Controls.Add(domainFieldsPanel);
            controlContainerPanel.Dock = DockStyle.Fill;
            controlContainerPanel.Location = new Point(5, 35);
            controlContainerPanel.Name = "controlContainerPanel";
            controlContainerPanel.Padding = new Padding(5);
            controlContainerPanel.Size = new Size(807, 195);
            controlContainerPanel.TabIndex = 7;
            // 
            // domainFieldsPanel
            // 
            domainFieldsPanel.AutoScroll = true;
            domainFieldsPanel.Controls.Add(xpathEditorPanel);
            domainFieldsPanel.Controls.Add(listingUrlPanel);
            domainFieldsPanel.Controls.Add(searchUrlPanel);
            domainFieldsPanel.Controls.Add(labelPanel);
            domainFieldsPanel.Dock = DockStyle.Fill;
            domainFieldsPanel.Location = new Point(5, 5);
            domainFieldsPanel.Name = "domainFieldsPanel";
            domainFieldsPanel.Size = new Size(797, 185);
            domainFieldsPanel.TabIndex = 14;
            // 
            // xpathEditorPanel
            // 
            xpathEditorPanel.AutoScroll = true;
            xpathEditorPanel.Controls.Add(xpathEditorTextBox);
            xpathEditorPanel.Controls.Add(xpathEditorContainerPanelTop);
            xpathEditorPanel.Controls.Add(xpathEditorLabel);
            xpathEditorPanel.Dock = DockStyle.Top;
            xpathEditorPanel.Location = new Point(0, 111);
            xpathEditorPanel.Name = "xpathEditorPanel";
            xpathEditorPanel.Padding = new Padding(5);
            xpathEditorPanel.Size = new Size(797, 64);
            xpathEditorPanel.TabIndex = 20;
            // 
            // xpathEditorTextBox
            // 
            xpathEditorTextBox.Dock = DockStyle.Fill;
            xpathEditorTextBox.Font = new Font("Segoe UI", 10F);
            xpathEditorTextBox.Location = new Point(172, 32);
            xpathEditorTextBox.Name = "xpathEditorTextBox";
            xpathEditorTextBox.Size = new Size(620, 25);
            xpathEditorTextBox.TabIndex = 11;
            xpathEditorTextBox.KeyUp += xpathEditorTextBox_KeyUp;
            // 
            // xpathEditorContainerPanelTop
            // 
            xpathEditorContainerPanelTop.Controls.Add(xpathEditorComboBox);
            xpathEditorContainerPanelTop.Controls.Add(xpathButtonsPanel);
            xpathEditorContainerPanelTop.Dock = DockStyle.Top;
            xpathEditorContainerPanelTop.Location = new Point(172, 5);
            xpathEditorContainerPanelTop.Name = "xpathEditorContainerPanelTop";
            xpathEditorContainerPanelTop.Size = new Size(620, 27);
            xpathEditorContainerPanelTop.TabIndex = 6;
            // 
            // xpathEditorComboBox
            // 
            xpathEditorComboBox.Dock = DockStyle.Fill;
            xpathEditorComboBox.Font = new Font("Segoe UI", 10F);
            xpathEditorComboBox.FormattingEnabled = true;
            xpathEditorComboBox.Location = new Point(0, 0);
            xpathEditorComboBox.Name = "xpathEditorComboBox";
            xpathEditorComboBox.Size = new Size(465, 25);
            xpathEditorComboBox.TabIndex = 11;
            xpathEditorComboBox.SelectedIndexChanged += xpathEditorComboBox_SelectedIndexChanged;
            // 
            // xpathButtonsPanel
            // 
            xpathButtonsPanel.Controls.Add(deleteXpathButton);
            xpathButtonsPanel.Controls.Add(addNewXpathButton);
            xpathButtonsPanel.Dock = DockStyle.Right;
            xpathButtonsPanel.Location = new Point(465, 0);
            xpathButtonsPanel.Name = "xpathButtonsPanel";
            xpathButtonsPanel.Padding = new Padding(5, 0, 5, 3);
            xpathButtonsPanel.Size = new Size(155, 27);
            xpathButtonsPanel.TabIndex = 10;
            // 
            // deleteXpathButton
            // 
            deleteXpathButton.BackColor = Color.FromArgb(100, 100, 150);
            deleteXpathButton.Dock = DockStyle.Right;
            deleteXpathButton.FlatAppearance.BorderSize = 0;
            deleteXpathButton.FlatStyle = FlatStyle.Flat;
            deleteXpathButton.Font = new Font("Segoe UI", 8F);
            deleteXpathButton.ForeColor = Color.FromArgb(250, 250, 255);
            deleteXpathButton.Location = new Point(80, 0);
            deleteXpathButton.Name = "deleteXpathButton";
            deleteXpathButton.Size = new Size(70, 24);
            deleteXpathButton.TabIndex = 7;
            deleteXpathButton.Text = "Delete";
            mainToolTip.SetToolTip(deleteXpathButton, "Delete the currently selected XPath query for this domain.");
            deleteXpathButton.UseVisualStyleBackColor = false;
            deleteXpathButton.Click += deleteXpathButton_Click;
            // 
            // addNewXpathButton
            // 
            addNewXpathButton.BackColor = Color.FromArgb(100, 100, 150);
            addNewXpathButton.Dock = DockStyle.Left;
            addNewXpathButton.FlatAppearance.BorderSize = 0;
            addNewXpathButton.FlatStyle = FlatStyle.Flat;
            addNewXpathButton.Font = new Font("Segoe UI", 8F);
            addNewXpathButton.ForeColor = Color.FromArgb(250, 250, 255);
            addNewXpathButton.Location = new Point(5, 0);
            addNewXpathButton.Name = "addNewXpathButton";
            addNewXpathButton.Size = new Size(70, 24);
            addNewXpathButton.TabIndex = 6;
            addNewXpathButton.Text = "Add new";
            mainToolTip.SetToolTip(addNewXpathButton, "Add a new XPath query for this domain.");
            addNewXpathButton.UseVisualStyleBackColor = false;
            addNewXpathButton.Click += addNewXpathButton_Click;
            // 
            // xpathEditorLabel
            // 
            xpathEditorLabel.BackColor = Color.FromArgb(250, 250, 255);
            xpathEditorLabel.Dock = DockStyle.Left;
            xpathEditorLabel.Font = new Font("Segoe UI Variable Display Semib", 10F, FontStyle.Bold);
            xpathEditorLabel.ImageAlign = ContentAlignment.TopLeft;
            xpathEditorLabel.Location = new Point(5, 5);
            xpathEditorLabel.Name = "xpathEditorLabel";
            xpathEditorLabel.Padding = new Padding(5, 0, 5, 0);
            xpathEditorLabel.Size = new Size(167, 54);
            xpathEditorLabel.TabIndex = 3;
            xpathEditorLabel.Text = "Post-search XPath:";
            xpathEditorLabel.TextAlign = ContentAlignment.TopRight;
            mainToolTip.SetToolTip(xpathEditorLabel, resources.GetString("xpathEditorLabel.ToolTip"));
            // 
            // listingUrlPanel
            // 
            listingUrlPanel.AutoScroll = true;
            listingUrlPanel.Controls.Add(listingUrlTextBox);
            listingUrlPanel.Controls.Add(listingUrlLabel);
            listingUrlPanel.Dock = DockStyle.Top;
            listingUrlPanel.Location = new Point(0, 74);
            listingUrlPanel.Name = "listingUrlPanel";
            listingUrlPanel.Padding = new Padding(5);
            listingUrlPanel.Size = new Size(797, 37);
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
            listingUrlLabel.Size = new Size(167, 27);
            listingUrlLabel.TabIndex = 3;
            listingUrlLabel.Text = "Listing URL pattern:";
            listingUrlLabel.TextAlign = ContentAlignment.TopRight;
            mainToolTip.SetToolTip(listingUrlLabel, "Regex escape pattern that should be designed to match any listing link from this domain.\r\n");
            // 
            // searchUrlPanel
            // 
            searchUrlPanel.AutoScroll = true;
            searchUrlPanel.Controls.Add(searchUrlTextBox);
            searchUrlPanel.Controls.Add(searchUrlLabel);
            searchUrlPanel.Dock = DockStyle.Top;
            searchUrlPanel.Location = new Point(0, 37);
            searchUrlPanel.Name = "searchUrlPanel";
            searchUrlPanel.Padding = new Padding(5);
            searchUrlPanel.Size = new Size(797, 37);
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
            searchUrlLabel.Size = new Size(167, 27);
            searchUrlLabel.TabIndex = 3;
            searchUrlLabel.Text = "Starting URL:";
            searchUrlLabel.TextAlign = ContentAlignment.TopRight;
            mainToolTip.SetToolTip(searchUrlLabel, resources.GetString("searchUrlLabel.ToolTip"));
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
            labelPanel.Size = new Size(797, 37);
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
            labelLabel.Size = new Size(167, 27);
            labelLabel.TabIndex = 3;
            labelLabel.Text = "Domain label:";
            labelLabel.TextAlign = ContentAlignment.TopRight;
            mainToolTip.SetToolTip(labelLabel, "Identifier for this domain for your own convenience.");
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
            // domainsSaveFileDialog
            // 
            domainsSaveFileDialog.Filter = "X-Search Domain Profile Files|*.xsdp";
            domainsSaveFileDialog.InitialDirectory = "DomainProfiles";
            domainsSaveFileDialog.RestoreDirectory = true;
            domainsSaveFileDialog.Title = "Save domain profile";
            // 
            // domainsOpenFileDialog
            // 
            domainsOpenFileDialog.Filter = "X-Search Domain Profile Files|*.xsdp";
            domainsOpenFileDialog.InitialDirectory = "DomainProfiles";
            domainsOpenFileDialog.Title = "Load domain profile";
            // 
            // mainToolTip
            // 
            mainToolTip.Popup += mainToolTip_Popup;
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
            xpathEditorPanel.ResumeLayout(false);
            xpathEditorPanel.PerformLayout();
            xpathEditorContainerPanelTop.ResumeLayout(false);
            xpathButtonsPanel.ResumeLayout(false);
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
        private ToolTip errorTooltip;
        private TextBox searchUrlTextBox;
        private TextBox labelTextBox;
        private ToolTip infoToolTip;
        private Panel xpathEditorPanel;
        private Label xpathEditorLabel;
        private TextBox xpathEditorTextBox;
        private Panel xpathEditorContainerPanelTop;
        private ComboBox xpathEditorComboBox;
        private Panel xpathButtonsPanel;
        private Button deleteXpathButton;
        private Button addNewXpathButton;
        private DataGridViewCheckBoxColumn activeDataGridViewColumn;
        private DataGridViewTextBoxColumn domainLabelDataGridViewColumn;
        private DataGridViewTextBoxColumn searchUrlPatternDataGridViewColumn;
        private DataGridViewTextBoxColumn listingUrlPatternDataGridViewColumn;
        private ToolTip mainToolTip;
        internal SaveFileDialog domainsSaveFileDialog;
        internal OpenFileDialog domainsOpenFileDialog;
    }
}