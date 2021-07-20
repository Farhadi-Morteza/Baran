using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BaranDataAccess.Security;
using Baran.Classes.Common;
using System.Transactions;

namespace Baran.Security.User
{
    public partial class frmUsers : Baran.Base_Forms.frmChildBase
    {

    #region Constractor

        public frmUsers()
    {
        InitializeComponent();
    }

    #endregion // End Constractor ---------------------------------------------------------------------

    #region Variables

        private long _UserID;

        byte[] UserImage;

        private dstSecurity.spr_Sec_SelectUsersByUserID_SelectDataTable P_tblUserToUpdate =
            new dstSecurity.spr_Sec_SelectUsersByUserID_SelectDataTable();
        private dstSecurity.spr_Sec_ItemUsers_SelectDataTable tblItemUserToUpdate =
            new dstSecurity.spr_Sec_ItemUsers_SelectDataTable();

        private bool _PasswordEnable = true
                    , _ConfirmPasswordEnable =true;

        private enum enmAccessLevelItemsID : int
        {
            Save = 0,
            Change = 1,
            Delete = 2,
            New = 3, 
            Print = 4
        }

        Nullable<int>
            intUserTypeID
            , intCompanyID
            , intCollectionID
            , intSubcollectionID
            , intPartID;


    #endregion // End Variables -----------------------------------------------------------------------

    #region Propertise

        public long UserID
        {
            get
            {
                return _UserID;
            }
            set
            {
                _UserID = value;
            }
        }

        public dstSecurity.spr_Sec_SelectUsersByUserID_SelectDataTable RecordToUpdat
        {
            get
            {
                return P_tblUserToUpdate;
            }
            set
            {
                P_tblUserToUpdate = value;
            }
        }

        public bool EnablePasswordFeild
        {
            set
            {
                txtPassword.Enabled = _PasswordEnable;
            }
        }

        public bool EnableConfirmPasswordFeild
        {
            set
            {
                txtConfirmPassword.Enabled = _ConfirmPasswordEnable;
            }
        }

    #endregion // End Propertiese ---------------------------------------------------------------------

    #region Methods

