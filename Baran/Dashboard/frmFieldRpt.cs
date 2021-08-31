using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Baran.Classes.Common;


namespace Baran.Dashboard
{
    public partial class frmFieldRpt : Baran.Base_Forms.frmChildBase
    {
        public frmFieldRpt()
        {
            InitializeComponent();
        }

        WaiteForm waite;
        private int? FieldID = null, ProductionID = null;
        private Nullable<DateTime> FromDate , ToDate;

        BaranDataAccess.Production.dstProducts.spr_prd_Production_cmb_SelectDataTable tblProductionCmb =
            new BaranDataAccess.Production.dstProducts.spr_prd_Production_cmb_SelectDataTable();

        public override void OnformLoad()
        {
            base.OnformLoad();

            ComboBoxSetting.FillComboBox(PublicEnum.EnmComboSource.srcFieldByUserID, cmbField);
            ComboBoxSetting.FillComboBox(PublicEnum.EnmComboSource.srcProductionByUserID, cmbProduction);

            tblProductionCmb = (BaranDataAccess.Production.dstProducts.spr_prd_Production_cmb_SelectDataTable)cmbProduction.DataSource;

            DrowCharts();
        }

        public override void OnActiveForm()
        {
            base.OnActiveForm();

            frmMain ofrm = frmMain.Instanc;
            ofrm.EnableToolBarItems(cnsToolStripButton.Confirm, cnsToolStripButton.Cancel, cnsToolStripButton.Clear, cnsToolStripButton.Export);
            ofrm.EnableMenuStripItems(cnsMenustripItems.Confirm, cnsMenustripItems.Cancel, cnsMenustripItems.Clear, cnsMenustripItems.Export);
        }

        public override void OnConfirm()
        {
            base.OnConfirm();

            if (!this.ControlsValidation())
            {
                OnMessage(BaranResources.FeildIsEmpty, PublicEnum.EnmMessageCategory.Warning);
                return;
            }

            waite = new WaiteForm();
            try
            {
                if (mskFromDate.Value.ToString() != string.Empty)
                    FromDate = DateTimeUtility.ToGregorian(mskFromDate.Value.ToString());

                if (mskToDate.Value.ToString() != string.Empty)
                    ToDate = DateTimeUtility.ToGregorian(mskToDate.Value.ToString());


                DrowCharts();
            }
            catch 
            {

            }
        }

        private void DrowCharts()
        {
            DrowWorker();
            DrowMachinery();
            DrowFertilizer();
            DrowPesticide();
            DrowWater();
            DrowWaterStorage();
            DrowChemicalAnalys();
        }

        private void DrowWorker()
        {
            BaranDataAccess.Dashboard.dstFieldTableAdapters.spr_dsb_Field_Worker_Total_rptTableAdapter adp =
                new BaranDataAccess.Dashboard.dstFieldTableAdapters.spr_dsb_Field_Worker_Total_rptTableAdapter();
            adp.FillFieldWorkerTable(dstField1.spr_dsb_Field_Worker_Total_rpt, CurrentUser.Instance.UserID, FromDate, ToDate, FieldID, ProductionID);
            chtWorker.DataSource = dstField1;
            chtWorker.DataMember = dstField1.spr_dsb_Field_Worker_Total_rpt.TableName.ToString();

        }

        private void DrowMachinery()
        {
            BaranDataAccess.Dashboard.dstFieldTableAdapters.spr_dsb_Field_Machinery_Total_rptTableAdapter adp =
                new BaranDataAccess.Dashboard.dstFieldTableAdapters.spr_dsb_Field_Machinery_Total_rptTableAdapter();
            adp.FillFieldMachineryTable(dstField1.spr_dsb_Field_Machinery_Total_rpt, CurrentUser.Instance.UserID, FromDate, ToDate, FieldID, ProductionID);
            chtMachinery.DataSource = dstField1;
            chtMachinery.DataMember = dstField1.spr_dsb_Field_Machinery_Total_rpt.TableName.ToString();

        }

        private void DrowFertilizer()
        {
            BaranDataAccess.Dashboard.dstFieldTableAdapters.spr_dsb_Field_Fertilizer_Total_rptTableAdapter adp =
                new BaranDataAccess.Dashboard.dstFieldTableAdapters.spr_dsb_Field_Fertilizer_Total_rptTableAdapter();
            adp.FillFieldFertilizerTable(dstField1.spr_dsb_Field_Fertilizer_Total_rpt, CurrentUser.Instance.UserID, FromDate, ToDate, FieldID, ProductionID);
            chtFertilizer.DataSource = dstField1;
            chtFertilizer.DataMember = dstField1.spr_dsb_Field_Fertilizer_Total_rpt.TableName.ToString();
        }

