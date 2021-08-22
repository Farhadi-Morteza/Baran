using Baran.Classes.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BaranDataAccess;

namespace Baran.Source
{
    public partial class frmBuildings : Baran.Base_Forms.frmSecondChildBase
    {
        #region Constractor

        public frmBuildings()
        {
            InitializeComponent();
              
        }

        public frmBuildings(int buildingID)
        {
            InitializeComponent();

            BuildingsID = buildingID;
            this.SetControlsValue();
              
        }

        #endregion

        #region Variables
        WaiteForm waite;
        BaranDataAccess.UnitOfWork dbContext;

        BaranDataAccess.Source.dstSourceTableAdapters.spr_src_Buildings_SelectTableAdapter adp =
            new BaranDataAccess.Source.dstSourceTableAdapters.spr_src_Buildings_SelectTableAdapter();
        BaranDataAccess.Source.dstSource dst;
        BaranDataAccess.Source.dstSource.spr_src_Buildings_SelectRow drw;
        DialogResult msgResult;

        int UserID = (int)CurrentUser.Instance.UserID;

        int? intParentCo = null;
        int? intBuildingsCategory = null;

        string
          strName,
          strDescription
          ;

        decimal
            dclArea;

        #endregion

        #region Propertise

        private int _BuildingsID;
        public int BuildingsID
        {
            get
            {
                return _BuildingsID;
            }
            set
            {
                _BuildingsID = value;
            }
        }

        #endregion

        #region Methods

