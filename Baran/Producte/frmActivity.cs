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
    public partial class frmActivity : Baran.Base_Forms.frmSecondChildBase
    {

        #region Constractor

        public frmActivity()
        {
            InitializeComponent();
        }

        public frmActivity(int activityID)
        {
            InitializeComponent();

            ActivityID = activityID;
            this.SetControlsValue();
        }

        #endregion

        #region Variables

        BaranDataAccess.Product.dstProductTableAdapters.spr_cmn_Activity_SelectTableAdapter adp =
            new BaranDataAccess.Product.dstProductTableAdapters.spr_cmn_Activity_SelectTableAdapter();

        internal string
            strName;

        internal int
            intBusinessID;
        #endregion

        #region Propertise

        private int _activityID;
        public int ActivityID
        {
            get
            {
                return _activityID;
            }
            set
            {
                _activityID = value;
            }
        }

        #endregion

        #region Methods

        public override void OnformLoad()
        {
            base.OnformLoad();
            ComboBoxSetting.FillComboBox(PublicEnum.EnmComboSource.srcBusiness, cmbBusiness);
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

                ActivityID = Convert.ToInt32( adp.Insert(strName, intBusinessID));

                if (ActivityID > 0)
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
            if (ActivityID <= 0)
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
                int RowAffected = Convert.ToInt32( adp.Update(ActivityID, strName, intBusinessID));

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

            if (ActivityID <= 0)
            {
                OnMessage(BaranResources.SavedNotLastTime, PublicEnum.EnmMessageCategory.Warning);
                return;
            }

            DialogResult msgResult = MessageBoxX.ShowMessageBox(PublicEnum.EnmMessageType.msgDeleteConfirm);
            if (msgResult == DialogResult.No) return;
            try
            {
                int RowAffected = Convert.ToInt32(adp.Delete(ActivityID));
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
            BaranDataAccess.Product.dstProduct.spr_cmn_Activity_SelectRow drw;
            try
            {                
                drw = adp.GetActivityByIDTable(ActivityID)[0];

                txtName.Text = drw.Name;
                cmbBusiness.Value = drw.IsFk_BusinessIDNull() ? -1 : drw.Fk_BusinessID;


            }
            catch
            {
                OnMessage(BaranResources.DoNotDoPleaseTryAgine, PublicEnum.EnmMessageCategory.Warning);
            }
        }

        private void SetVariables()
        {
            strName = txtName.Text.Trim();
            intBusinessID = Convert.ToInt32( cmbBusiness.Value);
        }

        private bool ControlsValidation()
        {
            bool blnResult = true;

            if (txtName.Text.Trim() == string.Empty)
            {
                txtName.Focus();
                blnResult = false;
            }
            else if (cmbBusiness.Value == null)
            {
                cmbBusiness.Focus();
                blnResult = false;
            }

            return blnResult;
        }

        #endregion

        #region Events

        #endregion
    }
}
