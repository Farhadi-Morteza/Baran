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
using GMap.NET.WindowsForms.Markers;
using WindowsForms.CustomMarkers;

namespace Baran.Producte
{
    public partial class frmTree : Baran.Base_Forms.frmSecondChildBase
    {

        #region Constractor

        public frmTree()
        {
            InitializeComponent();
            MainMap.Overlays.Add(markers);
            MainMap.Overlays.Add(routes);
        }

        public frmTree(int treeID)
        {
            InitializeComponent();
            MainMap.Overlays.Add(markers);
            MainMap.Overlays.Add(routes);

            TreeID = treeID;
            this.SetControlsValue();

        }

        #endregion

        #region Variables

        UnitOfWork db;

        BaranDataAccess.Product.dstProductTableAdapters.spr_src_Tree_SelectTableAdapter adp =
            new BaranDataAccess.Product.dstProductTableAdapters.spr_src_Tree_SelectTableAdapter();

        string
            strBaseCultivar,
            strBaseType,
            strScionCultivar,
            strSubInformation,
            strCantaminationHistory,
            strTreeYeild,
            strMainCultivar,
            strScionLocation,
            strBaseBuyLocation,
            strTransplantType
            ;

        double?
            dclLatitude ,
            dclLongitude 
            ;

        int
            intFieldID,
            intTreeType
            ;

        short
            intRow,
            intColumn
            ;

        DateTime
            datDatePlanting,
            datDateScion
            ;

        System.Data.Spatial.DbGeometry geoLocation ;

        //-------------------------------------------------------------------------------
        bool isMouseDown = false;
        GMapMarker currentMarker;

        internal readonly GMapOverlay markers = new GMapOverlay("markers");
        internal readonly GMapOverlay routes = new GMapOverlay("routes");
        //-------------------------------------------------------------------------------
        #endregion

        #region Propertise

        private int _treeID;
        public int TreeID
        {
            get
            {
                return _treeID;
            }
            set
            {
                _treeID = value;
            }

        }
        #endregion

        #region Methods

        public override void OnformLoad()
        {
            base.OnformLoad();

            ComboBoxSetting.FillComboBox(PublicEnum.EnmComboSource.srcTreeType, cmbTreeType);
            ComboBoxSetting.FillComboBox(PublicEnum.EnmComboSource.srcFieldByUserID, cmbField, CurrentUser.Instance.UserID.ToString());

            // set current marker
            currentMarker = new GMarkerGoogle(MainMap.Position, GMarkerGoogleType.arrow);
            currentMarker.IsHitTestVisible = false;

            markers.Markers.Add(currentMarker);

        }

        public override void OnSave()
        {
            base.OnSave();
            if (!this.ControlsValidation())
            {
                OnMessage(BaranResources.FeildIsEmpty, PublicEnum.EnmMessageCategory.Warning);
                return;
            }

            DialogResult msgResult = MessageBoxX.ShowMessageBox(PublicEnum.EnmMessageType.msgSaveConfirm);
            if (msgResult == DialogResult.No) return;

            try
            {
                this.SetVariables();

                db = new UnitOfWork();

                    tbl_src_Tree tree = new tbl_src_Tree()
                    {
                    Fk_FieldID = intFieldID,
                    Fk_TreeType = intTreeType,
                    BaseCultivar = strBaseCultivar,
                    BaseType = strBaseType,
                    ScionCultivar = strScionCultivar,
                    DatePlanting = datDatePlanting,
                    SubInformation = strSubInformation,
                    CantaminationHistory = strCantaminationHistory,
                    TreeYeild = strTreeYeild,
                    Row = intRow,
                    Column = intColumn,
                    MainCultivar = strMainCultivar,
                    ScionLocation = strScionLocation,
                    BaseBuyLocation = strBaseBuyLocation,
                    DateScion = datDateScion,
                    TransplantType = strTransplantType,
                    CreateUserID = CurrentUser.Instance.UserID,
                    IsActive = true,
                    CreateDate = System.DateTime.Now,
                    Latitude = dclLatitude,
                    Longitude = dclLongitude,
                    Location = geoLocation
                };

                db.TreeRepository.Insert(tree);
                db.Save();
                TreeID = tree.TreeID;

                //int rowAffected = Convert.ToInt32(adp.Insert(intFieldID, intTreeType, strBaseCultivar, strBaseType,strScionCultivar
                //                                            , datDatePlanting, strSubInformation, strCantaminationHistory, strTreeYeild, intRow
                //                                            , intColumn, strMainCultivar, strScionLocation, strBaseBuyLocation, datDateScion
                //                                            , strTransplantType,CurrentUser.Instance.UserID, dclLatitude, dclLongitude));

                //if (rowAffected > 0)
                //{
                    OnMessage(BaranResources.SaveSuccessful, PublicEnum.EnmMessageCategory.Success);
                //}
                //else
                //    OnMessage(BaranResources.SaveFail, PublicEnum.EnmMessageCategory.Warning);
            }
            catch
            {
                OnMessage(BaranResources.DoNotDoPleaseTryAgine, PublicEnum.EnmMessageCategory.Warning);
            }
        }

