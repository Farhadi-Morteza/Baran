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
    public partial class frmPesticide : Baran.Base_Forms.frmSecondChildBase
    {
        #region Constractor

        public frmPesticide()
        {
            InitializeComponent();
        }

        public frmPesticide(int pesticideID)
        {
            InitializeComponent();

            PesticideID = pesticideID;
            this.SetControlsValue();
        }

        #endregion

        #region Variables

        WaiteForm waite;

        BaranDataAccess.Product.dstProduct.spr_src_Pesticide_SelectRow drw;
        BaranDataAccess.Product.dstProductTableAdapters.spr_src_Pesticide_SelectTableAdapter adp =
            new BaranDataAccess.Product.dstProductTableAdapters.spr_src_Pesticide_SelectTableAdapter();



        DialogResult msgResult;

        int
            intPesticideCategoryID
            , intMaterialModeID
            , intProductCategoryID
            , intUnitMeasurementID
            ;
        int UserID = (int)CurrentUser.Instance.UserID;

        string
            strName
            , strDescription
            , strManufacture
            , strRegistrationNumber
            ;

        #endregion

        #region Propertise

        private int _pesticideID;
        public int PesticideID
        {
            get
            {
                return _pesticideID;
            }
            set
            {
                _pesticideID = value;
            }
        }

        #endregion

        #region Methods

        public override void OnformLoad()
        {
            base.OnformLoad();
            Baran.Classes.Common.ComboBoxSetting.FillComboBox(Classes.Common.PublicEnum.EnmComboSource.srcPesticideCategory, cmbPesticideCategory);
            Baran.Classes.Common.ComboBoxSetting.FillComboBox(Classes.Common.PublicEnum.EnmComboSource.srcMaterialMode, cmbMaterialMode);
            Baran.Classes.Common.ComboBoxSetting.FillComboBox(Classes.Common.PublicEnum.EnmComboSource.srcProductCategory, cmbProductCategory);
            Baran.Classes.Common.ComboBoxSetting.FillComboBox(Classes.Common.PublicEnum.EnmComboSource.srcUnitMeasurementAll, cmbUnitMeasurement);
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

                PesticideID = Convert.ToInt32(adp.Insert(strName, strManufacture, intPesticideCategoryID, intMaterialModeID
                                                                         , intProductCategoryID, intUnitMeasurementID, strRegistrationNumber, strDescription, UserID));
                if (PesticideID > 0)
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

            if (PesticideID <= 0)
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
                int RowAffected = Convert.ToInt32(adp.Update(PesticideID, strName, strManufacture, intPesticideCategoryID,
                                                            intMaterialModeID, intProductCategoryID, intUnitMeasurementID
                                                            , strRegistrationNumber, strDescription, UserID));

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

            if (PesticideID <= 0)
            {
                OnMessage(BaranResources.SavedNotLastTime, PublicEnum.EnmMessageCategory.Warning);
                return;
            }

            msgResult = MessageBoxX.ShowMessageBox(PublicEnum.EnmMessageType.msgDeleteConfirm);
            if (msgResult == DialogResult.No) return;
            try
            {

                int RowAffected = Convert.ToInt32(adp.Delete(PesticideID, UserID));

                if (RowAffected > 0)
                {
                    PesticideID = 0;
                    ControlsSetting.ClearControls(grpMain.Controls);
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
            ControlsSetting.ClearControls(grpMain.Controls);
        }

        private void SetControlsValue()
        {
            //BaranDataAccess.Product.dstProduct.spr_src_FertilizerByID_SelectRow drw;
            //BaranDataAccess.Product.dstProductTableAdapters.spr_src_FertilizerByID_SelectTableAdapter adpID
            //    = new BaranDataAccess.Product.dstProductTableAdapters.spr_src_FertilizerByID_SelectTableAdapter();
            BaranDataAccess.Product.dstProductTableAdapters.spr_src_Pesticide_SelectTableAdapter ppp
                = new BaranDataAccess.Product.dstProductTableAdapters.spr_src_Pesticide_SelectTableAdapter();

            if (PesticideID > 0)
            {
                drw = adp.GetPesticideByIDTable(PesticideID)[0];

                txtName.Text = drw.IsNameNull() ? string.Empty : drw.Name;
                txtManufacture.Text = drw.IsManufactureNull() ? string.Empty : drw.Manufacture;
                txtRegistrationNumber.Text = drw.IsRegistrationNumberNull() ? string.Empty : drw.RegistrationNumber;
                txtDescription.Text = drw.IsDescriptionNull() ? string.Empty : drw.Description;

                if (!drw.IsFk_PesticideCategoryIDNull())
                    cmbPesticideCategory.Value = drw.Fk_PesticideCategoryID;
                if (!drw.IsFk_MaterialModeIDNull())
                    cmbMaterialMode.Value = drw.Fk_MaterialModeID;
                if (!drw.IsFk_ProductCategoryIDNull())
                    cmbProductCategory.Value = drw.Fk_ProductCategoryID;
                if (!drw.IsFk_UnitMeasurementIDNull())
                    cmbUnitMeasurement.Value = drw.Fk_UnitMeasurementID;
            }
        }

        private void SetVariables()
        {

            strName = txtName.Text.Trim();
            strDescription = txtDescription.Text.Trim();
            strManufacture = txtManufacture.Text.Trim();
            strRegistrationNumber = txtRegistrationNumber.Text.Trim();

            if (cmbPesticideCategory.Value != null)
                intPesticideCategoryID = Convert.ToInt32(cmbPesticideCategory.Value);
            if (cmbMaterialMode.Value != null)
                intMaterialModeID = Convert.ToInt32(cmbMaterialMode.Value);
            if (cmbProductCategory.Value != null)
                intProductCategoryID = Convert.ToInt32(cmbProductCategory.Value);
            if (cmbUnitMeasurement.Value != null)
                intUnitMeasurementID = Convert.ToInt32(cmbUnitMeasurement.Value);
        }

        private bool ControlsValidation()
        {
            bool blnResult = true;

            if (txtName.Text.Trim() == string.Empty)
            {
                txtName.Focus();
                blnResult = false;
            }
            else if (cmbPesticideCategory.Value == null)
            {
                cmbPesticideCategory.Focus();
                blnResult = false;
            }
            else if (cmbMaterialMode.Value == null)
            {
                cmbMaterialMode.Focus();
                blnResult = false;
            }
            else if (cmbUnitMeasurement.Value == null)
            {
                cmbUnitMeasurement.Focus();
                blnResult = false;
            }
            else if (cmbProductCategory.Value == null)
            {
                cmbProductCategory.Focus();
                blnResult = false;
            }

            return blnResult;
        }

        #endregion
    }
}
