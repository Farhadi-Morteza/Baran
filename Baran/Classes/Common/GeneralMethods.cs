
using System.Data;
namespace Baran
{
    class GeneralMethods
    {
        static public Base_Forms.frmChildBase CreateChildForm(string strFormName)
        {
            try
            {
                string strAssemblyName = Baran.Properties.Settings.Default.ApplicationAssemblyName;
                System.Type FormType = System.Type.GetType(strAssemblyName + "." + strFormName);
                Base_Forms.frmChildBase frmChild = (Base_Forms.frmChildBase)System.Activator.CreateInstance(FormType);
                return frmChild;
            }
            catch (System.Exception ex)
            {

                System.Windows.Forms.MessageBox.Show(BaranResources.UnderConstructionErrorMessage);
                return null;
            }
        }

        static public bool CheckAccessibleItemForCurrentUser(int intItemID)
        {
            bool returnValue = false;

            BaranDataAccess.Security.dstSecurity.spr_AccessibleItemsForCurrentUser_SelectDataTable tblAccessibleItems =
                new BaranDataAccess.Security.dstSecurity.spr_AccessibleItemsForCurrentUser_SelectDataTable();

            BaranDataAccess.Security.dstSecurityTableAdapters.spr_AccessibleItemsForCurrentUser_SelectTableAdapter adpAccessibleItems =
                new BaranDataAccess.Security.dstSecurityTableAdapters.spr_AccessibleItemsForCurrentUser_SelectTableAdapter();

            try
            {
                tblAccessibleItems = adpAccessibleItems.GetAccessibleItemsForCurrentUserTable((long)BaranLibrary.CurrentUser.CurrentUserInfo[0]["UserID"]);

                DataTable tblItem = tblAccessibleItems.Select("ItemID = " + intItemID).CopyToDataTable();

                if (tblItem.Rows.Count > 0)
                {
                    returnValue = true;
                }
                else
                {
                    Baran.Classes.Common.MessageBoxX.ShowMessageBox(BaranResources.DonNotHavePermission);
                    returnValue = false;
                }
            }
            catch
            {
                Baran.Classes.Common.MessageBoxX.ShowMessageBox(BaranResources.DonNotHavePermission);
                returnValue = false;
            }

            return returnValue;
        }

        static public void SetFormSchema(Base_Forms.frmChildBase frmCurrentChild, int prmFormItemID)
        {
            BaranDataAccess.Security.dstSecurity.spr_AccessibleItemsForCurrentUser_SelectDataTable tblAccessibleItems =
                new BaranDataAccess.Security.dstSecurity.spr_AccessibleItemsForCurrentUser_SelectDataTable();

            BaranDataAccess.Security.dstSecurityTableAdapters.spr_AccessibleItemsForCurrentUser_SelectTableAdapter adpAccessibleItems =
                new BaranDataAccess.Security.dstSecurityTableAdapters.spr_AccessibleItemsForCurrentUser_SelectTableAdapter();

            BaranDataAccess.Security.dstSecurity.spr_AccessibleItemsForCurrentUser_SelectRow drwAccessibleItems;

            tblAccessibleItems = adpAccessibleItems.GetAccessibleItemsForCurrentUserTable(Baran.Classes.Common.CurrentUser.Instance.UserID);

            string strFilte = "FK_ItemID = " + prmFormItemID;

            try
            {
                drwAccessibleItems = (BaranDataAccess.Security.dstSecurity.spr_AccessibleItemsForCurrentUser_SelectRow)tblAccessibleItems.Select(strFilte, "")[0];
                if (drwAccessibleItems.ItemID != null)
                {
                    if (frmCurrentChild != null)
                    {

                        System.IO.MemoryStream mstrmTemp = new System.IO.MemoryStream(drwAccessibleItems.ItemLogo);
                        System.Drawing.Bitmap bmpTemp = new System.Drawing.Bitmap(mstrmTemp);
                        frmCurrentChild.FormLogo = bmpTemp;
                        mstrmTemp.Close();

                        frmCurrentChild.FormMessage = drwAccessibleItems.ItemName;
                        frmCurrentChild.Text = drwAccessibleItems.ItemName;
                        frmCurrentChild.FormItemID = drwAccessibleItems.ItemID;
                    }


                }
                else
                {
                    Baran.Classes.Common.MessageBoxX.ShowMessageBox(BaranResources.DonNotHavePermission, System.Windows.Forms.MessageBoxButtons.OK);
                }
            }
            catch
            {

            }


        }

    }
}

