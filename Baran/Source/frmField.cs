using Baran.Classes.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BaranDataAccess;

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
        BaranDataAccess.UnitOfWork dbContext;

        DialogResult msgResult;

        int UserID = (int)CurrentUser.Instance.UserID;
        int? intSoilTexture = null;
        int? intOwnership = null;
        int? intFeildUseType = null;
        int? intLandID = null;
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
            ComboBoxSetting.FillComboBox(PublicEnum.EnmComboSource.srcLand, cmbLand, "");
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
                BaranDataAccess.tbl_src_Field field = new tbl_src_Field()
                {
                    Name = strName,
                    UsableArea = dclUsableArea,
                    TotalArea = dclTotalArea,
                    Fk_SoilTextureID = intSoilTexture,
                    CreateUserID = UserID,
                    CreateDate = System.DateTime.Now,
                    Fk_LandID = intLandID,
                    IsActive = true, 
                    Code = strCode, 
                    Description = strDescription,
                };

                dbContext.FieldRepository.Insert(field);
                dbContext.Save();
                this.DialogResult = DialogResult.OK;

                OnMessage(BaranResources.SaveSuccessful, PublicEnum.EnmMessageCategory.Success);
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

                dbContext = new UnitOfWork();
                BaranDataAccess.tbl_src_Field field = new tbl_src_Field();
                field = dbContext.FieldRepository.GetById(FieldID);

                field.Name = strName;
                field.UsableArea = dclUsableArea;
                field.TotalArea = dclTotalArea;
                field.Fk_SoilTextureID = intSoilTexture;
                field.UpdateUserID = UserID;
                field.UpdateDate = System.DateTime.Now;
                field.Fk_LandID = intLandID;
                field.Code = strCode;

                dbContext.FieldRepository.Update(field);
                dbContext.Save();
                this.DialogResult = DialogResult.OK;

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
            if (FieldID <= 0)
            {
                OnMessage(BaranResources.SavedNotLastTime, PublicEnum.EnmMessageCategory.Warning);
                return;
            }

            msgResult = MessageBoxX.ShowMessageBox(PublicEnum.EnmMessageType.msgDeleteConfirm);
            if (msgResult == DialogResult.No) return;
            try
            {
                dbContext = new UnitOfWork();
                BaranDataAccess.tbl_src_Field field = new tbl_src_Field();
                field = dbContext.FieldRepository.GetById(FieldID);

                field.IsActive = false;
                field.InactivationUserID = UserID;
                field.InactivationDate = System.DateTime.Now;

                dbContext.FieldRepository.Update(field);
                dbContext.Save();
                this.DialogResult = DialogResult.OK;

                OnMessage(BaranResources.DeleteSuccessful, PublicEnum.EnmMessageCategory.Success);
                waite.Close();
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
            dbContext = new UnitOfWork();
            tbl_src_Field field = new tbl_src_Field();

            field = dbContext.FieldRepository.GetById(FieldID);

            if (field != null)
            {
                txtName.Text = field.Name;
                txtAddress.Text = field.Address;
                //txtCity.Text = field.City;
                txtTotalArea.Text = field.TotalArea.ToString();
                txtUsableArea.Text = field.UsableArea.ToString();
                txtDescription.Text = field.Description;
                txtCode.Text = field.Code;
                //txtDocNumber.Text = field.DocNumber;
                //txtFutureProgram.Text = field.FutureProgram;
                //txtDocPlace.Text = field.DocPlace;
                cmbSoilTexture.Value = field.Fk_SoilTextureID;
                //cmbOwnership.Value = field.Fk_OwnershipID;
                cmbFieldUseType.Value = field.Fk_FieldUseTypeID;
                //cmbProvince.Value = field.Fk_ProvinceID;
                //cmbTownship.Value = field.Fk_TownshipID;
                cmbLand.Value = field.Fk_LandID;
                //chkOpposition.Checked = land.Opposition  ? false : land.Opposition;
                //chkChangeUse.Checked = land.changeUse;
                //chkSalability.Checked = drw.IsSalabilityNull() ? false : drw.Salability;
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


                if (cmbLand.Value != null)
                    intLandID = Convert.ToInt32(cmbLand.Value);
                if (cmbSoilTexture.Value != null)
                    intSoilTexture = Convert.ToInt32(cmbSoilTexture.Value);
                //if (cmbOwnership.Value != null)
                //    intOwnership = Convert.ToInt32(cmbOwnership.Value);
                if (cmbFieldUseType.Value != null)
                    intFeildUseType = Convert.ToInt32(cmbFieldUseType.Value);
                //if (cmbProvince.Value != null)
                //    intProvinceID = Convert.ToInt32(cmbProvince.Value);
                //if (cmbTownship.Value != null)
                //    intTownshipID = Convert.ToInt32(cmbTownship.Value);

                //blnOpposition = chkOpposition.Checked;
                //blnChangeUse = chkChangeUse.Checked;
                //blnSalability = chkSalability.Checked;
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
            //else if (cmbProvince.Value == null)
            //{
            //    cmbProvince.Focus();
            //    blnResult = false;
            //}
            //else if (cmbTownship.Value == null)
            //{
            //    cmbTownship.Focus();
            //    blnResult = false;
            //}
            else if (cmbSoilTexture.Value == null)
            {
                cmbSoilTexture.Focus();
                blnResult = false;
            }
            //else if (cmbOwnership.Value == null)
            //{
            //    cmbOwnership.Focus();
            //    blnResult = false;
            //}
            //else if (cmbFieldUseType.Value == null)
            //{
            //    cmbFieldUseType.Focus();
            //    blnResult = false;
            //}
            else if (cmbLand.Value == null)
            {
                cmbLand.Focus();
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
