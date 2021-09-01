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
                    var parts = dbContext.spr_src_PartLocation_Rpt(collectionId, subcollectionId, partId);

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

                            GMapMarker markLand = new GMarkerGoogle(pointsLand[pointsLand.Count / 2],new Bitmap(System.Drawing.Image.FromFile(PublicMethods.PictureFileNamePath(cnsPictureName.PartMarker))));
                            markLand.ToolTipText = strTooltip;
                            markLand.ToolTip.Font = new System.Drawing.Font("B Nazanin", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
                            markLand.ToolTip.Fill = Brushes.Black;
                            markLand.ToolTip.Foreground = Brushes.White;
                            markLand.ToolTip.Stroke = Pens.Black;
                            markLand.ToolTip.TextPadding = new Size(20, 20);
                            markLand.ToolTipMode = MarkerTooltipMode.OnMouseOver;

                            markers.Markers.Add(markLand);
                            routes.Routes.Add(rtPart);
                        }
                    }
                }

                // Land =====================================================================================================
                if (chkLand.Checked)
                {
                    var results = dbContext.spr_src_LandLocation_Rpt(collectionId, subcollectionId, partId);

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

                            markers.Markers.Add(mark);
                            routes.Routes.Add(route);
                        }
                    }
                }
            // Field ====================================================================================================
            if (chkField.Checked)
            {
                var fields = dbContext.spr_src_FieldLocation_Rpt(collectionId, subcollectionId, partId, null);

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

                        markers.Markers.Add(mark);
                        routes.Routes.Add(route);
                    }
                }
            }
                // Waarehhouse ==============================================================================================
                if (chkWarehouse.Checked)
                {
                    var warehouses = dbContext.spr_src_WarehouseLocation_Rpt(collectionId, subcollectionId, partId);

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

                            markers.Markers.Add(mark);
                            routes.Routes.Add(route);
                        }
                    }
                }
                // Building =================================================================================================
                if (chkBuilding.Checked)
                {
                    var Buildings = dbContext.spr_src_BuildingsLocation_Rpt(collectionId, subcollectionId, partId);

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

                            markers.Markers.Add(mark);
                            routes.Routes.Add(route);
                        }
                    }
                }
                // Water ====================================================================================================
                if (chkWater.Checked)
                {
                    var Waters = dbContext.spr_src_WaterLocation_Rpt(collectionId, subcollectionId, partId);
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

                            markers.Markers.Add(mark);
                        }
                    }
                }
                // Water Storage ============================================================================================
                if (chkWaterStorage.Checked)
                {
                    var waterstorages = dbContext.spr_src_WaterStorageLocation_Rpt(collectionId, subcollectionId, partId);

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

                            markers.Markers.Add(mark);
                            routes.Routes.Add(route);
                        }
                    }
                }
                // Water Transmission Line ===================================================================================
                if (chkWaterTransmissionLine.Checked)
                {
                    var waterTransmissionLines = dbContext.spr_src_WaterTransmissionLineLocation_Rpt(collectionId, subcollectionId, partId);

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

                            markers.Markers.Add(mark);
                            routes.Routes.Add(route);
                        }
                    }

                }
                // Tree ======================================================================================================
                if (chkTree.Checked)
                {
                    var tree = dbContext.spr_src_TreeLocation_Rpt(collectionId, subcollectionId, partId);

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

                            markers.Markers.Add(mark);
                        }
                    }

                }

            }
            MainMap.ZoomAndCenterRoutes("routes");
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
    }
}
