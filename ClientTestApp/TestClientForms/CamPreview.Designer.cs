﻿namespace TestClientForms
{
    partial class CamPreview
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
            picBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)picBox).BeginInit();
            SuspendLayout();
            // 
            // picBox
            // 
            picBox.Location = new System.Drawing.Point(2, 0);
            picBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            picBox.Name = "picBox";
            picBox.Size = new System.Drawing.Size(639, 588);
            picBox.TabIndex = 0;
            picBox.TabStop = false;
            // 
            // CamPreview
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(642, 588);
            Controls.Add(picBox);
            Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            Name = "CamPreview";
            Text = "CamPreview";
            ((System.ComponentModel.ISupportInitialize)picBox).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.PictureBox picBox;
    }
}