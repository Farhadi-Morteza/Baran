using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Baran.Classes.Common;
using BaranDataAccess;
using GMap.NET;
using GMap.NET.WindowsForms;


namespace Baran.Dashboard
{
    public partial class frmFieldTaskListRpt : Baran.Base_Forms.frmChildBase
    {
        public frmFieldTaskListRpt()
        {
            InitializeComponent();

            MainMap.Overlays.Add(routes);
            MainMap.Overlays.Add(markers);
        }

        internal readonly GMapOverlay routes = new GMapOverlay("routes");
        internal readonly GMapOverlay markers = new GMapOverlay("markers");

        private int? _fieldID = null;
        public int? FieldID
        {
            get
            {
                return _fieldID;
            } set
            {
                _fieldID = value;
            }
        }

        public override void OnformLoad()
        {
            base.OnformLoad();
            ComboBoxSetting.FillComboBox(PublicEnum.EnmComboSource.srcFieldByUserID, cmbField);
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
            dstDashboard1.spr_dsb_FieldTaskList_rpt_Select.Clear();
            if (FieldID != null)
                this.FillGrid();

            using (var dbContext = new AMSEntities())
            {
                var fields = dbContext.spr_src_FieldLocation_Rpt(null, null, null, FieldID, CurrentUser.Instance.UserID);

                foreach (var result in fields)
                {
                    if (result.Location != null)
                    {
                        List<PointLatLng> points = new List<PointLatLng>();
                        points = GeoUtils.ConvertStringCoordinatesToGMapPolygony(result.Location.ProviderValue.ToString());

                        GMapRoute route = new GMapRoute(points, "hahahahaha");
                        {
                            route.Stroke = new Pen(Color.FromArgb(255, PublicVariables.FieldColor));
                            route.Stroke.Width = PublicVariables.StrokeWidth;
                            route.Stroke.DashStyle = PublicVariables.StrokeDashStyle;
                        }

                        string strTooltip = $"کشت و صنعت: {result.CollectionName} " +
                            $"\n واحد: {result.SubcollectionName} " +
                            $"\n واحد فرعی: {result.PartName}" +
                            $"\n نام : {result.LandName} " +
                            $"\n  کد: {result.Code} " +
                            $"\n مساحت کل: {result.TotalArea} " +
                            $"\n مساحت قابل استفاده: {result.UsableArea} " +
                            $"\n بافت خاک : {result.SoilTexture} " +
                            $"\n نوع کاربری: {result.FieldUseType} ";

                        GMapMarker mark = new GMap.NET.WindowsForms.Markers.GMarkerGoogle(points[points.Count / 2], new Bitmap(System.Drawing.Image.FromFile(PublicMethods.PictureFileNamePath(cnsPictureName.FieldMarker))));
                        mark.ToolTipText = strTooltip;
                        mark.ToolTip.Font = new System.Drawing.Font("B Nazanin", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
                        mark.ToolTip.Fill = Brushes.Black;
                        mark.ToolTip.Foreground = Brushes.White;
                        mark.ToolTip.Stroke = Pens.Black;
                        mark.ToolTip.TextPadding = new Size(20, 20);
                        mark.ToolTipMode = MarkerTooltipMode.OnMouseOver;

                        mark.Tag = result.FieldID;

                        markers.Markers.Add(mark);
                        routes.Routes.Add(route);
                    }
                   
                }
                MainMap.ZoomAndCenterRoutes("routes");
            }
        }

        public override void OnClear()
        {
            base.OnClear();
            Baran.Classes.Common.ControlsSetting.ClearControls(grpControls.Controls);
            this.ClearMap();
            dstDashboard1.spr_dsb_FieldTaskList_rpt_Select.Clear();
            FieldID = null;
        }

        private void ClearMap()
        {
            try
            {
                routes.Routes.Clear();
                markers.Markers.Clear();
            }
            catch
            {

            }
        }

        private void cmbField_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                FieldID = Convert.ToInt32(cmbField.Value);
            }
            catch 
            {
                FieldID = null;
            }
        }

        private void MainMap_OnMarkerClick(GMapMarker item, MouseEventArgs e)
        {
            if (FieldID == Convert.ToInt32(item.Tag))
                return;
            FieldID = Convert.ToInt32( item.Tag);
            cmbField.Value = FieldID;
            this.FillGrid();
        }

        private void FillGrid()
        {
            if (FieldID is null)
                return;

            BaranDataAccess.Dashboard.dstDashboardTableAdapters.spr_dsb_FieldTaskList_rpt_SelectTableAdapter adp =
                new BaranDataAccess.Dashboard.dstDashboardTableAdapters.spr_dsb_FieldTaskList_rpt_SelectTableAdapter();
            try
            {
                adp.FillFieldTaskListTable(dstDashboard1.spr_dsb_FieldTaskList_rpt_Select, FieldID);
                this.grdItem.FreeSpaceGenerator();
            }
            catch { }
        }

    }
}
