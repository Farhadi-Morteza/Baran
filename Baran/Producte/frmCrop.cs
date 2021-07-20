using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Baran.Classes.Common;

namespace Baran.Producte
{
    public partial class frmCrop : Baran.Base_Forms.frmSecondChildBase
    {

        #region Constractor

        public frmCrop()
        {
            InitializeComponent();
        }

        public frmCrop(int cropID)
        {
            InitializeComponent();

            CropID = cropID;
            this.SetControlsValue();
        }
        #endregion

        #region Variables

        BaranDataAccess.Product.dstProductTableAdapters.spr_cmn_Crop_SelectTableAdapter adpCrop =
            new BaranDataAccess.Product.dstProductTableAdapters.spr_cmn_Crop_SelectTableAdapter();
        
        internal string
            strNameFa,
            strNameEn;
        
        internal int
            intActivity,
            intCropCategory,
            intUnitMeasurementID;

        byte[] bytLogo;

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

            ComboBoxSetting.FillComboBox(PublicEnum.EnmComboSource.srcCropCategory, cmbCropCategory);
            ComboBoxSetting.FillComboBox(PublicEnum.EnmComboSource.srcActivity, cmbActivity);
            ComboBoxSetting.FillComboBox(PublicEnum.EnmComboSource.srcUnitMeasurement, cmbUnitMeasurement, null);// cnsMeasurementCategory.Weight.ToString());
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

                CropID = Convert.ToInt32( adpCrop.NewCrop_Insert(strNameEn, strNameFa, intActivity, intCropCategory, intUnitMeasurementID, CurrentUser.Instance.UserID, bytLogo));

                if (CropID > 0)
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
            DialogResult msgResult = MessageBoxX.ShowMessageBox(PublicEnum.EnmMessageType.msgSaveConfirm);
            if (msgResult == DialogResult.No) return;

            try
            {
                this.SetVariables();
                int RowAffected = Convert.ToInt32( adpCrop.Update(CropID, strNameEn, strNameFa, intActivity, intCropCategory, intUnitMeasurementID,bytLogo, CurrentUser.Instance.UserID));

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

            if (CropID <= 0)
            {
                OnMessage(BaranResources.SavedNotLastTime, PublicEnum.EnmMessageCategory.Warning);
                return;
            }

            DialogResult msgResult = MessageBoxX.ShowMessageBox(PublicEnum.EnmMessageType.msgDeleteConfirm);
            if (msgResult == DialogResult.No) return;
            try
            {
                int RowAffected = (int)adpCrop.Delete(CropID, CurrentUser.Instance.UserID);
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
            picLogo.Image = null;
            CropID = 0;
        }

        private void SetControlsValue()
        {
            BaranDataAccess.Product.dstProduct.spr_cmn_Crop_SelectRow drw;
            try
            {
                drw = adpCrop.GetCropByIDTable(CropID)[0];

                txtNameEn.Text = drw.IsNameEnNull() ? string.Empty : drw.NameEn;
                txtNameFa.Text = drw.IsNameFaNull() ? string.Empty : drw.NameFa;

                cmbActivity.Value = drw.IsFk_ActivityIDNull() ? -1 : drw.Fk_ActivityID;
                cmbCropCategory.Value = drw.IsFk_CropCategoryIDNull() ? -1 : drw.Fk_CropCategoryID;
                cmbUnitMeasurement.Value = drw.IsFk_UnitMeasurementIDNull() ? -1 : drw.Fk_UnitMeasurementID;

                if(!drw.IsLogoNull())
                    picLogo.Image = PublicMethods.ArrayToImage(drw.Logo);
            }
            catch
            {
                OnMessage(BaranResources.DoNotDoPleaseTryAgine, PublicEnum.EnmMessageCategory.Warning);
            }
        }

        private void SetVariables()
        {
            strNameEn = txtNameEn.Text.Trim();
            strNameFa = txtNameFa.Text.Trim();


            if (cmbActivity.Value != null)
                intActivity = Convert.ToInt32(cmbActivity.Value);
            if (cmbCropCategory.Value != null)
                intCropCategory = Convert.ToInt32(cmbCropCategory.Value);
            if (cmbUnitMeasurement.Value != null)
                intUnitMeasurementID = Convert.ToInt32(cmbUnitMeasurement.Value);

            bytLogo = PublicMethods.ImageToArray(picLogo.Image);
        }

        private bool ControlsValidation()
        {
            bool blnResult = true;

            if (txtNameFa.Text.Trim() == string.Empty)
            {
                txtNameFa.Focus();
                blnResult = false;
            }
            //else if (txtNameEn.Text.Trim() == string.Empty)
            //{
            //    txtNameEn.Focus();
            //    blnResult = false;
            //}
            else if (cmbActivity.Value == null)
            {
                cmbActivity.Focus();
                blnResult = false;

            }
            else if (cmbUnitMeasurement.Value == null)
            {
                cmbUnitMeasurement.Focus();
                blnResult = false;
            }
            else if (cmbCropCategory.Value == null)
            {
                cmbCropCategory.Focus();
                blnResult = false;
            }
            return blnResult;
        }

        #endregion

        #region Events

        private void btnShow_Click(object sender, EventArgs e)
        {
            picLogo.Image = PublicMethods.PictureOpenFileDialog();
        }

        #endregion

        private void grpMain_Click(object sender, EventArgs e)
        {

        }

    }
}
