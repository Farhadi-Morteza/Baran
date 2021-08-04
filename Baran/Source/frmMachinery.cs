using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Baran.Classes.Common;
using BaranDataAccess;

namespace Baran.Source
{
    public partial class frmMachinery : Baran.Base_Forms.frmSecondChildBase
    {
        #region Constractor

        public frmMachinery()
        {
            InitializeComponent();
     
        }

        public frmMachinery( int machineryID)
        {
            InitializeComponent();
            MachineryID = machineryID;
            this.SetControlsValue();
      
        }


        #endregion

        #region Variables
        WaiteForm waite;
        BaranDataAccess.UnitOfWork db = new BaranDataAccess.UnitOfWork();

        BaranDataAccess.Source.dstSourceTableAdapters.spr_src_Machinery_SelectTableAdapter adp =
            new BaranDataAccess.Source.dstSourceTableAdapters.spr_src_Machinery_SelectTableAdapter();
        BaranDataAccess.Source.dstSource dst;
        DialogResult msgResult;

        int UserID = (int)CurrentUser.Instance.UserID;

        int? intParentCo = null;
        int intMachineryCategory;
        int? intCount = null;

        string
          strName,
          strManufacturer,
          strModel,
          strRegNumber,
          strYear,
          strDescription
          ;

        decimal dclVigor = 0;

        #endregion

        #region Propertise

        private int _MachineryID;
        public int MachineryID
        {
            get
            {
                return _MachineryID;
            }
            set
            {
                _MachineryID = value;
            }
        }

        #endregion

        #region Methods