        private void SetAccessibleItemsTree()
        {

            BaranDataAccess.Security.dstSecurityTableAdapters.spr_Sec_Packages_SelectTableAdapter adpPackages =
                new BaranDataAccess.Security.dstSecurityTableAdapters.spr_Sec_Packages_SelectTableAdapter();

            BaranDataAccess.Security.dstSecurity.spr_Sec_Packages_SelectDataTable tblPackages =
                new dstSecurity.spr_Sec_Packages_SelectDataTable();
            try
            {
                tblPackages = adpPackages.GetPackagesTable();

                ImageList imgListItems = new ImageList();
                trvItems.ImageList = imgListItems;
                imgListItems.ImageSize = new Size(16, 16);

                foreach (dstSecurity.spr_Sec_Packages_SelectRow drwPackages in tblPackages)
                {
                    TreeNode trnPackage = new TreeNode();

                    trnPackage.Text = drwPackages.PackageName;
                    trnPackage.Tag = drwPackages.PackageID;
                    trnPackage.ForeColor =  System.Drawing.Color.White;

                    try
                    {
                        System.IO.MemoryStream mstrmTemp = new System.IO.MemoryStream(drwPackages.PackageLogo);
                        System.Drawing.Bitmap bmpTemp = new System.Drawing.Bitmap(mstrmTemp);
                        imgListItems.Images.Add(bmpTemp);
                        mstrmTemp.Close();
                    }
                    catch { }

                    trnPackage.Checked = false;
                    trnPackage.ImageIndex = imgListItems.Images.Count - 1;
                    trnPackage.SelectedImageIndex = imgListItems.Images.Count - 1;

                    trvItems.Nodes.Add(trnPackage);

                    BaranDataAccess.Security.dstSecurityTableAdapters.spr_Sec_Items_SelectTableAdapter adpItems =
                        new BaranDataAccess.Security.dstSecurityTableAdapters.spr_Sec_Items_SelectTableAdapter();

                    BaranDataAccess.Security.dstSecurity.spr_Sec_Items_SelectDataTable tblItems =
                        new dstSecurity.spr_Sec_Items_SelectDataTable();

                    tblItems = adpItems.GetItemsTableByPackageID(drwPackages.PackageID);

                    foreach (dstSecurity.spr_Sec_Items_SelectRow drwItems in tblItems)
                    {
                        TreeNode trnItems = new TreeNode();
                        trnItems.Text = drwItems.ItemName;
                        trnItems.Tag = drwItems.ItemID;
                        trnItems.ForeColor = System.Drawing.Color.White;

                        try
                        {
                            System.IO.MemoryStream mstrmTempItems = new System.IO.MemoryStream(drwItems.ItemLogo);
                            System.Drawing.Bitmap bmpTempItems = new System.Drawing.Bitmap(mstrmTempItems);
                            imgListItems.Images.Add(bmpTempItems);
                            mstrmTempItems.Close();
                        }
                        catch
                        { }

                        trnItems.Checked = false;
                        trnItems.ImageIndex = imgListItems.Images.Count - 1;
                        trnItems.SelectedImageIndex = imgListItems.Images.Count - 1;

                        trnPackage.Nodes.Add(trnItems);
                        trnItems.Collapse();

                        DataTable tblAccessLevel = PopulateAccessLevelDataTable();
                        for (int i = 0; i < tblAccessLevel.Rows.Count; i++)
                        {
                            TreeNode trnAccessLevelItems = new TreeNode();
                            trnAccessLevelItems.Text = tblAccessLevel.Rows[i][1].ToString();

                            imgListItems.Images.Add(imgAccessLevel.Images[i]);

                            trnAccessLevelItems.Checked = false;
                            trnAccessLevelItems.ImageIndex = imgListItems.Images.Count - 1;
                            trnAccessLevelItems.SelectedImageIndex = imgListItems.Images.Count - 1;
                            trnAccessLevelItems.ForeColor = System.Drawing.Color.White;
                            trnItems.Nodes.Add(trnAccessLevelItems);
                            trnAccessLevelItems.Collapse();
                        }
                    }
                }
            }
            catch
            { }
        }

        private DataTable PopulateAccessLevelDataTable()
        {
            DataTable tblAccessLevel = new DataTable();
            tblAccessLevel.Columns.Add("AccessLevelID");
            tblAccessLevel.Columns.Add("AccessLevelName");

            tblAccessLevel.Rows.Add(new object[] { "1", "ثبت" });
            tblAccessLevel.Rows.Add(new object[] { "2", "تغییر" });
            tblAccessLevel.Rows.Add(new object[] { "3", "حذف" });
            tblAccessLevel.Rows.Add(new object[] { "4", "جدید" });
            tblAccessLevel.Rows.Add(new object[] { "5", "پرینت" });

            return tblAccessLevel;
        }

