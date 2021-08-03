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
    public partial class frmWaterTransmission : Baran.Base_Forms.frmSecondChildBase
    {
        #region Constractor

        public frmWaterTransmission()
        {
            InitializeComponent();
              

            this.WaterTransmissionLineID = 0;
        }

        public frmWaterTransmission(int waterTransmissionLineID)
        {
            InitializeComponent();
              

            this.WaterTransmissionLineID = waterTransmissionLineID;
            this.SetControlsValue();
        }
        #endregion

        #region Variables

        WaiteForm waite;

        BaranDataAccess.Source.dstSourceTableAdapters.spr_src_WaterTransmissionLine_SelectTableAdapter adp
            = new BaranDataAccess.Source.dstSourceTableAdapters.spr_src_WaterTransmissionLine_SelectTableAdapter();

        BaranDataAccess.Source.dstSource.spr_src_WaterTransmissionLine_SelectRow drw;

        DialogResult msgResult;

        int intParentID;
        int intWaterTransmissionTypeID;
        int UserID = Convert.ToInt32(CurrentUser.Instance.UserID);

        string
            strName
            , strDescription;

        decimal
            dcllength
            , dclDiameter

            ;
        #endregion

        #region Propertise

        private int _WaterTransmissionLineID = -1;
        public int WaterTransmissionLineID
        {
            get
            {
                return _WaterTransmissionLineID;
            }
            set
            {
                _WaterTransmissionLineID = value;
            }
        }

        #endregion

        #region Methods

        public override void OnformLoad()
        {
            base.OnformLoad();
            Baran.Classes.Common.ComboBoxSetting.FillComboBox(Classes.Common.PublicEnum.EnmComboSource.srcPart, cmbParentCo, "");
            Baran.Classes.Common.ComboBoxSetting.FillComboBox(Classes.Common.PublicEnum.EnmComboSource.srcWaterTransmissionType, cmbWaterTransmissiontype, "");
            btnGeo.Image = btnPrint.Image = System.Drawing.Image.FromFile(PublicMethods.PictureFileNamePath(cnsPictureName.Map64));

            this.FillGridDoc();

        }

        public override void OnSave()
        {
            base.OnSave();

            //if (WaterTransmissionLineID > 0)
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

                WaterTransmissionLineID = Convert.ToInt32(adp.New_WaterTransmissionLine_Insert(strName, dcllength, dclDiameter, intParentID, UserID, strDescription, intWaterTransmissionTypeID));

                if (WaterTransmissionLineID > 0)
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

            if (WaterTransmissionLineID <= 0)
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
                int RowAffected = Convert.ToInt32(adp.Update(WaterTransmissionLineID, strName, dcllength, dclDiameter, intParentID, UserID, strDescription, intWaterTransmissionTypeID));

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

            if (WaterTransmissionLineID <= 0)
            {
                OnMessage(BaranResources.SavedNotLastTime, PublicEnum.EnmMessageCategory.Warning);
                return;
            }

            msgResult = MessageBoxX.ShowMessageBox(PublicEnum.EnmMessageType.msgDeleteConfirm);
            if (msgResult == DialogResult.No) return;
            try
            {
                int RowAffected = Convert.ToInt32(adp.Delete(WaterTransmissionLineID, UserID));
                if (RowAffected > 0)
                {
                    WaterTransmissionLineID = 0;
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
            WaterTransmissionLineID = 0;
            grdDoc.dstCommon.spr_cmn_DocumentByFkID_Select.Clear();
        }

        public override void OnDoc(int? companyID, int? collectionID, int? subcollectionID, int? partID, int? landID, int? fieldID, int? warehouseID, int? buildingID, int? machineryID, int? waterID, int? waterStorageID, int? waterTransmissionLineID)
        {
            if (WaterTransmissionLineID <= 0)
            {
                OnMessage(BaranResources.SavedNotLastTime, PublicEnum.EnmMessageCategory.Warning);
                return;
            }
            base.OnDoc(null, null, null, null,null, null, null, null, null, null, null, this.WaterTransmissionLineID);
            this.FillGridDoc();
        }

        private void SetControlsValue()
        {
            BaranDataAccess.Source.dstSource.spr_src_WaterTransmissionLineByID_SelectRow drw;
            BaranDataAccess.Source.dstSource dst = new BaranDataAccess.Source.dstSource();
            try
            {
                dst = BaranDataAccess.Source.dstSource.WaterTransmissionLineByIDTable(WaterTransmissionLineID);
                drw = dst.spr_src_WaterTransmissionLineByID_Select[0];


                txtName.Text = drw.Name;
                txtLength.Text = drw.IsLengthNull() ? string.Empty : drw.Length.ToString();
                txtDiameter.Text = drw.IsDiameterNull() ? string.Empty : drw.Diameter.ToString();
                txtDescription.Text = drw.IsDescriptionNull() ? string.Empty : drw.Description;

                if (!drw.IsFk_PartIDNull())
                    cmbParentCo.Value = drw.Fk_PartID;

                if (!drw.IsFk_WaterTransmissionTypeIDNull())
                    cmbWaterTransmissiontype.Value = drw.Fk_WaterTransmissionTypeID;
            }
            catch
            {
                OnMessage(BaranResources.DoNotDoPleaseTryAgine, PublicEnum.EnmMessageCategory.Warning);
            }

        }

        private void SetVariables()
        {
            strName = txtName.Text.Trim();
            strDescription = txtDescription.Text.Trim();

            dcllength = Convert.ToDecimal(txtLength.Text.Trim());

            if(txtDiameter.Text.Trim() != string.Empty)
                dclDiameter = Convert.ToDecimal(txtDiameter.Text.Trim());

            if (cmbParentCo.Value != null)
                intParentID = Convert.ToInt32(cmbParentCo.Value);

            if (cmbWaterTransmissiontype.Value != null)
                intWaterTransmissionTypeID = Convert.ToInt32(cmbWaterTransmissiontype.Value);
        }

        private bool ControlsValidation()
        {
            bool blnResult = true;

            if (cmbParentCo.SelectedItem == null)
            {
                cmbParentCo.Focus();
                blnResult = false;

            }
            else if (txtName.Text.Trim() == string.Empty)
            {
                txtName.Focus();
                blnResult = false;
            }
            else if (txtLength.Text.Trim() == string.Empty)
            {
                txtLength.Focus();
                blnResult = false;
            }
            else if (cmbWaterTransmissiontype.SelectedItem == null)
            {
                cmbWaterTransmissiontype.Focus();
                blnResult = false;

            }
            //else if (txtDescription.Text.Trim() == string.Empty)
            //{
            //    ControlsSetting.AddPictureMessage(cmbParentCo, cnsPictureMessageType.Warning, cnsPictureMessagePosition.Right);
            //    txtDescription.Focus();
            //    blnResult = false;

            //}


            return blnResult;
        }

        private void FillGridDoc()
        {
            this.Height = this.Height - grdDoc.Height;
            if (WaterTransmissionLineID > 0)
            {
                BaranDataAccess.Common.dstCommonTableAdapters.spr_cmn_DocumentByFkID_SelectTableAdapter adp =
                    new BaranDataAccess.Common.dstCommonTableAdapters.spr_cmn_DocumentByFkID_SelectTableAdapter();

                try
                {
                    adp.FillDocumentByFkIDTable(grdDoc.dstCommon.spr_cmn_DocumentByFkID_Select, null, null, null, null,null, null, null, null, null, null, null, this.WaterTransmissionLineID);

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
            if (WaterTransmissionLineID <= 0)
            {
                OnMessage(BaranResources.SavedNotLastTime, PublicEnum.EnmMessageCategory.Warning);
                return;
            }

            Baran.Maps.frmBaseMap ofrm = new Maps.frmBaseMap(PublicEnum.EnmShapeType.Rout);
            ofrm.WaterTransmissionLineID = WaterTransmissionLineID;
            ofrm.ShowDialog();
        }

        private void grdDoc_ClickCellButton(object sender, Infragistics.Win.UltraWinGrid.CellEventArgs e)
        {
            if (e.Cell.Column.Key == "Update")
            {
                try
                {
                    Baran.Common.frmDocument ofrm = new Common.frmDocument((int)e.Cell.Row.Cells[grdDoc.dstCommon.spr_cmn_Document_Select.DocumentIDColumn.ColumnName].Value);
                    ofrm.WaterTransmissionLineID = this.WaterTransmissionLineID;
                    ofrm.FormType = cnsFormType.Change;
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

        private void grpControls_Click(object sender, EventArgs e)
        {

        }
    }
}
