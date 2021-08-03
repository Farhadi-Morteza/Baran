using Baran.Classes.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Baran.Source
{
    public partial class frmMachineryView : Baran.Base_Forms.frmViewBase
    {
        #region Constractor
        public frmMachineryView(int machineryID)
        {
            InitializeComponent();
            MachineryID = machineryID;
        }
        #endregion

        #region Variables
        BaranDataAccess.Common.dstCommon.spr_cmn_DocumentByFkID_SelectDataTable tblDoc =
            new BaranDataAccess.Common.dstCommon.spr_cmn_DocumentByFkID_SelectDataTable();
        #endregion

        #region Propertise

        private int _MachineryID;
        public int MachineryID
        {
            get
            {
                return _MachineryID;
            }
            set
            {
                _MachineryID = value;
            }
        }

        #endregion

        #region Methods

        public override void OnformLoad()
        {
            base.OnformLoad();
            this.SetControlsValue();
            this.SetDocument();
        }

        private void SetControlsValue()
        {            
            BaranDataAccess.Source.dstSource.spr_src_Machinery_Vew_SelectRow rwMachinery;
            try
            {
                rwMachinery = BaranDataAccess.Source.dstSource.MachineryViewTable(MachineryID).spr_src_Machinery_Vew_Select[0];

                lblCollection.Text = rwMachinery.IsCollectionNull() ? string.Empty : rwMachinery.Collection;
                lblSubcollection.Text = rwMachinery.Subcollection;
                lblName.Text = rwMachinery.IsNameNull() ? string.Empty : rwMachinery.Name;
                lblCount.Text = rwMachinery.IsCountNull() ? string.Empty : rwMachinery.Count.ToString();
                lblVigor.Text = rwMachinery.IsVigorNull() ? string.Empty : rwMachinery.Vigor.ToString();
                lblCategory.Text = rwMachinery.IsCategoryNull() ? string.Empty : rwMachinery.Category;
                lblRegNumber.Text = rwMachinery.IsRegNumberNull() ? string.Empty : rwMachinery.RegNumber;
                lblYear.Text = rwMachinery.IsYearNull() ? string.Empty : rwMachinery.Year;
                lblManufacture.Text = rwMachinery.IsManufacturerNull() ? string.Empty : rwMachinery.Manufacturer;
                lblModel.Text = rwMachinery.IsModelNull() ? string.Empty : rwMachinery.Model;
                lblDescription.Text = rwMachinery.IsDescriptionNull() ? string.Empty : rwMachinery.Description;
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
                adpDoc.FillDocumentByFkIDTable(tblDoc, null, null, null, null, null,null, null, null, MachineryID, null, null, null);
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