        private void SetFeilds()
        {
            if (P_tblUserToUpdate == null || P_tblUserToUpdate.Rows.Count == 0) return;
            BaranDataAccess.Security.dstSecurity.spr_Sec_SelectUsersByUserID_SelectRow drwUser = (BaranDataAccess.Security.dstSecurity.spr_Sec_SelectUsersByUserID_SelectRow)P_tblUserToUpdate.Rows[0];

            txtName.Text = drwUser.FirstName.ToString();
            txtFamily.Text = drwUser.LastName.ToString();
            txtTelephone.Text = drwUser.IsTelephoneNull() ? "" : drwUser.Telephone;
            txtMobile.Text = drwUser.IsMobileNull() ? "" : drwUser.Mobile;
            txtEmail.Text = drwUser.IsEmailNull() ? "" : drwUser.Email;
            txtDescription.Text = drwUser.IsDescriptionNull() ? "" : drwUser.Description;
            txtAddress.Text = drwUser.IsUserAddressNull() ? "" : drwUser.UserAddress;
            txtUserName.Text = drwUser.UserName;
            txtPassword.Text = drwUser.Password;

            cmbShop.Value = drwUser.FK_ShopID;

            chkIsActive.Checked = drwUser.IsIsActiveNull() ? false : drwUser.IsActive;
            chkIsManager.Checked = drwUser.IsIsManagerNull() ? false : drwUser.IsManager;
            chkSalesPerson.Checked = drwUser.IsIsSalesPersonNull() ? false : drwUser.IsSalesPerson;
            chkOtherStaff.Checked = drwUser.IsIsOtherStaffNull() ? false : drwUser.IsOtherStaff;
            chkAccountant.Checked = drwUser.IsIsAccountantNull() ? false : drwUser.IsAccountant;

            cmbUserType.Value = drwUser.IsFK_UserTypeIDNull() ? 0 : drwUser.FK_UserTypeID;
            
            //picUser.Image = PublicMethods.ArrayToImage(drwUser.UserImage);

            BaranDataAccess.Security.dstSecurityTableAdapters.spr_AccessibleItemsForCurrentUser_SelectTableAdapter adpAccessibleItems =
                new BaranDataAccess.Security.dstSecurityTableAdapters.spr_AccessibleItemsForCurrentUser_SelectTableAdapter();

            BaranDataAccess.Security.dstSecurity.spr_AccessibleItemsForCurrentUser_SelectDataTable tblAccessibleItems =
                new BaranDataAccess.Security.dstSecurity.spr_AccessibleItemsForCurrentUser_SelectDataTable();

            BaranDataAccess.Security.dstSecurity.spr_AccessibleItemsForCurrentUser_SelectRow drwAccessibleItems;

            long lngUserID = (long)P_tblUserToUpdate.Rows[0]["UserID"];
            tblAccessibleItems = adpAccessibleItems.GetAccessibleItemsForCurrentUserTable(lngUserID);            

            bool
                 blnSave = false
                , blnChange = false
                , blnDelete = false
                , blnNew = false
                , blnPrint = false
                    ;

            foreach (TreeNode trnPackage in trvItems.Nodes)
            {
                Boolean
                    blnAllChecked = true;

                foreach (TreeNode trnItem in trnPackage.Nodes)
                {
                    string strFilter = "FK_ItemID = " + Convert.ToInt32(trnItem.Tag);
                    tblAccessibleItems.Select(strFilter, "");
                    if (tblAccessibleItems.Select(strFilter, "").GetLength(0) == 0)
                        blnAllChecked = false;
                    else
                    {
                        drwAccessibleItems = tblAccessibleItems[0];
                        trnItem.Checked = true;
                        trnItem.Nodes[(int)enmAccessLevelItemsID.Save].Checked = drwAccessibleItems.IsbitSaveNull() ? false : drwAccessibleItems.bitSave;
                        trnItem.Nodes[(int)enmAccessLevelItemsID.Change].Checked = drwAccessibleItems.IsbitChangeNull() ? false : drwAccessibleItems.bitChange;
                        trnItem.Nodes[(int)enmAccessLevelItemsID.Delete].Checked = drwAccessibleItems.IsbitDeleteNull() ? false : drwAccessibleItems.bitDelete;
                        trnItem.Nodes[(int)enmAccessLevelItemsID.New].Checked = drwAccessibleItems.IsbitNewNull() ? false : drwAccessibleItems.bitNew;
                        trnItem.Nodes[(int)enmAccessLevelItemsID.Print].Checked = drwAccessibleItems.IsbitPrintNull() ? false : drwAccessibleItems.bitPrint;

                        blnSave = drwAccessibleItems.IsbitSaveNull() ? false : drwAccessibleItems.bitSave;
                        blnChange = drwAccessibleItems.IsbitChangeNull() ? false : drwAccessibleItems.bitChange;
                        blnDelete = drwAccessibleItems.IsbitDeleteNull() ? false : drwAccessibleItems.bitDelete;
                        blnNew = drwAccessibleItems.IsbitNewNull() ? false : drwAccessibleItems.bitNew;
                        blnPrint = drwAccessibleItems.IsbitPrintNull() ? false : drwAccessibleItems.bitPrint;

                    }

                }
                if (blnAllChecked)
                    trnPackage.Checked = true;

            }
            if (blnSave)
                chkSave.Checked = true;
            if (blnChange)
                chkChange.Checked = true;
            if (blnDelete)
                chkDelete.Checked = true;
            if (blnNew)
                chkNew.Checked = true;
            if (blnPrint)
                chkPrint.Checked = true;

        }

