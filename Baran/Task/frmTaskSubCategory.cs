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
    public partial class frmTaskSubCategory : Baran.Base_Forms.frmSecondChildBase
    {

        #region Constractor
        public frmTaskSubCategory()
        {
            InitializeComponent();
        }

        public frmTaskSubCategory(int taskSubCategoryID)
        {
            InitializeComponent();
            TaskSubCategoryID = taskSubCategoryID;
            this.SetControlsValue();
        }
        #endregion

        #region Variables

        BaranDataAccess.Task.dstTaskTableAdapters.spr_tsk_TaskSubCategori_SelectTableAdapter adp =
            new BaranDataAccess.Task.dstTaskTableAdapters.spr_tsk_TaskSubCategori_SelectTableAdapter();
        
        internal string
            strName;
        int
            intTaskCategoryID;

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

            ComboBoxSetting.FillComboBox(PublicEnum.EnmComboSource.srcTaskCategory, cmbTaskCategory);
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

                TaskSubCategoryID = Convert.ToInt32(adp.Insert(strName, intTaskCategoryID, CurrentUser.Instance.UserID));

                if (TaskSubCategoryID > 0)
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
            if (TaskSubCategoryID <= 0)
            {
                OnMessage(BaranResources.SavedNotLastTime, PublicEnum.EnmMessageCategory.Warning);
                return;
            }

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
                int RowAffected = Convert.ToInt32(adp.Update(TaskSubCategoryID, strName, intTaskCategoryID, CurrentUser.Instance.UserID ));

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

            if (TaskSubCategoryID <= 0)
            {
                OnMessage(BaranResources.SavedNotLastTime, PublicEnum.EnmMessageCategory.Warning);
                return;
            }

            DialogResult msgResult = MessageBoxX.ShowMessageBox(PublicEnum.EnmMessageType.msgDeleteConfirm);
            if (msgResult == DialogResult.No) return;
            try
            {
                int RowAffected = Convert.ToInt32(adp.Delete(TaskSubCategoryID, CurrentUser.Instance.UserID));
                if (RowAffected > 0)
                {
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

            Baran.Classes.Common.ControlsSetting.ClearControls(grpMain.Controls);
            TaskSubCategoryID = 0;
        }

        private void SetControlsValue()
        {
            BaranDataAccess.Task.dstTask.spr_tsk_TaskSubCategori_SelectRow drw;
            try
            {

                drw = adp.GetSubCategoryByIDTable(TaskSubCategoryID)[0];

                cmbTaskCategory.Value = drw.Fk_TaskCategoryID;
                txtName.Text = drw.TaskSubCategoryName;

            }
            catch
            {
                OnMessage(BaranResources.DoNotDoPleaseTryAgine, PublicEnum.EnmMessageCategory.Warning);
            }
        }

        private void SetVariables()
        {
            strName = txtName.Text.Trim();

            if (cmbTaskCategory.Value != null)
                intTaskCategoryID = Convert.ToInt32(cmbTaskCategory.Value);

        }

        private bool ControlsValidation()
        {
            bool blnResult = true;

            if (txtName.Text.Trim() == string.Empty)
            {
                txtName.Focus();
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

        private void grpMain_Click(object sender, EventArgs e)
        {

        }

        #region Events

        #endregion
    }
}
