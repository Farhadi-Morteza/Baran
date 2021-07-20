using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Baran.Classes.Singleton
{
    class mdiParent
    {
       private static mdiParent _instance;
        public static mdiParent Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new mdiParent();
                }
                return _instance;
            }
            set
            {
                _instance = value;
            }

        }


        private mdiParent()
        {
            _frmMain = frmMain.Instanc;
        }


        private System.Windows.Forms.Form _frmMain;
        public System.Windows.Forms.Form FrmMain
        {
            get
            {
                return _frmMain;
            }
            set
            {
                _frmMain = value;
            }
        }
    }
    
}
