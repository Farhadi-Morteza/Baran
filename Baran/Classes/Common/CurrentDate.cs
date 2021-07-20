using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Baran.Classes.Common
{
    public class CurrentDate
    {
        private static CurrentDate _instance;
        public static CurrentDate Instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new CurrentDate();
                }
                return _instance;
            }
            set
            {
                _instance = value;
            }
           
        }





        private CurrentDate()
        {
              BaranDataAccess.DateAdjustement.dstDateTableAdapters.spr_GetServerDate_SelectTableAdapter adpDate = 
                  new BaranDataAccess.DateAdjustement.dstDateTableAdapters.spr_GetServerDate_SelectTableAdapter();
              BaranDataAccess.DateAdjustement.dstDate.spr_GetServerDate_SelectDataTable tblDate = 
                  new BaranDataAccess.DateAdjustement.dstDate.spr_GetServerDate_SelectDataTable();
              BaranDataAccess.DateAdjustement.dstDate.spr_GetServerDate_SelectRow drwDate = tblDate.Newspr_GetServerDate_SelectRow();

              tblDate = adpDate.GetDate();
              drwDate = (BaranDataAccess.DateAdjustement.dstDate.spr_GetServerDate_SelectRow)tblDate.Rows[0];

              _currentDateMiladi =  drwDate.MiladiDate; 
              _currentDateShamsi = drwDate.ShamsiDate;
              _currentYearShamsi = drwDate.ShamsiYear;
        }


        #region Propertise

        private DateTime _currentDateMiladi;
        public DateTime CurrentDateMiladi
        {
            get
            {
                return _currentDateMiladi;
            }
            set
            {
                _currentDateMiladi = value;
            }
        }

        private string _currentDateShamsi ;
        public string CurrentDateShamsi
        {
            get
            {
                return _currentDateShamsi;
            }
            set
            {
                _currentDateShamsi = value;
            }
        }

        private string _currentYearShamsi;
        public string CurrentYearShamsi
        {
            get
            {
                return _currentYearShamsi;
            }
            set
            {
                _currentYearShamsi = value;
            }
        }


        #endregion
    }

}
