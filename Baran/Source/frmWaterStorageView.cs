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
    public partial class frmWaterStorageView : Baran.Base_Forms.frmViewBase
    {

        #region Constractor

        public frmWaterStorageView(int waterStorageID)
        {
            InitializeComponent();

            WaterStorageID = waterStorageID;
        }

        #endregion

        #region Variables
        BaranDataAccess.Common.dstCommon.spr_cmn_DocumentByFkID_SelectDataTable tblDoc =
            new BaranDataAccess.Common.dstCommon.spr_cmn_DocumentByFkID_SelectDataTable();
        #endregion

        #region Propertise

        private int _WaterStorageID = 0;
        public int WaterStorageID
        {
            get
            {
                return _WaterStorageID;
            }
            set
            {
                _WaterStorageID = value;
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
            BaranDataAccess.Source.dstSource.spr_src_WaterStorage_Vew_SelectRow rw;

            try
            {
                rw = BaranDataAccess.Source.dstSource.WaterStorageViewTable(WaterStorageID).spr_src_WaterStorage_Vew_Select[0];

                lblCollection.Text = rw.IsCollectionNull() ? string.Empty : rw.Collection;
                lblSubcollection.Text = rw.IsSubcollectionNull() ? string.Empty : rw.Subcollection;
                lblPart.Text = rw.IsPartNull() ? string.Empty : rw.Part;
                lblName.Text = rw.IsNameNull() ? string.Empty : rw.Name;
                lblDescription.Text = rw.IsDescriptionNull() ? string.Empty : rw.Description;
                lblArea.Text = rw.IsAreaNull() ? string.Empty : rw.Area.ToString();
                lblVolume.Text = rw.IsVolumeNull() ? string.Empty : rw.Volume.ToString();
                lblOutput.Text = rw.IsOutputNull() ? string.Empty : rw.Output.ToString();
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
                adpDoc.FillDocumentByFkIDTable(tblDoc, null, null, null, null, null,null, null, null, null, null, WaterStorageID, null);
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
            tbl_src_WaterStorage waterStorage = db.WaterStorageRepository.GetById(WaterStorageID);

            List<PointLatLng> Mypoints = new List<PointLatLng>();
            if (waterStorage.Location != null)
            {
                Mypoints = GeoUtils.ConvertStringCoordinatesToGMapPolygony(waterStorage.Location.ProviderValue.ToString());

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
                    adpLocation.FillLocationByIDTable(tblLocation, null, null, null, WaterStorageID, null, null, null);

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

        private void imageListView1_ItemDoubleClick(object sender, Manina.Windows.Forms.ItemClickEventArgs e)
        {
            Baran.Common.frmImageListView ofrm = new Common.frmImageListView(tblDoc);
            ofrm.WindowState = FormWindowState.Maximized;
            ofrm.ShowDialog();
        }

        #endregion

    }
}
