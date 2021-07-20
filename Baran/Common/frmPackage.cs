using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Baran.Classes.Common;

namespace Baran.Common
{
    public partial class frmPackage : Baran.Base_Forms.frmChildBase
    {
        public frmPackage()
        {
            InitializeComponent();
        }

        private void btnShowPic_Click(object sender, EventArgs e)
        {
            picPackage.Image = PublicMethods.PictureOpenFileDialog();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string strPackageName;
            int intPckageOrder, intPackageID;

            byte[] bytPackageLogo;

            BaranDataAccess.Security.dstSecurityTableAdapters.spr_Sec_Packages_SelectTableAdapter adpPackageInsert =
                new BaranDataAccess.Security.dstSecurityTableAdapters.spr_Sec_Packages_SelectTableAdapter();

            DialogResult msgResult = MessageBoxX.ShowMessageBox(PublicEnum.EnmMessageType.msgSaveConfirm);
            if (msgResult == DialogResult.No) return;

            if (txtPackageName.Text == string.Empty)
            {
                this.lblMessage.Text = BaranResources.FeildIsEmpty;
                txtPackageName.Focus();
                return;
            }
            else
            {
                strPackageName = txtPackageName.Text.Trim();
            }

            if (txtPackageOrder.Text == string.Empty)
            {
                this.lblMessage.Text = BaranResources.FeildIsEmpty;
                txtPackageOrder.Focus();
                return;
            }
            else
            {
                intPckageOrder = Convert.ToInt32(txtPackageOrder.Text.Trim());
            }

            if (picPackage.Image == null)
            {
                this.lblMessage.Text = BaranResources.FeildIsEmpty;
                btnShowPic.Focus();
                return;
            }
            else
            {
                bytPackageLogo = PublicMethods.ImageToArray(picPackage.Image);
            }

            try
            {
                intPackageID = Convert.ToInt32(adpPackageInsert.spr_Sec_Package_Inser(strPackageName, bytPackageLogo, intPckageOrder));

                if (intPackageID > 0)
                    this.lblMessage.Text = BaranResources.SaveSuccessful;
                else
                    this.lblMessage.Text = "یا قبلا این نام تعریف شده است  " + BaranResources.DoNotDoPleaseTryAgine;
            }
            catch
            {
                this.lblMessage.Text = BaranResources.SaveFail;
            }
        }
    }
}
