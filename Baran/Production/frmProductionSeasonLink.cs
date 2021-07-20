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
    public partial class frmProductionSeasonLink : Baran.Base_Forms.frmSecondChildBase
    {

        #region Constractor

        public frmProductionSeasonLink()
        {
            InitializeComponent();
        }

        #endregion

        #region Variables

        BaranDataAccess.Production.dstProductsTableAdapters.spr_prd_Season_SelectTableAdapter adp =
            new BaranDataAccess.Production.dstProductsTableAdapters.spr_prd_Season_SelectTableAdapter();

        string
            strSeasonName;

        int intStatusID, intTasklistCropID;

        private Nullable<DateTime>
            FromDate
            , ToDate;

        #endregion

        #region Propertise



        //private int _FieldID;
        //public int FieldID
        //{
        //    get
        //    {
        //        return _FieldID;
        //    }
        //    set
        //    {
        //        _FieldID = value;
        //    }
        //}

        //private int _productionID;
        //public int ProductionID
        //{
        //    get
        //    {
        //        return _productionID;
        //    }
        //    set
        //    {
        //        _productionID = value;
        //    }
        //}

        private int _seasonID;
        public int SeasonID
        {
            get
            {
                return _seasonID;
            }
            set
            {
                _seasonID = value;
            }
        }
        #endregion

        #region Methods

        public override void OnformLoad()
        {
            base.OnformLoad();

            ComboBoxSetting.FillComboBox(PublicEnum.EnmComboSource.srcTasklistCropByCropID, cmbTasklistCrop, PublicPropertise.CropID.ToString());
            ComboBoxSetting.FillComboBox(PublicEnum.EnmComboSource.srcStatus, cmbStatus);

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

            //if (PublicPropertise.ProductionFieldID > 0)
            //{
            //    OnMessage(BaranResources.SavedLastTime, PublicEnum.EnmMessageCategory.Warning);
            //    return;
            //}

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
                int RowAffected = Convert.ToInt32(adp.Insert(strSeasonName, FromDate, ToDate, PublicPropertise.ProductionID, intTasklistCropID, intStatusID, CurrentUser.Instance.UserID));
                if (RowAffected > 0)
                {
                    MessageBoxX.ShowMessageBox(PublicEnum.EnmMessageType.msgSaveSuccessful);


                    Baran.Production.frmProductionTaskList ofrm = new frmProductionTaskList();

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
            if (this.SeasonID <= 0)
            {
                this.OnSave();
                //OnMessage(BaranResources.SavedNotLastTime, PublicEnum.EnmMessageCategory.Warning);
                //return;
            }

            base.OnChange();

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

                int RowAffected = Convert.ToInt32(adp.Update(SeasonID,strSeasonName, FromDate, ToDate, PublicPropertise.ProductionID, intTasklistCropID, intStatusID, CurrentUser.Instance.UserID));

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

            if (SeasonID <= 0)
            {
                OnMessage(BaranResources.SavedNotLastTime, PublicEnum.EnmMessageCategory.Warning);
                return;
            }

            DialogResult msgResult = MessageBoxX.ShowMessageBox(PublicEnum.EnmMessageType.msgDeleteConfirm);
            if (msgResult == DialogResult.No) return;
            try
            {
                int RowAffected = (int)adp.Delete(SeasonID, CurrentUser.Instance.UserID);
                if (RowAffected > 0)
                {
                    OnMessage(BaranResources.DeleteSuccessful, PublicEnum.EnmMessageCategory.Success);
                    SeasonID = 0;
                    this.OnClear();
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
            dstTask1.spr_tsk_TasklistCrop_lst_ByTasklistID_Select.Clear();
        }

        private bool ControlsValidation()
        {
            bool blnResult = true;

            if (txtSeasonName.Text.Trim() == string.Empty)
            {
                txtSeasonName.Focus();
                blnResult = false;
            }
            else if (mskFromDate.Value.ToString() == "")
            {
                mskFromDate.Focus();
                blnResult = false;
            }
            else if (mskToDate.Value.ToString() == "")
            {
                mskToDate.Focus();
                blnResult = false;
            }
            else if (cmbStatus.Value == null)
            {
                cmbStatus.Focus();
                blnResult = false;
            }
            //else if (cmbTasklistCrop.Value == null)
            //{
            //    cmbTasklistCrop.Focus();
            //    blnResult = false;
            //}

            return blnResult;
        }

        private void SetVariables()
        {
            strSeasonName = txtSeasonName.Text.Trim();
            intStatusID = Convert.ToInt32(cmbStatus.Value);
            intTasklistCropID = Convert.ToInt32(cmbTasklistCrop.Value);

            if (mskFromDate.Text != null)
                FromDate =  DateTimeUtility.ToGregorian(mskFromDate.Value.ToString());// PublicMethods.ShamsiToMiladi(mskFromDate.Value.ToString());

            if (mskToDate.Text != null)
                ToDate = DateTimeUtility.ToGregorian(mskToDate.Text);//.Value.ToString());// PublicMethods.ShamsiToMiladi(mskToDate.Text);//.Value.ToString());// DateTimeUtility.ToGregorian(mskToDate.Text);
        }

        private void SetControlsValue()
        {
            BaranDataAccess.Production.dstProducts.spr_prd_Season_SelectRow drw;
            try
            {
                drw = adp.GetSeasonByProductionIDTable(PublicPropertise.ProductionID)[0];

                SeasonID = drw.SeasonID;

                txtSeasonName.Text = drw.SeasonName;
                mskFromDate.Text = drw.IsStartDateNull() ? null : DateTimeUtility.ToPersian(drw.StartDate);
                mskToDate.Text = drw.IsEndDateNull() ? null : DateTimeUtility.ToPersian(drw.EndDate);
                cmbStatus.Value = drw.IsFK_StatusNull() ? null : cmbStatus.Value = drw.FK_Status;
                cmbTasklistCrop.Value = drw.IsFk_TasklistCropIDNull() ? null : cmbTasklistCrop.Value = drw.Fk_TasklistCropID;
            }
            catch { }
        }

        #endregion

        #region Events

        private void cmbTasklistCrop_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                dstTask1.spr_tsk_TasklistCrop_lst_ByTasklistID_Select.Clear();

                if (cmbTasklistCrop.Value != null)
                {
                    int tasklistID = Convert.ToInt32(cmbTasklistCrop.Value);

                    BaranDataAccess.Task.dstTaskTableAdapters.spr_tsk_TasklistCrop_lst_ByTasklistID_SelectTableAdapter adp =
                        new BaranDataAccess.Task.dstTaskTableAdapters.spr_tsk_TasklistCrop_lst_ByTasklistID_SelectTableAdapter();

                    adp.FillTasklistCropListByTasklistIDTable(dstTask1.spr_tsk_TasklistCrop_lst_ByTasklistID_Select, tasklistID);
                    grdItem.Visible = true;
                }
            }
            catch
            {
                grdItem.Visible = false;
            }
        }

        #endregion

        private void groupBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
