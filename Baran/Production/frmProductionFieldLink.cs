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
using BaranDataAccess;

namespace Baran.Production
{
    public partial class frmProductionFieldLink : Baran.Base_Forms.frmSecondChildBase
    {
        #region Constractor

        public frmProductionFieldLink(int productionID)
        {
            ProductionID = productionID;
              
            InitializeComponent();

        }

        #endregion

        #region Variables

        BaranDataAccess.Production.dstProductsTableAdapters.spr_Prd_ProductionField_SelectTableAdapter adp =
            new BaranDataAccess.Production.dstProductsTableAdapters.spr_Prd_ProductionField_SelectTableAdapter();

        string
            strDescription;

        decimal
            dclLinkedArea;

        private Nullable<DateTime>
            FromDate
            , ToDate;

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

        private int _productionID;
        public int ProductionID
        {
            get
            {
                return _productionID;
            }
            set
            {
                _productionID = value;
            }
        }
        #endregion

        #region Methods

        public override void OnformLoad()
        {
            base.OnformLoad();

            ComboBoxSetting.FillComboBox(Classes.Common.PublicEnum.EnmComboSource.srcFieldByUserID, cmbFields, CurrentUser.Instance.UserID.ToString());
            //picImage.Image = System.Drawing.Image.FromFile(PublicMethods.PictureFileNamePath(cnsPictureName.Field));

            if (PublicPropertise.ProductionInUpate)
            {
                this.SetControlsValue();
                FormType = cnsFormType.Change;
            }
            else
                FormType = cnsFormType.New;
        }

        public override void OnSave()
        {
            base.OnSave();

            if (PublicPropertise.ProductionFieldID > 0)
            {
                OnMessage(BaranResources.SavedLastTime, PublicEnum.EnmMessageCategory.Warning);
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
                
                PublicPropertise.ProductionFieldID = Convert.ToInt32( adp.NewProductionField_Insert(FieldID, ProductionID, dclLinkedArea, FromDate, ToDate, strDescription, CurrentUser.Instance.UserID));
                if (PublicPropertise.ProductionFieldID > 0)
                {
                    MessageBoxX.ShowMessageBox(PublicEnum.EnmMessageType.msgSaveSuccessful);


                    Baran.Production.frmProductionCultivarLink ofrm = new frmProductionCultivarLink();

                    //ofrm.FormItemID = Convert.ToInt32(PublicEnum.EnmformItemId.Field);
                    //if (PublicMethods.SetFormSchema(ofrm, ofrm.FormItemID))
                    //{
                    ofrm.MdiParent = this.MdiParent;
                    ofrm.FormType = cnsFormType.New;
                    ofrm.Show();

                    this.Close();
                    //OnMessage(BaranResources.SaveSuccessful, PublicEnum.EnmMessageCategory.Success);
                }
                else
                    OnMessage(BaranResources.SaveFail, PublicEnum.EnmMessageCategory.Warning);
            }
            catch
            {
                OnMessage(BaranResources.DoNotDoPleaseTryAgine, PublicEnum.EnmMessageCategory.Warning);
            }
        }

        public override void OnChange()
        {
            base.OnChange();

            if (PublicPropertise.ProductionFieldID <= 0)
            {
                OnMessage(BaranResources.SavedNotLastTime, PublicEnum.EnmMessageCategory.Warning);
                return;
            }

            if (!this.ControlsValidation())
            {
                OnMessage(BaranResources.FeildIsEmpty, PublicEnum.EnmMessageCategory.Warning);
                return;
            }

            DialogResult msgResult = MessageBoxX.ShowMessageBox(PublicEnum.EnmMessageType.msgEditConfirm);
            if (msgResult == DialogResult.No) return;

            try
            {
                this.SetVariables();
                int RowAffected = Convert.ToInt32(adp.Update(PublicPropertise.ProductionFieldID, FieldID, ProductionID, dclLinkedArea, FromDate, ToDate, strDescription, CurrentUser.Instance.UserID));

                if (RowAffected > 0)
                {
                    OnMessage(BaranResources.EditSuccessful, PublicEnum.EnmMessageCategory.Success);
                }
                else
                    OnMessage(BaranResources.EditFail, PublicEnum.EnmMessageCategory.Warning);
            }
            catch
            {
                OnMessage(BaranResources.DoNotDoPleaseTryAgine, PublicEnum.EnmMessageCategory.Warning);
            }
        }

