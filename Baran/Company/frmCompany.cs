using Baran.Classes.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Baran.Company
{
    public partial class frmCompany : Baran.Base_Forms.frmChildBase
    {
        public frmCompany(): base()
        {
            InitializeComponent();
        }

        int CompanyID = 1;

        public override void OnformLoad()
        {
            base.OnformLoad();

            ComboBoxSetting.FillComboBox(PublicEnum.EnmComboSource.srcProvince, cmbProvince, "");
            ComboBoxSetting.FillComboBox(PublicEnum.EnmComboSource.srcCompanyCategory, cmbCompanyCategory, "");

            BaranDataAccess.Company.dstCompany.spr_src_Company_SelectRow drwCompany;
            BaranDataAccess.Company.dstCompany dstCompany;
            dstCompany = BaranDataAccess.Company.dstCompany.CompanyTable(CurrentUser.Instance.UserID);
            drwCompany = dstCompany.spr_src_Company_Select[0];

            CompanyID = drwCompany.CompanyID;
            txtName.Text = drwCompany.Name;
            txtEconomicCode.Text = drwCompany.IsEconomicCodeNull() ? string.Empty : drwCompany.EconomicCode;
            txtRegistrationNumber.Text = drwCompany.IsRegistrationNumberNull() ? string.Empty : drwCompany.RegistrationNumber;
            txtNationalID.Text = drwCompany.IsNationalIDNull() ? string.Empty : drwCompany.NationalID;
            txtPostalCode.Text = drwCompany.IsPostalCodeNull() ? string.Empty : drwCompany.PostalCode;
            cmbProvince.Value = drwCompany.IsFk_ProvinceIDNull() ? -1 : drwCompany.Fk_ProvinceID;
            cmbTownship.Value = drwCompany.IsFk_TownshipIDNull() ? -1 : drwCompany.Fk_TownshipID;
            cmbCompanyCategory.Value = drwCompany.IsFk_CompanyCategoryNull() ? -1 : drwCompany.Fk_CompanyCategory;
            txtAddress.Text = drwCompany.IsAddressNull() ? string.Empty : drwCompany.Address;
            txtTelephone1.Text = drwCompany.IsTelephone1Null() ? string.Empty : drwCompany.Telephone1;
            txtTelephone2.Text = drwCompany.IsTelephone2Null() ? string.Empty : drwCompany.Telephone2;
            txtMobile1.Text = drwCompany.IsMobile1Null() ? string.Empty : drwCompany.Mobile1;
            txtMobile2.Text = drwCompany.IsMobile2Null() ? string.Empty : drwCompany.Mobile2;
            txtFax.Text = drwCompany.IsFaxNull() ? string.Empty : drwCompany.Fax;
            txtEmail.Text = drwCompany.IsEmailNull() ? string.Empty : drwCompany.Email;
            txtWebSite.Text = drwCompany.IsWebSiteNull() ? string.Empty : drwCompany.WebSite;
            txtDescription.Text = drwCompany.IsDescriptionNull() ? string.Empty : drwCompany.Description;
            txtCity.Text = drwCompany.IsCityNull() ? string.Empty : drwCompany.City;
            if (!drwCompany.IsLogoNull())
                picLogo.Image = PublicMethods.ArrayToImage(drwCompany.Logo);
        }

        public override void OnActiveForm()
        {
            base.OnActiveForm();

            frmMain ofrm = frmMain.Instanc;
            ofrm.EnableToolBarItems(cnsToolStripButton.Cancel, cnsToolStripButton.Change);
            ofrm.EnableMenuStripItems(cnsMenustripItems.Cancel, cnsMenustripItems.Change);
        }

        public override void OnChange()
        {
            base.OnChange();
            CompanyID = 1;
            byte[] Logo;
            int UserID = (int)CurrentUser.Instance.UserID;
            int intProvinceID, intTownshipID, intCompanyCategory;

            string
              strName,
              strEconomicCode,
              strPostalCode,
              strRegistrationNumber,
              strNationalID,
              strAddress,
              strTelephone1,
              strTelephone2,
              strFax,
              strMobile1,
              strMobile2,
              strEmail,
              strWebSite,
              strDescription,
              strCity
              ;

            BaranDataAccess.Company.dstCompanyTableAdapters.spr_src_Company_SelectTableAdapter adpComanyUpdate =
                new BaranDataAccess.Company.dstCompanyTableAdapters.spr_src_Company_SelectTableAdapter();

            DialogResult msgResult = MessageBoxX.ShowMessageBox(PublicEnum.EnmMessageType.msgEditConfirm);
            if (msgResult == DialogResult.No) return;

            try
            {
                strName = txtName.Text.Trim();
                strEconomicCode = txtEconomicCode.Text.Trim();
                strPostalCode = txtPostalCode.Text.Trim();
                strRegistrationNumber = txtRegistrationNumber.Text.Trim();
                strNationalID = txtNationalID.Text.Trim();
                strAddress = txtAddress.Text.Trim();
                strTelephone1 = txtTelephone1.Text.Trim();
                strTelephone2 = txtTelephone2.Text.Trim();
                strFax = txtFax.Text.Trim();
                strMobile1 = txtMobile1.Text.Trim();
                strMobile2 = txtMobile2.Text.Trim();
                strEmail = txtEmail.Text.Trim();
                strWebSite = txtWebSite.Text.Trim();
                strDescription = txtDescription.Text.Trim();
                strCity = txtCity.Text.Trim();


                intProvinceID = (int)cmbProvince.Value;
                intTownshipID = (int)cmbTownship.Value;
                intCompanyCategory = (int)cmbCompanyCategory.Value;

                Logo = Baran.Classes.Common.PublicMethods.ImageToArray(picLogo.Image);

                int RowAffected = Convert.ToInt32(
                    adpComanyUpdate.Update(
                    CompanyID,
                    strName,
                    strEconomicCode,
                    strRegistrationNumber,
                    strNationalID,
                    strPostalCode,
                    intProvinceID,
                    intTownshipID,
                    strCity,
                    strAddress,
                    strWebSite,
                    strEmail,
                    strTelephone1,
                    strMobile1,
                    strTelephone2,
                    strMobile2,
                    strFax,
                    strDescription,
                    intCompanyCategory,
                    Logo,
                    UserID
                    ));

                if (RowAffected > 0)
                    OnMessage(BaranResources.EditSuccessful, PublicEnum.EnmMessageCategory.Success);
                else
                    OnMessage(BaranResources.EditFail, PublicEnum.EnmMessageCategory.Warning);
            }
            catch
            {
                OnMessage(BaranResources.DoNotDoPleaseTryAgine, PublicEnum.EnmMessageCategory.Warning);
            }
        }

        private void cmbProvince_ValueChanged(object sender, EventArgs e)
        {
            cmbTownship.Value = null;
            ComboBoxSetting.FillComboBox(PublicEnum.EnmComboSource.srcTownship, cmbTownship, Convert.ToString(cmbProvince.Value));
        }

        private void btnShowLogo_Click(object sender, EventArgs e)
        {
            picLogo.Image = Baran.Classes.Common.PublicMethods.PictureOpenFileDialog();
        }

        private void btnDoc_Click(object sender, EventArgs e)
        {
            if (CompanyID < 1)
            {
                OnMessage(BaranResources.SavedLastTime, PublicEnum.EnmMessageCategory.Warning);
                return;
            }
            Baran.Common.frmDocument ofrm = new Common.frmDocument();
            ofrm.Show();
            ofrm.CompanyID = CompanyID;
        }


    }
}
