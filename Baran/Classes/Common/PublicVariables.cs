using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Baran.Classes.Common
{
    public static class PublicVariables
    {

        public static Baran.Windows.Forms.PictureBox PicBoxMsg = PictureBoxMsg.Instance.PicBoxX;

        public static object ActiveFormObject;
        public static EventArgs ActiveFormEventArgs;

        private static string _fiscalYearName;
        public static string FiscalYearName
        {
            get
            {
                return _fiscalYearName;
            }
            set
            {
                _fiscalYearName = value;
            }
        }

        private static int _fiscalYearID;
        public static int FiscalYearID
        {
            get
            {
                return _fiscalYearID;
            }
            set
            {
                _fiscalYearID = value;
            }
        }

        private static bool _isCurrentFiscalYear;
        public static bool IsCurretnFiscalYear
        {
            get
            {
                return _isCurrentFiscalYear;
            }
            set
            {
                _isCurrentFiscalYear = value;
            }
        }

        private static bool _isFiscalYearClose;
        public static bool IsFiscalYearClose
        {
            get
            {
                return _isFiscalYearClose;
            }
            set
            {
                _isFiscalYearClose = value;
            }
        }

        private static string _WhereClause = string.Empty;
        public static string WhereClause
        {
            get
            {
                return _WhereClause;
            }
            set
            {
                _WhereClause = value;
            }
        }

        private static int _factorOperationTypeID;
        public static int FactorOperationTypeID
        {
            get 
            {
                return _factorOperationTypeID;
            }
            set
            {
                _factorOperationTypeID = value;
            }
        }

        private static System.Windows.Forms.DialogResult _msgResult;
        public static System.Windows.Forms.DialogResult msgResult
        {
            get
            {
                return _msgResult;
            }
            set
            {
                _msgResult = value;
            }
        }

        private static string _documentPath = string.Empty;
        public static string DocumentPath
        {
            get
            {
                return _documentPath = System.Windows.Forms.Application.StartupPath + @"\Doc\";
            }
        }
    }
}