        private void DrowPesticide()
        {
            BaranDataAccess.Dashboard.dstFieldTableAdapters.spr_dsb_Field_Pesticide_Total_rptTableAdapter adp =
                new BaranDataAccess.Dashboard.dstFieldTableAdapters.spr_dsb_Field_Pesticide_Total_rptTableAdapter();
            adp.FillFieldPesticideTable(dstField1.spr_dsb_Field_Pesticide_Total_rpt, CurrentUser.Instance.UserID, FromDate, ToDate, FieldID, ProductionID);
            chtPesticide.DataSource = dstField1;
            chtPesticide.DataMember = dstField1.spr_dsb_Field_Pesticide_Total_rpt.TableName.ToString();
        }

        private void DrowWater()
        {
            BaranDataAccess.Dashboard.dstFieldTableAdapters.spr_dsb_Field_Water_Total_rptTableAdapter adp =
                new BaranDataAccess.Dashboard.dstFieldTableAdapters.spr_dsb_Field_Water_Total_rptTableAdapter();
            adp.FillFieldWaterTable(dstField1.spr_dsb_Field_Water_Total_rpt, CurrentUser.Instance.UserID, FromDate, ToDate, FieldID, ProductionID);
            chtWater.DataSource = dstField1;
            chtWater.DataMember = dstField1.spr_dsb_Field_Water_Total_rpt.TableName.ToString();
        }

        private void DrowWaterStorage()
        {
            BaranDataAccess.Dashboard.dstFieldTableAdapters.spr_dsb_Field_WaterStorage_Total_rptTableAdapter adp =
                new BaranDataAccess.Dashboard.dstFieldTableAdapters.spr_dsb_Field_WaterStorage_Total_rptTableAdapter();
            adp.FillFieldWaterStorageTable(dstField1.spr_dsb_Field_WaterStorage_Total_rpt, CurrentUser.Instance.UserID, FromDate, ToDate, FieldID, ProductionID);
            chtWaterStorage.DataSource = dstField1;
            chtWaterStorage.DataMember = dstField1.spr_dsb_Field_WaterStorage_Total_rpt.TableName.ToString();
        }

        private void DrowChemicalAnalys()
        {
            BaranDataAccess.Dashboard.dstField.spr_dsb_Field_ChemicalAnalys_rptDataTable dtResult =
                new BaranDataAccess.Dashboard.dstField.spr_dsb_Field_ChemicalAnalys_rptDataTable();
            BaranDataAccess.Dashboard.dstFieldTableAdapters.spr_dsb_Field_ChemicalAnalys_rptTableAdapter adp =
                new BaranDataAccess.Dashboard.dstFieldTableAdapters.spr_dsb_Field_ChemicalAnalys_rptTableAdapter();
            adp.FillFieldChemicalAnalysTable(dtResult, CurrentUser.Instance.UserID, FromDate, ToDate, FieldID, ProductionID);


            var dtChart = dtResult.AsEnumerable()
                  .GroupBy(r1 => r1.Field<string>("NameFa"))
                .Select(g => g.Key).ToList();

            DataTable tbl = new DataTable("ChemicalAnalysTable");
            tbl.Columns.Add("Date", typeof(string));
            foreach (var i in dtChart)
            {
                tbl.Columns.Add(i.ToString(), typeof(decimal));
            }

            var dtDate = dtResult.AsEnumerable()
                .GroupBy(d => d.Field<string>("Date"))
                .Select(g => g.Key).ToList();

            foreach (var col in dtDate)
            {
                DataRow r = tbl.NewRow();
                r["Date"] = col;
                foreach (var row in dtResult)
                {
                    if (row.Date == col)
                    {
                        r[row.NameFa] = row.Percentage;
                    }
                    else
                    {
                        r[row.NameFa] = 0;
                    }
                }
                tbl.Rows.Add(r);
            }

            chtChemicalAnalys.DataSource = tbl;
            chtChemicalAnalys.DataMember = tbl.TableName;
        }

        public override void OnClear()
        {
            base.OnClear();
            ControlsSetting.ClearControls(grpControler.Controls);
            dstField1.Clear();
            FieldID = null;
            ProductionID = null;
            FromDate = null;
            ToDate = null;
        }

        private bool ControlsValidation()
        {
            bool blnResult = true;

            //if (mskFromDate.Value.ToString() == string.Empty)
            //{
            //    mskFromDate.Focus();
            //    blnResult = false;
            //}
            //else if (mskToDate.Value.ToString() == string.Empty)
            //{
            //    mskToDate.Focus();
            //    blnResult = false;
            //}
            //else if (cmbField.Value == null)
            //{
            //    cmbField.Focus();
            //    blnResult = false;
            //}

            return blnResult;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void cmbProduction_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbProduction.Value != null)
                    ProductionID = Convert.ToInt32(cmbProduction.Value);
                else
                    ProductionID = null;
            }
            catch
            {
                ProductionID = null;
            }
        }

        private void cmbField_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbField.Value != null)
                {
                    FieldID = Convert.ToInt32(cmbField.Value);
                    int id = Convert.ToInt32(cmbField.Value.ToString());
                    var tbl = tblProductionCmb.Where(s => s.FieldID == id).ToArray();
                    cmbProduction.DataSource = tbl;
                }
                else
                    FieldID = null;
            }
            catch
            {
                FieldID = null;
            }

        }

        private void tlpUp_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
