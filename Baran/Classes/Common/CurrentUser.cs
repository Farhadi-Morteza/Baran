using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Baran.Classes.Common
{
    class CurrentUser
    {

        private static CurrentUser _instance;
        public static CurrentUser Instance
        {
            get
            {
                if(_instance == null)
                    _instance  = new CurrentUser();
                
                return _instance;
            }
            set
            {
                _instance = value;
            }
        }

        BaranDataAccess.Security.dstSecurity.spr_Sec_UserAuthentication_SelectRow drwUser = BaranLibrary.CurrentUser.CurrentUserInfo.Newspr_Sec_UserAuthentication_SelectRow();

        private CurrentUser()
        {
            LoadCurrentUser();

            _userID = drwUser.UserID;
            _firstName = drwUser.FirstName;
            _lastName = drwUser.LastName;
            _fullName = drwUser.FirstName + ' ' + drwUser.LastName;
            _shopID = drwUser.FK_ShopID;
            _UserName = drwUser.UserName;
        }

        private void LoadCurrentUser()
        {
            drwUser = (BaranDataAccess.Security.dstSecurity.spr_Sec_UserAuthentication_SelectRow)BaranLibrary.CurrentUser.CurrentUserInfo.Rows[0];
        }

        #region variables

        private int _userID;
        public int UserID
        {
            get
            {
                return _userID;
            }
            set
            {
                _userID = value;
            }
        }

        private string _firstName ;
        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                _firstName = value;
            }
        }

        private string _lastName;
        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                _lastName = value;
            }
        }

        private string _fullName;
        public string FullName
        {
            get
            {
                return _fullName;
            }
            set
            {
                _fullName = value;
            }
        }

        private int _shopID;
        public int ShopID
        {
            get
            {
                return _shopID;
            }
            set
            {
                _shopID = value;
            }
        }

        private string _UserName;
        public string UserName
        {
            get
            {
                return _UserName;
            }
            set
            {
                _UserName = value;
            }
       }


        #endregion



    
    }

}
