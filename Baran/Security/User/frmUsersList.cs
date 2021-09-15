using System.Windows.Forms;
using System;
using BaranDataAccess.Security;
using Baran.Classes.Common;

namespace Baran.Security.User
{
    public partial class frmUsersList : Base_Forms.frmChildBase
    {

    #region Constractor

        public frmUsersList()
        {
            InitializeComponent();
        }

    #endregion // End Constractor ---------------------------------------------------------------------

    #region Variables

        public static readonly string dgvUserIDCol = "UserID";

    #endregion // End Variables -----------------------------------------------------------------------

    #region Propertise

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

            tblUserToUpate = adpUser.GetUserTableByUserID((int)dgvUsers.ActiveRow.Cells[dgvUserIDCol].Value);

            if (tblUserToUpate == null && tblUserToUpate.Rows.Count == 0)
            {
                this.lblMessage.Text = BaranResources.RecordNotFound;
                return;
            }
            else
            {
                frmUsers ofrmUsers = new frmUsers();
                if (PublicMethods.SetFormSchema(ofrmUsers, cnsFormItemID.UserAmend))
                {
                    ofrmUsers.MdiParent = this.MdiParent;
                    ofrmUsers.RecordToUpdat = tblUserToUpate;
                    ofrmUsers.EnablePasswordFeild = false;
                    ofrmUsers.EnableConfirmPasswordFeild = false;
                    ofrmUsers.Show();
                }
            }
        }

        public override void OnNew()
        {
            frmUsers ofrmUsers = new frmUsers();
            if (PublicMethods.SetFormSchema(ofrmUsers, cnsFormItemID.Users))
            {
                ofrmUsers.MdiParent = this.MdiParent;
                ofrmUsers.RecordToUpdat = null;
                ofrmUsers.Show();
            }
        }

        public override void OnRefresh()
        {
            base.OnRefresh();
            this.SetGrid();
        }

        public override void OnDelete()
        {
            base.OnDelete();

            if (dgvUsers.ActiveRow == null) return;

            DialogResult Result = Baran.Classes.Common.MessageBoxX.ShowMessageBox(Baran.Classes.Common.PublicEnum.EnmMessageType.msgDeleteConfirm);
            if (Result == DialogResult.No) return;

            long lngDelUserID = (long)dgvUsers.ActiveRow.Cells[dgvUserIDCol].Value;
            string strDelUserName = dgvUsers.ActiveRow.Cells[2].Value.ToString();

            long lngCurrentUserID = CurrentUser.Instance.UserID;

            if (lngDelUserID == lngCurrentUserID)
            {
                OnMessage(BaranResources.YouCannotDeleteTheCurrentUuser, PublicEnum.EnmMessageCategory.Warning);
                return;
            }

            try
            {
                BaranDataAccess.Security.dstSecurityTableAdapters.spr_Sec_Users_SelectTableAdapter adpUser =
                    new BaranDataAccess.Security.dstSecurityTableAdapters.spr_Sec_Users_SelectTableAdapter();

                int RowAffected = Convert.ToInt32( adpUser.Delete(lngDelUserID, lngCurrentUserID));

                //if (RowAffected > 0)
                    this.lblMessage.Text = BaranResources.DeleteSuccessful;
                //else
                //    this.lblMessage.Text = BaranResources.DoNotDoPleaseTryAgine;

                this.SetGrid();
            }
            catch
            {
                this.lblMessage.Text = BaranResources.DeleteFail;
            }
        }

        public override void OnExport(Windows.Forms.UltraGrid grdItem)
        {
            base.OnExport(this.dgvUsers);
        }
        private void SetGrid()
        {
            dstsecurity.Clear();
            BaranDataAccess.Security.dstSecurityTableAdapters.spr_Sec_Users_lst_SelectTableAdapter adp =
                new BaranDataAccess.Security.dstSecurityTableAdapters.spr_Sec_Users_lst_SelectTableAdapter();
            adp.FillUsersListTable(dstsecurity.spr_Sec_Users_lst_Select);

            //dstsecurity.spr_Sec_Users_lst_Select.Merge(BaranDataAccess.Security.dstSecurity.GetUsers().spr_Sec_Users_Select);
        }

    #endregion // End Methods -------------------------------------------------------------------------

    #region Events

        private void frmUsersList_Load(object sender, System.EventArgs e)
        {
            SetGrid();
        }

        private void frmUsersList_Activated(object sender, System.EventArgs e)
        {
            Baran.frmMain ofrmMain = Baran.frmMain.Instanc;

            ofrmMain.EnableToolBarItems(cnsToolStripButton.Cancel, cnsToolStripButton.Delete, cnsToolStripButton.Change, cnsToolStripButton.New, cnsToolStripButton.Refresh, cnsToolStripButton.Filter, cnsToolStripButton.Export);
            ofrmMain.EnableMenuStripItems(cnsMenustripItems.Cancel, cnsMenustripItems.Delete, cnsMenustripItems.Change, cnsMenustripItems.New, cnsMenustripItems.Refresh, cnsMenustripItems.Filter, cnsMenustripItems.Export);
        }

        private void dgvUsers_DoubleClick(object sender, System.EventArgs e)
        {
            this.OnChange();
        }


        #endregion // End Events --------------------------------------------------------------------------

        private void dgvUsers_ClickCellButton(object sender, Infragistics.Win.UltraWinGrid.CellEventArgs e)
        {
            try
            {
                if (e.Cell.Column.Key == ColumnKey.Update)
                    OnChange();
                else if (e.Cell.Column.Key == ColumnKey.Delete)
                    OnDelete();
                else if (e.Cell.Column.Key == ColumnKey.New)
                    OnNew();
                else if (e.Cell.Column.Key == ColumnKey.Detail)
                    OnDetail();
            }
            catch { }
        }
    }
}
