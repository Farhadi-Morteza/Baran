using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using Baran.Classes.Common;

namespace Baran.Common
{
    public partial class frmSaveImage : Baran.Base_Forms.frmChildBase
    {
        public frmSaveImage()
        {
            InitializeComponent();
        }

        #region Method


        #endregion

        private int _OperationType;
        private int OperationType
        {
            get
            {
                return _OperationType;
            }
            set
            {
                _OperationType = value;
            }
        }

        private enum enmOperationType : int
        {
            Packages = 1
            , Items = 2
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            picItems.Image = PublicMethods.PictureOpenFileDialog();
        }

        public override void OnSave()
        {
            base.OnSave();
            int intItemID = (int)cmbObject.Value;

            if((cmbObject.Value).ToString() != "")
            {
                intItemID = (int)cmbObject.Value;
            }

            byte[] objImage = Baran.Classes.Common.PublicMethods.ImageToArray(picItems.Image);

            BaranDataAccess.Common.dstImagesTableAdapters.InsertImageTableAdapter adapter
                = new BaranDataAccess.Common.dstImagesTableAdapters.InsertImageTableAdapter();
            adapter.spr_Cmn_InsertImageIntoTable_Update(objImage, intItemID);
            //BaranDataAccess.Common.dstImages.InsertImage(objImage);

            //Image h = Image.FromFile(txtCodeP.Text + ".png");
            //picPerson.Image = h;//System.Drawing.Image.FromFile(dlg.FileName);
            //SqlConnection Cnn1 = new SqlConnection(Properties.Settings.Default["Ansar_ConnectionString"].ToString());
            //object objImage = ImageToArray(picPerson.Image);
            //SqlCommand Cmd1 = new SqlCommand("UPDATE dbo.tblPersonalPublic SET ImagePerson=@Img WHERE CodeP=@CodeP", Cnn1);
            //Cmd1.Parameters.AddWithValue("@CodeP", txtCodeP.Text);
            //Cmd1.Parameters.AddWithValue("@Img", objImage);
            //Cnn1.Open();
            //SqlDataReader Dr1 = Cmd1.ExecuteReader();
            //Dr1.Read();
        }

        private void frmSaveImage_Load(object sender, EventArgs e)
        {
            this.SetTypeCombo();
        }

        private void SetTypeCombo()
        {
            DataTable tblType = new DataTable();
            tblType.Columns.Add("TypeID");
            tblType.Columns.Add("TypeName");

            tblType.Rows.Add(new object[] { "1" ,"گروه"});
            tblType.Rows.Add(new object[] { "2" ,"آیتم"});

            cmbType.DataSource = tblType;
            cmbType.DisplayMember = tblType.Columns[1].ToString();
            cmbType.ValueMember = tblType.Columns[0].ToString();
        }

        private void frmSaveImage_Activated(object sender, EventArgs e)
        {
            frmMain ofrm = frmMain.Instanc;

            ofrm.EnableToolBarItems(cnsToolStripButton.Cancel, cnsToolStripButton.Change);
            ofrm.EnableMenuStripItems(cnsMenustripItems.Cancel, cnsMenustripItems.Change);
        }

        private void cmbType_ValueChanged(object sender, EventArgs e)
        {


        }

        private void cmbObject_ValueChanged(object sender, EventArgs e)
        {
 
        }

        private void btnNewPackage_Click(object sender, EventArgs e)
        {
            frmPackage ofrmPackage = new frmPackage();

            ofrmPackage.ShowDialog();
            this.frmSaveImage_Activated(sender, e);
            this.SetPackagesCombo();
        }

        private void SetPackagesCombo()
        {
            BaranDataAccess.Common.dstItems ItemsDst;

            ItemsDst = BaranDataAccess.Common.dstItems.GetPackages();

            cmbObject.DataSource = ItemsDst.spr_Sec_Packages_Select;
            cmbObject.ValueMember = ItemsDst.spr_Sec_Packages_Select.PackageIDColumn.ColumnName;
            cmbObject.DisplayMember = ItemsDst.spr_Sec_Packages_Select.PackageNameColumn.ColumnName;
        }

