using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Baran.Classes.Common;
using BaranDataAccess;
using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;

namespace Baran.Dashboard
{
    public partial class frmFieldRpt : Baran.Base_Forms.frmChildBase
    {
        public frmFieldRpt()
        {
            InitializeComponent();
            setDate();

            for(int i = 0; i < tlpMain.RowCount; i++)
            {
                tlpMain.RowStyles[i].Height = 300;
            }

            MainMap.Overlays.Add(routes);
            MainMap.Overlays.Add(markers);

        }



     

    internal readonly GMapOverlay routes = new GMapOverlay("routes");
    internal readonly GMapOverlay markers = new GMapOverlay("markers");

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

            mskFromDate.Text = CurrentDate.Instance.CurrentDateShamsi;
            mskToDate.Text = DateTimeUtility.AddDay(CurrentDate.Instance.CurrentDateShamsi, 30);

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

             DrowCharts();

        }

        private void DrowCharts()
        {
      
            try
            {
                if (mskFromDate.Value.ToString() == "")
                    FromDate = null;
                else
                    FromDate = DateTimeUtility.ToGregorian(mskFromDate.Value.ToString());
                

                if (mskToDate.Value.ToString() != "")
                    ToDate = DateTimeUtility.ToGregorian(mskToDate.Value.ToString());
                else
                    ToDate = null;

                FillGride();
                DrowWorker();
                DrowMachinery();
                DrowFertilizer();
                DrowPesticide();
                DrowWater();
                DrowWaterStorage();
                DrowChemicalAnalys();
                FillgrdProduction();
                DrowMap();
                
            }
            catch
            {

            }
      
        }

