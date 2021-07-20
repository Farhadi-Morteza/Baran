using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BaranLibrary
{
    static public class CurrentShop
    {
        static BaranDataAccess.Security.dstSecurity.spr_ShopCheckForCurrentUser_SelectDataTable currentShopInfo = new BaranDataAccess.Security.dstSecurity.spr_ShopCheckForCurrentUser_SelectDataTable();
        static public BaranDataAccess.Security.dstSecurity.spr_ShopCheckForCurrentUser_SelectDataTable CurrentShopInfo
        {
            get
            {
                return currentShopInfo;
            }
            set
            {
                currentShopInfo = value;
            }
        }
    }
}