        public override void OnChange()
        {
            base.OnChange();
            if ( TreeID <= 0)
            {
                OnMessage(BaranResources.SavedNotLastTime, PublicEnum.EnmMessageCategory.Warning);
                return;
            }

            if (!this.ControlsValidation())
            {
                OnMessage(BaranResources.FeildIsEmpty, PublicEnum.EnmMessageCategory.Warning);
                return;
            }
            DialogResult msgResult = MessageBoxX.ShowMessageBox(PublicEnum.EnmMessageType.msgSaveConfirm);
            if (msgResult == DialogResult.No) return;

            try
            {
                this.SetVariables();
                db = new UnitOfWork();
                tbl_src_Tree tree = new tbl_src_Tree();
                tree = db.TreeRepository.GetById(TreeID);

                tree.Fk_FieldID = intFieldID;
                tree.Fk_TreeType = intTreeType;
                tree.BaseCultivar = strBaseCultivar;
                tree.BaseType = strBaseType;
                tree.ScionCultivar = strScionCultivar;
                tree.DatePlanting = datDatePlanting;
                tree.SubInformation = strSubInformation;
                tree.CantaminationHistory = strCantaminationHistory;
                tree.TreeYeild = strTreeYeild;
                tree.Row = intRow;
                tree.Column = intColumn;
                tree.MainCultivar = strMainCultivar;
                tree.ScionLocation = strScionLocation;
                tree.BaseBuyLocation = strBaseBuyLocation;
                tree.DateScion = datDateScion;
                tree.TransplantType = strTransplantType;
                tree.UpdateUserID = CurrentUser.Instance.UserID;
                tree.IsActive = true;
                tree.UpdateDate = System.DateTime.Now;
                tree.Latitude = dclLatitude;
                tree.Longitude = dclLongitude;
                tree.Location = geoLocation;

                db.TreeRepository.Update(tree);
                db.Save();

                //int RowAffected = Convert.ToInt32(adp.Update(TreeID, intFieldID, intTreeType, strBaseCultivar, strBaseType,
                //                                            strScionCultivar, datDatePlanting, strSubInformation, strCantaminationHistory,
                //                                            strTreeYeild, intRow, intColumn, strMainCultivar, strScionLocation, 
                //                                            strBaseBuyLocation, datDateScion, strTransplantType, CurrentUser.Instance.UserID, dclLatitude, dclLongitude));

                //if (RowAffected > 0)
                //{
                    OnMessage(BaranResources.EditSuccessful, PublicEnum.EnmMessageCategory.Success);
                //}
                //else
                //    OnMessage(BaranResources.EditFail, PublicEnum.EnmMessageCategory.Warning);
            }
            catch
            {
                OnMessage(BaranResources.DoNotDoPleaseTryAgine, PublicEnum.EnmMessageCategory.Warning);
            }
        }

        public override void OnDelete()
        {
            base.OnDelete();

            if (TreeID <= 0)
            {
                OnMessage(BaranResources.SavedNotLastTime, PublicEnum.EnmMessageCategory.Warning);
                return;
            }

            DialogResult msgResult = MessageBoxX.ShowMessageBox(PublicEnum.EnmMessageType.msgDeleteConfirm);
            if (msgResult == DialogResult.No) return;
            try
            {
                int RowAffected = Convert.ToInt16(adp.Delete(TreeID, CurrentUser.Instance.UserID));
                if (RowAffected > 0)
                {
                    OnMessage(BaranResources.DeleteSuccessful, PublicEnum.EnmMessageCategory.Success);
                }
                else
                    OnMessage(BaranResources.DeleteFail, PublicEnum.EnmMessageCategory.Warning);
            }
            catch
            {
                OnMessage(BaranResources.DoNotDoPleaseTryAgine, PublicEnum.EnmMessageCategory.Warning);
            }
        }

