using Baran.Classes.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Baran.Security
{
    public partial class frmLoginNew : Form
    {
        bool UserNameValidated = false;
        bool PasswordValidated = false;

        private bool _loggingValidated = false;
        public bool LoggingValidated
        {
            get
            {
                return _loggingValidated;
            }
            set
            {
                _loggingValidated = value;
            }
        }

        public frmLoginNew()
        {
            InitializeComponent();
            //this.TransparencyKey = System.Drawing.Color.Turquoise;
            //this.BackColor = System.Drawing.Color.Turquoise;
            this.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.BackColor = System.Drawing.Color.Fuchsia;
        }

        private void frmLoginNew_Load(object sender, EventArgs e)
        {
            picUserName.Image = System.Drawing.Image.FromFile(PublicMethods.PictureFileNamePath(cnsPictureName.UserName));
            picPassword.Image = System.Drawing.Image.FromFile(PublicMethods.PictureFileNamePath(cnsPictureName.Password));
            picShowPassword.Image = System.Drawing.Image.FromFile(PublicMethods.PictureFileNamePath(cnsPictureName.HiddenPass));
        
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            BaranDataAccess.Security.dstSecurity.spr_Sec_UserAuthentication_SelectDataTable tblUser =
              new BaranDataAccess.Security.dstSecurity.spr_Sec_UserAuthentication_SelectDataTable();
            BaranDataAccess.Security.dstSecurityTableAdapters.spr_Sec_UserAuthentication_SelectTableAdapter adpUser =
                new BaranDataAccess.Security.dstSecurityTableAdapters.spr_Sec_UserAuthentication_SelectTableAdapter();

            //this.ControlsValidation(1);
            if (txtUserName.Text.Trim() == string.Empty)
            {
                MessageBoxX.ShowMessageBox(BaranResources.UserNameTextBoxIsEmptyMessage);
                txtUserName.Focus();
                return;
            }
            else if (txtPassword.Text.Trim() == string.Empty)
            {
                MessageBoxX.ShowMessageBox(BaranResources.PasswordTextBoxIsEmptyMessage);
                txtPassword.Focus();
                return;
            }

            try
            {
                tblUser = adpUser.GetAuthenticatedUserTable(1, txtUserName.Text.Trim(), txtPassword.Text.Trim());


                if (tblUser.Count > 0)
                {
                    BaranLibrary.CurrentUser.CurrentUserInfo = tblUser;
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    LoggingValidated = true;
                    this.Close();
                }
                else
                {
                    MessageBoxX.ShowMessageBox(BaranResources.UserNameOrPasswordIsWrong);
                    txtUserName.Focus();
                    LoggingValidated = false;
                    //return;
                    
                }
            }
            catch
            {
                Baran.Classes.Common.MessageBoxX.ShowMessageBox(BaranResources.ConnectionWithServerError);
                this.Close();
            }
        }

        private bool LoginValidation()
        {
            bool blnResult = true;

            if (txtUserName.Text.Trim() == string.Empty)
            {
                ControlsSetting.AddPictureMessage(txtUserName, cnsPictureMessageType.Warning, cnsPictureMessagePosition.Right);
                //txtUserName.Focus();
                blnResult = false;
            }

            else if (txtPassword.Text.Trim() == string.Empty)
            {
                ControlsSetting.AddPictureMessage(txtPassword, cnsPictureMessageType.Warning, cnsPictureMessagePosition.Right);
                //txtPassword.Focus();
                blnResult = false;
            }




            return blnResult;
        }

        private void txtUserName_Leave(object sender, System.EventArgs e)
        {
            //ControlsValidation(2);
        }

        private void txtPassword_Leave(object sender, System.EventArgs e)
        {
            //if (txtPassword.Text.Trim() == "") 
            //    txtUserName.Focus();

            //if(UserNameValidated)
            //    ControlsValidation(1);
            //else
            //    txtUserName.Focus();
        }

        private void ControlsValidation(int prmAction)
        {
            BaranDataAccess.Security.dstSecurity.spr_Sec_UserAuthentication_SelectDataTable tblUser = new BaranDataAccess.Security.dstSecurity.spr_Sec_UserAuthentication_SelectDataTable();
            BaranDataAccess.Security.dstSecurityTableAdapters.spr_Sec_UserAuthentication_SelectTableAdapter adpUser = new BaranDataAccess.Security.dstSecurityTableAdapters.spr_Sec_UserAuthentication_SelectTableAdapter();



            try
            {
                tblUser = adpUser.GetAuthenticatedUserTable(prmAction, txtUserName.Text, txtPassword.Text);

                if (tblUser.Rows.Count == 0)
                {
                    //lstErrorMessage.Visible = true;
                    //if (!(lstErrorMessage.Items.Contains(BaranResources.invalidCredentialsAtLogin)))
                    //    lstErrorMessage.Items.Add(BaranResources.invalidCredentialsAtLogin);

                    //System.Windows.Forms.MessageBox.Show(BaranResources.invalidCredentialsAtLogin );
                    if (prmAction == 2)
                    {
                        ControlsSetting.AddPictureMessage(txtUserName, cnsPictureMessageType.Error, cnsPictureMessagePosition.Right);
                        txtUserName.Focus();
                        return;
                    }
                    else if (prmAction == 1)
                    {
                        ControlsSetting.AddPictureMessage(picShowPassword, cnsPictureMessageType.Error, cnsPictureMessagePosition.Right);
                        txtPassword.Focus();
                        return;
                    }

                }
                else
                    if (prmAction == 2)
                    {
                        ControlsSetting.AddPictureMessage(txtUserName, cnsPictureMessageType.Success, cnsPictureMessagePosition.Right);
                        UserNameValidated = true;
                    }
                    else if (prmAction == 1)
                    {
                        
                        ControlsSetting.AddPictureMessage(picShowPassword, cnsPictureMessageType.Success, cnsPictureMessagePosition.Right);

                    }

            }
            catch
            {
                Baran.Classes.Common.MessageBoxX.ShowMessageBox(BaranResources.ConnectionWithServerError);
                this.Close();
            }   
        }

        private void picShowPassword_Click(object sender, EventArgs e)
        {
            if (txtPassword.UseSystemPasswordChar)
            {
                txtPassword.UseSystemPasswordChar = false;
                picShowPassword.Image = System.Drawing.Image.FromFile(PublicMethods.PictureFileNamePath(cnsPictureName.ShowPass));
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
                picShowPassword.Image = System.Drawing.Image.FromFile(PublicMethods.PictureFileNamePath(cnsPictureName.HiddenPass));
            }
            }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}


