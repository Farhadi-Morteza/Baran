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
    public partial class frmWaterList : Baran.Base_Forms.frmChildBase
    {
        public frmWaterList()
        {
            InitializeComponent();
        }

        #region Propertise

        private int _WaterID;
        public int WaterID
        {
            get
            {
                return _WaterID;
            }
            set
            {
                _WaterID = value;
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
            ofrm.EnableToolBarItems(cnsToolStripButton.Cancel, cnsToolStripButton.Change, cnsToolStripButton.New, cnsToolStripButton.Delete, cnsToolStripButton.Refresh, cnsToolStripButton.Export, cnsToolStripButton.Detail);
            ofrm.EnableMenuStripItems(cnsMenustripItems.Cancel, cnsMenustripItems.Change, cnsMenustripItems.New, cnsMenustripItems.Delete, cnsMenustripItems.Refresh, cnsMenustripItems.Export, cnsMenustripItems.Detail);
        }

        public override void OnNew()
        {
            base.OnNew();
            Baran.Source.frmWater ofrm = new frmWater();

            ofrm.FormItemID = Convert.ToInt32(PublicEnum.EnmformItemId.Water);
            if (PublicMethods.SetFormSchema(ofrm, ofrm.FormItemID))
            {
                ofrm.FormType = cnsFormType.New;
                ofrm.ShowDialog();
                this.FillGrid();

            }
        }

        public override void OnChange()
        {
            base.OnChange();
            if (WaterID <= 0)
            {
                OnMessage(BaranResources.NoRowSelectedError, PublicEnum.EnmMessageCategory.Warning);
                return;
            }
            Baran.Source.frmWater ofrm = new frmWater(WaterID);

            ofrm.FormItemID = Convert.ToInt32(PublicEnum.EnmformItemId.Water);
            if (PublicMethods.SetFormSchema(ofrm, ofrm.FormItemID))
            {
                ofrm.FormType = cnsFormType.Change;
                ofrm.ShowDialog();
                this.FillGrid();
            }
        }

        public override void OnDelete()
        {
            base.OnDelete();
            if (WaterID <= 0)
            {
                OnMessage(BaranResources.NoRowSelectedError, PublicEnum.EnmMessageCategory.Warning);
                return;
            }

            DialogResult msgResult = MessageBoxX.ShowMessageBox(PublicEnum.EnmMessageType.msgDeleteConfirm);
            if (msgResult == DialogResult.No) return;
            BaranDataAccess.Source.dstSourceTableAdapters.spr_src_Water_SelectTableAdapter adp =
    new BaranDataAccess.Source.dstSourceTableAdapters.spr_src_Water_SelectTableAdapter();
            try
            {
                int RowAffected = (int)adp.Delete(WaterID, Convert.ToInt32(CurrentUser.Instance.UserID));
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

        public override void OnRefresh()
        {
            base.OnRefresh();

            this.FillGrid();
        }

        public override void OnDetail()
        {
            base.OnDetail();
            this.Detail();
        }

        private void FillGrid()
        {
            try
            {
                dstSource1.spr_src_Water_Lst_Select.Clear();
                dstSource1.spr_src_Water_Lst_Select.Merge(BaranDataAccess.Source.dstSource.WaterListTable(CurrentUser.Instance.UserID).spr_src_Water_Lst_Select);
            }
            catch
            {
            }

        }

        public override void OnExport(Windows.Forms.UltraGrid grdItem)
        {
            base.OnExport(this.grdItem);
        }

        private void Detail()
        {
            if (WaterID <= 0)
            {
                OnMessage(BaranResources.NoRowSelectedError, PublicEnum.EnmMessageCategory.Warning);
                return;
            }

            Baran.Source.frmWaterView ofrm = new frmWaterView(WaterID);
            ofrm.ShowDialog();
        }

        #endregion

        #region Events

        private void grdItem_AfterRowActivate(object sender, EventArgs e)
        {
            if ((grdItem.ActiveRow == null) || (grdItem.ActiveRow.Cells["WaterID"].Value == DBNull.Value))
                return;
            WaterID = (int)grdItem.ActiveRow.Cells["WaterID"].Value;

        }

        private void grdItem_DoubleClickRow(object sender, Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs e)
        {
            this.Detail();
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
