namespace XSearch_WinForms
{
    partial class PagePreview
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PagePreview));
            previewWebView = new Microsoft.Web.WebView2.WinForms.WebView2();
            ((System.ComponentModel.ISupportInitialize)previewWebView).BeginInit();
            SuspendLayout();
            // 
            // previewWebView
            // 
            previewWebView.AllowExternalDrop = true;
            previewWebView.CreationProperties = null;
            previewWebView.DefaultBackgroundColor = Color.White;
            previewWebView.Dock = DockStyle.Fill;
            previewWebView.Location = new Point(0, 0);
            previewWebView.Name = "previewWebView";
            previewWebView.Padding = new Padding(10, 0, 0, 0);
            previewWebView.Size = new Size(800, 450);
            previewWebView.TabIndex = 1;
            previewWebView.ZoomFactor = 1D;
            // 
            // PagePreview
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(previewWebView);
            DoubleBuffered = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "PagePreview";
            Text = "X-Search: Page Preview";
            ((System.ComponentModel.ISupportInitialize)previewWebView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        internal Microsoft.Web.WebView2.WinForms.WebView2 previewWebView;
    }
}