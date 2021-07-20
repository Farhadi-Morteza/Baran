namespace Baran.Security
{
    partial class frmLoginNew
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
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLoginNew));
            this.lblCaption = new Baran.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.btnCancel = new Baran.Windows.Forms.Button();
            this.btnOk = new Baran.Windows.Forms.Button();
            this.picUserName = new Baran.Windows.Forms.PictureBox();
            this.picPassword = new Baran.Windows.Forms.PictureBox();
            this.picShowPassword = new Baran.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picUserName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picShowPassword)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCaption
            // 
            appearance1.BackColor = System.Drawing.Color.Transparent;
            appearance1.ForeColor = System.Drawing.Color.DarkBlue;
            appearance1.TextHAlignAsString = "Center";
            appearance1.TextVAlignAsString = "Middle";
            this.lblCaption.Appearance = appearance1;
            this.lblCaption.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblCaption.Location = new System.Drawing.Point(117, 258);
            this.lblCaption.Name = "lblCaption";
            this.lblCaption.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblCaption.Size = new System.Drawing.Size(381, 36);
            this.lblCaption.TabIndex = 5;
            this.lblCaption.Text = "Mazare Novin Iranian";
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPassword.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtPassword.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtPassword.Location = new System.Drawing.Point(204, 339);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtPassword.Size = new System.Drawing.Size(205, 28);
            this.txtPassword.TabIndex = 1;
            this.txtPassword.UseSystemPasswordChar = true;
            this.txtPassword.Leave += new System.EventHandler(this.txtPassword_Leave);
            // 
            // txtUserName
            // 
            this.txtUserName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtUserName.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtUserName.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtUserName.Location = new System.Drawing.Point(204, 310);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtUserName.Size = new System.Drawing.Size(234, 28);
            this.txtUserName.TabIndex = 0;
            this.txtUserName.Leave += new System.EventHandler(this.txtUserName_Leave);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCancel.BackColor = System.Drawing.Color.OliveDrab;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.ForeColor = System.Drawing.SystemColors.Window;
            this.btnCancel.Location = new System.Drawing.Point(177, 414);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(261, 30);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnOk.BackColor = System.Drawing.Color.OliveDrab;
            this.btnOk.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnOk.FlatAppearance.BorderSize = 0;
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOk.ForeColor = System.Drawing.SystemColors.Window;
            this.btnOk.Location = new System.Drawing.Point(177, 380);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(261, 30);
            this.btnOk.TabIndex = 3;
            this.btnOk.Text = "Login";
            this.btnOk.UseVisualStyleBackColor = false;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // picUserName
            // 
            this.picUserName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.picUserName.BackColor = System.Drawing.Color.Transparent;
            this.picUserName.Location = new System.Drawing.Point(176, 310);
            this.picUserName.Name = "picUserName";
            this.picUserName.Size = new System.Drawing.Size(26, 24);
            this.picUserName.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picUserName.TabIndex = 6;
            this.picUserName.TabStop = false;
            // 
            // picPassword
            // 
            this.picPassword.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.picPassword.BackColor = System.Drawing.Color.Transparent;
            this.picPassword.Location = new System.Drawing.Point(176, 339);
            this.picPassword.Name = "picPassword";
            this.picPassword.Size = new System.Drawing.Size(26, 24);
            this.picPassword.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picPassword.TabIndex = 7;
            this.picPassword.TabStop = false;
            // 
            // picShowPassword
            // 
            this.picShowPassword.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.picShowPassword.BackColor = System.Drawing.Color.Transparent;
            this.picShowPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picShowPassword.Location = new System.Drawing.Point(412, 339);
            this.picShowPassword.Name = "picShowPassword";
            this.picShowPassword.Size = new System.Drawing.Size(26, 24);
            this.picShowPassword.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picShowPassword.TabIndex = 8;
            this.picShowPassword.TabStop = false;
            this.picShowPassword.Click += new System.EventHandler(this.picShowPassword_Click);
            // 
            // frmLoginNew
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(611, 533);
            this.Controls.Add(this.picShowPassword);
            this.Controls.Add(this.lblCaption);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.picUserName);
            this.Controls.Add(this.picPassword);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLoginNew";
            this.RightToLeftLayout = true;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.frmLoginNew_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picUserName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picShowPassword)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Windows.Forms.Button btnOk;
        private Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtPassword;
        public System.Windows.Forms.TextBox txtUserName;
        private Windows.Forms.Label lblCaption;
        private Windows.Forms.PictureBox picUserName;
        private Windows.Forms.PictureBox picPassword;
        private Windows.Forms.PictureBox picShowPassword;
    }
}