        private void SetItemsCombo()
        {
            BaranDataAccess.Common.dstItems ItemsDst;

            ItemsDst = BaranDataAccess.Common.dstItems.GetItems();

            cmbObject.DataSource = ItemsDst.spr_Sec_Items_Select;
            cmbObject.ValueMember = ItemsDst.spr_Sec_Items_Select.ItemIDColumn.ColumnName;
            cmbObject.DisplayMember = ItemsDst.spr_Sec_Items_Select.ItemNameColumn.ColumnName;

            ItemsDst = BaranDataAccess.Common.dstItems.GetPackages();
            cmbPackageOfItems.DataSource = ItemsDst.spr_Sec_Packages_Select;
            cmbPackageOfItems.ValueMember = ItemsDst.spr_Sec_Packages_Select.PackageIDColumn.ColumnName;
            cmbPackageOfItems.DisplayMember = ItemsDst.spr_Sec_Packages_Select.PackageNameColumn.ColumnName;
        }

        private void ClearFields()
        {
            cmbObject.DataSource = null;
            cmbObject.Text = "";

            txtName.Text = string.Empty;
            txtOrder.Text = string.Empty;

            picItems.Image = null;
        }

        private void SetFieldsVisible(int prmTypeID)
        {
            if (prmTypeID == (int) enmOperationType.Packages)
            {
                btnNewPackage.Visible = true;
                cmbPackageOfItems.Visible = false;
                lblPackageOfItems.Visible = false;
            }
            else if (prmTypeID == (int)enmOperationType.Items)
            {
                btnNewPackage.Visible = false;
                cmbPackageOfItems.Visible = true;
                lblPackageOfItems.Visible = true;
            }
        }

        public override void OnChange()
        {
            base.OnChange();
            
            string strName;

            int 
                intPackageOfItems,
                intObjectID,
                intOrder,
                intInsertID = 0;

            byte[] bytImage;

            if (txtName.Text == string.Empty)
            {
                this.lblMessage.Text = BaranResources.FeildIsEmpty;
                txtName.Focus();
                return;
            }
            else
            {
                strName = txtName.Text.Trim();
            }

            if (txtOrder.Text == string.Empty)
            {
                this.lblMessage.Text = BaranResources.FeildIsEmpty;
                txtOrder.Focus();
                return;
            }
            else
            {
                intOrder = Convert.ToInt32( txtOrder.Text.Trim());
            }

            if (picItems.Image == null)
            {
                this.lblMessage.Text = BaranResources.FeildIsEmpty;
                btnShow.Focus();
                return;
            }
            else
            {
                bytImage = PublicMethods.ImageToArray(picItems.Image);
            }

            if(cmbObject.Text == string.Empty)
            {
                this.lblMessage.Text = BaranResources.FeildIsEmpty;
                cmbObject.Focus();
                return;
            }
            else
            {
                intObjectID = Convert.ToInt32( cmbObject.Value);
            }

            if (OperationType == (int)enmOperationType.Packages)
            {
                BaranDataAccess.Security.dstSecurityTableAdapters.spr_Sec_Packages_SelectTableAdapter adpPackageUpdate =
                    new BaranDataAccess.Security.dstSecurityTableAdapters.spr_Sec_Packages_SelectTableAdapter();

                try
                {
                    intInsertID = Convert.ToInt32( adpPackageUpdate.spr_Sec_Package_Update(intObjectID, strName, intOrder, bytImage));
                }
                catch
                {
                    this.lblMessage.Text = BaranResources.EditFail;
                }
            }
            else if (OperationType == (int)enmOperationType.Items)
            {
                BaranDataAccess.Security.dstSecurityTableAdapters.spr_Sec_Items_SelectTableAdapter adpItemUpdate =
                    new BaranDataAccess.Security.dstSecurityTableAdapters.spr_Sec_Items_SelectTableAdapter();

                if(cmbPackageOfItems.Text == string.Empty)
                {
                    this.lblMessage.Text = BaranResources.FeildIsEmpty;
                    cmbPackageOfItems.Focus();
                    return;
                }
                else
                {
                    intPackageOfItems = Convert.ToInt32(cmbPackageOfItems.Value);
                }
                try
                {
                    intInsertID = Convert.ToInt32(adpItemUpdate.spr_Sec_Items_Update(intObjectID, strName, intOrder, intPackageOfItems, bytImage));
                }
                catch
                {
                    this.lblMessage.Text = BaranResources.EditFail;
                }
            }

            if (intInsertID > 0)
                this.lblMessage.Text = BaranResources.EditSuccessful;
            else
                this.lblMessage.Text = BaranResources.DoNotDoPleaseTryAgine;
        }

