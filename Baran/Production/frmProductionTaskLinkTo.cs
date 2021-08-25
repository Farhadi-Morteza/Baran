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
    public partial class frmProductionTaskLinkTo : Baran.Base_Forms.frmSecondChildBase
    {

        #region Constractor

        public frmProductionTaskLinkTo(int productionTaskID)
        {
            InitializeComponent();
            ProductionTaskID = productionTaskID;
            
        }

        #endregion

        #region Variables

        int intTaskID, intStatusID, intTaskCategoryID, intTaskSubCategoryID, intPersonID;

        private Nullable<DateTime>
            dtmStartDate
            , dtmEndDate;

        string strTaskName, strDescription;


        #endregion

        #region Propertise

        private int _procutionTaskID;
        public int ProductionTaskID
        {
            get
            {
                return _procutionTaskID;
            }
            set
            {
                _procutionTaskID = value;
            }
        }

        private int? _taskCategoryID;
        public int? TaskCategoryID
        {
            get
            {
                return _taskCategoryID;
            }
            set
            {
                _taskCategoryID = value;
            }
        }

        private int _productionTaskPersonID ;
        public int ProductionTaskPersonID 
        {
            get
            {
                return _productionTaskPersonID;
            }
            set
            {
                _productionTaskPersonID = value;
            }
        }

        private int _productionTaskMachineryID;
        public int ProductionTaskMachineryID
        {
            get
            {
                return _productionTaskMachineryID;
            }
            set
            {
                _productionTaskMachineryID = value;
            }
        }

        private int _productionTaskFertilizerID;
        public int ProductionTaskFertilizerID
        {
            get
            {
                return _productionTaskFertilizerID;
            }
            set
            {
                _productionTaskFertilizerID = value;
            }
        }

        private int _productionTaskPesticideID;
        public int ProductionTaskPesticideID
        {
            get
            {
                return _productionTaskPesticideID;
            }
            set
            {
                _productionTaskPesticideID = value;
            }
        }

        private int _productionTaskWaterID;
        public int ProductionTaskWaterID
        {
            get
            {
                return _productionTaskWaterID;
            }
            set
            {
                _productionTaskWaterID = value;
            }
        }

        private int _productionTaskWaterStorageID;
        public int ProductionTaskWaterStorageID
        {
            get
            {
                return _productionTaskWaterStorageID;
            }
            set
            {
                _productionTaskWaterStorageID = value;
            }
        }

        private int _productionTaskDocID;
        public int ProductionTaskDocID
        {
            get
            {
                return _productionTaskDocID;
            }
            set
            {
                _productionTaskDocID = value;
            }
        }

        private int _productionTaskDiscussionID;
        public int ProductionTaskDiscussionID
        {
            get
            {
                return _productionTaskDiscussionID;
            }
            set
            {
                _productionTaskDiscussionID = value;
            }
        }

        private int _productionTaskChemicalAnalysID;
        public int ProductionTaskChemicalAnalysID
        {
            get
            {
                return _productionTaskChemicalAnalysID;
            }
            set
            {
                _productionTaskChemicalAnalysID = value;
            }
        }

        #endregion

        #region Methods

        public override void OnformLoad()
        {
            base.OnformLoad();

            this.SetControlsValue();

            ComboBoxSetting.FillComboBox(PublicEnum.EnmComboSource.srcStatus, cmbStatus);
            ComboBoxSetting.FillComboBox(PublicEnum.EnmComboSource.srcTaskCategory, cmbTaskCategory);
            //ComboBoxSetting.FillComboBox(PublicEnum.EnmComboSource.srcTaskSubCategory, cmbTaskSubCategory);
            ComboBoxSetting.FillComboBox(PublicEnum.EnmComboSource.srcPersonByPersonCategoryIDCmb, cmbPerson, cnsPersonCategory.Expert.ToString());
            ComboBoxSetting.FillComboBox(PublicEnum.EnmComboSource.srcPersonByPersonCategoryIDCmb, cmbWorker, cnsPersonCategory.Worker.ToString());
            ComboBoxSetting.FillComboBox(PublicEnum.EnmComboSource.srcMachineryByUserIDCmb, cmbMachinery, CurrentUser.Instance.UserID.ToString());

            if (TaskCategoryID == cnsTaskCategory.Fertilizer)
            {
                dstProduct1.spr_src_Fertilizer_cmbLst_Select.Clear();
                BaranDataAccess.Product.dstProductTableAdapters.spr_src_Fertilizer_cmbLst_SelectTableAdapter adpFertilizer =
                    new BaranDataAccess.Product.dstProductTableAdapters.spr_src_Fertilizer_cmbLst_SelectTableAdapter();
                adpFertilizer.FillFertilizerCmdLstTable(dstProduct1.spr_src_Fertilizer_cmbLst_Select);

                this.FillFertilizerGrid();

                egbFertilizer.Visible = true;
                egbFertilizer.Expanded = true;
            }

            if (TaskCategoryID == cnsTaskCategory.Protection)
            {
                dstProduct1.spr_src_Pesticide_cmbLst_Select.Clear();
                BaranDataAccess.Product.dstProductTableAdapters.spr_src_Pesticide_cmbLst_SelectTableAdapter adpPesticide =
                   new BaranDataAccess.Product.dstProductTableAdapters.spr_src_Pesticide_cmbLst_SelectTableAdapter();
                adpPesticide.FillPesticideCmdLstTable(dstProduct1.spr_src_Pesticide_cmbLst_Select);

                this.FillPesticideGrid();
                egbPesticide.Visible = true;
                egbPesticide.Expanded = true;
            }

            if (TaskCategoryID == cnsTaskCategory.Irrigation)
            {
                ComboBoxSetting.FillComboBox(PublicEnum.EnmComboSource.srcWaterByUserIDCmb, cmbWater, CurrentUser.Instance.UserID.ToString());
                ComboBoxSetting.FillComboBox(PublicEnum.EnmComboSource.srcWaterStorageByUserIDCmb, cmbWaterStorage, CurrentUser.Instance.UserID.ToString());

                this.FillWaterGrid();
                this.FillWaterStorageGrid();

                egbWater.Visible = true;
                egbWater.Expanded = true;

                egbWaterStorage.Visible = true;
                egbWaterStorage.Expanded = true;
            }

            if (TaskCategoryID == cnsTaskCategory.ChemicalAnalysis)
            {
                dstProduct1.spr_src_Pesticide_cmbLst_Select.Clear();
                BaranDataAccess.Product.dstProductTableAdapters.spr_src_ChemicalAnalys_cmbLst_SelectTableAdapter adpChemicalAnalys =
                   new BaranDataAccess.Product.dstProductTableAdapters.spr_src_ChemicalAnalys_cmbLst_SelectTableAdapter();

                adpChemicalAnalys.FillChemicalAnalysCmbLstTable(dstProduct1.spr_src_ChemicalAnalys_cmbLst_Select);

                this.FillChemicalAnalysGrid();
                egbChemicalAnalys.Visible = true;
                egbChemicalAnalys.Expanded = true;
            }

            

            this.FillWorkerGrid();
            this.FillMachineryGrid();
            this.FillDocGrid();
            this.FillDiscussionGrid();

            egbWorker.Expanded = true;
            egbMachinery.Expanded = true;
            egbDocu.Expanded = true;
            egbDiscussion.Expanded = true;
            

            this.Location = new Point(this.Location.X, 0);
            this.Size = new System.Drawing.Size(this.Size.Width, Screen.PrimaryScreen.WorkingArea.Height);
        }

        private void ChangebtnSaveToUpdate(Baran.Windows.Forms.Button button)
        {
            button.Text = "Update";
            button.BackColor = System.Drawing.Color.SkyBlue;
        }

        private void ChangebtnUpdateToSave(Baran.Windows.Forms.Button button)
        {
            button.Text = "Save";
            button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(188)))), ((int)(((byte)(66)))));
        }

        private void SetControlsValue()
        {
            if (ProductionTaskID <= 0)
                return;

            BaranDataAccess.Production.dstProductsTableAdapters.spr_prd_ProductionTask_SelectTableAdapter adp =
                new BaranDataAccess.Production.dstProductsTableAdapters.spr_prd_ProductionTask_SelectTableAdapter();
            BaranDataAccess.Production.dstProducts.spr_prd_ProductionTask_SelectRow drw;

            try
            {
                drw = adp.GetProductionTaskByIDTable(ProductionTaskID)[0];
                TaskCategoryID = drw.IsFk_TaskCategoryIDNull() ? 0 : drw.Fk_TaskCategoryID;

                txtTaskName.Text = drw.TaskName;
                cmbTaskCategory.Value = drw.IsFk_TaskCategoryIDNull() ? null : cmbTaskCategory.Value = drw.Fk_TaskCategoryID;
                cmbTaskSubCategory.Value = drw.IsFk_TaskSubCategoryIDNull() ? null : cmbTaskSubCategory.Value = drw.Fk_TaskSubCategoryID;
                cmbStatus.Value = drw.IsFk_StatusNull() ? null : cmbStatus.Value = drw.Fk_Status;
                cmbPerson.Value = drw.IsFk_PersonIDNull() ? null : cmbPerson.Value = drw.Fk_PersonID;
                mskStartDate.Text = drw.IsStartDateNull() ? null: mskStartDate.Text = DateTimeUtility.ToPersian(drw.StartDate);
                mskEndDate.Text = drw.IsEndDateNull() ? null : mskEndDate.Text = DateTimeUtility.ToPersian(drw.EndDate);
                txtDescription.Text = drw.Descripton;
            }
            catch 
            {
                OnMessage(BaranResources.DoNotDoPleaseTryAgine, PublicEnum.EnmMessageCategory.Warning);
            }

            BaranDataAccess.Production.dstProductsTableAdapters.spr_prd_Season_SelectTableAdapter adpSeason =
                new BaranDataAccess.Production.dstProductsTableAdapters.spr_prd_Season_SelectTableAdapter();
            BaranDataAccess.Production.dstProducts.spr_prd_Season_SelectRow drwSeason;

            try
            {
                drwSeason = adpSeason.GetSeasonByProductionIDTable(PublicPropertise.ProductionID)[0];

                txtSeasonName.Text = drwSeason.SeasonName;
                mskSeasonFromDate.Value = drwSeason.IsStartDateNull() ? null : mskSeasonFromDate.Value = DateTimeUtility.ToPersian( drwSeason.StartDate);
                mskSeasonToDate.Value = drwSeason.IsEndDateNull() ? null : mskSeasonToDate.Value = DateTimeUtility.ToPersian( drwSeason.EndDate);
            }
            catch { }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (ProductionTaskID <= 0)
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

            BaranDataAccess.Production.dstProductsTableAdapters.spr_prd_ProductionTask_SelectTableAdapter adp =
                new BaranDataAccess.Production.dstProductsTableAdapters.spr_prd_ProductionTask_SelectTableAdapter();

            try
            {
                this.SetVariables();
                int RowAffected = Convert.ToInt32(adp.Update(ProductionTaskID, PublicPropertise.ProductionID, intTaskID, intStatusID, dtmStartDate, dtmEndDate, strDescription, strTaskName, intTaskCategoryID, intTaskSubCategoryID, CurrentUser.Instance.UserID, intPersonID));

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

            if (txtTaskName.Text == string.Empty)
            {
                txtTaskName.Focus();
                blnResult = false;
            }
            else if (cmbStatus.Value == null)
            {
                cmbStatus.Focus();
                blnResult = false;
            }

            return blnResult;
        }

        private void SetVariables()
        {
            intStatusID = Convert.ToInt32(cmbStatus.Value);

            strDescription = txtDescription.Text.Trim();
            strTaskName = txtTaskName.Text.Trim();

            if (cmbTaskCategory.Value != null)
                intTaskCategoryID = Convert.ToInt32(cmbTaskCategory.Value);
            if (cmbTaskSubCategory.Value != null)
                intTaskSubCategoryID = Convert.ToInt32(cmbTaskSubCategory.Value);

            if (mskStartDate.Text != null)
                dtmStartDate = DateTimeUtility.ToGregorian(mskStartDate.Value.ToString());
            if (mskEndDate.Text != null)
                dtmEndDate = DateTimeUtility.ToGregorian(mskEndDate.Value.ToString());
            if (cmbPerson.Value != null)
                intPersonID = Convert.ToInt32(cmbPerson.Value);
        }

        #endregion

        #region Events -------------------------------------------------------------------------------------------------------------

        private void ultraGridTask1_SizeChanged(object sender, EventArgs e)
        {
            //ultraExpandableGroupBox1.Size = new System.Drawing.Size(ultraExpandableGroupBox1.Size.Width,  ultraGridTask1.Size.Height + 30);
            //int dfdf = 0;
            //foreach (System.Windows.Forms.Control control in ultraExpandableGroupBoxPanel1.Controls)
            //{
            //    string st = control.Name;
            //    int pp = control.Size.Height;
            //    dfdf += control.Size.Height;
            //}
            //ultraExpandableGroupBox1.Size = ultraGridTask1.Size;// new System.Drawing.Size(ultraExpandableGroupBox1.Size.Width, ultraGridTask1.Size.Height);
        }

        private void cmbTaskCategory_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                cmbTaskSubCategory.Value = null;
                ComboBoxSetting.FillComboBox(PublicEnum.EnmComboSource.srcTaskSubCategoryByTaskCategoryID, cmbTaskSubCategory, cmbTaskCategory.Value.ToString());
            }
            catch
            {
                cmbTaskSubCategory.Value = null;
            }
        }
        #endregion

        #region Worker -------------------------------------------------------------------------------------------------------------

        void FillWorkerGrid()
        {
            BaranDataAccess.Production.dstProductionTaskTableAdapters.spr_prd_ProductionTask_Person_LinkByProductionTaskID_lst_SelectTableAdapter adpWorker =
                new BaranDataAccess.Production.dstProductionTaskTableAdapters.spr_prd_ProductionTask_Person_LinkByProductionTaskID_lst_SelectTableAdapter();
            dstProductionTask1.spr_prd_ProductionTask_Person_LinkByProductionTaskID_lst_Select.Clear();
            try
            {
                adpWorker.FillProductionTaskPersonByProductionTaskIDTable(dstProductionTask1.spr_prd_ProductionTask_Person_LinkByProductionTaskID_lst_Select, ProductionTaskID);
            }
            catch
            {
                OnMessage(BaranResources.DoNotDoPleaseTryAgine, PublicEnum.EnmMessageCategory.Warning);
            }
        }

        private void SetWorkerControlsValue()
        {
            if (grdWorker.ActiveRow == null)
                return;

            try
            {               
                cmbWorker.Value = grdWorker.ActiveRow.Cells[dstProductionTask1.spr_prd_ProductionTask_Person_LinkByProductionTaskID_lst_Select.Fk_PersonIDColumn.ColumnName].Value;
                mskWorkHours.Text = grdWorker.ActiveRow.Cells[dstProductionTask1.spr_prd_ProductionTask_Person_LinkByProductionTaskID_lst_Select.WorkHoursColumn.ColumnName].Value.ToString();
                mskWorkerTreatedArea.Text = grdWorker.ActiveRow.Cells[dstProductionTask1.spr_prd_ProductionTask_Person_LinkByProductionTaskID_lst_Select.TreatedAreaColumn.ColumnName].Value.ToString();
                txtWorkerDescription.Text = grdWorker.ActiveRow.Cells[dstProductionTask1.spr_prd_ProductionTask_Person_LinkByProductionTaskID_lst_Select.DescriptionColumn.ColumnName].Value.ToString();
                mskWorkDate.Value = grdWorker.ActiveRow.Cells[dstProductionTask1.spr_prd_ProductionTask_Person_LinkByProductionTaskID_lst_Select.DateColumn.ColumnName].Value.ToString();
            }
            catch
            {
                OnMessage(BaranResources.DoNotDoPleaseTryAgine, PublicEnum.EnmMessageCategory.Warning);
            }
        }

        private void btnAddWorker_Click(object sender, EventArgs e)
        {        

            if (ProductionTaskID <= 0)
            {
                OnMessage(BaranResources.SavedNotLastTime, PublicEnum.EnmMessageCategory.Warning);
                return;
            }

            if (cmbWorker.Value == null)
            {
                OnMessage(BaranResources.FeildIsEmpty, PublicEnum.EnmMessageCategory.Info);
                cmbWorker.Focus();
                return;
            }
            else if (mskWorkDate.Value.ToString() == string.Empty)
            {
                OnMessage(BaranResources.FeildIsEmpty, PublicEnum.EnmMessageCategory.Info);
                mskWorkDate.Focus();
                return;
            }
            else if (mskWorkHours.Value.ToString() == string.Empty && mskWorkerTreatedArea.Value.ToString() == string.Empty)
            {
                OnMessage(BaranResources.FeildIsEmpty, PublicEnum.EnmMessageCategory.Info);
                mskWorkHours.Focus();
                return;
            }

            int workerID;
            Nullable<TimeSpan> workHours = null;
            Nullable<decimal> workerTreatedArea = null;

            string workerDescription;
            Nullable<DateTime> workDate;

            workerID = Convert.ToInt32(cmbWorker.Value);
            workDate = DateTimeUtility.ToGregorian(mskWorkDate.Value.ToString());
            if(mskWorkHours.Value.ToString() != "")
                workHours = TimeSpan.Parse(mskWorkHours.Value.ToString());
            if(mskWorkerTreatedArea.Value.ToString() != "")                
                workerTreatedArea = Convert.ToDecimal(mskWorkerTreatedArea.Value);
            workerDescription = txtWorkerDescription.Text.Trim() ;

            //Save ------------------------------------------------------------------------------------------------------------------------
            if (ProductionTaskPersonID <= 0)
            {
                DialogResult msgResult = MessageBoxX.ShowMessageBox(PublicEnum.EnmMessageType.msgSaveConfirm);
                if (msgResult == DialogResult.No) return;

                BaranDataAccess.Production.dstProductionTaskTableAdapters.spr_prd_ProductionTask_Person_Link_SelectTableAdapter adpWorker =
                    new BaranDataAccess.Production.dstProductionTaskTableAdapters.spr_prd_ProductionTask_Person_Link_SelectTableAdapter();

                try
                {
                    ProductionTaskPersonID = Convert.ToInt32(adpWorker.NewProductionTask_Person_Link_Insert
                                            (ProductionTaskID
                                            , workerID, workDate, workHours, workerTreatedArea, workerDescription
                                            , CurrentUser.Instance.UserID));
                    if (ProductionTaskPersonID > 0)
                    {
                        OnMessage(BaranResources.SaveSuccessful, PublicEnum.EnmMessageCategory.Success);

                        //Infragistics.Win.UltraWinGrid.UltraGridRow row = grdWorker.DisplayLayout.Bands[0].AddNew();
                        //row.Cells[dstProductionTask1.spr_prd_ProductionTask_Person_LinkByProductionTaskID_lst_Select.ProductionTaskPersonIDColumn.ColumnName].Value = ProductionTaskPersonID;
                        //row.Cells[dstProductionTask1.spr_prd_ProductionTask_Person_LinkByProductionTaskID_lst_Select.Fk_PersonIDColumn.ColumnName].Value = cmbWorker.Value;
                        //row.Cells[dstProductionTask1.spr_prd_ProductionTask_Person_LinkByProductionTaskID_lst_Select.FullNameColumn.ColumnName].Value = cmbWorker.Text;
                        //row.Cells[dstProductionTask1.spr_prd_ProductionTask_Person_LinkByProductionTaskID_lst_Select.WorkHoursColumn.ColumnName].Value = mskWorkHours.Text;
                        //row.Cells[dstProductionTask1.spr_prd_ProductionTask_Person_LinkByProductionTaskID_lst_Select.TreatedAreaColumn.ColumnName].Value = mskWorkerTreatedArea.Text;
                        //row.Cells[dstProductionTask1.spr_prd_ProductionTask_Person_LinkByProductionTaskID_lst_Select.DateColumn.ColumnName].Value = mskWorkDate.Text;
                        //row.Cells[dstProductionTask1.spr_prd_ProductionTask_Person_LinkByProductionTaskID_lst_Select.DescriptionColumn.ColumnName].Value = txtWorkerDescription.Text;

                        this.FillWorkerGrid();
                        ProductionTaskPersonID = 0;

                    }
                    else
                        OnMessage(BaranResources.SaveFail, PublicEnum.EnmMessageCategory.Warning);
                }
                catch
                {
                    OnMessage(BaranResources.DoNotDoPleaseTryAgine, PublicEnum.EnmMessageCategory.Warning);
                }
            }

            // Update ----------------------------------------------------------------------------------------------------------------
            else if (ProductionTaskPersonID > 0)
            {
                DialogResult msgResult = MessageBoxX.ShowMessageBox(PublicEnum.EnmMessageType.msgEditConfirm);
                if (msgResult == DialogResult.No) return;

                BaranDataAccess.Production.dstProductionTaskTableAdapters.spr_prd_ProductionTask_Person_Link_SelectTableAdapter adpWorker =
                    new BaranDataAccess.Production.dstProductionTaskTableAdapters.spr_prd_ProductionTask_Person_Link_SelectTableAdapter();

                try
                {
                    int RowAffected = Convert.ToInt32(adpWorker.Update(
                                    ProductionTaskPersonID
                                    , ProductionTaskID
                                    , workerID, workDate, workHours, workerTreatedArea, workerDescription
                                    , CurrentUser.Instance.UserID));

                    if (RowAffected > 0)
                    {

                        OnMessage(BaranResources.EditSuccessful, PublicEnum.EnmMessageCategory.Success);
                        try
                        {
                            //grdWorker.ActiveRow.Cells[dstProductionTask1.spr_prd_ProductionTask_Person_LinkByProductionTaskID_lst_Select.FullNameColumn.ColumnName].Value = cmbWorker.Text;
                            //grdWorker.ActiveRow.Cells[dstProductionTask1.spr_prd_ProductionTask_Person_LinkByProductionTaskID_lst_Select.DateColumn.ColumnName].Value = mskWorkDate.Text;
                            //grdWorker.ActiveRow.Cells[dstProductionTask1.spr_prd_ProductionTask_Person_LinkByProductionTaskID_lst_Select.WorkHoursColumn.ColumnName].Value = mskWorkHours.Text.Trim();
                            //grdWorker.ActiveRow.Cells[dstProductionTask1.spr_prd_ProductionTask_Person_LinkByProductionTaskID_lst_Select.TreatedAreaColumn.ColumnName].Value = mskWorkerTreatedArea.Text.Trim();
                            //grdWorker.ActiveRow.Cells[dstProductionTask1.spr_prd_ProductionTask_Person_LinkByProductionTaskID_lst_Select.DescriptionColumn.ColumnName].Value = txtWorkerDescription.Text.Trim();

                            this.FillWorkerGrid();

                            ChangebtnUpdateToSave(btnAddWorker);
                            ProductionTaskPersonID = 0;
                        }
                        catch { }
                        
                    }
                    else
                        OnMessage(BaranResources.SaveFail, PublicEnum.EnmMessageCategory.Warning);
                }
                catch
                {
                    OnMessage(BaranResources.DoNotDoPleaseTryAgine, PublicEnum.EnmMessageCategory.Warning);
                }
            }


        }

        private void grdWorker_SizeChanged(object sender, EventArgs e)
        {
            egbWorker.Size = new Size(egbWorker.Size.Width, grpWorker.Size.Height + grdWorker.Size.Height + 60);
        }

        private void grdWorker_ClickCellButton(object sender, Infragistics.Win.UltraWinGrid.CellEventArgs e)
        {
            #region Delete

            if (e.Cell.Column.Key == "Delete")
            {
                BaranDataAccess.Production.dstProductionTaskTableAdapters.spr_prd_ProductionTask_Person_Link_SelectTableAdapter adpWorker =
                    new BaranDataAccess.Production.dstProductionTaskTableAdapters.spr_prd_ProductionTask_Person_Link_SelectTableAdapter();

                try
                {
                    DialogResult msgResult = MessageBoxX.ShowMessageBox(PublicEnum.EnmMessageType.msgDeleteConfirm);
                    if (msgResult == DialogResult.No) return;

                    int RowAffected = (int)adpWorker.Delete(Convert.ToInt32( e.Cell.Row.Cells[dstProductionTask1.spr_prd_ProductionTask_Person_LinkByProductionTaskID_lst_Select.ProductionTaskPersonIDColumn.ColumnName].Value), CurrentUser.Instance.UserID);

                    if (RowAffected > 0)
                    {
                        e.Cell.Row.Delete();
                        OnMessage(BaranResources.DeleteSuccessful, PublicEnum.EnmMessageCategory.Success);
                    }
                    else
                        OnMessage(BaranResources.DeleteFail, PublicEnum.EnmMessageCategory.Warning);                }
                catch
                {
                    OnMessage(BaranResources.DoNotDoPleaseTryAgine, PublicEnum.EnmMessageCategory.Warning);
                }

            }

            #endregion
            #region Update

            if (e.Cell.Column.Key == "Update")
            {
                if (grdWorker.ActiveRow != null)
                {
                    ProductionTaskPersonID = Convert.ToInt32(e.Cell.Row.Cells[dstProductionTask1.spr_prd_ProductionTask_Person_LinkByProductionTaskID_lst_Select.ProductionTaskPersonIDColumn.ColumnName].Value);
                    
                    this.SetWorkerControlsValue();

                    this.ChangebtnSaveToUpdate(btnAddWorker);
                }
            }

            #endregion

        }

        private void grdWorker_Click(object sender, EventArgs e)
        {
            if (grdWorker.ActiveRow == null)
                return;

            this.SetWorkerControlsValue();

            ProductionTaskPersonID = 0;
            ChangebtnUpdateToSave(btnAddWorker);
        }

        #endregion

        #region Machinery -------------------------------------------------------------------------------------------------------------

        private void FillMachineryGrid()
        {
            BaranDataAccess.Production.dstProductionTaskTableAdapters.spr_prd_ProductionTask_Machinery_LinkByProductionTaskID_lst_SelectTableAdapter adpWorker =
               new BaranDataAccess.Production.dstProductionTaskTableAdapters.spr_prd_ProductionTask_Machinery_LinkByProductionTaskID_lst_SelectTableAdapter();
            dstProductionTask1.spr_prd_ProductionTask_Machinery_LinkByProductionTaskID_lst_Select.Clear();
            try
            {
                adpWorker.FillProductionTaskMachineryByProductionTaskIDTable(dstProductionTask1.spr_prd_ProductionTask_Machinery_LinkByProductionTaskID_lst_Select, ProductionTaskID);
            }
            catch
            {
                OnMessage(BaranResources.DoNotDoPleaseTryAgine, PublicEnum.EnmMessageCategory.Warning);
            }
        }

        private void SetMachineryControlsValue()
        {
            if (grdWorker.ActiveRow == null)
                return;

            try
            {
                cmbMachinery.Value = grdMachinery.ActiveRow.Cells[dstProductionTask1.spr_prd_ProductionTask_Machinery_LinkByProductionTaskID_lst_Select.Fk_MachineryIDColumn.ColumnName].Value;
                mskMachineryHours.Text = grdMachinery.ActiveRow.Cells[dstProductionTask1.spr_prd_ProductionTask_Machinery_LinkByProductionTaskID_lst_Select.WorkHoursColumn.ColumnName].Value.ToString();
                mskMachineryTreatedArea.Text = grdMachinery.ActiveRow.Cells[dstProductionTask1.spr_prd_ProductionTask_Machinery_LinkByProductionTaskID_lst_Select.TreatedAreaColumn.ColumnName].Value.ToString();
                txtMachineryDescription.Text = grdMachinery.ActiveRow.Cells[dstProductionTask1.spr_prd_ProductionTask_Machinery_LinkByProductionTaskID_lst_Select.DescriptionColumn.ColumnName].Value.ToString();
                mskMachineryDate.Value = grdMachinery.ActiveRow.Cells[dstProductionTask1.spr_prd_ProductionTask_Machinery_LinkByProductionTaskID_lst_Select.DateColumn.ColumnName].Value.ToString();
            }
            catch
            {
                OnMessage(BaranResources.DoNotDoPleaseTryAgine, PublicEnum.EnmMessageCategory.Warning);
            }
        }

        private void btnAddMachinery_Click(object sender, EventArgs e)
        {
            if (ProductionTaskID <= 0)
            {
                OnMessage(BaranResources.SavedNotLastTime, PublicEnum.EnmMessageCategory.Warning);
                return;
            }

            if (cmbMachinery.Value == null)
            {
                OnMessage(BaranResources.FeildIsEmpty, PublicEnum.EnmMessageCategory.Info);
                cmbMachinery.Focus();
                return;
            }
            else if (mskMachineryDate.Value.ToString() == "")
            {
                OnMessage(BaranResources.FeildIsEmpty, PublicEnum.EnmMessageCategory.Info);
                mskMachineryDate.Focus();
                return;
            }
            else if (mskMachineryHours.Text.Trim() == string.Empty && mskMachineryTreatedArea.Text.Trim() == string.Empty)
            {
                OnMessage(BaranResources.FeildIsEmpty, PublicEnum.EnmMessageCategory.Info);
                mskMachineryHours.Focus();
                return;
            }

            int MachineryID;
            Nullable<TimeSpan> MachineryHours = null;
            Nullable<decimal> MachineryTreatedArea = null;
            string MachineryDescription;
            Nullable<DateTime> MachineryDate;

            MachineryID = Convert.ToInt32(cmbMachinery.Value);
            MachineryDate = DateTimeUtility.ToGregorian(mskMachineryDate.Value.ToString());
            if (mskMachineryHours.Value.ToString()!= "")
                MachineryHours = TimeSpan.Parse(mskMachineryHours.Value.ToString());
            if (mskMachineryTreatedArea.Value.ToString() != "")
                MachineryTreatedArea = Convert.ToDecimal(mskMachineryTreatedArea.Value);
            MachineryDescription = txtMachineryDescription.Text.Trim();

            BaranDataAccess.Production.dstProductionTaskTableAdapters.spr_prd_ProductionTask_Machinery_Link_SelectTableAdapter adpMachinery =
                new BaranDataAccess.Production.dstProductionTaskTableAdapters.spr_prd_ProductionTask_Machinery_Link_SelectTableAdapter();
                

            //Save ------------------------------------------------------------------------------------------------------------------------
            if (ProductionTaskMachineryID <= 0)
            {
                DialogResult msgResult = MessageBoxX.ShowMessageBox(PublicEnum.EnmMessageType.msgSaveConfirm);
                if (msgResult == DialogResult.No) return;


                try
                {
                    ProductionTaskMachineryID = Convert.ToInt32(adpMachinery.NewProductionTask_Machinery_Link_Insert
                                            (ProductionTaskID
                                            , MachineryID, MachineryDate, MachineryHours, MachineryTreatedArea, MachineryDescription
                                            , CurrentUser.Instance.UserID));
                    if (ProductionTaskMachineryID > 0)
                    {
                        OnMessage(BaranResources.SaveSuccessful, PublicEnum.EnmMessageCategory.Success);

                        Infragistics.Win.UltraWinGrid.UltraGridRow row = grdMachinery.DisplayLayout.Bands[0].AddNew();
                        row.Cells[dstProductionTask1.spr_prd_ProductionTask_Machinery_LinkByProductionTaskID_lst_Select.ProductionTaskMachineryIDColumn.ColumnName].Value = ProductionTaskMachineryID;
                        row.Cells[dstProductionTask1.spr_prd_ProductionTask_Machinery_LinkByProductionTaskID_lst_Select.Fk_MachineryIDColumn.ColumnName].Value = cmbMachinery.Value;
                        row.Cells[dstProductionTask1.spr_prd_ProductionTask_Machinery_LinkByProductionTaskID_lst_Select.FullNameColumn.ColumnName].Value = cmbMachinery.Text;
                        row.Cells[dstProductionTask1.spr_prd_ProductionTask_Machinery_LinkByProductionTaskID_lst_Select.WorkHoursColumn.ColumnName].Value = mskMachineryHours.Text;
                        row.Cells[dstProductionTask1.spr_prd_ProductionTask_Machinery_LinkByProductionTaskID_lst_Select.TreatedAreaColumn.ColumnName].Value = mskMachineryTreatedArea.Text;
                        row.Cells[dstProductionTask1.spr_prd_ProductionTask_Machinery_LinkByProductionTaskID_lst_Select.DateColumn.ColumnName].Value = mskMachineryDate.Text;
                        row.Cells[dstProductionTask1.spr_prd_ProductionTask_Machinery_LinkByProductionTaskID_lst_Select.DescriptionColumn.ColumnName].Value = txtMachineryDescription.Text;

                        //grdWorker.Rows[0].Selected = true;
                        ProductionTaskMachineryID = 0;

                    }
                    else
                        OnMessage(BaranResources.SaveFail, PublicEnum.EnmMessageCategory.Warning);
                }
                catch
                {
                    OnMessage(BaranResources.DoNotDoPleaseTryAgine, PublicEnum.EnmMessageCategory.Warning);
                }
            }

            // Update ----------------------------------------------------------------------------------------------------------------
            else if (ProductionTaskMachineryID > 0)
            {
                DialogResult msgResult = MessageBoxX.ShowMessageBox(PublicEnum.EnmMessageType.msgEditConfirm);
                if (msgResult == DialogResult.No) return;

                try
                {
                    int RowAffected = Convert.ToInt32(adpMachinery.Update(
                                    ProductionTaskMachineryID
                                    , ProductionTaskID
                                    , MachineryID, MachineryDate, MachineryHours, MachineryTreatedArea, MachineryDescription
                                    , CurrentUser.Instance.UserID));

                    if (RowAffected > 0)
                    {

                        OnMessage(BaranResources.EditSuccessful, PublicEnum.EnmMessageCategory.Success);
                        try
                        {
                            grdWorker.ActiveRow.Cells[dstProductionTask1.spr_prd_ProductionTask_Machinery_LinkByProductionTaskID_lst_Select.FullNameColumn.ColumnName].Value = cmbMachinery.Text;
                            grdWorker.ActiveRow.Cells[dstProductionTask1.spr_prd_ProductionTask_Machinery_LinkByProductionTaskID_lst_Select.DateColumn.ColumnName].Value = mskMachineryDate.Text;
                            grdWorker.ActiveRow.Cells[dstProductionTask1.spr_prd_ProductionTask_Machinery_LinkByProductionTaskID_lst_Select.WorkHoursColumn.ColumnName].Value = mskMachineryHours.Text.Trim();
                            grdWorker.ActiveRow.Cells[dstProductionTask1.spr_prd_ProductionTask_Machinery_LinkByProductionTaskID_lst_Select.TreatedAreaColumn.ColumnName].Value = mskMachineryTreatedArea.Text.Trim();
                            grdWorker.ActiveRow.Cells[dstProductionTask1.spr_prd_ProductionTask_Machinery_LinkByProductionTaskID_lst_Select.DescriptionColumn.ColumnName].Value = txtMachineryDescription.Text.Trim();

                            ChangebtnUpdateToSave(btnAddMachinery);
                            ProductionTaskMachineryID = 0;
                        }
                        catch { }

                    }
                    else
                        OnMessage(BaranResources.SaveFail, PublicEnum.EnmMessageCategory.Warning);
                }
                catch
                {
                    OnMessage(BaranResources.DoNotDoPleaseTryAgine, PublicEnum.EnmMessageCategory.Warning);
                }
            }

        }

        private void grdMachinery_SizeChanged(object sender, EventArgs e)
        {
            egbMachinery.Size = new Size(egbMachinery.Size.Width, grpMachinery.Size.Height + grdMachinery.Size.Height + 60);
        }

        private void grdMachinery_ClickCellButton(object sender, Infragistics.Win.UltraWinGrid.CellEventArgs e)
        {
            #region Delete
            BaranDataAccess.Production.dstProductionTaskTableAdapters.spr_prd_ProductionTask_Machinery_Link_SelectTableAdapter adpMachinery =
                new BaranDataAccess.Production.dstProductionTaskTableAdapters.spr_prd_ProductionTask_Machinery_Link_SelectTableAdapter();


            if (e.Cell.Column.Key == "Delete")
            {

                try
                {
                    DialogResult msgResult = MessageBoxX.ShowMessageBox(PublicEnum.EnmMessageType.msgDeleteConfirm);
                    if (msgResult == DialogResult.No) return;

                    int RowAffected = (int)adpMachinery.Delete(Convert.ToInt32(e.Cell.Row.Cells[dstProductionTask1.spr_prd_ProductionTask_Machinery_LinkByProductionTaskID_lst_Select.ProductionTaskMachineryIDColumn.ColumnName].Value), CurrentUser.Instance.UserID);

                    if (RowAffected > 0)
                    {
                        e.Cell.Row.Delete();
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

            #endregion
            #region Update

            if (e.Cell.Column.Key == "Update")
            {
                if (grdWorker.ActiveRow != null)
                {
                    ProductionTaskMachineryID = Convert.ToInt32(e.Cell.Row.Cells[dstProductionTask1.spr_prd_ProductionTask_Machinery_LinkByProductionTaskID_lst_Select.ProductionTaskMachineryIDColumn.ColumnName].Value);

                    this.SetMachineryControlsValue();

                    this.ChangebtnSaveToUpdate(btnAddMachinery);
                }
            }

            #endregion
        }

        private void grdMachinery_Click(object sender, EventArgs e)
        {
            
            if (grdMachinery.ActiveRow == null)
                return;

            this.SetMachineryControlsValue();

            ProductionTaskMachineryID = 0;
            ChangebtnUpdateToSave(btnAddMachinery);
        }

        #endregion

        #region Fertilizer -------------------------------------------------------------------------------------------------------------

        private void FillFertilizerGrid()
        {
            BaranDataAccess.Production.dstProductionTaskTableAdapters.spr_prd_ProductionTask_Fertilizer_LinkByProductionTaskID_lst_SelectTableAdapter adpFertilizer =
               new BaranDataAccess.Production.dstProductionTaskTableAdapters.spr_prd_ProductionTask_Fertilizer_LinkByProductionTaskID_lst_SelectTableAdapter();
            dstProductionTask1.spr_prd_ProductionTask_Fertilizer_LinkByProductionTaskID_lst_Select.Clear();
            try
            {
                adpFertilizer.FillProductionTaskFertilizerByProductionTaskIDTable(dstProductionTask1.spr_prd_ProductionTask_Fertilizer_LinkByProductionTaskID_lst_Select, ProductionTaskID);
            }
            catch
            {
                OnMessage(BaranResources.DoNotDoPleaseTryAgine, PublicEnum.EnmMessageCategory.Warning);
            }
        }

        private void SetFertilizerControlsValue()
        {
            if (grdFertilizer.ActiveRow == null)
                return;

            try
            {
                cmbFertilizer.Value = grdFertilizer.ActiveRow.Cells[dstProductionTask1.spr_prd_ProductionTask_Fertilizer_LinkByProductionTaskID_lst_Select.Fk_FertilizerIDColumn.ColumnName].Value;
                mskFertilizerDate.Value = grdFertilizer.ActiveRow.Cells[dstProductionTask1.spr_prd_ProductionTask_Fertilizer_LinkByProductionTaskID_lst_Select.DateColumn.ColumnName].Value.ToString();
                txtFertilizerTreatedArea.Text = grdFertilizer.ActiveRow.Cells[dstProductionTask1.spr_prd_ProductionTask_Fertilizer_LinkByProductionTaskID_lst_Select.TreatedAreaColumn.ColumnName].Value.ToString();
                txtFertilizerDescription.Text = grdFertilizer.ActiveRow.Cells[dstProductionTask1.spr_prd_ProductionTask_Fertilizer_LinkByProductionTaskID_lst_Select.DescriptionColumn.ColumnName].Value.ToString();
                mskFertilizerStartTime.Value = grdFertilizer.ActiveRow.Cells[dstProductionTask1.spr_prd_ProductionTask_Fertilizer_LinkByProductionTaskID_lst_Select.StartTimeColumn.ColumnName].Value.ToString();
                mskFertilizerEndTime.Value = grdFertilizer.ActiveRow.Cells[dstProductionTask1.spr_prd_ProductionTask_Fertilizer_LinkByProductionTaskID_lst_Select.EndTimeColumn.ColumnName].Value.ToString();
                mskFertilizerQuality.Value = grdFertilizer.ActiveRow.Cells[dstProductionTask1.spr_prd_ProductionTask_Fertilizer_LinkByProductionTaskID_lst_Select.QuantityColumn.ColumnName].Value.ToString();

            }
            catch
            {
                OnMessage(BaranResources.DoNotDoPleaseTryAgine, PublicEnum.EnmMessageCategory.Warning);
            }
        }

        private void btnAddFertilizer_Click(object sender, EventArgs e)
        {
            if (ProductionTaskID <= 0)
            {
                OnMessage(BaranResources.SavedNotLastTime, PublicEnum.EnmMessageCategory.Warning);
                return;
            }

            if (cmbFertilizer.Value == null)
            {
                OnMessage(BaranResources.FeildIsEmpty, PublicEnum.EnmMessageCategory.Info);
                cmbFertilizer.Focus();
                return;
            }
            else if (mskFertilizerDate.Value.ToString() == "")
            {
                OnMessage(BaranResources.FeildIsEmpty, PublicEnum.EnmMessageCategory.Info);
                mskFertilizerDate.Focus();
                return;
            }
            else if (mskFertilizerStartTime.Value.ToString() == "")
            {
                OnMessage(BaranResources.FeildIsEmpty, PublicEnum.EnmMessageCategory.Info);
                mskFertilizerStartTime.Focus();
                return;
            }
            else if (mskFertilizerEndTime.Value.ToString() == string.Empty)
            {
                OnMessage(BaranResources.FeildIsEmpty, PublicEnum.EnmMessageCategory.Info);
                mskFertilizerEndTime.Focus();
                return;                
            }
            else if (txtFertilizerTreatedArea.Text.Trim() == string.Empty)
            {
                OnMessage(BaranResources.FeildIsEmpty, PublicEnum.EnmMessageCategory.Info);
                mskMachineryHours.Focus();
                return;
            }

            int FertilizerID;
            string FertilizerDescription;
            Nullable<DateTime> FertilizerDate;
            Nullable<TimeSpan> FertilizerStartTime = null, FertilizerEndTime = null;
            Nullable<decimal> FertilizerQuality = null , FertilizerTreatedArea = null;

            FertilizerID = Convert.ToInt32(cmbFertilizer.Value);
            FertilizerDate = DateTimeUtility.ToGregorian(mskFertilizerDate.Value.ToString());
            if (mskFertilizerStartTime.Value.ToString() != "")
                FertilizerStartTime = TimeSpan.Parse( mskFertilizerStartTime.Value.ToString());
            if (mskFertilizerEndTime.Value.ToString() != "")
                FertilizerEndTime = TimeSpan.Parse( mskFertilizerEndTime.Value.ToString());
            if (txtFertilizerTreatedArea.Text.Trim() != "")
                FertilizerTreatedArea = Convert.ToDecimal(txtFertilizerTreatedArea.Value);
            FertilizerDescription = txtFertilizerDescription.Text.Trim();
            FertilizerQuality = decimal.Parse( mskFertilizerQuality.Value.ToString());

            BaranDataAccess.Production.dstProductionTaskTableAdapters.spr_prd_ProductionTask_Fertilizer_Link_SelectTableAdapter adpFertilizer =
                new BaranDataAccess.Production.dstProductionTaskTableAdapters.spr_prd_ProductionTask_Fertilizer_Link_SelectTableAdapter();

            //Save ------------------------------------------------------------------------------------------------------------------------
            if (ProductionTaskFertilizerID <= 0)
            {
                DialogResult msgResult = MessageBoxX.ShowMessageBox(PublicEnum.EnmMessageType.msgSaveConfirm);
                if (msgResult == DialogResult.No) return;


                try
                {
                    ProductionTaskFertilizerID = Convert.ToInt32(adpFertilizer.NewProductionTask_Fertilizer_Link_Insert
                                            (ProductionTaskID
                                            , FertilizerID, FertilizerDate, FertilizerStartTime,FertilizerEndTime, FertilizerQuality, FertilizerTreatedArea, FertilizerDescription
                                            , CurrentUser.Instance.UserID));
                    if (ProductionTaskFertilizerID > 0)
                    {
                        OnMessage(BaranResources.SaveSuccessful, PublicEnum.EnmMessageCategory.Success);

                        Infragistics.Win.UltraWinGrid.UltraGridRow row = grdFertilizer.DisplayLayout.Bands[0].AddNew();
                        row.Cells[dstProductionTask1.spr_prd_ProductionTask_Fertilizer_LinkByProductionTaskID_lst_Select.ProductionTaskFertilizerIDColumn.ColumnName].Value = ProductionTaskFertilizerID;
                        row.Cells[dstProductionTask1.spr_prd_ProductionTask_Fertilizer_LinkByProductionTaskID_lst_Select.Fk_FertilizerIDColumn.ColumnName].Value = cmbFertilizer.Value;
                        row.Cells[dstProductionTask1.spr_prd_ProductionTask_Fertilizer_LinkByProductionTaskID_lst_Select.NameColumn.ColumnName].Value = cmbFertilizer.Text;
                        row.Cells[dstProductionTask1.spr_prd_ProductionTask_Fertilizer_LinkByProductionTaskID_lst_Select.StartTimeColumn.ColumnName].Value = mskFertilizerStartTime.Text;
                        row.Cells[dstProductionTask1.spr_prd_ProductionTask_Fertilizer_LinkByProductionTaskID_lst_Select.EndTimeColumn.ColumnName].Value = mskFertilizerEndTime.Text;
                        row.Cells[dstProductionTask1.spr_prd_ProductionTask_Fertilizer_LinkByProductionTaskID_lst_Select.TreatedAreaColumn.ColumnName].Value = txtFertilizerTreatedArea.Value;
                        row.Cells[dstProductionTask1.spr_prd_ProductionTask_Fertilizer_LinkByProductionTaskID_lst_Select.DateColumn.ColumnName].Value = mskFertilizerDate.Value;
                        row.Cells[dstProductionTask1.spr_prd_ProductionTask_Fertilizer_LinkByProductionTaskID_lst_Select.DescriptionColumn.ColumnName].Value = txtFertilizerDescription.Text;
                        row.Cells[dstProductionTask1.spr_prd_ProductionTask_Fertilizer_LinkByProductionTaskID_lst_Select.QuantityColumn.ColumnName].Value = mskFertilizerQuality.Value;

                        //grdWorker.Rows[0].Selected = true;
                        ProductionTaskFertilizerID = 0;

                    }
                    else
                        OnMessage(BaranResources.SaveFail, PublicEnum.EnmMessageCategory.Warning);
                }
                catch
                {
                    OnMessage(BaranResources.DoNotDoPleaseTryAgine, PublicEnum.EnmMessageCategory.Warning);
                }
            }

            // Update ----------------------------------------------------------------------------------------------------------------
            else if (ProductionTaskFertilizerID > 0)
            {
                DialogResult msgResult = MessageBoxX.ShowMessageBox(PublicEnum.EnmMessageType.msgEditConfirm);
                if (msgResult == DialogResult.No) return;

                try
                {
                    int RowAffected = Convert.ToInt32(adpFertilizer.Update(
                                    ProductionTaskFertilizerID
                                    , ProductionTaskID
                                    , FertilizerID, FertilizerDate, FertilizerStartTime, FertilizerEndTime, FertilizerQuality, FertilizerTreatedArea, FertilizerDescription
                                    , CurrentUser.Instance.UserID));

                    if (RowAffected > 0)
                    {

                        OnMessage(BaranResources.EditSuccessful, PublicEnum.EnmMessageCategory.Success);
                        try
                        {
                            grdFertilizer.ActiveRow.Cells[dstProductionTask1.spr_prd_ProductionTask_Fertilizer_LinkByProductionTaskID_lst_Select.NameColumn.ColumnName].Value = cmbFertilizer.Text;
                            grdFertilizer.ActiveRow.Cells[dstProductionTask1.spr_prd_ProductionTask_Fertilizer_LinkByProductionTaskID_lst_Select.DateColumn.ColumnName].Value = mskFertilizerDate.Text;
                            grdFertilizer.ActiveRow.Cells[dstProductionTask1.spr_prd_ProductionTask_Fertilizer_LinkByProductionTaskID_lst_Select.StartTimeColumn.ColumnName].Value = mskFertilizerStartTime.Text;
                            grdFertilizer.ActiveRow.Cells[dstProductionTask1.spr_prd_ProductionTask_Fertilizer_LinkByProductionTaskID_lst_Select.EndTimeColumn.ColumnName].Value = mskFertilizerEndTime.Text;
                            grdFertilizer.ActiveRow.Cells[dstProductionTask1.spr_prd_ProductionTask_Fertilizer_LinkByProductionTaskID_lst_Select.TreatedAreaColumn.ColumnName].Value = txtFertilizerTreatedArea.Text.Trim();
                            grdFertilizer.ActiveRow.Cells[dstProductionTask1.spr_prd_ProductionTask_Fertilizer_LinkByProductionTaskID_lst_Select.DescriptionColumn.ColumnName].Value = txtFertilizerDescription.Text.Trim();
                            grdFertilizer.ActiveRow.Cells[dstProductionTask1.spr_prd_ProductionTask_Fertilizer_LinkByProductionTaskID_lst_Select.QuantityColumn.ColumnName].Value = mskFertilizerQuality.Text;

                            ChangebtnUpdateToSave(btnAddFertilizer);
                            ProductionTaskFertilizerID = 0;
                        }
                        catch { }

                    }
                    else
                        OnMessage(BaranResources.SaveFail, PublicEnum.EnmMessageCategory.Warning);
                }
                catch
                {
                    OnMessage(BaranResources.DoNotDoPleaseTryAgine, PublicEnum.EnmMessageCategory.Warning);
                }
            }

        }

        private void grdFertilizer_SizeChanged(object sender, EventArgs e)
        {
            egbFertilizer.Size = new Size(egbFertilizer.Size.Width, grpFertilizer.Size.Height + grdFertilizer.Size.Height + 60);
        }

        private void grdFertilizer_ClickCellButton(object sender, Infragistics.Win.UltraWinGrid.CellEventArgs e)
        {
            #region Delete
            BaranDataAccess.Production.dstProductionTaskTableAdapters.spr_prd_ProductionTask_Fertilizer_Link_SelectTableAdapter adpFertilizer =
                new BaranDataAccess.Production.dstProductionTaskTableAdapters.spr_prd_ProductionTask_Fertilizer_Link_SelectTableAdapter();


            if (e.Cell.Column.Key == "Delete")
            {

                try
                {
                    DialogResult msgResult = MessageBoxX.ShowMessageBox(PublicEnum.EnmMessageType.msgDeleteConfirm);
                    if (msgResult == DialogResult.No) return;

                    int RowAffected = (int)adpFertilizer.Delete(Convert.ToInt32(e.Cell.Row.Cells[dstProductionTask1.spr_prd_ProductionTask_Fertilizer_LinkByProductionTaskID_lst_Select.ProductionTaskFertilizerIDColumn.ColumnName].Value), CurrentUser.Instance.UserID);

                    if (RowAffected > 0)
                    {
                        e.Cell.Row.Delete();
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

            #endregion
            #region Update

            if (e.Cell.Column.Key == "Update")
            {
                if (grdFertilizer.ActiveRow != null)
                {
                    ProductionTaskFertilizerID = Convert.ToInt32(e.Cell.Row.Cells[dstProductionTask1.spr_prd_ProductionTask_Fertilizer_LinkByProductionTaskID_lst_Select.ProductionTaskFertilizerIDColumn.ColumnName].Value);

                    this.SetFertilizerControlsValue();

                    this.ChangebtnSaveToUpdate(btnAddFertilizer);
                }
            }

            #endregion
        }

        private void grdFertilizer_Click(object sender, EventArgs e)
        {

            if (grdFertilizer.ActiveRow == null)
                return;

            this.SetFertilizerControlsValue();

            ProductionTaskFertilizerID = 0;
            ChangebtnUpdateToSave(btnAddFertilizer);
        }

        private void cmbFertilizer_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                lblUnitMeasurement.Text = cmbFertilizer.SelectedRow.Cells[dstProduct1.spr_src_Fertilizer_cmbLst_Select.UnitMeasurementColumn.ColumnName].Value.ToString();
            }
            catch
            {
                lblUnitMeasurement.Text = "...";
            }
        }

        #endregion

        #region Pesticide -------------------------------------------------------------------------------------------------------------

        private void FillPesticideGrid()
        {
            BaranDataAccess.Production.dstProductionTaskTableAdapters.spr_prd_ProductionTask_Pesticide_LinkByProductionTaskID_lst_SelectTableAdapter adpPesticide =
               new BaranDataAccess.Production.dstProductionTaskTableAdapters.spr_prd_ProductionTask_Pesticide_LinkByProductionTaskID_lst_SelectTableAdapter();
            dstProductionTask1.spr_prd_ProductionTask_Pesticide_LinkByProductionTaskID_lst_Select.Clear();
            try
            {
                adpPesticide.FillProductionTaskPesticideByProductionTaskIDTable(dstProductionTask1.spr_prd_ProductionTask_Pesticide_LinkByProductionTaskID_lst_Select, ProductionTaskID);
            }
            catch
            {
                OnMessage(BaranResources.DoNotDoPleaseTryAgine, PublicEnum.EnmMessageCategory.Warning);
            }
        }

        private void SetPesticideControlsValue()
        {
            if (grdPesticide.ActiveRow == null)
                return;

            try
            {
                cmbPesticide.Value = grdPesticide.ActiveRow.Cells[dstProductionTask1.spr_prd_ProductionTask_Pesticide_LinkByProductionTaskID_lst_Select.Fk_PesticideIDColumn.ColumnName].Value;
                mskPesticideDate.Value = grdPesticide.ActiveRow.Cells[dstProductionTask1.spr_prd_ProductionTask_Pesticide_LinkByProductionTaskID_lst_Select.DateColumn.ColumnName].Value.ToString();
                mskPesticideTreadetArea.Value = grdPesticide.ActiveRow.Cells[dstProductionTask1.spr_prd_ProductionTask_Pesticide_LinkByProductionTaskID_lst_Select.TreatedAreaColumn.ColumnName].Text;
                txtPesticideDescription.Text = grdPesticide.ActiveRow.Cells[dstProductionTask1.spr_prd_ProductionTask_Pesticide_LinkByProductionTaskID_lst_Select.DescriptionColumn.ColumnName].Text;
                mskPesticideStartTime.Value = grdPesticide.ActiveRow.Cells[dstProductionTask1.spr_prd_ProductionTask_Pesticide_LinkByProductionTaskID_lst_Select.StartTimeColumn.ColumnName].Text;
                mskPesticideEndTime.Value = grdPesticide.ActiveRow.Cells[dstProductionTask1.spr_prd_ProductionTask_Pesticide_LinkByProductionTaskID_lst_Select.EndTimeColumn.ColumnName].Text;
                mskPesticideQuality.Value = grdPesticide.ActiveRow.Cells[dstProductionTask1.spr_prd_ProductionTask_Pesticide_LinkByProductionTaskID_lst_Select.QuantityColumn.ColumnName].Text;

            }
            catch
            {
                OnMessage(BaranResources.DoNotDoPleaseTryAgine, PublicEnum.EnmMessageCategory.Warning);
            }
        }

        private void btnAddPesticide_Click(object sender, EventArgs e)
        {
            if (ProductionTaskID <= 0)
            {
                OnMessage(BaranResources.SavedNotLastTime, PublicEnum.EnmMessageCategory.Warning);
                return;
            }

            if (cmbPesticide.Value == null)
            {
                OnMessage(BaranResources.FeildIsEmpty, PublicEnum.EnmMessageCategory.Info);
                cmbPesticide.Focus();
                return;
            }
            else if (mskPesticideDate.Value.ToString() == "")
            {
                OnMessage(BaranResources.FeildIsEmpty, PublicEnum.EnmMessageCategory.Info);
                mskPesticideDate.Focus();
                return;
            }
            else if (mskPesticideStartTime.Value.ToString() == "")
            {
                OnMessage(BaranResources.FeildIsEmpty, PublicEnum.EnmMessageCategory.Info);
                mskPesticideStartTime.Focus();
                return;
            }
            else if (mskPesticideEndTime.Value.ToString() == string.Empty)
            {
                OnMessage(BaranResources.FeildIsEmpty, PublicEnum.EnmMessageCategory.Info);
                mskPesticideEndTime.Focus();
                return;
            }
            else if (mskPesticideTreadetArea.Text.Trim() == string.Empty)
            {
                OnMessage(BaranResources.FeildIsEmpty, PublicEnum.EnmMessageCategory.Info);
                mskPesticideTreadetArea.Focus();
                return;
            }

            int PesticideID;
            string PesticideDescription;
            Nullable<DateTime> PesticideDate;
            Nullable<TimeSpan> PesticideStartTime = null, PesticideEndTime = null;
            Nullable<decimal> PesticideQuality = null, PesticideTreatedArea = null;

            PesticideID = Convert.ToInt32(cmbPesticide.Value);
            PesticideDate = DateTimeUtility.ToGregorian(mskPesticideDate.Value.ToString());
            if (mskPesticideStartTime.Value.ToString() != "")
                PesticideStartTime = TimeSpan.Parse(mskPesticideStartTime.Value.ToString());
            if (mskPesticideEndTime.Value.ToString() != "")
                PesticideEndTime = TimeSpan.Parse(mskPesticideEndTime.Value.ToString());
            if (mskPesticideTreadetArea.Value.ToString()!= "")
                PesticideTreatedArea = Convert.ToDecimal(mskPesticideTreadetArea.Value);
            PesticideDescription = txtPesticideDescription.Text.Trim();
            PesticideQuality = decimal.Parse(mskPesticideQuality.Value.ToString());

            BaranDataAccess.Production.dstProductionTaskTableAdapters.spr_prd_ProductionTask_Pesticide_Link_SelectTableAdapter adpPesticide =
                new BaranDataAccess.Production.dstProductionTaskTableAdapters.spr_prd_ProductionTask_Pesticide_Link_SelectTableAdapter();

            //Save ------------------------------------------------------------------------------------------------------------------------
            if (ProductionTaskPesticideID <= 0)
            {
                DialogResult msgResult = MessageBoxX.ShowMessageBox(PublicEnum.EnmMessageType.msgSaveConfirm);
                if (msgResult == DialogResult.No) return;


                try
                {
                    ProductionTaskPesticideID = Convert.ToInt32(adpPesticide.NewProductionTask_Pesticide_Link_Insert
                                            (ProductionTaskID
                                            , PesticideID, PesticideDate, PesticideStartTime, PesticideEndTime, PesticideQuality, PesticideTreatedArea, PesticideDescription
                                            , CurrentUser.Instance.UserID));
                    if (ProductionTaskPesticideID > 0)
                    {
                        OnMessage(BaranResources.SaveSuccessful, PublicEnum.EnmMessageCategory.Success);
                        //OnMessage(BaranResources.FeildIsEmpty, PublicEnum.EnmMessageCategory.Info);

                        Infragistics.Win.UltraWinGrid.UltraGridRow row = grdPesticide.DisplayLayout.Bands[0].AddNew();
                        row.Cells[dstProductionTask1.spr_prd_ProductionTask_Pesticide_LinkByProductionTaskID_lst_Select.ProductionTaskPesticideIDColumn.ColumnName].Value = ProductionTaskPesticideID;
                        row.Cells[dstProductionTask1.spr_prd_ProductionTask_Pesticide_LinkByProductionTaskID_lst_Select.Fk_PesticideIDColumn.ColumnName].Value = cmbPesticide.Value;
                        row.Cells[dstProductionTask1.spr_prd_ProductionTask_Pesticide_LinkByProductionTaskID_lst_Select.NAMEColumn.ColumnName].Value = cmbPesticide.Text;
                        row.Cells[dstProductionTask1.spr_prd_ProductionTask_Pesticide_LinkByProductionTaskID_lst_Select.StartTimeColumn.ColumnName].Value = mskPesticideStartTime.Value.ToString();
                        row.Cells[dstProductionTask1.spr_prd_ProductionTask_Pesticide_LinkByProductionTaskID_lst_Select.EndTimeColumn.ColumnName].Value = mskPesticideEndTime.Value.ToString();
                        row.Cells[dstProductionTask1.spr_prd_ProductionTask_Pesticide_LinkByProductionTaskID_lst_Select.TreatedAreaColumn.ColumnName].Value = mskPesticideTreadetArea.Value.ToString() ;
                        row.Cells[dstProductionTask1.spr_prd_ProductionTask_Pesticide_LinkByProductionTaskID_lst_Select.DateColumn.ColumnName].Value = mskPesticideDate.Value.ToString();
                        row.Cells[dstProductionTask1.spr_prd_ProductionTask_Pesticide_LinkByProductionTaskID_lst_Select.DescriptionColumn.ColumnName].Value = txtPesticideDescription.Text;
                        row.Cells[dstProductionTask1.spr_prd_ProductionTask_Pesticide_LinkByProductionTaskID_lst_Select.QuantityColumn.ColumnName].Value = mskPesticideQuality.Value;

                        //grdWorker.Rows[0].Selected = true;
                        ProductionTaskPesticideID = 0;

                    }
                    else
                        OnMessage(BaranResources.SaveFail, PublicEnum.EnmMessageCategory.Warning);
                }
                catch
                {
                    OnMessage(BaranResources.DoNotDoPleaseTryAgine, PublicEnum.EnmMessageCategory.Warning);
                }
            }

            // Update ----------------------------------------------------------------------------------------------------------------
            else if (ProductionTaskPesticideID > 0)
            {
                DialogResult msgResult = MessageBoxX.ShowMessageBox(PublicEnum.EnmMessageType.msgEditConfirm);
                if (msgResult == DialogResult.No) return;

                try
                {
                    int RowAffected = Convert.ToInt32(adpPesticide.Update(
                                    ProductionTaskPesticideID
                                    , ProductionTaskID
                                    , PesticideID, PesticideDate, PesticideStartTime, PesticideEndTime, PesticideQuality, PesticideTreatedArea, PesticideDescription
                                    , CurrentUser.Instance.UserID));

                    if (RowAffected > 0)
                    {

                        OnMessage(BaranResources.EditSuccessful, PublicEnum.EnmMessageCategory.Success);
                        try
                        {
                            grdPesticide.ActiveRow.Cells[dstProductionTask1.spr_prd_ProductionTask_Pesticide_LinkByProductionTaskID_lst_Select.NAMEColumn.ColumnName].Value = cmbPesticide.Text;
                            grdPesticide.ActiveRow.Cells[dstProductionTask1.spr_prd_ProductionTask_Pesticide_LinkByProductionTaskID_lst_Select.DateColumn.ColumnName].Value = mskPesticideDate.Value.ToString();
                            grdPesticide.ActiveRow.Cells[dstProductionTask1.spr_prd_ProductionTask_Pesticide_LinkByProductionTaskID_lst_Select.StartTimeColumn.ColumnName].Value = mskPesticideStartTime.Value.ToString();
                            grdPesticide.ActiveRow.Cells[dstProductionTask1.spr_prd_ProductionTask_Pesticide_LinkByProductionTaskID_lst_Select.EndTimeColumn.ColumnName].Value = mskPesticideEndTime.Value.ToString();
                            grdPesticide.ActiveRow.Cells[dstProductionTask1.spr_prd_ProductionTask_Pesticide_LinkByProductionTaskID_lst_Select.TreatedAreaColumn.ColumnName].Value = mskPesticideTreadetArea.Value.ToString();
                            grdPesticide.ActiveRow.Cells[dstProductionTask1.spr_prd_ProductionTask_Pesticide_LinkByProductionTaskID_lst_Select.DescriptionColumn.ColumnName].Value = txtPesticideDescription.Text.Trim();
                            grdPesticide.ActiveRow.Cells[dstProductionTask1.spr_prd_ProductionTask_Pesticide_LinkByProductionTaskID_lst_Select.QuantityColumn.ColumnName].Value = mskPesticideQuality.Value.ToString();

                            ChangebtnUpdateToSave(btnAddPesticide);
                            ProductionTaskPesticideID = 0;
                        }
                        catch { }

                    }
                    else
                        OnMessage(BaranResources.SaveFail, PublicEnum.EnmMessageCategory.Warning);
                }
                catch
                {
                    OnMessage(BaranResources.DoNotDoPleaseTryAgine, PublicEnum.EnmMessageCategory.Warning);
                }
            }
        }

        private void grdPesticide_SizeChanged(object sender, EventArgs e)
        {
            egbPesticide.Size = new Size(egbPesticide.Size.Width, grpPesticide.Size.Height + grdPesticide.Size.Height + 60);
        }

        private void grdPesticide_ClickCellButton(object sender, Infragistics.Win.UltraWinGrid.CellEventArgs e)
        {
            #region Delete
            BaranDataAccess.Production.dstProductionTaskTableAdapters.spr_prd_ProductionTask_Pesticide_Link_SelectTableAdapter adpPesticide =
                new BaranDataAccess.Production.dstProductionTaskTableAdapters.spr_prd_ProductionTask_Pesticide_Link_SelectTableAdapter();


            if (e.Cell.Column.Key == "Delete")
            {

                try
                {
                    DialogResult msgResult = MessageBoxX.ShowMessageBox(PublicEnum.EnmMessageType.msgDeleteConfirm);
                    if (msgResult == DialogResult.No) return;

                    int RowAffected = (int)adpPesticide.Delete(Convert.ToInt32(e.Cell.Row.Cells[dstProductionTask1.spr_prd_ProductionTask_Pesticide_LinkByProductionTaskID_lst_Select.ProductionTaskPesticideIDColumn.ColumnName].Value), CurrentUser.Instance.UserID);

                    if (RowAffected > 0)
                    {
                        e.Cell.Row.Delete();
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

            #endregion
            #region Update

            if (e.Cell.Column.Key == "Update")
            {
                if (grdPesticide.ActiveRow != null)
                {
                    ProductionTaskPesticideID = Convert.ToInt32(e.Cell.Row.Cells[dstProductionTask1.spr_prd_ProductionTask_Pesticide_LinkByProductionTaskID_lst_Select.ProductionTaskPesticideIDColumn.ColumnName].Value);

                    this.SetPesticideControlsValue();

                    this.ChangebtnSaveToUpdate(btnAddPesticide);
                }
            }

            #endregion
        }

        private void grdPesticide_Click(object sender, EventArgs e)
        {
            if (grdPesticide.ActiveRow == null)
                return;

            this.SetPesticideControlsValue();

            ProductionTaskPesticideID = 0;
            ChangebtnUpdateToSave(btnAddPesticide);
        }

        private void cmbPesticide_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                lblPesticideUnitMeasurement.Text = cmbPesticide.SelectedRow.Cells[dstProduct1.spr_src_Pesticide_cmbLst_Select.UnitMeasurementColumn.ColumnName].Value.ToString();
            }
            catch
            {
                lblPesticideUnitMeasurement.Text = "...";
            }
        }

        #endregion

        #region Water ----------------------------------------------------------------------------------------------------------

        private void FillWaterGrid()
        {
            BaranDataAccess.Production.dstProductionTaskTableAdapters.spr_prd_ProductionTask_Water_LinkByProductionTaskID_lst_SelectTableAdapter adpWater =
               new BaranDataAccess.Production.dstProductionTaskTableAdapters.spr_prd_ProductionTask_Water_LinkByProductionTaskID_lst_SelectTableAdapter(); ;            
            dstProductionTask1.spr_prd_ProductionTask_Water_LinkByProductionTaskID_lst_Select.Clear();
            try
            {
                adpWater.FillProductionTaskWaterByProductionTaskIDTable(dstProductionTask1.spr_prd_ProductionTask_Water_LinkByProductionTaskID_lst_Select, ProductionTaskID);
            }
            catch
            {
                OnMessage(BaranResources.DoNotDoPleaseTryAgine, PublicEnum.EnmMessageCategory.Warning);
            }
        }

        private void SetWaterControlsValue()
        {
            if (grdWater.ActiveRow == null)
                return;

            try
            {
                cmbWater.Value = grdWater.ActiveRow.Cells[dstProductionTask1.spr_prd_ProductionTask_Water_LinkByProductionTaskID_lst_Select.Fk_WaterIDColumn.ColumnName].Value;
                mskWaterDate.Value = grdWater.ActiveRow.Cells[dstProductionTask1.spr_prd_ProductionTask_Water_LinkByProductionTaskID_lst_Select.DateColumn.ColumnName].Value.ToString();
                mskWaterTradetArea.Value = grdWater.ActiveRow.Cells[dstProductionTask1.spr_prd_ProductionTask_Water_LinkByProductionTaskID_lst_Select.TreatedAreaColumn.ColumnName].Text;
                txtWaterDescription.Text = grdWater.ActiveRow.Cells[dstProductionTask1.spr_prd_ProductionTask_Water_LinkByProductionTaskID_lst_Select.DescriptionColumn.ColumnName].Text;
                mskWaterStartTime.Value = grdWater.ActiveRow.Cells[dstProductionTask1.spr_prd_ProductionTask_Water_LinkByProductionTaskID_lst_Select.StartTimeColumn.ColumnName].Text;
                mskWaterEndTime.Value = grdWater.ActiveRow.Cells[dstProductionTask1.spr_prd_ProductionTask_Water_LinkByProductionTaskID_lst_Select.EndTimeColumn.ColumnName].Text;
                mskWaterUsageVolume.Value = grdWater.ActiveRow.Cells[dstProductionTask1.spr_prd_ProductionTask_Water_LinkByProductionTaskID_lst_Select.UsageVolumeColumn.ColumnName].Text;

            }
            catch
            {
                OnMessage(BaranResources.DoNotDoPleaseTryAgine, PublicEnum.EnmMessageCategory.Warning);
            }
        }

        private void btnAddWater_Click(object sender, EventArgs e)
        {
            if (ProductionTaskID <= 0)
            {
                OnMessage(BaranResources.SavedNotLastTime, PublicEnum.EnmMessageCategory.Warning);
                return;
            }

            if (cmbWater.Value == null)
            {
                OnMessage(BaranResources.FeildIsEmpty, PublicEnum.EnmMessageCategory.Info);
                cmbWater.Focus();
                return;
            }
            else if (mskWaterDate.Value.ToString() == "")
            {
                OnMessage(BaranResources.FeildIsEmpty, PublicEnum.EnmMessageCategory.Info);
                mskWaterDate.Focus();
                return;
            }
            else if (mskWaterStartTime.Value.ToString() == "")
            {
                OnMessage(BaranResources.FeildIsEmpty, PublicEnum.EnmMessageCategory.Info);
                mskWaterStartTime.Focus();
                return;
            }
            else if (mskWaterEndTime.Value.ToString() == string.Empty)
            {
                OnMessage(BaranResources.FeildIsEmpty, PublicEnum.EnmMessageCategory.Info);
                mskWaterEndTime.Focus();
                return;
            }
            else if (mskWaterTradetArea.Text.Trim() == string.Empty)
            {
                OnMessage(BaranResources.FeildIsEmpty, PublicEnum.EnmMessageCategory.Info);
                mskWaterTradetArea.Focus();
                return;
            }

            int WaterID;
            string WaterDescription;
            Nullable<DateTime> WaterDate;
            Nullable<TimeSpan> WaterStartTime = null, WaterEndTime = null;
            Nullable<decimal> WaterUsageVolume = null, WaterTreatedArea = null;

            WaterID = Convert.ToInt32(cmbWater.Value);
            WaterDate = DateTimeUtility.ToGregorian(mskWaterDate.Value.ToString());
            if (mskWaterStartTime.Value.ToString() != "")
                WaterStartTime = TimeSpan.Parse(mskWaterStartTime.Value.ToString());
            if (mskWaterEndTime.Value.ToString() != "")
                WaterEndTime = TimeSpan.Parse(mskWaterEndTime.Value.ToString());
            if (mskWaterTradetArea.Value.ToString() != "")
                WaterTreatedArea = Convert.ToDecimal(mskWaterTradetArea.Value);
            WaterDescription = txtWaterDescription.Text.Trim();
            WaterUsageVolume = decimal.Parse(mskWaterUsageVolume.Value.ToString());

            BaranDataAccess.Production.dstProductionTaskTableAdapters.spr_prd_ProductionTask_Water_Link_SelectTableAdapter adpWater =
                new BaranDataAccess.Production.dstProductionTaskTableAdapters.spr_prd_ProductionTask_Water_Link_SelectTableAdapter();

            //Save ------------------------------------------------------------------------------------------------------------------------
            if (ProductionTaskWaterID <= 0)
            {
                DialogResult msgResult = MessageBoxX.ShowMessageBox(PublicEnum.EnmMessageType.msgSaveConfirm);
                if (msgResult == DialogResult.No) return;


                try
                {
                    ProductionTaskWaterID = Convert.ToInt32(adpWater.NewProductionTask_Water_Link_Insert
                                            (ProductionTaskID
                                            , WaterID, WaterDate, WaterStartTime, WaterEndTime, WaterUsageVolume, WaterTreatedArea, WaterDescription
                                            , CurrentUser.Instance.UserID));
                    if (ProductionTaskWaterID > 0)
                    {
                        OnMessage(BaranResources.SaveSuccessful, PublicEnum.EnmMessageCategory.Success);
                        //OnMessage(BaranResources.FeildIsEmpty, PublicEnum.EnmMessageCategory.Info);

                        Infragistics.Win.UltraWinGrid.UltraGridRow row = grdWater.DisplayLayout.Bands[0].AddNew();
                        row.Cells[dstProductionTask1.spr_prd_ProductionTask_Water_LinkByProductionTaskID_lst_Select.ProductionTaskWaterIDColumn.ColumnName].Value = ProductionTaskWaterID;
                        row.Cells[dstProductionTask1.spr_prd_ProductionTask_Water_LinkByProductionTaskID_lst_Select.Fk_WaterIDColumn.ColumnName].Value = cmbWater.Value;
                        row.Cells[dstProductionTask1.spr_prd_ProductionTask_Water_LinkByProductionTaskID_lst_Select.NameColumn.ColumnName].Value = cmbWater.Text;
                        row.Cells[dstProductionTask1.spr_prd_ProductionTask_Water_LinkByProductionTaskID_lst_Select.StartTimeColumn.ColumnName].Value = mskWaterStartTime.Value.ToString();
                        row.Cells[dstProductionTask1.spr_prd_ProductionTask_Water_LinkByProductionTaskID_lst_Select.EndTimeColumn.ColumnName].Value = mskWaterEndTime.Value.ToString();
                        row.Cells[dstProductionTask1.spr_prd_ProductionTask_Water_LinkByProductionTaskID_lst_Select.TreatedAreaColumn.ColumnName].Value = mskWaterTradetArea.Value.ToString();
                        row.Cells[dstProductionTask1.spr_prd_ProductionTask_Water_LinkByProductionTaskID_lst_Select.DateColumn.ColumnName].Value = mskWaterDate.Value.ToString();
                        row.Cells[dstProductionTask1.spr_prd_ProductionTask_Water_LinkByProductionTaskID_lst_Select.DescriptionColumn.ColumnName].Value = txtWaterDescription.Text;
                        row.Cells[dstProductionTask1.spr_prd_ProductionTask_Water_LinkByProductionTaskID_lst_Select.UsageVolumeColumn.ColumnName].Value = mskWaterUsageVolume.Value;

                        //grdWorker.Rows[0].Selected = true;
                        ProductionTaskWaterID = 0;

                    }
                    else
                        OnMessage(BaranResources.SaveFail, PublicEnum.EnmMessageCategory.Warning);
                }
                catch
                {
                    OnMessage(BaranResources.DoNotDoPleaseTryAgine, PublicEnum.EnmMessageCategory.Warning);
                }
            }

            // Update ----------------------------------------------------------------------------------------------------------------
            else if (ProductionTaskWaterID > 0)
            {
                DialogResult msgResult = MessageBoxX.ShowMessageBox(PublicEnum.EnmMessageType.msgEditConfirm);
                if (msgResult == DialogResult.No) return;

                try
                {
                    int RowAffected = Convert.ToInt32(adpWater.Update(
                                    ProductionTaskWaterID
                                    , ProductionTaskID
                                    , WaterID, WaterDate, WaterStartTime, WaterEndTime, WaterUsageVolume, WaterTreatedArea, WaterDescription
                                    , CurrentUser.Instance.UserID));

                    if (RowAffected > 0)
                    {

                        OnMessage(BaranResources.EditSuccessful, PublicEnum.EnmMessageCategory.Success);
                        try
                        {
                            grdWater.ActiveRow.Cells[dstProductionTask1.spr_prd_ProductionTask_Water_LinkByProductionTaskID_lst_Select.NameColumn.ColumnName].Value = cmbWater.Text;
                            grdWater.ActiveRow.Cells[dstProductionTask1.spr_prd_ProductionTask_Water_LinkByProductionTaskID_lst_Select.DateColumn.ColumnName].Value = mskWaterDate.Value.ToString();
                            grdWater.ActiveRow.Cells[dstProductionTask1.spr_prd_ProductionTask_Water_LinkByProductionTaskID_lst_Select.StartTimeColumn.ColumnName].Value = mskWaterStartTime.Value.ToString();
                            grdWater.ActiveRow.Cells[dstProductionTask1.spr_prd_ProductionTask_Water_LinkByProductionTaskID_lst_Select.EndTimeColumn.ColumnName].Value = mskWaterEndTime.Value.ToString();
                            grdWater.ActiveRow.Cells[dstProductionTask1.spr_prd_ProductionTask_Water_LinkByProductionTaskID_lst_Select.TreatedAreaColumn.ColumnName].Value = mskWaterTradetArea.Value.ToString();
                            grdWater.ActiveRow.Cells[dstProductionTask1.spr_prd_ProductionTask_Water_LinkByProductionTaskID_lst_Select.DescriptionColumn.ColumnName].Value = txtWaterDescription.Text.Trim();
                            grdWater.ActiveRow.Cells[dstProductionTask1.spr_prd_ProductionTask_Water_LinkByProductionTaskID_lst_Select.UsageVolumeColumn.ColumnName].Value = mskWaterUsageVolume.Value.ToString();

                            ChangebtnUpdateToSave(btnAddWater);
                            ProductionTaskWaterID = 0;
                        }
                        catch { }

                    }
                    else
                        OnMessage(BaranResources.SaveFail, PublicEnum.EnmMessageCategory.Warning);
                }
                catch
                {
                    OnMessage(BaranResources.DoNotDoPleaseTryAgine, PublicEnum.EnmMessageCategory.Warning);
                }
            }
        }

        private void grdWater_SizeChanged(object sender, EventArgs e)
        {
            egbWater.Size = new Size(egbWater.Size.Width, grpWater.Size.Height + grdWater.Size.Height + 60);
        }

        private void grdWater_ClickCellButton(object sender, Infragistics.Win.UltraWinGrid.CellEventArgs e)
        {
            #region Delete
            BaranDataAccess.Production.dstProductionTaskTableAdapters.spr_prd_ProductionTask_Water_Link_SelectTableAdapter adpWater =
                new BaranDataAccess.Production.dstProductionTaskTableAdapters.spr_prd_ProductionTask_Water_Link_SelectTableAdapter();


            if (e.Cell.Column.Key == "Delete")
            {

                try
                {
                    DialogResult msgResult = MessageBoxX.ShowMessageBox(PublicEnum.EnmMessageType.msgDeleteConfirm);
                    if (msgResult == DialogResult.No) return;

                    int RowAffected = (int)adpWater.Delete(Convert.ToInt32(e.Cell.Row.Cells[dstProductionTask1.spr_prd_ProductionTask_Water_LinkByProductionTaskID_lst_Select.ProductionTaskWaterIDColumn.ColumnName].Value), CurrentUser.Instance.UserID);

                    if (RowAffected > 0)
                    {
                        e.Cell.Row.Delete();
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

            #endregion
            #region Update

            if (e.Cell.Column.Key == "Update")
            {
                if (grdWater.ActiveRow != null)
                {
                    ProductionTaskWaterID = Convert.ToInt32(e.Cell.Row.Cells[dstProductionTask1.spr_prd_ProductionTask_Water_LinkByProductionTaskID_lst_Select.ProductionTaskWaterIDColumn.ColumnName].Value);

                    this.SetWaterControlsValue();

                    this.ChangebtnSaveToUpdate(btnAddWater);
                }
            }

            #endregion
        }

        private void grdWater_Click(object sender, EventArgs e)
        {
            if (grdWater.ActiveRow == null)
                return;

            this.SetWaterControlsValue();

            ProductionTaskWaterID = 0;
            ChangebtnUpdateToSave(btnAddWater);
        }

        #endregion

        #region Water Storage ------------------------------------------------------------------------------------------

        private void FillWaterStorageGrid()
        {
            BaranDataAccess.Production.dstProductionTaskTableAdapters.spr_prd_ProductionTask_WaterStorage_LinkByProductionTaskID_lst_SelectTableAdapter adpWaterStorage =
               new BaranDataAccess.Production.dstProductionTaskTableAdapters.spr_prd_ProductionTask_WaterStorage_LinkByProductionTaskID_lst_SelectTableAdapter();
            dstProductionTask1.spr_prd_ProductionTask_WaterStorage_LinkByProductionTaskID_lst_Select.Clear();
            try
            {
                adpWaterStorage.FillProductionTaskWaterStorageByProductionTaskIDTable(dstProductionTask1.spr_prd_ProductionTask_WaterStorage_LinkByProductionTaskID_lst_Select, ProductionTaskID);
            }
            catch
            {
                OnMessage(BaranResources.DoNotDoPleaseTryAgine, PublicEnum.EnmMessageCategory.Warning);
            }
        }

        private void SetWaterStorageControlsValue()
        {
            if (grdWaterStorage.ActiveRow == null)
                return;

            try
            {
                cmbWaterStorage.Value = grdWaterStorage.ActiveRow.Cells[dstProductionTask1.spr_prd_ProductionTask_WaterStorage_LinkByProductionTaskID_lst_Select.Fk_WaterStorageIDColumn.ColumnName].Value;
                mskWaterStorageDate.Value = grdWaterStorage.ActiveRow.Cells[dstProductionTask1.spr_prd_ProductionTask_WaterStorage_LinkByProductionTaskID_lst_Select.DateColumn.ColumnName].Value.ToString();
                mskWaterStorageTreatedArea.Value = grdWaterStorage.ActiveRow.Cells[dstProductionTask1.spr_prd_ProductionTask_WaterStorage_LinkByProductionTaskID_lst_Select.TreatedAreaColumn.ColumnName].Text;
                txtWaterStorageDescription.Text = grdWaterStorage.ActiveRow.Cells[dstProductionTask1.spr_prd_ProductionTask_WaterStorage_LinkByProductionTaskID_lst_Select.DescriptionColumn.ColumnName].Text;
                mskWaterStorageStartTime.Value = grdWaterStorage.ActiveRow.Cells[dstProductionTask1.spr_prd_ProductionTask_WaterStorage_LinkByProductionTaskID_lst_Select.StartTimeColumn.ColumnName].Text;
                mskWaterStorageEndTime.Value = grdWaterStorage.ActiveRow.Cells[dstProductionTask1.spr_prd_ProductionTask_WaterStorage_LinkByProductionTaskID_lst_Select.EndTimeColumn.ColumnName].Text;
                mskWaterStorageUsageVoulum.Value = grdWaterStorage.ActiveRow.Cells[dstProductionTask1.spr_prd_ProductionTask_WaterStorage_LinkByProductionTaskID_lst_Select.UsageVolumeColumn.ColumnName].Text;

            }
            catch
            {
                OnMessage(BaranResources.DoNotDoPleaseTryAgine, PublicEnum.EnmMessageCategory.Warning);
            }
        }

        private void btnAddWaterStorage_Click(object sender, EventArgs e)
        {
            if (ProductionTaskID <= 0)
            {
                OnMessage(BaranResources.SavedNotLastTime, PublicEnum.EnmMessageCategory.Warning);
                return;
            }

            if (cmbWaterStorage.Value == null)
            {
                OnMessage(BaranResources.FeildIsEmpty, PublicEnum.EnmMessageCategory.Info);
                cmbWaterStorage.Focus();
                return;
            }
            else if (mskWaterStorageDate.Value.ToString() == "")
            {
                OnMessage(BaranResources.FeildIsEmpty, PublicEnum.EnmMessageCategory.Info);
                mskWaterStorageDate.Focus();
                return;
            }
            else if (mskWaterStorageStartTime.Value.ToString() == "")
            {
                OnMessage(BaranResources.FeildIsEmpty, PublicEnum.EnmMessageCategory.Info);
                mskWaterStorageStartTime.Focus();
                return;
            }
            else if (mskWaterStorageEndTime.Value.ToString() == string.Empty)
            {
                OnMessage(BaranResources.FeildIsEmpty, PublicEnum.EnmMessageCategory.Info);
                mskWaterStorageEndTime.Focus();
                return;
            }
            else if (mskWaterStorageTreatedArea.Text.Trim() == string.Empty)
            {
                OnMessage(BaranResources.FeildIsEmpty, PublicEnum.EnmMessageCategory.Info);
                mskWaterStorageTreatedArea.Focus();
                return;
            }

            int WaterStorageID;
            string WaterStorageDescription;
            Nullable<DateTime> WaterStorageDate;
            Nullable<TimeSpan> WaterStorageStartTime = null, WaterStorageEndTime = null;
            Nullable<decimal> WaterStorageUsageVolume = null, WaterStorageTreatedArea = null;

            WaterStorageID = Convert.ToInt32(cmbWaterStorage.Value);
            WaterStorageDate = DateTimeUtility.ToGregorian(mskWaterStorageDate.Value.ToString());
            if (mskWaterStartTime.Value.ToString() != "")
                WaterStorageStartTime = TimeSpan.Parse(mskWaterStorageStartTime.Value.ToString());
            if (mskWaterEndTime.Value.ToString() != "")
                WaterStorageEndTime = TimeSpan.Parse(mskWaterStorageEndTime.Value.ToString());
            if (mskWaterTradetArea.Value.ToString() != "")
                WaterStorageTreatedArea = Convert.ToDecimal(mskWaterStorageTreatedArea.Value);
            WaterStorageDescription = txtWaterStorageDescription.Text.Trim();
            WaterStorageUsageVolume = decimal.Parse(mskWaterStorageUsageVoulum.Value.ToString());

            BaranDataAccess.Production.dstProductionTaskTableAdapters.spr_prd_ProductionTask_WaterStorage_Link_SelectTableAdapter adpWaterStorage =
                new BaranDataAccess.Production.dstProductionTaskTableAdapters.spr_prd_ProductionTask_WaterStorage_Link_SelectTableAdapter();

            //Save ------------------------------------------------------------------------------------------------------------------------
            if (ProductionTaskWaterStorageID <= 0)
            {
                DialogResult msgResult = MessageBoxX.ShowMessageBox(PublicEnum.EnmMessageType.msgSaveConfirm);
                if (msgResult == DialogResult.No) return;


                try
                {
                    ProductionTaskWaterStorageID = Convert.ToInt32(adpWaterStorage.NewProductionTask_WaterStorage_Link_Insert
                                            (ProductionTaskID
                                            , WaterStorageID, WaterStorageDate, WaterStorageStartTime, WaterStorageEndTime, WaterStorageUsageVolume, WaterStorageTreatedArea, WaterStorageDescription
                                            , CurrentUser.Instance.UserID));
                    if (ProductionTaskWaterStorageID > 0)
                    {
                        OnMessage(BaranResources.SaveSuccessful, PublicEnum.EnmMessageCategory.Success);
                        //OnMessage(BaranResources.FeildIsEmpty, PublicEnum.EnmMessageCategory.Info);

                        Infragistics.Win.UltraWinGrid.UltraGridRow row = grdWaterStorage.DisplayLayout.Bands[0].AddNew();
                        row.Cells[dstProductionTask1.spr_prd_ProductionTask_WaterStorage_LinkByProductionTaskID_lst_Select.ProductionTaskWaterStorageIDColumn.ColumnName].Value = ProductionTaskWaterStorageID;
                        row.Cells[dstProductionTask1.spr_prd_ProductionTask_WaterStorage_LinkByProductionTaskID_lst_Select.Fk_WaterStorageIDColumn.ColumnName].Value = cmbWaterStorage.Value;
                        row.Cells[dstProductionTask1.spr_prd_ProductionTask_WaterStorage_LinkByProductionTaskID_lst_Select.NameColumn.ColumnName].Value = cmbWaterStorage.Text;
                        row.Cells[dstProductionTask1.spr_prd_ProductionTask_WaterStorage_LinkByProductionTaskID_lst_Select.StartTimeColumn.ColumnName].Value = mskWaterStorageStartTime.Value.ToString();
                        row.Cells[dstProductionTask1.spr_prd_ProductionTask_WaterStorage_LinkByProductionTaskID_lst_Select.EndTimeColumn.ColumnName].Value = mskWaterStorageEndTime.Value.ToString();
                        row.Cells[dstProductionTask1.spr_prd_ProductionTask_WaterStorage_LinkByProductionTaskID_lst_Select.TreatedAreaColumn.ColumnName].Value = mskWaterStorageTreatedArea.Value.ToString();
                        row.Cells[dstProductionTask1.spr_prd_ProductionTask_WaterStorage_LinkByProductionTaskID_lst_Select.DateColumn.ColumnName].Value = mskWaterStorageDate.Value.ToString();
                        row.Cells[dstProductionTask1.spr_prd_ProductionTask_WaterStorage_LinkByProductionTaskID_lst_Select.DescriptionColumn.ColumnName].Value = txtWaterStorageDescription.Text;
                        row.Cells[dstProductionTask1.spr_prd_ProductionTask_WaterStorage_LinkByProductionTaskID_lst_Select.UsageVolumeColumn.ColumnName].Value = mskWaterStorageUsageVoulum.Value;

                        //grdWorker.Rows[0].Selected = true;
                        ProductionTaskWaterStorageID = 0;

                    }
                    else
                        OnMessage(BaranResources.SaveFail, PublicEnum.EnmMessageCategory.Warning);
                }
                catch
                {
                    OnMessage(BaranResources.DoNotDoPleaseTryAgine, PublicEnum.EnmMessageCategory.Warning);
                }
            }

            // Update ----------------------------------------------------------------------------------------------------------------
            else if (ProductionTaskWaterStorageID > 0)
            {
                DialogResult msgResult = MessageBoxX.ShowMessageBox(PublicEnum.EnmMessageType.msgEditConfirm);
                if (msgResult == DialogResult.No) return;

                try
                {
                    int RowAffected = Convert.ToInt32(adpWaterStorage.Update(
                                    ProductionTaskWaterStorageID
                                    , ProductionTaskID
                                    , WaterStorageID, WaterStorageDate, WaterStorageStartTime, WaterStorageEndTime, WaterStorageUsageVolume, WaterStorageTreatedArea, WaterStorageDescription
                                    , CurrentUser.Instance.UserID));

                    if (RowAffected > 0)
                    {

                        OnMessage(BaranResources.EditSuccessful, PublicEnum.EnmMessageCategory.Success);
                        try
                        {
                            grdWaterStorage.ActiveRow.Cells[dstProductionTask1.spr_prd_ProductionTask_WaterStorage_LinkByProductionTaskID_lst_Select.NameColumn.ColumnName].Value = cmbWaterStorage.Text;
                            grdWaterStorage.ActiveRow.Cells[dstProductionTask1.spr_prd_ProductionTask_WaterStorage_LinkByProductionTaskID_lst_Select.DateColumn.ColumnName].Value = mskWaterStorageDate.Value.ToString();
                            grdWaterStorage.ActiveRow.Cells[dstProductionTask1.spr_prd_ProductionTask_WaterStorage_LinkByProductionTaskID_lst_Select.StartTimeColumn.ColumnName].Value = mskWaterStorageStartTime.Value.ToString();
                            grdWaterStorage.ActiveRow.Cells[dstProductionTask1.spr_prd_ProductionTask_WaterStorage_LinkByProductionTaskID_lst_Select.EndTimeColumn.ColumnName].Value = mskWaterStorageEndTime.Value.ToString();
                            grdWaterStorage.ActiveRow.Cells[dstProductionTask1.spr_prd_ProductionTask_WaterStorage_LinkByProductionTaskID_lst_Select.TreatedAreaColumn.ColumnName].Value = mskWaterStorageTreatedArea.Value.ToString();
                            grdWaterStorage.ActiveRow.Cells[dstProductionTask1.spr_prd_ProductionTask_WaterStorage_LinkByProductionTaskID_lst_Select.DescriptionColumn.ColumnName].Value = txtWaterStorageDescription.Text.Trim();
                            grdWaterStorage.ActiveRow.Cells[dstProductionTask1.spr_prd_ProductionTask_WaterStorage_LinkByProductionTaskID_lst_Select.UsageVolumeColumn.ColumnName].Value = mskWaterUsageVolume.Value.ToString();

                            ChangebtnUpdateToSave(btnAddWaterStorage);
                            ProductionTaskWaterStorageID = 0;
                        }
                        catch { }

                    }
                    else
                        OnMessage(BaranResources.SaveFail, PublicEnum.EnmMessageCategory.Warning);
                }
                catch
                {
                    OnMessage(BaranResources.DoNotDoPleaseTryAgine, PublicEnum.EnmMessageCategory.Warning);
                }
            }
        }

        private void grdWaterStorage_Click(object sender, EventArgs e)
        {
            if (grdWaterStorage.ActiveRow == null)
                return;

            this.SetWaterStorageControlsValue();

            ProductionTaskWaterStorageID = 0;
            ChangebtnUpdateToSave(btnAddWaterStorage);
        }

        private void grdWaterStorage_SizeChanged(object sender, EventArgs e)
        {
            egbWaterStorage.Size = new Size(egbWaterStorage.Size.Width, grpWaterStorage.Size.Height + grdWaterStorage.Size.Height + 60);
        }

        private void grdWaterStorage_ClickCellButton(object sender, Infragistics.Win.UltraWinGrid.CellEventArgs e)
        {
            #region Delete
            BaranDataAccess.Production.dstProductionTaskTableAdapters.spr_prd_ProductionTask_WaterStorage_Link_SelectTableAdapter adpWaterStorage =
                new BaranDataAccess.Production.dstProductionTaskTableAdapters.spr_prd_ProductionTask_WaterStorage_Link_SelectTableAdapter();


            if (e.Cell.Column.Key == "Delete")
            {

                try
                {
                    DialogResult msgResult = MessageBoxX.ShowMessageBox(PublicEnum.EnmMessageType.msgDeleteConfirm);
                    if (msgResult == DialogResult.No) return;

                    int RowAffected = (int)adpWaterStorage.Delete(Convert.ToInt32(e.Cell.Row.Cells[dstProductionTask1.spr_prd_ProductionTask_WaterStorage_LinkByProductionTaskID_lst_Select.ProductionTaskWaterStorageIDColumn.ColumnName].Value), CurrentUser.Instance.UserID);

                    if (RowAffected > 0)
                    {
                        e.Cell.Row.Delete();
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

            #endregion
            #region Update

            if (e.Cell.Column.Key == "Update")
            {
                if (grdWaterStorage.ActiveRow != null)
                {
                    ProductionTaskWaterStorageID = Convert.ToInt32(e.Cell.Row.Cells[dstProductionTask1.spr_prd_ProductionTask_WaterStorage_LinkByProductionTaskID_lst_Select.ProductionTaskWaterStorageIDColumn.ColumnName].Value);

                    this.SetWaterStorageControlsValue();

                    this.ChangebtnSaveToUpdate(btnAddWaterStorage);
                }
            }

            #endregion
        }

        #endregion

        #region Doc ----------------------------------------------------------------------------------------------------

        private void FillDocGrid()
        {
            BaranDataAccess.Production.dstProductionTaskTableAdapters.spr_prd_ProductionTask_Doc_ByProductionTaskID_lst_SelectTableAdapter adpDoc =
               new BaranDataAccess.Production.dstProductionTaskTableAdapters.spr_prd_ProductionTask_Doc_ByProductionTaskID_lst_SelectTableAdapter();
            dstProductionTask1.spr_prd_ProductionTask_Doc_ByProductionTaskID_lst_Select.Clear();
            try
            {
                adpDoc.FillProductionTaskDocbyProductionTaskIDTable(dstProductionTask1.spr_prd_ProductionTask_Doc_ByProductionTaskID_lst_Select, ProductionTaskID);
            }
            catch
            {
                OnMessage(BaranResources.DoNotDoPleaseTryAgine, PublicEnum.EnmMessageCategory.Warning);
            }
        }

        private void btnAddDocu_Click(object sender, EventArgs e)
        {
            Baran.Production.frmProductionTaskDoc ofrm = new frmProductionTaskDoc(ProductionTaskID);
            ofrm.FormType = cnsFormType.New;
            if (ofrm.ShowDialog() == DialogResult.OK)
                this.FillDocGrid();
        }

        private void grdDoc_Click(object sender, EventArgs e)
        {
            if (grdDoc.ActiveRow == null)
                return;

            ProductionTaskDocID = 0;
            ChangebtnUpdateToSave(btnAddDocu);
        }

        private void grdDoc_SizeChanged(object sender, EventArgs e)
        {
            egbDocu.Size = new Size(egbDocu.Size.Width, grpDocu.Size.Height + grdDoc.Size.Height + 60);
        }

        private void grdDoc_ClickCellButton(object sender, Infragistics.Win.UltraWinGrid.CellEventArgs e)
        {
            #region Delete
            BaranDataAccess.Production.dstProductionTaskTableAdapters.spr_prd_ProductionTask_Doc_SelectTableAdapter adpDoc =
                new BaranDataAccess.Production.dstProductionTaskTableAdapters.spr_prd_ProductionTask_Doc_SelectTableAdapter();


            if (e.Cell.Column.Key == "Delete")
            {

                try
                {
                    DialogResult msgResult = MessageBoxX.ShowMessageBox(PublicEnum.EnmMessageType.msgDeleteConfirm);
                    if (msgResult == DialogResult.No) return;

                    int RowAffected = (int)adpDoc.Delete(Convert.ToInt32(e.Cell.Row.Cells[dstProductionTask1.spr_prd_ProductionTask_Doc_ByProductionTaskID_lst_Select.ProductionTaskDocIDColumn.ColumnName].Value), CurrentUser.Instance.UserID);

                    if (RowAffected > 0)
                    {
                        e.Cell.Row.Delete();
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

            #endregion
            #region Update

            if (e.Cell.Column.Key == "Update")
            {
                try
                {    
                    Baran.Production.frmProductionTaskDoc ofrm = 
                        new frmProductionTaskDoc(ProductionTaskID, (int)e.Cell.Row.Cells[dstProductionTask1.spr_prd_ProductionTask_Doc_ByProductionTaskID_lst_Select.ProductionTaskDocIDColumn.ColumnName].Value);
                    ofrm.FormType = cnsFormType.Change;
                    if (ofrm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        this.FillDocGrid();
                }
                catch
                {
                    OnMessage(BaranResources.DoNotDoPleaseTryAgine, PublicEnum.EnmMessageCategory.Warning);
                }
            }

            #endregion
        }

        #endregion

        #region Discussion -------------------------------------------------------------------------------------------------

        private void FillDiscussionGrid()
        {
            BaranDataAccess.Production.dstProductionTaskTableAdapters.spr_prd_ProductionTask_Discussion_ByProductionTaskID_lst_SelectTableAdapter adpDiscussion =
              new BaranDataAccess.Production.dstProductionTaskTableAdapters.spr_prd_ProductionTask_Discussion_ByProductionTaskID_lst_SelectTableAdapter();
            dstProductionTask1.spr_prd_ProductionTask_Discussion_ByProductionTaskID_lst_Select.Clear();
            try
            {
                adpDiscussion.FillProductionTaskDiscussionByProductionTaskIDTable(dstProductionTask1.spr_prd_ProductionTask_Discussion_ByProductionTaskID_lst_Select, ProductionTaskID);
            }
            catch
            {
                OnMessage(BaranResources.DoNotDoPleaseTryAgine, PublicEnum.EnmMessageCategory.Warning);
            }
        }

        private void btnAddDiscussion_Click(object sender, EventArgs e)
        {
            if (ProductionTaskID <= 0)
            {
                OnMessage(BaranResources.SavedNotLastTime, PublicEnum.EnmMessageCategory.Warning);
                return;
            }

             if (txtDiscossion.Text.Trim() == string.Empty)
            {
                OnMessage(BaranResources.FeildIsEmpty, PublicEnum.EnmMessageCategory.Info);
                txtDiscossion.Focus();
                return;
            }


             BaranDataAccess.Production.dstProductionTaskTableAdapters.spr_prd_ProductionTask_Discussion_SelectTableAdapter adpDiscussion =
                 new BaranDataAccess.Production.dstProductionTaskTableAdapters.spr_prd_ProductionTask_Discussion_SelectTableAdapter();

            //Save ------------------------------------------------------------------------------------------------------------------------
            if (ProductionTaskDiscussionID <= 0)
            {
                DialogResult msgResult = MessageBoxX.ShowMessageBox(PublicEnum.EnmMessageType.msgSaveConfirm);
                if (msgResult == DialogResult.No) return;


                try
                {
                    ProductionTaskDiscussionID = Convert.ToInt32(adpDiscussion.NewProductionTask_Discussion_Insert(ProductionTaskID, txtDiscossion.Text.Trim(), CurrentUser.Instance.UserID));

                    if (ProductionTaskDiscussionID > 0)
                    {
                        OnMessage(BaranResources.SaveSuccessful, PublicEnum.EnmMessageCategory.Success);

                        //string ss = DateTime.Now.ToString();
                        //string pp = DateTimeUtility.ToGregorian(ss).ToString(); ;

                        Infragistics.Win.UltraWinGrid.UltraGridRow row = grdDiscusssion.DisplayLayout.Bands[0].AddNew();
                        row.Cells[dstProductionTask1.spr_prd_ProductionTask_Discussion_ByProductionTaskID_lst_Select.ProductionTaskDiscussionIDColumn.ColumnName].Value = ProductionTaskDiscussionID;
                        row.Cells[dstProductionTask1.spr_prd_ProductionTask_Discussion_ByProductionTaskID_lst_Select.CommentColumn.ColumnName].Value = txtDiscossion.Text.Trim();
                        row.Cells[dstProductionTask1.spr_prd_ProductionTask_Discussion_ByProductionTaskID_lst_Select.Fk_ProductionTaskIDColumn.ColumnName].Value = ProductionTaskID;
                        row.Cells[dstProductionTask1.spr_prd_ProductionTask_Discussion_ByProductionTaskID_lst_Select.CreateDateColumn.ColumnName].Value =DateTime.Now.ToString();
                        row.Cells[dstProductionTask1.spr_prd_ProductionTask_Discussion_ByProductionTaskID_lst_Select.FullNameColumn.ColumnName].Value = CurrentUser.Instance.FullName;

                        ProductionTaskDiscussionID = 0;

                    }
                    else
                        OnMessage(BaranResources.SaveFail, PublicEnum.EnmMessageCategory.Warning);
                }
                catch
                {
                    OnMessage(BaranResources.DoNotDoPleaseTryAgine, PublicEnum.EnmMessageCategory.Warning);
                }
            }

            // Update ----------------------------------------------------------------------------------------------------------------
            else if (ProductionTaskDiscussionID > 0)
            {
                DialogResult msgResult = MessageBoxX.ShowMessageBox(PublicEnum.EnmMessageType.msgEditConfirm);
                if (msgResult == DialogResult.No) return;

                try
                {
                    int RowAffected = Convert.ToInt32(adpDiscussion.Update(
                                    ProductionTaskDiscussionID,ProductionTaskID, txtDiscossion.Text.Trim(), CurrentUser.Instance.UserID));

                    if (RowAffected > 0)
                    {

                        OnMessage(BaranResources.EditSuccessful, PublicEnum.EnmMessageCategory.Success);
                        try
                        {
                            grdDiscusssion.ActiveRow.Cells[dstProductionTask1.spr_prd_ProductionTask_Discussion_ByProductionTaskID_lst_Select.CommentColumn.ColumnName].Value = txtDiscossion.Text.Trim();
                            grdDiscusssion.ActiveRow.Cells[dstProductionTask1.spr_prd_ProductionTask_Discussion_ByProductionTaskID_lst_Select.CreateDateColumn.ColumnName].Value = DateTime.Now.ToString();
                            grdDiscusssion.ActiveRow.Cells[dstProductionTask1.spr_prd_ProductionTask_Discussion_ByProductionTaskID_lst_Select.FullNameColumn.ColumnName].Value = CurrentUser.Instance.FullName;


                            ChangebtnUpdateToSave(btnAddDiscussion);
                            ProductionTaskDiscussionID = 0;
                        }
                        catch { }

                    }
                    else
                        OnMessage(BaranResources.SaveFail, PublicEnum.EnmMessageCategory.Warning);
                }
                catch
                {
                    OnMessage(BaranResources.DoNotDoPleaseTryAgine, PublicEnum.EnmMessageCategory.Warning);
                }
            }
        }

        private void grdDiscusssion_Click(object sender, EventArgs e)
        {
            if (grdDiscusssion.ActiveRow == null)
                return;


            try
            {
                txtDiscossion.Text = grdDiscusssion.ActiveRow.Cells[dstProductionTask1.spr_prd_ProductionTask_Discussion_ByProductionTaskID_lst_Select.CommentColumn.ColumnName].Value.ToString() ;
                ProductionTaskID = (int) grdDiscusssion.ActiveRow.Cells[dstProductionTask1.spr_prd_ProductionTask_Discussion_ByProductionTaskID_lst_Select.Fk_ProductionTaskIDColumn.ColumnName].Value;

                ChangebtnUpdateToSave(btnAddDiscussion);
                ProductionTaskDiscussionID = 0;
            }
            catch { }

        }

        private void grdDiscusssion_SizeChanged(object sender, EventArgs e)
        {
            egbDiscussion.Size = new Size(egbDiscussion.Size.Width, grpDiscussion.Size.Height + grdDiscusssion.Size.Height + 60);
        }

        private void egpBasePanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void grpWater_Click(object sender, EventArgs e)
        {



        }

        private void grdDiscusssion_ClickCellButton(object sender, Infragistics.Win.UltraWinGrid.CellEventArgs e)
        {
            #region Delete
            BaranDataAccess.Production.dstProductionTaskTableAdapters.spr_prd_ProductionTask_Discussion_SelectTableAdapter adpDiscussion =
                new BaranDataAccess.Production.dstProductionTaskTableAdapters.spr_prd_ProductionTask_Discussion_SelectTableAdapter();


            if (e.Cell.Column.Key == "Delete")
            {

                try
                {
                    DialogResult msgResult = MessageBoxX.ShowMessageBox(PublicEnum.EnmMessageType.msgDeleteConfirm);
                    if (msgResult == DialogResult.No) return;

                    int RowAffected = (int)adpDiscussion.Delete(Convert.ToInt32(e.Cell.Row.Cells[dstProductionTask1.spr_prd_ProductionTask_Discussion_ByProductionTaskID_lst_Select.ProductionTaskDiscussionIDColumn.ColumnName].Value), CurrentUser.Instance.UserID);

                    if (RowAffected > 0)
                    {
                        e.Cell.Row.Delete();
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

            #endregion
            #region Update

            if (e.Cell.Column.Key == "Update")
            {
                if (grdDiscusssion.ActiveRow != null)
                {
                    ProductionTaskDiscussionID = Convert.ToInt32(e.Cell.Row.Cells[dstProductionTask1.spr_prd_ProductionTask_Discussion_ByProductionTaskID_lst_Select.ProductionTaskDiscussionIDColumn.ColumnName].Value);
                    txtDiscossion.Text = e.Cell.Row.Cells[dstProductionTask1.spr_prd_ProductionTask_Discussion_ByProductionTaskID_lst_Select.CommentColumn.ColumnName].Value.ToString();

                    this.ChangebtnSaveToUpdate(btnAddDiscussion);
                }
            }

            #endregion
        }

        #endregion

        #region Chemical Analys-------------------------------------------------------------------------------------

        private void FillChemicalAnalysGrid()
        {
            BaranDataAccess.Production.dstProductionTaskTableAdapters.spr_prd_ProductionTask_ChemicalAnalys_ByProductionTaskID_lst_SelectTableAdapter adpDiscussion =
              new BaranDataAccess.Production.dstProductionTaskTableAdapters.spr_prd_ProductionTask_ChemicalAnalys_ByProductionTaskID_lst_SelectTableAdapter();
            dstProductionTask1.spr_prd_ProductionTask_ChemicalAnalys_ByProductionTaskID_lst_Select.Clear();
            try
            {
                adpDiscussion.FillProductionTaskChemicalAnalysByProductionTaskIDTable(dstProductionTask1.spr_prd_ProductionTask_ChemicalAnalys_ByProductionTaskID_lst_Select, ProductionTaskID);
            }
            catch
            {
                OnMessage(BaranResources.DoNotDoPleaseTryAgine, PublicEnum.EnmMessageCategory.Warning);
            }
        }

        private void btnAddChemicalAnalys_Click(object sender, EventArgs e)
        {
            if (ProductionTaskID <= 0)
            {
                OnMessage(BaranResources.SavedNotLastTime, PublicEnum.EnmMessageCategory.Warning);
                return;
            }

            if (cmbChemicalAnalys.Value == null)
            {
                OnMessage(BaranResources.FeildIsEmpty, PublicEnum.EnmMessageCategory.Info);
                cmbChemicalAnalys.Focus();
                return;
            }


            BaranDataAccess.Production.dstProductionTaskTableAdapters.spr_prd_ProductionTask_ChemicalAnalys_SelectTableAdapter adpChemicalAnalys =
                new BaranDataAccess.Production.dstProductionTaskTableAdapters.spr_prd_ProductionTask_ChemicalAnalys_SelectTableAdapter();

            int ChemicalAnalysID = Convert.ToInt32(cmbChemicalAnalys.Value);
            //Save ------------------------------------------------------------------------------------------------------------------------
            if (ProductionTaskChemicalAnalysID <= 0)
            {
                DialogResult msgResult = MessageBoxX.ShowMessageBox(PublicEnum.EnmMessageType.msgSaveConfirm);
                if (msgResult == DialogResult.No) return;


                try
                {
                    ProductionTaskChemicalAnalysID = Convert.ToInt32(adpChemicalAnalys.NewProductionTask_ChemicalAnalys_Insert(ProductionTaskID, ChemicalAnalysID, CurrentUser.Instance.UserID));

                    if (ProductionTaskChemicalAnalysID > 0)
                    {
                        OnMessage(BaranResources.SaveSuccessful, PublicEnum.EnmMessageCategory.Success);

                        this.FillChemicalAnalysGrid();
                        ProductionTaskChemicalAnalysID = 0;

                    }
                    else
                        OnMessage(BaranResources.SaveFail, PublicEnum.EnmMessageCategory.Warning);
                }
                catch
                {
                    OnMessage(BaranResources.DoNotDoPleaseTryAgine, PublicEnum.EnmMessageCategory.Warning);
                }
            }

            // Update ----------------------------------------------------------------------------------------------------------------
            else if (ProductionTaskChemicalAnalysID > 0)
            {
                DialogResult msgResult = MessageBoxX.ShowMessageBox(PublicEnum.EnmMessageType.msgEditConfirm);
                if (msgResult == DialogResult.No) return;

                try
                {
                    int RowAffected = Convert.ToInt32(adpChemicalAnalys.Update(
                                    ProductionTaskChemicalAnalysID, ProductionTaskID, ChemicalAnalysID, CurrentUser.Instance.UserID));

                    if (RowAffected > 0)
                    {

                        OnMessage(BaranResources.EditSuccessful, PublicEnum.EnmMessageCategory.Success);
                        try
                        {
                            this.FillChemicalAnalysGrid();

                            ChangebtnUpdateToSave(btnAddDiscussion);
                            ProductionTaskDiscussionID = 0;
                        }
                        catch { }

                    }
                    else
                        OnMessage(BaranResources.SaveFail, PublicEnum.EnmMessageCategory.Warning);
                }
                catch
                {
                    OnMessage(BaranResources.DoNotDoPleaseTryAgine, PublicEnum.EnmMessageCategory.Warning);
                }
            }
        }

        private void grdChemicalAnalys_Click(object sender, EventArgs e)
        {
            if (grdChemicalAnalys.ActiveRow == null)
                return;


            try
            {
                cmbChemicalAnalys.Value = grdDiscusssion.ActiveRow.Cells[dstProductionTask1.spr_prd_ProductionTask_ChemicalAnalys_ByProductionTaskID_lst_Select.Fk_ChemicalAnalysIDColumn.ColumnName].Value;
                ProductionTaskID = (int)grdDiscusssion.ActiveRow.Cells[dstProductionTask1.spr_prd_ProductionTask_ChemicalAnalys_ByProductionTaskID_lst_Select.Fk_ProductionTaskIDColumn.ColumnName].Value;

                ChangebtnUpdateToSave(btnAddChemicalAnalys);
                ProductionTaskChemicalAnalysID = 0;
            }
            catch { }

        }

        private void grdChemicalAnalys_SizeChanged(object sender, EventArgs e)
        {
            egbChemicalAnalys.Size = new Size(egbChemicalAnalys.Size.Width, grpChemicalAnalys.Size.Height + grdChemicalAnalys.Size.Height + 60);
        }

        private void grdChemicalAnalys_ClickCellButton(object sender, Infragistics.Win.UltraWinGrid.CellEventArgs e)
        {
            #region Delete
            BaranDataAccess.Production.dstProductionTaskTableAdapters.spr_prd_ProductionTask_ChemicalAnalys_SelectTableAdapter adpChemicalAnalys =
                new BaranDataAccess.Production.dstProductionTaskTableAdapters.spr_prd_ProductionTask_ChemicalAnalys_SelectTableAdapter();


            if (e.Cell.Column.Key == "Delete")
            {

                try
                {
                    DialogResult msgResult = MessageBoxX.ShowMessageBox(PublicEnum.EnmMessageType.msgDeleteConfirm);
                    if (msgResult == DialogResult.No) return;

                    int RowAffected = (int)adpChemicalAnalys.Delete(Convert.ToInt32(e.Cell.Row.Cells[dstProductionTask1.spr_prd_ProductionTask_ChemicalAnalys_Select.ProductionTaskChemicalAnalysIDColumn.ColumnName].Value), CurrentUser.Instance.UserID);

                    if (RowAffected > 0)
                    {
                        e.Cell.Row.Delete();
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

            #endregion
            #region Update

            if (e.Cell.Column.Key == "Update")
            {
                if (grdDiscusssion.ActiveRow != null)
                {
                    ProductionTaskChemicalAnalysID = Convert.ToInt32(e.Cell.Row.Cells[dstProductionTask1.spr_prd_ProductionTask_ChemicalAnalys_ByProductionTaskID_lst_Select.ProductionTaskChemicalAnalysIDColumn.ColumnName].Value);
                    cmbChemicalAnalys.Value = e.Cell.Row.Cells[dstProductionTask1.spr_prd_ProductionTask_ChemicalAnalys_ByProductionTaskID_lst_Select.Fk_ChemicalAnalysIDColumn.ColumnName].Value;

                    this.ChangebtnSaveToUpdate(btnAddChemicalAnalys);
                }
            }

            #endregion
        }

        #endregion






    }
}
