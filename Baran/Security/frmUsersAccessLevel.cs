using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Baran.Classes.Common;

namespace Baran.Security
{
    public partial class frmUsersAccessLevel : Baran.Base_Forms.frmChildBase
    {

    #region Constractor

        public frmUsersAccessLevel()
        {
            InitializeComponent();
        }

    #endregion // End Constractor ---------------------------------------------------------------------

    #region Variables

        private long _UserID;

        private static readonly string dgvUserIDCol = "UserID";
        private static readonly string dgvUserNameCol = "UserName";

    #endregion // End Variables -----------------------------------------------------------------------

    #region Propertise

        private long UserID
        {
            get
            {
                return _UserID;
            }
            set
            {
                _UserID = value;
            }
        }

    #endregion // End Propertiese ---------------------------------------------------------------------

    #region Methods

        public override void OnChange()
        {
            base.OnChange();
            if (dgvUsers.Rows.Count == 0) return;

            BaranDataAccess.Security.dstSecurityTableAdapters.spr_Sec_SelectUsersByUserID_SelectTableAdapter adpUser =
                new BaranDataAccess.Security.dstSecurityTableAdapters.spr_Sec_SelectUsersByUserID_SelectTableAdapter();

            BaranDataAccess.Security.dstSecurity.spr_Sec_SelectUsersByUserID_SelectDataTable tblUserToUpate =
                new BaranDataAccess.Security.dstSecurity.spr_Sec_SelectUsersByUserID_SelectDataTable();

            tblUserToUpate = adpUser.GetUserTableByUserID((long)dgvUsers.ActiveRow.Cells[dgvUserIDCol].Value);

            if (tblUserToUpate == null && tblUserToUpate.Rows.Count == 0)
            {
                this.lblMessage.Text = BaranResources.RecordNotFound;
                return;
            }
            else
            {
                Baran.Security.User.frmUsers ofrmUsers = new Baran.Security.User.frmUsers();
                if (PublicMethods.SetFormSchema(ofrmUsers, cnsFormItemID.StoresAmend))
                {
                    ofrmUsers.MdiParent = this.MdiParent;
                    ofrmUsers.RecordToUpdat = tblUserToUpate;
                    ofrmUsers.EnablePasswordFeild = false;
                    ofrmUsers.EnableConfirmPasswordFeild = false;
                    ofrmUsers.Show();
                }

            }
        }

        public override void OnDelete()
        {
            base.OnDelete();

            if (dgvUsers.Selected.Rows.Count == 0) return;

            DialogResult Result = Baran.Classes.Common.MessageBoxX.ShowMessageBox(Baran.Classes.Common.PublicEnum.EnmMessageType.msgDeleteConfirm);
            if (Result == DialogResult.No) return;

            long lngDelUserID = (long)dgvUsers.ActiveRow.Cells[dgvUserIDCol].Value;
            string strDelUserName = dgvUsers.ActiveRow.Cells[dgvUserNameCol].Value.ToString();

            long lngCurrentUserID = CurrentUser.Instance.UserID;

            if (lngDelUserID == lngCurrentUserID)
            {
                this.lblMessage.Text = BaranResources.YouCannotDeleteTheCurrentUuser;
                return;
            }

            try
            {
                BaranDataAccess.Security.dstSecurityTableAdapters.spr_Sec_Users_SelectTableAdapter adpUser =
                    new BaranDataAccess.Security.dstSecurityTableAdapters.spr_Sec_Users_SelectTableAdapter();

                int RowAffected = Convert.ToInt32(adpUser.Delete(lngDelUserID, lngCurrentUserID));

                //if (RowAffected > 0)
                this.lblMessage.Text = BaranResources.DeleteSuccessful + ' ' + strDelUserName;
                //else
                //    this.lblMessage.Text = BaranResources.DoNotDoPleaseTryAgine;

                this.FillGrid();
            }
            catch
            {
                this.lblMessage.Text = BaranResources.DeleteFail;
            }
        }

        public override void OnRefresh()
        {
            base.OnRefresh();

            FillGrid();
        }

    #endregion // End Methods -------------------------------------------------------------------------

    #region Events


        private void frmUsersAccessLevel_Load(object sender, EventArgs e)
        {
            this.FillGrid();
        }

        private void FillGrid()
        {
            BaranDataAccess.Security.dstSecurity.spr_Sec_UsersAccessLevel_SelectDataTable tblUsersAccessLevel =
                new BaranDataAccess.Security.dstSecurity.spr_Sec_UsersAccessLevel_SelectDataTable();
            BaranDataAccess.Security.dstSecurityTableAdapters.spr_Sec_UsersAccessLevel_SelectTableAdapter adpUsersAccessLevel =
                new BaranDataAccess.Security.dstSecurityTableAdapters.spr_Sec_UsersAccessLevel_SelectTableAdapter();

            tblUsersAccessLevel.Clear();
            tblUsersAccessLevel = adpUsersAccessLevel.GetUsersAccessLevelTable();
            dstsecurity1.Clear();
            dstsecurity1.spr_Sec_UsersAccessLevel_Select.Merge(tblUsersAccessLevel);
        }

        private void frmUsersAccessLevel_Activated(object sender, EventArgs e)
        {
            frmMain ofrmMain = frmMain.Instanc;

            ofrmMain.EnableToolBarItems(cnsToolStripButton.Cancel, cnsToolStripButton.Change, cnsToolStripButton.Delete, cnsToolStripButton.Refresh);
            ofrmMain.EnableMenuStripItems(cnsMenustripItems.Cancel, cnsMenustripItems.Change, cnsMenustripItems.Delete, cnsMenustripItems.Refresh);
        }


    #endregion // End Events --------------------------------------------------------------------------

    }
}
