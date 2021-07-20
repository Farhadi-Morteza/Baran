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
    public partial class frmPerson : Baran.Base_Forms.frmSecondChildBase
    {

        #region Constractor

        public frmPerson()
        {
            InitializeComponent();
        }

        public frmPerson(int personID)
        {
            InitializeComponent();

            PersonID = personID;
            this.SetControlsValue();
        }

        #endregion

        #region Propertise

        private int _personID;
        public int PersonID
        {
            get
            {
                return _personID;
            }
            set
            {
                _personID = value;
            }
        }

        #endregion

        #region Variables

        WaiteForm waite;

        BaranDataAccess.Product.dstProduct.spr_src_Person_SelectRow drw;
        BaranDataAccess.Product.dstProductTableAdapters.spr_src_Person_SelectTableAdapter adp =
            new BaranDataAccess.Product.dstProductTableAdapters.spr_src_Person_SelectTableAdapter();



        DialogResult msgResult;

     
        int? intProvinceID = null;
        int? intTownshipID = null;
        int intGender
            ,intPersonCategoryID
            , intPartID;
            
        int UserID = (int)CurrentUser.Instance.UserID;

        string
            strFirstName
            , strLastName
            , strNikName
            , strNationalCode
            , strDescription
            , strPostalCode
            , strCity
            , strAddress
            , strMobil
            , strTelephon
            , strIntroducing
            ;

        #endregion

        #region Methods

        public override void OnformLoad()
        {
            base.OnformLoad();
            Baran.Classes.Common.ComboBoxSetting.FillComboBox(Classes.Common.PublicEnum.EnmComboSource.srcPersonCategory, cmbPersonCategory);
            Baran.Classes.Common.ComboBoxSetting.FillComboBox(Classes.Common.PublicEnum.EnmComboSource.srcGender, cmbGender);
            Baran.Classes.Common.ComboBoxSetting.FillComboBox(Classes.Common.PublicEnum.EnmComboSource.srcProvince, cmbProvince);
            ComboBoxSetting.FillComboBox(PublicEnum.EnmComboSource.srcPart, cmbPart);
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

                PersonID = Convert.ToInt32(adp.Insert(strFirstName, strLastName, strNikName, intGender, strNationalCode, strPostalCode
                                                    , intProvinceID, intTownshipID, strCity, strAddress, strTelephon
                                                    , strMobil, intPersonCategoryID, strIntroducing, strDescription, UserID, intPartID));
                if (PersonID > 0)
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

            if (PersonID <= 0)
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
                int RowAffected = Convert.ToInt32(adp.Update(PersonID, strFirstName, strLastName, strNikName, intGender, strNationalCode, strPostalCode
                                                    , intProvinceID, intTownshipID, strCity, strAddress, strTelephon
                                                    , strMobil, intPersonCategoryID, strIntroducing, strDescription, UserID, intPartID));

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

            if (PersonID <= 0)
            {
                OnMessage(BaranResources.SavedNotLastTime, PublicEnum.EnmMessageCategory.Warning);
                return;
            }

            msgResult = MessageBoxX.ShowMessageBox(PublicEnum.EnmMessageType.msgDeleteConfirm);
            if (msgResult == DialogResult.No) return;
            try
            {

                int RowAffected = Convert.ToInt32(adp.Delete(PersonID, UserID));

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
            PersonID = 0;
            ControlsSetting.ClearControls(grpMain.Controls);
        }

        private void SetControlsValue()
        {

            if (PersonID > 0)
            {
                drw = adp.GetPersonByIDTable(PersonID)[0];

                txtFirstName.Text = drw.IsFirstNameNull() ? string.Empty : drw.FirstName;
                txtLastName.Text = drw.IsLastNameNull() ? string.Empty : drw.LastName;
                txtNikName.Text = drw.IsNikNameNull() ? string.Empty : drw.NikName;
                txtPostalCode.Text = drw.IsPostalCodeNull() ? string.Empty : drw.PostalCode;
                txtCity.Text = drw.IsCityNull() ? string.Empty : drw.City;
                txtAddress.Text = drw.IsAddressNull() ? string.Empty : drw.Address;
                txtNationalCode.Text = drw.IsNationalCodeNull() ? string.Empty : drw.NationalCode;
                txtTelephone1.Text = drw.IsTelephoneNull() ? string.Empty : drw.Telephone;
                txtMobile.Text = drw.IsMobileNull() ? string.Empty : drw.Mobile;
                txtIntroducing.Text = drw.IsIntroducingNull() ? string.Empty  : drw.Introducing;
                txtDescription.Text = drw.IsDescriptionNull() ? string.Empty : drw.Description;

                if (!drw.IsFk_GenderIDNull())
                    cmbGender.Value = drw.Fk_GenderID;
                if (!drw.IsFk_ProvinceIDNull())
                    cmbProvince.Value = drw.Fk_ProvinceID;
                if (!drw.IsFk_TownshipIDNull())
                    cmbTownship.Value = drw.Fk_TownshipID;
                if (!drw.IsFk_PersonCategoryIDNull())
                    cmbPersonCategory.Value = drw.Fk_PersonCategoryID;
                cmbPart.Value = drw.IsFk_PartIDNull() ? null : cmbPart.Value = drw.Fk_PartID;
            }
        }

        private void SetVariables()
        {

            strFirstName = txtFirstName.Text.Trim();
             strLastName = txtLastName.Text.Trim();
             strNikName = txtNikName.Text.Trim();
             strNationalCode = txtNationalCode.Text.Trim();
             strDescription = txtDescription.Text.Trim();
             strPostalCode = txtPostalCode.Text.Trim();
             strCity = txtCity.Text.Trim();
             strAddress = txtAddress.Text.Trim();
             strMobil = txtMobile.Text.Trim();
             strTelephon = txtTelephone1.Text.Trim();
             strIntroducing = txtIntroducing.Text.Trim();

            if (cmbGender.Value != null)
                intGender = Convert.ToInt32(cmbGender.Value);
            if (cmbProvince.Value != null)
                intProvinceID = Convert.ToInt32(cmbProvince.Value);
            if (cmbTownship.Value != null)
                intTownshipID = Convert.ToInt32(cmbTownship.Value);
            if (cmbPersonCategory.Value != null)
                intPersonCategoryID = Convert.ToInt32(cmbPersonCategory.Value);
            if (cmbPart.Value != null)
                intPartID = Convert.ToInt32(cmbPart.Value);
        }

        private bool ControlsValidation()
        {
            bool blnResult = true;

            if (cmbPart.Value == null)
            {
                cmbPart.Focus();
                blnResult = false;
            }
            else if (txtFirstName.Text.Trim() == string.Empty)
            {
                txtFirstName.Focus();
                blnResult = false;
            }
            else if (txtLastName.Text.Trim() == string.Empty)
            {
                txtLastName.Focus();
                blnResult = false;
            }
            else if (txtNationalCode.Text.Trim() == string.Empty)
            {
                txtNationalCode.Focus();
                blnResult = false;
            }
            else if (cmbGender.Value == null)
            {
                cmbGender.Focus();
                blnResult = false;
            }
            else if (cmbPersonCategory.Value == null)
            {
                cmbPersonCategory.Focus();
                blnResult = false;
            }

            return blnResult;
        }

        #endregion

        private void cmbProvince_ValueChanged(object sender, EventArgs e)
        {
            cmbTownship.Value = null;
            ComboBoxSetting.FillComboBox(PublicEnum.EnmComboSource.srcTownship, cmbTownship, Convert.ToString(cmbProvince.Value));
        }
    }
}
