using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Baran.Classes.Singleton
{
    public class CurrentDate
    {
        private static CurrentDate _instance;
        public static CurrentDate Instance
        {
            get
            {
                if (_instance == null)
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
            string strServerDate = BaranLibrary.GeneralMethods.GetServerDateShamsi();

            _year = strServerDate.Substring(0, 4);
            _month = strServerDate.Substring(5, 2);
            _day = strServerDate.Substring(8, 2);
 
        }

        private string _year;
        public string Year
        {
            get
            {
                return _year;
            }
            set
            {
                _year = value;
            }
        }

        private string _month;
        public string Month
        {
            get
            {
                return _month;
            }
            set
            {
                _month = value;
            }
        }

        private string _day;
        public string Day
        {
            get
            {
                return _day;
            }
            set
            {
                _day = value;
            }
        }
    }
}
