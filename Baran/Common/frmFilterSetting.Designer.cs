namespace Baran.Common
{
    partial class frmFilterSetting
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
            this.btnShowPic = new Baran.Windows.Forms.Button();
            this.picShop = new Baran.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picShop)).BeginInit();
            this.SuspendLayout();
            // 
            // grpMain
            // 
            this.grpMain.Controls.Add(this.btnShowPic);
            this.grpMain.Controls.Add(this.picShop);
            // 
            // btnShowPic
            // 
            this.btnShowPic.Location = new System.Drawing.Point(49, 185);
            this.btnShowPic.Name = "btnShowPic";
            this.btnShowPic.Size = new System.Drawing.Size(94, 34);
            this.btnShowPic.TabIndex = 3;
            this.btnShowPic.Text = "نمایش";
            this.btnShowPic.UseVisualStyleBackColor = true;
            this.btnShowPic.Click += new System.EventHandler(this.btnShowPic_Click);
            // 
            // picShop
            // 
            this.picShop.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picShop.Location = new System.Drawing.Point(26, 15);
            this.picShop.Name = "picShop";
            this.picShop.Size = new System.Drawing.Size(135, 156);
            this.picShop.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picShop.TabIndex = 2;
            this.picShop.TabStop = false;
            // 
            // frmFilterSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(668, 494);
            this.Name = "frmFilterSetting";
            ((System.ComponentModel.ISupportInitialize)(this.grpMain)).EndInit();
            this.grpMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picShop)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Windows.Forms.Button btnShowPic;
        private Windows.Forms.PictureBox picShop;
    }
}
