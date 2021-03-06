using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Baran.Classes.Common;

namespace Baran.Source
{
    public partial class frmWarehouse : Baran.Base_Forms.frmSecondChildBase
    {
        #region Constractor

        public frmWarehouse()
        {
            InitializeComponent();
              
        }

        public frmWarehouse(int warehouseID)
        {
            InitializeComponent();
            WarehouseID = warehouseID;
            this.SetControlsValue();
              
        }

        #endregion

        #region Variables

        WaiteForm waite;

        BaranDataAccess.Source.dstSourceTableAdapters.spr_src_Warehouse_SelectTableAdapter adp =
            new BaranDataAccess.Source.dstSourceTableAdapters.spr_src_Warehouse_SelectTableAdapter();
        BaranDataAccess.Source.dstSource dst;
        BaranDataAccess.Source.dstSource.spr_src_Warehouse_SelectRow drw;
        DialogResult msgResult;

        int UserID = (int)CurrentUser.Instance.UserID;

        int? intParentCo = null;
        int? intWarehouseType = null;
        int? intWarehouseUseType = null;

        string
          strName,

          strWarehouseKeeper,
          strDescription,
          strAddress
          ;

        decimal?
            dclArea,
            dclVolume;


        #endregion

        #region Propertise

        private int _WarehouseID;
        public int WarehouseID
        {
            get
            {
                return _WarehouseID;
            }
            set
            {
                _WarehouseID = value;
            }
        }

        #endregion

        #region Methods

