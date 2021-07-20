using Baran.Classes.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Baran.Common
{
    public partial class frmDocument : Baran.Base_Forms.frmSecondChildBase
    {
        #region Constractor

        public frmDocument()
        {
            InitializeComponent();
              
        }

        public frmDocument(int documentID)
        {
            InitializeComponent();
              

            DocumentID = documentID;
            this.SetControlsValue();

        }

        #endregion

        #region Variables
        string strName, strDescription;
        byte[] bytImage;
        WaiteForm waite;
        #endregion

        #region Propertise

        private static frmDocument _frmDocument = null;
        public static frmDocument Instanc
        {
            get
            {
                if (_frmDocument == null)
                { _frmDocument = new frmDocument(); }
                return _frmDocument;

            }
        }

        private int _documentID;
        public int DocumentID
        {
            get
            {
                return _documentID;
            }
            set
            {
                _documentID = value;

            }
        }

        private int? _companyID;
        public int? CompanyID
        {
            get
            {
                return _companyID;
            }
            set
            {
                _companyID = value;
         
            }
        }

        private int? _CollectionID;
        public int? CollectionID
        {
            get
            {
                return _CollectionID;
            }
            set
            {
                _CollectionID= value;
         
            }
        }

        private int? _subcollectionID;
        public int? SubcollectionID
        {
            get
            {
                return _subcollectionID;
            }
            set
            {
                _subcollectionID= value;
         
            }
        }
        
        private int? _partID;
        public int? PartID
        {
            get
            {
                return _partID;
            }
            set
            {
                _partID= value;
         
            }
        }	

        private int? _fieldID;
        public int? FieldID
        {
            get
            {
                return _fieldID;
            }
            set
            {
                _fieldID= value;
         
            }
        }

        private int? _warehouseID;
        public int? WarehouseID
        {
            get
            {
                return _warehouseID;
            }
            set
            {
                _warehouseID= value;
         
            }
        }

        private int? _buildingID;
        public int? BuildingID
        {
            get
            {
                return _buildingID;
            }
            set
            {
                _buildingID= value;
         
            }
        }
	
        private int? _machineryID;
        public int? MachineryID
        {
            get
            {
                return _machineryID;
            }
            set
            {
                _machineryID= value;         
            }
        }

        private int? _waterID;
        public int? WaterID
        {
            get
            {
                return _waterID;
            }
            set
            {
                _waterID= value;         
            }
        }

        private int? _waterStorageID;
        public int? WaterStorageID
        {
            get
            {
                return _waterStorageID;
            }
            set
            {
                _waterStorageID= value;         
            }
        }

        private int? _waterTransmissionLineID;
        public int? WaterTransmissionLineID
        {
            get
            {
                return _waterTransmissionLineID;
            }
            set
            {
                _waterTransmissionLineID= value;         
            }
        }

        private int? _treeID;
        public int? TreeID
        {
            get
            {
                return _treeID;
            }
            set
            {
                _treeID = value;
            }
        }

        #endregion

        #region Methods

        public override void OnSave()
        {
            base.OnSave();

            BaranDataAccess.Common.dstCommonTableAdapters.spr_cmn_Document_SelectTableAdapter adp =
                new BaranDataAccess.Common.dstCommonTableAdapters.spr_cmn_Document_SelectTableAdapter();

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
                DocumentID = Convert.ToInt32(adp.New_Document_Insert(strName, strDescription, bytImage, CompanyID, CollectionID, SubcollectionID, PartID, FieldID, WarehouseID, BuildingID, MachineryID, WaterID, WaterStorageID, WaterTransmissionLineID, TreeID, CurrentUser.Instance.UserID));

                if (DocumentID > 0)
                    OnMessage(BaranResources.SaveSuccessful, PublicEnum.EnmMessageCategory.Success);
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
            BaranDataAccess.Common.dstCommonTableAdapters.spr_cmn_Document_SelectTableAdapter adp =
                new BaranDataAccess.Common.dstCommonTableAdapters.spr_cmn_Document_SelectTableAdapter();

            if (DocumentID < 0)
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

                int RowAffected = Convert.ToInt32(adp.Update(DocumentID,strName, strDescription, bytImage, CompanyID, CollectionID, SubcollectionID, PartID, FieldID, WarehouseID, BuildingID, MachineryID, WaterID, WaterStorageID, WaterTransmissionLineID, TreeID, (int)CurrentUser.Instance.UserID));

                if (RowAffected > 0)
                    OnMessage(BaranResources.EditSuccessful, PublicEnum.EnmMessageCategory.Success);
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

            BaranDataAccess.Common.dstCommonTableAdapters.spr_cmn_Document_SelectTableAdapter adp =
                 new BaranDataAccess.Common.dstCommonTableAdapters.spr_cmn_Document_SelectTableAdapter();

            DialogResult msgResult = MessageBoxX.ShowMessageBox(PublicEnum.EnmMessageType.msgEditConfirm);
            if (msgResult == DialogResult.No) return;
            try
            {
                int RowAffected = (int)adp.Delete(DocumentID,(int)CurrentUser.Instance.UserID);

                if (RowAffected > 0)
                {
                    OnMessage(BaranResources.DeleteSuccessful, PublicEnum.EnmMessageCategory.Success);
                    ControlsSetting.ClearControls(grpMain.Controls);
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
                btnShowPic.Focus();
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
            BaranDataAccess.Common.dstCommonTableAdapters.spr_cmn_Document_SelectTableAdapter adp = 
                new BaranDataAccess.Common.dstCommonTableAdapters.spr_cmn_Document_SelectTableAdapter();
            BaranDataAccess.Common.dstCommon.spr_cmn_Document_SelectDataTable tbl = 
                new BaranDataAccess.Common.dstCommon.spr_cmn_Document_SelectDataTable();
            BaranDataAccess.Common.dstCommon.spr_cmn_Document_SelectRow rw;

            adp.FillDocumentByIDTable(tbl, DocumentID);
            rw = tbl[0];

            txtName.Text = rw.Name;
            txtDescription.Text = rw.Description;
            picImage.Image = PublicMethods.ArrayToImage(rw.Document);

        }

        #endregion

        #region Events

        private void btnShowPic_Click(object sender, EventArgs e)
        {
            picImage.Image = Baran.Classes.Common.PublicMethods.PictureOpenFileDialog();

        }

        #endregion
    }
}
























