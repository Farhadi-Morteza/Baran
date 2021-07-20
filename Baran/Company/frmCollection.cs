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
    public partial class frmCollection : Baran.Base_Forms.frmSecondChildBase
    {
        #region Constractor

        public frmCollection()
        {
            InitializeComponent();

        }

        public frmCollection(BaranDataAccess.Company.dstCompany dstCollection, int collectionID)
        {
            InitializeComponent();

            dst = dstCollection;
            CollectionID = collectionID;

            this.SetControlsValue();
              
        }

        #endregion

        #region Variables

        BaranDataAccess.Company.dstCompanyTableAdapters.spr_src_Collection_SelectTableAdapter adpCollection =
            new BaranDataAccess.Company.dstCompanyTableAdapters.spr_src_Collection_SelectTableAdapter();
        BaranDataAccess.Company.dstCompany dst;
        BaranDataAccess.Company.dstCompany.spr_src_Collection_SelectRow drwCollection;

        DialogResult msgResult;

        byte[] Logo;
        int UserID = (int)CurrentUser.Instance.UserID;
        int? intProvinceID = null;
        int? intTownshipID = null;
        int? intCompanyCategory = null;
        int? intCompanyID = null;

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

        #endregion

        #region Propertise

        private int _CollectionID;
        public int CollectionID
        {
            get
            {
                return _CollectionID;
            }
            set
            {
                _CollectionID = value;
            }
        }

        #endregion

        #region Methods

        public override void OnformLoad()
        {
            base.OnformLoad();
            //grpCancel.SendToBack();

            ComboBoxSetting.FillComboBox(PublicEnum.EnmComboSource.srcProvince, cmbProvince, "");
            ComboBoxSetting.FillComboBox(PublicEnum.EnmComboSource.srcCompanyCategory, cmbCompanyCategory);
            //EnableButtons(cnschildBaseButtonsName.Cancel, cnschildBaseButtonsName.Change, cnschildBaseButtonsName.Delete, cnschildBaseButtonsName.Clear, cnschildBaseButtonsName.Doc);
            this.FillGridDoc();
        }

        public override void OnActiveForm()
        {
            base.OnActiveForm();

            frmMain ofrm = frmMain.Instanc;
            ofrm.EnableToolBarItems(cnsToolStripButton.Cancel, cnsToolStripButton.Change, cnsToolStripButton.Save, cnsToolStripButton.Delete, cnsToolStripButton.Clear, cnsToolStripButton.Export);
            ofrm.EnableMenuStripItems(cnsMenustripItems.Cancel, cnsMenustripItems.Change, cnsMenustripItems.Save, cnsMenustripItems.Delete, cnsMenustripItems.Clear, cnsMenustripItems.Export);
        }

        public override void OnSave()
        {
            base.OnSave();

            //if (CollectionID > 0)
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

            Baran.Classes.Common.WaiteForm waite = new WaiteForm();
            try
            {
                waite.Show();
                this.SetVariables();
                CollectionID = Convert.ToInt32(adpCollection.New_Collection_Insert(
                    strName, strEconomicCode, strRegistrationNumber, strNationalID, strPostalCode, intProvinceID, intTownshipID,
                    strCity, strAddress, strWebSite, strEmail, strTelephone1, strMobile1, strTelephone2, strMobile2, strFax, strDescription, intCompanyCategory,
                    Logo, UserID));

                if (CollectionID > 0)
                {
                    OnMessage(BaranResources.SaveSuccessful, PublicEnum.EnmMessageCategory.Success);
                    waite.Close();
                }
                else
                {
                    OnMessage(BaranResources.SaveFail, PublicEnum.EnmMessageCategory.Warning);
                    waite.Close();
                }
            }
            catch
            {
                OnMessage(BaranResources.DoNotDoPleaseTryAgine, PublicEnum.EnmMessageCategory.Warning);
                waite.Close();
            }
        }

        public override void OnChange()
        {
            base.OnChange();
            if (CollectionID <= 0)
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

            WaiteForm waite = new WaiteForm();
            try
            {
                waite.Show();
                this.SetVariables();
                int RowAffected = Convert.ToInt32(adpCollection.Update(
                    CollectionID, strName, strEconomicCode, strRegistrationNumber, strNationalID, strPostalCode, intProvinceID, intTownshipID,
                    strCity, strAddress, strWebSite, strEmail, strTelephone1, strMobile1, strTelephone2, strMobile2, strFax, strDescription, intCompanyCategory,
                    Logo, UserID, intCompanyID));

                if (RowAffected > 0)
                {
                    OnMessage(BaranResources.EditSuccessful, PublicEnum.EnmMessageCategory.Success);
                   
                }
                else
                {
                    OnMessage(BaranResources.EditFail, PublicEnum.EnmMessageCategory.Warning);
                   
                }
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

            if (CollectionID <= 0)
            {
                OnMessage(BaranResources.SavedNotLastTime, PublicEnum.EnmMessageCategory.Warning);
                return;
            }

            msgResult = MessageBoxX.ShowMessageBox(PublicEnum.EnmMessageType.msgDeleteConfirm);
            if (msgResult == DialogResult.No) return;
            try
            {
                int RowAffected = (int)adpCollection.Delete(CollectionID, UserID);
                if (RowAffected > 0)
                {
                    CollectionID = 0;
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

            CollectionID = 0;
            Baran.Classes.Common.ControlsSetting.ClearControls(grpControls.Controls);
            grdDoc.dstCommon.spr_cmn_DocumentByFkID_Select.Clear();
            //txtName.Text = string.Empty;
            //txtPostalCode.Text = string.Empty;
            //cmbProvince.Value = null; //.SelectedIndex = -1;
            //cmbTownship.Value = null; //.SelectedIndex = -1;
            //txtAddress.Text = string.Empty;
            //txtTelephone1.Text = string.Empty;
            //txtTelephone2.Text = string.Empty;
            //txtMobile1.Text = string.Empty;
            //txtMobile2.Text = string.Empty;
            //txtFax.Text = string.Empty;
            //txtEmail.Text = string.Empty;
            //txtWebSite.Text = string.Empty;
            //txtDescription.Text = string.Empty;
            //txtCity.Text = string.Empty;
        }

        public override void OnDoc(int? companyID, int? collectionID, int? subcollectionID, int? partID, int? fieldID, int? warehouseID, int? buildingID, int? machineryID, int? waterID, int? waterStorageID, int? waterTransmissionLineID)
        {
            if (CollectionID <= 0)
            {
                OnMessage(BaranResources.SavedNotLastTime, PublicEnum.EnmMessageCategory.Warning);
                return;
            }
            base.OnDoc(null, this.CollectionID, null, null, null, null, null, null, null, null, null);
            this.FillGridDoc();
        }

        private void SetControlsValue()
        {
            drwCollection = (BaranDataAccess.Company.dstCompany.spr_src_Collection_SelectRow)dst.spr_src_Collection_Select.Select("CollectionID = " + CollectionID)[0];

            txtName.Text = drwCollection.Name;
            txtEconomicCode.Text = drwCollection.IsEconomicCodeNull() ? string.Empty : drwCollection.EconomicCode;
            txtRegistrationNumber.Text = drwCollection.IsRegistrationNumberNull() ? string.Empty : drwCollection.RegistrationNumber;
            txtNationalID.Text = drwCollection.IsNationalIDNull() ? string.Empty : drwCollection.NationalID;
            txtPostalCode.Text = drwCollection.IsPostalCodeNull() ? string.Empty : drwCollection.PostalCode;
            if(!drwCollection.IsFk_ProvinceIDNull())
                cmbProvince.Value =  drwCollection.Fk_ProvinceID;
            if(!drwCollection.IsFk_TownshipIDNull())
                cmbTownship.Value = drwCollection.Fk_TownshipID;
            if(!drwCollection.IsFk_CompanyCategoryNull())
                cmbCompanyCategory.Value = drwCollection.Fk_CompanyCategory;
            txtAddress.Text = drwCollection.IsAddressNull() ? string.Empty : drwCollection.Address;
            txtTelephone1.Text = drwCollection.IsTelephone1Null() ? string.Empty : drwCollection.Telephone1;
            txtTelephone2.Text = drwCollection.IsTelephone2Null() ? string.Empty : drwCollection.Telephone2;
            txtMobile1.Text = drwCollection.IsMobile1Null() ? string.Empty : drwCollection.Mobile1;
            txtMobile2.Text = drwCollection.IsMobile2Null() ? string.Empty : drwCollection.Mobile2;
            txtFax.Text = drwCollection.IsFaxNull() ? string.Empty : drwCollection.Fax;
            txtEmail.Text = drwCollection.IsEmailNull() ? string.Empty : drwCollection.Email;
            txtWebSite.Text = drwCollection.IsWebSiteNull() ? string.Empty : drwCollection.WebSite;
            txtDescription.Text = drwCollection.IsDescriptionNull() ? string.Empty : drwCollection.Description;
            txtCity.Text = drwCollection.IsCityNull() ? string.Empty : drwCollection.City;
            if (!drwCollection.IsLogoNull())
                picLogo.Image = PublicMethods.ArrayToImage(drwCollection.Logo);

        }

        private void SetVariables()
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

            Logo = Baran.Classes.Common.PublicMethods.ImageToArray(picLogo.Image);

            if (cmbProvince.Value != null)
                intProvinceID = Convert.ToInt32(cmbProvince.Value);
            if (cmbTownship.Value != null)
                intTownshipID = Convert.ToInt32(cmbTownship.Value);
            if (cmbCompanyCategory.Value != null)
                intCompanyCategory = Convert.ToInt32(cmbCompanyCategory.Value);
        }

        private bool ControlsValidation()
        {
            bool blnResult = true;

            if (txtName.Text.Trim() == string.Empty)
            {
                txtName.Focus();
                blnResult = false;
            }
            else if (txtTelephone1.Text.Trim() == string.Empty)
            {
                txtTelephone1.Focus();
                blnResult = false;

            }
            else if (txtMobile1.Text.Trim() == string.Empty)
            {
                txtMobile1.Focus();
                blnResult = false;

            }
            else if (txtPostalCode.Text.Trim() == string.Empty)
            {
                txtPostalCode.Focus();
                blnResult = false;

            }
            else if (cmbProvince.Value == null)
            {
                cmbProvince.Focus();
                blnResult = false;
            }
            else if (cmbTownship.Value == null)
            {
                cmbTownship.Focus();
                blnResult = false;
            }

            return blnResult;
        }

        private void FillGridDoc()
        {
            this.Height = this.Height - grdDoc.Height;
            if (CollectionID > 0)
            {
                BaranDataAccess.Common.dstCommonTableAdapters.spr_cmn_DocumentByFkID_SelectTableAdapter adp =
                    new BaranDataAccess.Common.dstCommonTableAdapters.spr_cmn_DocumentByFkID_SelectTableAdapter();

                try
                {
                    adp.FillDocumentByFkIDTable(grdDoc.dstCommon.spr_cmn_DocumentByFkID_Select, null, CollectionID, null, null, null, null, null, null, null, null, null);

                    if (grdDoc.dstCommon.spr_cmn_DocumentByFkID_Select.Count <= cnsgrdDoc.MaxRowCount)
                    {
                        this.Height = this.Height + cnsgrdDoc.Margin + (grdDoc.dstCommon.spr_cmn_DocumentByFkID_Select.Count * (grdDoc.DisplayLayout.Override.MinRowHeight));
                    }
                    else if (grdDoc.dstCommon.spr_cmn_DocumentByFkID_Select.Count > cnsgrdDoc.MaxRowCount)
                    {
                        this.Height = this.Height + cnsgrdDoc.Margin + (cnsgrdDoc.MaxRowCount * (grdDoc.DisplayLayout.Override.MinRowHeight));
                    }
                       
                }
                catch
                { }
            }
        }

        #endregion

        #region Events

        private void cmbProvince_ValueChanged(object sender, EventArgs e)
        {
            cmbTownship.Value = null;
            ComboBoxSetting.FillComboBox(PublicEnum.EnmComboSource.srcTownship, cmbTownship, Convert.ToString(cmbProvince.Value));
        }

        private void grdDoc_ClickCellButton(object sender, Infragistics.Win.UltraWinGrid.CellEventArgs e)
        {
            if (e.Cell.Column.Key == "Delete")
            {
                BaranDataAccess.Common.dstCommonTableAdapters.spr_cmn_Document_SelectTableAdapter adp =
                    new BaranDataAccess.Common.dstCommonTableAdapters.spr_cmn_Document_SelectTableAdapter();

                try
                {
                    msgResult = MessageBoxX.ShowMessageBox(PublicEnum.EnmMessageType.msgDeleteConfirm);
                    if (msgResult == DialogResult.No) return;

                    int RowAffected = (int)adp.Delete((int)e.Cell.Row.Cells[grdDoc.dstCommon.spr_cmn_Document_Select.DocumentIDColumn.ColumnName].Value, (int)CurrentUser.Instance.UserID);

                    if (RowAffected > 0)
                    {
                        e.Cell.Row.Delete();
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
            else if (e.Cell.Column.Key == "Update")
            {
                try
                {
                    Baran.Common.frmDocument ofrm = new Common.frmDocument((int)e.Cell.Row.Cells[grdDoc.dstCommon.spr_cmn_Document_Select.DocumentIDColumn.ColumnName].Value);
                    ofrm.CollectionID = CollectionID;
                    ofrm.ShowDialog();

                    this.FillGridDoc();
                }
                catch (Exception)
                {

                    throw;
                }
            }
            else if (e.Cell.Column.Key == "Download")
            {
                System.Drawing.Image img;

                // Displays a SaveFileDialog so the user can save the Image
                // assigned to Button2.
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Filter = "JPeg Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif";
                saveFileDialog1.Title = "Save an Image File";
                saveFileDialog1.ShowDialog();

                BaranDataAccess.Common.dstCommon.spr_cmn_DocumentByFkID_SelectRow rw;
                string strFilter = "DocumentID = " + (int)e.Cell.Row.Cells["DocumentID"].Value;
                rw = (BaranDataAccess.Common.dstCommon.spr_cmn_DocumentByFkID_SelectRow)grdDoc.dstCommon.spr_cmn_DocumentByFkID_Select.Select(strFilter)[0];

                //8888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888
                //System.Runtime.Serialization.Formatters.Binary.BinaryFormatter bf = 
                //    new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                //using (var ms = new System.IO.MemoryStream())
                //{
                //    bf.Serialize(ms, e.Cell.Row.Cells["Document"].Value);
                //    System.Drawing.Image returnImage = System.Drawing.Image.FromStream(ms);

                //    byte[] ppjk = ms.ToArray();
                //   img = PublicMethods.ArrayToImage(ppjk);
                //}
                //8888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888


                img = PublicMethods.ArrayToImage(rw.Document);

                // If the file name is not an empty string open it for saving.
                if (saveFileDialog1.FileName != "")
                {
                    // Saves the Image via a FileStream created by the OpenFile method.
                    System.IO.FileStream fs =
                        (System.IO.FileStream)saveFileDialog1.OpenFile();
                    // Saves the Image in the appropriate ImageFormat based upon the
                    // File type selected in the dialog box.
                    // NOTE that the FilterIndex property is one-based.
                    switch (saveFileDialog1.FilterIndex)
                    {
                        case 1:
                            //this.button2.Image.Save(fs, System.Drawing.Imaging.ImageFormat.Jpeg);
                            img.Save(fs, System.Drawing.Imaging.ImageFormat.Jpeg);
                            break;

                        case 2:
                            img.Save(fs,
                              System.Drawing.Imaging.ImageFormat.Bmp);
                            break;

                        case 3:
                            img.Save(fs,
                              System.Drawing.Imaging.ImageFormat.Gif);
                            break;
                    }

                    fs.Close();
                    OnMessage(BaranResources.SaveSuccessful, PublicEnum.EnmMessageCategory.Success);
                }

            }

        }

        private void btnShowLogo_Click(object sender, EventArgs e)
        {
            picLogo.Image = Baran.Classes.Common.PublicMethods.PictureOpenFileDialog();
        }

        #endregion

    }
}
