using Baran.Classes.Common;
using GMap.NET;
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
using BaranDataAccess;

namespace Baran.Dashboard
{
    public partial class frmBaseCompanyInfoRpt : Baran.Base_Forms.frmChildBase
    {
        public frmBaseCompanyInfoRpt()
        {
            InitializeComponent();

            MainMap.Overlays.Add(routes);
            MainMap.Overlays.Add(polygons);
            MainMap.Overlays.Add(markers);

        }

        internal readonly GMapOverlay routes = new GMapOverlay("routes");
        internal readonly GMapOverlay polygons = new GMapOverlay("polygons");
        internal readonly GMapOverlay markers = new GMapOverlay("markers");

        BaranDataAccess.Company.dstCompany.spr_src_Subcollection_SelectDataTable tblSubCollection =
            new BaranDataAccess.Company.dstCompany.spr_src_Subcollection_SelectDataTable();
        BaranDataAccess.Company.dstCompany.spr_src_Part_SelectDataTable tblPart =
            new BaranDataAccess.Company.dstCompany.spr_src_Part_SelectDataTable();

        public string MarkerTag { get; set; }

        private void grpControls_Click(object sender, EventArgs e)
        {

        }

        public override void OnformLoad()
        {
            base.OnformLoad();

            lblPartColor.Appearance.BackColor =  PublicVariables.partColor;
            lblLandColor.Appearance.BackColor = PublicVariables.LandColor;
            lblFieldColor.Appearance.BackColor = PublicVariables.FieldColor;
            lblWarehouseColor.Appearance.BackColor = PublicVariables.WarehouseColor;
            lblBuildingColor.Appearance.BackColor = PublicVariables.BuildingColor;
            lblWaterColor.Appearance.BackColor = PublicVariables.WaterColor;
            lblWaterstorageColor.Appearance.BackColor = PublicVariables.WaterstorageColor;
            lblWaterTrasmissionLineColor.Appearance.BackColor = PublicVariables.WaterTransmissionLineColor;
            lblTreeColor.Appearance.BackColor = PublicVariables.TreeColor;

            ComboBoxSetting.FillComboBox(PublicEnum.EnmComboSource.srcCollection, cmbCollection, "");
            ComboBoxSetting.FillComboBox(PublicEnum.EnmComboSource.srcSubcollection, cmbSubcollection, "");
            ComboBoxSetting.FillComboBox(PublicEnum.EnmComboSource.srcPart, cmbPart, "");

            tblSubCollection = (BaranDataAccess.Company.dstCompany.spr_src_Subcollection_SelectDataTable)cmbSubcollection.DataSource;
            tblPart = (BaranDataAccess.Company.dstCompany.spr_src_Part_SelectDataTable)cmbPart.DataSource;

            try
            {
                tlpMain.RowStyles[0].Height = 500;
                tlpMain.RowStyles[1].Height = 0;
                tlpMain.RowStyles[2].Height = 0;
                tlpMain.RowStyles[3].Height = 0;
            }
            catch { }
        }

        public override void OnActiveForm()
        {
            base.OnActiveForm();

            frmMain ofrm = frmMain.Instanc;
            ofrm.EnableToolBarItems(cnsToolStripButton.Confirm, cnsToolStripButton.Cancel, cnsToolStripButton.Clear);
            ofrm.EnableMenuStripItems(cnsMenustripItems.Confirm, cnsMenustripItems.Cancel, cnsMenustripItems.Clear);
        }

        public override void OnClear()
        {
            base.OnClear();
            Baran.Classes.Common.ControlsSetting.ClearControls(grpControls.Controls);

            cmbSubcollection.DataSource = tblSubCollection;
            cmbPart.DataSource = tblPart;

            this.ClearMap();
        }

