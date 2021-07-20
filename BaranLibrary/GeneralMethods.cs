using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BaranLibrary
{
    static public class GeneralMethods
    {
        static private BaranDataAccess.DateAdjustement.dstDateTableAdapters.spr_GetServerDate_SelectTableAdapter adpDate = new BaranDataAccess.DateAdjustement.dstDateTableAdapters.spr_GetServerDate_SelectTableAdapter();
        static private BaranDataAccess.DateAdjustement.dstDate.spr_GetServerDate_SelectDataTable tblDate = new BaranDataAccess.DateAdjustement.dstDate.spr_GetServerDate_SelectDataTable();
        static private BaranDataAccess.DateAdjustement.dstDate.spr_GetServerDate_SelectRow drwDate = tblDate.Newspr_GetServerDate_SelectRow();

        static public DateTime GetServerDate()
        {
            tblDate = adpDate.GetDate();
            drwDate = (BaranDataAccess.DateAdjustement.dstDate.spr_GetServerDate_SelectRow)tblDate.Rows[0];

            CurrentDateShami = string.Format("{0:YYYY/MM/DD HH:MM}", drwDate.ShamsiDateTime);
            CurrentDateMiladi = drwDate.MiladiDate;

            return drwDate.MiladiDate;
        }

        public static string GetServerDateShamsi()
        {
            tblDate = adpDate.GetDate();
            drwDate = (BaranDataAccess.DateAdjustement.dstDate.spr_GetServerDate_SelectRow)tblDate.Rows[0];

            CurrentDateShami = string.Format("{0:YYYY/MM/DD HH:MM}", drwDate.ShamsiDateTime);
            CurrentDateMiladi = drwDate.MiladiDate;

            return drwDate.ShamsiDateTime;
        }

        private static string _CurrentDateShamsi;
        public static string CurrentDateShami
        {
            get
            {
                return _CurrentDateShamsi;
            }
            set
            {
                _CurrentDateShamsi = value;
            }
        }

        private static DateTime _CurrentDateMiladi;
        public static DateTime CurrentDateMiladi
        {
            get
            {
                return _CurrentDateMiladi;
            }
            set
            {
                _CurrentDateMiladi = value;
            }
        }

        static public string PictureFileNamePath(string prmImageName)
        {
            string filename = prmImageName;

            int intIndex = filename.LastIndexOf(@"\");
            string strPath, strFile;

            if (intIndex > -1)
            {
                strPath = filename.Substring(0, intIndex);
                strFile = filename.Substring(filename.LastIndexOf(@"\") + 1);
            }
            else
            {
                strFile = filename.Substring(filename.LastIndexOf(@"\") + 1);
            }

            filename = System.Windows.Forms.Application.StartupPath + @"\Pic\" + strFile;

            if (!System.IO.File.Exists(filename))
            {
                //throw new Exception("Report file does not exist.");
                filename = string.Empty;
            }
            else
            {

            }

            return filename;
        }
    }
}
