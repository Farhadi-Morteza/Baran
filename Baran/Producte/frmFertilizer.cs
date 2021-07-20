using Baran.Classes.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Baran.Producte
{
    public partial class frmFertilizer : Baran.Base_Forms.frmSecondChildBase
    {
        #region Constractor

        public frmFertilizer()
        {
            InitializeComponent();
        }

        public frmFertilizer(int fertilizerID)
        {
            InitializeComponent();

            this.FertilizerID = fertilizerID;
            
        }

        #endregion

        #region Variables

        WaiteForm waite;

        BaranDataAccess.Product.dstProduct.spr_src_Fertilizer_SelectRow drw;
        BaranDataAccess.Product.dstProductTableAdapters.spr_src_Fertilizer_SelectTableAdapter adp
            = new BaranDataAccess.Product.dstProductTableAdapters.spr_src_Fertilizer_SelectTableAdapter();
        BaranDataAccess.Product.dstProductTableAdapters.spr_src_FertilizerElement_selectTableAdapter adpElement =
            new BaranDataAccess.Product.dstProductTableAdapters.spr_src_FertilizerElement_selectTableAdapter();


        DialogResult msgResult;

        int
            intFertilizerCategoryID
            , intMaterialModeID
            , intProductCategoryID
            , intUnitMeasurementID
            ;
        int UserID = (int)CurrentUser.Instance.UserID;

        string
            strName
            , strDescription
            , strManufacture
            , strRegistrationNumber
            ;

        #endregion

        #region Propertise

        private int _fertilizerID = -1;
        public int FertilizerID
        {
            get
            {
                return _fertilizerID;
            }
            set
            {
                _fertilizerID = value;
            }
        }

        #endregion

        #region Methods

        public override void OnformLoad()
        {

            base.OnformLoad();
            Baran.Classes.Common.ComboBoxSetting.FillComboBox(Classes.Common.PublicEnum.EnmComboSource.srcFertilizerCategory, cmbFertilizerCategory);
            Baran.Classes.Common.ComboBoxSetting.FillComboBox(Classes.Common.PublicEnum.EnmComboSource.srcMaterialMode, cmbMaterialMode);
            Baran.Classes.Common.ComboBoxSetting.FillComboBox(Classes.Common.PublicEnum.EnmComboSource.srcProductCategory, cmbProductCategory);
            Baran.Classes.Common.ComboBoxSetting.FillComboBox(Classes.Common.PublicEnum.EnmComboSource.srcUnitMeasurementAll, cmbUnitMeasurement);

            dstCommon1.spr_cmn_Element_cmb_Select.Clear();
            dstCommon1.spr_cmn_Element_cmb_Select.Merge(BaranDataAccess.Common.dstCommon.ElementCmbTable().spr_cmn_Element_cmb_Select);

            if(FertilizerID >0)
                this.SetControlsValue();
        }

        public override void OnSave()
        {
            base.OnSave();

            //if (WaterStorageID > 0)
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

                FertilizerID = Convert.ToInt32(adp.New_Fertilizer_Insert(strName, strManufacture, intFertilizerCategoryID, intMaterialModeID
                                                                         , intProductCategoryID, intUnitMeasurementID, strRegistrationNumber, strDescription, UserID));
                if (FertilizerID > 0)
                {
                    for (int i = 0; i <= dstProduct1.spr_src_FertilizerElement_select.Count - 1; i++)
                    {
                        dstProduct1.spr_src_FertilizerElement_select.Rows[i][dstProduct1.spr_src_FertilizerElement_select.Fk_FertilizerIDColumn.ColumnName] = FertilizerID;
                        dstProduct1.spr_src_FertilizerElement_select.Rows[i][dstProduct1.spr_src_FertilizerElement_select.CreateUserIDColumn.ColumnName] = UserID;
                    }
                    adpElement.Update(dstProduct1.spr_src_FertilizerElement_select);
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

            if (FertilizerID <= 0)
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
                int RowAffected = Convert.ToInt32(adp.Update(FertilizerID, strName, strManufacture, intFertilizerCategoryID,
                                                            intMaterialModeID, intProductCategoryID, intUnitMeasurementID
                                                            , strRegistrationNumber, strDescription, UserID));

                if (RowAffected > 0)
                {
                    for (int i = 0; i <= dstProduct1.spr_src_FertilizerElement_select.Count - 1; i++)
                    {
                        try
                        {
                            dstProduct1.spr_src_FertilizerElement_select.Rows[i][dstProduct1.spr_src_FertilizerElement_select.Fk_FertilizerIDColumn.ColumnName] = FertilizerID;
                            dstProduct1.spr_src_FertilizerElement_select.Rows[i][dstProduct1.spr_src_FertilizerElement_select.UpdateUserIDColumn.ColumnName] = UserID;
                        }
                        catch { }
                    }
                    adpElement.Update(dstProduct1.spr_src_FertilizerElement_select);
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

            if (FertilizerID <= 0)
            {
                OnMessage(BaranResources.SavedNotLastTime, PublicEnum.EnmMessageCategory.Warning);
                return;
            }

            msgResult = MessageBoxX.ShowMessageBox(PublicEnum.EnmMessageType.msgDeleteConfirm);
            if (msgResult == DialogResult.No) return;
            try
            {

                int RowAffected = Convert.ToInt32(adp.Delete(FertilizerID, UserID));

                if (RowAffected > 0)
                {
                    FertilizerID = 0;
                    ControlsSetting.ClearControls(grpControls.Controls);
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
            ControlsSetting.ClearControls(grpControls.Controls);
        }

        private void SetControlsValue()
        {
            BaranDataAccess.Product.dstProduct.spr_src_FertilizerByID_SelectRow drw;
            BaranDataAccess.Product.dstProductTableAdapters.spr_src_FertilizerByID_SelectTableAdapter adpID
                = new BaranDataAccess.Product.dstProductTableAdapters.spr_src_FertilizerByID_SelectTableAdapter();

            if (FertilizerID > 0)
            {
                //drw = BaranDataAccess.Source.dstSource.WaterStorageByIDTable(WaterStorageID).spr_src_WaterStorage_Select[0];
                drw = adpID.GetFertilizerByIDTable(FertilizerID)[0];

                txtName.Text = drw.IsNameNull() ? string.Empty : drw.Name;
                txtManufacture.Text = drw.IsManufactureNull() ? string.Empty : drw.Manufacture;
                txtRegistrationNumber.Text = drw.IsRegistrationNumberNull() ? string.Empty : drw.RegistrationNumber;
                txtDescription.Text = drw.IsDescriptionNull() ? string.Empty : drw.Description;

                if (!drw.IsFk_FertilizerCategoryIDNull())
                    cmbFertilizerCategory.Value = drw.Fk_FertilizerCategoryID;
                if (!drw.IsFk_MaterialModeIDNull())
                    cmbMaterialMode.Value = drw.Fk_MaterialModeID;
                if (!drw.IsFk_ProductCategoryIDNull())
                    cmbProductCategory.Value = drw.Fk_ProductCategoryID;
                if (!drw.IsFk_UnitMeasurementIDNull())
                    cmbUnitMeasurement.Value = drw.Fk_UnitMeasurementID;

                dstProduct1.spr_src_FertilizerElement_select.Merge(BaranDataAccess.Product.dstProduct.FertilizerElementTable(FertilizerID).spr_src_FertilizerElement_select);
                var pp = BaranDataAccess.Product.dstProduct.FertilizerElementTable(FertilizerID).spr_src_FertilizerElement_select;
            }

        }

        private void SetVariables()
        {

            strName = txtName.Text.Trim();
            strDescription = txtDescription.Text.Trim();
            strManufacture = txtManufacture.Text.Trim();
            strRegistrationNumber = txtRegistrationNumber.Text.Trim();

            if (cmbFertilizerCategory.Value != null)
                intFertilizerCategoryID = Convert.ToInt32(cmbFertilizerCategory.Value);
            if (cmbMaterialMode.Value != null)
                intMaterialModeID = Convert.ToInt32(cmbMaterialMode.Value);
            if (cmbProductCategory.Value != null)
                intProductCategoryID = Convert.ToInt32(cmbProductCategory.Value);
            if (cmbUnitMeasurement.Value != null)
                intUnitMeasurementID = Convert.ToInt32(cmbUnitMeasurement.Value);
        }

        private bool ControlsValidation()
        {
            bool blnResult = true;

            if (txtName.Text.Trim() == string.Empty)
            {
                txtName.Focus();
                blnResult = false;
            }
            else if (cmbFertilizerCategory.Value == null)
            {
                cmbFertilizerCategory.Focus();
                blnResult = false;
            }
            else if (cmbMaterialMode.Value == null)
            {
                cmbMaterialMode.Focus();
                blnResult = false;
            }
            else if (cmbUnitMeasurement.Value == null)
            {
                cmbUnitMeasurement.Focus();
                blnResult = false;
            }
            else if (cmbProductCategory.Value == null)
            {
                cmbProductCategory.Focus();
                blnResult = false;
            }

            return blnResult;
        }

        private void drpItem_RowSelected(object sender, Infragistics.Win.UltraWinGrid.RowSelectedEventArgs e)
        {
            if (e.Row == null)
                return;

            grdItem.ActiveRow.Cells[dstProduct1.spr_src_FertilizerElement_select.Fk_ElementIDColumn.ColumnName].Value
                = e.Row.Cells[dstCommon1.spr_cmn_Element_cmb_Select.ElementIDColumn.ColumnName].Value;
        }

        #endregion

        private void grdItem_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {

        }
    }
}
