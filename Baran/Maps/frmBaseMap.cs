using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsForms.CustomMarkers;
using System.Data.Entity;
using System.Spatial;
using Baran.Classes.Common;
using BaranDataAccess;

namespace Baran.Maps
{
    public partial class frmBaseMap : Form
    {

        #region Constractor
        WaiteForm waiteLoad = new WaiteForm();
        public frmBaseMap(PublicEnum.EnmShapeType shapeType)
        {
            waiteLoad.Show();

            InitializeComponent();
                       
            btnClose.BackgroundImage = System.Drawing.Image.FromFile(PublicMethods.PictureFileNamePath(cnsPictureName.Close));
            btnMinimize.BackgroundImage = System.Drawing.Image.FromFile(PublicMethods.PictureFileNamePath(cnsPictureName.minimize));

            if (!GMapControl.IsDesignerHosted)
            {
                ShapeType = Convert.ToInt32( shapeType);

                // add your custom map db provider
                //GMap.NET.CacheProviders.MySQLPureImageCache ch = new GMap.NET.CacheProviders.MySQLPureImageCache();
                //ch.ConnectionString = @"server=sql2008;User Id=trolis;Persist Security Info=True;database=gmapnetcache;password=trolis;";
                //MainMap.Manager.SecondaryCache = ch;

                // set your proxy here if need
                //GMapProvider.IsSocksProxy = true;
                //GMapProvider.WebProxy = new WebProxy("127.0.0.1", 1080);
                //GMapProvider.WebProxy.Credentials = new NetworkCredential("ogrenci@bilgeadam.com", "bilgeada");
                // or
                //GMapProvider.WebProxy = WebRequest.DefaultWebProxy;
                //                          

                // set cache mode only if no internet avaible
                //if (!Stuff.PingNetwork("pingtest.com"))
                //{
                //MainMap.Manager.Mode = AccessMode.ServerAndCache;
                //MessageBox.Show("No internet connection available, going to CacheOnly mode.", "GMap.NET - Demo.WindowsForms", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //}

                //// config map         
                //MainMap.MapProvider = GMapProviders.BingSatelliteMap;
                ////MainMap.MapProvider = GMap.NET.MapProviders.GoogleSatelliteMapProvider.Instance;
                //GMaps.Instance.Mode = GMap.NET.AccessMode.ServerAndCache;
                //MainMap.CacheLocation = System.Windows.Forms.Application.StartupPath + @"\Map\";

                //MainMap.Position = new PointLatLng(32.843888, 51.967501);
                //MainMap.MinZoom = 1;
                //MainMap.MaxZoom = 18;
                //MainMap.Zoom = 5;

                //MainMap.ScaleMode = ScaleModes.Fractional;

                // map events
                {
                    MainMap.OnPositionChanged += new PositionChanged(MainMap_OnPositionChanged);

                    MainMap.OnMapZoomChanged += new MapZoomChanged(MainMap_OnMapZoomChanged);
                    MainMap.OnMapTypeChanged += new MapTypeChanged(MainMap_OnMapTypeChanged);

                    MainMap.OnMarkerClick += new MarkerClick(MainMap_OnMarkerClick);
                    MainMap.OnMarkerEnter += new MarkerEnter(MainMap_OnMarkerEnter);
                    MainMap.OnMarkerLeave += new MarkerLeave(MainMap_OnMarkerLeave);

                    MainMap.OnPolygonEnter += new PolygonEnter(MainMap_OnPolygonEnter);
                    MainMap.OnPolygonLeave += new PolygonLeave(MainMap_OnPolygonLeave);

                    MainMap.OnRouteEnter += new RouteEnter(MainMap_OnRouteEnter);
                    MainMap.OnRouteLeave += new RouteLeave(MainMap_OnRouteLeave);

                    //MainMap.Manager.OnTileCacheComplete += new TileCacheComplete(OnTileCacheComplete);
                    //MainMap.Manager.OnTileCacheStart += new TileCacheStart(OnTileCacheStart);
                    //MainMap.Manager.OnTileCacheProgress += new TileCacheProgress(OnTileCacheProgress);
                }

                MainMap.MouseMove += new MouseEventHandler(MainMap_MouseMove);
                MainMap.MouseDown += new MouseEventHandler(MainMap_MouseDown);
                MainMap.MouseUp += new MouseEventHandler(MainMap_MouseUp);
                MainMap.MouseDoubleClick += new MouseEventHandler(MainMap_MouseDoubleClick);

                // get position
                textBoxLat.Text = MainMap.Position.Lat.ToString(CultureInfo.InvariantCulture);
                textBoxLng.Text = MainMap.Position.Lng.ToString(CultureInfo.InvariantCulture);

                // get cache modes
                //checkBoxUseRouteCache.Checked = MainMap.Manager.UseRouteCache;

                // get zoom  
                trackBar1.Minimum = MainMap.MinZoom * 100;
                trackBar1.Maximum = MainMap.MaxZoom * 100;
                trackBar1.TickFrequency = 100;

                // add custom layers  
                {
                    MainMap.Overlays.Add(routes);
                    MainMap.Overlays.Add(polygons);
                    MainMap.Overlays.Add(objects);
                    MainMap.Overlays.Add(top);

                    //routes.Routes.CollectionChanged += new GMap.NET.ObjectModel.NotifyCollectionChangedEventHandler(Routes_CollectionChanged);
                    //objects.Markers.CollectionChanged += new GMap.NET.ObjectModel.NotifyCollectionChangedEventHandler(Markers_CollectionChanged);
                }

                // set current marker
                currentMarker = new GMarkerGoogle(MainMap.Position, GMarkerGoogleType.arrow);
                currentMarker.IsHitTestVisible = false;
                top.Markers.Add(currentMarker);
            }
        }

