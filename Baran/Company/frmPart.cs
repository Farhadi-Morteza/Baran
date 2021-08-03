using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Baran.Classes.Common;

namespace Baran.Company
{
    public partial class frmPart : Baran.Base_Forms.frmSecondChildBase
    {

        #region Constractor

        public frmPart()
        {
            InitializeComponent();
              
        }

        public frmPart(BaranDataAccess.Company.dstCompany dstCompany, int partID)
        {
            InitializeComponent();

            dst = dstCompany;
            PartID = partID;

            this.SetControlsValue();
              
        }

        #endregion

        #region Variables
        WaiteForm waite;

        BaranDataAccess.Company.dstCompanyTableAdapters.spr_src_Part_SelectTableAdapter adp =
            new BaranDataAccess.Company.dstCompanyTableAdapters.spr_src_Part_SelectTableAdapter();
        BaranDataAccess.Company.dstCompany dst;
        BaranDataAccess.Company.dstCompany.spr_src_Part_SelectRow drw;

        DialogResult msgResult;

        byte[] Logo;
        int UserID = (int)CurrentUser.Instance.UserID;
        int? intProvinceID = null;
        int? intTownshipID = null;
        int? intCompanyCategory = null;
        int? intCompanyID = null;
        int? intParntCo = null;

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

        private int _PartID;
        public int PartID
        {
            get
            {
                return _PartID;
            }
            set
            {
                _PartID = value;
            }
        }

        #endregion

        #region Methods