        public override void OnClear()
        {
            base.OnClear();

            Baran.Classes.Common.ControlsSetting.ClearControls(grpControls.Controls);
            TreeID = 0;
        }

        void AddMarker()
        {
            GMarkerGoogle m = new GMarkerGoogle(currentMarker.Position, new Bitmap(System.Drawing.Image.FromFile(PublicMethods.PictureFileNamePath(cnsPictureName.TreeMarker))));

            txtLatitude.Text = currentMarker.Position.Lat.ToString();
            txtLongitude.Text = currentMarker.Position.Lng.ToString();

            m.ToolTipMode = MarkerTooltipMode.OnMouseOver;
            m.ToolTipText = currentMarker.Position.ToString();

            markers.Markers.Clear();
            markers.Markers.Add(m);
        }

        private void SetControlsValue()
        {
            if (TreeID <= 0)
                return;

            //    db = new UnitOfWork();
            //    tbl_src_Tree tree = new tbl_src_Tree();
            //try
            //    { 
            //        tree = db.TreeRepository.GetById(TreeID);

            //        txtBaseCultivar.Text = tree.BaseCultivar;
            //        txtBaseType.Text = tree.BaseType;
            //        txtScionCultivar.Text = tree.ScionCultivar;
            //        txtSubInformation.Text = tree.SubInformation;
            //        txtCantaminationHistory.Text = tree.CantaminationHistory;
            //        txtTreeYeild.Text = tree.TreeYeild;
            //        txtMainCultivar.Text = tree.MainCultivar;
            //        txtScionLocation.Text = tree.ScionLocation;
            //        txtBaseBuyLocation.Text = tree.BaseBuyLocation;
            //        txtTransplantType.Text = tree.TransplantType;
            //        txtRow.Text = tree.Row.ToString();
            //        txtColumn.Text = tree.Column.ToString();
            //        txtLongitude.Text = tree.Longitude == null? string.Empty: tree.Longitude.ToString();
            //        txtLatitude.Text = tree.Latitude == null? string.Empty: tree.Latitude.ToString();

            //        cmbField.Value = tree.Fk_FieldID == null ? null : tree.Fk_FieldID;
            //        cmbTreeType.Value = tree.Fk_TreeType;
            //        mskDatePlanting.Text = tree.DatePlanting.ToString();// tree.DatePlanting == null ? string.Empty: DateTimeUtility.ToPersian(tree.DatePlanting);
            //        mskDateScion.Text  = tree.DateScion.ToString();// tree.DateScion == null ? string.Empty : DateTimeUtility.ToPersian(tree.DateScion);





            BaranDataAccess.Product.dstProduct.spr_src_Tree_SelectRow drw;
            try
            {
                drw = adp.GetTreeByIDTable(TreeID)[0];

                txtBaseCultivar.Text = drw.IsBaseCultivarNull() ? string.Empty : drw.BaseCultivar;
                txtBaseType.Text = drw.IsBaseTypeNull() ? string.Empty : drw.BaseType;
                txtScionCultivar.Text = drw.IsScionCultivarNull() ? string.Empty : drw.ScionCultivar;
                txtSubInformation.Text = drw.IsSubInformationNull() ? string.Empty : drw.SubInformation;
                txtCantaminationHistory.Text = drw.IsCantaminationHistoryNull() ? string.Empty : drw.CantaminationHistory;
                txtTreeYeild.Text = drw.IsTreeYeildNull() ? string.Empty : drw.TreeYeild;
                txtMainCultivar.Text = drw.IsMainCultivarNull() ? string.Empty : drw.MainCultivar;
                txtScionLocation.Text = drw.IsScionLocationNull() ? string.Empty : drw.ScionLocation;
                txtBaseBuyLocation.Text = drw.IsBaseBuyLocationNull() ? string.Empty : drw.BaseBuyLocation;
                txtTransplantType.Text = drw.IsTransplantTypeNull() ? string.Empty : drw.TransplantType;
                txtRow.Text = drw.IsRowNull() ? string.Empty : drw.Row.ToString();
                txtColumn.Text = drw.IsColumnNull() ? string.Empty : drw.Column.ToString();
                txtLongitude.Text = drw.IsLongitudeNull() ? string.Empty : drw.Longitude.ToString();
                txtLatitude.Text = drw.IsLatitudeNull() ? string.Empty : drw.Latitude.ToString();


                if (!drw.IsFk_FieldIDNull())
                    cmbField.Value = drw.Fk_FieldID;
                if (!drw.IsFk_TreeTypeNull())
                    cmbTreeType.Value = drw.Fk_TreeType;
                if (!drw.IsDatePlantingNull())
                    mskDatePlanting.Text = DateTimeUtility.ToPersian(drw.DatePlanting);
                if (!drw.IsDateScionNull())
                    mskDateScion.Text = DateTimeUtility.ToPersian(drw.DateScion);



                if ((!drw.IsLatitudeNull()) && (!drw.IsLongitudeNull()))
                {
                    //currentMarker.Position = new PointLatLng(Convert.ToDouble(drw.Latitude), Convert.ToDouble(drw.Longitude));
                    //this.AddMarker();


                    ////////////////////////////
                    //GMap.NET.WindowsForms.GMapOverlay markers = new GMap.NET.WindowsForms.GMapOverlay("markers");
                    GMap.NET.PointLatLng po = new GMap.NET.PointLatLng(Convert.ToDouble(drw.Latitude), Convert.ToDouble(drw.Longitude));
                    GMap.NET.WindowsForms.GMapMarker mark = new GMap.NET.WindowsForms.Markers.GMarkerGoogle(po, new Bitmap(System.Drawing.Image.FromFile(PublicMethods.PictureFileNamePath(cnsPictureName.TreeMarker))));

                    markers.Markers.Clear();
                    markers.Markers.Add(mark);
                    ///////////////////////////
                    //MainMap.Position = po;// new PointLatLng(32.843888, 51.967501);
                    //MainMap.Zoom = 17;

                    //MainMap.Overlays.Clear();
                    //MainMap.Overlays.Add(markers);
                    //MainMap.ZoomAndCenterMarkers(objects.ToString());
                    MainMap.ZoomAndCenterMarkers("markers");
                }

            }
            catch
            {
                OnMessage(BaranResources.DoNotDoPleaseTryAgine, PublicEnum.EnmMessageCategory.Warning);
            }
        }

