using Baran.Classes.Common;
using BaranDataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Baran.Source
{
    public partial class frmLand : Baran.Base_Forms.frmSecondChildBase
    {
        #region Constractor

        public frmLand()
        {
            InitializeComponent();
        }

        public frmLand(int landID)
        {
            InitializeComponent();

            LandID = landID;
            this.SetControlsValue();
        }

        #endregion

        #region Variables
        WaiteForm waite;
        UnitOfWork dbContext;

        DialogResult msgResult;

        int UserID = (int)CurrentUser.Instance.UserID;
        int? intSoilTexture = null;
        int? intOwnership = null;
        int? intFeildUseType = null;
        int? intParentCo = null;
        int? intProvinceID = null;
        int? intTownshipID = null;

        string
          strName,
          strAddress,
          strDescription,
          strCity,
          strCode,
          strDocNumber,
          strFutureProgram,
          strDocPlace
          ;

        decimal
          dclUsableArea,
          dclTotalArea
          ;

        Boolean
            blnOpposition,
            blnSalability,
            blnChangeUse;

        #endregion

        #region Propertise

        private int _landID;
        public int LandID
        {
            get
            {
                return _landID;
            }
            set
            {
                _landID = value;
            }
        }

        #endregion

        #region Methods

        public override void OnformLoad()
        {
            base.OnformLoad();
            ComboBoxSetting.FillComboBox(PublicEnum.EnmComboSource.srcPart, cmbParentCo, "");
            ComboBoxSetting.FillComboBox(PublicEnum.EnmComboSource.srcSoilTexture, cmbSoilTexture, "");
            ComboBoxSetting.FillComboBox(PublicEnum.EnmComboSource.srcOwnership, cmbOwnership, "");
            ComboBoxSetting.FillComboBox(PublicEnum.EnmComboSource.srcFieldUseType, cmbFieldUseType, "");
            ComboBoxSetting.FillComboBox(PublicEnum.EnmComboSource.srcProvince, cmbProvince, "");

            btnGeo.Image = System.Drawing.Image.FromFile(PublicMethods.PictureFileNamePath(cnsPictureName.Map64));
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


                 dbContext = new UnitOfWork();
                tbl_src_Land land = new tbl_src_Land()
                {
                    Name = strName,
                    UsableArea = dclUsableArea,
                    TotalArea = dclTotalArea,
                    Fk_SoilTextureID = intSoilTexture,
                    Fk_OwnershipID = intOwnership,
                    Fk_FieldUseTypeID = intFeildUseType,
                    Fk_ProvinceID = intProvinceID,
                    Fk_TownshipID = intTownshipID,
                    City = strCity,
                    Address = strAddress,
                    CreateUserID = UserID,
                    Fk_partID = intParentCo,
                    Description = strDescription,
                    Opposition = blnOpposition,
                    Code = strCode,
                    DocNumber = strDocNumber,
                    Salability = blnSalability,
                    changeUse = blnChangeUse,
                    FutureProgram = strFutureProgram,
                    DocPlace = strDocPlace,
                };


                dbContext.LandRepository.Insert(land);
                dbContext.Save();

                if (land.LandID > 0)
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
            if (LandID <= 0)
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

                dbContext = new UnitOfWork();
                tbl_src_Land land = new tbl_src_Land()
                {
                    Name = strName,
                    UsableArea = dclUsableArea,
                    TotalArea = dclTotalArea,
                    Fk_SoilTextureID = intSoilTexture,
                    Fk_OwnershipID = intOwnership,
                    Fk_FieldUseTypeID = intFeildUseType,
                    Fk_ProvinceID = intProvinceID,
                    Fk_TownshipID = intTownshipID,
                    City = strCity,
                    Address = strAddress,
                    CreateUserID = UserID,
                    Fk_partID = intParentCo,
                    Description = strDescription,
                    Opposition = blnOpposition,
                    Code = strCode,
                    DocNumber = strDocNumber,
                    Salability = blnSalability,
                    changeUse = blnChangeUse,
                    FutureProgram = strFutureProgram,
                    DocPlace = strDocPlace,
                    UpdateUserID = CurrentUser.Instance.UserID,
                    UpdateDate = System.DateTime.Now,
                };


                dbContext.LandRepository.Update(land);
                dbContext.Save();

                OnMessage(BaranResources.EditSuccessful, PublicEnum.EnmMessageCategory.Success);
                waite.Close();
            }
            catch
            {
                OnMessage(BaranResources.DoNotDoPleaseTryAgine, PublicEnum.EnmMessageCategory.Warning);
                waite.Close();
            }
            waite.Close();
        }

        public override void OnDelete()
        {
            base.OnDelete();
            if (LandID <= 0)
            {
                OnMessage(BaranResources.SavedNotLastTime, PublicEnum.EnmMessageCategory.Warning);
                return;
            }

            msgResult = MessageBoxX.ShowMessageBox(PublicEnum.EnmMessageType.msgDeleteConfirm);
            if (msgResult == DialogResult.No) return;
            try
            {
                dbContext = new UnitOfWork();
                tbl_src_Land land = new tbl_src_Land()
                {
                    IsActive = false,
                    InactivationUserID = CurrentUser.Instance.UserID,
                    InactivationDate = System.DateTime.Now,
                };


                dbContext.LandRepository.Update(land);
                dbContext.Save();

                LandID = 0;
                this.OnClear();
                OnMessage(BaranResources.DeleteSuccessful, PublicEnum.EnmMessageCategory.Success);

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
            LandID = 0;
            grdDoc.dstCommon.spr_cmn_DocumentByFkID_Select.Clear();
        }

        public override void OnDoc(int? companyID, int? collectionID, int? subcollectionID, int? partID, int? fieldID, int? warehouseID, int? buildingID, int? machineryID, int? waterID, int? waterStorageID, int? waterTransmissionLineID)
        {
            if (LandID <= 0)
            {
                OnMessage(BaranResources.SavedNotLastTime, PublicEnum.EnmMessageCategory.Warning);
                return;
            }
            base.OnDoc(null, null, null, null, this.LandID, null, null, null, null, null, null);
            this.FillGridDoc();
        }

        private void SetControlsValue()
        {
            BaranDataAccess.Source.dstSource.spr_src_FieldByID_SelectRow drw;

            try
            {
                dbContext = new UnitOfWork();
                tbl_src_Land land = new tbl_src_Land();

                land = dbContext.LandRepository.GetById(LandID);

                if (land != null)
                {
                    txtName.Text = land.Name;
                    txtAddress.Text = land.Address;
                    txtCity.Text = land.City;
                    txtTotalArea.Text = land.TotalArea.ToString();
                    txtUsableArea.Text = land.UsableArea.ToString();
                    txtDescription.Text = land.Description;
                    txtCode.Text = land.Code;
                    txtDocNumber.Text = land.DocNumber;
                    txtFutureProgram.Text = land.FutureProgram;
                    txtDocPlace.Text = land.DocPlace;
                    cmbSoilTexture.Value = land.Fk_SoilTextureID;
                    cmbOwnership.Value = land.Fk_OwnershipID;
                    cmbFieldUseType.Value = land.Fk_FieldUseTypeID;
                    cmbProvince.Value = land.Fk_ProvinceID;
                    cmbTownship.Value = land.Fk_TownshipID;
                    cmbParentCo.Value = land.Fk_partID;
                    //chkOpposition.Checked = land.Opposition  ? false : land.Opposition;
                    //chkChangeUse.Checked = land.changeUse;
                    //chkSalability.Checked = drw.IsSalabilityNull() ? false : drw.Salability;
                }
            }
            catch
            {
                OnMessage(BaranResources.DoNotDoPleaseTryAgine, PublicEnum.EnmMessageCategory.Warning);
            }
        }

        private void SetVariables()
        {
            try
            {
                strName = txtName.Text.Trim();
                strDescription = txtDescription.Text.Trim();
                strCity = txtCity.Text.Trim();
                dclTotalArea = Convert.ToDecimal(txtTotalArea.Text.Trim());
                dclUsableArea = Convert.ToDecimal(txtUsableArea.Text.Trim());

                //decimal d = decimal.Parse(txtTotalArea.Text.Trim(), System.Globalization.CultureInfo.InvariantCulture);
                //Console.WriteLine(d.ToString(System.Globalization.CultureInfo.InvariantCulture));

                strAddress = txtAddress.Text.Trim();
                strCode = txtCode.Text.Trim();
                strDocNumber = txtDocNumber.Text.Trim();
                strFutureProgram = txtFutureProgram.Text.Trim();
                strDocPlace = txtDocPlace.Text.Trim();


                if (cmbParentCo.Value != null)
                    intParentCo = Convert.ToInt32(cmbParentCo.Value);
                if (cmbSoilTexture.Value != null)
                    intSoilTexture = Convert.ToInt32(cmbSoilTexture.Value);
                if (cmbOwnership.Value != null)
                    intOwnership = Convert.ToInt32(cmbOwnership.Value);
                if (cmbFieldUseType.Value != null)
                    intFeildUseType = Convert.ToInt32(cmbFieldUseType.Value);
                if (cmbProvince.Value != null)
                    intProvinceID = Convert.ToInt32(cmbProvince.Value);
                if (cmbTownship.Value != null)
                    intTownshipID = Convert.ToInt32(cmbTownship.Value);

                blnOpposition = chkOpposition.Checked;
                blnChangeUse = chkChangeUse.Checked;
                blnSalability = chkSalability.Checked;
            }
            catch
            {
                OnMessage(BaranResources.DoNotDoPleaseTryAgine, PublicEnum.EnmMessageCategory.Warning);
            }
        }

        private bool ControlsValidation()
        {
            bool blnResult = true;

            if (txtName.Text.Trim() == string.Empty)
            {
                txtName.Focus();
                blnResult = false;
            }
            else if (txtTotalArea.Text.Trim() == string.Empty)
            {
                txtTotalArea.Focus();
                blnResult = false;

            }
            else if (txtUsableArea.Text.Trim() == string.Empty)
            {
                txtUsableArea.Focus();
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
            else if (cmbSoilTexture.Value == null)
            {
                cmbSoilTexture.Focus();
                blnResult = false;
            }
            else if (cmbOwnership.Value == null)
            {
                cmbOwnership.Focus();
                blnResult = false;
            }
            else if (cmbFieldUseType.Value == null)
            {
                cmbFieldUseType.Focus();
                blnResult = false;
            }
            else if (cmbParentCo.Value == null)
            {
                cmbParentCo.Focus();
                blnResult = false;
            }

            return blnResult;
        }

        private void FillGridDoc()
        {
            this.Height = this.Height - grdDoc.Height;
            if (LandID > 0)
            {
                BaranDataAccess.Common.dstCommonTableAdapters.spr_cmn_DocumentByFkID_SelectTableAdapter adp =
                    new BaranDataAccess.Common.dstCommonTableAdapters.spr_cmn_DocumentByFkID_SelectTableAdapter();

                try
                {
                    adp.FillDocumentByFkIDTable(grdDoc.dstCommon.spr_cmn_DocumentByFkID_Select, null, null, null, null, this.LandID, null, null, null, null, null, null);

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

        private void btnGeo_Click(object sender, EventArgs e)
        {
            if (LandID <= 0)
            {
                OnMessage(BaranResources.SavedNotLastTime, PublicEnum.EnmMessageCategory.Warning);
                return;
            }

            Baran.Maps.frmBaseMap ofrm = new Maps.frmBaseMap(PublicEnum.EnmShapeType.Polygon);
            ofrm.FieldID = LandID;
            ofrm.ShowDialog();
        }

        private void cmbProvince_ValueChanged(object sender, EventArgs e)
        {
            cmbTownship.Value = null;
            ComboBoxSetting.FillComboBox(PublicEnum.EnmComboSource.srcTownship, cmbTownship, Convert.ToString(cmbProvince.Value));
        }

        private void grdDoc_ClickCellButton(object sender, Infragistics.Win.UltraWinGrid.CellEventArgs e)
        {
            if (e.Cell.Column.Key == "Update")
            {
                try
                {
                    Baran.Common.frmDocument ofrm = new Common.frmDocument((int)e.Cell.Row.Cells[grdDoc.dstCommon.spr_cmn_Document_Select.DocumentIDColumn.ColumnName].Value);
                    ofrm.FieldID = this.LandID;
                    ofrm.FormType = cnsFormType.Change;
                    ofrm.ShowDialog();

                    this.FillGridDoc();
                }
                catch
                {
                    OnMessage(BaranResources.DoNotDoPleaseTryAgine, PublicEnum.EnmMessageCategory.Warning);
                }
            }
        }

        #endregion
    }
}
