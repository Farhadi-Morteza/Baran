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
    public partial class frmWarehouseView : Baran.Base_Forms.frmViewBase
    {
        #region Constractor
        public frmWarehouseView(int warehouseID)
        {
            InitializeComponent();
            WarehouseID = warehouseID;
        }
        #endregion

        #region Variables
        BaranDataAccess.Common.dstCommon.spr_cmn_DocumentByFkID_SelectDataTable tblDoc =
            new BaranDataAccess.Common.dstCommon.spr_cmn_DocumentByFkID_SelectDataTable();
        #endregion

        #region Propertise
        private int _WarehouseID;
        public int WarehouseID
        {
            get
            {
                return _WarehouseID;
            }
            set
            {
                _WarehouseID = value;
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
            BaranDataAccess.Source.dstSource.spr_src_Warehouse_Vew_SelectRow rwWarehouse;

            try
            {
                rwWarehouse = BaranDataAccess.Source.dstSource.WarehouseViewTable(WarehouseID).spr_src_Warehouse_Vew_Select[0];

                lblCollection.Text = rwWarehouse.IsCollectionNull() ? string.Empty : rwWarehouse.Collection;
                lblSubcollection.Text = rwWarehouse.IsSubcollectionNull() ? string.Empty : rwWarehouse.Subcollection;
                lblPart.Text = rwWarehouse.IsPartNull() ? string.Empty : rwWarehouse.Part;
                lblName.Text = rwWarehouse.IsNameNull() ? string.Empty : rwWarehouse.Name;
                lblWarehouseType.Text = rwWarehouse.IsWarehouseTypeNull() ? string.Empty : rwWarehouse.WarehouseType;
                lblWarehouseUseType.Text = rwWarehouse.IsWarehouseUseTypeNull() ? string.Empty : rwWarehouse.WarehouseUseType;
                lblArea.Text = rwWarehouse.IsAreaNull() ? string.Empty : rwWarehouse.Area.ToString();
                lblVolume.Text = rwWarehouse.IsVolumeNull() ? string.Empty : rwWarehouse.Volume.ToString();
                lblWarehouseKeeper.Text = rwWarehouse.IsWarehouseKeeperNull() ? string.Empty : rwWarehouse.WarehouseKeeper;
                lblDescription.Text = rwWarehouse.IsDescriptionNull() ? string.Empty : rwWarehouse.Description;
                lblAddress.Text = rwWarehouse.IsAddressNull() ? string.Empty : rwWarehouse.Address;
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
                adpDoc.FillDocumentByFkIDTable(tblDoc, null, null, null, null,null, null, WarehouseID, null, null, null, null, null);
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
            tbl_src_Warehouse warehouse = db.WarehouseRepository.GetById(WarehouseID);

            List<PointLatLng> Mypoints = new List<PointLatLng>();
            if (warehouse.Location != null)
            {
                Mypoints = GeoUtils.ConvertStringCoordinatesToGMapPolygony(warehouse.Location.ProviderValue.ToString());

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

                List<PointLatLng> points = new List<PointLatLng>();

                try
                {
                    adpLocation.FillLocationByIDTable(tblLocation, null, null, WarehouseID, null, null, null, null);

                    if (tblLocation.Count > 0)
                    {
                        GMap.NET.WindowsForms.GMapOverlay routes = new GMap.NET.WindowsForms.GMapOverlay("routes");
                        foreach (var point in tblLocation)
                        {
                            points.Add(new PointLatLng(Convert.ToDouble(point.Latitude), Convert.ToDouble(point.Longitude)));

                        }
                        ////////////////////////////
                        GMap.NET.WindowsForms.GMapRoute rt = new GMap.NET.WindowsForms.GMapRoute(points, string.Empty);
                        {
                            rt.Stroke = new Pen(Color.FromArgb(144, Color.Red));
                            rt.Stroke.Width = 5;
                            rt.Stroke.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDot;
                        }

                        GMap.NET.WindowsForms.GMapMarker mark = new GMap.NET.WindowsForms.Markers.GMarkerGoogle(points[points.Count / 2], GMap.NET.WindowsForms.Markers.GMarkerGoogleType.red_dot);
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
