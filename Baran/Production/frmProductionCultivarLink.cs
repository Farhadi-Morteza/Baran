using Baran.Classes.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Baran.Production
{
    public partial class frmProductionCultivarLink : Baran.Base_Forms.frmSecondChildBase
    {
        #region Constractor
        public frmProductionCultivarLink()
        {
            InitializeComponent();
        }
        #endregion

        #region Variables
        
        BaranDataAccess.Production.dstProductsTableAdapters.spr_prd_Production_SelectTableAdapter adpProduction =
                    new BaranDataAccess.Production.dstProductsTableAdapters.spr_prd_Production_SelectTableAdapter();

            int intCropID, intCultivarID;
        #endregion

        #region Propertise

        #endregion

        #region Methods

        public override void OnformLoad()
        {
            base.OnformLoad();

            ComboBoxSetting.FillComboBox(PublicEnum.EnmComboSource.srcCrop, cmbCrop, PublicPropertise.ActivityID.ToString());

            if (PublicPropertise.ProductionInUpate)
            {
                this.SetControlsValue();
                this.FormType = cnsFormType.Change;
            }
            else
                this.FormType = cnsFormType.New;
        }

        public override void OnSave()
        {
            base.OnSave();
            if (PublicPropertise.ProductionID <= 0)
                return;

            if (!this.ControlsValidation())
            {
                OnMessage(BaranResources.FeildIsEmpty, PublicEnum.EnmMessageCategory.Warning);
                return;
            }

            DialogResult msgResult = MessageBoxX.ShowMessageBox(PublicEnum.EnmMessageType.msgSaveConfirm);
            if (msgResult == DialogResult.No) return;

            try
            {
                this.SetVariables();
                
               
                int RowAffected = Convert.ToInt32(adpProduction.Update_Production_Cultivar_Update(PublicPropertise.ProductionID, intCropID, intCultivarID, CurrentUser.Instance.UserID ));

                if (RowAffected > 0)
                {
                    MessageBoxX.ShowMessageBox(PublicEnum.EnmMessageType.msgSaveSuccessful);

                    PublicPropertise.CropID = intCropID;
                    Baran.Production.frmProductionSeasonLink ofrm = new frmProductionSeasonLink();

                    //ofrm.FormItemID = Convert.ToInt32(PublicEnum.EnmformItemId.Field);
                    //if (PublicMethods.SetFormSchema(ofrm, ofrm.FormItemID))
                    //{
                    ofrm.MdiParent = this.MdiParent;
                    ofrm.FormType = cnsFormType.New;
                    ofrm.Show();

                    this.Close();
                    //OnMessage(BaranResources.SaveSuccessful, PublicEnum.EnmMessageCategory.Success);
                }
                else
                    OnMessage(BaranResources.SaveFail, PublicEnum.EnmMessageCategory.Warning);
            }
            catch
            {
                OnMessage(BaranResources.DoNotDoPleaseTryAgine, PublicEnum.EnmMessageCategory.Warning);
            }
        }

        public override void OnChange()
        {
            base.OnChange();

            if (PublicPropertise.ProductionID <= 0)
             {
                OnMessage(BaranResources.SavedNotLastTime, PublicEnum.EnmMessageCategory.Warning);
                return;
            }

            if (!this.ControlsValidation())
            {
                OnMessage(BaranResources.FeildIsEmpty, PublicEnum.EnmMessageCategory.Warning);
                return;
            }

            DialogResult msgResult = MessageBoxX.ShowMessageBox(PublicEnum.EnmMessageType.msgEditConfirm);
            if (msgResult == DialogResult.No) return;

            try
            {
                this.SetVariables();
                
                int RowAffected = Convert.ToInt32(adpProduction.Update_Production_Cultivar_Update(PublicPropertise.ProductionID, intCropID, intCultivarID, CurrentUser.Instance.UserID));

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
        }

        public override void OnDelete()
        {
            base.OnDelete();

            if (PublicPropertise.ProductionID <= 0)
            {
                OnMessage(BaranResources.SavedNotLastTime, PublicEnum.EnmMessageCategory.Warning);
                return;
            }



            DialogResult msgResult = MessageBoxX.ShowMessageBox(PublicEnum.EnmMessageType.msgDeleteConfirm);
            if (msgResult == DialogResult.No) return;

            try
            {

                int RowAffected = Convert.ToInt32(adpProduction.Update_Production_Cultivar_Update(PublicPropertise.ProductionID, null, null, CurrentUser.Instance.UserID));

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
        }

        private bool ControlsValidation()
        {
            bool blnResult = true;

            if (cmbCrop.Value == null)
            {
                cmbCrop.Focus();
                blnResult = false;
            }
            else if (cmbCultivar.Value == null)
            {
                cmbCultivar.Focus();
                blnResult = false;
            } 

            return blnResult;
        }

        private void SetVariables()
        {
            intCropID = Convert.ToInt32( cmbCrop.Value);
            intCultivarID = Convert.ToInt32(cmbCultivar.Value);
        }

        private void SetControlsValue()
        {            
            BaranDataAccess.Production.dstProducts.spr_prd_Production_SelectRow drw;

            drw = adpProduction.GetProductionByIDTable(PublicPropertise.ProductionID)[0];
            cmbCrop.Value = drw.IsFK_CropIDNull() ? null : cmbCrop.Value = drw.FK_CropID;
            cmbCultivar.Value = drw.IsFk_CultivarIDNull() ? null : cmbCultivar.Value = drw.Fk_CultivarID;

        }

        #endregion

        #region Events

        private void cmbCrop_ValueChanged(object sender, EventArgs e)
        {
            if (cmbCrop.Value == null)
            {
                cmbCultivar.Value = null;
                return;
            }

            ComboBoxSetting.FillComboBox(PublicEnum.EnmComboSource.srcCultivar, cmbCultivar, cmbCrop.Value.ToString());
            grplabels.Visible = false;
            cmbCultivar.Value = null;
            cmbCultivar.Text = "";
        }

        private void cmbCultivar_ValueChanged(object sender, EventArgs e)
        {

            BaranDataAccess.Common.dstCommonTableAdapters.spr_cmn_CultivarByID_SelectTableAdapter adpCultivar =
                new BaranDataAccess.Common.dstCommonTableAdapters.spr_cmn_CultivarByID_SelectTableAdapter();
            BaranDataAccess.Common.dstCommon.spr_cmn_CultivarByID_SelectRow rwCultivar;

            

            try
            {
                rwCultivar = adpCultivar.GetCultivarByIDTable((int)cmbCultivar.Value)[0];

                lblCultivarName.Text = rwCultivar.IsNameFaNull() ? string.Empty : rwCultivar.NameFa;
                lblCultivarNameEn.Text = rwCultivar.IsNameEnNull() ? string.Empty : rwCultivar.NameEn;
                lblCountryName.Text = rwCultivar.IsCountryNameNull() ? string.Empty : rwCultivar.CountryName;
                lblYeildPerHectare.Text = rwCultivar.IsYieldPerHectareNull() ? string.Empty : rwCultivar.YieldPerHectare.ToString();
                lblCultivatedClimet.Text = rwCultivar.IsCultivatedClimateNull() ? string.Empty : rwCultivar.CultivatedClimate;
                lblDescription.Text = rwCultivar.IsPropertyNull() ? string.Empty : rwCultivar.Property;

                grplabels.Visible = true;
                    
            }
            catch
            {
                grplabels.Visible = false;
                OnMessage(BaranResources.DoNotDoPleaseTryAgine, PublicEnum.EnmMessageCategory.Warning);
            }

        }

        #endregion


    }
}
