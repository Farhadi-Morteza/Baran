using Baran.Classes.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Baran.Task
{
    public partial class frmTaskSubCategoryList : Baran.Base_Forms.frmChildBase
    {

        #region Constractor

        public frmTaskSubCategoryList()
        {
            InitializeComponent();
        }

        #endregion

        #region Variables

        #endregion

        #region Propertise

        private int _taskSubCategoryID;
        public int TaskSubCategoryID
        {
            get
            {
                return _taskSubCategoryID;
            }
            set
            {
                _taskSubCategoryID = value;
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

            Baran.Task.frmTaskSubCategory ofrm =
                new frmTaskSubCategory();

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
            frmTaskSubCategory ofrm = new frmTaskSubCategory(TaskSubCategoryID);

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

            if (TaskSubCategoryID <= 0)
            {
                OnMessage(BaranResources.SavedNotLastTime, PublicEnum.EnmMessageCategory.Warning);
                return;
            }

            DialogResult msgResult = MessageBoxX.ShowMessageBox(PublicEnum.EnmMessageType.msgDeleteConfirm);
            if (msgResult == DialogResult.No) return;

            BaranDataAccess.Product.dstProductTableAdapters.spr_cmn_Crop_SelectTableAdapter adpCrop =
                new BaranDataAccess.Product.dstProductTableAdapters.spr_cmn_Crop_SelectTableAdapter();
            try
            {
                //int RowAffected = Convert.ToInt32(adpCrop.Delete(TaskSubCategoryID, CurrentUser.Instance.UserID));
                //if (RowAffected > 0)
                //{
                //    OnMessage(BaranResources.DeleteSuccessful, PublicEnum.EnmMessageCategory.Success);
                //    grdItem.ActiveRow.Delete();
                //}
                //else
                //    OnMessage(BaranResources.DeleteFail, PublicEnum.EnmMessageCategory.Warning);
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
            BaranDataAccess.Task.dstTaskTableAdapters.spr_tsk_TaskSubCategory_lst_SelectTableAdapter adp =
                new BaranDataAccess.Task.dstTaskTableAdapters.spr_tsk_TaskSubCategory_lst_SelectTableAdapter();

            dstTask1.spr_tsk_TaskSubCategory_lst_Select.Clear();

            try
            {
                adp.FillTaskSubCategoryListTable(dstTask1.spr_tsk_TaskSubCategory_lst_Select);
            }
            catch
            {

            }
        }

        #endregion

        #region Events
        
        private void grdItem_Click(object sender, EventArgs e)
        {
            if ((grdItem.ActiveRow == null) || (grdItem.ActiveRow.Cells["TaskSubCategoryID"].Value == DBNull.Value))
                return;
            TaskSubCategoryID = (int)grdItem.ActiveRow.Cells["TaskSubCategoryID"].Value;
        }

        #endregion
    }
}