        public override void OnformLoad()
        {
            base.OnformLoad();
            ComboBoxSetting.FillComboBox(PublicEnum.EnmComboSource.srcBuildingsCategory, cmbBuildingsCategory, "");
            ComboBoxSetting.FillComboBox(PublicEnum.EnmComboSource.srcPart, cmbParentCo, "");

            btnGeo.Image = btnPrint.Image = System.Drawing.Image.FromFile(PublicMethods.PictureFileNamePath(cnsPictureName.Map64));
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

            //if (BuildingsID > 0)
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

                dbContext = new UnitOfWork();
                tbl_src_Buildings building = new tbl_src_Buildings()
                {
                    Name = strName,
                    Area = dclArea,
                    Fk_BuildingsCategoryID = intBuildingsCategory,
                    Fk_PartID = intParentCo,
                    Description = strDescription,
                    CreateUserID = UserID,
                    CreateDate = System.DateTime.Now,
                    IsActive = true
                };

                dbContext.BuildingsRepository.Insert(building);
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

            if (BuildingsID <= 0)
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

                BaranDataAccess.UnitOfWork db = new BaranDataAccess.UnitOfWork();

                tbl_src_Buildings buildings = new tbl_src_Buildings();

                buildings = db.BuildingsRepository.GetById(BuildingsID);

                buildings.Name = strName;
                buildings.Area = dclArea;
                buildings.Fk_BuildingsCategoryID = intBuildingsCategory;
                buildings.Fk_PartID = intParentCo;
                buildings.UpdateUserID = UserID;
                buildings.Description = strDescription;
                buildings.UpdateDate = System.DateTime.Now;

                db.BuildingsRepository.Update(buildings);
                db.Save();

                //int RowAffected = Convert.ToInt32(adp.Update(BuildingsID, strName, dclArea, intBuildingsCategory, intParentCo, UserID, strDescription));

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

            if (BuildingsID <= 0)
            {
                OnMessage(BaranResources.SavedNotLastTime, PublicEnum.EnmMessageCategory.Warning);
                return;
            }

            msgResult = MessageBoxX.ShowMessageBox(PublicEnum.EnmMessageType.msgDeleteConfirm);
            if (msgResult == DialogResult.No) return;
            try
            {
                BaranDataAccess.UnitOfWork db = new BaranDataAccess.UnitOfWork();
                tbl_src_Buildings buildings = new tbl_src_Buildings();

                buildings = db.BuildingsRepository.GetById(BuildingsID);

                buildings.IsActive = false;
                buildings.InactivationUserID = UserID;
                buildings.InactivationDate = System.DateTime.Now;

                db.BuildingsRepository.Update(buildings);
                db.Save();

                //int RowAffected = (int)adp.Delete(BuildingsID, UserID);
                //if (RowAffected > 0)
                //{
                    BuildingsID = 0;
                    OnMessage(BaranResources.DeleteSuccessful, PublicEnum.EnmMessageCategory.Success);
                //}
                //else
                //    OnMessage(BaranResources.DeleteFail, PublicEnum.EnmMessageCategory.Warning);
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
            BuildingsID = 0;
            grdDoc.dstCommon.spr_cmn_DocumentByFkID_Select.Clear();
        }


        public override void OnDoc(int? companyID, int? collectionID, int? subcollectionID, int? partID, int? landID, int? fieldID, int? warehouseID, int? buildingID, int? machineryID, int? waterID, int? waterStorageID, int? waterTransmissionLineID)
        {
            if (BuildingsID <= 0)
            {
                OnMessage(BaranResources.SavedNotLastTime, PublicEnum.EnmMessageCategory.Warning);
                return;
            }
            base.OnDoc(null, null, null, null, null, null, null, this.BuildingsID, null, null, null, null);
            this.FillGridDoc();
        }

        private void SetControlsValue()
        {
            BaranDataAccess.Source.dstSource.spr_src_BuildingsByID_SelectRow drw;
            try
            {
                dst = BaranDataAccess.Source.dstSource.BuildingsByIDTable(BuildingsID);
                drw = dst.spr_src_BuildingsByID_Select[0];

                txtName.Text = drw.IsNameNull() ? string.Empty : drw.Name;
                txtArea.Text = drw.IsAreaNull() ? string.Empty : drw.Area.ToString();
                txtDescription.Text = drw.IsDescriptionNull() ? string.Empty : drw.Description;

                cmbBuildingsCategory.Value = drw.IsFk_BuildingsCategoryIDNull() ? -1 : drw.Fk_BuildingsCategoryID;
                cmbParentCo.Value = drw.IsFk_SubCollectionIDNull() ? -1 : drw.Fk_SubCollectionID;
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
                //dclArea = Convert.ToDecimal(txtArea.Text.Trim().Replace(".", "/"));
                dclArea = Convert.ToDecimal(txtArea.Text.Trim());

                if (cmbBuildingsCategory.Value != null)
                    intBuildingsCategory = Convert.ToInt32(cmbBuildingsCategory.Value);
                if (cmbParentCo.Value != null)
                    intParentCo = Convert.ToInt32(cmbParentCo.Value);
            }
            catch { }
        }

        private void FillGridDoc()
        {
            this.Height = this.Height - grdDoc.Height;
            if (BuildingsID > 0)
            {
                BaranDataAccess.Common.dstCommonTableAdapters.spr_cmn_DocumentByFkID_SelectTableAdapter adp =
                    new BaranDataAccess.Common.dstCommonTableAdapters.spr_cmn_DocumentByFkID_SelectTableAdapter();

                try
                {
                    adp.FillDocumentByFkIDTable(grdDoc.dstCommon.spr_cmn_DocumentByFkID_Select, null, null, null, null,null, null, null, this.BuildingsID, null, null, null, null);

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
                {
                    OnMessage(BaranResources.DoNotDoPleaseTryAgine, PublicEnum.EnmMessageCategory.Warning);
                }
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
            else if (cmbBuildingsCategory.Value == null)
            {
                cmbBuildingsCategory.Focus();
                blnResult = false;
            }
            else if (txtArea.Text.Trim() == string.Empty)
            {
                txtArea.Focus();
                blnResult = false;
            }
            else if (cmbParentCo.Value == null)
            {
                cmbParentCo.Focus();
                blnResult = false;
            }

            return blnResult;
        }


        #endregion

        #region Events

        private void btnGeo_Click(object sender, EventArgs e)
        {
            if (BuildingsID <= 0)
            {
                OnMessage(BaranResources.SavedNotLastTime, PublicEnum.EnmMessageCategory.Warning);
                return;
            }

            Baran.Maps.frmBaseMap ofrm = new Maps.frmBaseMap(PublicEnum.EnmShapeType.Polygon);
            ofrm.BuildingID = BuildingsID;
            ofrm.ShowDialog();
        }

        private void grdDoc_ClickCellButton(object sender, Infragistics.Win.UltraWinGrid.CellEventArgs e)
        {
            if (e.Cell.Column.Key == "Update")
            {
                try
                {
                    Baran.Common.frmDocument ofrm = new Common.frmDocument((int)e.Cell.Row.Cells[grdDoc.dstCommon.spr_cmn_Document_Select.DocumentIDColumn.ColumnName].Value);
                    ofrm.BuildingID = this.BuildingsID;
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
