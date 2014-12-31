// -----------------------------------------------------------------------------
// 
// Copyright (c) 2014 Matthew Stanford
// 
// The person or persons who have associated work with this document (the 
// "Dedicator" or "Certifier") hereby either (a) certifies that, to the best of 
// his knowledge, the work of authorship identified is in the public domain of 
// the country from which the work is published, or (b) hereby dedicates 
// whatever copyright the dedicators holds in the work of authorship identified 
// below (the "Work") to the public domain. A certifier, moreover, dedicates any 
// copyright interest he may have in the associated work, and for these 
// purposes, is described as a "dedicator" below.
//
// A certifier has taken reasonable steps to verify the copyright status of this 
// work. Certifier recognizes that his good faith efforts may not shield him 
// from liability if in fact the work certified is not in the public domain.
//
// Dedicator makes this dedication for the benefit of the public at large and to 
// the detriment of the Dedicator's heirs and successors. Dedicator intends this 
// dedication to be an overt act of relinquishment in perpetuity of all present 
// and future rights under copyright law, whether vested or contingent, in the 
// Work. Dedicator understands that such relinquishment of all rights includes 
// the relinquishment of all rights to enforce (by lawsuit or otherwise) those 
// copyrights in the Work.
//
// Dedicator recognizes that, once placed in the public domain, the Work may be 
// freely reproduced, distributed, transmitted, used, modified, built upon, or 
// otherwise exploited by anyone for any purpose, commercial or non-commercial, 
// and in any way, including by methods that have not yet been invented or 
// conceived.
// 
// -----------------------------------------------------------------------------
namespace Slideshow
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.SuspendLayout();
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMain";
            this.Text = "Slideshow";
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion
    }
}

