using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Globalization;

namespace BaranLibrary
{
    public partial class MaskedDate : UserControl
    {

        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                base.Text = mskDate.Text;
            }
        }

        //public override Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit. Value 
        //{
        //    get
        //    {
        //        return mskDate.Value;
        //    }

        //}

        protected override void OnLeave(EventArgs e)
        {
            base.OnLeave(e);
            if (mskDate.Text == "____/__/__")
                return;

            if (!IsDatePersian(mskDate.Text))
            {
                //if (ISDateShamsi(mskDate.Text) == false)
                MessageBox.Show(" تاریخ نا معتبر می باشد", "DateInvalid Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                mskDate.Focus();
            }

            this.Text = mskDate.Text;
        }   
        
        

// كنترل معتبر بودن يك تاريخ
// strShamsi : ####/##/## ورودى تاريخ شمسى به فرمت

        public bool ISDateShamsi(String strDate)
        {
            bool Result = true;
            string strYear, strMonth, strDay;
            int intYear, intMonth, intDay;
            try
            {
                if (strDate.Length > 10 || strDate.Length < 8)
                    Result = false;

                if (strDate.Length == 8)
                    strDate = "13" + strDate;

                strYear = strDate.Substring(0, 4);
                strMonth = strDate.Substring(5, 2);
                strDay = strDate.Substring(8, 2);

                intYear = Convert.ToUInt16(strYear);
                intMonth = Convert.ToUInt16(strMonth);
                intDay = Convert.ToUInt16(strDay);

                if ((intMonth < 1) &&
                    (intMonth > 12) &&
                    (intDay < 1) &&
                    (intDay > 31) &&
                    (intYear < 1) &&
                    (intYear > 9999))
                    Result = false;

                if ((intMonth > 6) || (intDay >= 31))
                    Result = false;
            }
            catch
            {
            }
            return Result;

        }

        public MaskedDate()
        {
            InitializeComponent();
            //mskDate.Text = FarsiLibrary.Utils.PersianDate.Now.ToString();
            mskDate.Appearance.ForeColor = BaranLibrary.GeneralProperties.BaseControlForeColor;
        }

        public static bool IsDatePersian(string date)
        {
            //if (!MyFramework.License.HardwareKeyAvailable())
            //{
            //    throw new Exception(MyFramework.Computer.HardwareKey.ErrorDescription);
            //}
            try
            {
                Regex RegExp = new Regex(@"^(?<year>\d{2,4})/(?<month>\d{1,2})/(?<day>\d{1,2})$", RegexOptions.ExplicitCapture);
                Match m = RegExp.Match(date);

                if (m.Success == true)
                {
                    int Year = int.Parse(m.Groups["year"].Value);
                    int Month = int.Parse(m.Groups["month"].Value);
                    int Day = int.Parse(m.Groups["day"].Value);

                    if (Year < 1 || Year > 99)
                    {
                        if (Year < 1300 || Year > 1500)
                        {
                            return false;
                        }
                    }

                    if (Month < 1 || Month > 12 || Day < 1 || Day > 31 ||
                        (Day == 31 && Month > 6) ||
                        (Month == 12 && Day == 30 && (Year >1300 && Year <2000)))
                    {
                        return false;
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool IsLeapYearPersian(string Year)
        {
            if (!IsYearPersian(Year))
            {
                return false;
            }
            PersianCalendar Calendar = new PersianCalendar();
            return Calendar.IsLeapYear(int.Parse(Year));
            //return true;
        }
       
        public static bool IsYearPersian(string Year)
        {
            //if (!MyFramework.License.HardwareKeyAvailable())
            //{
            //    throw new Exception(MyFramework.Computer.HardwareKey.ErrorDescription);
            //}
            try
            {
                int x;
                x = int.Parse(Year);
                if (x > 1300 && x < 1400)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
