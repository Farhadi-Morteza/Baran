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
    public partial class frmProductionTaskDoc : Baran.Base_Forms.frmSecondChildBase
    {


        private void groupBox1_Click(object sender, EventArgs e)
        {

        }

        #region Constractor

        public frmProductionTaskDoc(int productionTaskID)
        {
            InitializeComponent();
            ProductinTaskID = productionTaskID;
        }

        public frmProductionTaskDoc(int productionTaskID, int productionTaskDocID)
        {
            InitializeComponent();


            ProductinTaskDocID = productionTaskDocID;
            ProductinTaskID = productionTaskID;
            this.SetControlsValue();

        }

        #endregion

        #region Variables

        string strName, strDescription;
        byte[] bytImage;
        WaiteForm waite;

        BaranDataAccess.Production.dstProductionTaskTableAdapters.spr_prd_ProductionTask_Doc_SelectTableAdapter adp =
    new BaranDataAccess.Production.dstProductionTaskTableAdapters.spr_prd_ProductionTask_Doc_SelectTableAdapter();

        #endregion

        #region Propertise

        private int _ProductinTaskDocID;
        public int ProductinTaskDocID
        {
            get
            {
                return _ProductinTaskDocID;
            }
            set
            {
                _ProductinTaskDocID = value;

            }
        }

        private int _ProductinTaskID;
        public int ProductinTaskID
        {
            get
            {
                return _ProductinTaskID;
            }
            set
            {
                _ProductinTaskID = value;

            }
        }

        #endregion

        #region Methods

        public override void OnSave()
        {
            base.OnSave();


            //if (DocumentID > 0)
            //{
            //    OnMessage(BaranResources.SavedLastTime, PublicEnum.EnmMessageCategory.Warning);
            //    return;
            //}

            if (!this.ControlsValidation()) return;

            SetVariables();

            DialogResult msgResult = MessageBoxX.ShowMessageBox(PublicEnum.EnmMessageType.msgSaveConfirm);
            if (msgResult == DialogResult.No) return;

            waite = new WaiteForm();
            try
            {
                waite.Show();
                int RowAffected = Convert.ToInt32(adp.Insert(ProductinTaskID, strName, strDescription, bytImage, CurrentUser.Instance.UserID));

                if (RowAffected > 0)
                {
                    OnMessage(BaranResources.SaveSuccessful, PublicEnum.EnmMessageCategory.Success);
                    DialogResult = System.Windows.Forms.DialogResult.OK;
                }
                else
                {
                    OnMessage(BaranResources.SaveFail, PublicEnum.EnmMessageCategory.Warning);
                    DialogResult = System.Windows.Forms.DialogResult.No;
                }
            }
            catch
            {
                OnMessage(BaranResources.DoNotDoPleaseTryAgine, PublicEnum.EnmMessageCategory.Warning);
                DialogResult = System.Windows.Forms.DialogResult.No;
            }
            
            waite.Close();
        }

        public override void OnChange()
        {
            base.OnChange();

            if (ProductinTaskDocID < 0)
            {
                OnMessage(BaranResources.SavedNotLastTime, PublicEnum.EnmMessageCategory.Warning);
                return;
            }

            if (!this.ControlsValidation()) return;

            SetVariables();
            DialogResult msgResult = MessageBoxX.ShowMessageBox(PublicEnum.EnmMessageType.msgEditConfirm);
            if (msgResult == DialogResult.No) return;

            waite = new WaiteForm();
            try
            {
                waite.Show();

                int RowAffected = Convert.ToInt32(adp.Update(ProductinTaskDocID, ProductinTaskID,strName, strDescription, bytImage, (int)CurrentUser.Instance.UserID));

                if (RowAffected > 0)
                {
                    OnMessage(BaranResources.EditSuccessful, PublicEnum.EnmMessageCategory.Success);
                    DialogResult = System.Windows.Forms.DialogResult.OK;
                }
                else
                {
                    OnMessage(BaranResources.EditFail, PublicEnum.EnmMessageCategory.Warning);
                    DialogResult = System.Windows.Forms.DialogResult.No;
                }
            }
            catch
            {
                OnMessage(BaranResources.DoNotDoPleaseTryAgine, PublicEnum.EnmMessageCategory.Warning);
                DialogResult = System.Windows.Forms.DialogResult.No;
            }

            waite.Close();
        }

        public override void OnDelete()
        {
            base.OnDelete();


            DialogResult msgResult = MessageBoxX.ShowMessageBox(PublicEnum.EnmMessageType.msgEditConfirm);
            if (msgResult == DialogResult.No) return;
            try
            {
                int RowAffected = (int)adp.Delete(ProductinTaskDocID,(int)CurrentUser.Instance.UserID);

                if (RowAffected > 0)
                {
                    OnMessage(BaranResources.DeleteSuccessful, PublicEnum.EnmMessageCategory.Success);
                    ControlsSetting.ClearControls(grpMain.Controls);
                    DialogResult = System.Windows.Forms.DialogResult.Yes;
                }
                else
                {
                    OnMessage(BaranResources.DeleteFail, PublicEnum.EnmMessageCategory.Warning);
                    DialogResult = System.Windows.Forms.DialogResult.No;
                }

            }
            catch
            {
                OnMessage(BaranResources.DoNotDoPleaseTryAgine, PublicEnum.EnmMessageCategory.Warning);
                DialogResult = System.Windows.Forms.DialogResult.No;
            }
        }

        public override void OnClear()
        {
            base.OnClear();
            ControlsSetting.ClearControls(grpControls.Controls);
            picImage.Image = null;
        }

        private bool ControlsValidation()
        {
            bool blnResult = true;

            if(txtName.Text.Trim()== string.Empty)
            {
                OnMessage(BaranResources.FeildIsEmpty, PublicEnum.EnmMessageCategory.Warning);
                txtName.Focus();
                blnResult = false;
            }
            else if (picImage.Image == null)
            {
                OnMessage(BaranResources.FeildIsEmpty, PublicEnum.EnmMessageCategory.Warning);
                btnShow.Focus();
                blnResult = false;
            }
            

            return blnResult;
        }

        private void SetVariables()
        {
            strName = txtName.Text.Trim();
            strDescription = txtDescription.Text.Trim();
            bytImage = PublicMethods.ImageToArray(picImage.Image);
        }

        private void SetControlsValue()
        {
            BaranDataAccess.Production.dstProductionTask.spr_prd_ProductionTask_Doc_SelectRow rw;
            rw =  adp.GetProductionTaskDocByIDTable(ProductinTaskDocID)[0];

            txtName.Text = rw.Name;
            txtDescription.Text = rw.Description;
            picImage.Image = PublicMethods.ArrayToImage(rw.Document);

        }

        #endregion

        #region Events

        private void btnShow_Click(object sender, EventArgs e)
        {
            picImage.Image = Baran.Classes.Common.PublicMethods.PictureOpenFileDialog();
        }

        #endregion

    }
}
