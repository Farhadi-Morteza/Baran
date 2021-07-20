using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BaranLibrary
{
    static public class CurrentUser
    {
        static BaranDataAccess.Security.dstSecurity.spr_Sec_UserAuthentication_SelectDataTable tblAuthenticatedUser = new BaranDataAccess.Security.dstSecurity.spr_Sec_UserAuthentication_SelectDataTable();

        static public BaranDataAccess.Security.dstSecurity.spr_Sec_UserAuthentication_SelectDataTable CurrentUserInfo
        {
            get
            {
                return tblAuthenticatedUser;
            }
            set
            {
                tblAuthenticatedUser = value;
            }
        }
    }


}
