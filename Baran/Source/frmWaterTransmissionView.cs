using Baran.Classes.Common;
using BaranDataAccess;
using GMap.NET;
using GMap.NET.WindowsForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Baran.Source
{
    public partial class frmWaterTransmissionView : Baran.Base_Forms.frmViewBase
    {

        #region Constractor
        public frmWaterTransmissionView(int waterTransmissionLineID)
        {
            InitializeComponent();
            WaterTransmissionLineID = waterTransmissionLineID;
        }
        #endregion

        #region Variables
        BaranDataAccess.Common.dstCommon.spr_cmn_DocumentByFkID_SelectDataTable tblDoc =
            new BaranDataAccess.Common.dstCommon.spr_cmn_DocumentByFkID_SelectDataTable();
        #endregion

        #region Propertise
        private int _WaterTransmissionLineID = -1;
        public int WaterTransmissionLineID
        {
            get
            {
                return _WaterTransmissionLineID;
            }
            set
            {
                _WaterTransmissionLineID = value;
            }
        }
        #endregion

        #region Methods

        public override void OnformLoad()
        {
            base.OnformLoad();
            this.SetControlsValue();
            this.DrowMap();
            this.SetDocument();
        }

        private void SetControlsValue()
        {
            BaranDataAccess.Source.dstSource.spr_src_WaterTransmissionLine_Vew_SelectRow rw;

            try
            {
                rw = BaranDataAccess.Source.dstSource.WaterTransmissionLineViewTable(WaterTransmissionLineID).spr_src_WaterTransmissionLine_Vew_Select[0];

                lblCollection.Text = rw.IsCollectionNull() ? string.Empty : rw.Collection;
                lblSubcollection.Text = rw.IsSubcollectionNull() ? string.Empty : rw.Subcollection;
                lblPart.Text = rw.IspartNull() ? string.Empty : rw.part;
                lblName.Text = rw.IsNameNull() ? string.Empty : rw.Name;
                lblDescription.Text = rw.IsDescriptionNull() ? string.Empty : rw.Description;
                lblLength.Text = rw.IsLengthNull() ? string.Empty : rw.Length.ToString();
                lblDiameter.Text = rw.IsDiameterNull() ? string.Empty : rw.Diameter.ToString();
                lblWaterTransmissionType.Text = rw.IsWaterTransmissionTypeNull() ? string.Empty : rw.WaterTransmissionType;
            }
            catch
            { }
        }

        private void SetDocument()
        {
            BaranDataAccess.Common.dstCommonTableAdapters.spr_cmn_DocumentByFkID_SelectTableAdapter adpDoc =
                new BaranDataAccess.Common.dstCommonTableAdapters.spr_cmn_DocumentByFkID_SelectTableAdapter();


            imageListView1.BackColor = imageListView1.Parent.BackColor;
            try
            {
                adpDoc.FillDocumentByFkIDTable(tblDoc, null, null, null, null, null, null, null, null, null, null, WaterTransmissionLineID);
                if (tblDoc.Count > 0)
                {
                    foreach (var Doc in tblDoc)
                    {
                        imageListView1.Items.Add(Doc.DocumentID, Doc.Name, PublicMethods.ArrayToImage(Doc.Document));
                    }
                }
                else
                    grpDoc.Visible = false;
            }
            catch
            { }
        }

        private void DrowMap()
        {
            GMapOverlay myroutes = new GMapOverlay("routes");

            UnitOfWork db = new UnitOfWork();
            tbl_src_WaterTransmissionLine waterTransmissionLine = db.WaterTransmissionLineRepository.GetById(WaterTransmissionLineID);

            List<PointLatLng> Mypoints = new List<PointLatLng>();
            if (waterTransmissionLine.Location != null)
            {
                Mypoints = GeoUtils.ConvertStringCoordinatesToGMapPolygony(waterTransmissionLine.Location.ProviderValue.ToString());

                GMapRoute rt = new GMapRoute(Mypoints, string.Empty);
                {
                    rt.Stroke = new Pen(Color.FromArgb(144, Color.Red));
                    rt.Stroke.Width = 5;
                    rt.Stroke.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDot;
                }
                myroutes.Routes.Add(rt);
                ///////////////////////////
                MainMap.Overlays.Clear();
                MainMap.Overlays.Add(myroutes);
                MainMap.ZoomAndCenterRoutes("routes");
            }
            else
            {
                BaranDataAccess.Map.dstLocation.spr_geo_LocationByID_SelectDataTable tblLocation =
               new BaranDataAccess.Map.dstLocation.spr_geo_LocationByID_SelectDataTable();
                BaranDataAccess.Map.dstLocationTableAdapters.spr_geo_LocationByID_SelectTableAdapter adpLocation =
                    new BaranDataAccess.Map.dstLocationTableAdapters.spr_geo_LocationByID_SelectTableAdapter();

                List<GMap.NET.PointLatLng> points = new List<GMap.NET.PointLatLng>();

                try
                {
                    adpLocation.FillLocationByIDTable(tblLocation, null, null, null, null, null, WaterTransmissionLineID, null);

                    if (tblLocation.Count > 0)
                    {
                        GMap.NET.WindowsForms.GMapOverlay routes = new GMap.NET.WindowsForms.GMapOverlay("routes");
                        foreach (var point in tblLocation)
                        {
                            points.Add(new GMap.NET.PointLatLng(Convert.ToDouble(point.Latitude), Convert.ToDouble(point.Longitude)));

                        }
                        ////////////////////////////
                        GMap.NET.WindowsForms.GMapRoute rt = new GMap.NET.WindowsForms.GMapRoute(points, string.Empty);
                        {
                            rt.Stroke = new Pen(Color.FromArgb(144, Color.Red));
                            rt.Stroke.Width = 5;
                            rt.Stroke.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDot;
                        }
                        routes.Routes.Add(rt);

                        ///////////////////////////
                        MainMap.Overlays.Clear();
                        MainMap.Overlays.Add(routes);
                        MainMap.ZoomAndCenterRoutes("routes");

                    }
                }
                catch
                { }
            }
        }

        #endregion

        #region Events

        private void imageListView1_ItemClick(object sender, Manina.Windows.Forms.ItemClickEventArgs e)
        {
            Baran.Common.frmImageListView ofrm = new Common.frmImageListView(tblDoc);
            ofrm.WindowState = FormWindowState.Maximized;
            ofrm.ShowDialog();
        }

        #endregion
    }
}