        private void cmbType_SelectionChanged(object sender, EventArgs e)
        {
            int intColumnType = Convert.ToInt32(cmbType.Value);

            this.ClearFields();

            OperationType = Convert.ToInt32(cmbType.Value);

            switch (intColumnType)
            {
                case (int)enmOperationType.Packages:
                    {
                        this.SetPackagesCombo();
                        this.SetFieldsVisible(intColumnType);
                        break;
                    }
                case (int)enmOperationType.Items:
                    {
                        this.SetItemsCombo();
                        this.SetFieldsVisible(intColumnType);
                        break;
                    }

            }
        }

        private void cmbObject_SelectionChanged(object sender, EventArgs e)
        {
            int intTypeID = Convert.ToInt32(cmbType.Value);
            int intObjectID = Convert.ToInt32(cmbObject.Value);

            try
            {
                switch (intTypeID)
                {
                    case ((int)enmOperationType.Items):
                        {
                            BaranDataAccess.Security.dstSecurity.spr_Sec_Items_SelectDataTable tblItems =
                                new BaranDataAccess.Security.dstSecurity.spr_Sec_Items_SelectDataTable();
                            BaranDataAccess.Security.dstSecurityTableAdapters.spr_Sec_Items_SelectTableAdapter adpItems =
                                new BaranDataAccess.Security.dstSecurityTableAdapters.spr_Sec_Items_SelectTableAdapter();
                            BaranDataAccess.Security.dstSecurity.spr_Sec_Items_SelectRow drwItems;

                            tblItems = adpItems.GetItemsTableByItemID(intObjectID);

                            drwItems = tblItems[0];

                            txtName.Text = drwItems.ItemName;
                            txtOrder.Text = drwItems.OrderInLevel.ToString();

                            picItems.Image = PublicMethods.ArrayToImage(drwItems.ItemLogo);

                            break;
                        }
                    case (int)enmOperationType.Packages:
                        {
                            BaranDataAccess.Security.dstSecurity.spr_Sec_Packages_SelectDataTable tblPackage =
                                new BaranDataAccess.Security.dstSecurity.spr_Sec_Packages_SelectDataTable();
                            BaranDataAccess.Security.dstSecurityTableAdapters.spr_Sec_Packages_SelectTableAdapter adpPackage =
                                new BaranDataAccess.Security.dstSecurityTableAdapters.spr_Sec_Packages_SelectTableAdapter();
                            BaranDataAccess.Security.dstSecurity.spr_Sec_Packages_SelectRow drwPackage;

                            tblPackage = adpPackage.GetPackageTableByPackageID(intObjectID);
                            drwPackage = tblPackage[0];

                            txtName.Text = drwPackage.PackageName;
                            txtOrder.Text = drwPackage.PackageOrder.ToString();

                            picItems.Image = PublicMethods.ArrayToImage(drwPackage.PackageLogo);

                            break;
                        }
                }
            }
            catch
            { }
        }

    }
}