        private void MainMap_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.AddMarker();
        }
        //#endregion

        // layers
        readonly GMapOverlay top = new GMapOverlay();
        internal readonly GMapOverlay objects = new GMapOverlay("objects");
        internal readonly GMapOverlay routes = new GMapOverlay("routes");
        internal readonly GMapOverlay polygons = new GMapOverlay("polygons");
        GMapOverlay myroutes = new GMapOverlay("Myroutes");


        // marker
        GMapMarker currentMarker;

        // polygons
        GMapPolygon polygon;

        // Route
        GMapRoute route;

        // etc
        readonly Random rnd = new Random();
        //readonly DescendingComparer ComparerIpStatus = new DescendingComparer();
        GMapMarkerRect CurentRectMarker = null;
        string mobileGpsLog = string.Empty;
        bool isMouseDown = false;
        PointLatLng start;
        PointLatLng end;

        GMapMarker currentTransport;
        #endregion

        #region Propertise

        private int? _fieldID = null;
        public int? FieldID
        {
            get
            {
                return _fieldID;
            }
            set
            {
                _fieldID = value;
            }
        }

        private int? _landID = null;
        public int? LandID
        {
            get
            {
                return _landID;
            }
            set
            {
                _landID = value;
            }
        }

        private int? _buildingID = null;
        public int? BuildingID
        {
            get
            {
                return _buildingID;
            }
            set
            {
                _buildingID = value;
            }
        }

        private int? _WarehouseID = null;
        public int? WarehouseID
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

        private int? _waterStorrageID = null;
        public int? WaterstorageID
        {
            get
            {
                return _waterStorrageID;
            }
            set
            {
                _waterStorrageID = value;
            }
        }

        private int? _waterID = null;
        public int? WaterID
        {
            get
            {
                return _waterID;
            }
            set
            {
                _waterID = value;
            }
        }

        private int? _waterTransmissionLineID = null;
        public int? WaterTransmissionLineID
        {
            get
            {
                return _waterTransmissionLineID;
            }
            set
            {
                _waterTransmissionLineID = value;
            }
        }

        private int? _partID = null;
        public int? PartID
        {
            get
            {
                return _partID;
            }
            set
            {
                _partID = value;
            }
        }

        private int _shapeType;
        public int ShapeType
        {
            get
            {
                return _shapeType;
            }
            set
            {
                _shapeType = value;
            }
        }

        #endregion

        #region Variables

        tbl_src_Part part;
        tbl_src_Field field;
        tbl_src_Land land;
        tbl_src_Buildings building;
        tbl_src_Warehouse warehouse;
        tbl_src_Water water;
        tbl_src_WaterTransmissionLine waterTransmissionLine;
        tbl_src_WaterStorage waterStorage;


        #endregion

        #region Methods

        void RegeneratePolygon()
        {
            List<PointLatLng> polygonPoints = new List<PointLatLng>();

            foreach (GMapMarker m in objects.Markers)
            {
                if (m is GMapMarkerRect)
                {
                    m.Tag = polygonPoints.Count;
                    polygonPoints.Add(m.Position);
                }
            }

            if (polygon == null)
            {
                polygon = new GMapPolygon(polygonPoints, "polygon test");
                polygon.IsHitTestVisible = true;
                polygons.Polygons.Add(polygon);
            }
            else
            {
                polygon.Points.Clear();
                polygon.Points.AddRange(polygonPoints);

                if (polygons.Polygons.Count == 0)
                {
                    polygons.Polygons.Add(polygon);
                }
                else
                {
                    MainMap.UpdatePolygonLocalPosition(polygon);

                    polygon.Stroke = new Pen(Color.WhiteSmoke, 2);
                    polygon.Fill = new SolidBrush(Color.FromArgb(40, Color.WhiteSmoke));

                    
                }
            }
        }

