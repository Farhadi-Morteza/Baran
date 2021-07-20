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
    public partial class frmTasklistForm : Baran.Base_Forms.frmSecondChildBase
    {

        #region Constractor

        public frmTasklistForm()
        {
            InitializeComponent();
        }

        public frmTasklistForm(int tasklistID)
        {
            InitializeComponent();
            this.TasklistID = tasklistID;
            this.SetControlsValue();
        }

        #endregion

        #region Variables

        WaiteForm waite;

        DialogResult msgResult;

        BaranDataAccess.Task.dstTaskTableAdapters.spr_tsk_Tasklist_SelectTableAdapter adpTasklist =
    new BaranDataAccess.Task.dstTaskTableAdapters.spr_tsk_Tasklist_SelectTableAdapter();
        BaranDataAccess.Task.dstTaskTableAdapters.spr_tsk_Tasklist_Task_Link_SelectTableAdapter adpTasklistTask =
            new BaranDataAccess.Task.dstTaskTableAdapters.spr_tsk_Tasklist_Task_Link_SelectTableAdapter();

        int UserID = (int)CurrentUser.Instance.UserID;

        string
            strTasklistName
            ;

        #endregion

        #region Propertise

        private int _tasklistID = -1;
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


            BaranDataAccess.Task.dstTaskTableAdapters.spr_tsk_Task_cmb_SelectTableAdapter adpTaskcmb =
                new BaranDataAccess.Task.dstTaskTableAdapters.spr_tsk_Task_cmb_SelectTableAdapter();

            adpTaskcmb.FillTaskCmbTable(dstTask1.spr_tsk_Task_cmb_Select);
        }

        public override void OnSave()
        {
            base.OnSave();

            //if (WaterStorageID > 0)
            //{
            //    OnMessage(BaranResources.SavedLastTime, PublicEnum.EnmMessageCategory.Warning);
            //    return;
            //}
            if (!this.ControlsValidation())
            {
                OnMessage(BaranResources.FeildIsEmpty, PublicEnum.EnmMessageCategory.Warning);
                return;
            }

            msgResult = MessageBoxX.ShowMessageBox(PublicEnum.EnmMessageType.msgSaveConfirm);
            if (msgResult == DialogResult.No) return;

            waite = new WaiteForm();
            try
            {
                waite.Show();
                this.SetVariables();

                TasklistID = Convert.ToInt32(adpTasklist.New_Tasklist_Insert(strTasklistName, UserID));
                if (TasklistID > 0)
                {
                    for (int i = 0; i <= dstTask1.spr_tsk_Tasklist_Task_Link_Select.Count - 1; i++)
                    {

                        dstTask1.spr_tsk_Tasklist_Task_Link_Select.Rows[i][dstTask1.spr_tsk_Tasklist_Task_Link_Select.Fk_TasklistIDColumn.ColumnName] = TasklistID;
                    }

                    adpTasklistTask.Update(dstTask1.spr_tsk_Tasklist_Task_Link_Select);

                    OnMessage(BaranResources.SaveSuccessful, PublicEnum.EnmMessageCategory.Success);
                }
                else
                    OnMessage(BaranResources.SaveFail, PublicEnum.EnmMessageCategory.Warning);
            }
            catch
            {
                OnMessage(BaranResources.DoNotDoPleaseTryAgine, PublicEnum.EnmMessageCategory.Warning);
            }
            waite.Close();
        }

        public override void OnChange()
        {
            base.OnChange();

            if (TasklistID <= 0)
            {
                OnMessage(BaranResources.SavedNotLastTime, PublicEnum.EnmMessageCategory.Warning);
                return;
            }

            if (!this.ControlsValidation())
            {
                OnMessage(BaranResources.FeildIsEmpty, PublicEnum.EnmMessageCategory.Warning);
                return;
            }

            msgResult = MessageBoxX.ShowMessageBox(PublicEnum.EnmMessageType.msgEditConfirm);
            if (msgResult == DialogResult.No) return;

            waite = new WaiteForm();
            try
            {
                waite.Show();
                this.SetVariables();

                int RowAffected = Convert.ToInt32(adpTasklist.Update(TasklistID, strTasklistName, UserID));

                if (RowAffected > 0)
                {
                    for (int i = 0; i <= dstTask1.spr_tsk_Tasklist_Task_Link_Select.Count - 1; i++)
                    {
                        dstTask1.spr_tsk_Tasklist_Task_Link_Select.Rows[i][dstTask1.spr_tsk_Tasklist_Task_Link_Select.Fk_TasklistIDColumn.ColumnName] = TasklistID;
                    }

                    adpTasklistTask.Update(dstTask1.spr_tsk_Tasklist_Task_Link_Select);

                    OnMessage(BaranResources.EditSuccessful, PublicEnum.EnmMessageCategory.Success);

                }
                else
                    OnMessage(BaranResources.EditFail, PublicEnum.EnmMessageCategory.Warning);
            }
            catch
            {
                OnMessage(BaranResources.DoNotDoPleaseTryAgine, PublicEnum.EnmMessageCategory.Warning);
            }
            waite.Close();
        }

        public override void OnDelete()
        {
            base.OnDelete();

            if (TasklistID <= 0)
            {
                OnMessage(BaranResources.SavedNotLastTime, PublicEnum.EnmMessageCategory.Warning);
                return;
            }

            msgResult = MessageBoxX.ShowMessageBox(PublicEnum.EnmMessageType.msgDeleteConfirm);
            if (msgResult == DialogResult.No) return;
            try
            {

                int RowAffected = Convert.ToInt32(adpTasklist.Delete(TasklistID, UserID));

                if (RowAffected > 0)
                {
                    TasklistID = 0;
                    ControlsSetting.ClearControls(grpControls.Controls);
                    OnMessage(BaranResources.DeleteSuccessful, PublicEnum.EnmMessageCategory.Success);
                }
                else
                    OnMessage(BaranResources.DeleteFail, PublicEnum.EnmMessageCategory.Warning);
            }
            catch
            {
                OnMessage(BaranResources.DoNotDoPleaseTryAgine, PublicEnum.EnmMessageCategory.Warning);
            }
        }

        public override void OnClear()
        {
            base.OnClear();
            ControlsSetting.ClearControls(grpControls.Controls);
        }

        private void SetControlsValue()
        {
            BaranDataAccess.Product.dstProductTableAdapters.spr_src_FertilizerByID_SelectTableAdapter adpID
                = new BaranDataAccess.Product.dstProductTableAdapters.spr_src_FertilizerByID_SelectTableAdapter();

            BaranDataAccess.Task.dstTask.spr_tsk_Tasklist_SelectRow drw;

            if (TasklistID > 0)
            {
                drw = adpTasklist.GetTasklistByIDTable(TasklistID)[0];

                txtTasklistName.Text = drw.TasklistName;

                adpTasklistTask.FillTasklistTaskByTasklistIDTable(dstTask1.spr_tsk_Tasklist_Task_Link_Select, TasklistID);
            }

        }

        private void SetVariables()
        {

            strTasklistName = txtTasklistName.Text.Trim();

        }

        private bool ControlsValidation()
        {
            bool blnResult = true;

            if (txtTasklistName.Text.Trim() == string.Empty)
            {
                txtTasklistName.Focus();
                blnResult = false;
            }

            return blnResult;
        }

        #endregion
    }
}
