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
    public partial class frmTasklistList : Baran.Base_Forms.frmChildBase
    {

        #region Constractor

        public frmTasklistList()
        {
            InitializeComponent();
        }

        #endregion

        #region Variables

        #endregion

        #region Propertise

        private int _tasklistID;
        public int TasklistID
        {
            get
            {
                return _tasklistID;
            }
            set
            {
                _tasklistID = value;
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

            Baran.Task.frmTasklistForm ofrm =
                new frmTasklistForm();
            
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

            if (TasklistID <= 0)
            {
                OnMessage(BaranResources.NoRowSelectedError, PublicEnum.EnmMessageCategory.Warning);
                return;
            }

            Baran.Task.frmTasklistForm ofrm =
                new frmTasklistForm(TasklistID);

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

            if (TasklistID <= 0)
            {
                OnMessage(BaranResources.SavedNotLastTime, PublicEnum.EnmMessageCategory.Warning);
                return;
            }

            DialogResult msgResult = MessageBoxX.ShowMessageBox(PublicEnum.EnmMessageType.msgDeleteConfirm);
            if (msgResult == DialogResult.No) return;

            BaranDataAccess.Task.dstTaskTableAdapters.spr_tsk_Tasklist_SelectTableAdapter adpTask =
                new BaranDataAccess.Task.dstTaskTableAdapters.spr_tsk_Tasklist_SelectTableAdapter();
            try
            {
                int RowAffected = Convert.ToInt32(adpTask.Delete(TasklistID, CurrentUser.Instance.UserID));
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
            BaranDataAccess.Task.dstTaskTableAdapters.spr_tsk_Tasklist_lst_SelectTableAdapter adpTasklist =
                new BaranDataAccess.Task.dstTaskTableAdapters.spr_tsk_Tasklist_lst_SelectTableAdapter();

            dstTask1.spr_tsk_Tasklist_lst_Select.Clear();

            try
            {
                adpTasklist.FillTasklistListTable(dstTask1.spr_tsk_Tasklist_lst_Select);
            }
            catch
            {

            }
        }

        #endregion

        #region Events

        private void grdItem_AfterRowActivate(object sender, EventArgs e)
        {
            if ((grdItem.ActiveRow == null) || (grdItem.ActiveRow.Cells[dstTask1.spr_tsk_Tasklist_lst_Select.TasklistIDColumn.ColumnName].Value == DBNull.Value))
                return;
            TasklistID = Convert.ToInt32( grdItem.ActiveRow.Cells[dstTask1.spr_tsk_Tasklist_lst_Select.TasklistIDColumn.ColumnName].Value);
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