        void RegenerateRout()
        {
            List<PointLatLng> RoutePoints = new List<PointLatLng>();

            foreach (GMapMarker m in objects.Markers)
            {
                if (m is GMapMarkerRect)
                {
                    m.Tag = RoutePoints.Count;
                    RoutePoints.Add(m.Position);
                }
            }

            if (route == null)
            {
                route = new GMapRoute(RoutePoints, "Route Test");
                route.IsHitTestVisible = true;
                routes.Routes.Add(route);
            }
            else
            {

                route.Points.Clear();
                route.Points.AddRange(RoutePoints);

                if(routes.Routes.Count == 0)
                {                    
                    routes.Routes.Add(route);
                }

                else
                {                  
                    MainMap.UpdateRouteLocalPosition(route);
                    route.Stroke = new Pen(Color.WhiteSmoke, 2);
                }
            }
        }

        void AddMarker()
        {
            GMarkerGoogle m = new GMarkerGoogle(currentMarker.Position, GMarkerGoogleType.yellow_pushpin);
            GMapMarkerRect mBorders = new GMapMarkerRect(currentMarker.Position);
            {
                mBorders.InnerMarker = m;
                if (polygon != null)
                {
                    mBorders.Tag = polygon.Points.Count;
                }
                mBorders.ToolTipMode = MarkerTooltipMode.OnMouseOver;
            }

            Placemark? p = null;

            //GeoCoderStatusCode status;
            //var ret = GMapProviders.GoogleMap.GetPlacemark(currentMarker.Position, out status);
            //if (status == GeoCoderStatusCode.G_GEO_SUCCESS && ret != null)
            //{
            //    p = ret;
            //}

            //if (p != null)
            //{
            //    mBorders.ToolTipText = p.Value.Address;
            //}
            //else
            //{
                mBorders.ToolTipText = currentMarker.Position.ToString();
            //}

            objects.Markers.Add(m);
            objects.Markers.Add(mBorders);

            if (ShapeType == (int)PublicEnum.EnmShapeType.Polygon)
                RegeneratePolygon();
            else if (ShapeType == (int)PublicEnum.EnmShapeType.Rout)
                RegenerateRout();
            
        }

        #endregion

        #region Events

        private void btnGoto_Click(object sender, EventArgs e)
        {
            try
            {
                double lat = Convert.ToDouble(textBoxLat.Text); // double.Parse(textBoxLat.Text, CultureInfo.InvariantCulture);
                double lng = Convert.ToDouble(textBoxLng.Text); // double.Parse(textBoxLng.Text, CultureInfo.InvariantCulture);

                currentMarker.Position = new PointLatLng(lat, lng);
                MainMap.Position = new PointLatLng(lat, lng);
            }
            catch (Exception ex)
            {
                MessageBox.Show("incorrect coordinate format: " + ex.Message);
            }
        }

        #endregion

        #region map events

        void MainMap_OnMarkerLeave(GMapMarker item)
        {
            if (item is GMapMarkerRect)
            {
                CurentRectMarker = null;

                GMapMarkerRect rc = item as GMapMarkerRect;
                rc.Pen.Color = Color.WhiteSmoke;

                Debug.WriteLine("OnMarkerLeave: " + item.Position);
            }
        }

        void MainMap_OnMarkerEnter(GMapMarker item)
        {
            if (item is GMapMarkerRect)
            {
                GMapMarkerRect rc = item as GMapMarkerRect;
                rc.Pen.Color = Color.Red;

                CurentRectMarker = rc;
            }
            Debug.WriteLine("OnMarkerEnter: " + item.Position);
        }

        GMapPolygon currentPolygon = null;
        void MainMap_OnPolygonLeave(GMapPolygon item)
        {
            currentPolygon = null;
            polygon.Stroke.Color = Color.WhiteSmoke;
            polygon.Fill = new SolidBrush(Color.FromArgb(40, Color.WhiteSmoke));
            Debug.WriteLine("OnPolygonLeave: " + item.Name);
        }

        void MainMap_OnPolygonEnter(GMapPolygon item)
        {
            currentPolygon = item;
            item.Stroke = new Pen(Color.Red, 2);
            item.Fill = new SolidBrush(Color.FromArgb(30, Color.Red));
            Debug.WriteLine("OnPolygonEnter: " + item.Name);
        }

        GMapRoute currentRoute = null;
        void MainMap_OnRouteLeave(GMapRoute item)
        {
            currentRoute = null;
            item.Stroke.Color = Color.WhiteSmoke;
            Debug.WriteLine("OnRouteLeave: " + item.Name);
        }

        void MainMap_OnRouteEnter(GMapRoute item)
        {
            currentRoute = item;
            item.Stroke.Color = Color.Red;
            Debug.WriteLine("OnRouteEnter: " + item.Name);
        }

        void MainMap_OnMapTypeChanged(GMapProvider type)
        {
            //comboBoxMapType.SelectedItem = type;

            trackBar1.Minimum = MainMap.MinZoom * 100;
            trackBar1.Maximum = MainMap.MaxZoom * 100;

            //if (radioButtonFlight.Checked)
            //{
            //    MainMap.ZoomAndCenterMarkers("objects");
            //}
        }

