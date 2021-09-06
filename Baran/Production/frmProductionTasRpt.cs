using Baran.Classes.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Baran.Production
{
    public partial class frmProductionTasRpt : Baran.Base_Forms.frmChildBase
    {
        public frmProductionTasRpt()
        {
            InitializeComponent();
        }

        #region Propertise

        private int _productionTaskID;
        public int ProductionTaskID 
        {
            get
            {
                return _productionTaskID;
            }
            set
            {
                _productionTaskID = value;
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
            ofrm.EnableToolBarItems(cnsToolStripButton.Cancel, cnsToolStripButton.Change,  cnsToolStripButton.Refresh, cnsToolStripButton.Export);
            ofrm.EnableMenuStripItems(cnsMenustripItems.Cancel, cnsMenustripItems.Change, cnsMenustripItems.Refresh, cnsMenustripItems.Export);
        }



        public override void OnChange()
        {
            base.OnChange();
            if (ProductionTaskID <= 0)
            {
                OnMessage(BaranResources.NoRowSelectedError, PublicEnum.EnmMessageCategory.Warning);
                return;
            }
            Baran.Production.frmProductionTaskLinkTo ofrm = new frmProductionTaskLinkTo(ProductionTaskID);

            //ofrm.FormItemID = Convert.ToInt32(PublicEnum.EnmformItemId.ProductionTask);
            //if (PublicMethods.SetFormSchema(ofrm, ofrm.FormItemID))
            //{
                ofrm.FormType = cnsFormType.Change;
                ofrm.ShowDialog();
                this.FillGrid();
            //}
        }


        public override void OnRefresh()
        {
            base.OnRefresh();

            this.FillGrid();
        }

        private void FillGrid()
        {
            try
            {
                dstProducts1.spr_prd_ProductionTask_Rpt_Select.Clear();

                BaranDataAccess.Production.dstProductsTableAdapters.spr_prd_ProductionTask_Rpt_SelectTableAdapter adp =
                    new BaranDataAccess.Production.dstProductsTableAdapters.spr_prd_ProductionTask_Rpt_SelectTableAdapter();

                adp.FillProductionTaskRptTable(dstProducts1.spr_prd_ProductionTask_Rpt_Select, CurrentUser.Instance.UserID);
            }
            catch
            {
            }

        }

        public override void OnExport(Windows.Forms.UltraGrid grdItem)
        {
            base.OnExport(this.grdItem);
        }


        #endregion

        #region Events

        private void grdItem_AfterRowActivate(object sender, EventArgs e)
        {
            if ((grdItem.ActiveRow == null) || (grdItem.ActiveRow.Cells["ProductionTaskID"].Value == DBNull.Value))
                return;
            ProductionTaskID = Convert.ToInt32( grdItem.ActiveRow.Cells["ProductionTaskID"].Value);

        }

        #endregion

        private void grdItem_InitializeRow(object sender, Infragistics.Win.UltraWinGrid.InitializeRowEventArgs e)
        {
            if (e.Row.Cells[dstProducts1.spr_prd_ProductionTask_Rpt_Select.StatusNameColumn.ColumnName].Value.ToString() == "در حال انجام")
                e.Row.Cells[dstProducts1.spr_prd_ProductionTask_Rpt_Select.StatusNameColumn.ColumnName].Appearance.ForeColor = Color.LightGreen;
            else if (e.Row.Cells[dstProducts1.spr_prd_ProductionTask_Rpt_Select.StatusNameColumn.ColumnName].Value.ToString() == "در صف انتظار")
                e.Row.Cells[dstProducts1.spr_prd_ProductionTask_Rpt_Select.StatusNameColumn.ColumnName].Appearance.ForeColor = Color.Orange;
            else if (e.Row.Cells[dstProducts1.spr_prd_ProductionTask_Rpt_Select.StatusNameColumn.ColumnName].Value.ToString() == "اتمام")
                e.Row.Cells[dstProducts1.spr_prd_ProductionTask_Rpt_Select.StatusNameColumn.ColumnName].Appearance.ForeColor = Color.LightSkyBlue;
        }

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