        private void SetVariables()
        {
            strBaseCultivar = txtBaseCultivar.Text.Trim();
            strBaseType = txtBaseType.Text.Trim();
            strScionCultivar = txtScionCultivar.Text.Trim();
            strSubInformation = txtSubInformation.Text.Trim();
            strCantaminationHistory = txtCantaminationHistory.Text.Trim();
            strTreeYeild = txtTreeYeild.Text.Trim();
            strMainCultivar= txtMainCultivar.Text.Trim();
            strScionLocation= txtScionLocation.Text.Trim();
            strBaseBuyLocation= txtBaseBuyLocation.Text.Trim();
            strTransplantType= txtTransplantType.Text.Trim();
            intRow = Convert.ToInt16( txtRow.Text.Trim());
            intColumn = Convert.ToInt16( txtColumn.Text.Trim());

            
            dclLatitude = txtLatitude.Text == string.Empty ? (double?)null : Convert.ToDouble(txtLatitude.Text.Trim());
            dclLongitude = txtLongitude.Text == string.Empty ? (double?)null : Convert.ToDouble(txtLongitude.Text.Trim());
            
            PointLatLng SavePoints = new PointLatLng();
            if (txtLatitude.Text != string.Empty && txtLongitude.Text != string.Empty)
            {
                SavePoints.Lat = Convert.ToDouble(txtLatitude.Text.Trim());
                SavePoints.Lng = Convert.ToDouble(txtLongitude.Text.Trim());
                geoLocation = GeoUtils.ConvertGMapPointToDbGeometryPoint(SavePoints);
            }

            if (cmbField.SelectedItem != null)
                intFieldID = Convert.ToInt32(cmbField.Value);
            if (cmbTreeType.SelectedItem != null)
                intTreeType = Convert.ToInt32(cmbTreeType.Value);
            if (mskDatePlanting.Value.ToString() != string.Empty)
                datDatePlanting = DateTimeUtility.ToGregorian(mskDatePlanting.Text);
            if (mskDateScion.Value.ToString() != string.Empty)
                datDateScion = DateTimeUtility.ToGregorian(mskDateScion.Text);



        }