        public override void OnDelete()
        {
            base.OnDelete();

            if (PublicPropertise.ProductionFieldID <= 0)
            {
                OnMessage(BaranResources.SavedNotLastTime, PublicEnum.EnmMessageCategory.Warning);
                return;
            }

            DialogResult msgResult = MessageBoxX.ShowMessageBox(PublicEnum.EnmMessageType.msgDeleteConfirm);
            if (msgResult == DialogResult.No) return;
            try
            {
                int RowAffected = (int)adp.Delete(PublicPropertise.ProductionFieldID, CurrentUser.Instance.UserID);
                if (RowAffected > 0)
                {
                    OnMessage(BaranResources.DeleteSuccessful, PublicEnum.EnmMessageCategory.Success);
                    FieldID = 0;
                    this.OnClear();
                }
                else
                    OnMessage(BaranResources.DeleteFail, PublicEnum.EnmMessageCategory.Warning);
            }
            catch
            {
                OnMessage(BaranResources.DoNotDoPleaseTryAgine, PublicEnum.EnmMessageCategory.Warning);
            }
        }

        private bool ControlsValidation()
        {
            bool blnResult = true;

            if (cmbFields.Value == null)
            {
                cmbFields.Focus();
                blnResult = false;
            }
            else if (txtLinkedArea.Text.Trim() == string.Empty)
            {
                txtLinkedArea.Focus();
                blnResult = false;
            }
            else if (mskFromDate.Value.ToString() == "")
            {
                mskFromDate.Focus();
                blnResult = false;
            }
            else if (mskToDate.Value.ToString() == "")
            {
                mskToDate.Focus();
                blnResult = false;
            }

            return blnResult;
        }

        private void SetVariables()
        {
            strDescription = txtDescription.Text.Trim();
            dclLinkedArea = Convert.ToDecimal(txtLinkedArea.Text.Trim());

            if (mskFromDate.Text != null)
                FromDate =  DateTimeUtility.ToGregorian(mskFromDate.Value.ToString());// PublicMethods.ShamsiToMiladi(mskFromDate.Value.ToString());

            if (mskToDate.Text != null)
                ToDate = DateTimeUtility.ToGregorian(mskToDate.Text);//.Value.ToString());// PublicMethods.ShamsiToMiladi(mskToDate.Text);//.Value.ToString());// DateTimeUtility.ToGregorian(mskToDate.Text);
        }

        private void SetControlsValue()
        {
            try
            {
                BaranDataAccess.Production.dstProducts.spr_Prd_ProductionField_SelectRow drw;
                drw = adp.GetProductionFieldByProductionIDTable(ProductionID)[0];

                PublicPropertise.ProductionFieldID = drw.FieldProductionID;

                cmbFields.Value = drw.IsFk_FieldIDNull() ? null : cmbFields.Value = drw.Fk_FieldID;
                txtLinkedArea.Text = drw.LinkedArea.ToString();

                mskFromDate.Text = !drw.IsFromDateNull() ? DateTimeUtility.ToPersian( drw.FromDate) : null;
                mskToDate.Text = drw.IsToDateNull() ? null : DateTimeUtility.ToPersian(drw.ToDate);
                txtDescription.Text = drw.Description;
            }
            catch { }
        }

        #endregion

        #region Events

        private void cmbFields_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbFields.Value == null) return;

