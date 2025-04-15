using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.ImageList;

namespace XSearch_WinForms
{
    /// <summary>
    /// General purpose utilities for GUI manipulation.
    /// </summary>
    internal class WinformsUIUtilities
    {
        // CONSTANTS //

        /// <summary>
        /// Native DPI of the screen WinForms was built and tested on.
        /// This is necessary because Windows Forms is not all that great at scaling things like images and text on different monitors.
        /// </summary>
        public static int NativeDPI => 96;

        /// <summary>
        /// Default hover time for tooltips.
        /// </summary>
        private static int TooltipHoverTime => 5000;

        /// <summary>
        /// Frames a form inside a panel.
        /// </summary>
        /// <param name="framePanel">The panel to frame the form in.</param>
        /// <param name="formRef">A reference to the form to be framed.</param>
        /// <param name="newForm">The form to be framed.</param>
        /// <param name="closeOriginal">Whether the original form should be closed once framed.</param>
        internal static void FrameForm(Panel framePanel, ref Form formRef, Form newForm, bool closeOriginal = false)
        {
            // If formRef refers to an actual form, close or hide it depending on settings.
            if (formRef != null)
            {
                if (closeOriginal)
                {
                    formRef.Close();
                }
                else
                {
                    formRef.Hide();
                }
            }
            
            newForm.TopLevel = false;
            newForm.FormBorderStyle = FormBorderStyle.None;
            newForm.Dock = DockStyle.Fill;
            framePanel.Controls.Add(newForm);
            newForm.BringToFront();
            newForm.Show();
        }

        internal static void FramePanel(Panel framePanel, Panel newPanel)
        {
            framePanel.Controls.Clear();
            framePanel.Controls.Add(newPanel);
            newPanel.Dock = DockStyle.Fill;
            newPanel.BringToFront();
            newPanel.Show();
        }

        /// <summary>
        /// General handler for tooltips over invalid textboxes.
        /// </summary>
        internal static async void HandleTooltipsForInvalidTextBox(ToolTip errorTooltip, bool shouldShowToolTip, TextBox textbox, string? title = null, string? body = null)
        {
            if (!shouldShowToolTip)
            {
                errorTooltip.Hide(textbox);
                textbox.BackColor = MainForm.DefaultFieldEntryColor;
            }
            else
            {
                errorTooltip.ToolTipTitle = title;
                errorTooltip.Show(body, textbox, 0, (int)(-textbox.Height * 1.75), TooltipHoverTime);
                textbox.BackColor = MainForm.InvalidFieldEntryColor;
                await Task.Delay(TooltipHoverTime);
                textbox.BackColor = MainForm.DefaultFieldEntryColor;
            }
        }

        internal static void ResizeImageListForDPIChange(ImageList imageList, float uiScale)
        {
            int newWidth = (int)(imageList.ImageSize.Width * uiScale);
            int newHeight = (int)(imageList.ImageSize.Height * uiScale);

            // Must re-add images after changing ImageList size or they will not draw properly due to the Handle for the image list being recreated.

            Dictionary<string, Image> ogImages = new Dictionary<string, Image>();

            foreach (string imgKey in imageList.Images.Keys)
            {
                ogImages.Add(imgKey, imageList.Images[imgKey]);
            }

            imageList.ImageSize = new Size(newWidth, newHeight);

            imageList.Images.Clear();

            foreach (string imgKey in ogImages.Keys)
            {
                imageList.Images.Add(imgKey, ogImages[imgKey]);
            }
        }

        internal static float CalculateUIScaleFromClientDPI(Control client)
        {
            float scale = 1f;

            Graphics g = client.CreateGraphics();

            try
            {
                scale = g.DpiX / NativeDPI;
            }
            finally
            {
                g.Dispose();
            }

            return scale;
        }
    }
}
