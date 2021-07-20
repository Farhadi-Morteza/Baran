using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Baran.Classes.Common
{
    public class AccessibleItemsForCurrentUser
    {
        private static AccessibleItemsForCurrentUser _instance;
        public static AccessibleItemsForCurrentUser Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new AccessibleItemsForCurrentUser();

                return _instance;
            }
        }

        private AccessibleItemsForCurrentUser()
        {
            BaranDataAccess.Security.dstSecurityTableAdapters.spr_AccessibleItemsForCurrentUser_SelectTableAdapter adpAccessibleItems = 
                new BaranDataAccess.Security.dstSecurityTableAdapters.spr_AccessibleItemsForCurrentUser_SelectTableAdapter();

            tblAccessibleItems = adpAccessibleItems.GetAccessibleItemsForCurrentUserTable(CurrentUser.Instance.UserID);
        }

        private BaranDataAccess.Security.dstSecurity.spr_AccessibleItemsForCurrentUser_SelectDataTable _tblAccessibleItems =
            new BaranDataAccess.Security.dstSecurity.spr_AccessibleItemsForCurrentUser_SelectDataTable();
        public BaranDataAccess.Security.dstSecurity.spr_AccessibleItemsForCurrentUser_SelectDataTable tblAccessibleItems
        {
            get
            {
                return _tblAccessibleItems;
            }
            set
            {
                _tblAccessibleItems = value;
            }
        }
    }
}