        public override void OnConfirm()
        {
            base.OnConfirm();

            this.ClearMap();

            int? collectionId = null, subcollectionId = null, partId = null;
            collectionId = (int?)cmbCollection.Value;
            subcollectionId = (int?)cmbSubcollection.Value;
            partId = (int?)cmbPart.Value;

            // Part =====================================================================================================

            using (var dbContext = new AMSEntities())
            {
                if (chkPart.Checked)
                {
                    var parts = dbContext.spr_src_PartLocation_Rpt(collectionId, subcollectionId, partId, CurrentUser.Instance.UserID);

                    foreach (var part in parts)
                    {
                        if (part.Location != null)
                        {
                            List<PointLatLng> pointsLand = new List<PointLatLng>();
                            pointsLand = GeoUtils.ConvertStringCoordinatesToGMapPolygony(part.Location.ProviderValue.ToString());

                            GMapRoute rtPart = new GMapRoute(pointsLand, "hahahahaha");
                            {
                                rtPart.Stroke = new Pen(Color.FromArgb(255, PublicVariables.partColor));
                                rtPart.Stroke.Width = PublicVariables.StrokeWidth;
                                rtPart.Stroke.DashStyle = PublicVariables.StrokeDashStyle;
                            }

                            string strTooltip = $"کشت و صنعت: {part.CollectionName} " +
                                $"\n واحد: {part.SubCollectionName} " +
                                $"\n واحد فرعی: {part.PartName}" +
                                $"\n استان: {part.ProvinceName} \n شهرستان: {part.TownshipName}";

                            GMapMarker markPart = new GMarkerGoogle(pointsLand[pointsLand.Count / 2],new Bitmap(System.Drawing.Image.FromFile(PublicMethods.PictureFileNamePath(cnsPictureName.PartMarker))));
                            markPart.ToolTipText = strTooltip;
                            markPart.ToolTip.Font = new System.Drawing.Font("B Nazanin", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
                            markPart.ToolTip.Fill = Brushes.Black;
                            markPart.ToolTip.Foreground = Brushes.White;
                            markPart.ToolTip.Stroke = Pens.Black;
                            markPart.ToolTip.TextPadding = new Size(20, 20);
                            markPart.ToolTipMode = MarkerTooltipMode.OnMouseOver;
                            markPart.Tag = BaseInfoCoModels.Part + SpecialChar.SplitChar + part.PartID;

                            markers.Markers.Add(markPart);
                            routes.Routes.Add(rtPart);
                        }
                    }
                }

                // Land =====================================================================================================
                if (chkLand.Checked)
                {
                    var results = dbContext.spr_src_LandLocation_Rpt(collectionId, subcollectionId, partId, CurrentUser.Instance.UserID);

                    foreach (var result in results)
                    {
                        if (result.Location != null)
                        {
                            List<PointLatLng> points = new List<PointLatLng>();
                            points = GeoUtils.ConvertStringCoordinatesToGMapPolygony(result.Location.ProviderValue.ToString());

                            GMapRoute route = new GMapRoute(points, "hahahahaha");
                            {
                                route.Stroke = new Pen(Color.FromArgb(255, PublicVariables.LandColor));
                                route.Stroke.Width = PublicVariables.StrokeWidth;
                                route.Stroke.DashStyle = PublicVariables.StrokeDashStyle;
                            }

                            string strTooltip = $"کشت و صنعت: {result.CollectionName} " +
                                $"\n واحد: {result.SubcollectionName} " +
                                $"\n واحد فرعی: {result.PartName}" +
                                $"\n مساحت کل: {result.TotalArea} \n مساحت قابل استفاده: {result.UsableArea} \n استان: {result.ProvinceName} \n شهرستان: {result.TownshipName} ";

                            GMapMarker mark = new GMarkerGoogle(points[points.Count / 2], new Bitmap(System.Drawing.Image.FromFile(PublicMethods.PictureFileNamePath(cnsPictureName.LandMarker))));
                            mark.ToolTipText = strTooltip;
                            mark.ToolTip.Font = new System.Drawing.Font("B Nazanin", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
                            mark.ToolTip.Fill = Brushes.Black;
                            mark.ToolTip.Foreground = Brushes.White;
                            mark.ToolTip.Stroke = Pens.Black;
                            mark.ToolTip.TextPadding = new Size(20, 20);
                            mark.ToolTipMode = MarkerTooltipMode.OnMouseOver;
                            mark.Tag = BaseInfoCoModels.Land + SpecialChar.SplitChar + result.LandID;

                            markers.Markers.Add(mark);
                            routes.Routes.Add(route);
                        }
                    }
                }
            // Field ====================================================================================================
            if (chkField.Checked)
            {
                var fields = dbContext.spr_src_FieldLocation_Rpt(collectionId, subcollectionId, partId, null, CurrentUser.Instance.UserID);

                foreach (var result in fields)
                {
                    if (result.Location != null)
                    {
                        List<PointLatLng> points = new List<PointLatLng>();
                        points = GeoUtils.ConvertStringCoordinatesToGMapPolygony(result.Location.ProviderValue.ToString());

                        GMapRoute route = new GMapRoute(points, "hahahahaha");
                        {
                            route.Stroke = new Pen(Color.FromArgb(255, PublicVariables.FieldColor));
                            route.Stroke.Width = PublicVariables.StrokeWidth;
                            route.Stroke.DashStyle = PublicVariables.StrokeDashStyle;
                        }

                        string strTooltip = $"کشت و صنعت: {result.CollectionName} " +
                            $"\n واحد: {result.SubcollectionName} " +
                            $"\n واحد فرعی: {result.PartName}" +
                            $"\n نام : {result.LandName} " +
                            $"\n  کد: {result.Code} " +
                            $"\n مساحت کل: {result.TotalArea} " +
                            $"\n مساحت قابل استفاده: {result.UsableArea} " +
                            $"\n بافت خاک : {result.SoilTexture} " +
                            $"\n نوع کاربری: {result.FieldUseType} ";

                        GMapMarker mark = new GMarkerGoogle(points[points.Count / 2], new Bitmap(System.Drawing.Image.FromFile(PublicMethods.PictureFileNamePath(cnsPictureName.FieldMarker))));
                            mark.ToolTipText = strTooltip;
                            mark.ToolTip.Font = new System.Drawing.Font("B Nazanin", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
                            mark.ToolTip.Fill = Brushes.Black;
                            mark.ToolTip.Foreground = Brushes.White;
                            mark.ToolTip.Stroke = Pens.Black;
                            mark.ToolTip.TextPadding = new Size(20, 20);
                            mark.ToolTipMode = MarkerTooltipMode.OnMouseOver;
                            mark.Tag =  BaseInfoCoModels.Field + SpecialChar.SplitChar + result.FieldID;

                        markers.Markers.Add(mark);
                        routes.Routes.Add(route);
                    }
                }
            }
                // Waarehhouse ==============================================================================================
                if (chkWarehouse.Checked)
                {
                    var warehouses = dbContext.spr_src_WarehouseLocation_Rpt(collectionId, subcollectionId, partId, CurrentUser.Instance.UserID);

                    foreach (var result in warehouses)
                    {
                        if (result.Location != null)
                        {
                            List<PointLatLng> points = new List<PointLatLng>();
                            points = GeoUtils.ConvertStringCoordinatesToGMapPolygony(result.Location.ProviderValue.ToString());

                            GMapRoute route = new GMapRoute(points, "hahahahaha");
                            {
                                route.Stroke = new Pen(Color.FromArgb(255, PublicVariables.WarehouseColor));
                                route.Stroke.Width = PublicVariables.StrokeWidth;
                                route.Stroke.DashStyle = PublicVariables.StrokeDashStyle;
                            }

                            string strTooltip = $"کشت و صنعت: {result.CollectionName} " +
                                $"\n واحد: {result.SubcollectionName} " +
                                $"\n واحد فرعی: {result.PartName}" +
                                $"\n نام : {result.WarehouseName} " +
                                $"\n  نوع انبار: {result.WarehouseType} " +
                                $"\n نوع کاربری : {result.WarehouseUseType} " +
                                $"\n مساحت: {result.Area} ";

                            GMapMarker mark = new GMarkerGoogle(points[points.Count / 2], new Bitmap(System.Drawing.Image.FromFile(PublicMethods.PictureFileNamePath(cnsPictureName.WarehouseMarker))));
                            mark.ToolTipText = strTooltip;
                            mark.ToolTip.Font = new System.Drawing.Font("B Nazanin", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
                            mark.ToolTip.Fill = Brushes.Black;
                            mark.ToolTip.Foreground = Brushes.White;
                            mark.ToolTip.Stroke = Pens.Black;
                            mark.ToolTip.TextPadding = new Size(20, 20);
                            mark.ToolTipMode = MarkerTooltipMode.OnMouseOver;
                            mark.Tag = BaseInfoCoModels.Warehouser + SpecialChar.SplitChar + result.WarehouseID;

                            markers.Markers.Add(mark);
                            routes.Routes.Add(route);
                        }
                    }
                }
                // Building =================================================================================================
                if (chkBuilding.Checked)
                {
                    var Buildings = dbContext.spr_src_BuildingsLocation_Rpt(collectionId, subcollectionId, partId, CurrentUser.Instance.UserID);

                    foreach (var result in Buildings)
                    {
                        if (result.Location != null)
                        {
                            List<PointLatLng> points = new List<PointLatLng>();
                            points = GeoUtils.ConvertStringCoordinatesToGMapPolygony(result.Location.ProviderValue.ToString());

                            GMapRoute route = new GMapRoute(points, "hahahahaha");
                            {
                                route.Stroke = new Pen(Color.FromArgb(255, PublicVariables.BuildingColor));
                                route.Stroke.Width = PublicVariables.StrokeWidth;
                                route.Stroke.DashStyle = PublicVariables.StrokeDashStyle;
                            }

                            string strTooltip = $"کشت و صنعت: {result.CollectionName} " +
                                $"\n واحد: {result.SubcollectionName} " +
                                $"\n واحد فرعی: {result.PartName}" +
                                $"\n نام : {result.BuildingName} " +
                                $"\n نوع : {result.BuildingCategoryName} " +
                                $"\n مساحت: {result.Area} ";

                            GMapMarker mark = new GMarkerGoogle(points[points.Count / 2], new Bitmap(System.Drawing.Image.FromFile(PublicMethods.PictureFileNamePath(cnsPictureName.BuildingMarker))));
                            mark.ToolTipText = strTooltip;
                            mark.ToolTip.Font = new System.Drawing.Font("B Nazanin", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
                            mark.ToolTip.Fill = Brushes.Black;
                            mark.ToolTip.Foreground = Brushes.White;
                            mark.ToolTip.Stroke = Pens.Black;
                            mark.ToolTip.TextPadding = new Size(20, 20);
                            mark.ToolTipMode = MarkerTooltipMode.OnMouseOver;
                            mark.Tag = BaseInfoCoModels.Building + SpecialChar.SplitChar + result.BuildingsID;

                            markers.Markers.Add(mark);
                            routes.Routes.Add(route);
                        }
                    }
                }
                // Water ====================================================================================================
                if (chkWater.Checked)
                {
                    var Waters = dbContext.spr_src_WaterLocation_Rpt(collectionId, subcollectionId, partId, CurrentUser.Instance.UserID);
                    foreach (var result in Waters)
                    {
                        if (result.Location != null)
                        {
                            List<PointLatLng> points = new List<PointLatLng>();
                            points = GeoUtils.ConvertStringPointToGMapPoint(result.Location.ProviderValue.ToString());

                            string strTooltip = $"کشت و صنعت: {result.CollectionName} " +
                                $"\n واحد: {result.SubcollectionName} " +
                                $"\n واحد فرعی: {result.PartName}" +
                                $"\n نام : {result.WaterName} " +
                                $"\n خروجی آب لیتر بر ثانیه : {result.WaterOutput} " +
                                $"\n منبع تامین : {result.WaterSourceTypeName} ";

                            //GMapMarker mark = new GMarkerGoogle(points[points.Count / 2], GMarkerGoogleType.blue_dot);
                            GMapMarker mark = new GMarkerGoogle(points[points.Count / 2], new Bitmap(System.Drawing.Image.FromFile(PublicMethods.PictureFileNamePath(cnsPictureName.WaterMarker))));
                            mark.ToolTipText = strTooltip;
                            mark.ToolTip.Font = new System.Drawing.Font("B Nazanin", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
                            mark.ToolTip.Fill = Brushes.Black;
                            mark.ToolTip.Foreground = Brushes.White;
                            mark.ToolTip.Stroke = Pens.Black;
                            mark.ToolTip.TextPadding = new Size(20, 20);
                            mark.ToolTipMode = MarkerTooltipMode.OnMouseOver;
                            mark.Tag = BaseInfoCoModels.Water + SpecialChar.SplitChar + result.WaterID;

                            markers.Markers.Add(mark);
                        }
                    }
                }
                // Water Storage ============================================================================================
                if (chkWaterStorage.Checked)
                {
                    var waterstorages = dbContext.spr_src_WaterStorageLocation_Rpt(collectionId, subcollectionId, partId, CurrentUser.Instance.UserID);

                    foreach (var result in waterstorages)
                    {
                        if (result.Location != null)
                        {
                            List<PointLatLng> points = new List<PointLatLng>();
                            points = GeoUtils.ConvertStringCoordinatesToGMapPolygony(result.Location.ProviderValue.ToString());

                            GMapRoute route = new GMapRoute(points, "hahahahaha");
                            {
                                route.Stroke = new Pen(Color.FromArgb(255, PublicVariables.WaterstorageColor));
                                route.Stroke.Width = PublicVariables.StrokeWidth;
                                route.Stroke.DashStyle = PublicVariables.StrokeDashStyle;
                            }

                            string strTooltip = $"کشت و صنعت: {result.CollectionName} " +
                                $"\n واحد: {result.SubcollectionName} " +
                                $"\n واحد فرعی: {result.PartName}" +
                                $"\n نام : {result.WaterStorageName} " +
                                $"\n خروجی لیت بر ثانیه : {result.Output} " +
                                $"\n مساحت: {result.Area} ";

                            GMapMarker mark = new GMarkerGoogle(points[points.Count / 2], new Bitmap(System.Drawing.Image.FromFile(PublicMethods.PictureFileNamePath(cnsPictureName.WaterStorageMarker))));
                            mark.ToolTipText = strTooltip;
                            mark.ToolTip.Font = new System.Drawing.Font("B Nazanin", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
                            mark.ToolTip.Fill = Brushes.Black;
                            mark.ToolTip.Foreground = Brushes.White;
                            mark.ToolTip.Stroke = Pens.Black;
                            mark.ToolTip.TextPadding = new Size(20, 20);
                            mark.ToolTipMode = MarkerTooltipMode.OnMouseOver;
                            mark.Tag = BaseInfoCoModels.WaterStorage + SpecialChar.SplitChar + result.WaterStorageID;

                            markers.Markers.Add(mark);
                            routes.Routes.Add(route);
                        }
                    }
                }
                // Water Transmission Line ===================================================================================
                if (chkWaterTransmissionLine.Checked)
                {
                    var waterTransmissionLines = dbContext.spr_src_WaterTransmissionLineLocation_Rpt(collectionId, subcollectionId, partId, CurrentUser.Instance.UserID);

                    foreach (var result in waterTransmissionLines)
                    {
                        if (result.Location != null)
                        {
                            List<PointLatLng> points = new List<PointLatLng>();
                            points = GeoUtils.ConvertStringCoordinatesToGMapRoute(result.Location.ProviderValue.ToString());

                            GMapRoute route = new GMapRoute(points, "hahahahaha");
                            {
                                route.Stroke = new Pen(Color.FromArgb(255, PublicVariables.WaterTransmissionLineColor));
                                route.Stroke.Width = PublicVariables.StrokeWidth;
                                route.Stroke.DashStyle = PublicVariables.StrokeDashStyle;
                            }

                            string strTooltip = $"کشت و صنعت: {result.CollectionName} " +
                                $"\n واحد: {result.SubcollectionName} " +
                                $"\n واحد فرعی: {result.PartName}" +
                                $"\n نام : {result.WaterTransmissionLineName} " +
                                $"\n نوع : {result.WaterTransmissionTypeName} " +
                                $"\n طول-هکتار : {result.Length} ";

                            GMapMarker mark = new GMarkerGoogle(points[points.Count / 2], new Bitmap(System.Drawing.Image.FromFile(PublicMethods.PictureFileNamePath(cnsPictureName.WaterTransmissionLineMarker))));
                            mark.ToolTipText = strTooltip;
                            mark.ToolTip.Font = new System.Drawing.Font("B Nazanin", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
                            mark.ToolTip.Fill = Brushes.Black;
                            mark.ToolTip.Foreground = Brushes.White;
                            mark.ToolTip.Stroke = Pens.Black;
                            mark.ToolTip.TextPadding = new Size(20, 20);
                            mark.ToolTipMode = MarkerTooltipMode.OnMouseOver;
                            mark.Tag = BaseInfoCoModels.WaterTransmissionLine + SpecialChar.SplitChar + result.WaterTransmissionLineID;

                            markers.Markers.Add(mark);
                            routes.Routes.Add(route);
                        }
                    }

                }
                // Tree ======================================================================================================
                if (chkTree.Checked)
                {
                    var tree = dbContext.spr_src_TreeLocation_Rpt(collectionId, subcollectionId, partId, CurrentUser.Instance.UserID);

                    foreach (var result in tree)
                    {
                        if (result.Location != null)
                        {
                            List<PointLatLng> points = new List<PointLatLng>();
                            points = GeoUtils.ConvertStringPointToGMapPoint(result.Location.ProviderValue.ToString());

                            string strTooltip = $"کشت و صنعت: {result.CollectionName} " +
                                $"\n واحد: {result.SubcollectionName} " +
                                $"\n واحد فرعی: {result.PartName}" +
                                $"\n زمین : {result.FieldName} " +
                                $"\n سطر-ستون : {result.Row} - {result.Column} " +
                                $"\n رقم پایه : {result.BaseCultivar} " +
                                $"\n نوع پایه : {result.BaseType} ";

                            GMapMarker mark = new GMarkerGoogle(points[points.Count / 2], new Bitmap(System.Drawing.Image.FromFile(PublicMethods.PictureFileNamePath(cnsPictureName.TreeMarker))));
                            mark.ToolTipText = strTooltip;
                            mark.ToolTip.Font = new System.Drawing.Font("B Nazanin", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
                            mark.ToolTip.Fill = Brushes.Black;
                            mark.ToolTip.Foreground = Brushes.White;
                            mark.ToolTip.Stroke = Pens.Black;
                            mark.ToolTip.TextPadding = new Size(20, 20);
                            mark.ToolTipMode = MarkerTooltipMode.OnMouseOver;
                            //mark.Tag = BaseInfoCoModels.Tree + result.tree

                            markers.Markers.Add(mark);
                        }
                    }

                }

            }
            MainMap.ZoomAndCenterRoutes("routes");
            MainMap.ZoomAndCenterMarkers("markers");

            if (chkField.Checked)
            {
                tlpMain.RowStyles[1].Height = 350;
                FillFieldGrid();
            }
            else
                tlpMain.RowStyles[1].Height = 0;

            if (chkBuilding.Checked)
            {
                tlpMain.RowStyles[2].Height = 350;
                FillBuildingGrid();
            }
            else
                tlpMain.RowStyles[2].Height = 0;

            if (chkWarehouse.Checked)
            {
                tlpMain.RowStyles[3].Height = 350;
                FillWarehouseGrid();
            }
            else
                tlpMain.RowStyles[3].Height = 0;



        }

        private void ClearMap()
        {
            try
            {
                polygons.Polygons.Clear();
                routes.Routes.Clear();
                markers.Markers.Clear();

                //polygons.Clear();
                //routes.Clear();
                //markers.Clear();
                //MainMap.Overlays.Clear();
            }
            catch
            {

            }
        }

        private void FillFieldGrid()
        {
            this.SetFieldVariables();

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
                    grdItem.DisplayLayout.Bands[0].Columns[ColumnKey.New].Hidden = true;
                    grdItem.DisplayLayout.Bands[0].Columns[ColumnKey.Delete].Hidden = true;
                    grdItem.DisplayLayout.Bands[0].Columns[ColumnKey.Update].Hidden = true;
                    grdItem.DisplayLayout.Bands[0].Columns[ColumnKey.Detail].Hidden = true;

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


        string
            strWhereClause
            , strSelectStatement
            , strGroupByClause
            , strOrderByClause
            ;
        private void SetFieldVariables()
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
                if (cmbSubcollection.Value != null)
                {
                    strWhereClause += " AND tbl_src_Subcollection.SubCollectionID = " + cmbSubcollection.Value;
                    strSelectStatement += ", dbo.tbl_src_Subcollection.Name AS [واحد] ";
                    strGroupByClause += ", dbo.tbl_src_Subcollection.Name  ";
                }
                if (cmbCollection.Value != null)
                {
                    strWhereClause += " AND dbo.tbl_src_Collection.CollectionID = " + cmbCollection.Value;
                    strSelectStatement += ", dbo.tbl_src_Collection.Name AS [کشت و صنعت] ";
                    strGroupByClause += ", dbo.tbl_src_Collection.Name ";
                }

                strSelectStatement += ", dbo.tbl_src_Company.Name AS [شرکت] ";
                strGroupByClause += ", dbo.tbl_src_Company.Name ";

                //---------------------------------------------------------------------------------------------------

                strOrderByClause += ", dbo.tbl_src_Company.Name ";

                if (cmbCollection.Value != null)
                {
                    strOrderByClause += ", dbo.tbl_src_Collection.Name ";
                }
                if (cmbSubcollection.Value != null)
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

        private void FillBuildingGrid()
        {
            this.SetBuildingVariables();

            BaranDataAccess.Source.dstReport.spr_src_Buildings_Rpt_SelectDataTable tbl =
                new BaranDataAccess.Source.dstReport.spr_src_Buildings_Rpt_SelectDataTable();
            BaranDataAccess.Source.dstReportTableAdapters.spr_src_Buildings_Rpt_SelectTableAdapter adp =
                new BaranDataAccess.Source.dstReportTableAdapters.spr_src_Buildings_Rpt_SelectTableAdapter();

            try
            {
                grdBuilding.DataMember = null;
                grdBuilding.DataSource = null;
                grdBuilding.DataBindings.Clear();

                BaranDataAccess.Source.dstReport dst =
                    new BaranDataAccess.Source.dstReport();

                grdBuilding.DataSource = dst;
                grdBuilding.DataMember = "spr_src_Buildings_Rpt_Select";

                tbl = adp.GetBuildingRptTable(1, strWhereClause, strSelectStatement, strGroupByClause, strOrderByClause, CurrentUser.Instance.UserID.ToString());

                if (tbl.Count < 1)
                {
                    OnMessage(BaranResources.RecordNotFound, PublicEnum.EnmMessageCategory.Warning);
                }

                grdBuilding.ClearUndoHistory();

                dst.spr_src_Buildings_Rpt_Select.Merge(tbl);

                grdBuilding.DisplayLayout.Bands[0].Columns["RowID"].Header.VisiblePosition = grdBuilding.DisplayLayout.Bands[0].Columns.Count;
                grdBuilding.DisplayLayout.Bands[0].Columns["FreeSpace"].Header.VisiblePosition = 0;
                grdBuilding.DisplayLayout.Bands[0].Columns[ColumnKey.New].Hidden = true;
                grdBuilding.DisplayLayout.Bands[0].Columns[ColumnKey.Delete].Hidden = true;
                grdBuilding.DisplayLayout.Bands[0].Columns[ColumnKey.Update].Hidden = true;
                grdBuilding.DisplayLayout.Bands[0].Columns[ColumnKey.Detail].Hidden = true;

                Infragistics.Win.UltraWinGrid.UltraGridBand band = this.grdBuilding.DisplayLayout.Bands[0];

                // Add a summary.
                Infragistics.Win.UltraWinGrid.SummarySettings summary = band.Summaries.Add(Infragistics.Win.UltraWinGrid.SummaryType.Sum, band.Columns["متراژ کل"]);
                summary.SummaryPosition = Infragistics.Win.UltraWinGrid.SummaryPosition.Right;
                summary.DisplayFormat = " {0:###,##.##}";
                ///////////////////////////////////////////////////////////////////
                band.Override.BorderStyleSummaryValue = Infragistics.Win.UIElementBorderStyle.None;
                band.SummaryFooterCaption = "";

                grdBuilding.FreeSpaceGenerator();

            }
            catch
            {
            }
        }

        private void SetBuildingVariables()
        {
            strSelectStatement = string.Empty;
            strWhereClause = string.Empty;
            strGroupByClause = string.Empty;
            strOrderByClause = string.Empty;

            try
            {

                strSelectStatement += ", dbo.tbl_src_BuildingsCategory.Name AS [گروه] ";
                strGroupByClause += ",    dbo.tbl_src_BuildingsCategory.Name  ";
                
                if (chkPart.Checked)
                {
                    strSelectStatement += ",dbo.tbl_src_Part.Name AS [واحد فرعی] ";
                    strGroupByClause += ", dbo.tbl_src_Part.Name ";
                }
                if (cmbSubcollection.Value != null)
                {
                    strWhereClause += " AND tbl_src_Subcollection.SubCollectionID = " + cmbSubcollection.Value;
                    strSelectStatement += ", dbo.tbl_src_Subcollection.Name AS [واحد] ";
                    strGroupByClause += ", dbo.tbl_src_Subcollection.Name  ";
                }
                if (cmbCollection.Value != null)
                {
                    strWhereClause += " AND dbo.tbl_src_Collection.CollectionID = " + cmbCollection.Value;
                    strSelectStatement += ", dbo.tbl_src_Collection.Name AS [کشت و صنعت] ";
                    strGroupByClause += ", dbo.tbl_src_Collection.Name ";
                }

                    strSelectStatement += ", dbo.tbl_src_Company.Name AS [شرکت] ";
                    strGroupByClause += ", dbo.tbl_src_Company.Name ";
    

                //---------------------------------------------------------------------------------------------------


                strOrderByClause += ", dbo.tbl_src_Company.Name ";
                
                if (cmbCollection.Value != null)
                {
                    strOrderByClause += ", dbo.tbl_src_Collection.Name ";
                }
                if (cmbSubcollection.Value != null)
                {
                    strOrderByClause += ", dbo.tbl_src_Subcollection.Name  ";
                }
                if (cmbPart.Value != null)
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

        private void FillWarehouseGrid()
        {
            this.SetWarehouseVariables();

            BaranDataAccess.Source.dstReport.spr_src_WareHouse_Rpt_SelectDataTable tbl =
                new BaranDataAccess.Source.dstReport.spr_src_WareHouse_Rpt_SelectDataTable();
            BaranDataAccess.Source.dstReportTableAdapters.spr_src_WareHouse_Rpt_SelectTableAdapter adp =
                new BaranDataAccess.Source.dstReportTableAdapters.spr_src_WareHouse_Rpt_SelectTableAdapter();
            try
            {
                grdWarehouse.DataMember = null;
                grdWarehouse.DataSource = null;
                grdWarehouse.DataBindings.Clear();

                BaranDataAccess.Source.dstReport dst =
                    new BaranDataAccess.Source.dstReport();

                grdWarehouse.DataSource = dst;
                grdWarehouse.DataMember = "spr_src_WareHouse_Rpt_Select";

                tbl = adp.GetWarehouseRptTable(1, strWhereClause, strSelectStatement, strGroupByClause, strOrderByClause, CurrentUser.Instance.UserID.ToString());
                if (tbl.Count > 0)
                {
                    grdWarehouse.ClearUndoHistory();

                    dst.spr_src_WareHouse_Rpt_Select.Merge(tbl);

                    grdWarehouse.DisplayLayout.Bands[0].Columns["RowID"].Header.VisiblePosition = grdWarehouse.DisplayLayout.Bands[0].Columns.Count;
                    grdWarehouse.DisplayLayout.Bands[0].Columns["FreeSpace"].Header.VisiblePosition = 0;
                    grdWarehouse.DisplayLayout.Bands[0].Columns[ColumnKey.New].Hidden = true;
                    grdWarehouse.DisplayLayout.Bands[0].Columns[ColumnKey.Delete].Hidden = true;
                    grdWarehouse.DisplayLayout.Bands[0].Columns[ColumnKey.Update].Hidden = true;
                    grdWarehouse.DisplayLayout.Bands[0].Columns[ColumnKey.Detail].Hidden = true;

                    Infragistics.Win.UltraWinGrid.UltraGridBand band = this.grdWarehouse.DisplayLayout.Bands[0];

                    // Add a summary.
                    Infragistics.Win.UltraWinGrid.SummarySettings summary = band.Summaries.Add(Infragistics.Win.UltraWinGrid.SummaryType.Sum, band.Columns["متراژ کل"]);
                    summary.SummaryPosition = Infragistics.Win.UltraWinGrid.SummaryPosition.Right;
                    summary.DisplayFormat = " {0:###,##.##}";
                    ///////////////////////////////////////////////////////////////////
                    band.Override.BorderStyleSummaryValue = Infragistics.Win.UIElementBorderStyle.None;
                    band.SummaryFooterCaption = "";

                    grdWarehouse.FreeSpaceGenerator();
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

        private void SetWarehouseVariables()
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
                if (chkWarehouseUseType.Checked)
                {
                    strSelectStatement += ", dbo.tbl_src_WareHouseUseType.Name AS [نوع کاربری] ";
                    strGroupByClause += ",    dbo.tbl_src_WareHouseUseType.Name  ";
                }
                if (chkPart.Checked)
                {
                    strSelectStatement += ",dbo.tbl_src_Part.Name AS [واحد فرعی] ";
                    strGroupByClause += ", dbo.tbl_src_Part.Name ";
                }
                if (cmbSubcollection.Value != null)
                {
                    strWhereClause += " AND tbl_src_Subcollection.SubCollectionID = " + cmbSubcollection.Value;
                    strSelectStatement += ", dbo.tbl_src_Subcollection.Name AS [واحد] ";
                    strGroupByClause += ", dbo.tbl_src_Subcollection.Name  ";
                }
                if (cmbSubcollection.Value != null)
                {
                    strWhereClause += " AND dbo.tbl_src_Collection.CollectionID = " + cmbCollection.Value;
                    strSelectStatement += ", dbo.tbl_src_Collection.Name AS [کشت و صنعت] ";
                    strGroupByClause += ", dbo.tbl_src_Collection.Name ";
                }
               
                strSelectStatement += ", dbo.tbl_src_Company.Name AS [شرکت] ";
                strGroupByClause += ", dbo.tbl_src_Company.Name ";
               

                //---------------------------------------------------------------------------------------------------

               
                strOrderByClause += ", dbo.tbl_src_Company.Name ";
                
                if (cmbCollection.Value != null)
                {
                    strOrderByClause += ", dbo.tbl_src_Collection.Name ";
                }
                if (cmbSubcollection.Value != null)
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


        private void btnFieldShow_Click(object sender, EventArgs e)
        {
            FillFieldGrid();
        }

        private void btnWarehouseShow_Click(object sender, EventArgs e)
        {
            FillWarehouseGrid();
        }

        private void MainMap_MouseEnter(object sender, EventArgs e)
        {
            egbMainPanel.AutoScroll = false;
        }

        private void MainMap_MouseLeave(object sender, EventArgs e)
        {
            egbMainPanel.AutoScroll = true;
        }

        private void cmbCollection_ValueChanged(object sender, EventArgs e)
        {
            if (cmbCollection.Value == null)
                return;
            try
            {
                int id = Convert.ToInt32(cmbCollection.Value.ToString());
                var tbl = tblSubCollection.Where(s => s.Fk_CollectionID == id).ToArray();
                cmbSubcollection.DataSource = tbl;
            }
            catch { }
        }

        private void cmbSubcollection_ValueChanged(object sender, EventArgs e)
        {
            if (cmbSubcollection.Value == null)
                return;
            int id = Convert.ToInt32(cmbSubcollection.Value.ToString());
            var tbl = tblPart.Where(s => s.Fk_SubcollectionID == id).ToArray();
            cmbPart.DataSource = tbl;
        }

        private void MainMap_OnMarkerClick(GMapMarker item, MouseEventArgs e)
        {
            if (item.Tag == null)
                return;

            //if (MarkerTag == item.Tag.ToString())
            //    return;

            MarkerTag = item.Tag.ToString();
            string[] tag = item.Tag.ToString().Split(SpecialChar.SplitChar.ToCharArray());
            string Name = tag[0].Trim();
            int ID = Convert.ToInt32(tag[1]);

            switch (Name)
            {
                case  nameof(BaseInfoCoModels.Field):
                    Baran.Source.frmFieldView frmField = new Source.frmFieldView(ID);
                    frmField.ShowDialog();
                    break;

                case nameof(BaseInfoCoModels.Building):
                    Baran.Source.frmBuildingsView frmBuilding = new Source.frmBuildingsView(ID);
                    frmBuilding.ShowDialog();
                    break;

                case nameof(BaseInfoCoModels.Warehouser):
                    Baran.Source.frmWarehouseView frmWarehouse = new Source.frmWarehouseView(ID);
                    frmWarehouse.ShowDialog();
                    break;

                case nameof(BaseInfoCoModels.Water):
                    Baran.Source.frmWaterView frmWater = new Source.frmWaterView(ID);
                    frmWater.ShowDialog();
                    break;

                case nameof(BaseInfoCoModels.WaterStorage):
                    Baran.Source.frmWaterStorageView frmWaterStorage = new Source.frmWaterStorageView(ID);
                    frmWaterStorage.ShowDialog();
                    break;

                case nameof(BaseInfoCoModels.WaterTransmissionLine):
                    Baran.Source.frmWaterTransmissionView frmWaterTransmissionLine = new Source.frmWaterTransmissionView(ID);
                    frmWaterTransmissionLine.ShowDialog();
                    break;

                case nameof(BaseInfoCoModels.Machinery):
                    Baran.Source.frmMachineryView frmMachinery = new Source.frmMachineryView(ID);
                    frmMachinery.ShowDialog();
                    break;

            }
        }
    }
}
