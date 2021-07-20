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
    public partial class frmProductionTaskList : Baran.Base_Forms.frmSecondChildBase
    {
        #region Constractor

        public frmProductionTaskList()
        {
            InitializeComponent();

       }

        #endregion

        #region Variables

        BaranDataAccess.Production.dstProductsTableAdapters.spr_prd_ProductionTaskByProductionID_SelectTableAdapter adp =
            new BaranDataAccess.Production.dstProductsTableAdapters.spr_prd_ProductionTaskByProductionID_SelectTableAdapter();
        
        #endregion

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
            if (PublicPropertise.ProductionInUpate)
            {
                FormType = cnsFormType.Change;
            }

            this.FillGrid();
        }

        public override void OnNew()
        {
            base.OnNew();

            Baran.Production.frmProductionTask ofrm =
                new frmProductionTask();

            //ofrm.FormItemID = Convert.ToInt32(PublicEnum.EnmformItemId.Crop);
            //if (PublicMethods.SetFormSchema(ofrm, ofrm.FormItemID))
            //{
                ofrm.FormType = cnsFormType.New;
                ofrm.ShowDialog();
                this.FillGrid();

            //}
        }

        public override void OnChange()
        {
            base.OnChange();

            if (grdItem.Selected.Rows.Count == 0)
            {
                OnMessage(BaranResources.NoRowSelectedError, PublicEnum.EnmMessageCategory.Warning);
                return;
            }

            if(ProductionTaskID <= 0)
            {
                OnMessage(BaranResources.SavedNotLastTime, PublicEnum.EnmMessageCategory.Warning);
                return;
            }

            Baran.Production.frmProductionTask ofrm =
                 new frmProductionTask(ProductionTaskID);

            //ofrm.FormItemID = Convert.ToInt32(PublicEnum.EnmformItemId.Field);
            //if (PublicMethods.SetFormSchema(ofrm, ofrm.FormItemID))
            //{
                ofrm.FormType = cnsFormType.Change;
                ofrm.ShowDialog();
                this.FillGrid();

            //}
        }

        public override void OnDelete()
        {
            base.OnDelete();

            if (ProductionTaskID <= 0)
            {
                OnMessage(BaranResources.SavedNotLastTime, PublicEnum.EnmMessageCategory.Warning);
                return;
            }

            DialogResult msgResult = MessageBoxX.ShowMessageBox(PublicEnum.EnmMessageType.msgDeleteConfirm);
            if (msgResult == DialogResult.No) return;

            BaranDataAccess.Production.dstProductsTableAdapters.spr_prd_ProductionTask_SelectTableAdapter adpDelete =
                new BaranDataAccess.Production.dstProductsTableAdapters.spr_prd_ProductionTask_SelectTableAdapter();
            try
            {
                int RowAffected = Convert.ToInt32(adpDelete.Delete(ProductionTaskID, CurrentUser.Instance.UserID));
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
            dstProducts1.spr_prd_ProductionTaskByProductionID_Select.Clear();

            try
            {
                adp.FillProductionTaskByProductonIDTable(dstProducts1.spr_prd_ProductionTaskByProductionID_Select, Baran.Classes.Common.PublicPropertise.ProductionID);
            }
            catch
            {

            }
        }

        #endregion

        #region Events

        private void grdItem_AfterRowActivate(object sender, EventArgs e)
        {
            if ((grdItem.ActiveRow == null) || (grdItem.ActiveRow.Cells[dstProducts1.spr_prd_ProductionTaskByProductionID_Select.ProductionTaskIDColumn.ColumnName].Value == DBNull.Value))
                return;
            ProductionTaskID = Convert.ToInt32( grdItem.ActiveRow.Cells[dstProducts1.spr_prd_ProductionTaskByProductionID_Select.ProductionTaskIDColumn.ColumnName].Value);
        }

        #endregion

        private void grdItem_DoubleClick(object sender, EventArgs e)
        {
            if (grdItem.ActiveRow == null)
                return;

            int ProductionTaskID = Convert.ToInt32( grdItem.ActiveRow.Cells[dstProducts1.spr_prd_ProductionTaskByProductionID_Select.ProductionTaskIDColumn.ColumnName].Value);

            Baran.Production.frmProductionTaskLinkTo ofrm = new frmProductionTaskLinkTo(ProductionTaskID);
            ofrm.ShowDialog();
        }
    }
}
