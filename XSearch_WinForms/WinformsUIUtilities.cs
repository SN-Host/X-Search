using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XSearch_WinForms
{
    /// <summary>
    /// General purpose utilities for GUI manipulation.
    /// </summary>
    internal class WinformsUIUtilities
    {
        // CONSTANTS //

        /// <summary>
        /// Default hover time for tooltips.
        /// </summary>
        private static int TOOLTIP_HOVERTIME = 5000;

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
                errorTooltip.Show(body, textbox, 0, (int)(-textbox.Height * 1.75), TOOLTIP_HOVERTIME);
                textbox.BackColor = MainForm.InvalidFieldEntryColor;
                await Task.Delay(TOOLTIP_HOVERTIME);
                textbox.BackColor = MainForm.DefaultFieldEntryColor;
            }
        }
    }
}
