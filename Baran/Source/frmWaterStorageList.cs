using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Baran.Classes.Common;

namespace Baran.Source
{
    public partial class frmWaterStorageList : Baran.Base_Forms.frmChildBase
    {
        #region Constractor

        public frmWaterStorageList()
        {
            InitializeComponent();
        }

        #endregion

        #region Variables

        DialogResult msgResult;

        #endregion

        #region Propertise

        private int _WaterStorageID = 0;
        public int WaterStorageID
        {
            get
            {
                return _WaterStorageID;
            }
            set
            {
                _WaterStorageID = value;
            }
        }

        #endregion

        #region Methods

        public override void OnActiveForm()
        {
            base.OnActiveForm();

            frmMain ofrm = frmMain.Instanc;
            ofrm.EnableToolBarItems(cnsToolStripButton.Cancel, cnsToolStripButton.Change, cnsToolStripButton.Delete, cnsToolStripButton.Export, cnsToolStripButton.New, cnsToolStripButton.Detail);
            ofrm.EnableMenuStripItems(cnsMenustripItems.Cancel, cnsMenustripItems.Change, cnsMenustripItems.Delete, cnsMenustripItems.Export, cnsMenustripItems.New, cnsMenustripItems.Detail);
        }

        public override void OnformLoad()
        {
            base.OnformLoad();
            this.FillGrid();
        }

        public override void OnNew()
        {
            base.OnNew();

            Baran.Source.frmWaterStorage ofrmWaterStorage =
                new frmWaterStorage();
            ofrmWaterStorage.FormItemID = Convert.ToInt32(PublicEnum.EnmformItemId.WaterStorage);
            if (PublicMethods.SetFormSchema(ofrmWaterStorage, ofrmWaterStorage.FormItemID))
            {
                ofrmWaterStorage.FormType = cnsFormType.New;
                ofrmWaterStorage.ShowDialog();
                this.FillGrid();

            }
        }

        public override void OnChange()
        {
            base.OnChange();
            if (grdItem.Selected.Rows.Count == 0)
            {
                OnMessage(BaranResources.NoRowSelectedError, PublicEnum.EnmMessageCategory.Warning);
                return;
            }

            Baran.Source.frmWaterStorage ofrmWaterStorageEdite =
                new frmWaterStorage(WaterStorageID);

            ofrmWaterStorageEdite.FormItemID = Convert.ToInt32(PublicEnum.EnmformItemId.WaterStorage);
            if (PublicMethods.SetFormSchema(ofrmWaterStorageEdite, ofrmWaterStorageEdite.FormItemID))
            {
                ofrmWaterStorageEdite.FormType = cnsFormType.Change;
                ofrmWaterStorageEdite.ShowDialog();
                this.FillGrid();
            }

        }

        public override void OnDelete()
        {
            base.OnDelete();
            if (grdItem.Selected.Rows.Count == 0)
            {
                OnMessage(BaranResources.NoRowSelectedError, PublicEnum.EnmMessageCategory.Warning);
                return;
            }
            if (WaterStorageID <= 0)
                return;

            msgResult = MessageBoxX.ShowMessageBox(PublicEnum.EnmMessageType.msgDeleteConfirm);
            if (msgResult == DialogResult.No) return;

            BaranDataAccess.Source.dstSourceTableAdapters.spr_src_WaterStorage_SelectTableAdapter adp
                = new BaranDataAccess.Source.dstSourceTableAdapters.spr_src_WaterStorage_SelectTableAdapter();

            try
            {
                int RowAffected = Convert.ToInt32(adp.Delete(WaterStorageID, Convert.ToInt32(CurrentUser.Instance.UserID)));
                if (RowAffected > 0)
                {
                    OnMessage(BaranResources.DeleteSuccessful, PublicEnum.EnmMessageCategory.Success);
                    this.FillGrid();
                }
                else
                    OnMessage(BaranResources.DeleteFail, PublicEnum.EnmMessageCategory.Warning);
            }
            catch
            {
                OnMessage(BaranResources.DoNotDoPleaseTryAgine, PublicEnum.EnmMessageCategory.Warning);
            }
        }

        public override void OnExport(Windows.Forms.UltraGrid grdItem)
        {
            base.OnExport(this.grdItem);
        }

        public override void OnDetail()
        {
            base.OnDetail();
            this.Detail();
        }

        private void FillGrid()
        {
            dstSource1.spr_src_WaterStorage_Lst_Select.Clear();
            dstSource1.spr_src_WaterStorage_Lst_Select.Merge(BaranDataAccess.Source.dstSource.WaterStorageListTable(CurrentUser.Instance.UserID).spr_src_WaterStorage_Lst_Select);

        }

        private void Detail()
        {
            Baran.Source.frmWaterStorageView ofrm = new frmWaterStorageView(WaterStorageID);
            ofrm.ShowDialog();
        }

        #endregion

        #region Events

        private void grdItem_AfterRowActivate(object sender, EventArgs e)
        {
            if (grdItem.ActiveRow == null || (grdItem.ActiveRow.Cells["WaterStorageID"].Value == DBNull.Value))
                return;

            WaterStorageID = Convert.ToInt32(grdItem.ActiveRow.Cells["WaterStorageID"].Value);

        }

        private void grdItem_DoubleClickRow(object sender, Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs e)
        {
            this.Detail();
        }

        #endregion



    }
}
