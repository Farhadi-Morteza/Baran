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
using BaranDataAccess;
using System.Device.Location;
using System.Linq;

namespace Baran.Source
{
    public partial class frmFieldView : Baran.Base_Forms.frmViewBase
    {
        #region Constractor

        public frmFieldView(int fieldID)
        {
            InitializeComponent();
            FieldID = fieldID;
        }

        #endregion

        #region Variables
        Image[] myimg = new Image[10];
        BaranDataAccess.Common.dstCommon.spr_cmn_DocumentByFkID_SelectDataTable tblDoc =
            new BaranDataAccess.Common.dstCommon.spr_cmn_DocumentByFkID_SelectDataTable();
        #endregion

        #region Propertise
        private int _FieldID;
        public int FieldID
        {
            get
            {
                return _FieldID;
            }
            set
            {
                _FieldID = value;
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
            BaranDataAccess.Source.dstSource dst;
            BaranDataAccess.Source.dstSource.spr_src_Field_Vew_SelectRow rwField;

            try
            {
                dst = BaranDataAccess.Source.dstSource.FieldViewTable(FieldID);
                rwField = dst.spr_src_Field_Vew_Select[0];

                lblCollection.Text =  rwField.CollectionName;
                lblSubcollection.Text = rwField.SubcollectionName;
                lblPart.Text = rwField.PartName;
                lblLand.Text = rwField.LandName;
                lblFieldName.Text = rwField.IsFieldNameNull() ? string.Empty : rwField.FieldName;
                lblTotalArea.Text = rwField.IsTotalAreaNull() ? string.Empty : rwField.TotalArea.ToString();
                lblUsableArea.Text = rwField.IsUsableAreaNull() ? string.Empty : rwField.UsableArea.ToString();
                lblFieldUseType.Text = rwField.IsFieldUseTypeNull() ? string.Empty : rwField.FieldUseType;
                lblSoilTextre.Text = rwField.IsSoilTextreNull() ? string.Empty : rwField.SoilTextre;
                lblOwnership.Text = rwField.IsOwnershipNull() ? string.Empty : rwField.Ownership;
                lblCode.Text = rwField.IsCodeNull() ? string.Empty : rwField.Code;
                lblDocNumber.Text = rwField.IsDocNumberNull() ? string.Empty : rwField.DocNumber;
                lblFutureProgram.Text = rwField.IsFutureProgramNull() ? string.Empty : rwField.FutureProgram;
                lblOwnership.Text = rwField.IsAddressNull() ? string.Empty : rwField.Address;
                lblDescription.Text = rwField.IsDescriptionNull() ? string.Empty : rwField.Description;
                if (rwField.Opposition)
                    lblOpposition.Text = "دارد";
                else
                    lblOpposition.Text = "ندارد";
                if (rwField.Salability)
                    lblSalability.Text = "دارد";
                else
                    lblSalability.Text = "ندارد";
                if (rwField.changeUse)
                    lblchangeUse.Text = "دارد";
                else
                    lblchangeUse.Text = "ندارد";
                lblDocPlace.Text = rwField.IsDocPlaceNull() ? string.Empty : rwField.DocPlace;
                lblProvinceName.Text = rwField.IsProvinceNameNull() ? string.Empty : rwField.ProvinceName;
                lblTownshipName.Text = rwField.IsTownshipNameNull() ? string.Empty : rwField.TownshipName;
                lblCity.Text = rwField.IsCityNull() ? string.Empty : rwField.City;
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
                adpDoc.FillDocumentByFkIDTable(tblDoc, null, null, null, null,null, FieldID, null, null, null, null, null, null);
                if (tblDoc.Count > 0)
                {
                    foreach (var Doc in tblDoc)
                    {
                        imageListView1.Items.Add(Doc.DocumentID, Doc.Name, PublicMethods.ArrayToImage(Doc.Document));
                    }


                    //imageListView1.View = Manina.Windows.Forms.View.Thumbnails;
                    //System.Reflection.Assembly assembly = System.Reflection.Assembly.GetAssembly(typeof(Manina.Windows.Forms.ImageListView));
                    ////RendererItem item = (RendererItem)renderertoolStripComboBox.SelectedItem;
                    //Manina.Windows.Forms.ImageListView.ImageListViewRenderer renderer = assembly.CreateInstance("Manina.Windows.Forms.ImageListViewRenderers+ZoomingRenderer") as Manina.Windows.Forms.ImageListView.ImageListViewRenderer;
                    //imageListView1.SetRenderer(renderer);
                    ////imageListView1.Focus();
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
            tbl_src_Field  field = db.FieldRepository.GetById(FieldID);

            List<PointLatLng> Mypoints = new List<PointLatLng>();
            if (field.LocationPolygon != null)
            {
                Mypoints = GeoUtils.ConvertStringCoordinatesToGMapPolygony(field.LocationPolygon.ProviderValue.ToString());

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
                //============================================*****************************************
                BaranDataAccess.Map.dstLocation.spr_geo_LocationByID_SelectDataTable tblLocation =
                           new BaranDataAccess.Map.dstLocation.spr_geo_LocationByID_SelectDataTable();
                BaranDataAccess.Map.dstLocationTableAdapters.spr_geo_LocationByID_SelectTableAdapter adpLocation =
                    new BaranDataAccess.Map.dstLocationTableAdapters.spr_geo_LocationByID_SelectTableAdapter();

                List<PointLatLng> points = new List<PointLatLng>();

                try
                {
                    adpLocation.FillLocationByIDTable(tblLocation, FieldID, null, null, null, null, null, null);

                    if (tblLocation.Count > 0)
                    {
                        GMapOverlay routes = new GMapOverlay("routes");

                        foreach (var point in tblLocation)
                        {
                            points.Add(new PointLatLng(Convert.ToDouble(point.Latitude), Convert.ToDouble(point.Longitude)));

                        }
                        ////////////////////////////
                        GMapRoute rt = new GMapRoute(points, string.Empty);
                        //GMapPolygon rt = new GMapPolygon(points, string.Empty);
                        {
                            rt.Stroke = new Pen(Color.FromArgb(144, Color.Red));
                            rt.Stroke.Width = 5;
                            rt.Stroke.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDot;
                        }
                        routes.Routes.Add(rt);
                        //routes.Polygons.Add(rt);

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

        private void grpControls_Click(object sender, EventArgs e)
        {

        }

    }
}

