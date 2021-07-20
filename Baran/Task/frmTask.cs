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
    public partial class frmTask : Baran.Base_Forms.frmSecondChildBase
    {

        #region Constractor

        public frmTask()
        {
            InitializeComponent();
        }

        public frmTask(int taskID)
        {
            InitializeComponent();
            TaskID = taskID;
            this.SetControlsValue();
        }

        #endregion

        #region Variables

        BaranDataAccess.Task.dstTaskTableAdapters.spr_tsk_Task_SelectTableAdapter adp =
            new BaranDataAccess.Task.dstTaskTableAdapters.spr_tsk_Task_SelectTableAdapter();
        
        internal string
            strTaskName
            , strTaskDescription;
        int?
            intTaskCategoryID
            , intTaskSubCategoryID;

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

            ComboBoxSetting.FillComboBox(PublicEnum.EnmComboSource.srcTaskCategory, cmbTaskCategory);
            //ComboBoxSetting.FillComboBox(PublicEnum.EnmComboSource.srcTaskSubCategory, cmbTaskSubCategory);
        }

        public override void OnSave()
        {
            base.OnSave();

            if (!this.ControlsValidation())
            {
                OnMessage(BaranResources.FeildIsEmpty, PublicEnum.EnmMessageCategory.Warning);
                return;
            }

            DialogResult msgResult = MessageBoxX.ShowMessageBox(PublicEnum.EnmMessageType.msgSaveConfirm);
            if (msgResult == DialogResult.No) return;

            try
            {
                this.SetVariables();

                TaskID = Convert.ToInt32(adp.Insert(strTaskName, strTaskDescription, intTaskCategoryID, intTaskSubCategoryID, CurrentUser.Instance.UserID));

                if (TaskID > 0)
                {
                    OnMessage(BaranResources.SaveSuccessful, PublicEnum.EnmMessageCategory.Success);
                }
                else
                    OnMessage(BaranResources.SaveFail, PublicEnum.EnmMessageCategory.Warning);
            }
            catch
            {
                OnMessage(BaranResources.DoNotDoPleaseTryAgine, PublicEnum.EnmMessageCategory.Warning);
            }
        }

        public override void OnChange()
        {
            base.OnChange();
            if (TaskID <= 0)
            {
                OnMessage(BaranResources.SavedNotLastTime, PublicEnum.EnmMessageCategory.Warning);
                return;
            }

            if (!this.ControlsValidation())
            {
                OnMessage(BaranResources.FeildIsEmpty, PublicEnum.EnmMessageCategory.Warning);
                return;
            }
            DialogResult msgResult = MessageBoxX.ShowMessageBox(PublicEnum.EnmMessageType.msgEditConfirm);
            if (msgResult == DialogResult.No) return;

            try
            {
                this.SetVariables();
                int RowAffected = Convert.ToInt32(adp.Update(TaskID, strTaskName, strTaskDescription, intTaskCategoryID, intTaskSubCategoryID, CurrentUser.Instance.UserID ));

                if (RowAffected > 0)
                {
                    OnMessage(BaranResources.EditSuccessful, PublicEnum.EnmMessageCategory.Success);
                }
                else
                    OnMessage(BaranResources.EditFail, PublicEnum.EnmMessageCategory.Warning);
            }
            catch
            {
                OnMessage(BaranResources.DoNotDoPleaseTryAgine, PublicEnum.EnmMessageCategory.Warning);
            }
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
            try
            {
                int RowAffected = Convert.ToInt32(adp.Delete(TaskID, CurrentUser.Instance.UserID));
                if (RowAffected > 0)
                {
                    this.ClearForm();
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
            this.ClearForm();
        }

        private void ClearForm()
        {
            Baran.Classes.Common.ControlsSetting.ClearControls(grpMain.Controls);
            TaskID = 0;
        }

        private void SetControlsValue()
        {            
            BaranDataAccess.Task.dstTask.spr_tsk_Task_SelectRow drw;
            try
            {

                drw = adp.GetTaskByIDTable(TaskID)[0];

                cmbTaskCategory.Value = drw.Fk_TaskCategoryID;
                
                if (!drw.IsFk_TaskSubCategoryIDNull())
                    cmbTaskSubCategory.Value = drw.Fk_TaskSubCategoryID;
                txtTaskName.Text = drw.TaskName;
                txtTaskDescription.Text = drw.IsTaskDescriptionNull() ? string.Empty : drw.TaskDescription;


            }
            catch
            {
                OnMessage(BaranResources.DoNotDoPleaseTryAgine, PublicEnum.EnmMessageCategory.Warning);
            }
        }

        private void SetVariables()
        {
            strTaskName = txtTaskName.Text.Trim();
            strTaskDescription = txtTaskDescription.Text.Trim();

            if (cmbTaskCategory.Value != null)
                intTaskCategoryID = Convert.ToInt32(cmbTaskCategory.Value);
            if (cmbTaskSubCategory.Value != null)
                intTaskSubCategoryID = Convert.ToInt32(cmbTaskSubCategory.Value);

        }

        private bool ControlsValidation()
        {
            bool blnResult = true;

            if (txtTaskName.Text.Trim() == string.Empty)
            {
                txtTaskName.Focus();
                blnResult = false;
            }
            else if (cmbTaskCategory.Value == null)
            {
                cmbTaskCategory.Focus();
                blnResult = false;
            }
            return blnResult;
        }

        #endregion

        #region Events

        private void cmbTaskCategory_ValueChanged(object sender, EventArgs e)
        {
            cmbTaskSubCategory.Value = null;
            ComboBoxSetting.FillComboBox(PublicEnum.EnmComboSource.srcTaskSubCategoryByTaskCategoryID, cmbTaskSubCategory, cmbTaskCategory.Value.ToString());
        }

        #endregion
    }
}