        private bool UserInfoValidation()
        {
            bool blnResult = true;

            if (txtName.Text.Trim() == string.Empty)
            {
                //this.lblMessage.Text = BaranResources.NameTextBoxIsEmptyMessage;
                OnMessage(BaranResources.NameTextBoxIsEmptyMessage, PublicEnum.EnmMessageCategory.Warning);
                txtName.Focus();
                blnResult = false;
            }

            else if (txtFamily.Text.Trim() == string.Empty)
            {
                //this.lblMessage.Text = BaranResources.FamilyTextBoxIsEmptyMessage ;
                OnMessage(BaranResources.FamilyTextBoxIsEmptyMessage, PublicEnum.EnmMessageCategory.Warning);
                txtFamily.Focus();
                blnResult = false;
            }

            else if (txtUserName.Text.Trim() == string.Empty)
            {
                //this.lblMessage.Text = BaranResources.UserNameTextBoxIsEmptyMessage;
                OnMessage(BaranResources.UserNameTextBoxIsEmptyMessage, PublicEnum.EnmMessageCategory.Warning);
                txtUserName.Focus();
                blnResult = false;
            }

            return blnResult;

        }

        public override void OnSave()
        {
            base.OnSave();

            if (!UserInfoValidation()) return;

            if (P_tblUserToUpdate.Count > 0)
            {
                this.OnChange();
                return;
            }

            DialogResult msgResult = MessageBoxX.ShowMessageBox(PublicEnum.EnmMessageType.msgSaveConfirm);
            if (msgResult == DialogResult.No) return;

            string strUserName = txtUserName.Text.Trim();
            string strPassword = txtPassword.Text.Trim();
            string strFirstName = txtName.Text.Trim();
            string strLastName = txtFamily.Text.Trim();
            string strMobile = txtMobile.Text.Trim();
            string strTelephone = txtTelephone.Text.Trim();
            string strEmail = txtEmail.Text.Trim();
            string strDescripton = txtDescription.Text.Trim();

            int intShopID = 22;// (int)cmbShop.Value;

            DateTime? dteUpdateDate = DateTime.Now;

            bool blnIsActiveUser = true;
            bool blnIsManager = chkIsManager.Checked;
            bool blnIsAccountant = chkAccountant.Checked;
            bool blnIsSalesPerson = chkSalesPerson.Checked;
            bool blnIsOtherStaff = chkOtherStaff.Checked;

            string strUserAddress = txtAddress.Text.Trim();
            DateTime dteCreateDate = DateTime.Now;

            long lngUserID = CurrentUser.Instance.UserID;

            UserImage = Baran.Classes.Common.PublicMethods.ImageToArray(picUser.Image);

            try
            {

                using (TransactionScope scope = new TransactionScope())
                {
                    BaranDataAccess.Security.dstSecurity.spr_Sec_SelectUserByUserName_SelectDataTable tblUser = new
                        BaranDataAccess.Security.dstSecurity.spr_Sec_SelectUserByUserName_SelectDataTable();

                    BaranDataAccess.Security.dstSecurityTableAdapters.spr_Sec_SelectUserByUserName_SelectTableAdapter adpUser =
                        new BaranDataAccess.Security.dstSecurityTableAdapters.spr_Sec_SelectUserByUserName_SelectTableAdapter();

                    tblUser = adpUser.GetUsersTableByUserName(txtUserName.Text.Trim());

                    if (tblUser.Rows.Count > 0)
                    {
                        MessageBox.Show(BaranResources.DuplicateUsererrorMessage);
                        return;
                    }

                    BaranDataAccess.Security.dstSecurityTableAdapters.spr_Sec_Users_SelectTableAdapter adpNewUserInsertion =
                        new BaranDataAccess.Security.dstSecurityTableAdapters.spr_Sec_Users_SelectTableAdapter();

                    lngUserID = Convert.ToInt64(adpNewUserInsertion.spr_Sec_User_Insert(strUserName,
                                                                                        strPassword,
                                                                                        blnIsActiveUser,
                                                                                        strFirstName,
                                                                                        strLastName,
                                                                                        strMobile,
                                                                                        strTelephone,
                                                                                        strEmail,
                                                                                        intShopID,
                                                                                        strUserAddress,
                                                                                        strDescripton,
                                                                                        blnIsManager,
                                                                                        blnIsAccountant,
                                                                                        blnIsSalesPerson,
                                                                                        blnIsOtherStaff,
                                                                                        lngUserID,
                                                                                        
                                                                                        intUserTypeID,
                                                                                        intCompanyID,
                                                                                        intCollectionID,
                                                                                        intSubcollectionID,
                                                                                        intPartID));

                    BaranDataAccess.Security.dstSecurity.spr_Sec_ItemUsers_SelectDataTable tblItemUser =
                        new dstSecurity.spr_Sec_ItemUsers_SelectDataTable();

                    BaranDataAccess.Security.dstSecurityTableAdapters.spr_Sec_ItemUsers_SelectTableAdapter adpItemUser =
                        new BaranDataAccess.Security.dstSecurityTableAdapters.spr_Sec_ItemUsers_SelectTableAdapter();


                    foreach (TreeNode trnPackage in trvItems.Nodes)
                    {

                        foreach (TreeNode trnItem in trnPackage.Nodes)
                        {
                            if (trnItem.Checked)
                            {
                                dstSecurity.spr_Sec_ItemUsers_SelectRow drwItemUser = tblItemUser.Newspr_Sec_ItemUsers_SelectRow();

                                drwItemUser.FK_ItemID = (int)trnItem.Tag;
                                drwItemUser.FK_UserID = lngUserID;
                                drwItemUser.HasWrite = true;
                                drwItemUser.bitSave = trnItem.Nodes[(int)enmAccessLevelItemsID.Save].Checked;
                                drwItemUser.bitChange = trnItem.Nodes[(int)enmAccessLevelItemsID.Change].Checked;
                                drwItemUser.bitDelete = trnItem.Nodes[(int)enmAccessLevelItemsID.Delete].Checked;
                                drwItemUser.bitNew = trnItem.Nodes[(int)enmAccessLevelItemsID.New].Checked;
                                drwItemUser.bitPrint = trnItem.Nodes[(int)enmAccessLevelItemsID.Print].Checked;
                                drwItemUser.IsActive = true;

                                tblItemUser.Rows.Add(drwItemUser);
                            }
                        }
                    }

                    adpItemUser.Update(tblItemUser);
                    scope.Complete();
                    this.lblMessage.Text = BaranResources.SaveSuccessful;
                }
            }
            catch
            {
                MessageBox.Show(BaranResources.NewUserInsertionInDBError);
                return;
            }


        }

