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

namespace Baran.Dashboard
{
    public partial class frmBaseCompanyInfoRpt : Baran.Base_Forms.frmChildBase
    {
        public frmBaseCompanyInfoRpt()
        {
            InitializeComponent();
        }

        BaranDataAccess.UnitOfWork dbContext;

        internal readonly GMapOverlay routes = new GMapOverlay("routes");
        internal readonly GMapOverlay polygons = new GMapOverlay("polygons");
        internal readonly GMapOverlay markers = new GMapOverlay("markers");

        Color partColor = Color.Red;
        Color LandColor = Color.Green;
        Color FieldColor = Color.GreenYellow;
        Color WarehouseColor = Color.BurlyWood;
        Color BuildingColor = Color.Brown;
        Color WaterColor = Color.SkyBlue;
        Color WaterstorageColor = Color.Blue;
        Color WaterTransmissionLineColor = Color.Black;

        System.Drawing.Drawing2D.DashStyle DashStyleLocation = System.Drawing.Drawing2D.DashStyle.Solid;
        int WidthLocation = 3;

        BaranDataAccess.Company.dstCompany.spr_src_Subcollection_SelectDataTable tblSubCollection =
            new BaranDataAccess.Company.dstCompany.spr_src_Subcollection_SelectDataTable();
        BaranDataAccess.Company.dstCompany.spr_src_Part_SelectDataTable tblPart =
            new BaranDataAccess.Company.dstCompany.spr_src_Part_SelectDataTable();

        string strWhereClause;

        private void grpControls_Click(object sender, EventArgs e)
        {

        }

