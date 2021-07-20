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
    public partial class frmBusiness : Baran.Base_Forms.frmSecondChildBase
    {

       #region Constractor

        public frmBusiness()
        {
            InitializeComponent();
        }

        public frmBusiness(int businessID)
        {
            InitializeComponent();

            BusinessID = businessID;
            this.SetControlsValue();
        }

        #endregion

        #region Variables

        BaranDataAccess.Product.dstProductTableAdapters.spr_cmn_Business_SelectTableAdapter adp =
            new BaranDataAccess.Product.dstProductTableAdapters.spr_cmn_Business_SelectTableAdapter();

        internal string
            strNameEn,
            strNameFa;

        internal int
            intBusinessCategory;
        #endregion

        #region Propertise

        private int _businessID;
        public int BusinessID
        {
            get
            {
                return _businessID;
            }
            set
            {
                _businessID = value;
            }
        }

        #endregion

        #region Methods

        public override void OnformLoad()
        {
            base.OnformLoad();

            ComboBoxSetting.FillComboBox(PublicEnum.EnmComboSource.srcBusinessCategory, cmbBusinessCategory);

        }

        public override void OnSave()
        {
            base.OnSave();

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

                BusinessID = Convert.ToInt32( adp.Insert(strNameEn, strNameFa, intBusinessCategory));

                if (BusinessID > 0)
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
        }

        public override void OnChange()
        {
            base.OnChange();
            if (BusinessID <= 0)
            {
                OnMessage(BaranResources.SavedNotLastTime, PublicEnum.EnmMessageCategory.Warning);
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
                int RowAffected = Convert.ToInt32( adp.Update(BusinessID, strNameEn, strNameFa, intBusinessCategory));

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

            if (BusinessID <= 0)
            {
                OnMessage(BaranResources.SavedNotLastTime, PublicEnum.EnmMessageCategory.Warning);
                return;
            }

            DialogResult msgResult = MessageBoxX.ShowMessageBox(PublicEnum.EnmMessageType.msgDeleteConfirm);
            if (msgResult == DialogResult.No) return;
            try
            {
                int RowAffected = Convert.ToInt32(adp.Delete(BusinessID));
                if (RowAffected > 0)
                {
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

        private void SetControlsValue()
        {
            BaranDataAccess.Product.dstProduct.spr_cmn_Business_SelectRow drw;
            try
            {                
                drw = adp.GetBusinessByIDTable(BusinessID)[0];

                txtName.Text = drw.IsNameFaNull() ? string.Empty : drw.NameFa;
                cmbBusinessCategory.Value = drw.IsFk_BusinessCategoryIDNull() ? -1 : drw.Fk_BusinessCategoryID;


            }
            catch
            {
                OnMessage(BaranResources.DoNotDoPleaseTryAgine, PublicEnum.EnmMessageCategory.Warning);
            }
        }

        private void SetVariables()
        {
            strNameFa = txtName.Text.Trim();
            intBusinessCategory = Convert.ToInt32( cmbBusinessCategory.Value);
        }

        private bool ControlsValidation()
        {
            bool blnResult = true;

            if (txtName.Text.Trim() == string.Empty)
            {
                txtName.Focus();
                blnResult = false;
            }
            else if (cmbBusinessCategory.Value == null)
            {
                cmbBusinessCategory.Focus();
                blnResult = false;
            }

            return blnResult;
        }

        #endregion

        #region Events

        #endregion
    }
}
