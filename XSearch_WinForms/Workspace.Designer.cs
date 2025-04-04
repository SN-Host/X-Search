namespace XSearch_WinForms
{
    partial class Workspace
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Workspace));
            dataGridViewPanel = new Panel();
            mainDataGridView = new DataGridView();
            statusDataGridViewColumn = new DataGridViewImageColumn();
            domainDataGridViewColumn = new DataGridViewTextBoxColumn();
            titleDataGridViewColumn = new DataGridViewTextBoxColumn();
            urlDataGridViewColumn = new DataGridViewTextBoxColumn();
            RetrievalTimeString = new DataGridViewTextBoxColumn();
            searchPanel = new Panel();
            searchTextBox = new TextBox();
            statusImages = new ImageList(components);
            controlPanel = new Panel();
            loadSessionButton = new Button();
            saveSessionButton = new Button();
            clearAllButton = new Button();
            clearListingButton = new Button();
            webPreviewButton = new Button();
            uncrossButton = new Button();
            crossButton = new Button();
            cancelPullButton = new Button();
            pullSearchButton = new Button();
            sessionOpenFileDialog = new OpenFileDialog();
            sessionSaveFileDialog = new SaveFileDialog();
            dataGridViewPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)mainDataGridView).BeginInit();
            searchPanel.SuspendLayout();
            controlPanel.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridViewPanel
            // 
            dataGridViewPanel.Controls.Add(mainDataGridView);
            dataGridViewPanel.Controls.Add(searchPanel);
            dataGridViewPanel.Dock = DockStyle.Fill;
            dataGridViewPanel.ForeColor = Color.FromArgb(50, 50, 60);
            dataGridViewPanel.Location = new Point(165, 0);
            dataGridViewPanel.Name = "dataGridViewPanel";
            dataGridViewPanel.Padding = new Padding(10, 0, 10, 10);
            dataGridViewPanel.Size = new Size(619, 361);
            dataGridViewPanel.TabIndex = 3;
            // 
            // mainDataGridView
            // 
            mainDataGridView.AllowUserToAddRows = false;
            mainDataGridView.AllowUserToOrderColumns = true;
            mainDataGridView.AllowUserToResizeRows = false;
            mainDataGridView.BackgroundColor = Color.FromArgb(180, 180, 210);
            mainDataGridView.BorderStyle = BorderStyle.None;
            mainDataGridView.CellBorderStyle = DataGridViewCellBorderStyle.Sunken;
            mainDataGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(240, 240, 250);
            dataGridViewCellStyle1.Font = new Font("Segoe UI Variable Text Semibold", 11.25F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(50, 50, 80);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(100, 100, 180);
            dataGridViewCellStyle1.SelectionForeColor = Color.White;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            mainDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            mainDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            mainDataGridView.Columns.AddRange(new DataGridViewColumn[] { statusDataGridViewColumn, domainDataGridViewColumn, titleDataGridViewColumn, urlDataGridViewColumn, RetrievalTimeString });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(230, 230, 245);
            dataGridViewCellStyle2.Font = new Font("Segoe UI Variable Text Semibold", 11.25F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(50, 50, 60);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(100, 100, 180);
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            mainDataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            mainDataGridView.Dock = DockStyle.Fill;
            mainDataGridView.Location = new Point(10, 39);
            mainDataGridView.Name = "mainDataGridView";
            mainDataGridView.ReadOnly = true;
            mainDataGridView.RowHeadersVisible = false;
            mainDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            mainDataGridView.ShowCellErrors = false;
            mainDataGridView.ShowRowErrors = false;
            mainDataGridView.Size = new Size(599, 312);
            mainDataGridView.TabIndex = 2;
            mainDataGridView.VirtualMode = true;
            mainDataGridView.CellContentClick += mainDataGridView_CellContentClick;
            mainDataGridView.CellFormatting += mainDataGridView_CellFormatting;
            mainDataGridView.CellValueNeeded += mainDataGridView_CellValueNeeded;
            mainDataGridView.SelectionChanged += mainDataGridView_SelectionChanged;
            // 
            // statusDataGridViewColumn
            // 
            statusDataGridViewColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            statusDataGridViewColumn.DataPropertyName = "StatusImage";
            statusDataGridViewColumn.FillWeight = 20F;
            statusDataGridViewColumn.HeaderText = "Status";
            statusDataGridViewColumn.Name = "statusDataGridViewColumn";
            statusDataGridViewColumn.ReadOnly = true;
            statusDataGridViewColumn.Resizable = DataGridViewTriState.True;
            statusDataGridViewColumn.SortMode = DataGridViewColumnSortMode.Automatic;
            statusDataGridViewColumn.Width = 75;
            // 
            // domainDataGridViewColumn
            // 
            domainDataGridViewColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            domainDataGridViewColumn.DataPropertyName = "DomainName";
            domainDataGridViewColumn.FillWeight = 50F;
            domainDataGridViewColumn.HeaderText = "Domain";
            domainDataGridViewColumn.Name = "domainDataGridViewColumn";
            domainDataGridViewColumn.ReadOnly = true;
            // 
            // titleDataGridViewColumn
            // 
            titleDataGridViewColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            titleDataGridViewColumn.DataPropertyName = "Title";
            titleDataGridViewColumn.HeaderText = "Title";
            titleDataGridViewColumn.Name = "titleDataGridViewColumn";
            titleDataGridViewColumn.ReadOnly = true;
            // 
            // urlDataGridViewColumn
            // 
            urlDataGridViewColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            urlDataGridViewColumn.DataPropertyName = "Url";
            urlDataGridViewColumn.HeaderText = "URL";
            urlDataGridViewColumn.Name = "urlDataGridViewColumn";
            urlDataGridViewColumn.ReadOnly = true;
            // 
            // RetrievalTimeString
            // 
            RetrievalTimeString.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            RetrievalTimeString.DataPropertyName = "RetrievalTimeString";
            RetrievalTimeString.HeaderText = "Pulled on";
            RetrievalTimeString.Name = "RetrievalTimeString";
            RetrievalTimeString.ReadOnly = true;
            // 
            // searchPanel
            // 
            searchPanel.Controls.Add(searchTextBox);
            searchPanel.Dock = DockStyle.Top;
            searchPanel.Location = new Point(10, 0);
            searchPanel.Name = "searchPanel";
            searchPanel.Padding = new Padding(5);
            searchPanel.Size = new Size(599, 39);
            searchPanel.TabIndex = 3;
            // 
            // searchTextBox
            // 
            searchTextBox.Dock = DockStyle.Fill;
            searchTextBox.Location = new Point(5, 5);
            searchTextBox.Name = "searchTextBox";
            searchTextBox.Size = new Size(589, 27);
            searchTextBox.TabIndex = 0;
            searchTextBox.KeyUp += searchTextBox_KeyUp;
            // 
            // statusImages
            // 
            statusImages.ColorDepth = ColorDepth.Depth32Bit;
            statusImages.ImageStream = (ImageListStreamer)resources.GetObject("statusImages.ImageStream");
            statusImages.TransparentColor = Color.Transparent;
            statusImages.Images.SetKeyName(0, "O.png");
            statusImages.Images.SetKeyName(1, "X.png");
            // 
            // controlPanel
            // 
            controlPanel.AutoScroll = true;
            controlPanel.Controls.Add(loadSessionButton);
            controlPanel.Controls.Add(saveSessionButton);
            controlPanel.Controls.Add(clearAllButton);
            controlPanel.Controls.Add(clearListingButton);
            controlPanel.Controls.Add(webPreviewButton);
            controlPanel.Controls.Add(uncrossButton);
            controlPanel.Controls.Add(crossButton);
            controlPanel.Controls.Add(cancelPullButton);
            controlPanel.Controls.Add(pullSearchButton);
            controlPanel.Dock = DockStyle.Left;
            controlPanel.Location = new Point(0, 0);
            controlPanel.Margin = new Padding(0);
            controlPanel.Name = "controlPanel";
            controlPanel.Size = new Size(165, 361);
            controlPanel.TabIndex = 2;
            controlPanel.Visible = false;
            // 
            // loadSessionButton
            // 
            loadSessionButton.Dock = DockStyle.Top;
            loadSessionButton.FlatAppearance.BorderSize = 0;
            loadSessionButton.FlatStyle = FlatStyle.Flat;
            loadSessionButton.Font = new Font("Segoe UI Variable Text", 10F);
            loadSessionButton.Image = Properties.Resources.placeholder_25x25_dark;
            loadSessionButton.ImageAlign = ContentAlignment.MiddleLeft;
            loadSessionButton.Location = new Point(0, 288);
            loadSessionButton.Name = "loadSessionButton";
            loadSessionButton.Padding = new Padding(5, 0, 0, 0);
            loadSessionButton.Size = new Size(165, 36);
            loadSessionButton.TabIndex = 9;
            loadSessionButton.Text = "  Load session";
            loadSessionButton.TextImageRelation = TextImageRelation.ImageBeforeText;
            loadSessionButton.UseVisualStyleBackColor = true;
            loadSessionButton.Click += loadSessionButton_Click;
            // 
            // saveSessionButton
            // 
            saveSessionButton.Dock = DockStyle.Top;
            saveSessionButton.FlatAppearance.BorderSize = 0;
            saveSessionButton.FlatStyle = FlatStyle.Flat;
            saveSessionButton.Font = new Font("Segoe UI Variable Text", 10F);
            saveSessionButton.Image = Properties.Resources.placeholder_25x25_dark;
            saveSessionButton.ImageAlign = ContentAlignment.MiddleLeft;
            saveSessionButton.Location = new Point(0, 252);
            saveSessionButton.Name = "saveSessionButton";
            saveSessionButton.Padding = new Padding(5, 0, 0, 0);
            saveSessionButton.Size = new Size(165, 36);
            saveSessionButton.TabIndex = 8;
            saveSessionButton.Text = "  Save session";
            saveSessionButton.TextImageRelation = TextImageRelation.ImageBeforeText;
            saveSessionButton.UseVisualStyleBackColor = true;
            saveSessionButton.Click += saveSessionButton_Click;
            // 
            // clearAllButton
            // 
            clearAllButton.Dock = DockStyle.Top;
            clearAllButton.FlatAppearance.BorderSize = 0;
            clearAllButton.FlatStyle = FlatStyle.Flat;
            clearAllButton.Font = new Font("Segoe UI Variable Text", 10F);
            clearAllButton.Image = Properties.Resources.placeholder_25x25_dark;
            clearAllButton.ImageAlign = ContentAlignment.MiddleLeft;
            clearAllButton.Location = new Point(0, 216);
            clearAllButton.Name = "clearAllButton";
            clearAllButton.Padding = new Padding(5, 0, 0, 0);
            clearAllButton.Size = new Size(165, 36);
            clearAllButton.TabIndex = 7;
            clearAllButton.Text = "  Clear all listings";
            clearAllButton.TextImageRelation = TextImageRelation.ImageBeforeText;
            clearAllButton.UseVisualStyleBackColor = true;
            clearAllButton.Click += clearAllButton_Click;
            // 
            // clearListingButton
            // 
            clearListingButton.Dock = DockStyle.Top;
            clearListingButton.FlatAppearance.BorderSize = 0;
            clearListingButton.FlatStyle = FlatStyle.Flat;
            clearListingButton.Font = new Font("Segoe UI Variable Text", 10F);
            clearListingButton.Image = Properties.Resources.placeholder_25x25_dark;
            clearListingButton.ImageAlign = ContentAlignment.MiddleLeft;
            clearListingButton.Location = new Point(0, 180);
            clearListingButton.Name = "clearListingButton";
            clearListingButton.Padding = new Padding(5, 0, 0, 0);
            clearListingButton.Size = new Size(165, 36);
            clearListingButton.TabIndex = 11;
            clearListingButton.Text = "  Clear listing";
            clearListingButton.TextImageRelation = TextImageRelation.ImageBeforeText;
            clearListingButton.UseVisualStyleBackColor = true;
            clearListingButton.Click += clearListingButton_Click;
            // 
            // webPreviewButton
            // 
            webPreviewButton.Dock = DockStyle.Top;
            webPreviewButton.FlatAppearance.BorderSize = 0;
            webPreviewButton.FlatStyle = FlatStyle.Flat;
            webPreviewButton.Font = new Font("Segoe UI Variable Text", 10F);
            webPreviewButton.Image = Properties.Resources.placeholder_25x25_dark;
            webPreviewButton.ImageAlign = ContentAlignment.MiddleLeft;
            webPreviewButton.Location = new Point(0, 144);
            webPreviewButton.Name = "webPreviewButton";
            webPreviewButton.Padding = new Padding(5, 0, 0, 0);
            webPreviewButton.Size = new Size(165, 36);
            webPreviewButton.TabIndex = 4;
            webPreviewButton.Text = "  Web preview";
            webPreviewButton.TextImageRelation = TextImageRelation.ImageBeforeText;
            webPreviewButton.UseVisualStyleBackColor = true;
            webPreviewButton.Click += webPreviewButton_Click;
            // 
            // uncrossButton
            // 
            uncrossButton.Dock = DockStyle.Top;
            uncrossButton.FlatAppearance.BorderSize = 0;
            uncrossButton.FlatStyle = FlatStyle.Flat;
            uncrossButton.Font = new Font("Segoe UI Variable Text", 10F);
            uncrossButton.Image = Properties.Resources.placeholder_25x25_dark;
            uncrossButton.ImageAlign = ContentAlignment.MiddleLeft;
            uncrossButton.Location = new Point(0, 108);
            uncrossButton.Name = "uncrossButton";
            uncrossButton.Padding = new Padding(5, 0, 0, 0);
            uncrossButton.Size = new Size(165, 36);
            uncrossButton.TabIndex = 6;
            uncrossButton.Text = "  Uncross";
            uncrossButton.TextImageRelation = TextImageRelation.ImageBeforeText;
            uncrossButton.UseVisualStyleBackColor = true;
            uncrossButton.Click += uncrossButton_Click;
            // 
            // crossButton
            // 
            crossButton.Dock = DockStyle.Top;
            crossButton.FlatAppearance.BorderSize = 0;
            crossButton.FlatStyle = FlatStyle.Flat;
            crossButton.Font = new Font("Segoe UI Variable Text", 10F);
            crossButton.Image = Properties.Resources.placeholder_25x25_dark;
            crossButton.ImageAlign = ContentAlignment.MiddleLeft;
            crossButton.Location = new Point(0, 72);
            crossButton.Name = "crossButton";
            crossButton.Padding = new Padding(5, 0, 0, 0);
            crossButton.Size = new Size(165, 36);
            crossButton.TabIndex = 5;
            crossButton.Text = "  Cross";
            crossButton.TextImageRelation = TextImageRelation.ImageBeforeText;
            crossButton.UseVisualStyleBackColor = true;
            crossButton.Click += crossButton_Click;
            // 
            // cancelPullButton
            // 
            cancelPullButton.Dock = DockStyle.Top;
            cancelPullButton.FlatAppearance.BorderSize = 0;
            cancelPullButton.FlatStyle = FlatStyle.Flat;
            cancelPullButton.Font = new Font("Segoe UI Variable Text", 10F);
            cancelPullButton.Image = Properties.Resources.placeholder_25x25_dark;
            cancelPullButton.ImageAlign = ContentAlignment.MiddleLeft;
            cancelPullButton.Location = new Point(0, 36);
            cancelPullButton.Name = "cancelPullButton";
            cancelPullButton.Padding = new Padding(5, 0, 0, 0);
            cancelPullButton.Size = new Size(165, 36);
            cancelPullButton.TabIndex = 12;
            cancelPullButton.Text = "  Cancel pull";
            cancelPullButton.TextImageRelation = TextImageRelation.ImageBeforeText;
            cancelPullButton.UseVisualStyleBackColor = true;
            cancelPullButton.Click += cancelPullButton_Click;
            // 
            // pullSearchButton
            // 
            pullSearchButton.Dock = DockStyle.Top;
            pullSearchButton.FlatAppearance.BorderSize = 0;
            pullSearchButton.FlatStyle = FlatStyle.Flat;
            pullSearchButton.Font = new Font("Segoe UI Variable Text", 10F);
            pullSearchButton.Image = Properties.Resources.placeholder_25x25_dark;
            pullSearchButton.ImageAlign = ContentAlignment.MiddleLeft;
            pullSearchButton.Location = new Point(0, 0);
            pullSearchButton.Name = "pullSearchButton";
            pullSearchButton.Padding = new Padding(5, 0, 0, 0);
            pullSearchButton.Size = new Size(165, 36);
            pullSearchButton.TabIndex = 10;
            pullSearchButton.Text = "  Pull search";
            pullSearchButton.TextImageRelation = TextImageRelation.ImageBeforeText;
            pullSearchButton.UseVisualStyleBackColor = true;
            pullSearchButton.Click += pullSearchButton_Click;
            // 
            // sessionOpenFileDialog
            // 
            sessionOpenFileDialog.Filter = "X-Search Session Files|*.xssp";
            sessionOpenFileDialog.InitialDirectory = "Sessions";
            sessionOpenFileDialog.Title = "Load session";
            // 
            // sessionSaveFileDialog
            // 
            sessionSaveFileDialog.Filter = "X-Search Session Files|*.xssp";
            sessionSaveFileDialog.InitialDirectory = "Sessions";
            sessionSaveFileDialog.Title = "Save session";
            // 
            // Workspace
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.FromArgb(250, 250, 255);
            ClientSize = new Size(784, 361);
            Controls.Add(dataGridViewPanel);
            Controls.Add(controlPanel);
            DoubleBuffered = true;
            Font = new Font("Segoe UI Variable Text Semibold", 11.25F, FontStyle.Bold);
            ForeColor = Color.FromArgb(50, 50, 100);
            Name = "Workspace";
            Text = "Workspace";
            dataGridViewPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)mainDataGridView).EndInit();
            searchPanel.ResumeLayout(false);
            searchPanel.PerformLayout();
            controlPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Panel dataGridViewPanel;
        private ImageList statusImages;
        private Microsoft.Web.WebView2.WinForms.WebView2 webView21;
        private DataGridView mainDataGridView;
        internal Panel controlPanel;
        private Button webPreviewButton;
        private Button crossButton;
        private Button uncrossButton;
        private Button clearAllButton;
        private Button saveSessionButton;
        private Button loadSessionButton;
        private Button pullSearchButton;
        private Button clearListingButton;
        private Panel searchPanel;
        private TextBox searchTextBox;
        private Button cancelPullButton;
        private OpenFileDialog sessionOpenFileDialog;
        private SaveFileDialog sessionSaveFileDialog;
        private DataGridViewImageColumn statusDataGridViewColumn;
        private DataGridViewTextBoxColumn domainDataGridViewColumn;
        private DataGridViewTextBoxColumn titleDataGridViewColumn;
        private DataGridViewTextBoxColumn urlDataGridViewColumn;
        private DataGridViewTextBoxColumn RetrievalTimeString;
    }
}