        public override void OnformLoad()
        {
            base.OnformLoad();
            ComboBoxSetting.FillComboBox(PublicEnum.EnmComboSource.srcProvince, cmbProvince, "");
            ComboBoxSetting.FillComboBox(PublicEnum.EnmComboSource.srcSubcollection, cmbParentCo, "");

            btnGeo.BackgroundImage = System.Drawing.Image.FromFile(PublicMethods.PictureFileNamePath(cnsPictureName.Map64));
            //EnableButtons(cnschildBaseButtonsName.Cancel, cnschildBaseButtonsName.Save, cnschildBaseButtonsName.Change, cnschildBaseButtonsName.Delete, cnschildBaseButtonsName.Clear, cnschildBaseButtonsName.Doc);

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
            //if (PartID > 0)
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
                PartID = Convert.ToInt32(adp.New_Part_Insert(
                    strName, strEconomicCode, strRegistrationNumber, strNationalID, strPostalCode, intProvinceID, intTownshipID,
                    strCity, strAddress, strWebSite, strEmail, strTelephone1, strMobile1, strTelephone2, strMobile2, strFax, strDescription, intCompanyCategory,
                    Logo, UserID, intParntCo));

                if (PartID > 0)
                {
                    OnMessage(BaranResources.SaveSuccessful, PublicEnum.EnmMessageCategory.Success);
                    
                }
                else
                {
                    OnMessage(BaranResources.SaveFail, PublicEnum.EnmMessageCategory.Warning);
                    
                }
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
            if (PartID <= 0)
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



                int RowAffected = Convert.ToInt32(adp.Update(
                    PartID, strName, strEconomicCode, strRegistrationNumber, strNationalID, strPostalCode, intProvinceID, intTownshipID,
                    strCity, strAddress, strWebSite, strEmail, strTelephone1, strMobile1, strTelephone2, strMobile2, strFax, strDescription, intCompanyCategory,
                    Logo, UserID, intParntCo));

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

            if (PartID <= 0)
            {
                OnMessage(BaranResources.SavedNotLastTime, PublicEnum.EnmMessageCategory.Warning);
                return;
            }

            msgResult = MessageBoxX.ShowMessageBox(PublicEnum.EnmMessageType.msgDeleteConfirm);
            if (msgResult == DialogResult.No) return;
            try
            {
                int RowAffected = (int)adp.Delete(PartID, UserID);
                if (RowAffected > 0)
                {
                    PartID = 0;
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

            Baran.Classes.Common.ControlsSetting.ClearControls(grpControls.Controls);
            PartID = 0;
            grdDoc.dstCommon.spr_cmn_DocumentByFkID_Select.Merge(null);
        }

        public override void OnDoc(int? companyID, int? collectionID, int? subcollectionID, int? partID, int? fieldID, int? warehouseID, int? buildingID, int? machineryID, int? waterID, int? waterStorageID, int? waterTransmissionLineID)
        {
            if (PartID <= 0)
            {
                OnMessage(BaranResources.SavedNotLastTime, PublicEnum.EnmMessageCategory.Warning);
                return;
            }
            base.OnDoc(null, null, null, this.PartID, null, null, null, null, null, null, null);
            this.FillGridDoc();
        }

        private void SetControlsValue()
        {
            if (dst == null) return;

            drw = (BaranDataAccess.Company.dstCompany.spr_src_Part_SelectRow)dst.spr_src_Part_Select.Select("PartID = " + PartID)[0];

            txtName.Text = drw.Name;
            txtPostalCode.Text = drw.IsPostalCodeNull() ? string.Empty : drw.PostalCode;
            cmbProvince.Value = drw.IsFk_ProvinceIDNull() ? -1 : drw.Fk_ProvinceID;
            cmbTownship.Value = drw.IsFk_TownshipIDNull() ? -1 : drw.Fk_TownshipID;
            txtAddress.Text = drw.IsAddressNull() ? string.Empty : drw.Address;
            txtTelephone1.Text = drw.IsTelephone1Null() ? string.Empty : drw.Telephone1;
            txtTelephone2.Text = drw.IsTelephone2Null() ? string.Empty : drw.Telephone2;
            txtMobile1.Text = drw.IsMobile1Null() ? string.Empty : drw.Mobile1;
            txtMobile2.Text = drw.IsMobile2Null() ? string.Empty : drw.Mobile2;
            txtFax.Text = drw.IsFaxNull() ? string.Empty : drw.Fax;
            txtEmail.Text = drw.IsEmailNull() ? string.Empty : drw.Email;
            txtWebSite.Text = drw.IsWebSiteNull() ? string.Empty : drw.WebSite;
            txtDescription.Text = drw.IsDescriptionNull() ? string.Empty : drw.Description;
            txtCity.Text = drw.IsCityNull() ? string.Empty : drw.City;
            cmbParentCo.Value = drw.Fk_SubcollectionID;
        }

        private void SetVariables()
        {
            strName = txtName.Text.Trim();
            strPostalCode = txtPostalCode.Text.Trim();
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

            if (cmbProvince.Value != null)
                intProvinceID = Convert.ToInt32(cmbProvince.Value);
            if (cmbTownship.Value != null)
                intTownshipID = Convert.ToInt32(cmbTownship.Value);
            if (cmbParentCo.Value != null)
                intParntCo = Convert.ToInt32(cmbParentCo.Value);
        }

        private bool ControlsValidation()
        {
            bool blnResult = true;

            if (cmbParentCo.Value == null)
            {
                cmbParentCo.Focus();
                blnResult = false;
            }
            else if (txtName.Text.Trim() == string.Empty)
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
            if (PartID > 0)
            {
                BaranDataAccess.Common.dstCommonTableAdapters.spr_cmn_DocumentByFkID_SelectTableAdapter adp =
                    new BaranDataAccess.Common.dstCommonTableAdapters.spr_cmn_DocumentByFkID_SelectTableAdapter();

                try
                {
                    adp.FillDocumentByFkIDTable(grdDoc.dstCommon.spr_cmn_DocumentByFkID_Select, null, null, null, this.PartID, null, null, null, null, null, null, null);

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

        private void btnGeo_Click(object sender, EventArgs e)
        {
            Baran.Maps.frmBaseMap ofrm = new Maps.frmBaseMap(PublicEnum.EnmShapeType.Polygon);
            ofrm.PartID = PartID;
            ofrm.ShowDialog();
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

                    int RowAffected = (int)adp.Delete((int)e.Cell.Row.Cells[grdDoc.dstCommon.spr_cmn_DocumentByFkID_Select.DocumentIDColumn.ColumnName].Value, (int)CurrentUser.Instance.UserID);

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
                    ofrm.PartID = this.PartID;
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

                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Filter = "JPeg Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif";
                saveFileDialog1.Title = "Save an Image File";
                saveFileDialog1.ShowDialog();

                BaranDataAccess.Common.dstCommon.spr_cmn_DocumentByFkID_SelectRow rw;
                string strFilter = "DocumentID = " + (int)e.Cell.Row.Cells["DocumentID"].Value;
                rw = (BaranDataAccess.Common.dstCommon.spr_cmn_DocumentByFkID_SelectRow)grdDoc.dstCommon.spr_cmn_DocumentByFkID_Select.Select(strFilter)[0];

                img = PublicMethods.ArrayToImage(rw.Document);

                if (saveFileDialog1.FileName != "")
                {
                    System.IO.FileStream fs =
                        (System.IO.FileStream)saveFileDialog1.OpenFile();

                    switch (saveFileDialog1.FilterIndex)
                    {
                        case 1:
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

        #endregion

    }
}
