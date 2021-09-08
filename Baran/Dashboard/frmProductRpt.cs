using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Baran.Classes.Common;
using BaranDataAccess;
using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;

namespace Baran.Dashboard
{
    public partial class frmProductRpt : Baran.Base_Forms.frmChildBase
    {
        public frmProductRpt()
        {
            InitializeComponent();
            MainMap.Overlays.Add(routes);
            MainMap.Overlays.Add(markers);
        }

        internal readonly GMapOverlay routes = new GMapOverlay("routes");
        internal readonly GMapOverlay markers = new GMapOverlay("markers");

        public DateTime Date { get; set; }
        public int? FieldID { get; set; }
        public int? CropID { get; set; }

        public override void OnformLoad()
        {
            base.OnformLoad();

            ComboBoxSetting.FillComboBox(PublicEnum.EnmComboSource.srcFieldByUserID, cmbField);
            ComboBoxSetting.FillComboBox(PublicEnum.EnmComboSource.srcCrop, cmbCrop);
        }

        public override void OnActiveForm()
        {
            base.OnActiveForm();

            frmMain ofrm = frmMain.Instanc;
            ofrm.EnableToolBarItems(cnsToolStripButton.Confirm, cnsToolStripButton.Cancel, cnsToolStripButton.Clear, cnsToolStripButton.Export);
            ofrm.EnableMenuStripItems(cnsMenustripItems.Confirm, cnsMenustripItems.Cancel, cnsMenustripItems.Clear, cnsMenustripItems.Export);
        }

        public override void OnConfirm()
        {
            base.OnConfirm();

            if (!this.ControlsValidation())
            {
                OnMessage(BaranResources.FeildIsEmpty, PublicEnum.EnmMessageCategory.Warning);
                return;
            }

            

            DrowMap();
        }

        public override void OnClear()
        {
            base.OnClear();

            ControlsSetting.ClearControls(grpControls.Controls);
            CropID = null;
            FieldID = null;
            mskDate.Text  = CurrentDate.Instance.CurrentDateShamsi;
        }

        private void DrowMap()
        {
            markers.Markers.Clear();
            routes.Routes.Clear();

            SetVariables();

            BaranDataAccess.Dashboard.dstDashboardTableAdapters.spr_dsb_Product_lst_rptTableAdapter adp =
                new BaranDataAccess.Dashboard.dstDashboardTableAdapters.spr_dsb_Product_lst_rptTableAdapter();
            try
            {
                adp.FillProductLstTable(dstDashboard1.spr_dsb_Product_lst_rpt, CurrentUser.Instance.UserID, Date, FieldID, CropID);
                grdItem.FreeSpaceGenerator();
            }
            catch { }

            using (var dbContext = new AMSEntities())
            {
                var crops = dbContext.spr_dsb_Product_rpt(CurrentUser.Instance.UserID, Date,FieldID, CropID).ToArray();

                var lands =
                    from cust in crops
                    group cust by cust.LandLocation
                    into gcust
                    select gcust.First();

                foreach (var Land in lands)
                {
                    if (Land.LandLocation != null)
                    {
                        List<PointLatLng> points = new List<PointLatLng>();
                        points = GeoUtils.ConvertStringCoordinatesToGMapPolygony(Land.LandLocation.ProviderValue.ToString());

                        GMapRoute route = new GMapRoute(points, "hahahahaha");
                        {
                            route.Stroke = new Pen(Color.FromArgb(255, PublicVariables.LandColor));
                            route.Stroke.Width = PublicVariables.StrokeWidth;
                            route.Stroke.DashStyle = PublicVariables.StrokeDashStyle;
                        }
                        routes.Routes.Add(route);
                    }

                }

                foreach (var result in crops)
                {
                    if (result.FieldLocation != null)
                    {
                        List<PointLatLng> points = new List<PointLatLng>();
                        points = GeoUtils.ConvertStringCoordinatesToGMapPolygony(result.FieldLocation.ProviderValue.ToString());

                        GMapRoute route = new GMapRoute(points, "hahahahaha");
                        {
                            route.Stroke = new Pen(Color.FromArgb(255, PublicVariables.FieldColor));
                            route.Stroke.Width = PublicVariables.StrokeWidth;
                            route.Stroke.DashStyle = PublicVariables.StrokeDashStyle;
                        }

                        string strTooltip = $"کشت و صنعت: {result.Collection} " +
                            $"\n واحد: {result.Subcollection} " +
                            $"\n واحد فرعی: {result.Part}" +
                            $"\n نام : {result.Field} ";

                        Bitmap CropIcon;
                        if (result.Icon != null)
                            CropIcon = new Bitmap(PublicMethods.ArrayToImage(result.Icon));
                        else
                            CropIcon = new Bitmap(System.Drawing.Image.FromFile(PublicMethods.PictureFileNamePath(cnsPictureName.FieldMarker)));

                        GMapMarker mark = new GMarkerGoogle(points[points.Count / 2], CropIcon);
                        //PointLatLng pp = GeoUtils.FindCentroid(points);
                        //GMapMarker mark = new GMarkerGoogle(pp, new Bitmap(System.Drawing.Image.FromFile(PublicMethods.PictureFileNamePath(cnsPictureName.FieldMarker))));
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
                MainMap.ZoomAndCenterRoutes("routes");
            }
        }

        private void SetVariables()
        {
            if (!this.ControlsValidation())
            {
                OnMessage(BaranResources.FeildIsEmpty, PublicEnum.EnmMessageCategory.Warning);
                return;
            }

            try
            {
                if (mskDate.Text != null)
                    Date = DateTimeUtility.ToGregorian(mskDate.Value.ToString());

                if (cmbCrop.Value != null)
                    CropID = Convert.ToInt32( cmbCrop.Value);
                else
                    CropID = null;

                if (cmbField.Value != null)
                    FieldID = Convert.ToInt32(cmbField.Value);
                else
                    FieldID = null;
        
            }
            catch
            {
                OnMessage(BaranResources.DoNotDoPleaseTryAgine, PublicEnum.EnmMessageCategory.Warning);
            }
        }

        private bool ControlsValidation()
        {
            bool blnResult = true;

            if (mskDate.Value.ToString() == string.Empty)
            {
                mskDate.Focus();
                blnResult = false;
            }
            return blnResult;
        }
    }
}
