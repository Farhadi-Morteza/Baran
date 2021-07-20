namespace Baran.Common
{
    partial class frmPackage
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
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            this.grbItems = new Baran.Windows.Forms.GroupBox();
            this.btnShowPic = new Baran.Windows.Forms.Button();
            this.picPackage = new Baran.Windows.Forms.PictureBox();
            this.lblName = new Baran.Windows.Forms.Label();
            this.txtPackageName = new Baran.Windows.Forms.TextBox();
            this.lblOrder = new Baran.Windows.Forms.Label();
            this.txtPackageOrder = new Baran.Windows.Forms.TextBox();
            this.grbButton = new Baran.Windows.Forms.GroupBox();
            this.btnSave = new Baran.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grpMain)).BeginInit();
            this.grpMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grbItems)).BeginInit();
            this.grbItems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPackage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grbButton)).BeginInit();
            this.grbButton.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblCaption
            // 
            this.lblCaption.Location = new System.Drawing.Point(259, 23);
            // 
            // grpMain
            // 
            this.grpMain.Controls.Add(this.grbButton);
            this.grpMain.Controls.Add(this.grbItems);
            this.grpMain.Size = new System.Drawing.Size(611, 297);
            // 
            // grpHeader
            // 
            this.grpHeader.Size = new System.Drawing.Size(611, 65);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(545, 3);
            // 
            // grbItems
            // 
            this.grbItems.Controls.Add(this.lblOrder);
            this.grbItems.Controls.Add(this.txtPackageOrder);
            this.grbItems.Controls.Add(this.lblName);
            this.grbItems.Controls.Add(this.txtPackageName);
            this.grbItems.Controls.Add(this.btnShowPic);
            this.grbItems.Controls.Add(this.picPackage);
            this.grbItems.Dock = System.Windows.Forms.DockStyle.Top;
            this.grbItems.Location = new System.Drawing.Point(3, 0);
            this.grbItems.Name = "grbItems";
            this.grbItems.Size = new System.Drawing.Size(605, 193);
            this.grbItems.TabIndex = 0;
            // 
            // btnShowPic
            // 
            this.btnShowPic.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnShowPic.Location = new System.Drawing.Point(222, 115);
            this.btnShowPic.Name = "btnShowPic";
            this.btnShowPic.Size = new System.Drawing.Size(76, 24);
            this.btnShowPic.TabIndex = 3;
            this.btnShowPic.Text = "نمایش";
            this.btnShowPic.UseVisualStyleBackColor = true;
            this.btnShowPic.Click += new System.EventHandler(this.btnShowPic_Click);
            // 
            // picPackage
            // 
            this.picPackage.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.picPackage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picPackage.Location = new System.Drawing.Point(222, 34);
            this.picPackage.Name = "picPackage";
            this.picPackage.Size = new System.Drawing.Size(76, 75);
            this.picPackage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picPackage.TabIndex = 2;
            this.picPackage.TabStop = false;
            // 
            // lblName
            // 
            appearance7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            appearance7.TextHAlignAsString = "Right";
            appearance7.TextVAlignAsString = "Middle";
            this.lblName.Appearance = appearance7;
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblName.Location = new System.Drawing.Point(543, 37);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(27, 16);
            this.lblName.TabIndex = 10;
            this.lblName.Text = ": نام";
            // 
            // txtPackageName
            // 
            this.txtPackageName.Location = new System.Drawing.Point(326, 34);
            this.txtPackageName.Name = "txtPackageName";
            this.txtPackageName.PreviousBackColor = System.Drawing.Color.Empty;
            this.txtPackageName.PreviousForeColor = System.Drawing.Color.Empty;
            this.txtPackageName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtPackageName.Size = new System.Drawing.Size(197, 21);
            this.txtPackageName.TabIndex = 9;
            this.txtPackageName.UnformattedText = null;
            // 
            // lblOrder
            // 
            appearance5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            appearance5.TextHAlignAsString = "Right";
            appearance5.TextVAlignAsString = "Middle";
            this.lblOrder.Appearance = appearance5;
            this.lblOrder.AutoSize = true;
            this.lblOrder.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblOrder.Location = new System.Drawing.Point(529, 64);
            this.lblOrder.Name = "lblOrder";
            this.lblOrder.Size = new System.Drawing.Size(41, 16);
            this.lblOrder.TabIndex = 12;
            this.lblOrder.Text = ": ترتیب";
            // 
            // txtPackageOrder
            // 
            this.txtPackageOrder.InputType = Baran.Windows.Forms.InputType.Numeric;
            this.txtPackageOrder.Location = new System.Drawing.Point(326, 61);
            this.txtPackageOrder.Name = "txtPackageOrder";
            this.txtPackageOrder.PreviousBackColor = System.Drawing.Color.Empty;
            this.txtPackageOrder.PreviousForeColor = System.Drawing.Color.Empty;
            this.txtPackageOrder.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtPackageOrder.Size = new System.Drawing.Size(197, 21);
            this.txtPackageOrder.TabIndex = 11;
            this.txtPackageOrder.UnformattedText = null;
            // 
            // grbButton
            // 
            this.grbButton.Controls.Add(this.btnSave);
            this.grbButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grbButton.Location = new System.Drawing.Point(3, 231);
            this.grbButton.Name = "grbButton";
            this.grbButton.Size = new System.Drawing.Size(605, 63);
            this.grbButton.TabIndex = 1;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(457, 13);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(113, 32);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "ثبت";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frmPackage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(611, 362);
            this.Name = "frmPackage";
            ((System.ComponentModel.ISupportInitialize)(this.grpMain)).EndInit();
            this.grpMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grbItems)).EndInit();
            this.grbItems.ResumeLayout(false);
            this.grbItems.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPackage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grbButton)).EndInit();
            this.grbButton.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Baran.Windows.Forms.GroupBox grbItems;
        private Baran.Windows.Forms.Button btnShowPic;
        private Baran.Windows.Forms.PictureBox picPackage;
        private Baran.Windows.Forms.Label lblName;
        private Baran.Windows.Forms.TextBox txtPackageName;
        private Baran.Windows.Forms.Label lblOrder;
        private Baran.Windows.Forms.TextBox txtPackageOrder;
        private Baran.Windows.Forms.GroupBox grbButton;
        private Baran.Windows.Forms.Button btnSave;
    }
}
