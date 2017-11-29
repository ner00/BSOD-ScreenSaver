using System.ComponentModel;
using System.Windows.Forms;

namespace BSOD
{
    partial class BlueForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.picture = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picture)).BeginInit();
            this.SuspendLayout();
            // 
            // picture
            // 
            this.picture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picture.Image = global::BSOD.Properties.Resources.bsod;
            this.picture.Location = new System.Drawing.Point(0, 0);
            this.picture.Name = "picture";
            this.picture.Size = new System.Drawing.Size(516, 328);
            this.picture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picture.TabIndex = 1;
            this.picture.TabStop = false;
            this.picture.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BlueForm_KeyDown);
            this.picture.MouseClick += new System.Windows.Forms.MouseEventHandler(this.BlueForm_MouseClick);
            this.picture.MouseMove += new System.Windows.Forms.MouseEventHandler(this.BlueForm_MouseMove);
            // 
            // BlueForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(516, 328);
            this.Controls.Add(this.picture);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "BlueForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "BSOD";
            this.Load += new System.EventHandler(this.BlueForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BlueForm_KeyDown);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.BlueForm_MouseClick);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.BlueForm_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.picture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private PictureBox picture;
    }
}

