using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Baran.Classes.Common;
using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;

namespace Baran.Source
{
    public partial class frmFieldRpt : Baran.Base_Forms.frmChildBase
    {
        public frmFieldRpt()
        {
            InitializeComponent();
        }

        #region Variables
        //@Action AS INT
        internal readonly GMapOverlay routes = new GMapOverlay("routes");
        internal readonly GMapOverlay polygons = new GMapOverlay("polygons");
        internal readonly GMapOverlay markers = new GMapOverlay("markers");

        string
            strWhereClause
            , strSelectStatement
            , strGroupByClause
            , strOrderByClause
            ;
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
            ComboBoxSetting.FillComboBox(PublicEnum.EnmComboSource.srcSoilTexture, cmbSoilTexture, "");
            ComboBoxSetting.FillComboBox(PublicEnum.EnmComboSource.srcOwnership, cmbOwnership, "");
            ComboBoxSetting.FillComboBox(PublicEnum.EnmComboSource.srcFieldUseType, cmbFieldUseType, "");
            ComboBoxSetting.FillComboBox(PublicEnum.EnmComboSource.srcProvince, cmbProvince, "");
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
                if (cmbProvince.Value != null)
                    strWhereClause += " AND dbo.tbl_cmn_Province.ProvinceID =" + cmbProvince.Value;
                if (cmbTownship.Value != null)
                    strWhereClause += " AND dbo.tbl_cmn_Township.TownshipID = " + cmbTownship.Value;
                if (cmbSoilTexture.Value != null)
                    strWhereClause += " AND dbo.tbl_cmn_SoilTexture.SoilTextureID = " + cmbSoilTexture.Value;
                if (cmbOwnership.Value != null)
                    strWhereClause += " AND dbo.tbl_cmn_Ownership.OwnershipID = " + cmbOwnership.Value;
                if (cmbFieldUseType.Value != null)
                    strWhereClause += " AND dbo.tbl_src_FieldUseType.FieldUseTypeID = " + cmbFieldUseType.Value;
                if (chkChangeUse.Checked)
                    strWhereClause += " AND dbo.tbl_src_Field.changeUse = " + chkChangeUse;

                //====================================================================================================
                //BaranDataAccess.UnitOfWork db = new BaranDataAccess.UnitOfWork();

                //var fields = db.FieldMapRepository.GetAll();
                //var fields = db.spr_src_Field_Map_Select(2, strWhereClause, CurrentUser.Instance.UserID.ToString());
                BaranDataAccess.AMSEntities DB = new BaranDataAccess.AMSEntities();
                //var fields = DB.spr_src_Field_Map_Select(2, strWhereClause, "68");

                //using (BaranDataAccess.AMSEntities db = new BaranDataAccess.AMSEntities())
                //{
                //    var fields = db.spr_src_Field_Map(2, strWhereClause, CurrentUser.Instance.UserID.ToString());

                //    //====================================================================================================

                //    foreach (var field in fields)
                //    {
                //        string strTooltip =
                //            field.PartName
                //            + "\n" +
                //            "نام قطعه:" + field.FieldName
                //            + "\n" +
                //            "مساحت کل:" + field.TotalArea
                //            + "\n" +
                //            "مساحت قابل استفاده::" + field.UsableArea
                //            + "\n" +
                //            "بافت خاک:" + field.SoilTexture
                //            + "\n" +
                //            "نوع کاربری:" + field.FieldUseType
                //            + "\n" +
                //            "شماره سند:" + field.DocNumber;

                //        List<PointLatLng> points = new List<PointLatLng>();

                //        if (field.LocationPolygon != null)
                //        {
                //            points = GeoUtils.ConvertStringCoordinatesToGMapPolygony(field.LocationPolygon.ProviderValue.ToString());

                //            GMapRoute rt = new GMapRoute(points, "hahahahaha");
                //            {
                //                rt.Stroke = new Pen(Color.FromArgb(144, Color.Red));
                //                rt.Stroke.Width = 5;
                //                rt.Stroke.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDot;
                //            }

                //            GMapMarker mark = new GMarkerGoogle(points[points.Count / 2], GMarkerGoogleType.red_dot);
                //            mark.ToolTipText = strTooltip;
                //            mark.ToolTip.Font = new System.Drawing.Font("B Nazanin", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
                //            mark.ToolTip.Fill = Brushes.Black;
                //            mark.ToolTip.Foreground = Brushes.White;
                //            mark.ToolTip.Stroke = Pens.Black;
                //            mark.ToolTip.TextPadding = new Size(20, 20);
                //            mark.ToolTipMode = MarkerTooltipMode.OnMouseOver;

