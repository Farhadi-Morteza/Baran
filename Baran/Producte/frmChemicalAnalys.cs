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
    public partial class frmChemicalAnalys : Baran.Base_Forms.frmSecondChildBase
    {
       #region Constractor

        public frmChemicalAnalys()
        {
            InitializeComponent();
        }

        public frmChemicalAnalys(int chemicalAnalysID)
        {
            InitializeComponent();
            this.ChemicalAnalysID = chemicalAnalysID;
            this.SetControlsValue();
        }

        #endregion

        #region Variables

        WaiteForm waite;

        BaranDataAccess.Product.dstProduct.spr_src_ChemicalAnalys_SelectRow drw;
        BaranDataAccess.Product.dstProductTableAdapters.spr_src_ChemicalAnalys_SelectTableAdapter adp =
            new BaranDataAccess.Product.dstProductTableAdapters.spr_src_ChemicalAnalys_SelectTableAdapter();
        BaranDataAccess.Product.dstProductTableAdapters.spr_src_ChemicalAnalysElement_SelectTableAdapter adpElement =
            new BaranDataAccess.Product.dstProductTableAdapters.spr_src_ChemicalAnalysElement_SelectTableAdapter();


        DialogResult msgResult;

        Nullable< int>
            intChemicalAnalysCategoryID
            , intFieldID
            , intWaterID
            , intFertilizerID
            ;

        Nullable<DateTime> datDate;

        int UserID = (int)CurrentUser.Instance.UserID;

        string
            strName
            , strDescription
            , strAnalysNumber
            , strSamplingDepth
            , strLabratoryName
            , strLabratoryCode
            , strLabratoryPhone
            , strLabratoryAddress
            ;

        #endregion

        #region Propertise

        private int _chemicalAnalysID = -1;
        public int ChemicalAnalysID
        {
            get
            {
                return _chemicalAnalysID;
            }
            set
            {
                _chemicalAnalysID = value;
            }
        }

        #endregion

        #region Methods

        public override void OnformLoad()
        {

            base.OnformLoad();
            Baran.Classes.Common.ComboBoxSetting.FillComboBox(Classes.Common.PublicEnum.EnmComboSource.srcChemicalAnalysCategory, cmbChemicalAnalysisCategory);

            dstCommon1.spr_cmn_Element_cmb_Select.Clear();
            dstCommon1.spr_cmn_Element_cmb_Select.Merge(BaranDataAccess.Common.dstCommon.ElementCmbTable().spr_cmn_Element_cmb_Select);
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

                ChemicalAnalysID = Convert.ToInt32(adp.NewChemicalAnalys_Insert(strName, datDate, strAnalysNumber, strSamplingDepth
                                                                            , strLabratoryName, strLabratoryCode, strLabratoryPhone, strLabratoryAddress, strDescription, 
                                                                               intChemicalAnalysCategoryID, intFieldID, intWaterID, intFertilizerID, UserID));
                if (ChemicalAnalysID > 0)
                {
                    for (int i = 0; i <= dstProduct1.spr_src_ChemicalAnalysElement_Select.Count - 1; i++)
                    {
                        dstProduct1.spr_src_ChemicalAnalysElement_Select.Rows[i][dstProduct1.spr_src_ChemicalAnalysElement_Select.Fk_ChemicalAnalysIDColumn.ColumnName] = ChemicalAnalysID;
                        dstProduct1.spr_src_ChemicalAnalysElement_Select.Rows[i][dstProduct1.spr_src_ChemicalAnalysElement_Select.CreateUserIDColumn.ColumnName] = CurrentUser.Instance.UserID;
                    }
                    adpElement.Update(dstProduct1.spr_src_ChemicalAnalysElement_Select);
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

            if (ChemicalAnalysID <= 0)
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
                int RowAffected = Convert.ToInt32(adp.Update(ChemicalAnalysID, strName, datDate, strAnalysNumber, strSamplingDepth
                                                            , strLabratoryName, strLabratoryCode, strLabratoryPhone, strLabratoryAddress, strDescription
                                                            , intChemicalAnalysCategoryID, intFieldID, intWaterID, intFertilizerID, UserID));

                if (RowAffected > 0)
                {
                    for (int i = 0; i <= dstProduct1.spr_src_ChemicalAnalysElement_Select.Count - 1; i++)
                    {
                        try
                        {
                            dstProduct1.spr_src_ChemicalAnalysElement_Select.Rows[i][dstProduct1.spr_src_ChemicalAnalysElement_Select.Fk_ChemicalAnalysIDColumn.ColumnName] = ChemicalAnalysID;
                            dstProduct1.spr_src_ChemicalAnalysElement_Select.Rows[i][dstProduct1.spr_src_ChemicalAnalysElement_Select.UpdateUserIDColumn.ColumnName] = CurrentUser.Instance.UserID;
                        }
                        catch { }
                    }
                    adpElement.Update(dstProduct1.spr_src_ChemicalAnalysElement_Select);
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

            if (ChemicalAnalysID <= 0)
            {
                OnMessage(BaranResources.SavedNotLastTime, PublicEnum.EnmMessageCategory.Warning);
                return;
            }

            msgResult = MessageBoxX.ShowMessageBox(PublicEnum.EnmMessageType.msgDeleteConfirm);
            if (msgResult == DialogResult.No) return;
            try
            {

                int RowAffected = Convert.ToInt32(adp.Delete(ChemicalAnalysID, UserID));

                if (RowAffected > 0)
                {
                    ChemicalAnalysID = 0;
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
            BaranDataAccess.Product.dstProduct.spr_src_ChemicalAnalysByID_SelectRow drw;
            BaranDataAccess.Product.dstProductTableAdapters.spr_src_ChemicalAnalysByID_SelectTableAdapter adpID =
                new BaranDataAccess.Product.dstProductTableAdapters.spr_src_ChemicalAnalysByID_SelectTableAdapter();

            if (ChemicalAnalysID > 0)
            {
                //drw = BaranDataAccess.Source.dstSource.WaterStorageByIDTable(WaterStorageID).spr_src_WaterStorage_Select[0];
                drw = adpID.GetChemicalAnalysByIDTable(ChemicalAnalysID)[0];

                txtName.Text = drw.IsNameNull() ? string.Empty : drw.Name;
                txtLabratoryCode.Text = drw.IsLabratoryCodeNull() ? string.Empty : drw.LabratoryCode;
                txtLabratoryName.Text = drw.IsLabratoryNameNull() ? string.Empty : drw.LabratoryName;
                txtLabratoryPhone.Text = drw.IsLabratoryPhoneNull() ? string.Empty : drw.LabratoryPhone;
                txtLabratoryAddress.Text = drw.IsLabratoryAddressNull() ? string.Empty : drw.LabratoryAddress;
                txtAnalysNumber.Text = drw.IsAnalysNumberNull() ? string.Empty : drw.AnalysNumber;
                txtSamplingDepth.Text = drw.IsSamplingDepthNull() ? string.Empty : drw.SamplingDepth;
                txtDescription.Text = drw.IsDescriptionNull() ? string.Empty : drw.Description;

                mskDate.Value = drw.IsDateNull()? null : mskDate.Value = DateTimeUtility.ToPersian(drw.Date);

                cmbChemicalAnalysisCategory.Value = drw.IsFk_ChemicalAnalysisCategoryIDNull() ? null : cmbChemicalAnalysisCategory.Value = drw.Fk_ChemicalAnalysisCategoryID;

                if (!drw.IsFk_FieldIDNull())
                    cmbSource.Value = drw.Fk_FieldID;
                if (!drw.IsFk_WaterIDNull())
                    cmbSource.Value = drw.Fk_WaterID;
                if (!drw.IsFk_FertilizerIDNull())
                    cmbSource.Value = drw.Fk_FertilizerID;

                BaranDataAccess.Product.dstProductTableAdapters.spr_src_ChemicalAnalysElement_SelectTableAdapter adpElement = 
                    new BaranDataAccess.Product.dstProductTableAdapters.spr_src_ChemicalAnalysElement_SelectTableAdapter();

                adpElement.FillChemicalAnalysElementTable(dstProduct1.spr_src_ChemicalAnalysElement_Select, ChemicalAnalysID);
            }

        }

        private void SetVariables()
        {

            strName = txtName.Text.Trim();
            strLabratoryCode = txtLabratoryCode.Text.Trim();
            strLabratoryName = txtLabratoryName.Text.Trim();
            strLabratoryPhone = txtLabratoryPhone.Text.Trim();
            strLabratoryAddress = txtLabratoryAddress.Text.Trim();
            strAnalysNumber = txtAnalysNumber.Text.Trim();
            strSamplingDepth = txtSamplingDepth.Text.Trim();
            strDescription = txtDescription.Text.Trim();

            datDate = DateTimeUtility.ToGregorian(mskDate.Value.ToString());

            intChemicalAnalysCategoryID = Convert.ToInt32(cmbChemicalAnalysisCategory.Value);
            if (ChemicalAnalysID == 1)
                intFieldID = Convert.ToInt32( cmbSource.Value);
            if (ChemicalAnalysID == 2)
                intWaterID = Convert.ToInt32(cmbSource.Value);
            if (ChemicalAnalysID == 3)
                intFertilizerID = Convert.ToInt32(cmbSource.Value);
            if (ChemicalAnalysID == 4)
                intFieldID = Convert.ToInt32(cmbSource.Value);


        }

        private bool ControlsValidation()
        {
            bool blnResult = true;

            if (txtName.Text.Trim() == string.Empty)
            {
                txtName.Focus();
                blnResult = false;
            }
            else if (cmbChemicalAnalysisCategory.Value == null)
            {
                cmbChemicalAnalysisCategory.Focus();
                blnResult = false;
            }
            else if (cmbSource.Value == null)
            {
                cmbSource.Focus();
                blnResult = false;
            }
            else if (mskDate.Value.ToString() == string.Empty)
            {
                mskDate.Focus();
                blnResult = false;
            }
            else if (txtAnalysNumber.Text == string.Empty)
            {
                txtAnalysNumber.Focus();
                blnResult = false;
            }

            return blnResult;
        }

        #endregion

        private void cmbChemicalAnalysisCategory_ValueChanged(object sender, EventArgs e)
        {
            try 
            {
                cmbSource.ValueMember = null;
                cmbSource.DisplayMember = null;
                cmbSource.Value = null;

                int CategoryID = Convert.ToInt32( cmbChemicalAnalysisCategory.Value);
                if (CategoryID == 1) 
                    ComboBoxSetting.FillComboBox(PublicEnum.EnmComboSource.srcFieldByUserID, cmbSource, CurrentUser.Instance.UserID.ToString());
                if (CategoryID == 2) 
                    ComboBoxSetting.FillComboBox(PublicEnum.EnmComboSource.srcWaterByUserIDCmb, cmbSource, CurrentUser.Instance.UserID.ToString());
                //if (CategoryID == 3)
                    //ComboBoxSetting.FillComboBox(PublicEnum.EnmComboSource.srcfer, cmbSource, CurrentUser.Instance.UserID.ToString());
                if (CategoryID == 4)
                    ComboBoxSetting.FillComboBox(PublicEnum.EnmComboSource.srcFieldByUserID, cmbSource, CurrentUser.Instance.UserID.ToString());
            }
            catch
            {
                cmbSource.Value = null;
            }
        }
    }
}
