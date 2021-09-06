namespace Baran.Security.User
{
    partial class frmChangePassword
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
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            this.grbChangePassword = new Baran.Windows.Forms.GroupBox();
            this.chkPasswordChar = new Baran.Windows.Forms.CheckBox.CheckBox();
            this.txtUserName = new Baran.Windows.Forms.TextBox();
            this.lblUserName = new Baran.Windows.Forms.Label();
            this.txtConfirmNewPassword = new System.Windows.Forms.TextBox();
            this.txtNewPassword = new System.Windows.Forms.TextBox();
            this.lblConfirmNewPassword = new Baran.Windows.Forms.Label();
            this.lblNewPassword = new Baran.Windows.Forms.Label();
            this.txtPreviousPassword = new System.Windows.Forms.TextBox();
            this.lblPreviousPassword = new Baran.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grpButons)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpHeader)).BeginInit();
            this.grpHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpMessage)).BeginInit();
            this.grpMessage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpMain)).BeginInit();
            this.grpMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grbChangePassword)).BeginInit();
            this.grbChangePassword.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName)).BeginInit();
            this.SuspendLayout();
            // 
            // btnMaxMin
            // 
            this.btnMaxMin.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            // 
            // grpButons
            // 
            this.grpButons.Location = new System.Drawing.Point(0, 279);
            this.grpButons.Size = new System.Drawing.Size(607, 75);
            // 
            // lblLine2
            // 
            this.lblLine2.Location = new System.Drawing.Point(1, 61);
            this.lblLine2.Size = new System.Drawing.Size(605, 3);
            // 
            // grpHeader
            // 
            this.grpHeader.Size = new System.Drawing.Size(607, 65);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(551, 9);
            this.pictureBox1.Size = new System.Drawing.Size(50, 49);
            // 
            // lblCaption
            // 
            this.lblCaption.Location = new System.Drawing.Point(324, 30);
            this.lblCaption.Size = new System.Drawing.Size(221, 16);
            // 
            // lblMessage
            // 
            this.lblMessage.Text = "";
            // 
            // lblLine1
            // 
            this.lblLine1.Size = new System.Drawing.Size(605, 3);
            // 
            // grpMessage
            // 
            this.grpMessage.Location = new System.Drawing.Point(0, 65);
            this.grpMessage.Size = new System.Drawing.Size(607, 30);
            // 
            // lblLine3
            // 
            this.lblLine3.Location = new System.Drawing.Point(1, 180);
            this.lblLine3.Size = new System.Drawing.Size(605, 3);
            // 
            // grpMain
            // 
            this.grpMain.Controls.Add(this.grbChangePassword);
            this.grpMain.Location = new System.Drawing.Point(0, 95);
            this.grpMain.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpMain.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpMain.Size = new System.Drawing.Size(607, 184);
            this.grpMain.Controls.SetChildIndex(this.grbChangePassword, 0);
            this.grpMain.Controls.SetChildIndex(this.lblLine3, 0);
            // 
            // grbChangePassword
            // 
            this.grbChangePassword.BorderStyle = Infragistics.Win.Misc.GroupBoxBorderStyle.None;
            this.grbChangePassword.Controls.Add(this.chkPasswordChar);
            this.grbChangePassword.Controls.Add(this.txtUserName);
            this.grbChangePassword.Controls.Add(this.lblUserName);
            this.grbChangePassword.Controls.Add(this.txtConfirmNewPassword);
            this.grbChangePassword.Controls.Add(this.txtNewPassword);
            this.grbChangePassword.Controls.Add(this.lblConfirmNewPassword);
            this.grbChangePassword.Controls.Add(this.lblNewPassword);
            this.grbChangePassword.Controls.Add(this.txtPreviousPassword);
            this.grbChangePassword.Controls.Add(this.lblPreviousPassword);
            this.grbChangePassword.Dock = System.Windows.Forms.DockStyle.Top;
            this.grbChangePassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.grbChangePassword.Location = new System.Drawing.Point(1, 0);
            this.grbChangePassword.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grbChangePassword.Name = "grbChangePassword";
            this.grbChangePassword.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grbChangePassword.Size = new System.Drawing.Size(605, 198);
            this.grbChangePassword.TabIndex = 0;
            // 
            // chkPasswordChar
            // 
            this.chkPasswordChar.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.chkPasswordChar.AutoSize = true;
            this.chkPasswordChar.ForeColor = System.Drawing.Color.White;
            this.chkPasswordChar.Location = new System.Drawing.Point(274, 147);
            this.chkPasswordChar.Name = "chkPasswordChar";
            this.chkPasswordChar.Size = new System.Drawing.Size(113, 20);
            this.chkPasswordChar.TabIndex = 3;
            this.chkPasswordChar.Text = "نمایش رمز عبور";
            this.chkPasswordChar.UseVisualStyleBackColor = true;
            this.chkPasswordChar.CheckedChanged += new System.EventHandler(this.chkPasswordChar_CheckedChanged);
            // 
            // txtUserName
            // 
            this.txtUserName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance6.BackColor = System.Drawing.Color.Transparent;
            appearance6.ForeColor = System.Drawing.Color.White;
            appearance6.TextHAlignAsString = "Left";
            this.txtUserName.Appearance = appearance6;
            this.txtUserName.BackColor = System.Drawing.Color.Transparent;
            this.txtUserName.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.txtUserName.EditableText = false;
            this.txtUserName.FontSize = 0;
            this.txtUserName.InputLanguage = Baran.Windows.Forms.InputLanguage.English;
            this.txtUserName.Location = new System.Drawing.Point(178, 27);
            this.txtUserName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.PreviousBackColor = System.Drawing.Color.Transparent;
            this.txtUserName.PreviousForeColor = System.Drawing.Color.Transparent;
            this.txtUserName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtUserName.Size = new System.Drawing.Size(209, 25);
            this.txtUserName.TabIndex = 5;
            this.txtUserName.UnformattedText = null;
            // 
            // lblUserName
            // 
            this.lblUserName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance1.ForeColor = System.Drawing.Color.White;
            this.lblUserName.Appearance = appearance1;
            this.lblUserName.AutoSize = true;
            this.lblUserName.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblUserName.Location = new System.Drawing.Point(412, 32);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblUserName.Size = new System.Drawing.Size(63, 15);
            this.lblUserName.TabIndex = 5;
            this.lblUserName.Text = " : نام کاربری";
            // 
            // txtConfirmNewPassword
            // 
            this.txtConfirmNewPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtConfirmNewPassword.BackColor = System.Drawing.SystemColors.Window;
            this.txtConfirmNewPassword.Location = new System.Drawing.Point(178, 117);
            this.txtConfirmNewPassword.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtConfirmNewPassword.Name = "txtConfirmNewPassword";
            this.txtConfirmNewPassword.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtConfirmNewPassword.Size = new System.Drawing.Size(209, 23);
            this.txtConfirmNewPassword.TabIndex = 2;
            this.txtConfirmNewPassword.UseSystemPasswordChar = true;
            // 
            // txtNewPassword
            // 
            this.txtNewPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNewPassword.BackColor = System.Drawing.SystemColors.Window;
            this.txtNewPassword.Location = new System.Drawing.Point(178, 87);
            this.txtNewPassword.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNewPassword.Name = "txtNewPassword";
            this.txtNewPassword.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtNewPassword.Size = new System.Drawing.Size(209, 23);
            this.txtNewPassword.TabIndex = 1;
            this.txtNewPassword.UseSystemPasswordChar = true;
            // 
            // lblConfirmNewPassword
            // 
            this.lblConfirmNewPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance2.ForeColor = System.Drawing.Color.White;
            this.lblConfirmNewPassword.Appearance = appearance2;
            this.lblConfirmNewPassword.AutoSize = true;
            this.lblConfirmNewPassword.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConfirmNewPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblConfirmNewPassword.Location = new System.Drawing.Point(398, 122);
            this.lblConfirmNewPassword.Name = "lblConfirmNewPassword";
            this.lblConfirmNewPassword.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblConfirmNewPassword.Size = new System.Drawing.Size(77, 15);
            this.lblConfirmNewPassword.TabIndex = 5;
            this.lblConfirmNewPassword.Text = " :تکرار رمز جدید";
            // 
            // lblNewPassword
            // 
            this.lblNewPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance3.ForeColor = System.Drawing.Color.White;
            this.lblNewPassword.Appearance = appearance3;
            this.lblNewPassword.AutoSize = true;
            this.lblNewPassword.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNewPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblNewPassword.Location = new System.Drawing.Point(422, 92);
            this.lblNewPassword.Name = "lblNewPassword";
            this.lblNewPassword.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblNewPassword.Size = new System.Drawing.Size(53, 15);
            this.lblNewPassword.TabIndex = 5;
            this.lblNewPassword.Text = " :رمز جدید";
            // 
            // txtPreviousPassword
            // 
            this.txtPreviousPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPreviousPassword.BackColor = System.Drawing.SystemColors.Window;
            this.txtPreviousPassword.Location = new System.Drawing.Point(178, 57);
            this.txtPreviousPassword.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPreviousPassword.Name = "txtPreviousPassword";
            this.txtPreviousPassword.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtPreviousPassword.Size = new System.Drawing.Size(209, 23);
            this.txtPreviousPassword.TabIndex = 0;
            // 
            // lblPreviousPassword
            // 
            this.lblPreviousPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance4.ForeColor = System.Drawing.Color.White;
            this.lblPreviousPassword.Appearance = appearance4;
            this.lblPreviousPassword.AutoSize = true;
            this.lblPreviousPassword.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPreviousPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblPreviousPassword.Location = new System.Drawing.Point(421, 62);
            this.lblPreviousPassword.Name = "lblPreviousPassword";
            this.lblPreviousPassword.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblPreviousPassword.Size = new System.Drawing.Size(54, 15);
            this.lblPreviousPassword.TabIndex = 5;
            this.lblPreviousPassword.Text = " :رمز قبلی";
            // 
            // frmChangePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(607, 354);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormMessage = "";
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmChangePassword";
            this.Text = "frmChangePassword";
            this.Activated += new System.EventHandler(this.frmChangePassword_Activated);
            this.Load += new System.EventHandler(this.frmChangePassword_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grpButons)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpHeader)).EndInit();
            this.grpHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpMessage)).EndInit();
            this.grpMessage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpMain)).EndInit();
            this.grpMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grbChangePassword)).EndInit();
            this.grbChangePassword.ResumeLayout(false);
            this.grbChangePassword.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Baran.Windows.Forms.GroupBox grbChangePassword;
        private Baran.Windows.Forms.Label lblPreviousPassword;
        private Baran.Windows.Forms.Label lblConfirmNewPassword;
        private Baran.Windows.Forms.Label lblNewPassword;
        private System.Windows.Forms.TextBox txtPreviousPassword;
        private System.Windows.Forms.TextBox txtConfirmNewPassword;
        private System.Windows.Forms.TextBox txtNewPassword;
        private Baran.Windows.Forms.TextBox txtUserName;
        private Baran.Windows.Forms.Label lblUserName;
        private Baran.Windows.Forms.CheckBox.CheckBox chkPasswordChar;
    }
}