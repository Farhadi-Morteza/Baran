using Baran.Classes.Common;
using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Baran.Source
{
    public partial class frmBuildingsView : Baran.Base_Forms.frmViewBase
    {

        #region Constractor
        public frmBuildingsView(int buildingID)
        {
            InitializeComponent();
            BuildingsID = buildingID;
        }

        #endregion

        #region Variables
        BaranDataAccess.Common.dstCommon.spr_cmn_DocumentByFkID_SelectDataTable tblDoc =
            new BaranDataAccess.Common.dstCommon.spr_cmn_DocumentByFkID_SelectDataTable();
        #endregion

        #region Propertise

        private int _BuildingsID;
        public int BuildingsID
        {
            get
            {
                return _BuildingsID;
            }
            set
            {
                _BuildingsID = value;
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
            BaranDataAccess.Source.dstSource.spr_src_Buildings_Vew_SelectRow rwBuildings;
            try
            {
                rwBuildings = BaranDataAccess.Source.dstSource.BuildingsViewTable(BuildingsID).spr_src_Buildings_Vew_Select[0];

                lblCollection.Text = rwBuildings.IsCollectionNull() ? string.Empty : rwBuildings.Collection;
                lblSubCollection.Text = rwBuildings.Subcollection;
                lblName.Text = rwBuildings.IsBuildingsNameNull() ? string.Empty : rwBuildings.BuildingsName;
                lblBuildingsCategory.Text = rwBuildings.IsBuildingsCategoryNull() ? string.Empty : rwBuildings.BuildingsCategory;
                lblArea.Text = rwBuildings.IsAreaNull() ? string.Empty : rwBuildings.Area.ToString();
                lblDiscription.Text = rwBuildings.IsDescriptionNull() ? string.Empty : rwBuildings.Description;
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
                adpDoc.FillDocumentByFkIDTable(tblDoc, null, null, null, null, null, null, BuildingsID, null, null, null, null);
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
            BaranDataAccess.Map.dstLocation.spr_geo_LocationByID_SelectDataTable tblLocation =
               new BaranDataAccess.Map.dstLocation.spr_geo_LocationByID_SelectDataTable();
            BaranDataAccess.Map.dstLocationTableAdapters.spr_geo_LocationByID_SelectTableAdapter adpLocation =
                new BaranDataAccess.Map.dstLocationTableAdapters.spr_geo_LocationByID_SelectTableAdapter();

            List<PointLatLng> points = new List<PointLatLng>();

            try
            {
                adpLocation.FillLocationByIDTable(tblLocation, null, BuildingsID, null, null, null, null, null);

                if (tblLocation.Count > 0)
                {
                    GMapOverlay routes = new GMapOverlay("routes");
                    foreach (var point in tblLocation)
                    {
                        points.Add(new PointLatLng(Convert.ToDouble(point.Latitude), Convert.ToDouble(point.Longitude)));

                    }
                    ////////////////////////////
                    GMapRoute rt = new GMapRoute(points, string.Empty);
                    {
                        rt.Stroke = new Pen(Color.FromArgb(144, Color.Red));
                        rt.Stroke.Width = 5;
                        rt.Stroke.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDot;
                    }

                    GMapMarker mark = new GMarkerGoogle(points[points.Count / 2], GMarkerGoogleType.red_dot);
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

        #endregion

        #region Events

        private void gprControls_Click(object sender, EventArgs e)
        {

        }

        private void imageListView1_ItemDoubleClick(object sender, Manina.Windows.Forms.ItemClickEventArgs e)
        {
            Baran.Common.frmImageListView ofrm = new Common.frmImageListView(tblDoc);
            ofrm.WindowState = FormWindowState.Maximized;
            ofrm.ShowDialog();
        }
        #endregion

    }
}
