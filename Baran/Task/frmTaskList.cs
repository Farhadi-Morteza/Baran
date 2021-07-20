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
    public partial class frmTaskList : Baran.Base_Forms.frmChildBase
    {

        #region Constractor

        public frmTaskList()
        {
            InitializeComponent();
        }

        #endregion

        #region Variables

        #endregion

        #region Propertise

        private int _taskID;
        public int TaskID
        {
            get
            {
                return _taskID;
            }
            set
            {
                _taskID = value;
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

            Baran.Task.frmTask ofrm =
                new frmTask();
            
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
            frmTask ofrm = new frmTask(TaskID);

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

            if (TaskID <= 0)
            {
                OnMessage(BaranResources.SavedNotLastTime, PublicEnum.EnmMessageCategory.Warning);
                return;
            }

            DialogResult msgResult = MessageBoxX.ShowMessageBox(PublicEnum.EnmMessageType.msgDeleteConfirm);
            if (msgResult == DialogResult.No) return;

            BaranDataAccess.Task.dstTaskTableAdapters.spr_tsk_Task_SelectTableAdapter adpTask =
                new BaranDataAccess.Task.dstTaskTableAdapters.spr_tsk_Task_SelectTableAdapter();
            try
            {
                int RowAffected = Convert.ToInt32(adpTask.Delete(TaskID, CurrentUser.Instance.UserID));
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
            BaranDataAccess.Task.dstTaskTableAdapters.spr_tsk_Task_lst_SelectTableAdapter adpTaskList =
                new BaranDataAccess.Task.dstTaskTableAdapters.spr_tsk_Task_lst_SelectTableAdapter();

            dstTask1.spr_tsk_Task_lst_Select.Clear();

            try
            {
                adpTaskList.FillTaskListTable(dstTask1.spr_tsk_Task_lst_Select);
            }
            catch
            {

            }
        }

        #endregion

        private void grdItem_Click(object sender, EventArgs e)
        {
            if (grdItem.ActiveRow == null)
                return;

            TaskID = Convert.ToInt32( grdItem.ActiveRow.Cells[dstTask1.spr_tsk_Task_lst_Select.TaskIDColumn.ColumnName].Value);
        }

        #region Events


        #endregion
    }
}