        private bool ControlsValidation()
        {
            bool blnResult = true;

            if (cmbField.SelectedItem == null)
            {
                cmbField.Focus();
                blnResult = false;
            }
            else if (txtRow.Text.Trim() == string.Empty)
            {
                txtRow.Focus();
                blnResult = false;
            }
            else if (txtColumn.Text.Trim() == string.Empty)
            {
                txtColumn.Focus();
                blnResult = false;
            }
            else if (mskDatePlanting.Value.ToString() == string.Empty)
            {
                mskDatePlanting.Focus();
                blnResult = false;
            }
            else if (mskDateScion.Value.ToString() == string.Empty)
            {
                mskDateScion.Focus();
                blnResult = false;
            }

            return blnResult;
        }

        private void DrowMap()
        {
            BaranDataAccess.Map.dstLocation.spr_geo_LocationByID_SelectDataTable tblLocation =
               new BaranDataAccess.Map.dstLocation.spr_geo_LocationByID_SelectDataTable();
            BaranDataAccess.Map.dstLocationTableAdapters.spr_geo_LocationByID_SelectTableAdapter adpLocation =
                new BaranDataAccess.Map.dstLocationTableAdapters.spr_geo_LocationByID_SelectTableAdapter();

            GMap.NET.WindowsForms.GMapOverlay markers = new GMap.NET.WindowsForms.GMapOverlay("markers");

            try
            {
                adpLocation.FillLocationByIDTable(tblLocation, null, null, null, null, null, null,null);

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

        #endregion

        #region Events

        private void cmbFields_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbField.Value == null) return;

                UnitOfWork db = new UnitOfWork();
                tbl_src_Field field = new tbl_src_Field();
                int FieldID = Convert.ToInt32(cmbField.Value);
                field = db.FieldRepository.GetById(FieldID);

                if (field is null)
                    return;

                List<PointLatLng> points = new List<PointLatLng>();

                if (field.LocationPolygon != null)
                {
                    points = GeoUtils.ConvertStringCoordinatesToGMapPolygony(field.LocationPolygon.ProviderValue.ToString());
                }

                ////////////////////////////
                GMapRoute rt = new GMapRoute(points, string.Empty);
                {
                    rt.Stroke = new Pen(Color.FromArgb(255, PublicVariables.FieldColor));
                    rt.Stroke.Width = PublicVariables.StrokeWidth;
                    rt.Stroke.DashStyle = PublicVariables.StrokeDashStyle;
                }

                routes.Routes.Clear();
                routes.Routes.Add(rt);
                //MainMap.Overlays.Remove(routes);
                //MainMap.Overlays.Add(routes);
                ////objects.Routes.Add(rt);

                ///////////////////////////
                //int p = MainMap.Overlays.Count;            
                MainMap.ZoomAndCenterRoutes("routes");
            }
            catch { }
        }

        private void MainMap_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isMouseDown = true;

                if (currentMarker.IsVisible)
                {
                    currentMarker.Position = MainMap.FromLocalToLatLng(e.X, e.Y);

                    //txtLatitude.Text = currentMarker.Position.Lat.ToString();
                    //txtLongitude.Text = currentMarker.Position.Lng.ToString();
                }
            }
        }

        private void MainMap_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isMouseDown = false;
            }
        }

        private void MainMap_DoubleClick(object sender, EventArgs e)
        {
            this.AddMarker();
        }

        private void btnGoto_Click(object sender, EventArgs e)
        {
            try
            {
                double lat = Convert.ToDouble(txtLatitude.Text); 
                double lng = Convert.ToDouble(txtLongitude.Text); 

                currentMarker.Position = new PointLatLng(lat, lng);
                MainMap.Position = new PointLatLng(lat, lng);
            }
            catch (Exception ex)
            {
                MessageBox.Show("incorrect coordinate format: " + ex.Message);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.AddMarker();
        }

        #endregion

        private void grpControls_Click(object sender, EventArgs e)
        {

        }
    }
}
