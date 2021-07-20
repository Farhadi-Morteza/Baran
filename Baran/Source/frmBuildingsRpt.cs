using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Baran.Classes.Common;
using GMap.NET.MapProviders;
using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;

namespace Baran.Source
{
    public partial class frmBuildingsRpt : Baran.Base_Forms.frmChildBase
    {
        #region Constractor

        public frmBuildingsRpt()
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
            ComboBoxSetting.FillComboBox(PublicEnum.EnmComboSource.srcBuildingsCategory, cmbBuildingsCategory, "");
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

            if (tbcMain.TabControl.ActiveTab.Index == 0)
                this.ShowMap();
            if (tbcMain.TabControl.ActiveTab.Index == 1)
                this.FillGrid();
            if (tbcMain.TabControl.ActiveTab.Index == 2)
                this.DrowChart();  
        }

        public override void OnExport(Windows.Forms.UltraGrid grdItem)
        {
            base.OnExport(this.grdItem);
        }

        private void FillGrid()
        {
            this.SetVariables();

            BaranDataAccess.Source.dstReport.spr_src_Buildings_Rpt_SelectDataTable tbl =
                new BaranDataAccess.Source.dstReport.spr_src_Buildings_Rpt_SelectDataTable();
            BaranDataAccess.Source.dstReportTableAdapters.spr_src_Buildings_Rpt_SelectTableAdapter adp =
                new BaranDataAccess.Source.dstReportTableAdapters.spr_src_Buildings_Rpt_SelectTableAdapter();

            try
            {
                grdItem.DataMember = null;
                grdItem.DataSource = null;
                grdItem.DataBindings.Clear();

                BaranDataAccess.Source.dstReport dst =
                    new BaranDataAccess.Source.dstReport();

                grdItem.DataSource = dst;
                grdItem.DataMember = "spr_src_Buildings_Rpt_Select";

                tbl = adp.GetBuildingRptTable(1, strWhereClause, strSelectStatement, strGroupByClause, strOrderByClause, CurrentUser.Instance.UserID.ToString());

                if (tbl.Count < 1)
                {
                    OnMessage(BaranResources.RecordNotFound, PublicEnum.EnmMessageCategory.Warning);
                }

                grdItem.ClearUndoHistory();

                dst.spr_src_Buildings_Rpt_Select.Merge(tbl);

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
            catch
            {
            }
        }

        private void DrowChart()
        {
            BaranDataAccess.Source.dstReport.spr_src_Buildings_cht_SelectDataTable tbl =
                new BaranDataAccess.Source.dstReport.spr_src_Buildings_cht_SelectDataTable();
            BaranDataAccess.Source.dstReportTableAdapters.spr_src_Buildings_cht_SelectTableAdapter adp =
                new BaranDataAccess.Source.dstReportTableAdapters.spr_src_Buildings_cht_SelectTableAdapter();
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


                //chtChart.Data = null;
                chtChart.DataMember = string.Empty;
                chtChart.DataSource = null;
                //chtChart.DataBindings.Clear();

                BaranDataAccess.Source.dstReport dst =
                    new BaranDataAccess.Source.dstReport();

                chtChart.DataSource = dst;
                chtChart.DataMember = "spr_src_Buildings_cht_Select";

                tbl.Clear();
                tbl = adp.GetBuildingsChtTable(intAction, intCompanyCategory, CurrentUser.Instance.UserID);

                if (tbl.Count >= 1)
                {
                    chtChart.Visible = true;
                    dst.spr_src_Buildings_cht_Select.Clear();
                    dst.spr_src_Buildings_cht_Select.Merge(tbl);
                }
                else
                {
                    chtChart.Visible = false;
                    OnMessage(BaranResources.RecordNotFound, PublicEnum.EnmMessageCategory.Warning);
                }
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
                if (cmbBuildingsCategory.Value != null)
                    strWhereClause += " AND dbo.tbl_src_BuildingsCategory.BuildingsCategoryID = " + cmbBuildingsCategory.Value;



                BaranDataAccess.Source.dstReport.spr_src_Buildings_Map_SelectDataTable tbl =
                    new BaranDataAccess.Source.dstReport.spr_src_Buildings_Map_SelectDataTable();
                BaranDataAccess.Source.dstReportTableAdapters.spr_src_Buildings_Map_SelectTableAdapter adp =
                    new BaranDataAccess.Source.dstReportTableAdapters.spr_src_Buildings_Map_SelectTableAdapter();

                adp.FillBuildingMapTable(tbl, 1, strWhereClause, CurrentUser.Instance.UserID.ToString());


                BaranDataAccess.Map.dstLocation.spr_geo_LocationByID_SelectDataTable tblLocation =
                    new BaranDataAccess.Map.dstLocation.spr_geo_LocationByID_SelectDataTable();
                BaranDataAccess.Map.dstLocationTableAdapters.spr_geo_LocationByID_SelectTableAdapter adpLocation =
                    new BaranDataAccess.Map.dstLocationTableAdapters.spr_geo_LocationByID_SelectTableAdapter();





                if (tbl.Count > 0)
                {
                    MainMap.Overlays.Clear();
                    GMapOverlay routes = new GMapOverlay("routes");

                    foreach (var building in tbl)
                    {
                        string strTooltip = 
                            building.SubCollectionName 
                            + "\n" + building.BuildingName 
                            + "\n" + building.BuildingCategoryName 
                            + "\n" + building.BuildingArea;

                        List<PointLatLng> points = new List<PointLatLng>();
                        adpLocation.FillLocationByIDTable(tblLocation, null, building.BuildingsID, null, null, null, null, null);

                        if (tblLocation.Count > 0)
                        {
                            foreach (var point in tblLocation)
                            {
                                points.Add(new PointLatLng(Convert.ToDouble(point.Latitude), Convert.ToDouble(point.Longitude)));
                            }

                            GMapRoute rt = new GMapRoute(points, "hahahahaha");
                            {
                                rt.Stroke = new Pen(Color.FromArgb(144, Color.Red));
                                rt.Stroke.Width = 5;
                                rt.Stroke.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDot;
                            }
                            if (points.Count > 0)
                            {
                                GMapMarker mark = new GMarkerGoogle(points[points.Count / 2], GMarkerGoogleType.red_dot);
                                mark.ToolTipText = strTooltip;
                                mark.ToolTip.Font = new System.Drawing.Font("B Nazanin", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
                                mark.ToolTip.Fill = Brushes.Black;
                                mark.ToolTip.Foreground = Brushes.White;
                                mark.ToolTip.Stroke = Pens.Black;
                                mark.ToolTip.TextPadding = new Size(20, 20);
                                mark.ToolTipMode = MarkerTooltipMode.OnMouseOver;

                                markers.Markers.Add(mark);
                            }
                            
                            routes.Routes.Add(rt);
                        }

                    }
                    MainMap.Overlays.Add(routes);
                    MainMap.Overlays.Add(markers);
                    MainMap.ZoomAndCenterRoutes("routes");
                }
            }
            catch { }
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
                if (chkCategory.Checked)
                {
                    strSelectStatement += ", dbo.tbl_src_BuildingsCategory.Name AS [گروه] ";
                    strGroupByClause += ",    dbo.tbl_src_BuildingsCategory.Name  ";
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
        }

        #endregion

        #region Events

        #endregion
    }
}