                //            markers.Markers.Add(mark);

                //            routes.Routes.Add(rt);
                //        }
                //    }
                //}
                MainMap.Overlays.Add(routes);
                MainMap.Overlays.Add(markers);
                //MainMap.ZoomAndCenterRoutes("routes");
            }
            catch
            { }

            //BaranDataAccess.Source.dstReport.spr_src_Field_Map_SelectDataTable tbl =
            //    new BaranDataAccess.Source.dstReport.spr_src_Field_Map_SelectDataTable();
            //BaranDataAccess.Source.dstReportTableAdapters.spr_src_Field_Map_SelectTableAdapter adp =
            //    new BaranDataAccess.Source.dstReportTableAdapters.spr_src_Field_Map_SelectTableAdapter();

            //adp.FillFieldMapTable(tbl, 2, strWhereClause, CurrentUser.Instance.UserID.ToString());

            //BaranDataAccess.Map.dstLocation.spr_geo_LocationByID_SelectDataTable tblLocation =
            //    new BaranDataAccess.Map.dstLocation.spr_geo_LocationByID_SelectDataTable();
            //BaranDataAccess.Map.dstLocationTableAdapters.spr_geo_LocationByID_SelectTableAdapter adpLocation =
            //    new BaranDataAccess.Map.dstLocationTableAdapters.spr_geo_LocationByID_SelectTableAdapter();

            //if (tbl.Count > 0)
            //{
            //    MainMap.Overlays.Clear();
            //    GMapOverlay routes = new GMapOverlay("routes");
            //    foreach (var field in tbl)
            //    {

            //        string strTooltip =
            //            field.PartName
            //            + "\n" +
            //            "نام قطعه:" + field.FieldName
            //            + "\n" +
            //            "مساحت کل:" + field.TotalArea
            //            + "\n" +
            //            "مساحت قابل استفاده::" + field.UsableArea
            //            + "\n" +
            //            "بافت خاک:" + field.SoilTexture
            //            + "\n" +
            //            "نوع کاربری:" + field.FieldUseType
            //            + "\n" +
            //            "شماره سند:" + field.DocNumber;

            //        List<PointLatLng> points = new List<PointLatLng>();
            //        //points = GeoUtils.ConvertStringCoordinatesToGMapPolygony(field.LocationPolygon.ProviderValue.ToString());
            //        //adpLocation.FillLocationByIDTable(tblLocation, field.FieldID, null, null, null, null, null, null);

            //        if (tblLocation.Count > 0)
            //        {

            //            foreach (var point in tblLocation)
            //            {
            //                points.Add(new PointLatLng(Convert.ToDouble(point.Latitude), Convert.ToDouble(point.Longitude)));
            //            }


            //            GMapRoute rt = new GMapRoute(points, "hahahahaha");
            //            {
            //                rt.Stroke = new Pen(Color.FromArgb(144, Color.Red));
            //                rt.Stroke.Width = 5;
            //                rt.Stroke.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDot;
            //            }
            //            //int poi = points.Count / 2;
            //            GMapMarker mark = new GMarkerGoogle(points[points.Count / 2], GMarkerGoogleType.red_dot);
            //            mark.ToolTipText = strTooltip;
            //            mark.ToolTip.Font = new System.Drawing.Font("B Nazanin", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            //            mark.ToolTip.Fill = Brushes.Black;
            //            mark.ToolTip.Foreground = Brushes.White;
            //            mark.ToolTip.Stroke = Pens.Black;
            //            mark.ToolTip.TextPadding = new Size(20, 20);
            //            mark.ToolTipMode = MarkerTooltipMode.OnMouseOver;

            //            markers.Markers.Add(mark);

            //            routes.Routes.Add(rt);
            //        }
            //    }
            //    MainMap.Overlays.Add(routes);
            //    MainMap.Overlays.Add(markers);
            //    //MainMap.ZoomAndCenterRoutes("routes");

            //}
            //}
            //        catch { }
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

