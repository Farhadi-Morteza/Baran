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
    public partial class frmLandView : Baran.Base_Forms.frmViewBase
    {
        public frmLandView(int landID)
        {
            InitializeComponent();
            LandID = landID;
        }

        #region Variables
        Image[] myimg = new Image[10];
        BaranDataAccess.Common.dstCommon.spr_cmn_DocumentByFkID_SelectDataTable tblDoc =
            new BaranDataAccess.Common.dstCommon.spr_cmn_DocumentByFkID_SelectDataTable();
        #endregion

        #region Propertise
        private int _landID;
        public int LandID
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
              BaranDataAccess.Source.dstSource.spr_src_Land_Vew_SelectRow rwLand;
            BaranDataAccess.Source.dstSourceTableAdapters.spr_src_Land_Vew_SelectTableAdapter adpLand =
                new BaranDataAccess.Source.dstSourceTableAdapters.spr_src_Land_Vew_SelectTableAdapter();

            try
            {
                rwLand = adpLand.GetLandViewTable(LandID)[0];

                lblCollection.Text = rwLand.CollectionName;
                lblSubcollection.Text =  rwLand.SubcollectionName;
                lblPart.Text = rwLand.PartName;
                lblFieldName.Text = rwLand.IsFieldNameNull() ? string.Empty : rwLand.FieldName;
                lblTotalArea.Text = rwLand.IsTotalAreaNull() ? string.Empty : rwLand.TotalArea.ToString();
                lblUsableArea.Text = rwLand.IsUsableAreaNull() ? string.Empty : rwLand.UsableArea.ToString();
                lblFieldUseType.Text = rwLand.IsFieldUseTypeNull() ? string.Empty : rwLand.FieldUseType;
                lblSoilTextre.Text = rwLand.IsSoilTextreNull() ? string.Empty : rwLand.SoilTextre;
                lblOwnership.Text = rwLand.IsOwnershipNull() ? string.Empty : rwLand.Ownership;
                lblCode.Text = rwLand.IsCodeNull() ? string.Empty : rwLand.Code;
                lblDocNumber.Text = rwLand.IsDocNumberNull() ? string.Empty : rwLand.DocNumber;
                lblFutureProgram.Text = rwLand.IsFutureProgramNull() ? string.Empty : rwLand.FutureProgram;
                lblOwnership.Text = rwLand.IsAddressNull() ? string.Empty : rwLand.Address;
                lblDescription.Text = rwLand.IsDescriptionNull() ? string.Empty : rwLand.Description;
                if (rwLand.Opposition)
                    lblOpposition.Text = "دارد";
                else
                    lblOpposition.Text = "ندارد";
                if (rwLand.Salability)
                    lblSalability.Text = "دارد";
                else
                    lblSalability.Text = "ندارد";
                if (rwLand.changeUse)
                    lblchangeUse.Text = "دارد";
                else
                    lblchangeUse.Text = "ندارد";
                lblDocPlace.Text = rwLand.IsDocPlaceNull() ? string.Empty : rwLand.DocPlace;
                lblProvinceName.Text = rwLand.IsProvinceNameNull() ? string.Empty : rwLand.ProvinceName;
                lblTownshipName.Text = rwLand.IsTownshipNameNull() ? string.Empty : rwLand.TownshipName;
                lblCity.Text = rwLand.IsCityNull() ? string.Empty : rwLand.City;
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
                adpDoc.FillDocumentByFkIDTable(tblDoc, null, null, null, null, LandID,null, null, null, null, null, null, null);
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
            tbl_src_Land land = db.LandRepository.GetById(LandID);

            List<PointLatLng> Mypoints = new List<PointLatLng>();
            if (land.Location != null)
            {
                Mypoints = GeoUtils.ConvertStringCoordinatesToGMapPolygony(land.Location.ProviderValue.ToString());

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
