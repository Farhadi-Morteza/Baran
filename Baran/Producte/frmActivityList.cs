using Baran.Classes.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Baran.Producte
{
    public partial class frmActivityList : Baran.Base_Forms.frmChildBase
    {

        #region Constractor

        public frmActivityList()
        {
            InitializeComponent();
        }

        #endregion

        #region Variables

        BaranDataAccess.Product.dstProductTableAdapters.spr_cmn_Activity_SelectTableAdapter adp =
            new BaranDataAccess.Product.dstProductTableAdapters.spr_cmn_Activity_SelectTableAdapter();

        #endregion

        #region Propertise

        private int _activityID;
        public int ActivityID
        {
            get
            {
                return _activityID;
            }
            set
            {
                _activityID = value;
            }
        }

        #endregion

        #region Methods

        public override void OnformLoad()
        {
            base.OnformLoad();
            this.FillGrid();
        }

        public override void OnActiveForm()
        {
            base.OnActiveForm();

            frmMain ofrm = frmMain.Instanc;
            ofrm.EnableToolBarItems(cnsToolStripButton.Cancel, cnsToolStripButton.Change, cnsToolStripButton.New, cnsToolStripButton.Delete, cnsToolStripButton.Clear, cnsToolStripButton.Export, cnsToolStripButton.Refresh);
            ofrm.EnableMenuStripItems(cnsMenustripItems.Cancel, cnsMenustripItems.Change, cnsMenustripItems.New, cnsMenustripItems.Delete, cnsMenustripItems.Clear, cnsMenustripItems.Export, cnsMenustripItems.Refresh);
        }

        public override void OnNew()
        {
            base.OnNew();

            Baran.Producte.frmActivity ofrm = new frmActivity();

            ofrm.FormType = cnsFormType.New;
            ofrm.ShowDialog();
            this.FillGrid();

        }

        public override void OnChange()
        {
            base.OnChange();

            if (ActivityID <= 0)
            {
                OnMessage(BaranResources.NoRowSelectedError, PublicEnum.EnmMessageCategory.Warning);
                return;
            }
            Baran.Producte.frmActivity ofrm = new frmActivity(ActivityID);

            ofrm.FormType = cnsFormType.Change;
            ofrm.ShowDialog();
            this.FillGrid();

        }

        public override void OnDelete()
        {
            base.OnDelete();

            if (ActivityID <= 0)
            {
                OnMessage(BaranResources.SavedNotLastTime, PublicEnum.EnmMessageCategory.Warning);
                return;
            }

            DialogResult msgResult = MessageBoxX.ShowMessageBox(PublicEnum.EnmMessageType.msgDeleteConfirm);
            if (msgResult == DialogResult.No) return;

            try
            {
                int RowAffected = Convert.ToInt32(adp.Delete(ActivityID));
                if (RowAffected > 0)
                {
                    OnMessage(BaranResources.DeleteSuccessful, PublicEnum.EnmMessageCategory.Success);
                    grdItem.ActiveRow.Delete();
                }
                else
                    OnMessage(BaranResources.DeleteFail, PublicEnum.EnmMessageCategory.Warning);
            }
            catch
            {
                OnMessage(BaranResources.DoNotDoPleaseTryAgine, PublicEnum.EnmMessageCategory.Warning);
            }
        }

        public override void OnRefresh()
        {
            base.OnRefresh();

            this.FillGrid();
        }

        private void FillGrid()
        {
            BaranDataAccess.Product.dstProductTableAdapters.spr_cmn_Activity_lst_SelectTableAdapter adpBusinessList =
                new BaranDataAccess.Product.dstProductTableAdapters.spr_cmn_Activity_lst_SelectTableAdapter();
            dstProduct1.spr_cmn_Activity_lst_Select.Clear();
            try
            {
                adpBusinessList.FillActivityListTable(dstProduct1.spr_cmn_Activity_lst_Select);
            }
            catch
            {

            }
        }

        #endregion

        #region Events

        private void grdItem_AfterRowActivate(object sender, EventArgs e)
        {
            if ((grdItem.ActiveRow == null) || (grdItem.ActiveRow.Cells["ActivityID"].Value == DBNull.Value))
                return;
            ActivityID = (int)grdItem.ActiveRow.Cells["ActivityID"].Value;
        }
        #endregion

        private void grdItem_ClickCellButton(object sender, Infragistics.Win.UltraWinGrid.CellEventArgs e)
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
