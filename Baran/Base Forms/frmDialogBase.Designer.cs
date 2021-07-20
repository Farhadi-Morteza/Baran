namespace Baran.Base_Forms
{
    partial class frmDialogBase
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
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            this.grpMain = new Baran.Windows.Forms.GroupBox();
            this.btnCancel = new Baran.Windows.Forms.Button();
            this.lblLine = new Baran.Windows.Forms.Label();
            this.lblCaption = new Baran.Windows.Forms.Label();
            this.pibFormpicture = new Baran.Windows.Forms.PictureBox();
            this.btnOk = new Baran.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grpMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pibFormpicture)).BeginInit();
            this.SuspendLayout();
            // 
            // grpMain
            // 
            this.grpMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpMain.Location = new System.Drawing.Point(12, 79);
            this.grpMain.Name = "grpMain";
            this.grpMain.Size = new System.Drawing.Size(416, 148);
            this.grpMain.TabIndex = 2;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnCancel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(246, 255);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(86, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "انصراف";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // lblLine
            // 
            this.lblLine.Anchor = System.Windows.Forms.AnchorStyles.None;
            appearance2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblLine.Appearance = appearance2;
            this.lblLine.AutoSize = true;
            this.lblLine.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblLine.Location = new System.Drawing.Point(12, 59);
            this.lblLine.Name = "lblLine";
            this.lblLine.Size = new System.Drawing.Size(106, 16);
            this.lblLine.TabIndex = 3;
            this.lblLine.Text = "_______________";
            // 
            // lblCaption
            // 
            this.lblCaption.Anchor = System.Windows.Forms.AnchorStyles.Right;
            appearance1.BackColor = System.Drawing.Color.Transparent;
            appearance1.FontData.BoldAsString = "True";
            appearance1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            appearance1.TextHAlignAsString = "Right";
            this.lblCaption.Appearance = appearance1;
            this.lblCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblCaption.Location = new System.Drawing.Point(16, 47);
            this.lblCaption.Name = "lblCaption";
            this.lblCaption.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblCaption.Size = new System.Drawing.Size(331, 17);
            this.lblCaption.TabIndex = 5;
            this.lblCaption.Text = "Caption";
            // 
            // pibFormpicture
            // 
            this.pibFormpicture.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.pibFormpicture.Location = new System.Drawing.Point(353, 1);
            this.pibFormpicture.Name = "pibFormpicture";
            this.pibFormpicture.Size = new System.Drawing.Size(66, 63);
            this.pibFormpicture.TabIndex = 4;
            this.pibFormpicture.TabStop = false;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnOk.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOk.Location = new System.Drawing.Point(338, 255);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(90, 23);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "تایید";
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // frmDialogBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(441, 290);
            this.Controls.Add(this.lblCaption);
            this.Controls.Add(this.pibFormpicture);
            this.Controls.Add(this.lblLine);
            this.Controls.Add(this.grpMain);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Name = "frmDialogBase";
            this.Text = "frmDialogBase";
            this.Load += new System.EventHandler(this.frmDialogBase_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grpMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pibFormpicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected Baran.Windows.Forms.Button btnOk;
        protected Baran.Windows.Forms.Button btnCancel;
        protected Baran.Windows.Forms.GroupBox grpMain;
        protected Baran.Windows.Forms.Label lblLine;
        protected Baran.Windows.Forms.PictureBox pibFormpicture;
        internal Baran.Windows.Forms.Label lblCaption;


    }
}