        public override void OnformLoad()
        {
            base.OnformLoad();
            ComboBoxSetting.FillComboBox(PublicEnum.EnmComboSource.srcMachineryCategory, cmbMachineryCategory, "");
            ComboBoxSetting.FillComboBox(PublicEnum.EnmComboSource.srcPart, cmbParentCo, "");

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


            //if (MachineryID > 0)
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

                tbl_src_Machinery machinery = new tbl_src_Machinery()
                {
                    Name = strName, Manufacturer = strManufacturer, Model = strModel, RegNumber = strRegNumber, Year = strYear, Description = strDescription
                    , MachineryID = intMachineryCategory, Count = intCount, Fk_PartID = intParentCo, Vigor = dclVigor, IsActive = true, CreateUserID = UserID, CreateDate = System.DateTime.Now
                };
                db.MachineryRepository.Insert(machinery);
                db.Save();
                MachineryID = machinery.MachineryID;

                //MachineryID = Convert.ToInt32(adp.New_Machinery_Insert(strName, strManufacturer, strModel, strRegNumber, strYear, strDescription
                //                                , intMachineryCategory, UserID, intCount, intParentCo, dclVigor));

                //if (MachineryID > 0)
                //{
                    OnMessage(BaranResources.SaveSuccessful, PublicEnum.EnmMessageCategory.Success);
                //}
                //else
                //    OnMessage(BaranResources.SaveFail, PublicEnum.EnmMessageCategory.Warning);
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
            if (MachineryID <= 0)
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

                tbl_src_Machinery machinery = new tbl_src_Machinery();
                machinery = db.MachineryRepository.GetById(MachineryID);
                if (machinery != null)
                {
                    machinery.Name = strName;
                    machinery.Manufacturer = strManufacturer;
                    machinery.Model = strModel;
                    machinery.RegNumber = strRegNumber;
                    machinery.Year = strYear;
                    machinery.Description = strDescription;
                    machinery.Fk_MachineryCategoryID = intMachineryCategory;
                    machinery.Count = intCount;
                    machinery.Fk_PartID = intParentCo;
                    machinery.Vigor = dclVigor;
                    machinery.UpdateUserID = UserID;
                    machinery.UpdateDate = System.DateTime.Now;
                }

                //int RowAffected = Convert.ToInt32(adp.Update(MachineryID, strName, strManufacturer, strModel, strRegNumber, strYear
                //                            , strDescription, intMachineryCategory, UserID, intCount, intParentCo, dclVigor));

                //if (RowAffected > 0)
                //{
                    OnMessage(BaranResources.EditSuccessful, PublicEnum.EnmMessageCategory.Success);
                //}
                //else
                //    OnMessage(BaranResources.EditFail, PublicEnum.EnmMessageCategory.Warning);
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

            if (MachineryID <= 0)
            {
                OnMessage(BaranResources.SavedNotLastTime, PublicEnum.EnmMessageCategory.Warning);
                return;
            }

            msgResult = MessageBoxX.ShowMessageBox(PublicEnum.EnmMessageType.msgDeleteConfirm);
            if (msgResult == DialogResult.No) return;
            try
            {
                int RowAffected = (int)adp.Delete(MachineryID, UserID);
                if (RowAffected > 0)
                {
                    MachineryID = 0;
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
            MachineryID = 0;
            grdDoc.dstCommon.spr_cmn_DocumentByFkID_Select.Clear();

        }

        public override void OnDoc(int? companyID, int? collectionID, int? subcollectionID, int? partID, int? landID, int? fieldID, int? warehouseID, int? buildingID, int? machineryID, int? waterID, int? waterStorageID, int? waterTransmissionLineID)
        {
            if (MachineryID <= 0)
            {
                OnMessage(BaranResources.SavedNotLastTime, PublicEnum.EnmMessageCategory.Warning);
                return;
            }
            base.OnDoc(null, null, null, null, null,null, null, null, this.MachineryID, null, null, null);
            this.FillGridDoc();
        }

        private void SetControlsValue()
        {
            BaranDataAccess.Source.dstSource.spr_src_MachineryByID_SelectRow drw;
            try
            {
                dst = BaranDataAccess.Source.dstSource.MachineryByIDTable(MachineryID);
                drw = dst.spr_src_MachineryByID_Select[0];

                txtName.Text = drw.IsNameNull() ? string.Empty : drw.Name;
                txtManufacturer.Text = drw.IsManufacturerNull() ? string.Empty : drw.Manufacturer;
                txtYear.Text = drw.IsYearNull() ? string.Empty : drw.Year;
                txtModel.Text = drw.IsModelNull() ? string.Empty : drw.Model;
                txtRegNumber.Text = drw.IsRegNumberNull() ? string.Empty : drw.RegNumber;
                txtCount.Text = drw.IsCountNull() ? string.Empty : drw.Count.ToString();
                txtDescription.Text = drw.IsDescriptionNull() ? string.Empty : drw.Description;
                txtVigor.Text = drw.IsVigorNull() ? string.Empty : drw.Vigor.ToString();
                cmbMachineryCategory.Value = drw.IsFk_MachineryCategoryIDNull() ? -1 : drw.Fk_MachineryCategoryID;
                cmbParentCo.Value = drw.IsFk_SubCollectionIDNull() ? -1 : drw.Fk_SubCollectionID;
            }
            catch
            {
                OnMessage(BaranResources.DoNotDoPleaseTryAgine, PublicEnum.EnmMessageCategory.Warning);
            }



        }

        private void SetVariables()
        {
            strName = txtName.Text.Trim();
            strManufacturer = txtManufacturer.Text.Trim();
            strYear = txtYear.Text.Trim();
            strModel = txtModel.Text.Trim();
            intCount = Convert.ToInt32(txtCount.Text.Trim());
            strRegNumber = txtRegNumber.Text.Trim();
            strDescription = txtDescription.Text.Trim();

            if (cmbMachineryCategory.Value != null)
                intMachineryCategory = Convert.ToInt32(cmbMachineryCategory.Value);
            if (cmbParentCo.Value != null)
                intParentCo = Convert.ToInt32(cmbParentCo.Value);
            if (txtVigor.Text != string.Empty)
                dclVigor = Convert.ToDecimal(txtVigor.Text.Trim());
        }

        private bool ControlsValidation()
        {
            bool blnResult = true;

            if (txtName.Text.Trim() == string.Empty)
            {
                txtName.Focus();
                blnResult = false;
            }
            else if (cmbMachineryCategory.SelectedItem == null)
            {
                cmbMachineryCategory.Focus();
                blnResult = false;

            }
            else if (txtCount.Text.Trim() == string.Empty)
            {
                txtCount.Focus();
                blnResult = false;

            }
            else if (txtVigor.Text.Trim() == string.Empty)
            {
                txtVigor.Focus();
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
            if (MachineryID > 0)
            {
                BaranDataAccess.Common.dstCommonTableAdapters.spr_cmn_DocumentByFkID_SelectTableAdapter adp =
                    new BaranDataAccess.Common.dstCommonTableAdapters.spr_cmn_DocumentByFkID_SelectTableAdapter();

                try
                {
                    adp.FillDocumentByFkIDTable(grdDoc.dstCommon.spr_cmn_DocumentByFkID_Select, null, null, null, null, null, null, null, null, this.MachineryID, null, null, null);

                    if (grdDoc.dstCommon.spr_cmn_DocumentByFkID_Select.Count > 0 && grdDoc.dstCommon.spr_cmn_DocumentByFkID_Select.Count <= cnsgrdDoc.MaxRowCount)
                    {
                        this.Height = this.Height + cnsgrdDoc.Margin + (grdDoc.dstCommon.spr_cmn_DocumentByFkID_Select.Count * (grdDoc.DisplayLayout.Override.MinRowHeight));
                    }
                    else if (grdDoc.dstCommon.spr_cmn_DocumentByFkID_Select.Count > 0 && grdDoc.dstCommon.spr_cmn_DocumentByFkID_Select.Count > cnsgrdDoc.MaxRowCount)
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

        private void grdDoc_ClickCellButton(object sender, Infragistics.Win.UltraWinGrid.CellEventArgs e)
        {
        if (e.Cell.Column.Key == "Update")
            {
                try
                {
                    Baran.Common.frmDocument ofrm = new Common.frmDocument((int)e.Cell.Row.Cells[grdDoc.dstCommon.spr_cmn_Document_Select.DocumentIDColumn.ColumnName].Value);
                    ofrm.MachineryID = this.MachineryID;
                    ofrm.ShowDialog();

                    this.FillGridDoc();
                }
                catch (Exception)
                {

                    throw;
                }
            }           
        }

        #endregion

    }
}
