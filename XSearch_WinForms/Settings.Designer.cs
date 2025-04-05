namespace XSearch_WinForms
{
    partial class Settings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings));
            mainSettingsContainerPanel = new Panel();
            autoSavePathPanel = new Panel();
            autoSavePathTextBox = new TextBox();
            autoSavePathLabel = new Label();
            autoSaveCheckBox = new CheckBox();
            toggleTooltipsCheckBox = new CheckBox();
            headlessCheckBox = new CheckBox();
            generallSetttingsDividerLineLabel = new Label();
            generalSettingsLabel = new Label();
            mainToolTip = new ToolTip(components);
            errorToolTip = new ToolTip(components);
            mainSettingsContainerPanel.SuspendLayout();
            autoSavePathPanel.SuspendLayout();
            SuspendLayout();
            // 
            // mainSettingsContainerPanel
            // 
            mainSettingsContainerPanel.BackColor = Color.FromArgb(250, 250, 255);
            mainSettingsContainerPanel.Controls.Add(autoSavePathPanel);
            mainSettingsContainerPanel.Controls.Add(toggleTooltipsCheckBox);
            mainSettingsContainerPanel.Controls.Add(headlessCheckBox);
            mainSettingsContainerPanel.Controls.Add(generallSetttingsDividerLineLabel);
            mainSettingsContainerPanel.Controls.Add(generalSettingsLabel);
            mainSettingsContainerPanel.Dock = DockStyle.Fill;
            mainSettingsContainerPanel.Location = new Point(0, 0);
            mainSettingsContainerPanel.Name = "mainSettingsContainerPanel";
            mainSettingsContainerPanel.Size = new Size(670, 533);
            mainSettingsContainerPanel.TabIndex = 0;
            // 
            // autoSavePathPanel
            // 
            autoSavePathPanel.Controls.Add(autoSavePathTextBox);
            autoSavePathPanel.Controls.Add(autoSavePathLabel);
            autoSavePathPanel.Controls.Add(autoSaveCheckBox);
            autoSavePathPanel.Dock = DockStyle.Top;
            autoSavePathPanel.Location = new Point(0, 94);
            autoSavePathPanel.Name = "autoSavePathPanel";
            autoSavePathPanel.Size = new Size(670, 30);
            autoSavePathPanel.TabIndex = 4;
            // 
            // autoSavePathTextBox
            // 
            autoSavePathTextBox.Dock = DockStyle.Fill;
            autoSavePathTextBox.Location = new Point(292, 0);
            autoSavePathTextBox.Name = "autoSavePathTextBox";
            autoSavePathTextBox.Size = new Size(378, 27);
            autoSavePathTextBox.TabIndex = 1;
            autoSavePathTextBox.TextChanged += autoSavePathTextBox_TextChanged;
            // 
            // autoSavePathLabel
            // 
            autoSavePathLabel.Dock = DockStyle.Left;
            autoSavePathLabel.Font = new Font("Segoe UI Variable Small Semilig", 11.25F);
            autoSavePathLabel.Location = new Point(162, 0);
            autoSavePathLabel.Name = "autoSavePathLabel";
            autoSavePathLabel.Size = new Size(130, 30);
            autoSavePathLabel.TabIndex = 0;
            autoSavePathLabel.Text = "Custom path:";
            autoSavePathLabel.TextAlign = ContentAlignment.MiddleRight;
            mainToolTip.SetToolTip(autoSavePathLabel, resources.GetString("autoSavePathLabel.ToolTip"));
            // 
            // autoSaveCheckBox
            // 
            autoSaveCheckBox.AutoSize = true;
            autoSaveCheckBox.Dock = DockStyle.Left;
            autoSaveCheckBox.Font = new Font("Segoe UI Variable Small Semilig", 11.25F);
            autoSaveCheckBox.Location = new Point(0, 0);
            autoSaveCheckBox.Name = "autoSaveCheckBox";
            autoSaveCheckBox.Padding = new Padding(3);
            autoSaveCheckBox.Size = new Size(162, 30);
            autoSaveCheckBox.TabIndex = 5;
            autoSaveCheckBox.Text = "Autosave/autoload";
            mainToolTip.SetToolTip(autoSaveCheckBox, "When enabled, X-Search will periodically save your current session and domain profile information, loading whatever was last saved on startup.");
            autoSaveCheckBox.UseVisualStyleBackColor = true;
            autoSaveCheckBox.CheckedChanged += autoSaveCheckBox_CheckedChanged;
            // 
            // toggleTooltipsCheckBox
            // 
            toggleTooltipsCheckBox.AutoSize = true;
            toggleTooltipsCheckBox.Dock = DockStyle.Top;
            toggleTooltipsCheckBox.Font = new Font("Segoe UI Variable Small Semilig", 11.25F);
            toggleTooltipsCheckBox.Location = new Point(0, 64);
            toggleTooltipsCheckBox.Name = "toggleTooltipsCheckBox";
            toggleTooltipsCheckBox.Padding = new Padding(3);
            toggleTooltipsCheckBox.Size = new Size(670, 30);
            toggleTooltipsCheckBox.TabIndex = 1;
            toggleTooltipsCheckBox.Text = "Tooltips";
            mainToolTip.SetToolTip(toggleTooltipsCheckBox, "Enables or disables tooltips across the entire program.");
            toggleTooltipsCheckBox.UseVisualStyleBackColor = true;
            toggleTooltipsCheckBox.CheckedChanged += toggleTooltipsCheckBox_CheckedChanged;
            // 
            // headlessCheckBox
            // 
            headlessCheckBox.AutoSize = true;
            headlessCheckBox.Dock = DockStyle.Top;
            headlessCheckBox.Font = new Font("Segoe UI Variable Small Semilig", 11.25F);
            headlessCheckBox.Location = new Point(0, 34);
            headlessCheckBox.Name = "headlessCheckBox";
            headlessCheckBox.Padding = new Padding(3);
            headlessCheckBox.Size = new Size(670, 30);
            headlessCheckBox.TabIndex = 0;
            headlessCheckBox.Text = "Headless browsing";
            mainToolTip.SetToolTip(headlessCheckBox, resources.GetString("headlessCheckBox.ToolTip"));
            headlessCheckBox.UseVisualStyleBackColor = true;
            headlessCheckBox.CheckedChanged += headlessCheckBox_CheckedChanged;
            // 
            // generallSetttingsDividerLineLabel
            // 
            generallSetttingsDividerLineLabel.BackColor = Color.FromArgb(50, 50, 100);
            generallSetttingsDividerLineLabel.Dock = DockStyle.Top;
            generallSetttingsDividerLineLabel.Location = new Point(0, 33);
            generallSetttingsDividerLineLabel.Name = "generallSetttingsDividerLineLabel";
            generallSetttingsDividerLineLabel.Size = new Size(670, 1);
            generallSetttingsDividerLineLabel.TabIndex = 2;
            // 
            // generalSettingsLabel
            // 
            generalSettingsLabel.Dock = DockStyle.Top;
            generalSettingsLabel.Font = new Font("Segoe UI Variable Text Semibold", 12F, FontStyle.Bold);
            generalSettingsLabel.Location = new Point(0, 0);
            generalSettingsLabel.Name = "generalSettingsLabel";
            generalSettingsLabel.Size = new Size(670, 33);
            generalSettingsLabel.TabIndex = 3;
            generalSettingsLabel.Text = "General settings";
            // 
            // mainToolTip
            // 
            mainToolTip.Popup += mainToolTip_Popup;
            // 
            // Settings
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.FromArgb(250, 250, 255);
            ClientSize = new Size(670, 533);
            Controls.Add(mainSettingsContainerPanel);
            DoubleBuffered = true;
            Font = new Font("Segoe UI Variable Text Semibold", 11.25F, FontStyle.Bold);
            ForeColor = Color.FromArgb(50, 50, 100);
            Name = "Settings";
            Text = "Settings";
            mainSettingsContainerPanel.ResumeLayout(false);
            mainSettingsContainerPanel.PerformLayout();
            autoSavePathPanel.ResumeLayout(false);
            autoSavePathPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Microsoft.Web.WebView2.WinForms.WebView2 webView21;
        private Panel mainSettingsContainerPanel;
        private Label generallSetttingsDividerLineLabel;
        private CheckBox toggleTooltipsCheckBox;
        private CheckBox headlessCheckBox;
        private Label generalSettingsLabel;
        private ToolTip mainToolTip;
        private Panel autoSavePathPanel;
        private TextBox autoSavePathTextBox;
        private Label autoSavePathLabel;
        private CheckBox autoSaveCheckBox;
        private ToolTip errorToolTip;
    }
}