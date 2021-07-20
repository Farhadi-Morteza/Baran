using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Baran.Classes.Common;

namespace Baran.Production
{
    public partial class frmProductionList : Baran.Base_Forms.frmChildBase
    {
        #region Constractor

        public frmProductionList()
        {
            InitializeComponent();
        }

        #endregion

        #region Variables

        #endregion

        #region Propertise

        private int _productionID;
        public int ProductionID
        {
            get
            {
                return _productionID;
            }
            set
            {
                _productionID = value;
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
            Baran.Production.frmCropPlantation ofrm = new frmCropPlantation();

            ofrm.FormItemID = Convert.ToInt32(PublicEnum.EnmformItemId.Buildings);
            if (PublicMethods.SetFormSchema(ofrm, ofrm.FormItemID))
            {               
                if (ofrm.ShowDialog() == DialogResult.OK)
                {
                    
                }
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
            PublicPropertise.ProductionInUpate = true;
            Baran.Production.frmBaseProduction ofrm = new frmBaseProduction(ProductionID);
            try
            {
                PublicPropertise.ActivityID = Convert.ToInt32(grdItem.ActiveRow.Cells[dstProducts1.spr_prd_Production_lst_Select.Fk_ActivityIDColumn.ColumnName].Value.ToString());
                PublicPropertise.CropID = Convert.ToInt32(grdItem.ActiveRow.Cells[dstProducts1.spr_prd_Production_lst_Select.FK_CropIDColumn.ColumnName].Value.ToString());
            }
            catch { }

            PublicPropertise.ProductionID = ProductionID;
            
            ofrm.Caption = grdItem.ActiveRow.Cells[dstProducts1.spr_prd_Production_lst_Select.ProductionNameColumn.ColumnName].Value.ToString();
            //ofrm.CropImage = ff;
            ofrm.ShowDialog();
            //ofrm.FormItemID = Convert.ToInt32(PublicEnum.EnmformItemId.Buildings);
            //if (PublicMethods.SetFormSchema(ofrm, ofrm.FormItemID))
            //{
            //    ofrm.FormType = cnsFormType.Change;
            //    ofrm.ShowDialog();
            //    this.FillGrid();

            //}
        }

        public override void OnDelete()
        {
            base.OnDelete();

            if (grdItem.Selected.Rows.Count == 0)
            {
                OnMessage(BaranResources.NoRowSelectedError, PublicEnum.EnmMessageCategory.Warning);
                return;
            }

            if (ProductionID <= 0)
                return;

            DialogResult msgResult = MessageBoxX.ShowMessageBox(PublicEnum.EnmMessageType.msgDeleteConfirm);
            if (msgResult == DialogResult.No) return;

            //BaranDataAccess.Source.dstSourceTableAdapters.spr_src_Buildings_SelectTableAdapter adp =
            //    new BaranDataAccess.Source.dstSourceTableAdapters.spr_src_Buildings_SelectTableAdapter();

            
            //try
            //{
            //    int RowAffected = (int)adp.Delete(BuildingsID, Convert.ToInt32(CurrentUser.Instance.UserID));
            //    if (RowAffected > 0)
            //    {
            //        OnMessage(BaranResources.DeleteSuccessful, PublicEnum.EnmMessageCategory.Success);
            //        this.FillGrid();
            //    }
            //    else
            //        OnMessage(BaranResources.DeleteFail, PublicEnum.EnmMessageCategory.Warning);
            //}
            //catch
            //{
            //    OnMessage(BaranResources.DoNotDoPleaseTryAgine, PublicEnum.EnmMessageCategory.Warning);
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
                BaranDataAccess.Production.dstProductsTableAdapters.spr_prd_Production_lst_SelectTableAdapter adp =
                    new BaranDataAccess.Production.dstProductsTableAdapters.spr_prd_Production_lst_SelectTableAdapter();

                dstProducts1.spr_prd_Production_lst_Select.Clear();
                adp.FillProductionListTable(dstProducts1.spr_prd_Production_lst_Select, CurrentUser.Instance.UserID);
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

        #endregion

        #region Events

        private void grdItem_Click(object sender, EventArgs e)
        {
            try
            {

                if ((grdItem.ActiveRow == null) || (grdItem.ActiveRow.Cells[dstProducts1.spr_prd_Production_lst_Select.ProductionIDColumn.ColumnName].Value == DBNull.Value))
                    return;
                ProductionID = (int)grdItem.ActiveRow.Cells[dstProducts1.spr_prd_Production_lst_Select.ProductionIDColumn.ColumnName].Value;
            }
            catch
            {
                OnMessage(BaranResources.DoNotDoPleaseTryAgine, PublicEnum.EnmMessageCategory.Warning);
            }
        }

        #endregion


    }
}
