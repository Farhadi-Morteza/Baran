using Baran.Classes.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Baran.Source
{
    public partial class frmField : Baran.Base_Forms.frmSecondChildBase
    {
        #region Constractor

        public frmField()
        {
            InitializeComponent();
        }

        public frmField(int fieldID)
        {
            InitializeComponent();

            FieldID = fieldID;
            this.SetControlsValue();
        }

        #endregion

        #region Variables
        WaiteForm waite;

        BaranDataAccess.Source.dstSource dst;
        BaranDataAccess.Source.dstSourceTableAdapters.spr_src_Field_SelectTableAdapter adp =
            new BaranDataAccess.Source.dstSourceTableAdapters.spr_src_Field_SelectTableAdapter();


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

        private int _FieldID;
        public int FieldID
        {
            get
            {
                return _FieldID;
            }
            set
            {
                _FieldID = value;
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

            BaranDataAccess.AMSEntities db = new BaranDataAccess.AMSEntities();

            var list = db.tbl_src_Field.ToList();

            //if (FieldID > 0)
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
                FieldID = Convert.ToInt32(adp.New_Field_Insert(strName, dclUsableArea, dclTotalArea, intSoilTexture, intOwnership
                                                             , intFeildUseType, intProvinceID, intTownshipID, strCity, strAddress, UserID, intParentCo, strDescription, blnOpposition
                                                             , strCode, strDocNumber, blnSalability, blnChangeUse, strFutureProgram, strDocPlace));

                if (FieldID > 0)
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
            if (FieldID <= 0)
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
                int RowAffected = Convert.ToInt32(adp.Update(FieldID, strName, dclUsableArea, dclTotalArea, intSoilTexture, intOwnership
                                                            , intFeildUseType, intProvinceID, intTownshipID, strCity, strAddress, UserID, intParentCo, strDescription, blnOpposition
                                                            , strCode, strDocNumber, blnSalability, blnChangeUse, strFutureProgram, strDocPlace));
                if (RowAffected > 0)
                {
                    OnMessage(BaranResources.EditSuccessful, PublicEnum.EnmMessageCategory.Success);
                    waite.Close();
                }
                else
                {
                    OnMessage(BaranResources.EditFail, PublicEnum.EnmMessageCategory.Warning);
                    waite.Close();
                }
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
            if (FieldID <= 0)
            {
                OnMessage(BaranResources.SavedNotLastTime, PublicEnum.EnmMessageCategory.Warning);
                return;
            }

            msgResult = MessageBoxX.ShowMessageBox(PublicEnum.EnmMessageType.msgDeleteConfirm);
            if (msgResult == DialogResult.No) return;
            try
            {
                int RowAffected = (int)adp.Delete(FieldID, UserID);
                if (RowAffected > 0)
                {
                    FieldID = 0;
                    this.OnClear();
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
            FieldID = 0;
            grdDoc.dstCommon.spr_cmn_DocumentByFkID_Select.Clear();
        }

        public override void OnDoc(int? companyID, int? collectionID, int? subcollectionID, int? partID, int? fieldID, int? warehouseID, int? buildingID, int? machineryID, int? waterID, int? waterStorageID, int? waterTransmissionLineID)
        {
            if (FieldID <= 0)
            {
                OnMessage(BaranResources.SavedNotLastTime, PublicEnum.EnmMessageCategory.Warning);
                return;
            }
            base.OnDoc(null, null, null, null, this.FieldID, null, null, null, null, null, null);
            this.FillGridDoc();
        }

        private void SetControlsValue()
        {
            BaranDataAccess.Source.dstSource.spr_src_FieldByID_SelectRow drw;

            try
            {
                dst = BaranDataAccess.Source.dstSource.FieldByIDTable(FieldID);
                drw = dst.spr_src_FieldByID_Select[0];

                txtName.Text = drw.Name;
                txtAddress.Text = drw.IsAddressNull() ? string.Empty : drw.Address;
                txtCity.Text = drw.IsCityNull() ? string.Empty : drw.City;
                txtTotalArea.Text = drw.IsTotalAreaNull() ? string.Empty : drw.TotalArea.ToString();
                txtUsableArea.Text = drw.IsUsableAreaNull() ? string.Empty : drw.UsableArea.ToString();
                txtDescription.Text = drw.IsDescriptionNull() ? string.Empty : drw.Description;
                txtCode.Text = drw.IsCodeNull() ? string.Empty : drw.Code;
                txtDocNumber.Text = drw.IsDocNumberNull() ? string.Empty : drw.DocNumber;
                txtFutureProgram.Text = drw.IsFutureProgramNull() ? string.Empty : drw.FutureProgram;
                txtDocPlace.Text = drw.IsDocPlaceNull() ? string.Empty : drw.DocPlace;
                cmbSoilTexture.Value = drw.IsFk_SoilTextureIDNull() ? 0 : drw.Fk_SoilTextureID;
                cmbOwnership.Value = drw.IsFk_OwnershipIDNull() ? -1 : drw.Fk_OwnershipID;
                cmbFieldUseType.Value = drw.IsFk_FieldUseTypeIDNull() ? -1 : drw.Fk_FieldUseTypeID;
                cmbProvince.Value = drw.IsFk_ProvinceIDNull() ? -1 : drw.Fk_ProvinceID;
                cmbTownship.Value = drw.IsFk_TownshipIDNull() ? -1 : drw.Fk_TownshipID;

                if (drw.IsFk_partIDNull())
                    cmbParentCo.Value = null;
                else
                    cmbParentCo.Value = drw.Fk_partID;

                chkOpposition.Checked = drw.IsOppositionNull() ? false : drw.Opposition;
                chkChangeUse.Checked = drw.IschangeUseNull() ? false : drw.changeUse;
                chkSalability.Checked = drw.IsSalabilityNull() ? false : drw.Salability;
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
            if (FieldID > 0)
            {
                BaranDataAccess.Common.dstCommonTableAdapters.spr_cmn_DocumentByFkID_SelectTableAdapter adp =
                    new BaranDataAccess.Common.dstCommonTableAdapters.spr_cmn_DocumentByFkID_SelectTableAdapter();

                try
                {
                    adp.FillDocumentByFkIDTable(grdDoc.dstCommon.spr_cmn_DocumentByFkID_Select, null, null, null, null, this.FieldID, null, null, null, null, null, null);

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
            if (FieldID <= 0)
            {
                OnMessage(BaranResources.SavedNotLastTime, PublicEnum.EnmMessageCategory.Warning);
                return;
            }

            Baran.Maps.frmBaseMap ofrm = new Maps.frmBaseMap(PublicEnum.EnmShapeType.Polygon);
            ofrm.FieldID = FieldID;
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
                    ofrm.FieldID = this.FieldID;
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