                UnitOfWork db = new UnitOfWork();
                tbl_src_Field field = new tbl_src_Field();
                try
                {

                    FieldID = Convert.ToInt32(cmbFields.Value);
                    field = db.FieldRepository.GetById(FieldID);

                    if (field is null)
                        return;
                    txtName.Text = field.Name;
                    txtTotalArea.Text = field.TotalArea == null ? string.Empty : field.TotalArea.ToString();
                    txtUsableArea.Text = field.UsableArea == null ? string.Empty : field.UsableArea.ToString();
                    txtLinkedArea.Text = field.UsableArea == null ? string.Empty : field.UsableArea.ToString();

                    List<PointLatLng> points = new List<PointLatLng>();

                    if (field.LocationPolygon != null)
                    {
                        points = GeoUtils.ConvertStringCoordinatesToGMapPolygony(field.LocationPolygon.ProviderValue.ToString());
                    }
                    GMapOverlay routes = new GMapOverlay("routes");
                    ////////////////////////////
                    GMapRoute rt = new GMapRoute(points, string.Empty);
                    {
                        rt.Stroke = new Pen(Color.FromArgb(255, PublicVariables.FieldColor));
                        rt.Stroke.Width = PublicVariables.StrokeWidth;
                        rt.Stroke.DashStyle = PublicVariables.StrokeDashStyle;
                    }
                    routes.Routes.Add(rt);

                    ///////////////////////////
                    MainMap.Overlays.Clear();
                    MainMap.Overlays.Add(routes);
                    MainMap.ZoomAndCenterRoutes("routes");
                }
                catch { }
            }
            catch { }
            //BaranDataAccess.Source.dstSourceTableAdapters.spr_src_FieldByID_Lst_SelectTableAdapter adp =
            //     new BaranDataAccess.Source.dstSourceTableAdapters.spr_src_FieldByID_Lst_SelectTableAdapter();
            //BaranDataAccess.Source.dstSource.spr_src_FieldByID_Lst_SelectRow drwField;

            //FieldID = Convert.ToInt32(cmbFields.Value);

            //drwField = adp.GetFieldListByIDTable(FieldID)[0];

            //txtName.Text = drwField.IsSoilTextureNameNull() ? string.Empty : drwField.SoilTextureName;
            //txtTotalArea.Text = drwField.IsTotalAreaNull() ? string.Empty : drwField.TotalArea.ToString();
            //txtUsableArea.Text = drwField.IsUsableAreaNull() ? string.Empty : drwField.UsableArea.ToString();
            //txtLinkedArea.Text = drwField.IsUsableAreaNull() ? string.Empty : drwField.UsableArea.ToString();



            //BaranDataAccess.Map.dstLocation.spr_geo_LocationByID_SelectDataTable tblLocation =
            //    new BaranDataAccess.Map.dstLocation.spr_geo_LocationByID_SelectDataTable();
            //BaranDataAccess.Map.dstLocationTableAdapters.spr_geo_LocationByID_SelectTableAdapter adpLocation =
            //    new BaranDataAccess.Map.dstLocationTableAdapters.spr_geo_LocationByID_SelectTableAdapter();

            ////List<PointLatLng> points = new List<PointLatLng>();

            //adpLocation.FillLocationByIDTable(tblLocation, FieldID, null, null, null, null, null, null);

            //if (tblLocation.Count > 0)
            //{
            //    GMapOverlay routes = new GMapOverlay("routes");
            //    foreach (var point in tblLocation)
            //    {
            //        points.Add(new PointLatLng(Convert.ToDouble(point.Latitude), Convert.ToDouble(point.Longitude)));

            //    }
            //    ////////////////////////////
            //    GMapRoute rt = new GMapRoute(points, string.Empty);
            //    {
            //        rt.Stroke = new Pen(Color.FromArgb(144, Color.Red));
            //        rt.Stroke.Width = 5;
            //        rt.Stroke.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDot;
            //    }
            //    routes.Routes.Add(rt);

            //    ///////////////////////////
            //    MainMap.Overlays.Clear();
            //    MainMap.Overlays.Add(routes);
            //    MainMap.ZoomAndCenterRoutes("routes");

            //}
        }

        #endregion
    }
}