        void MainMap_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isMouseDown = false;
            }
        }

        void MainMap_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isMouseDown = true;

                if (currentMarker.IsVisible)
                {
                    currentMarker.Position = MainMap.FromLocalToLatLng(e.X, e.Y);

                    textBoxLat.Text = currentMarker.Position.Lat.ToString();
                    textBoxLng.Text = currentMarker.Position.Lng.ToString();

                    var px = MainMap.MapProvider.Projection.FromLatLngToPixel(currentMarker.Position.Lat, currentMarker.Position.Lng, (int)MainMap.Zoom);
                    var tile = MainMap.MapProvider.Projection.FromPixelToTileXY(px);

                    Debug.WriteLine("MouseDown: geo: " + currentMarker.Position + " | px: " + px + " | tile: " + tile);
                }
            }
        }

        // move current marker with left holding
        void MainMap_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && isMouseDown)
            {
                if (CurentRectMarker == null)
                {
                    if (currentMarker.IsVisible)
                    {
                        currentMarker.Position = MainMap.FromLocalToLatLng(e.X, e.Y);

                        textBoxLat.Text = currentMarker.Position.Lat.ToString();
                        textBoxLng.Text = currentMarker.Position.Lng.ToString();
                    }
                }
                else // move rect marker
                {
                    PointLatLng pnew = MainMap.FromLocalToLatLng(e.X, e.Y);

                    textBoxLat.Text = pnew.Lat.ToString();
                    textBoxLng.Text = pnew.Lng.ToString();

                    int? pIndex = (int?)CurentRectMarker.Tag;
                    if (pIndex.HasValue)
                    {
                        if (ShapeType == (int)PublicEnum.EnmShapeType.Polygon)
                        {
                            if (pIndex < polygon.Points.Count)
                            {
                                polygon.Points[pIndex.Value] = pnew;
                                MainMap.UpdatePolygonLocalPosition(polygon);
                            }
                        }
                        else if (ShapeType == (int)PublicEnum.EnmShapeType.Rout)
                        {
                            if (pIndex < route.Points.Count)
                            {
                                route.Points[pIndex.Value] = pnew;
                                MainMap.UpdateRouteLocalPosition(route);
                            }
                        }
                    }

                    if (currentMarker.IsVisible)
                    {
                        currentMarker.Position = pnew;
                        
                    }
                    CurentRectMarker.Position = pnew;

                    if (CurentRectMarker.InnerMarker != null)
                    {
                        CurentRectMarker.InnerMarker.Position = pnew;
                        CurentRectMarker.ToolTipText = currentMarker.Position.ToString();
                    }
                }

                MainMap.Refresh(); // force instant invalidation
            }
        }

        // MapZoomChanged
        void MainMap_OnMapZoomChanged()
        {
            trackBar1.Value = (int)(MainMap.Zoom * 100.0);
            textBoxZoomCurrent.Text = MainMap.Zoom.ToString();
        }

        // click on some marker
        void MainMap_OnMarkerClick(GMapMarker item, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                if (item is GMapMarkerRect)
                {
                //    int? pIndex = (int?)CurentRectMarker.Tag;
                //    GeoCoderStatusCode status;
                //    var pos = GMapProviders.GoogleMap.GetPlacemark(item.Position, out status);
                //    if (status == GeoCoderStatusCode.G_GEO_SUCCESS && pos != null)
                //    {
                //        GMapMarkerRect v = item as GMapMarkerRect;
                //        {
                //            v.ToolTipText = pos.Value.Address;
                //        }
                //        MainMap.Invalidate(false);
                //    }
                }
                else
                {
                    if (item.Tag != null)
                    {
                        //if (currentTransport != null)
                        //{
                        //    currentTransport.ToolTipMode = MarkerTooltipMode.OnMouseOver;
                        //    currentTransport = null;
                        //}
                        //currentTransport = item;
                        //currentTransport.ToolTipMode = MarkerTooltipMode.Always;
                    }
                }
            }
        }

        // loader end loading tiles
        void MainMap_OnTileLoadComplete(long ElapsedMilliseconds)
        {
            MainMap.ElapsedMilliseconds = ElapsedMilliseconds;

            MethodInvoker m = delegate()
            {
                //panelMenu.Text = "Menu, last load in " + MainMap.ElapsedMilliseconds + "ms";

                //textBoxMemory.Text = string.Format(CultureInfo.InvariantCulture, "{0:0.00} MB of {1:0.00} MB", MainMap.Manager.MemoryCache.Size, MainMap.Manager.MemoryCache.Capacity);
            };
            try
            {
                BeginInvoke(m);
            }
            catch
            {
            }
        }

        // current point changed
        void MainMap_OnPositionChanged(PointLatLng point)
        {
            //    textBoxLatCurrent.Text = point.Lat.ToString(CultureInfo.InvariantCulture);
            //    textBoxLngCurrent.Text = point.Lng.ToString(CultureInfo.InvariantCulture);

            //lock (flights)

            //{
            //    lastPosition = point;
            //    lastZoom = (int)MainMap.Zoom;
            //}
        }

        PointLatLng lastPosition;
        int lastZoom;

        // center markers on start
        private void frmBaseMap_Load(object sender, EventArgs e)
        {
            trackBar1.Value = (int)MainMap.Zoom * 100;
            Activate();
            TopMost = true;
            TopMost = false;

            int? fk_PartID = null;

            UnitOfWork db = new UnitOfWork();
            List<PointLatLng> points = new List<PointLatLng>();

            if (PartID > 0)
            {
                part = new tbl_src_Part();
                part = db.PartRepository.GetById(PartID);

                fk_PartID = part.PartID;

                if (part.Location != null)
                {
                    points = GeoUtils.ConvertStringCoordinatesToGMapPolygony(part.Location.ProviderValue.ToString());
                }
            }
            else if (FieldID > 0)
            {
                field = new tbl_src_Field();
                field = db.FieldRepository.GetById(FieldID);

                fk_PartID = field.Fk_partID;

                tbl_src_Land land = new tbl_src_Land();
                land = db.LandRepository.GetById(field.Fk_LandID);

                if (land != null)
                {

                    List<PointLatLng> Mypoints = new List<PointLatLng>();
                    if (land.Location != null)
                    {
                        Mypoints = GeoUtils.ConvertStringCoordinatesToGMapPolygony(land.Location.ProviderValue.ToString());

                        GMapRoute rt = new GMapRoute(Mypoints, string.Empty);
                        {
                            rt.Stroke = new Pen(Color.FromArgb(144, Color.White));
                            rt.Stroke.Width = 5;
                            rt.Stroke.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDot;                        
                       }
                        myroutes.Routes.Add(rt);
                        /////////////////////////////
                        //MainMap.Overlays.Clear();
                        MainMap.Overlays.Add(myroutes);
                        MainMap.ZoomAndCenterRoutes("Myroutes");
                    }
                }

                if (field.LocationPolygon != null)
                {
                    points = GeoUtils.ConvertStringCoordinatesToGMapPolygony(field.LocationPolygon.ProviderValue.ToString());
                }
            }
            else if (LandID > 0)
            {
                land = new tbl_src_Land();
                land = db.LandRepository.GetById(LandID);

                fk_PartID = land.Fk_partID;

                if (land.Location != null)
                {
                    points = GeoUtils.ConvertStringCoordinatesToGMapPolygony(land.Location.ProviderValue.ToString());
                }
            }
            else if (BuildingID > 0)
            {
                building = new tbl_src_Buildings();
                building = db.BuildingsRepository.GetById(BuildingID);

                fk_PartID = building.Fk_PartID;

                if (building.Location != null)
                {
                    points = GeoUtils.ConvertStringCoordinatesToGMapPolygony(building.Location.ProviderValue.ToString());
                }
            }
            else if (WarehouseID > 0)
            {
                warehouse = new tbl_src_Warehouse();
                warehouse = db.WarehouseRepository.GetById(WarehouseID);

                fk_PartID = warehouse.Fk_PartID;

                if (warehouse.Location != null)
                {
                    points = GeoUtils.ConvertStringCoordinatesToGMapPolygony(warehouse.Location.ProviderValue.ToString());
                }
            }
            else if (WaterID > 0)
            {
                water = new tbl_src_Water();
                water = db.WaterRepository.GetById(WaterID);

                fk_PartID = water.Fk_PartID;

                if (water.Location != null)
                {
                    points = GeoUtils.ConvertStringPointToGMapPoint(water.Location.ProviderValue.ToString());
                }
            }
            else if (WaterstorageID > 0)
            {
                waterStorage = new tbl_src_WaterStorage();
                waterStorage = db.WaterStorageRepository.GetById(WaterstorageID);

                fk_PartID = waterStorage.Fk_PartID;

                if (waterStorage.Location != null)
                {
                    points = GeoUtils.ConvertStringCoordinatesToGMapPolygony(waterStorage.Location.ProviderValue.ToString());
                }
            }
            else if (WaterTransmissionLineID > 0)
            {
                waterTransmissionLine = new tbl_src_WaterTransmissionLine();
                waterTransmissionLine = db.WaterTransmissionLineRepository.GetById(WaterTransmissionLineID);

                fk_PartID = waterTransmissionLine.Fk_PartID;

                if (waterTransmissionLine.Location != null)
                {
                    points = GeoUtils.ConvertStringCoordinatesToGMapRoute(waterTransmissionLine.Location.ProviderValue.ToString());
                }
            }

            if (fk_PartID != null)
            {
                tbl_src_Part partPolygon = new tbl_src_Part();
                partPolygon = db.PartRepository.GetById(fk_PartID);

                if (partPolygon != null)
                {

                    List<PointLatLng> Partpoints = new List<PointLatLng>();
                    if (partPolygon.Location != null)
                    {
                        Partpoints = GeoUtils.ConvertStringCoordinatesToGMapPolygony(partPolygon.Location.ProviderValue.ToString());

                        GMapRoute rt = new GMapRoute(Partpoints, string.Empty);
                        {
                            rt.Stroke = new Pen(Color.FromArgb(144, Color.Yellow));
                            rt.Stroke.Width = 4;
                            rt.Stroke.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
                        }
                        myroutes.Routes.Add(rt);
                        /////////////////////////////
                        //MainMap.Overlays.Clear();
                        MainMap.Overlays.Add(myroutes);
                        MainMap.ZoomAndCenterRoutes("Myroutes");
                    }
                }
            }

            if (points.Count == 0)
            {
                if (FieldID != null || BuildingID != null || WarehouseID != null || WaterstorageID != null || WaterID != null || WaterTransmissionLineID != null || PartID != null)
                {
                    BaranDataAccess.Map.dstLocation.spr_geo_LocationByID_SelectDataTable tblLocationByID =
                        new BaranDataAccess.Map.dstLocation.spr_geo_LocationByID_SelectDataTable();

                    tblLocationByID = BaranDataAccess.Map.dstLocation.LocationByIDTable(FieldID, BuildingID, WarehouseID, WaterstorageID, WaterID, WaterTransmissionLineID, PartID).spr_geo_LocationByID_Select;

                    //List<PointLatLng> points = new List<PointLatLng>();
                    foreach (var tbl in tblLocationByID)
                    {
                        currentMarker.Position = new PointLatLng(tbl.Latitude, tbl.Longitude);
                        this.AddMarker();
                    }
                }
            }


            foreach (var point in points)
            {
                currentMarker.Position = new PointLatLng(point.Lat, point.Lng);
                this.AddMarker();
            }
            MainMap.ZoomAndCenterMarkers("objects");

            waiteLoad.Close();
        }

        #endregion

        WaiteForm waite;

        private void buttonZoomUp_Click(object sender, EventArgs e)
        {
            MainMap.Zoom = ((int)MainMap.Zoom) + 1;
        }

        private void buttonZoomDown_Click(object sender, EventArgs e)
        {
            MainMap.Zoom = ((int)(MainMap.Zoom + 0.99)) - 1;
        }

        private void textBoxGeo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                //GeoCoderStatusCode status = MainMap.SetPositionByKeywords(textBoxGeo.Text);
                MainMap.SetPositionByKeywords(textBoxGeo.Text.Trim());
                //if (status != GeoCoderStatusCode.G_GEO_SUCCESS)
                //{
                //    MessageBox.Show("Geocoder can't find: '" + textBoxGeo.Text + "', reason: " + status.ToString(), "GMap.NET", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //}
            }
        }

        private void textBoxZoomCurrent_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                if (textBoxZoomCurrent.Text == string.Empty) return;
                MainMap.Zoom = Convert.ToInt16(textBoxZoomCurrent.Text);
            }
        }

        private void checkBoxCurrentMarker_CheckedChanged(object sender, EventArgs e)
        {
            currentMarker.IsVisible = checkBoxCurrentMarker.Checked;
        }

        private void checkBoxDebug_CheckedChanged(object sender, EventArgs e)
        {
            MainMap.ShowTileGridLines = checkBoxDebug.Checked;
        }

        private void checkBoxCanDrag_CheckedChanged(object sender, EventArgs e)
        {
            MainMap.CanDragMap = checkBoxCanDrag.Checked;
        }

        private void btnSaveView_Click(object sender, EventArgs e)
        {
            try
            {
                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.Filter = "PNG (*.png)|*.png";
                    sfd.FileName = "GMap.NET image";

                    Image tmpImage = MainMap.ToImage();
                    if (tmpImage != null)
                    {
                        using (tmpImage)
                        {
                            if (sfd.ShowDialog() == DialogResult.OK)
                            {
                                tmpImage.Save(sfd.FileName);

                                MessageBox.Show("Image saved: " + sfd.FileName, "GMap.NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Image failed to save: " + ex.Message, "GMap.NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGPX_Click(object sender, EventArgs e)
        {
            using (FileDialog dlg = new OpenFileDialog())
            {
                dlg.CheckPathExists = true;
                dlg.CheckFileExists = false;
                dlg.AddExtension = true;
                dlg.DefaultExt = "gpx";
                dlg.ValidateNames = true;
                dlg.Title = "GMap.NET: open gpx log";
                dlg.Filter = "gpx files (*.gpx)|*.gpx|All files (*.*)|*.*";
                dlg.FilterIndex = 1;
                dlg.RestoreDirectory = true;

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    try
                    {

                        string gpx = File.ReadAllText(dlg.FileName);

                        gpxType r = MainMap.Manager.DeserializeGPX(gpx);
                            if (r != null)
                            {
                                if (r.trk.Length > 0)
                                {
                                    foreach (var trk in r.trk)
                                    {
                                        List<PointLatLng> points = new List<PointLatLng>();

                                        foreach (var seg in trk.trkseg)
                                        {
                                            foreach (var p in seg.trkpt)
                                            {
                                                //points.Add(new PointLatLng((double)p.lat, (double)p.lon));
                                                currentMarker.Position = new PointLatLng((double)p.lat, (double)p.lon);
                                                this.AddMarker();
                                            }
                                        }

                                        //GMapRoute rt = new GMapRoute(points, string.Empty);
                                        //{
                                        //    rt.Stroke = new Pen(Color.FromArgb(144, Color.Red));
                                        //    rt.Stroke.Width = 5;
                                        //    rt.Stroke.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDot;
                                        //}
                                        //routes.Routes.Add(rt);
                                        //GMapPolygon ff = new GMapPolygon(points, "");
                                        //{ 
                                           
                                        //}
                                        
                                    }

                                    //MainMap.ZoomAndCenterRoutes(null);
                                    MainMap.ZoomAndCenterMarkers("objects");
                                }
                            }
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine("GPX import: " + ex.ToString());
                        MessageBox.Show("Error importing gpx: " + ex.Message, "GMap.NET", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void btnAddMarker_Click(object sender, EventArgs e)
        {
            this.AddMarker();
        }

        private void btnZoomCenter_Click(object sender, EventArgs e)
        {
            MainMap.ZoomAndCenterMarkers("objects");
        }

        private void btnCleaAll_Click(object sender, EventArgs e)
        {
            objects.Markers.Clear();
            polygons.Polygons.Clear();
            routes.Routes.Clear();           
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void frmBaseMap_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void MainMap_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (currentPolygon != null)
                {
                    polygons.Polygons.Remove(currentPolygon);
                    currentPolygon = null;
                }

                if (currentRoute != null)
                {
                    routes.Routes.Remove(currentRoute);
                    currentRoute = null;
                }

                if (CurentRectMarker != null)
                {
                    objects.Markers.Remove(CurentRectMarker);

                    if (CurentRectMarker.InnerMarker != null)
                    {
                        objects.Markers.Remove(CurentRectMarker.InnerMarker);
                    }
                    CurentRectMarker = null;

                    if (ShapeType == (int)PublicEnum.EnmShapeType.Polygon)
                        RegeneratePolygon();
                    else if (ShapeType == (int)PublicEnum.EnmShapeType.Rout)
                        RegenerateRout();
                }
            }
            else if (e.KeyCode == Keys.Escape)
            {
                MainMap.Bearing = 0;

                if (currentTransport != null && !MainMap.IsMouseOverMarker)
                {
                    currentTransport.ToolTipMode = MarkerTooltipMode.OnMouseOver;
                    currentTransport = null;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            BaranDataAccess.Map.dstLocation dst = new BaranDataAccess.Map.dstLocation();
            BaranDataAccess.Map.dstLocationTableAdapters.spr_geo_Location_SelectTableAdapter adp =
                new BaranDataAccess.Map.dstLocationTableAdapters.spr_geo_Location_SelectTableAdapter();

            DialogResult msgResult = MessageBoxX.ShowMessageBox(PublicEnum.EnmMessageType.msgSaveConfirm);
            if (msgResult == DialogResult.No) return;
            
            waite = new WaiteForm();
            try
            {
                
                waite.Show();
                adp.Delete(FieldID, BuildingID, WarehouseID, WaterstorageID, WaterID, WaterTransmissionLineID, PartID);

                List<PointLatLng> SavePoints = new List<PointLatLng>();
                if (ShapeType == (int)PublicEnum.EnmShapeType.Polygon)
                    SavePoints = polygon.Points;
                else if (ShapeType == (int)PublicEnum.EnmShapeType.Rout)
                    SavePoints = route.Points;
                else if (ShapeType == (int)PublicEnum.EnmShapeType.point)
                    SavePoints.Add(new PointLatLng((double)currentMarker.Position.Lat, (double)currentMarker.Position.Lng));

                UnitOfWork db = new UnitOfWork();

                if (PartID > 0)
                {
                    tbl_src_Part p = new tbl_src_Part();
                    p = db.PartRepository.GetById(PartID);
                    p.Location = GeoUtils.ConvertGMapPolygonPointsToDbGeometryPolygon(SavePoints);
                    db.PartRepository.Update(p);

                }
                else if (FieldID > 0)
                {
                    field.LocationPolygon = GeoUtils.ConvertGMapPolygonPointsToDbGeometryPolygon(SavePoints);
                    db.FieldRepository.Update(field);

                }
                else if (LandID > 0)
                {
                    land.Location = GeoUtils.ConvertGMapPolygonPointsToDbGeometryPolygon(SavePoints);
                    db.LandRepository.Update(land);
                }
                else if (BuildingID > 0)
                {
                    building.Location = GeoUtils.ConvertGMapPolygonPointsToDbGeometryPolygon(SavePoints);
                    db.BuildingsRepository.Update(building);

                }
                else if (WarehouseID > 0)
                {
                    warehouse.Location = GeoUtils.ConvertGMapPolygonPointsToDbGeometryPolygon(SavePoints);
                    db.WarehouseRepository.Update(warehouse);

                }

                else if (WaterstorageID > 0)
                {
                    waterStorage.Location = GeoUtils.ConvertGMapPolygonPointsToDbGeometryPolygon(SavePoints);
                    db.WaterStorageRepository.Update(waterStorage);

                }
                else if (WaterID > 0)
                {
                    water.Location = GeoUtils.ConvertGMapPointToDbGeometryPoint(SavePoints[0]);
                    db.WaterRepository.Update(water);

                }
                else if (WaterTransmissionLineID > 0)
                {
                    waterTransmissionLine.Location = GeoUtils.ConvertGMapLinePointsToDbGeometryLine(SavePoints);
                    db.WaterTransmissionLineRepository.Update(waterTransmissionLine);

                }

                else
                {
                    foreach (var poi in SavePoints)
                    {
                        adp.Insert(poi.Lng, poi.Lat, FieldID, BuildingID, WarehouseID, WaterstorageID, WaterID, WaterTransmissionLineID, PartID);

                    }
                }
                db.Save();
                waite.Close();
                MessageBoxX.ShowMessageBox(PublicEnum.EnmMessageType.msgSaveSuccessful);
            }
            catch 
            {
                MessageBoxX.ShowMessageBox(PublicEnum.EnmMessageType.msgSaveFail);
            }
            waite.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            GeoCoderStatusCode status = MainMap.SetPositionByKeywords(textBoxGeo.Text);
            MainMap.SetPositionByKeywords(textBoxGeo.Text.Trim());
            if (status != GeoCoderStatusCode.G_GEO_SUCCESS)
            {
                MessageBox.Show("Geocoder can't find: '" + textBoxGeo.Text + "', reason: " + status.ToString(), "GMap.NET", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RectLatLng area = MainMap.SelectedArea;
            if (!area.IsEmpty)
            {
                for (int i = (int)MainMap.Zoom; i <= MainMap.MaxZoom; i++)
                {
                    DialogResult res = MessageBox.Show("Ready ripp at Zoom = " + i + " ?", "GMap.NET", MessageBoxButtons.YesNoCancel);

                    if (res == DialogResult.Yes)
                    {
                        using (TilePrefetcher obj = new TilePrefetcher())
                        {
                            obj.Overlay =  objects; // set overlay if you want to see cache progress on the map

                            obj.Shuffle = MainMap.Manager.Mode != AccessMode.CacheOnly;

                            obj.Owner = this;
                            obj.ShowCompleteMessage = true;
                            obj.Start(area, i, MainMap.MapProvider, MainMap.Manager.Mode == AccessMode.CacheOnly ? 0 : 100, MainMap.Manager.Mode == AccessMode.CacheOnly ? 0 : 1);
                        }
                    }
                    else if (res == DialogResult.No)
                    {
                        continue;
                    }
                    else if (res == DialogResult.Cancel)
                    {
                        break;
                    }
                }
            }
            else
            {
                MessageBox.Show("Select map area holding ALT", "GMap.NET", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        //private void button2_Click(object sender, EventArgs e)
        //{



            //BaranDataAccess.Source.dstSource dst = new BaranDataAccess.Source.dstSource();
            ////dst.spr_src_FieldLocation_Select.Merge(BaranDataAccess.Source.dstSource.FieldLocationTable(CurrentUser.Instance.UserID).spr_src_FieldLocation_Select;
            //BaranDataAccess.Source.dstSourceTableAdapters.spr_src_FieldLocation_SelectTableAdapter adp =
            //    new BaranDataAccess.Source.dstSourceTableAdapters.spr_src_FieldLocation_SelectTableAdapter();

            //for (int mm = 0; mm <= polygon.Points.Count - 1; mm++)
            //{
            //    adp.Insert(polygon.Points[mm].Lng, polygon.Points[mm].Lat, 2);
            //}
            

            //System.Data.Spatial.DbGeography Location;
            //Location = null;
            //Location = System.Data.Spatial.DbGeography.FromText("POLYGON((-122.358 47.653, -122.348 47.649, -122.348 47.658, -122.358 47.658, -122.358 47.653))");
            //string dd = Location.StartPoint.Longitude.ToString();
            ////foreach(var mm in )
            //List<PointLatLng> poi = new List<PointLatLng>();
            //for (int pp = 1; pp < Location.PointCount; pp++)
            //{
            //    var pooo = Location.PointAt(pp);

            //    //points.Add(new PointLatLng((double)p.lat, (double)p.lon));
            //    poi.Add(new PointLatLng((double)pooo.Latitude, (double)pooo.Longitude));

            //}
            //GMapRoute rtt = new GMapRoute(poi, string.Empty);
            //{
            //    rtt.Stroke = new Pen(Color.FromArgb(144, Color.Red));
            //    rtt.Stroke.Width = 5;
            //    rtt.Stroke.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDot;
            //}
            //routes.Routes.Add(rtt);
        //}


    }
}