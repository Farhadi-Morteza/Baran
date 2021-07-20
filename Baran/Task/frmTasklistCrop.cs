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
    public partial class frmTasklistCrop : Baran.Base_Forms.frmSecondChildBase
    {


        #region Constractor

        public frmTasklistCrop()
        {
            InitializeComponent();
        }

        public frmTasklistCrop(int cropID)
        {
            InitializeComponent();
            this.CropID = cropID;
            this.SetControlsValue();
        }

        #endregion

        #region Variables

        WaiteForm waite;

        DialogResult msgResult;

        BaranDataAccess.Task.dstTaskTableAdapters.spr_tsk_Tasklist_Crop_Link_SelectTableAdapter adpTasklistCrop =
            new BaranDataAccess.Task.dstTaskTableAdapters.spr_tsk_Tasklist_Crop_Link_SelectTableAdapter();


        int UserID = (int)CurrentUser.Instance.UserID;

        int intTasklistID, intCropID;

        #endregion

        #region Propertise

        private int _cropID;
        public int CropID
        {
            get
            {
                return _cropID;
            }
            set
            {
                _cropID = value;
            }
        }

        #endregion

        #region Methods

        public override void OnformLoad()
        {

            base.OnformLoad();


            BaranDataAccess.Task.dstTaskTableAdapters.spr_tsk_Tasklist_cmb_SelectTableAdapter adpTasklistcmb =
                new BaranDataAccess.Task.dstTaskTableAdapters.spr_tsk_Tasklist_cmb_SelectTableAdapter();


            adpTasklistcmb.FillTasklistCmbTable(dstTask1.spr_tsk_Tasklist_cmb_Select);

            Baran.Classes.Common.ComboBoxSetting.FillComboBox(PublicEnum.EnmComboSource.srcCrop, cmbCrop);
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

                for (int i = 0; i <= dstTask1.spr_tsk_Tasklist_Crop_Link_Select.Count - 1; i++)
                {
                    dstTask1.spr_tsk_Tasklist_Crop_Link_Select.Rows[i][dstTask1.spr_tsk_Tasklist_Crop_Link_Select.Fk_CropIDColumn.ColumnName] = intCropID;
                }

                int rowAffected = Convert.ToInt32(adpTasklistCrop.Update(dstTask1.spr_tsk_Tasklist_Crop_Link_Select));

                if (rowAffected > 0)
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
            waite.Close();
        }

        public override void OnChange()
        {
            base.OnChange();

            if (CropID <= 0)
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

                for (int i = 0; i <= dstTask1.spr_tsk_Tasklist_Crop_Link_Select.Count - 1; i++)
                {
                    if (dstTask1.spr_tsk_Tasklist_Crop_Link_Select.Rows[i].RowState != DataRowState.Deleted)
                        dstTask1.spr_tsk_Tasklist_Crop_Link_Select.Rows[i][dstTask1.spr_tsk_Tasklist_Crop_Link_Select.Fk_CropIDColumn.ColumnName] = intCropID;
                }

                int RowAffected = Convert.ToInt32(adpTasklistCrop.Update(dstTask1.spr_tsk_Tasklist_Crop_Link_Select));

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
            waite.Close();
        }

        public override void OnDelete()
        {
            base.OnDelete();

            if (CropID <= 0)
            {
                OnMessage(BaranResources.SavedNotLastTime, PublicEnum.EnmMessageCategory.Warning);
                return;
            }

            msgResult = MessageBoxX.ShowMessageBox(PublicEnum.EnmMessageType.msgDeleteConfirm);
            if (msgResult == DialogResult.No) return;
            try
            {

                int RowAffected = Convert.ToInt32(adpTasklistCrop.spr_tsk_Tasklist_Crop_LinkByCropID_Delete(CropID));

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
            CropID = 0;
            ControlsSetting.ClearControls(grpControls.Controls);
            dstTask1.spr_tsk_Tasklist_Crop_Link_Select.Clear();
        }

        private void SetControlsValue()
        {

            if (CropID > 0)
            {
                try
                {
                    adpTasklistCrop.FillTasklistCropByCropIDTable(dstTask1.spr_tsk_Tasklist_Crop_Link_Select,CropID);
                    cmbCrop.Value = CropID;
                }
                catch { }


            }

        }

        private void SetVariables()
        {

        }

        private bool ControlsValidation()
        {
            bool blnResult = true;

            if (cmbCrop.Value == null)
            {
                cmbCrop.Focus();
                blnResult = false;
            }

            return blnResult;
        }

        #endregion

        private void cmbCrop_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbCrop.Value != null)
                    intCropID = Convert.ToInt32(cmbCrop.Value);
            }
            catch { }
        }
    }
}