        public override void OnChange()
        {
            base.OnChange();


            BaranDataAccess.Security.dstSecurityTableAdapters.spr_Sec_Users_SelectTableAdapter adpUsers =
                new BaranDataAccess.Security.dstSecurityTableAdapters.spr_Sec_Users_SelectTableAdapter();

            dstSecurity.spr_Sec_SelectUsersByUserID_SelectRow drwUser = (dstSecurity.spr_Sec_SelectUsersByUserID_SelectRow)P_tblUserToUpdate.Rows[0];

            long lngChangeUserID = (long)this.P_tblUserToUpdate.Rows[0]["UserID"];

            drwUser.IsActive = chkIsActive.Checked;
            drwUser.FK_UserTypeID = 1;
            drwUser.Email = txtEmail.Text.Trim();
            drwUser.FirstName = txtName.Text.Trim();
            drwUser.LastName = txtFamily.Text.Trim();
            drwUser.Mobile = txtMobile.Text.Trim();
            drwUser.Telephone = txtTelephone.Text.Trim();
            drwUser.IsManager = chkIsManager.Checked;
            drwUser.IsAccountant = chkAccountant.Checked;
            drwUser.IsSalesPerson = chkSalesPerson.Checked;
            drwUser.IsOtherStaff = chkOtherStaff.Checked;
            drwUser.CreateDate = DateTime.Now;
            drwUser.FK_ShopID = Convert.ToInt32( cmbShop.Value);
            drwUser.UserImage = Baran.Classes.Common.PublicMethods.ImageToArray(picUser.Image);
            
            drwUser.FK_UserTypeID = Convert.ToInt32( intUserTypeID);
            if (intCompanyID != null)
                drwUser.Fk_CompanyID = Convert.ToInt32(intCompanyID);
            if (intCollectionID != null)
                drwUser.Fk_CollectionID = Convert.ToInt32(intCollectionID);
            if (intSubcollectionID != null)
                drwUser.Fk_SubcollectionID = Convert.ToInt32(intSubcollectionID);
            if (intPartID != null)
                drwUser.Fk_PartID = Convert.ToInt32(intPartID);
            try
            {
                //using (TransactionScope scope = new TransactionScope())
                //{

                    adpUsers.Update(drwUser);
                

                    BaranDataAccess.Security.dstSecurityTableAdapters.spr_Sec_ItemUsers_SelectTableAdapter adpItemUsers =
                        new BaranDataAccess.Security.dstSecurityTableAdapters.spr_Sec_ItemUsers_SelectTableAdapter();
                    
                    tblItemUserToUpdate = adpItemUsers.GetItemUsersTable(drwUser.UserID);

                    foreach (DataRow Drow in tblItemUserToUpdate.Rows)
                    {
                        Drow.Delete();
                    }


                    foreach (TreeNode trnPackage in trvItems.Nodes)
                    {

                        foreach (TreeNode trnItem in trnPackage.Nodes)
                        {
                            if (trnItem.Checked)
                            {
                                dstSecurity.spr_Sec_ItemUsers_SelectRow drwItemUser = tblItemUserToUpdate.Newspr_Sec_ItemUsers_SelectRow();

                                drwItemUser.FK_ItemID = (int)trnItem.Tag;
                                drwItemUser.FK_UserID = drwUser.UserID;
                                drwItemUser.HasWrite = true;
                                drwItemUser.bitSave = trnItem.Nodes[(int)enmAccessLevelItemsID.Save].Checked;
                                drwItemUser.bitChange = trnItem.Nodes[(int)enmAccessLevelItemsID.Change].Checked;
                                drwItemUser.bitDelete = trnItem.Nodes[(int)enmAccessLevelItemsID.Delete].Checked;
                                drwItemUser.bitNew = trnItem.Nodes[(int)enmAccessLevelItemsID.New].Checked;
                                drwItemUser.bitPrint = trnItem.Nodes[(int)enmAccessLevelItemsID.Print].Checked;
                                drwItemUser.IsActive = true;

                                tblItemUserToUpdate.Rows.Add(drwItemUser);
                            }
                        }
                    }


                    adpItemUsers.Update(tblItemUserToUpdate);
                    tblItemUserToUpdate = adpItemUsers.GetItemUsersTable(lngChangeUserID);

                    //scope.Complete();
                    //this.lblMessage.Text = BaranResources.EditSuccessful;
                    OnMessage(BaranResources.EditSuccessful, PublicEnum.EnmMessageCategory.Success);
                //}
            }
            catch
            {
                this.lblMessage.Text = BaranResources.EditFail;
                return;
            }
        }