        public override void OnformLoad()
        {
            base.OnformLoad();
            ComboBoxSetting.FillComboBox(PublicEnum.EnmComboSource.srcWarehouseType, cmbWarehouseType, "");
            ComboBoxSetting.FillComboBox(PublicEnum.EnmComboSource.srcPart, cmbParentCo, "");
            ComboBoxSetting.FillComboBox(PublicEnum.EnmComboSource.srcWarehouseUseType, cmbWarehouseUseType, "");

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

            //if (WarehouseID > 0)
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
                WarehouseID = Convert.ToInt32(adp.New_Warehouse_Insert(strName, dclArea, strWarehouseKeeper, strAddress, intWarehouseType, strDescription, UserID, intParentCo, intWarehouseUseType, dclVolume));

                if (WarehouseID > 0)
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

            if (WarehouseID <= 0)
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
                int RowAffected = Convert.ToInt32(adp.Update(WarehouseID, strName, dclArea, strWarehouseKeeper, strAddress, intWarehouseType, strDescription, UserID, intParentCo, intWarehouseUseType, dclVolume));

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

            if (WarehouseID <= 0)
            {
                OnMessage(BaranResources.SavedNotLastTime, PublicEnum.EnmMessageCategory.Warning);
                return;
            }

            msgResult = MessageBoxX.ShowMessageBox(PublicEnum.EnmMessageType.msgDeleteConfirm);
            if (msgResult == DialogResult.No) return;
            try
            {
                int RowAffected = (int)adp.Delete(WarehouseID, UserID);
                if (RowAffected > 0)
                {
                    WarehouseID = 0;
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
            WarehouseID = 0;
            grdDoc.dstCommon.spr_cmn_DocumentByFkID_Select.Clear();
        }

        public override void OnDoc(int? companyID, int? collectionID, int? subcollectionID, int? partID, int? landID, int? fieldID, int? warehouseID, int? buildingID, int? machineryID, int? waterID, int? waterStorageID, int? waterTransmissionLineID)
        {
            if (WarehouseID <= 0)
            {
                OnMessage(BaranResources.SavedNotLastTime, PublicEnum.EnmMessageCategory.Warning);
                return;
            }
            base.OnDoc(null, null, null, null,null, null, this.WarehouseID, null, null, null, null, null);
            this.FillGridDoc();
        }

        private void SetControlsValue()
        {
            BaranDataAccess.Source.dstSource.spr_src_WarehouseByID_SelectRow drw;
            try
            {
                dst = BaranDataAccess.Source.dstSource.WarehouseByIDTable(WarehouseID);
                drw = dst.spr_src_WarehouseByID_Select[0];

                txtName.Text = drw.Name;
                txtWarehouseKeeper.Text = drw.IsWarehouseKeeperNull() ? string.Empty : drw.WarehouseKeeper;
                txtArea.Text = drw.IsAreaNull() ? string.Empty : drw.Area.ToString();
                txtVolume.Text = drw.IsVolumeNull() ? string.Empty : drw.Volume.ToString();
                txtAddress.Text = drw.IsAddressNull() ? string.Empty : drw.Address;
                txtDescription.Text = drw.IsDescriptionNull() ? string.Empty : drw.Description;

                cmbWarehouseType.Value = drw.IsFK_WarehouseTypeNull() ? -1 : drw.FK_WarehouseType;
                cmbParentCo.Value = drw.IsFk_PartIDNull() ? -1 : drw.Fk_PartID;
                cmbWarehouseUseType.Value = drw.IsFk_WarehouseUseTypeIDNull() ? -1 : drw.Fk_WarehouseUseTypeID;
            }
            catch
            {
                OnMessage(BaranResources.DoNotDoPleaseTryAgine, PublicEnum.EnmMessageCategory.Warning);
            }
        }

        private void SetVariables()
        {
            strName = txtName.Text.Trim();
            strWarehouseKeeper = txtWarehouseKeeper.Text.Trim();
            dclArea = Convert.ToDecimal(txtArea.Text.Trim());

            if (txtVolume.Text.Trim() != "")
                dclVolume = Convert.ToDecimal(txtVolume.Text.Trim());
            strDescription = txtDescription.Text.Trim();
            strAddress = txtAddress.Text.Trim();

            if (cmbWarehouseType.Value != null)
                intWarehouseType = Convert.ToInt32(cmbWarehouseType.Value);
            if (cmbParentCo.Value != null)
                intParentCo = Convert.ToInt32(cmbParentCo.Value);
            if (cmbWarehouseUseType.Value != null)
                intWarehouseUseType = Convert.ToInt32(cmbWarehouseUseType.Value);
        }

        private bool ControlsValidation()
        {
            bool blnResult = true;

            if (txtName.Text.Trim() == string.Empty)
            {
                txtName.Focus();
                blnResult = false;
            }
            else if (cmbParentCo.SelectedItem == null)
            {
                cmbParentCo.Focus();
                blnResult = false;
            }
            else if (cmbWarehouseType.SelectedItem == null)
            {
                cmbWarehouseType.Focus();
                blnResult = false;
            }
            else if (cmbWarehouseUseType.SelectedItem == null)
            {
                cmbWarehouseUseType.Focus();
                blnResult = false;
            }
            else if (txtArea.Text.Trim() == string.Empty)
            {
                txtArea.Focus();
                blnResult = false;

            }


            return blnResult;
        }

        private void FillGridDoc()
        {
            this.Height = this.Height - grdDoc.Height;
            if (WarehouseID > 0)
            {
                BaranDataAccess.Common.dstCommonTableAdapters.spr_cmn_DocumentByFkID_SelectTableAdapter adp =
                    new BaranDataAccess.Common.dstCommonTableAdapters.spr_cmn_DocumentByFkID_SelectTableAdapter();

                try
                {
                    adp.FillDocumentByFkIDTable(grdDoc.dstCommon.spr_cmn_DocumentByFkID_Select, null, null, null, null, null, null, this.WarehouseID, null, null, null, null, null);

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
                    ofrm.WarehouseID = this.WarehouseID;
                    ofrm.ShowDialog();

                    this.FillGridDoc();
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        private void btnGeo_Click(object sender, EventArgs e)
        {
            if (WarehouseID <= 0)
            {
                OnMessage(BaranResources.SavedNotLastTime, PublicEnum.EnmMessageCategory.Warning);
                return;
            }

            Baran.Maps.frmBaseMap ofrm = new Maps.frmBaseMap(PublicEnum.EnmShapeType.Polygon);
            ofrm.WarehouseID = WarehouseID;
            ofrm.ShowDialog();
        }

        #endregion
    }
}
