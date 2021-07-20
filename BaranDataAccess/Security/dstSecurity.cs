namespace BaranDataAccess.Security
{
    
    
    public partial class dstSecurity {

        public static dstSecurity GetUsers()
        {
            dstSecurity returnDst = new dstSecurity();

            dstSecurityTableAdapters.spr_Sec_Users_SelectTableAdapter adapter =
                new BaranDataAccess.Security.dstSecurityTableAdapters.spr_Sec_Users_SelectTableAdapter();

            try
            {
                adapter.FillUsersTable(returnDst.spr_Sec_Users_Select);
            }
            catch
            {
                returnDst = null;
            }
            return returnDst;
        }

        public static dstSecurity GetShops()
        {
            dstSecurity returnDst = new dstSecurity();

            dstSecurityTableAdapters.spr_Sec_Shop_SelectTableAdapter adapter =
                new BaranDataAccess.Security.dstSecurityTableAdapters.spr_Sec_Shop_SelectTableAdapter();

            try
            {
                adapter.FillShopsTable(returnDst.spr_Sec_Shop_Select);
            }
            catch
            {
                returnDst = null;
            }
            return returnDst;
        }

        public static dstSecurity GetDatabases()
        {
            dstSecurity returnDst = new dstSecurity();

            dstSecurityTableAdapters.spr_Sec_Databases_SelectTableAdapter adapter =
                new dstSecurityTableAdapters.spr_Sec_Databases_SelectTableAdapter();

            try
            {
                adapter.FillDataBaseTable(returnDst.spr_Sec_Databases_Select);
            }
            catch
            {
                returnDst = null;
            }
            return returnDst;
        }

        public static dstSecurity GetUserType()
        {
            dstSecurity returnDst = new dstSecurity();

            dstSecurityTableAdapters.spr_Sec_UserType_SelectTableAdapter adapter =
                new dstSecurityTableAdapters.spr_Sec_UserType_SelectTableAdapter();

            try
            {
                adapter.FillUserTypeTable(returnDst.spr_Sec_UserType_Select);
            }
            catch 
            {
                returnDst = null;
            }
            return returnDst;
        }
    }
}