        public override void OnClear()
        {
            base.OnClear();
            ControlsSetting.ClearControls(grbInfoGathering.Controls);
            ControlsSetting.ClearControls(grbPersonalInfo.Controls);
            ControlsSetting.ClearControls(grbUserType.Controls);
            ControlsSetting.ClearControls(grbAccessLevel.Controls);

            foreach (TreeNode trnPackages in trvItems.Nodes)
            {
                trnPackages.Checked = false;
                foreach (TreeNode trnItems in trnPackages.Nodes)
                {
                    trnItems.Checked = false;
                    foreach (TreeNode trnAccessLevel in trnItems.Nodes)
                    {
                        trnAccessLevel.Checked = false;
                    }
                }
                
                
            }
        }

        private void AccessLeveCheckBox_AfterChanged(int prmNode, bool prmChecked)
        {
            for (int i = 0; i <= trvItems.Nodes.Count - 1; i++)
            {
                for (int p = 0; p <= trvItems.Nodes[i].Nodes.Count - 1; p++)
                    if (trvItems.Nodes[i].Nodes[p].Checked == true)
                        if (!prmChecked)
                            trvItems.Nodes[i].Nodes[p].Nodes[prmNode].Checked = prmChecked;
            }
        }


    #endregion // End Methods -------------------------------------------------------------------------