        private void DrowMap()
        {
            using (var dbContext = new AMSEntities())
            {
                var fields = dbContext.spr_dsb_Field_Location_rpt(CurrentUser.Instance.UserID, FromDate, ToDate, FieldID, ProductionID);

                foreach (var result in fields)
                {
                    if (result.LocationPolygon != null)
                    {
                        List<PointLatLng> points = new List<PointLatLng>();
                        points = GeoUtils.ConvertStringCoordinatesToGMapPolygony(result.LocationPolygon.ProviderValue.ToString());

                        GMapRoute route = new GMapRoute(points, "hahahahaha");
                        {
                            route.Stroke = new Pen(Color.FromArgb(255, PublicVariables.FieldColor));
                            route.Stroke.Width = PublicVariables.StrokeWidth;
                            route.Stroke.DashStyle = PublicVariables.StrokeDashStyle;
                        }

                        string strTooltip = $"کشت و صنعت: {result.CollectionName} " +
                            $"\n واحد: {result.SubCollectionName} " +
                            $"\n واحد فرعی: {result.PartName}" +
                            $"\n نام : {result.FieldName} ";

                        GMapMarker mark = new GMarkerGoogle(points[points.Count / 2], new Bitmap(System.Drawing.Image.FromFile(PublicMethods.PictureFileNamePath(cnsPictureName.FieldMarker))));
                        mark.ToolTipText = strTooltip;
                        mark.ToolTip.Font = new System.Drawing.Font("B Nazanin", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
                        mark.ToolTip.Fill = Brushes.Black;
                        mark.ToolTip.Foreground = Brushes.White;
                        mark.ToolTip.Stroke = Pens.Black;
                        mark.ToolTip.TextPadding = new Size(20, 20);
                        mark.ToolTipMode = MarkerTooltipMode.OnMouseOver;

                        markers.Markers.Add(mark);
                        routes.Routes.Add(route);
                    }
                }
                MainMap.ZoomAndCenterRoutes("routes");
            }
        }

        private void FillGride()
        {
            BaranDataAccess.Dashboard.dstFieldTableAdapters.spr_dsb_Field_ProducttionTask_rptTableAdapter adp =
                new BaranDataAccess.Dashboard.dstFieldTableAdapters.spr_dsb_Field_ProducttionTask_rptTableAdapter();
            adp.FillFieldProductionTaskTable(dstField1.spr_dsb_Field_ProducttionTask_rpt, CurrentUser.Instance.UserID, FromDate, ToDate, FieldID, ProductionID);
            grdItem.FreeSpaceGenerator();
        }

        private void FillgrdProduction()
        {
            BaranDataAccess.Dashboard.dstFieldTableAdapters.spr_dsb_Field_Producttion_rptTableAdapter adp =
                new BaranDataAccess.Dashboard.dstFieldTableAdapters.spr_dsb_Field_Producttion_rptTableAdapter();
            adp.FillFieldProductionTable(dstField1.spr_dsb_Field_Producttion_rpt, CurrentUser.Instance.UserID, FromDate, ToDate, FieldID, ProductionID);
            grdProduction.FreeSpaceGenerator();
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

            if (tbl.Rows.Count > 0)
                chtChemicalAnalys.Visible = true;
            else
                chtChemicalAnalys.Visible = false;
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
            chtChemicalAnalys.Visible = false;
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

        private void setDate()
        {
            mskToDate.Text = CurrentDate.Instance.CurrentDateShamsi;

            if (rdbTreeDays.Checked)
                mskFromDate.Text = DateTimeUtility.AddDay(CurrentDate.Instance.CurrentDateShamsi, -3);
            else if(rdbWeek.Checked)
                mskFromDate.Text = DateTimeUtility.AddDay(CurrentDate.Instance.CurrentDateShamsi, -7);
            else if (rdbMonth.Checked)
                mskFromDate.Text = DateTimeUtility.AddDay(CurrentDate.Instance.CurrentDateShamsi, -30);
            else if (rdbYear.Checked)
                mskFromDate.Text = DateTimeUtility.AddDay(CurrentDate.Instance.CurrentDateShamsi, -360);
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

        private void lblMachinery_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Baran.Dashboard.frmMachineryRpt ofrm = new frmMachineryRpt(mskFromDate.Value.ToString(), mskToDate.Value.ToString());            
            ofrm.Show();
        }

        private void lblWorker_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmWorkerRpt ofrm = new frmWorkerRpt(mskFromDate.Value.ToString(), mskToDate.Value.ToString());
            ofrm.Show();
        }

        private void lblWater_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmWaterRpt ofrm = new frmWaterRpt(mskFromDate.Value.ToString(), mskToDate.Value.ToString());
            ofrm.Show();
        }

        private void lblPesticide_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmPesticideRpt ofrm = new frmPesticideRpt(mskFromDate.Value.ToString(), mskToDate.Value.ToString());
            ofrm.Show();
        }

        private void lblWaterStorage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmWaterStorageRpt ofrm = new frmWaterStorageRpt(mskFromDate.Value.ToString(), mskToDate.Value.ToString());
            ofrm.Show();
        }

        private void lblChemicalAnalys_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmChemicalAnalysRpt ofrm = new frmChemicalAnalysRpt(mskFromDate.Value.ToString(), mskToDate.Value.ToString());
            ofrm.Show();
        }

        private void lblFertilizer_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmFertilizerRpt ofrm = new frmFertilizerRpt(mskFromDate.Value.ToString(), mskToDate.Value.ToString());
            ofrm.Show();

        }

        private void rdbTreeDays_CheckedChanged(object sender, EventArgs e)
        {
            setDate();
        }

        private void rdbWeek_CheckedChanged(object sender, EventArgs e)
        {
            setDate();
        }

        private void rdbMonth_CheckedChanged(object sender, EventArgs e)
        {
            setDate();
        }

        private void rdbYear_CheckedChanged(object sender, EventArgs e)
        {
            setDate();
        }

        private void mapMain_MouseEnter(object sender, EventArgs e)
        {
            ultraExpandableGroupBoxPanel1.AutoScroll = false;
        }

        private void mapMain_MouseLeave(object sender, EventArgs e)
        {
            ultraExpandableGroupBoxPanel1.AutoScroll = true;
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
