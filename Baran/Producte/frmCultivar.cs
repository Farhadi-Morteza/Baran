using Baran.Classes.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Baran.Producte
{
    public partial class frmCultivar : Baran.Base_Forms.frmSecondChildBase
    {

        #region Constractor

        public frmCultivar()
        {
            InitializeComponent();
        }

        public frmCultivar(int cultivarID)
        {
            InitializeComponent();

            CultivarID = cultivarID;
            this.SetControlsValue();
        }

        #endregion

        #region Variables

        BaranDataAccess.Product.dstProductTableAdapters.spr_cmn_Cultivar_SelectTableAdapter adp =
            new BaranDataAccess.Product.dstProductTableAdapters.spr_cmn_Cultivar_SelectTableAdapter();

        
        internal string
            strNameFa,
            strNameEn,
            strProperty,
            strCultivatedClimate,
            strDescription;
        
        internal int
            intCropID,
            intCountryID;

        decimal dclYieldPerHectare;

        #endregion

        #region Propertise

        private int _cultivarID;
        public int CultivarID
        {
            get
            {
                return _cultivarID;
            }
            set
            {
                _cultivarID = value;
            }
        }

        #endregion

        #region Methods

        public override void OnformLoad()
        {
            base.OnformLoad();

            ComboBoxSetting.FillComboBox(PublicEnum.EnmComboSource.srcCountry, cmbCountry);
            ComboBoxSetting.FillComboBox(PublicEnum.EnmComboSource.srcCrop, cmbCrop);
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

                CultivarID = Convert.ToInt32(adp.New_Cultivar_Insert(strNameFa, strNameEn, intCountryID, strProperty, strCultivatedClimate, dclYieldPerHectare, strDescription, CurrentUser.Instance.UserID, intCropID));

                if (CultivarID > 0)
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
            if (CultivarID <= 0)
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
                int RowAffected = Convert.ToInt32(adp.Update(CultivarID, strNameFa, strNameEn, intCountryID, strProperty, strCultivatedClimate, dclYieldPerHectare, strDescription, CurrentUser.Instance.UserID, intCropID));

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

            if (CultivarID <= 0)
            {
                OnMessage(BaranResources.SavedNotLastTime, PublicEnum.EnmMessageCategory.Warning);
                return;
            }

            DialogResult msgResult = MessageBoxX.ShowMessageBox(PublicEnum.EnmMessageType.msgDeleteConfirm);
            if (msgResult == DialogResult.No) return;
            try
            {
                int RowAffected = Convert.ToInt32(adp.Delete(CultivarID, CurrentUser.Instance.UserID));
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
            CultivarID = 0;
        }

        private void SetControlsValue()
        {
            BaranDataAccess.Product.dstProduct.spr_cmn_Cultivar_SelectRow drw;
            try
            {
                drw = adp.GetCultivarByIDTable(CultivarID)[0];

                txtNameEn.Text = drw.IsNameEnNull() ? string.Empty : drw.NameEn;
                txtNameFa.Text = drw.IsNameFaNull() ? string.Empty : drw.NameFa;
                txtProperty.Text = drw.IsPropertyNull() ? string.Empty : drw.Property;
                txtCultivatedClimate.Text = drw.IsCultivatedClimateNull() ? string.Empty : drw.CultivatedClimate;
                txtYieldPerHectare.Text = drw.IsYieldPerHectareNull() ? string.Empty :  drw.YieldPerHectare.ToString();
                txtDescription.Text = drw.IsDescriptionNull() ? string.Empty : drw.Description;

                cmbCrop.Value = drw.Fk_CropID;

                if (drw.Fk_CountryID != null)
                    cmbCountry.Value = drw.Fk_CountryID;

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
            strCultivatedClimate = txtCultivatedClimate.Text.Trim();
            strProperty = txtProperty.Text.Trim();
            strDescription = txtDescription.Text.Trim();

            intCropID = Convert.ToInt32( cmbCrop.Value);

            dclYieldPerHectare = Convert.ToDecimal( txtYieldPerHectare.Text.Trim());

            if (cmbCountry.Value != null)
                intCountryID = Convert.ToInt32(cmbCountry.Value);

        }

        private bool ControlsValidation()
        {
            bool blnResult = true;

            if (txtNameFa.Text.Trim() == string.Empty)
            {
                txtNameFa.Focus();
                blnResult = false;
            }
            if (txtYieldPerHectare.Text.Trim() == string.Empty)
            {
                txtYieldPerHectare.Focus();
                blnResult = false;
            }
            else if (cmbCrop.Value == null)
            {
                cmbCrop.Focus();
                blnResult = false;
            }

            return blnResult;
        }

        #endregion

        #region Events

        #endregion
    }
}