    #region Events

        private void frmUsers_Load(object sender, EventArgs e)
        {
            //Baran.Classes.Common.ComboBoxSetting.FillComboBox(PublicEnum.EnmComboSource.srcShops, cmbShop, "");
            Baran.Classes.Common.ComboBoxSetting.FillComboBox(PublicEnum.EnmComboSource.srcUserType, cmbUserType, "");
            this.SetAccessibleItemsTree();
            this.SetFeilds();
        }

        private void frmUsers_Activated(object sender, EventArgs e)
        {
            Baran.frmMain ofrmMain = Baran.frmMain.Instanc;

            ofrmMain.EnableToolBarItems(cnsToolStripButton.Cancel, cnsToolStripButton.Save, cnsToolStripButton.Clear);
            ofrmMain.EnableMenuStripItems(cnsMenustripItems.Cancel, cnsMenustripItems.Save, cnsMenustripItems.Clear);
        }

        private void trvItems_AfterCheck(object sender, TreeViewEventArgs e)
        {

            if (e.Action == TreeViewAction.Unknown) return;

            for (int i = 0; i <= e.Node.Nodes.Count - 1; i++)
            {
                e.Node.Nodes[i].Checked = e.Node.Checked;
                for (int p = 0; p <= e.Node.Nodes[i].Nodes.Count - 1; p++)
                {
                    e.Node.Nodes[i].Nodes[p].Checked = e.Node.Checked;
                }
            }

            if (e.Node.Parent != null && e.Node.Level != 2)
            {

                Boolean blnAllChecked = true;
                TreeNode trnPachage = e.Node.Parent;

                for (int j = 0; j <= trnPachage.Nodes.Count - 1; j++)
                {
                    if (trnPachage.Nodes[j].Checked == false)
                    {
                        blnAllChecked = false;
                        break;
                    }

                }
                trnPachage.Checked = blnAllChecked;

            }


            if (e.Node.Level == 2)
                if (e.Node.Checked)
                    e.Node.Parent.Checked = e.Node.Checked;

            bool
                 blnSave = false
                , blnChange = false
                , blnDelete = false
                , blnNew = false
                , blnPrint = false
                ;

            for (int i = 0; i <= trvItems.Nodes.Count - 1; i++)
            {
                for (int p = 0; p <= trvItems.Nodes[i].Nodes.Count - 1; p++)
                {
                    for (int q = 0; q <= trvItems.Nodes[i].Nodes[p].Nodes.Count - 1; q++)
                    {
                        if (trvItems.Nodes[i].Nodes[p].Nodes[(int)enmAccessLevelItemsID.Save].Checked)
                            blnSave = true;
                        if (trvItems.Nodes[i].Nodes[p].Nodes[(int)enmAccessLevelItemsID.Change].Checked)
                            blnChange = true;
                        if (trvItems.Nodes[i].Nodes[p].Nodes[(int)enmAccessLevelItemsID.Delete].Checked)
                            blnDelete = true;
                        if (trvItems.Nodes[i].Nodes[p].Nodes[(int)enmAccessLevelItemsID.New].Checked)
                            blnNew = true;
                        if (trvItems.Nodes[i].Nodes[p].Nodes[(int)enmAccessLevelItemsID.Print].Checked)
                            blnPrint = true;
                    }
                }
            }

            chkSave.Checked = blnSave;
            chkChange.Checked = blnChange;
            chkDelete.Checked = blnDelete;
            chkNew.Checked = blnNew;
            chkPrint.Checked = blnPrint;

        }

