using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Baran.Classes.Common;

namespace Baran.Security.User
{
    public partial class frmChangePassword : Baran.Base_Forms.frmChildBase
    {

    #region Constractor

        public frmChangePassword()
        {
            InitializeComponent();
        }

    #endregion // End Constractor ---------------------------------------------------------------------

    #region Variables

    #endregion // End Variables -----------------------------------------------------------------------

    #region Propertise

    #endregion // End Propertiese ---------------------------------------------------------------------

    #region Methods

        public override void OnChange()
        {
            base.OnChange();

            DialogResult msgResult = MessageBoxX.ShowMessageBox(PublicEnum.EnmMessageType.msgEditConfirm);
            if (msgResult == DialogResult.No) return;

            BaranDataAccess.Security.dstSecurityTableAdapters.spr_Sec_PasswordChange_UpdateTableAdapter adpPasswordChange =
                new BaranDataAccess.Security.dstSecurityTableAdapters.spr_Sec_PasswordChange_UpdateTableAdapter();


            BaranDataAccess.Security.dstSecurity.spr_Sec_UserAuthentication_SelectRow drwCurrentUser =
                (BaranDataAccess.Security.dstSecurity.spr_Sec_UserAuthentication_SelectRow)BaranLibrary.CurrentUser.CurrentUserInfo.Rows[0];

            BaranDataAccess.Security.dstSecurity.spr_SelectUserByUserNameandPassword_SelectDataTable tblUser =
                new BaranDataAccess.Security.dstSecurity.spr_SelectUserByUserNameandPassword_SelectDataTable();

            BaranDataAccess.Security.dstSecurityTableAdapters.spr_SelectUserByUserNameandPassword_SelectTableAdapter adpUser =
                new BaranDataAccess.Security.dstSecurityTableAdapters.spr_SelectUserByUserNameandPassword_SelectTableAdapter();

            tblUser = adpUser.GetUserDataByUserNameandPassword(drwCurrentUser.UserName, txtPreviousPassword.Text.Trim());
            if (tblUser.Rows.Count == 0)
            {
                MessageBox.Show(BaranResources.PasswordIncorrectInFrmChangePassword);
                txtPreviousPassword.Focus();
                return;
            }
            if (txtNewPassword.Text == string.Empty)
            {
                MessageBox.Show(BaranResources.NewPasswordnotSpecifiedError);
                txtNewPassword.Focus();
                return;
            }

            if (txtNewPassword.Text.Trim() != txtConfirmNewPassword.Text.Trim())
            {
                MessageBox.Show(BaranResources.newPasswordConfirmationError);
                txtConfirmNewPassword.Focus();
                return;
            }
            try
            {
                adpPasswordChange.Update(drwCurrentUser.UserID, txtNewPassword.Text.Trim());
                txtPreviousPassword.Focus();

                lblMessage.Text = "";
                lblMessage.Text = BaranResources.SuccessfulPasswordChangeMessage;

                return;
            }
            catch 
            {
                this.lblMessage.Text = BaranResources.EditSuccessful;
            }

        }

    #endregion // End Methods -------------------------------------------------------------------------

    #region Events

        private void frmChangePassword_Activated(object sender, EventArgs e)
        {
            frmMain ofrmMain = frmMain.Instanc;
            ofrmMain.EnableToolBarItems(cnsToolStripButton.Cancel, cnsToolStripButton.Change);
            ofrmMain.EnableMenuStripItems(cnsMenustripItems.Cancel, cnsMenustripItems.Change);
        }

        private void frmChangePassword_Load(object sender, EventArgs e)
        {
            txtUserName.Text = Baran.Classes.Common.CurrentUser.Instance.UserName.ToString();
        }

        private void chkPasswordChar_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPasswordChar.Checked == true)
            {
                txtPreviousPassword.UseSystemPasswordChar = false;
                txtNewPassword.UseSystemPasswordChar = false;
                txtConfirmNewPassword.UseSystemPasswordChar = false;
            }
            else
            {
                txtPreviousPassword.UseSystemPasswordChar = true;
                txtNewPassword.UseSystemPasswordChar = true;
                txtConfirmNewPassword.UseSystemPasswordChar = true;
            }
        }

    #endregion // End Events --------------------------------------------------------------------------

    }
}