        public override void OnformLoad()
        {
            base.OnformLoad();

            lblPartColor.Appearance.BackColor = partColor;
            lblLandColor.Appearance.BackColor = LandColor;
            lblFieldColor.Appearance.BackColor = FieldColor;
            lblWarehouseColor.Appearance.BackColor = WarehouseColor;
            lblBuildingColor.Appearance.BackColor = BuildingColor;
            lblWaterColor.Appearance.BackColor = WaterColor;
            lblWaterstorageColor.Appearance.BackColor = WaterstorageColor;
            lblWaterTrasmissionLineColor.Appearance.BackColor = WaterTransmissionLineColor;

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

        public override void OnConfirm()
        {
            base.OnConfirm();

            this.ClearMap();

            dbContext = new BaranDataAccess.UnitOfWork();

            List<PointLatLng> points = new List<PointLatLng>();

            if (chkBuilding.Checked)
            {
                try
                {
                    strWhereClause = string.Empty;
                    if (cmbCollection.Value != null)
                        strWhereClause += " AND dbo.tbl_src_Collection.CollectionID = " + cmbCollection.Value;
                    if (cmbSubcollection.Value != null)
                        strWhereClause += " AND dbo.tbl_src_Subcollection.SubCollectionID = " + cmbSubcollection.Value;
                    if (cmbPart.Value != null)
                        strWhereClause += " AND dbo.tbl_src_Part.PartID = " + cmbPart.Value;

                    using (BaranDataAccess.AMSEntities db = new BaranDataAccess.AMSEntities())
                    {


                    var buildings = db.spr_src_Buildings_Map_Select(2, strWhereClause, CurrentUser.Instance.UserID.ToString());
                        GMapOverlay buroutes = new GMapOverlay("routes");
                        GMapOverlay bupolygons = new GMapOverlay("polygons");
                        GMapOverlay bumarkers = new GMapOverlay("markers");
                        foreach (var building in buildings)
                        {
                            string strTooltip =
                                building.CollectionNmae
                                + "\n" + building.SubCollectionName
                                + "\n" + building.PartName
                                + "\n" + building.BuildingName
                                + "\n" + building.BuildingCategoryName
                                + "\n" + building.BuildingArea;

                            if (building.Location != null)
                            {
                                points = GeoUtils.ConvertStringCoordinatesToGMapPolygony(building.Location.ProviderValue.ToString());

                                GMapRoute rtBuildings = new GMapRoute(points, "hahahahaha");
                                {
                                    rtBuildings.Stroke.Color = BuildingColor;
                                    rtBuildings.Stroke.Width = WidthLocation;
                                    rtBuildings.Stroke.DashStyle = DashStyleLocation;
                                }

                                GMapMarker mark = new GMarkerGoogle(points[points.Count / 2], GMarkerGoogleType.red_dot);
                                mark.ToolTipText = strTooltip;
                                mark.ToolTip.Font = new System.Drawing.Font("B Nazanin", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
                                mark.ToolTip.Fill = Brushes.Black;
                                mark.ToolTip.Foreground = Brushes.White;
                                mark.ToolTip.Stroke = Pens.Black;
                                mark.ToolTip.TextPadding = new Size(20, 20);
                                mark.ToolTipMode = MarkerTooltipMode.OnMouseOver;

                    

                                bumarkers.Markers.Add(mark);
                                buroutes.Routes.Add(rtBuildings);


                            }
                        }
                        GMapOverlay Buildingsroutes = new GMapOverlay("Buildingsroutes");
                        MainMap.Overlays.Add(Buildingsroutes);

                    }

                }
                catch
                { }
            }
            if (chkLand.Checked)
            {
                try
                {
                    strWhereClause = string.Empty;
                    if (cmbCollection.Value != null)
                        strWhereClause += " AND dbo.tbl_src_Collection.CollectionID = " + cmbCollection.Value;
                    if (cmbSubcollection.Value != null)
                        strWhereClause += " AND dbo.tbl_src_Subcollection.SubCollectionID = " + cmbSubcollection.Value;
                    if (cmbPart.Value != null)
                        strWhereClause += " AND dbo.tbl_src_Part.PartID = " + cmbPart.Value;

                    //====================================================================================================
                    using (BaranDataAccess.AMSEntities db = new BaranDataAccess.AMSEntities())
                    {
                        var Lands = db.spr_src_Land_Map_Select(2, strWhereClause, CurrentUser.Instance.UserID.ToString());

                        foreach (var land in Lands)
                        {
                            string strTooltip =
                                land.PartName
                                + "\n" +
                                "اراضی :" + land.FieldName
                                + "\n" +
                                "مساحت کل:" + land.TotalArea
                                + "\n" +
                                "مساحت قابل استفاده::" + land.UsableArea
                                + "\n" +
                                "شماره سند:" + land.DocNumber;

                            if (land.Location != null)
                            {
                                points = GeoUtils.ConvertStringCoordinatesToGMapPolygony(land.Location.ProviderValue.ToString());

                                GMapRoute rt = new GMapRoute(points, "hahahahaha");
                                {
                                    rt.Stroke.Color = LandColor;
                                    rt.Stroke.Width = WidthLocation;
                                    rt.Stroke.DashStyle = DashStyleLocation;
                                }

                                GMapMarker mark = new GMarkerGoogle(points[points.Count / 2], GMarkerGoogleType.yellow);
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
                }
                catch { }

            }
            if (chkField.Checked)
            {
                string strWhere = "";
                //strWhere += $" AND (dbo.tbl_src_Field.Fk_LandID = {land.LandID} )";
                //if (cmbFieldUseType.Value != null)
                //    strWhere += $" AND (dbo.tbl_src_FieldUseType.FieldUseTypeID = {cmbFieldUseType.Value})";
                //if (cmbSoilTexture.Value != null)
                //    strWhere += $"  AND (dbo.tbl_cmn_SoilTexture.SoilTextureID = {cmbSoilTexture.Value})";
                using (BaranDataAccess.AMSEntities db = new BaranDataAccess.AMSEntities())
                {
                    var fields = db.spr_src_Field_Map_Select(2, strWhere, CurrentUser.Instance.UserID.ToString());

                    foreach (var field in fields)
                    {
                        string strFieldTooltip =
                            "نام قطعه:" + field.FieldName
                            + "\n" +
                            "مساحت کل:" + field.TotalArea
                            + "\n" +
                            "مساحت قابل استفاده::" + field.UsableArea
                            + "\n" +
                            "بافت خاک:" + field.SoilTexture
                            + "\n" +
                            "نوع کاربری:" + field.FieldUseType;


                        List<PointLatLng> Fieldpoints = new List<PointLatLng>();

                        if (field.LocationPolygon != null)
                        {
                            Fieldpoints = GeoUtils.ConvertStringCoordinatesToGMapPolygony(field.LocationPolygon.ProviderValue.ToString());

                            GMapRoute rtField = new GMapRoute(Fieldpoints, "hahahahaha");
                            {
                                rtField.Stroke.Color = FieldColor;
                                rtField.Stroke.Width = WidthLocation;
                                rtField.Stroke.DashStyle = DashStyleLocation;
                            }

                            GMapMarker markField = new GMarkerGoogle(Fieldpoints[Fieldpoints.Count / 2], GMarkerGoogleType.red_dot);
                            markField.ToolTipText = strFieldTooltip;
                            markField.ToolTip.Font = new System.Drawing.Font("B Nazanin", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
                            markField.ToolTip.Fill = Brushes.Black;
                            markField.ToolTip.Foreground = Brushes.White;
                            markField.ToolTip.Stroke = Pens.Black;
                            markField.ToolTip.TextPadding = new Size(20, 20);
                            markField.ToolTipMode = MarkerTooltipMode.OnMouseOver;

                            markers.Markers.Add(markField);
                            routes.Routes.Add(rtField);
                        }
                    }
                }
            }

            MainMap.Overlays.Add(routes);
            MainMap.Overlays.Add(markers);
            MainMap.ZoomAndCenterRoutes("routes");
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
    }
}