        private void chkSave_CheckedChanged(object sender, EventArgs e)
        {
            this.AccessLeveCheckBox_AfterChanged((int)enmAccessLevelItemsID.Save, chkSave.Checked);
        }

        private void chkChange_CheckedChanged(object sender, EventArgs e)
        {
            this.AccessLeveCheckBox_AfterChanged((int)enmAccessLevelItemsID.Change, chkChange.Checked);
        }

        private void chkDelete_CheckedChanged(object sender, EventArgs e)
        {
            this.AccessLeveCheckBox_AfterChanged((int)enmAccessLevelItemsID.Delete, chkDelete.Checked);
        }

        private void chkNew_CheckedChanged(object sender, EventArgs e)
        {
            this.AccessLeveCheckBox_AfterChanged((int)enmAccessLevelItemsID.New, chkNew.Checked);
        }

        private void chkPrint_CheckedChanged(object sender, EventArgs e)
        {
            this.AccessLeveCheckBox_AfterChanged((int)enmAccessLevelItemsID.Print, chkPrint.Checked);
        }

    #endregion // End Events --------------------------------------------------------------------------

        private void btnShowPic_Click(object sender, EventArgs e)
        {
            picUser.Image = Baran.Classes.Common.PublicMethods.PictureOpenFileDialog();
        }

        private void cmbUserType_ValueChanged(object sender, EventArgs e)
        {
            cmbUserAccessLevel.Value = null;
            intUserTypeID = Convert.ToInt32(cmbUserType.Value);
            intCompanyID = null; intCollectionID = null; intSubcollectionID = null; intPartID = null;

            if (intUserTypeID == 1)
            {
                Baran.Classes.Common.ComboBoxSetting.FillComboBox(PublicEnum.EnmComboSource.srcCompany, cmbUserAccessLevel, "");
            }
            else if (intUserTypeID == 2)
            {
                Baran.Classes.Common.ComboBoxSetting.FillComboBox(PublicEnum.EnmComboSource.srcCollection, cmbUserAccessLevel, "");
            }
            else if (intUserTypeID == 3)
            {
                Baran.Classes.Common.ComboBoxSetting.FillComboBox(PublicEnum.EnmComboSource.srcSubcollection, cmbUserAccessLevel, "");
            }
            else if (intUserTypeID == 4)
            {
                Baran.Classes.Common.ComboBoxSetting.FillComboBox(PublicEnum.EnmComboSource.srcPart, cmbUserAccessLevel, "");
            }
        }

        private void cmbUserAccessLevel_ValueChanged(object sender, EventArgs e)
        {
            intCompanyID = null; intCollectionID = null; intSubcollectionID = null; intPartID = null;

            try
            {
                if (intUserTypeID == null) return;
                if (intUserTypeID == 1)
                {
                    intCompanyID = Convert.ToInt32(cmbUserAccessLevel.Value);
                }
                else if (intUserTypeID == 2)
                {
                    intCollectionID = Convert.ToInt32(cmbUserAccessLevel.Value);
                }
                else if (intUserTypeID == 3)
                {
                    intSubcollectionID = Convert.ToInt32(cmbUserAccessLevel.Value);
                }
                else if (intUserTypeID == 4)
                {
                    intPartID = Convert.ToInt32(cmbUserAccessLevel.Value);
                }
            }
            catch { }
        }

    }
}