        private void FillGrid()
        {
            this.SetVariables();

            BaranDataAccess.Source.dstReport.spr_src_Field_Rpt_SelectDataTable tblField =
                new BaranDataAccess.Source.dstReport.spr_src_Field_Rpt_SelectDataTable();
            BaranDataAccess.Source.dstReportTableAdapters.spr_src_Field_Rpt_SelectTableAdapter adpField =
                new BaranDataAccess.Source.dstReportTableAdapters.spr_src_Field_Rpt_SelectTableAdapter();

            try
            {
                grdItem.DataMember = null;
                grdItem.DataSource = null;
                grdItem.DataBindings.Clear();

                BaranDataAccess.Source.dstReport dst =
                    new BaranDataAccess.Source.dstReport();

                grdItem.DataSource = dst;
                grdItem.DataMember = "spr_src_Field_Rpt_Select";


                tblField = adpField.GetFieldRptTable(2, strWhereClause, strSelectStatement, strGroupByClause, strOrderByClause, CurrentUser.Instance.UserID.ToString());
                if (tblField.Count > 0)
                {
                    grdItem.ClearUndoHistory();

                    dst.spr_src_Field_Rpt_Select.Merge(tblField);

                    grdItem.DisplayLayout.Bands[0].Columns["RowID"].Header.VisiblePosition = grdItem.DisplayLayout.Bands[0].Columns.Count;
                    grdItem.DisplayLayout.Bands[0].Columns["FreeSpace"].Header.VisiblePosition = 0;

                    Infragistics.Win.UltraWinGrid.UltraGridBand band = this.grdItem.DisplayLayout.Bands[0];

                    // Add a summary.
                    Infragistics.Win.UltraWinGrid.SummarySettings summary = band.Summaries.Add(Infragistics.Win.UltraWinGrid.SummaryType.Sum, band.Columns["مساحت کل"]);
                    summary.SummaryPosition = Infragistics.Win.UltraWinGrid.SummaryPosition.Right;
                    summary.DisplayFormat = " مساحت کل {0:###,##.##}";
                    ///////////////////////////////////////////////////////////////////
                    Infragistics.Win.UltraWinGrid.SummarySettings summary2 = band.Summaries.Add(Infragistics.Win.UltraWinGrid.SummaryType.Sum, band.Columns["مساحت قابل استفاده"]);
                    summary2.SummaryPosition = Infragistics.Win.UltraWinGrid.SummaryPosition.Right;
                    summary2.DisplayFormat = "  مساحت قابل استفاده {0:###,##.##}";
                    ///////////////////////////////////////////////////////////////////
                    band.Override.BorderStyleSummaryValue = Infragistics.Win.UIElementBorderStyle.None;
                    band.SummaryFooterCaption = "جمع کل";

                    grdItem.FreeSpaceGenerator();
                    //this.grdItem.DisplayLayout.Bands[0].Columns[6].MergedCellEvaluationType =
                    //    Infragistics.Win.UltraWinGrid.MergedCellEvaluationType.MergeSameText;
                    //grdItem.DisplayLayout.Override.MergedCellStyle = Infragistics.Win.UltraWinGrid.MergedCellStyle.Always;
                    //grdItem.DisplayLayout.Bands[0].Columns[6].MergedCellStyle = Infragistics.Win.UltraWinGrid.MergedCellStyle.Always; 
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
            BaranDataAccess.Source.dstReport.spr_src_Field_cht_SelectDataTable tbl =
                new BaranDataAccess.Source.dstReport.spr_src_Field_cht_SelectDataTable();
            BaranDataAccess.Source.dstReportTableAdapters.spr_src_Field_cht_SelectTableAdapter adp =
                new BaranDataAccess.Source.dstReportTableAdapters.spr_src_Field_cht_SelectTableAdapter();
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
                if (rdbOwnership.Checked)
                    intAction = 1;
                else if (rdbFieldUseType.Checked)
                    intAction = 2;
                else if (rdbTexture.Checked)
                    intAction = 3;
                else if (rdbProvince.Checked)
                    intAction = 4;
                else if (rdbTownship.Checked)
                    intAction = 5;
                else if (rdbCity.Checked)
                    intAction = 6;
                else if (rdbSalability.Checked)
                    intAction = 7;
                else if (rdbChangeUse.Checked)
                    intAction = 8;
                else if (rdbOpposition.Checked)
                    intAction = 9;


                //chtChart.Data = null;
                chtChart.DataMember = string.Empty;
                chtChart.DataSource = null;
                //chtChart.DataBindings.Clear();

                BaranDataAccess.Source.dstReport dst =
                    new BaranDataAccess.Source.dstReport();

                chtChart.DataSource = dst;
                chtChart.DataMember = "spr_src_Field_cht_Select";

                tbl.Clear();
                tbl = adp.GetFieldChartTable(intAction, intCompanyCategory, CurrentUser.Instance.UserID.ToString());

                if (tbl.Count >= 1)
                {
                    chtChart.Visible = true;
                    dst.spr_src_Field_cht_Select.Clear();
                    dst.spr_src_Field_cht_Select.Merge(tbl);
                }
                else
                    chtChart.Visible = false;
            }
            catch
            {
                this.lblMessage.Text = BaranResources.AccessibleItemsInsertionInDBError;
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
                if (chkCity.Checked)
                {
                    strSelectStatement += ",dbo.tbl_src_Field.City AS [شهر] ";
                    strGroupByClause += ",  dbo.tbl_src_Field.City ";
                }
                if (chkTownship.Checked)
                {
                    strSelectStatement += ", dbo.tbl_cmn_Township.TownshipName AS [شهرستان]";
                    strGroupByClause += ",  dbo.tbl_cmn_Township.TownshipName ";
                }
                if (chkProvince.Checked)
                {
                    strSelectStatement += ", dbo.tbl_cmn_Province.ProvinceName AS [استان]";
                    strGroupByClause += ",  dbo.tbl_cmn_Province.ProvinceName ";
                }
                if (chkChangeUse.Checked)
                {
                    strSelectStatement += ",  dbo.tbl_src_Field.changeUse AS [تغییر کاربری] ";
                    strGroupByClause += ",  dbo.tbl_src_Field.changeUse ";
                }
                if (chkSalability.Checked)
                {
                    strSelectStatement += ", dbo.tbl_src_Field.Salability AS [قابلیت فروش]";
                    strGroupByClause += ", dbo.tbl_src_Field.Salability ";
                }
                if (chkOpposition.Checked)
                {
                    strSelectStatement += ",  dbo.tbl_src_Field.Opposition AS [دارای معرض] ";
                    strGroupByClause += ",  dbo.tbl_src_Field.Opposition  ";
                }
                if (chkSoilTexture.Checked)
                {
                    strSelectStatement += ",   dbo.tbl_cmn_SoilTexture.NameFa AS [بافت خاک] ";
                    strGroupByClause += ",    dbo.tbl_cmn_SoilTexture.NameFa  ";
                }
                if (chkFieldUseType.Checked)
                {
                    strSelectStatement += ",dbo.tbl_src_FieldUseType.NameFa AS [نوع کاربری] ";
                    strGroupByClause += ", dbo.tbl_src_FieldUseType.NameFa ";
                }
                if (chkOwnership.Checked)
                {
                    strSelectStatement += ", dbo.tbl_cmn_Ownership.NameFa AS [نوع مالکیت] ";
                    strGroupByClause += ",  dbo.tbl_cmn_Ownership.NameFa ";
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
                if (chkOwnership.Checked)
                {
                    strOrderByClause += ",  dbo.tbl_cmn_Ownership.NameFa ";
                }
                if (chkFieldUseType.Checked)
                {
                    strOrderByClause += ", dbo.tbl_src_FieldUseType.NameFa ";
                }
                if (chkSoilTexture.Checked)
                {
                    strOrderByClause += ",    dbo.tbl_cmn_SoilTexture.NameFa  ";
                }
                if (chkProvince.Checked)
                {
                    strOrderByClause += ",    dbo.tbl_cmn_Province.ProvinceName  ";
                }
                if (chkTownship.Checked)
                {
                    strOrderByClause += ", dbo.tbl_cmn_Township.TownshipName  ";
                }
                if (chkCity.Checked)
                {
                    strOrderByClause += ", dbo.tbl_src_Field.City ";
                }
                if (chkChangeUse.Checked)
                {
                    strOrderByClause += ",  dbo.tbl_src_Field.changeUse ";
                }
                if (chkSalability.Checked)
                {
                    strOrderByClause += ", dbo.tbl_src_Field.Salability ";
                }
                if (chkOpposition.Checked)
                {
                    strOrderByClause += ",  dbo.tbl_src_Field.Opposition  ";
                }

                if (strOrderByClause != string.Empty)
                {
                    strOrderByClause = strOrderByClause.Remove(0, 1);
                    strOrderByClause = " ORDER BY " + strOrderByClause;
                }
            }
            catch { }
        }

        public override void OnExport(Windows.Forms.UltraGrid grdItem)
        {
            base.OnExport(this.grdItem);
        }

        #endregion

        #region Events

        private void cmbProvince_ValueChanged(object sender, EventArgs e)
        {
            cmbTownship.Value = null;
            ComboBoxSetting.FillComboBox(PublicEnum.EnmComboSource.srcTownship, cmbTownship, Convert.ToString(cmbProvince.Value));
        }

        #endregion

        private void grpSourceControls_Click(object sender, EventArgs e)
        {

        }

    }
}
