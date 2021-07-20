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
    public partial class frmCropPlantation : Baran.Base_Forms.frmChildBase
    {
        #region Constractor
        public frmCropPlantation()
        {
            InitializeComponent();
        }
        #endregion

        #region Variables

        BaranDataAccess.Production.dstProductsTableAdapters.spr_prd_Production_SelectTableAdapter adp =
            new BaranDataAccess.Production.dstProductsTableAdapters.spr_prd_Production_SelectTableAdapter();

        string
          strName;

        int
            intActivityID;

        #endregion

        #region Propertise

        #endregion

        #region Methods

        public override void OnformLoad()
        {
            base.OnformLoad();

            ComboBoxSetting.FillComboBox(PublicEnum.EnmComboSource.srcBusinessCategory, cmbBusinessCategory);
            PicLogo.Image = System.Drawing.Image.FromFile(PublicMethods.PictureFileNamePath(cnsPictureName.Crops));
        }

        public override void OnActiveForm()
        {
            base.OnActiveForm();
            frmMain ofrm = frmMain.Instanc;
            ofrm.EnableToolBarItems(cnsToolStripButton.Cancel, cnsToolStripButton.Save);
            ofrm.EnableMenuStripItems(cnsMenustripItems.Cancel, cnsMenustripItems.Save);

            cmbActivity.Focus();
        }

        public override void OnSave()
        {
            base.OnSave();

            if (PublicPropertise.ProductionID > 0)
            {
                OnMessage(BaranResources.SavedLastTime, PublicEnum.EnmMessageCategory.Warning);
                return;
            }

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
                PublicPropertise.ProductionID = Convert.ToInt32(adp.New_Production_Insert(strName, intActivityID, CurrentUser.Instance.UserID));
                if (PublicPropertise.ProductionID > 0)
                {
                    OnMessage(BaranResources.SaveSuccessful, PublicEnum.EnmMessageCategory.Success);
                    Baran.Production.frmBaseProduction ofrm = new frmBaseProduction(PublicPropertise.ProductionID);
                    PublicPropertise.ActivityID = intActivityID;
                    ofrm.Caption = strName;
                    ofrm.ShowDialog();

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
                int RowAffected = Convert.ToInt32(adp.Update(PublicPropertise.ProductionID, strName, intActivityID, Convert.ToInt32(CurrentUser.Instance.UserID)));

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

            if (txtName.Text.Trim() == string.Empty)
            {
                txtName.Focus();
                blnResult = false;
            }

            else if (cmbActivity.SelectedItem == null)
            {
                cmbActivity.Focus();
                blnResult = false;
            }

            return blnResult;
        }

        private void SetVariables()
        {
            strName = txtName.Text.Trim();
            if (cmbActivity.Value != null)
                intActivityID = Convert.ToInt32(cmbActivity.Value);
        }

        #endregion

        #region Events

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.OnSave();

            //Baran.Production.frmBaseProduction ofrm = new frmBaseProduction(ProductionID);
            //PublicPropertise.ActivityID = intActivityID;
            //ofrm.ShowDialog();

        }

        private void cmbBusinessCategory_ValueChanged(object sender, EventArgs e)
        {
            cmbBusiness.Value = null;
            cmbActivity.Value = null;

            try
            {
                if (cmbBusinessCategory.Value != null)
                {
                    ComboBoxSetting.FillComboBox(PublicEnum.EnmComboSource.srcBusinessByBusinessCategoryID, cmbBusiness, cmbBusinessCategory.Value.ToString());
                }
                else
                {
                    cmbBusiness.Value = null;
                }
            }
            catch
            {
                cmbBusinessCategory.Value = null;
                cmbBusiness.Value = null;
                cmbActivity.Value = null;
            }

        }

        private void cmbBusiness_ValueChanged(object sender, EventArgs e)
        {
            cmbActivity.Value = null;

            try
            {
                if (cmbBusiness.Value != null)
                {
                    ComboBoxSetting.FillComboBox(PublicEnum.EnmComboSource.srcActivityByBusinessID, cmbActivity, cmbBusiness.Value.ToString());
                }
                else
                {
                    cmbBusiness.Value = null;
                }
            }
            catch
            {
                cmbBusiness.Value = null;
                cmbActivity.Value = null;
            }
        }

        #endregion
    }
}
