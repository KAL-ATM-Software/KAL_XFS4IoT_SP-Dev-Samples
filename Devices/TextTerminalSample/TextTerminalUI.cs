/***********************************************************************************************\
 * (C) KAL ATM Software GmbH, 2021
 * KAL ATM Software GmbH licenses this file to you under the MIT license.
 * See the LICENSE file in the project root for more information.
\***********************************************************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextTerminalSample
{
    public partial class TextTerminalUI : Form
    {
        public TextTerminalUI()
        {
            InitializeComponent();

            ClearTextBox();
        }

        // Object used to lock access to private variables.
        private object propertyLock = new();

        // Lines on the display.
        private char[][] formLines;
        // Current cursor position.
        private int CurrentX = 0, CurrentY = 0;
        // Current display resolution.
        private int CurrentWidth = 32, CurrentHeight = 16;
        // If we are expecting KeyPress on the channel.
        private bool ReadingText = false;

        public int GetCurrentX()
        {
            lock (propertyLock)
            {
                return CurrentX;
            }
        }
        public int GetCurrentY()
        {

            lock (propertyLock)
            {
                return CurrentY;
            }
        }
        public int GetCurrentWidth()
        {

            lock (propertyLock)
            {
                return CurrentWidth;
            }
        }
        public int GetCurrentHeight()
        {

            lock (propertyLock)
            {
                return CurrentHeight;
            }
        }

        public void SetResolution(int width, int height)
        {
            lock (propertyLock)
            {
                CurrentWidth = width;
                CurrentHeight = height;
            }
            formLines = null;
            ClearTextBox();
        }

        public void SetReading(bool val)
        {
            lock (propertyLock)
            {
                ReadingText = val;
            }
        }
        public bool GetReading()
        {
            lock (propertyLock)
            {
                return ReadingText;
            }
        }

        /// <summary>
        /// Scroll the text on the display.
        /// </summary>
        public void ScrollTextBox()
        {
            lock (propertyLock)
            {
                for(int i = 1; i < formLines.Length; i++)
                {
                    Array.Copy(formLines[i], formLines[i - 1], CurrentWidth);
                }
                for (int i = 0; i < CurrentWidth; i++)
                    formLines[^1][i] = ' ';
            }
            UpdateTextBox();
        }

        /// <summary>
        /// Called on key button press.
        /// </summary>
        private async void KEYBtn_Click(object sender, EventArgs e)
        {
            if (sender is not Button btn) return;
            var key = btn.Text;
            if (string.IsNullOrWhiteSpace(key)) return;

            if (btn.Name.Contains("FDK"))
                key = btn.Name.Replace("FDK", "ckFDK0").Replace("Btn", ""); //CkFDK01

            if (GetReading())
            {
                await TextTerminalSample.readPressChannel.Writer.WriteAsync(key);
            }
        }

        /// <summary>
        /// Clear the text box and setup the form lines.
        /// </summary>
        private void ClearTextBox()
        {
            lock (propertyLock)
            {
                if (formLines is null)
                    formLines = new char[CurrentHeight][];
                for (int i = 0; i < formLines.Length; i++)
                {
                    formLines[i] = new char[CurrentWidth];
                    for (int x = 0; x < CurrentWidth; x++)
                        formLines[i][x] = ' ';
                }
            }
            UpdateTextBox();
        }

        /// <summary>
        /// Clear the specified area on the display.
        /// </summary>
        public void ClearArea(int x, int y, int width, int height)
        {
            lock (propertyLock)
            {
                for (int i = 0; i < height; i++)
                {
                    for (int j = 0; j < width; j++)
                    {
                        formLines[i + y][j + x] = ' ';
                    }
                }
                //Set cursor to top left of cleared area.
                CurrentX = x;
                CurrentY = y;
            }
            UpdateTextBox();
        }

        /// <summary>
        /// Write the text at the specified position.
        /// </summary>
        public void WriteAt(int x, int y, string text)
        {
            lock (propertyLock)
            {
                for (int i = 0; i < text.Length; i++)
                    formLines[y][x + i] = text[i];

                CurrentX = x + text.Length;
                CurrentY = y;
                if (CurrentX == CurrentWidth)
                {
                    CurrentX = 0;
                    ++CurrentY;
                }
                if (CurrentY >= CurrentHeight)
                {
                    CurrentY = 0;
                    CurrentX = 0;
                }
            }
            UpdateTextBox();
        }

        /// <summary>
        /// Update the text box based on the formLines.
        /// </summary>
        private void UpdateTextBox()
        {
            string Text;
            lock (propertyLock)
            {
                Text = string.Join(Environment.NewLine, formLines.Select(c => new string(c)));
            }

            if (this.InvokeRequired)
            {
                this.BeginInvoke(new Action(() => OperatorTextBox.Text = Text));
                return;
            }
            OperatorTextBox.Text = Text;
        }
    }
}
