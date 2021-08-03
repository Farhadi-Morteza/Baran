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
    public partial class frmWater : Baran.Base_Forms.frmSecondChildBase
    {
        #region Constractor

        public frmWater()
        {
            InitializeComponent();
              
        }

        public frmWater(int waterID)
        {
            InitializeComponent();

            WaterID = waterID;
            this.SetControlsValue();
              
        }

        #endregion

        #region Variables
        WaiteForm waite;

        BaranDataAccess.Source.dstSourceTableAdapters.spr_src_Water_SelectTableAdapter adp =
            new BaranDataAccess.Source.dstSourceTableAdapters.spr_src_Water_SelectTableAdapter();
        BaranDataAccess.Source.dstSource dst;
        BaranDataAccess.Source.dstSource.spr_src_Water_SelectRow drw;
        DialogResult msgResult;

        int UserID = (int)CurrentUser.Instance.UserID;

        int? intParentCo = null;
        int? intWaterSourceType = null;

        string
          strName,          
          strDescription
          ;

        decimal dclWaterOutput;

        #endregion

        #region Propertise

        private int _WaterID;
        public int WaterID
        {
            get
            {
                return _WaterID;
            }
            set
            {
                _WaterID = value;
            }
        }

        #endregion

        #region Methods

        public override void OnformLoad()
        {
            base.OnformLoad();
            ComboBoxSetting.FillComboBox(PublicEnum.EnmComboSource.srcWaterSourceType, cmbWaterSourceType, "");
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

            //if (WaterID > 0)
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

                WaterID = Convert.ToInt32(adp.New_Water_Insert(strName, intWaterSourceType, dclWaterOutput, intParentCo, UserID));

                if (WaterID > 0)
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
            if (WaterID <= 0)
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
                int RowAffected = Convert.ToInt32(adp.Update(WaterID, strName, intWaterSourceType, dclWaterOutput, intParentCo, UserID, strDescription));

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

            if (WaterID <= 0)
            {
                OnMessage(BaranResources.SavedNotLastTime, PublicEnum.EnmMessageCategory.Warning);
                return;
            }

            msgResult = MessageBoxX.ShowMessageBox(PublicEnum.EnmMessageType.msgDeleteConfirm);
            if (msgResult == DialogResult.No) return;
            try
            {
                int RowAffected = (int)adp.Delete(WaterID, UserID);
                if (RowAffected > 0)
                {
                    WaterID = 0;
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
            WaterID = 0;
            grdDoc.dstCommon.spr_cmn_DocumentByFkID_Select.Clear();
        }

        public override void OnDoc(int? companyID, int? collectionID, int? subcollectionID, int? partID, int? landID, int? fieldID, int? warehouseID, int? buildingID, int? machineryID, int? waterID, int? waterStorageID, int? waterTransmissionLineID)
        {
            if (WaterID <= 0)
            {
                OnMessage(BaranResources.SavedNotLastTime, PublicEnum.EnmMessageCategory.Warning);
                return;
            }
            base.OnDoc(null, null, null, null, null,null, null, null, null, this.WaterID, null, null);
            this.FillGridDoc();
        }

        private void SetControlsValue()
        {
            BaranDataAccess.Source.dstSource.spr_src_WaterByID_SelectRow drw;
            try
            {
                dst = BaranDataAccess.Source.dstSource.WaterByIDTable(WaterID);
                drw = dst.spr_src_WaterByID_Select[0];

                txtName.Text = drw.Name;
                txtWaterOutput.Text = drw.IsWaterOutputNull() ? string.Empty : drw.WaterOutput.ToString();
                txtDescription.Text = drw.IsDescriptionNull() ? string.Empty : drw.Description;

                cmbWaterSourceType.Value = drw.IsFk_WaterSourceTypeIDNull() ? -1 : drw.Fk_WaterSourceTypeID;
                cmbParentCo.Value = drw.IsFk_PartIDNull() ? -1 : drw.Fk_PartID;
            }
            catch
            {
                OnMessage(BaranResources.DoNotDoPleaseTryAgine, PublicEnum.EnmMessageCategory.Warning);
            }
        }

        private void SetVariables()
        {
            strName = txtName.Text.Trim();
            dclWaterOutput = Convert.ToDecimal( txtWaterOutput.Text.Trim());
            strDescription = txtDescription.Text.Trim();

            if (cmbWaterSourceType.Value != null)
                intWaterSourceType = Convert.ToInt32(cmbWaterSourceType.Value);
            if (cmbParentCo.Value != null)
                intParentCo = Convert.ToInt32(cmbParentCo.Value);
        }

        private bool ControlsValidation()
        {
            bool blnResult = true;

            if (txtName.Text.Trim() == string.Empty)
            {
                txtName.Focus();
                blnResult = false;
            }
            else if (cmbWaterSourceType.SelectedItem == null)
            {
                cmbWaterSourceType.Focus();
                blnResult = false;
            }
            else if (txtWaterOutput.Text.Trim() == string.Empty)
            {
                txtWaterOutput.Focus();
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
            if (WaterID > 0)
            {
                BaranDataAccess.Common.dstCommonTableAdapters.spr_cmn_DocumentByFkID_SelectTableAdapter adp =
                    new BaranDataAccess.Common.dstCommonTableAdapters.spr_cmn_DocumentByFkID_SelectTableAdapter();

                try
                {
                    adp.FillDocumentByFkIDTable(grdDoc.dstCommon.spr_cmn_DocumentByFkID_Select, null, null, null,null, null, null, null, null, null, this.WaterID, null, null);

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

        private void btnGeo_Click(object sender, EventArgs e)
        {
            if (WaterID <= 0)
            {
                OnMessage(BaranResources.SavedNotLastTime, PublicEnum.EnmMessageCategory.Warning);
                return;
            }

            Baran.Maps.frmBaseMap ofrm = new Maps.frmBaseMap(PublicEnum.EnmShapeType.point);
            ofrm.WaterID = WaterID;
            ofrm.ShowDialog();
        }

        private void grdDoc_ClickCellButton(object sender, Infragistics.Win.UltraWinGrid.CellEventArgs e)
        {
            if (e.Cell.Column.Key == "Update")
            {
                try
                {
                    Baran.Common.frmDocument ofrm = new Common.frmDocument((int)e.Cell.Row.Cells[grdDoc.dstCommon.spr_cmn_Document_Select.DocumentIDColumn.ColumnName].Value);
                    ofrm.WaterID = this.WaterID;
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
