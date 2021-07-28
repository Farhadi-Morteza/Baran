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
    public partial class frmWaterView : Baran.Base_Forms.frmViewBase
    {
        #region Constractor
        public frmWaterView(int waterID)
        {
            InitializeComponent();
            WaterID = waterID;
        }

        #endregion

        #region Variables
        BaranDataAccess.Common.dstCommon.spr_cmn_DocumentByFkID_SelectDataTable tblDoc =
            new BaranDataAccess.Common.dstCommon.spr_cmn_DocumentByFkID_SelectDataTable();
        #endregion

        #region Propertise

        private int _WaterID;
        public int WaterID
        {
            get
            {
                return _WaterID;
            }
            set
            {
                _WaterID = value;
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
            BaranDataAccess.Source.dstSource.spr_src_Water_Vew_SelectRow rwWater;
            try
            {
                rwWater = BaranDataAccess.Source.dstSource.WaterViewTable(WaterID).spr_src_Water_Vew_Select[0];

                lblCollection.Text = rwWater.IsCollectionNull() ? string.Empty : rwWater.Collection;
                lblSubcollection.Text = rwWater.IsSubcollectionNull() ? string.Empty : rwWater.Subcollection;
                lblPart.Text = rwWater.IsPartNull() ? string.Empty : rwWater.Part;
                lblName.Text = rwWater.IsNameNull() ? string.Empty : rwWater.Name;
                lblWaterSourceType.Text = rwWater.IsWaterSourceTypeNull() ? string.Empty : rwWater.WaterSourceType;
                lblWaterOutput.Text = rwWater.IsWaterOutputNull() ? string.Empty : rwWater.WaterOutput.ToString();
                lblDescription.Text = rwWater.IsDescriptionNull() ? string.Empty : rwWater.Description;
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
                adpDoc.FillDocumentByFkIDTable(tblDoc, null, null, null, null, null, null, null, null, WaterID, null, null);
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
            tbl_src_Water water = db.WaterRepository.GetById(WaterID);

            List<PointLatLng> Mypoints = new List<PointLatLng>();
            if (water.Location != null)
            {
                GMap.NET.WindowsForms.GMapOverlay markers = new GMap.NET.WindowsForms.GMapOverlay("markers");
                Mypoints = GeoUtils.ConvertStringCoordinatesToGMapPolygony(water.Location.ProviderValue.ToString());

                GMap.NET.WindowsForms.GMapMarker mark = new GMap.NET.WindowsForms.Markers.GMarkerGoogle(Mypoints[0], GMap.NET.WindowsForms.Markers.GMarkerGoogleType.red_dot);

                markers.Markers.Add(mark);
                ///////////////////////////
                MainMap.Position = Mypoints[0];// new PointLatLng(32.843888, 51.967501);
                MainMap.Zoom = 17;

                MainMap.Overlays.Clear();
                MainMap.Overlays.Add(markers);



            }
            else
            {
                BaranDataAccess.Map.dstLocation.spr_geo_LocationByID_SelectDataTable tblLocation =
               new BaranDataAccess.Map.dstLocation.spr_geo_LocationByID_SelectDataTable();
                BaranDataAccess.Map.dstLocationTableAdapters.spr_geo_LocationByID_SelectTableAdapter adpLocation =
                    new BaranDataAccess.Map.dstLocationTableAdapters.spr_geo_LocationByID_SelectTableAdapter();

                GMap.NET.WindowsForms.GMapOverlay markers = new GMap.NET.WindowsForms.GMapOverlay("markers");

                try
                {
                    adpLocation.FillLocationByIDTable(tblLocation, null, null, null, null, WaterID, null, null);

                    if (tblLocation.Count > 0)
                    {
                        ////////////////////////////
                        GMap.NET.PointLatLng po = new GMap.NET.PointLatLng(Convert.ToDouble(tblLocation[0].Latitude), Convert.ToDouble(tblLocation[0].Longitude));
                        GMap.NET.WindowsForms.GMapMarker mark = new GMap.NET.WindowsForms.Markers.GMarkerGoogle(po, GMap.NET.WindowsForms.Markers.GMarkerGoogleType.red_dot);

                        markers.Markers.Add(mark);
                        ///////////////////////////
                        MainMap.Position = po;// new PointLatLng(32.843888, 51.967501);
                        MainMap.Zoom = 17;

                        MainMap.Overlays.Clear();
                        MainMap.Overlays.Add(markers);

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
