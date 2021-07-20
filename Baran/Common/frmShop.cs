using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Baran.Classes.Common;

namespace Baran.Common
{
    public partial class frmShop : Baran.Base_Forms.frmChildBase
    {
        public frmShop()
        {
            InitializeComponent();
        }

        private void btnShowPic_Click(object sender, EventArgs e)
        {
            picShop.Image = Baran.Classes.Common.PublicMethods.PictureOpenFileDialog();
        }

        public override void OnformLoad()
        {
            base.OnformLoad();

            ComboBoxSetting.FillComboBox(PublicEnum.EnmComboSource.srcProvince, cmbProvince, "");

            BaranDataAccess.Security.dstSecurity.spr_Sec_Shop_SelectDataTable tblShop =
                new BaranDataAccess.Security.dstSecurity.spr_Sec_Shop_SelectDataTable();
            BaranDataAccess.Security.dstSecurityTableAdapters.spr_Sec_Shop_SelectTableAdapter adpShop =
                new BaranDataAccess.Security.dstSecurityTableAdapters.spr_Sec_Shop_SelectTableAdapter();
            BaranDataAccess.Security.dstSecurity.spr_Sec_Shop_SelectRow drwShop;

            tblShop = adpShop.GetShopsTable();
            drwShop = tblShop[0];

            txtShopName.Text = drwShop.ShopName;
            txtEconomicCode.Text = drwShop.IsEconomicCodeNull() ? string.Empty : drwShop.EconomicCode;
            txtPostalCode.Text = drwShop.IsPostalCodeNull() ? string.Empty : drwShop.PostalCode;
            txtShopAddress.Text = drwShop.IsShopAddressNull() ? string.Empty : drwShop.ShopAddress;
            txtShopTell.Text = drwShop.IsShopTellNull() ? string.Empty : drwShop.ShopTell;
            txtShopTell1.Text = drwShop.IsShopTell1Null() ? string.Empty : drwShop.ShopTell1;
            txtShopTell2.Text = drwShop.IsShopTell2Null() ? string.Empty : drwShop.ShopTell2;
            txtShopFax.Text = drwShop.IsShopFaxNull() ? string.Empty : drwShop.ShopFax;
            txtShopMobile.Text = drwShop.IsShopMobileNull() ? string.Empty : drwShop.ShopMobile;
            txtShopMobile1.Text = drwShop.IsShopMobile1Null() ? string.Empty : drwShop.ShopMobile1;
            txtShopEmail.Text = drwShop.IsShopEmailNull() ? string.Empty : drwShop.ShopEmail;
            txtShopWebSite.Text = drwShop.IsShopWebSiteNull() ? string.Empty : drwShop.ShopWebSite;
            txtShopDescription.Text = drwShop.IsShopDescriptionNull() ? string.Empty : drwShop.ShopDescription;
            txtRegistrationNumber.Text = drwShop.IsRegistrationNumberNull() ? string.Empty : drwShop.RegistrationNumber;
            txtNationalID.Text = drwShop.IsNationalIDNull() ? string.Empty : drwShop.NationalID;
            txtCity.Text = drwShop.IsCityNull() ? string.Empty : drwShop.City;

            cmbProvince.Value = drwShop.IsFk_ProvinceIDNull() ? -1 : drwShop.Fk_ProvinceID;
            cmbTownship.Value = drwShop.IsFk_TownshipIDNull() ? -1 : drwShop.Fk_TownshipID;

            if(!drwShop.IsShopLogoNull())
                picShop.Image = PublicMethods.ArrayToImage(drwShop.ShopLogo);
        }

        public override void OnActiveForm()
        {
            base.OnActiveForm();

            frmMain ofrm = frmMain.Instanc;
            ofrm.EnableToolBarItems(cnsToolStripButton.Cancel, cnsToolStripButton.Change);
            ofrm.EnableMenuStripItems(cnsMenustripItems.Cancel, cnsMenustripItems.Change, cnsMenustripItems.Save);
        }

        public override void OnSave()
        {
            base.OnSave();
            this.ShopInfoChange();
        }

        public override void OnChange()
        {
            base.OnChange();
            this.ShopInfoChange();
        }

        private void ShopInfoChange()
        {

            byte[] ShopLogo;
            long lngUserID = CurrentUser.Instance.UserID;
            int intShopID, intProvinceID, intTownshipID;

            string
              strShopName,
              strEconomicCode,
              strPostalCode,
              strShopAddress,
              strShopTell,
              strShopTell1,
              strShopTell2,
              strShopFax,
              strShopMobile,
              strShopMobile1,
              strShopEmail,
              strShopWebSite,
              strShopDescription,
              strRegistrationNumber,
              strNationalID,
              strCity
              ;

            BaranDataAccess.Security.dstSecurityTableAdapters.spr_Sec_Shop_SelectTableAdapter adpShopUpdate =
                new BaranDataAccess.Security.dstSecurityTableAdapters.spr_Sec_Shop_SelectTableAdapter();

            DialogResult msgResult = MessageBoxX.ShowMessageBox(PublicEnum.EnmMessageType.msgEditConfirm);
            if (msgResult == DialogResult.No) return;

            try
            {
                strShopName = txtShopName.Text.Trim();
                strEconomicCode = txtEconomicCode.Text.Trim();
                strPostalCode = txtPostalCode.Text.Trim();
                strShopAddress = txtShopAddress.Text.Trim();
                strShopTell = txtShopTell.Text.Trim();
                strShopTell1 = txtShopTell1.Text.Trim();
                strShopTell2 = txtShopTell2.Text.Trim();
                strShopFax = txtShopFax.Text.Trim();
                strShopMobile = txtShopMobile.Text.Trim();
                strShopMobile1 = txtShopMobile1.Text.Trim();
                strShopEmail = txtShopEmail.Text.Trim();
                strShopWebSite = txtShopWebSite.Text.Trim();
                strShopDescription = txtShopDescription.Text.Trim();
                strRegistrationNumber = txtRegistrationNumber.Text.Trim();
                strNationalID = txtNationalID.Text.Trim();
                strCity = txtCity.Text.Trim();

                intProvinceID = (int) cmbProvince.Value;
                intTownshipID = (int)cmbTownship.Value;

                ShopLogo = Baran.Classes.Common.PublicMethods.ImageToArray(picShop.Image);

                intShopID = Convert.ToInt32(adpShopUpdate.Update(strShopName,
                                     strEconomicCode,
                                     strPostalCode,
                                     ShopLogo,
                                     strShopAddress,
                                     strShopTell,
                                     strShopTell1,
                                     strShopTell2,
                                     strShopFax,
                                     strShopMobile,
                                     strShopMobile1,
                                     strShopEmail,
                                     strShopWebSite,
                                     lngUserID,
                                     strShopDescription,
                                     strRegistrationNumber,
                                     strNationalID,
                                     intProvinceID,
                                     intTownshipID,
                                     strCity));

                if (intShopID > 0)
                    this.lblMessage.Text = BaranResources.EditSuccessful;
                else
                    this.lblMessage.Text = BaranResources.DoNotDoPleaseTryAgine;
            }
            catch
            {
                this.lblMessage.Text = BaranResources.EditFail;
            }
        }

        private void cmbProvince_ValueChanged(object sender, EventArgs e)
        {
            cmbTownship.Value = null;
            ComboBoxSetting.FillComboBox(PublicEnum.EnmComboSource.srcTownship, cmbTownship,Convert.ToString( cmbProvince.Value));
        }

        private void picShop_Click(object sender, EventArgs e)
        {

        }

    }
}
