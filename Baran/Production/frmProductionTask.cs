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
    public partial class frmProductionTask : Baran.Base_Forms.frmSecondChildBase
    {

        #region Constractor

        public frmProductionTask()
        {
            InitializeComponent();
        }

        public frmProductionTask(int productionTaskID)
        {
            this.InitializeComponent();
            ProductonTaskID = productionTaskID;
            this.SetControlsValue();
        }

        #endregion

        #region Variables

        BaranDataAccess.Production.dstProductsTableAdapters.spr_prd_ProductionTask_SelectTableAdapter adp =
            new BaranDataAccess.Production.dstProductsTableAdapters.spr_prd_ProductionTask_SelectTableAdapter();
        
        int intTaskID, intStatusID, intTaskCategoryID, intTaskSubCategoryID;
        Nullable<int> intPersonID;

        private Nullable<DateTime>
            dtmStartDate
            , dtmEndDate;

        string strTaskName, strDescription;

        #endregion

        #region Propertise

        private int _productionTaskID;
        public int ProductonTaskID
        {
            get
            { return _productionTaskID; }
            set
            { _productionTaskID = value; }
        }

        #endregion

        #region Methods

        public override void OnformLoad()
        {
            base.OnformLoad();

            ComboBoxSetting.FillComboBox(PublicEnum.EnmComboSource.srcStatus, cmbStatus);
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

                int RowAffected = Convert.ToInt32(adp.Insert(PublicPropertise.ProductionID, intTaskID, intStatusID, dtmStartDate, dtmEndDate, strDescription, strTaskName, intTaskCategoryID, intTaskSubCategoryID, CurrentUser.Instance.UserID, intPersonID ));

                if (RowAffected > 0)
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
            if (ProductonTaskID <= 0)
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
                int RowAffected = Convert.ToInt32(adp.Update(ProductonTaskID, PublicPropertise.ProductionID, intTaskID, intStatusID, dtmStartDate, dtmEndDate, strDescription, strTaskName, intTaskCategoryID, intTaskSubCategoryID, CurrentUser.Instance.UserID, intPersonID));

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

            if (ProductonTaskID <= 0)
            {
                OnMessage(BaranResources.SavedNotLastTime, PublicEnum.EnmMessageCategory.Warning);
                return;
            }

            DialogResult msgResult = MessageBoxX.ShowMessageBox(PublicEnum.EnmMessageType.msgDeleteConfirm);
            if (msgResult == DialogResult.No) return;
            try
            {
                int RowAffected = Convert.ToInt32(adp.Delete(ProductonTaskID, CurrentUser.Instance.UserID));
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
            //this.mskStartDate.Value = null;
            //this.mskEndDate.Value = null;
            ProductonTaskID = 0;
        }

        private void SetControlsValue()
        {            
            BaranDataAccess.Production.dstProducts.spr_prd_ProductionTask_SelectRow drw;

            try
            {
                drw = adp.GetProductionTaskByIDTable(ProductonTaskID)[0];

                txtTaskName.Text = drw.IsTaskNameNull() ? string.Empty : drw.TaskName;
                cmbStatus.Value = drw.IsFk_StatusNull() ? -1 : drw.Fk_Status;

                cmbTaskSubCategory.Value = drw.IsFk_TaskSubCategoryIDNull() ? null : cmbTaskSubCategory.Value = drw.Fk_TaskSubCategoryID;

                if(!drw.IsStartDateNull())
                    mskStartDate.Text = DateTimeUtility.ToPersian(drw.StartDate);
                if(!drw.IsEndDateNull())
                    mskEndDate.Text = DateTimeUtility.ToPersian(drw.EndDate);

                cmbTaskCategory.Value = drw.IsFk_TaskCategoryIDNull() ? null : cmbTaskCategory.Value = drw.Fk_TaskCategoryID;
                cmbTaskSubCategory.Value = drw.IsFk_TaskSubCategoryIDNull() ? null : cmbTaskSubCategory.Value = drw.Fk_TaskSubCategoryID;

                txtDescription.Text = drw.IsDescriptonNull() ? string.Empty : drw.Descripton;
            }
            catch
            {
                OnMessage(BaranResources.DoNotDoPleaseTryAgine, PublicEnum.EnmMessageCategory.Warning);
            }
        }

        private void SetVariables()
        {
            intStatusID = Convert.ToInt32(cmbStatus.Value);

            strDescription = txtDescription.Text.Trim();
            strTaskName = txtTaskName.Text.Trim();

            if (cmbTaskCategory.Value != null)
                intTaskCategoryID = Convert.ToInt32(cmbTaskCategory.Value);
            if (cmbTaskSubCategory.Value != null)
                intTaskSubCategoryID = Convert.ToInt32(cmbTaskSubCategory.Value);

            if (mskStartDate.Text != null)
                dtmStartDate = DateTimeUtility.ToGregorian(mskStartDate.Value.ToString());
            if (mskEndDate.Text != null)
                dtmEndDate = DateTimeUtility.ToGregorian(mskEndDate.Value.ToString());
            //if()
        }

        private bool ControlsValidation()
        {
            bool blnResult = true;

            if (txtTaskName.Text == string.Empty)
            {
                txtTaskName.Focus();
                blnResult = false;
            }
            else if (cmbStatus.Value == null)
            {
                cmbStatus.Focus();
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
