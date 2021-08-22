using Baran.Classes.Common;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Baran.Source
{
    public partial class frmWarehouseRpt : Baran.Base_Forms.frmChildBase
    {
        #region Constractor

        public frmWarehouseRpt()
        {
            InitializeComponent();

            // config map         
            //MainMap.MapProvider = GMapProviders.BingSatelliteMap;
            //MainMap.Position = new PointLatLng(32.843888, 51.967501);
            //MainMap.MinZoom = 1;
            //MainMap.MaxZoom = 18;
            //MainMap.Zoom = 5; 
        }

        #endregion

        #region Variables
        //@Action AS INT
        BaranDataAccess.Company.dstCompany.spr_src_Subcollection_SelectDataTable tblSubCollection =
            new BaranDataAccess.Company.dstCompany.spr_src_Subcollection_SelectDataTable();
        BaranDataAccess.Company.dstCompany.spr_src_Part_SelectDataTable tblPart =
            new BaranDataAccess.Company.dstCompany.spr_src_Part_SelectDataTable();

        string
            strWhereClause
            , strSelectStatement
            , strGroupByClause
            , strOrderByClause
            ;

        internal readonly GMapOverlay routes = new GMapOverlay("routes");
        internal readonly GMapOverlay polygons = new GMapOverlay("polygons");
        internal readonly GMapOverlay markers = new GMapOverlay("markers");

        #endregion

        #region Propertise

        #endregion

        #region Methods

        public override void OnformLoad()
        {
            base.OnformLoad();
            ComboBoxSetting.FillComboBox(PublicEnum.EnmComboSource.srcCollection, cmbCollection, "");
            ComboBoxSetting.FillComboBox(PublicEnum.EnmComboSource.srcSubcollection, cmbSubcollection, "");
            ComboBoxSetting.FillComboBox(PublicEnum.EnmComboSource.srcPart, cmbPart, "");
            ComboBoxSetting.FillComboBox(PublicEnum.EnmComboSource.srcWarehouseType, cmbWarehouseType, "");
            ComboBoxSetting.FillComboBox(PublicEnum.EnmComboSource.srcWarehouseUseType, cmbWarehouseUseType, "");

            tblSubCollection = (BaranDataAccess.Company.dstCompany.spr_src_Subcollection_SelectDataTable)cmbSubcollection.DataSource;
            tblPart = (BaranDataAccess.Company.dstCompany.spr_src_Part_SelectDataTable)cmbPart.DataSource;
        }

        public override void OnActiveForm()
        {
            base.OnActiveForm();

            frmMain ofrm = frmMain.Instanc;
            ofrm.EnableToolBarItems(cnsToolStripButton.Confirm, cnsToolStripButton.Cancel,    cnsToolStripButton.Clear, cnsToolStripButton.Export);
            ofrm.EnableMenuStripItems(cnsMenustripItems.Confirm, cnsMenustripItems.Cancel,  cnsMenustripItems.Clear, cnsMenustripItems.Export);
        }

        public override void OnConfirm()
        {
            base.OnConfirm();
            if (tbcMain.TabControl.ActiveTab.Index == 0)
                this.ShowMap();
            if (tbcMain.TabControl.ActiveTab.Index == 1)
                this.FillGrid();
            if (tbcMain.TabControl.ActiveTab.Index == 2)
                this.DrowChart();     
        }

        public override void OnClear()
        {
            base.OnClear();
            if (tbcMain.TabControl.ActiveTab.Index == 2)
                Baran.Classes.Common.ControlsSetting.ClearControls(grpTableControls.Controls);
            if (tbcMain.TabControl.ActiveTab.Index == 1)
                Baran.Classes.Common.ControlsSetting.ClearControls(grpChartControls.Controls);
            if (tbcMain.TabControl.ActiveTab.Index == 0)
            {
                Baran.Classes.Common.ControlsSetting.ClearControls(grpControls.Controls);
                this.ClearMap();
            }

            cmbSubcollection.DataSource = tblSubCollection;
            cmbPart.DataSource = tblPart;
        }

        public override void OnExport(Windows.Forms.UltraGrid grdItem)
        {
            base.OnExport(this.grdItem);
        }

        private void FillGrid()
        {
            this.SetVariables();

            BaranDataAccess.Source.dstReport.spr_src_WareHouse_Rpt_SelectDataTable tbl =
                new BaranDataAccess.Source.dstReport.spr_src_WareHouse_Rpt_SelectDataTable();
            BaranDataAccess.Source.dstReportTableAdapters.spr_src_WareHouse_Rpt_SelectTableAdapter adp =
                new BaranDataAccess.Source.dstReportTableAdapters.spr_src_WareHouse_Rpt_SelectTableAdapter();
            try
            {
                grdItem.DataMember = null;
                grdItem.DataSource = null;
                grdItem.DataBindings.Clear();

                BaranDataAccess.Source.dstReport dst = 
                    new BaranDataAccess.Source.dstReport();

                grdItem.DataSource = dst;
                grdItem.DataMember = "spr_src_WareHouse_Rpt_Select"; 
    
                tbl = adp.GetWarehouseRptTable(1, strWhereClause, strSelectStatement, strGroupByClause, strOrderByClause, CurrentUser.Instance.UserID.ToString());
                if (tbl.Count > 0)
                {
                    grdItem.ClearUndoHistory();

                    dst.spr_src_WareHouse_Rpt_Select.Merge(tbl);

                    grdItem.DisplayLayout.Bands[0].Columns["RowID"].Header.VisiblePosition = grdItem.DisplayLayout.Bands[0].Columns.Count;
                    grdItem.DisplayLayout.Bands[0].Columns["FreeSpace"].Header.VisiblePosition = 0;

                    Infragistics.Win.UltraWinGrid.UltraGridBand band = this.grdItem.DisplayLayout.Bands[0];

                    // Add a summary.
                    Infragistics.Win.UltraWinGrid.SummarySettings summary = band.Summaries.Add(Infragistics.Win.UltraWinGrid.SummaryType.Sum, band.Columns["متراژ کل"]);
                    summary.SummaryPosition = Infragistics.Win.UltraWinGrid.SummaryPosition.Right;
                    summary.DisplayFormat = " {0:###,##.##}";
                    ///////////////////////////////////////////////////////////////////
                    band.Override.BorderStyleSummaryValue = Infragistics.Win.UIElementBorderStyle.None;
                    band.SummaryFooterCaption = "";

                    grdItem.FreeSpaceGenerator();
                }
                else
                {
                    OnMessage(BaranResources.RecordNotFound, PublicEnum.EnmMessageCategory.Warning);
                }
            }
            catch 
            {
            }
        }

        private void DrowChart()
        {
            BaranDataAccess.Source.dstReport.spr_src_Warehouse_cht_SelectDataTable tbl =
                new BaranDataAccess.Source.dstReport.spr_src_Warehouse_cht_SelectDataTable();
            BaranDataAccess.Source.dstReportTableAdapters.spr_src_Warehouse_cht_SelectTableAdapter adp =
                new BaranDataAccess.Source.dstReportTableAdapters.spr_src_Warehouse_cht_SelectTableAdapter();
            try
            {
                int intCompanyCategory = 1;
                if (rdbCompany.Checked)
                    intCompanyCategory = 1;
                else if (rdbCollection.Checked)
                    intCompanyCategory = 2;
                else if (rdbSubcollection.Checked)
                    intCompanyCategory = 3;
                else if (rdbPart.Checked)
                    intCompanyCategory = 4;

                int intAction = 1;
                if (rdbWarehouseUseType.Checked)
                    intAction = 1;
                else if (rdbWarehouseType.Checked)
                    intAction = 2;


                //chtChart.Data = null;
                chtChart.DataMember = string.Empty;
                chtChart.DataSource = null;
                //chtChart.DataBindings.Clear();

                BaranDataAccess.Source.dstReport dst =
                    new BaranDataAccess.Source.dstReport();

                chtChart.DataSource = dst;
                chtChart.DataMember = "spr_src_Warehouse_cht_Select";

                tbl.Clear();
                tbl = adp.GetWarehouseChtTable(intAction, intCompanyCategory, CurrentUser.Instance.UserID.ToString());

                if (tbl.Count >= 1)
                {
                    chtChart.Visible = true;
                    dst.spr_src_Warehouse_cht_Select.Clear();
                    dst.spr_src_Warehouse_cht_Select.Merge(tbl);
                }
                else
                    chtChart.Visible = false;
            }
            catch
            {
                this.lblMessage.Text = BaranResources.AccessibleItemsInsertionInDBError;
            }
        }

        private void ShowMap()
        {
            this.ClearMap();
            try
            {
                strWhereClause = string.Empty;
                if (cmbCollection.Value != null)
                {
                    strWhereClause += " AND dbo.tbl_src_Collection.CollectionID = " + cmbCollection.Value;
                }
                if (cmbSubcollection.Value != null)
                    strWhereClause += " AND dbo.tbl_src_Subcollection.SubCollectionID = " + cmbSubcollection.Value;
                if (cmbPart.Value != null)
                    strWhereClause += " AND dbo.tbl_src_Part.PartID = " + cmbPart.Value;
                if (cmbWarehouseType.Value != null)
                    strWhereClause += " AND dbo.tbl_src_WarehouseType.WarehouseTypeID = " + cmbWarehouseType.Value;
                if (cmbWarehouseUseType.Value != null)
                    strWhereClause += " AND dbo.tbl_src_WareHouseUseType.WarehouseUseTypeID = " + cmbWarehouseUseType.Value;

                using (BaranDataAccess.AMSEntities db = new BaranDataAccess.AMSEntities())
                {
                    var warehouses = db.spr_src_WareHouse_Map_Select(1, strWhereClause, CurrentUser.Instance.UserID.ToString());

                    foreach (var warehouse in warehouses)
                    {
                        string strTooltip =
                            warehouse.PartName
                            + "\n" +
                            "نام انبار:" + warehouse.WarehouseName
                            + "\n" +
                            "مساحت کل:" + warehouse.WarehouseArea
                            + "\n" +
                            "نوع انبار:" + warehouse.WarehouseTypeName
                            + "\n" +
                            "نوع کاربری:" + warehouse.WarehouseUseTypeName;

                        List<PointLatLng> points = new List<PointLatLng>();

                        if (warehouse.Location != null)
                        {
                            points = GeoUtils.ConvertStringCoordinatesToGMapPolygony(warehouse.Location.ProviderValue.ToString());

                            GMapRoute rt = new GMapRoute(points, string.Empty);
                            {
                                rt.Stroke = new Pen(Color.FromArgb(144, Color.Red));
                                rt.Stroke.Width = 5;
                                rt.Stroke.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDot;
                            }

                            GMapMarker mark = new GMarkerGoogle(points[points.Count / 2], GMarkerGoogleType.red_dot);
                            mark.ToolTipText = strTooltip;
                            mark.ToolTip.Font = new System.Drawing.Font("B Nazanin", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
                            mark.ToolTip.Fill = Brushes.Black;
                            mark.ToolTip.Foreground = Brushes.White;
                            mark.ToolTip.Stroke = Pens.Black;
                            mark.ToolTip.TextPadding = new Size(20, 20);
                            mark.ToolTipMode = MarkerTooltipMode.OnMouseOver;

                            markers.Markers.Add(mark);

                            routes.Routes.Add(rt);
                        }
                    }
                }
                MainMap.Overlays.Add(routes);
                MainMap.Overlays.Add(markers);
                MainMap.ZoomAndCenterRoutes("routes");
            }
            catch
            { }
        }

        private void ClearMap()
        {
            try
            {
                //polygons.Polygons.Clear();
                //routes.Routes.Clear();
                //markers.Markers.Clear();

                polygons.Clear();
                routes.Clear();
                markers.Clear();
                MainMap.Overlays.Clear();
            }
            catch
            {

            }
        }

        private void SetVariables()
        {
            strSelectStatement = string.Empty;
            strWhereClause = string.Empty;
            strGroupByClause = string.Empty;
            strOrderByClause = string.Empty;

            try
            {
                if (chkWarehouseType.Checked)
                {
                    strSelectStatement += ", dbo.tbl_src_WarehouseType.Name AS [نوع انبار] ";
                    strGroupByClause += ",    dbo.tbl_src_WarehouseType.Name  ";
                }
                if(chkWarehouseUseType.Checked)
                {
                    strSelectStatement += ", dbo.tbl_src_WareHouseUseType.Name AS [نوع کاربری] ";
                    strGroupByClause += ",    dbo.tbl_src_WareHouseUseType.Name  ";
                }
                if (chkPart.Checked)
                {
                    strSelectStatement += ",dbo.tbl_src_Part.Name AS [واحد فرعی] ";
                    strGroupByClause += ", dbo.tbl_src_Part.Name ";
                }
                if (chkSubcollection.Checked)
                {
                    strSelectStatement += ", dbo.tbl_src_Subcollection.Name AS [واحد] ";
                    strGroupByClause += ", dbo.tbl_src_Subcollection.Name  ";
                }
                if (chkCollection.Checked)
                {
                    //strWhereClause += " AND dbo.tbl_src_Collection.CollectionID = " + cmbCollection.Value;
                    strSelectStatement += ", dbo.tbl_src_Collection.Name AS [کشت و صنعت] ";
                    strGroupByClause += ", dbo.tbl_src_Collection.Name ";
                }
                if (chkCompany.Checked)
                {
                    strSelectStatement += ", dbo.tbl_src_Company.Name AS [شرکت] ";
                    strGroupByClause += ", dbo.tbl_src_Company.Name ";
                }

                //---------------------------------------------------------------------------------------------------

                if (chkCompany.Checked)
                {
                    strOrderByClause += ", dbo.tbl_src_Company.Name ";
                }
                if (chkCollection.Checked)
                {
                    strOrderByClause += ", dbo.tbl_src_Collection.Name ";
                }
                if (chkSubcollection.Checked)
                {
                    strOrderByClause += ", dbo.tbl_src_Subcollection.Name  ";
                }
                if (chkPart.Checked)
                {
                    strOrderByClause += ", dbo.tbl_src_Part.Name ";
                }
                if (strOrderByClause != string.Empty)
                {
                    strOrderByClause = strOrderByClause.Remove(0, 1);
                    strOrderByClause = " ORDER BY " + strOrderByClause;
                }
            }
            catch { }
        }


        #endregion

        private void grpTableControls_Click(object sender, EventArgs e)
        {

        }


        private void cmbCollection_ValueChanged(object sender, EventArgs e)
        {
            if (cmbCollection.Value == null)
                return;
            int id = Convert.ToInt32(cmbCollection.Value.ToString());
            var tbl = tblSubCollection.Where(s => s.Fk_CollectionID == id).ToArray();
            cmbSubcollection.DataSource = tbl;
        }

        private void cmbSubcollection_ValueChanged(object sender, EventArgs e)
        {
            if (cmbSubcollection.Value == null)
                return;
            int id = Convert.ToInt32(cmbSubcollection.Value.ToString());
            var tbl = tblPart.Where(s => s.Fk_SubcollectionID == id).ToArray();
            cmbPart.DataSource = tbl;
        }


        #region Events

        #endregion
    }
}
