using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using FarsiLibrary.Utils;

namespace Baran.Classes.Common
{
    public enum DateFormat
    {
        yymmdd,
        yyyymmdd,
        DDmmMMyyyy
    }
    public enum DateToWordFormat
    {
        dmy,
        dmyyyy
    }

    public enum DateInterval
    {
        Day,
        Hour,
        Minute,
        Second,
        Millisecond
    }     
    class DateTimeUtility
    {
        public static DateTime ToGregorian(string PersianDate)
        {
            //if (!MyFramework.License.HardwareKeyAvailable())
            //{
            //    throw new Exception(MyFramework.Computer.HardwareKey.ErrorDescription);
            //}
            try
            {
                if (!IsDatePersian(PersianDate))
                {
                    throw new Exception("Persian date formt is wrong.");
                }
                PersianCalendar Calendar = new PersianCalendar();
                Regex RegExp = new Regex(@"^(?<year>\d{2,4})/(?<month>\d{1,2})/(?<day>\d{1,2})$", RegexOptions.ExplicitCapture);
                Match m = RegExp.Match(PersianDate);

                int Year;
                int Month;
                int Day;
                if (m.Groups["year"].Value.Length == 2)
                {
                    Year = int.Parse("13" + m.Groups["year"].Value);
                }
                else
                {
                    Year = int.Parse(m.Groups["year"].Value);
                }
                Month = int.Parse(m.Groups["month"].Value);
                Day = int.Parse(m.Groups["day"].Value);


                //return new DateTime(Year, Month, Day, Calendar);
                var p = Calendar.ToDateTime(Year, Month, Day, 0, 0, 0, 0);
                return Calendar.ToDateTime(Year, Month, Day, 0, 0, 0, 0);
            }
            catch (Exception)
            {
                throw new Exception("Can not convert to Gregorian date.");
            }
        }

        public static DateTime ToGregorian(int PersianYear, int PersianMonth, int PersianDay)
        {
            PersianCalendar Calendar = new PersianCalendar();
            return Calendar.ToDateTime(PersianYear, PersianMonth, PersianDay, 0, 0, 0, 0);
        }

        public static string ToPersian(DateTime GregorianDate)
        {
            //if (!MyFramework.License.HardwareKeyAvailable())
            //{
            //    throw new Exception(MyFramework.Computer.HardwareKey.ErrorDescription);
            //}
            PersianCalendar Calendar = new PersianCalendar();
            string Year = Calendar.GetYear(GregorianDate).ToString("0000");
            string Month = Calendar.GetMonth(GregorianDate).ToString("00");
            string Day = Calendar.GetDayOfMonth(GregorianDate).ToString("00");

            return Year + "/" + Month + "/" + Day;
        }

        /// <summary>
        /// Return The Shamsi Date With a Specified Format
        /// 1:d Small DateTime
        /// 2:g FullDateTime
        /// 3:G 
        /// </summary>
        /// <param name="GregorianDate"></param>
        /// <param name="format"> format Type d,g,G,s,u </param>
        /// <returns>Shamsi Date</returns>
        public static string ToPersianFullDate(DateTime GregorianDate)
        {
            FarsiLibrary.Utils.PersianDate result = FarsiLibrary.Utils.PersianDateConverter.ToPersianDate(GregorianDate);
            string output = result.ToString("s");
            output = output.Replace("T", "").Replace("-", "/").Insert(10, " ").Remove(output.Length - 3, 3);
            return output;
        }

        public static string ToPersian(DateTime GregorianDate, DateFormat Format)
        {
            PersianCalendar Calendar = new PersianCalendar();
            string Year = Calendar.GetYear(GregorianDate).ToString("0000");
            string Month = Calendar.GetMonth(GregorianDate).ToString("00");
            string Day = Calendar.GetDayOfMonth(GregorianDate).ToString("00");
            string ReturnValue = string.Empty;

            switch (Format)
            {
                case DateFormat.yymmdd:
                    ReturnValue = Year.Substring(2, 2) + "/" + Month + "/" + Day;
                    break;
                case DateFormat.yyyymmdd:
                    ReturnValue = Year + "/" + Month + "/" + Day;
                    break;
                case DateFormat.DDmmMMyyyy:
                    ReturnValue = DayNamePersian(GregorianDate) + Day + MonthNamePersian(GregorianDate) + Year;
                    break;
            }
            return ReturnValue;
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
                        (Month == 12 && Day == 30 && (IsLeapYearPersian(Year.ToString()) == false)))
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

        public static bool IsDateGregorian(DateTime date)
        {
            //if (!MyFramework.License.HardwareKeyAvailable())
            //{
            //    throw new Exception(MyFramework.Computer.HardwareKey.ErrorDescription);
            //}
            try
            {
                DateTime x;
                x = DateTime.Parse(date.ToString());

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool IsDateGregorian(string date)
        {
            try
            {
                DateTime x;
                x = DateTime.Parse(date);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool IsTime(string time)
        {
            try
            {
                Regex RegExp;
                Match m;

                RegExp = new Regex(@"^(?<hour>\d{1,2}):(?<minute>\d{1,2}):(?<secound>\d{1,2})$", RegexOptions.ExplicitCapture);
                m = RegExp.Match(time);

                if (m.Success == true)
                {
                    int Hour = int.Parse(m.Groups["hour"].Value);
                    int Minute = int.Parse(m.Groups["minute"].Value);
                    int Secound = int.Parse(m.Groups["secound"].Value);

                    if (Hour < 1 || Hour > 24)
                    {
                        return false;
                    }

                    if (Minute < 0 || Minute > 59)
                    {
                        return false;
                    }
                    if (Secound < 0 || Secound > 59)
                    {
                        return false;
                    }

                    return true;
                }
                else
                {
                    RegExp = new Regex(@"^(?<hour>\d{1,2}):(?<minute>\d{1,2})$", RegexOptions.ExplicitCapture);
                    m = RegExp.Match(time);

                    if (m.Success == true)
                    {
                        int Hour = int.Parse(m.Groups["hour"].Value);
                        int Minute = int.Parse(m.Groups["minute"].Value);

                        if (Hour < 1 || Hour > 24)
                        {
                            return false;
                        }

                        if (Minute < 0 || Minute > 59)
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
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool IsYearGregorian(string Year)
        {
            //if (!MyFramework.License.HardwareKeyAvailable())
            //{
            //    throw new Exception(MyFramework.Computer.HardwareKey.ErrorDescription);
            //}
            try
            {
                int x;
                x = int.Parse(Year);
                if (x > 1900 && x < 2050)
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

        public static string DayNamePersian(DateTime date)
        {
            string[] PersianDayName = { "يک شنبه", "دوشنبه", "سه شنبه", "چهارشنبه", "پنج شنبه", "جمعه", "شنبه" };
            PersianCalendar Calendar = new PersianCalendar();
            return PersianDayName[(int)Calendar.GetDayOfWeek(date)];
        }

        public static string DayNamePersian(int Index)
        {
            try
            {
                string[] PersianDayName = { "شنبه", "يک شنبه", "دوشنبه", "سه شنبه", "چهارشنبه", "پنج شنبه", "جمعه" };
                PersianCalendar Calendar = new PersianCalendar();
                return PersianDayName[Index];
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        public static string DayNameGregorian(DateTime date)
        {
            string[] GregorianDayName = { "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday" };
            return GregorianDayName[(int)date.DayOfWeek];
        }

        public static string DayNameGregorian(int Index)
        {
            try
            {
                string[] GregorianDayName = { "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday" };
                return GregorianDayName[Index];
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        public static string MonthNamePersian(DateTime date)
        {
            string[] PersianMonthName = { "فروردين", "ارديبهشت", "خرداد", "تير", "مرداد", "شهريور", "مهر", "آبان", "آذر", "دى", "بهمن", "اسفند" };
            PersianCalendar Calendar = new PersianCalendar();
            return PersianMonthName[Calendar.GetMonth(date) - 1];
            
        }

        public static string MonthNamePersian(int Index)
        {
            try
            {
                string[] PersianMonthName = { "فروردين", "ارديبهشت", "خرداد", "تير", "مرداد", "شهريور", "مهر", "آبان", "آذر", "دى", "بهمن", "اسفند" };
                PersianCalendar Calendar = new PersianCalendar();
                return PersianMonthName[Index - 1];
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        public static string MonthNameGregorian(DateTime date)
        {
            string[] GregorianMonthName = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
            return GregorianMonthName[date.Month - 1];
        }

        public static string MonthNameGregorian(int Index)
        {
            try
            {
                string[] GregorianMonthName = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
                return GregorianMonthName[Index];
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        public static int DaysOfWeekPersian(DateTime date)
        {
            PersianCalendar Calendar = new PersianCalendar();
            return (int)Calendar.GetDayOfWeek(date);
        }

        public static int DaysOfYearPersian(DateTime date)
        {
            PersianCalendar Calendar = new PersianCalendar();
            return Calendar.GetDayOfYear(date);
        }

        public static int DaysOfWeekGregorian(DateTime date)
        {
            return (int)date.DayOfWeek;
        }

        public static int DaysOfWeekGregorian(System.DayOfWeek value)
        {
            switch (value)
            {
                case System.DayOfWeek.Saturday: return 0;
                case System.DayOfWeek.Sunday: return 1;
                case System.DayOfWeek.Monday: return 2;
                case System.DayOfWeek.Tuesday: return 3;
                case System.DayOfWeek.Wednesday: return 4;
                case System.DayOfWeek.Thursday: return 5;
                default: return 6;
            }
        }

        public static System.DayOfWeek DaysOfWeekGregorian(int value)
        {
            switch (value)
            {
                case 0: return System.DayOfWeek.Saturday;
                case 1: return System.DayOfWeek.Sunday;
                case 2: return System.DayOfWeek.Monday;
                case 3: return System.DayOfWeek.Tuesday;
                case 4: return System.DayOfWeek.Wednesday;
                case 5: return System.DayOfWeek.Thursday;
                default: return System.DayOfWeek.Friday;
            }
        }

        public static int DaysOfYearGregorian(DateTime date)
        {
            return date.DayOfYear;
        }

        public static int DaysOfMonthPersian(DateTime date)
        {
            PersianCalendar Calendar = new PersianCalendar();
            return Calendar.GetDayOfMonth(date);
        }

        public static int DaysOfMonthGregorian(DateTime date)
        {
            return date.Month;
        }

        public static int DaysInMonthPersian(int Year, int Month)
        {
            PersianCalendar Calendar = new PersianCalendar();
            return Calendar.GetDaysInMonth(Year, Month);
        }

        public static int MonthOfYearPersian(DateTime date)
        {
            PersianCalendar Calendar = new PersianCalendar();
            return Calendar.GetMonth(date);
        }

        public static int MonthOfYearGregorian(DateTime date)
        {
            return date.Month;
        }

        public static int ToPersianYear(DateTime date)
        {
            PersianCalendar Calendar = new PersianCalendar();
            return Calendar.GetYear(date);
        }

        public static string AddYear(string PersianDate, int Year)
        {
            DateTime date = ToGregorian(PersianDate);
            date.AddYears(Year);
            return ToPersian(date);
        }

        public static string AddYear(string PersianDate, int Year, DateFormat Format)
        {
            DateTime date = ToGregorian(PersianDate);
            date.AddYears(Year);
            return ToPersian(date, Format);
        }

        public static string AddMonth(string PersianDate, int Month)
        {
            DateTime date = ToGregorian(PersianDate);
            date.AddMonths(Month);
            return ToPersian(date);
        }

        public static string AddMonth(string PersianDate, int Month, DateFormat Format)
        {
            DateTime date = ToGregorian(PersianDate);
            date.AddMonths(Month);
            return ToPersian(date, Format);
        }

        public static string AddDay(string PersianDate, int Day)
        {
            DateTime date = ToGregorian(PersianDate);
            //date.AddDays(Day);
            date = date.AddDays(Day);
            return ToPersian(date);
        }

        public static string AddDay(string PersianDate, int Day, DateFormat Format)
        {
            DateTime date = ToGregorian(PersianDate);
            date.AddDays(Day);
            return ToPersian(date);
        }

        public static long DateDiff(DateInterval Interval, string date1, string date2)
        {
            //if (!MyFramework.License.HardwareKeyAvailable())
            //{
            //    throw new Exception(MyFramework.Computer.HardwareKey.ErrorDescription);
            //}
            if (!IsDatePersian(date1) || !IsDatePersian(date2))
            {
                return -1;
            }
            DateTime TempDate1 = ToGregorian(date1);
            DateTime TempDate2 = ToGregorian(date2);
            long ReturnValue = 0;

            switch (Interval)
            {
                case DateInterval.Day:
                    ReturnValue = (long)TempDate1.Subtract(TempDate2).Days;
                    break;
                case DateInterval.Hour:
                    ReturnValue = (long)TempDate1.Subtract(TempDate2).Hours;
                    break;
                case DateInterval.Minute:
                    ReturnValue = (long)TempDate1.Subtract(TempDate2).Minutes;
                    break;
                case DateInterval.Second:
                    ReturnValue = (long)TempDate1.Subtract(TempDate2).Seconds;
                    break;
                case DateInterval.Millisecond:
                    ReturnValue = (long)TempDate1.Subtract(TempDate2).Milliseconds;
                    break;
            }
            return ReturnValue;
        }

        public static string CurrentDatePersian()
        {
            string ReturnValue;

            ReturnValue = Baran.Classes.Common.CurrentDate.Instance.CurrentDateShamsi;
            return ReturnValue;
        }

        public static DateTime CurrentDateGregorian()
        {
            DateTime ReturnValue;

            ReturnValue = Baran.Classes.Common.CurrentDate.Instance.CurrentDateMiladi;
            return ReturnValue;
        }

        public static string DateToWordsPersian(string date)
        {
            string DateToWordsPersian = string.Empty;
            if(!IsDatePersian(date))
                return "";
            string strYear,strMonth, strDay;
            strYear = date.Substring(0,4);
            strMonth = date.Substring(5,2);
            strDay = date.Substring(8,2);

            DateToWordsPersian = DaysToWord(strDay) + MonthsToWord(strMonth) + YearsToWord(strYear) ;
            return DateToWordsPersian;
        }
        public static string DateToWordsPersian(string date, DateToWordFormat dateFormat)
        {
            string DateToWordsPersian = string.Empty;
            if (!IsDatePersian(date))
                return "";
            string strYear, strMonth, strDay;
            strYear = date.Substring(0, 4);
            strMonth = date.Substring(5, 2);
            strDay = date.Substring(8, 2);

            switch (dateFormat)
            {
                case DateToWordFormat.dmy:
                    DateToWordsPersian = DaysToWord(strDay) + MonthsToWord(strMonth) + YearsToWord(strYear);
                    break;
                case DateToWordFormat.dmyyyy:
                    DateToWordsPersian = DaysToWord(strDay) + MonthsToWord(strMonth) + strYear;
                    break;

            }
            return DateToWordsPersian;
        }

        private static string YearsToWord(string year)
        {
            string strYear = string.Empty;
            Int32 intYear, intThousand, intHundred, intTen;
            intYear = Convert.ToInt32(year);

            intThousand = intYear / 1000;
            intYear = intYear - (intThousand * 1000);
            intHundred = intYear / 100;
            intYear = intYear - (intHundred * 100);
            if (intYear > 19)
            {
                intTen = intYear / 10;
                intYear = intYear % 10;
            }
            else
                intTen = 0;

            switch (intThousand)
            {
                case 1: strYear = strYear + " یک هزار "; break;
                case 2: strYear = strYear + " دو هزار "; break;
                case 3: strYear = strYear + " سه هزار "; break;
                case 4: strYear = strYear + " چهار هزار "; break;
                case 5: strYear = strYear + " پنج هزار "; break;
                case 6: strYear = strYear + " شش هزار "; break;
                case 7: strYear = strYear + " هفت هزار "; break;
                case 8: strYear = strYear + " هشت هزار "; break;
                case 9: strYear = strYear + " نه هزار "; break;
            }
            strYear = strYear + " و ";

            switch (intHundred)
            {
                case 0: strYear = strYear + ""; break;
                case 1: strYear = strYear + " یک صد "; break;
                case 2: strYear = strYear + " دویست "; break;
                case 3: strYear = strYear + " سیصد "; break;
                case 4: strYear = strYear + " چهارصد "; break;
                case 5: strYear = strYear + " پانصد "; break;
                case 6: strYear = strYear + " ششصد "; break;
                case 7: strYear = strYear + " هفتصد "; break;
                case 8: strYear = strYear + " هشتصد "; break;
                case 9: strYear = strYear + " نهصد "; break;
            }
            strYear = strYear + " و ";

            switch (intTen)
            {
                case 2: strYear = strYear + " بیست "; break;
                case 3: strYear = strYear + " سی "; break;
                case 4: strYear = strYear + " چهل "; break;
                case 5: strYear = strYear + " پنجاه "; break;
                case 6: strYear = strYear + " شصت "; break;
                case 7: strYear = strYear + " هفتاد "; break;
                case 8: strYear = strYear + " هشتاد "; break;
                case 9: strYear = strYear + " نود "; break;
            }
            if(intTen != 0)
                strYear = strYear + " و ";

            switch (intYear)
            {
                case 0: strYear = strYear + ""; break;
                case 1: strYear = strYear + " یک "; break;
                case 2: strYear = strYear + " دو "; break;
                case 3: strYear = strYear + " سه "; break;
                case 4: strYear = strYear + " چهار "; break;
                case 5: strYear = strYear + " پنج "; break;
                case 6: strYear = strYear + " شش "; break;
                case 7: strYear = strYear + " هفت "; break;
                case 8: strYear = strYear + " هشت "; break;
                case 9: strYear = strYear + " نه "; break;
                case 10: strYear = strYear + " ده "; break;
                case 11: strYear = strYear + " یازده "; break;
                case 12: strYear = strYear + " دوازده "; break;
                case 13: strYear = strYear + " سیزده "; break;
                case 14: strYear = strYear + " چهارده "; break;
                case 15: strYear = strYear + " پانزده "; break;
                case 16: strYear = strYear + " شانزده "; break;
                case 17: strYear = strYear + " هفده "; break;
                case 18: strYear = strYear + " هجده "; break;
                case 19: strYear = strYear + " نوزده "; break;
            }

            return strYear;
        }

        public static string MonthsToWord(string month)
        {
            string strMonth = string.Empty;
            switch (month)
            {
                case "01": strMonth = " فروردین ماه "; break;
                case "02": strMonth = " اردیبهشت ماه "; break;
                case "03": strMonth = " خرداد ماه "; break;
                case "04": strMonth = " تیر ماه "; break;
                case "05": strMonth = " مرداد ماه "; break;
                case "06": strMonth = " شهریور ماه "; break;
                case "07": strMonth = " مهر ماه "; break;
                case "08": strMonth = " ابان ماه "; break;
                case "09": strMonth = " اذر ماه "; break;
                case "10": strMonth = " دی ماه "; break;
                case "11": strMonth = " بهمن ماه "; break;
                case "12": strMonth = " اسفند ماه "; break;
            }
            return strMonth;
        }

        public static string DaysToWord(string day)
        {
            string strDay = string.Empty;
            switch (day)
            {
                case "01": strDay = "اول"; break;
                case "02": strDay = "دوم"; break;
                case "03": strDay = "سوم"; break;
                case "04": strDay = "چهارم"; break;
                case "05": strDay = "پنجم"; break;
                case "06": strDay = "ششم"; break;
                case "07": strDay = "هفتم"; break;
                case "08": strDay = "هشتم"; break;
                case "09": strDay = "نهم"; break;
                case "10": strDay = "دهم"; break;
                case "11": strDay = "یازدهم"; break;
                case "12": strDay = "دوازدهم"; break;
                case "13": strDay = "سیزدهم"; break;
                case "14": strDay = "چهاردهم"; break;
                case "15": strDay = "پانزدهم"; break;
                case "16": strDay = "شانزدهم"; break;
                case "17": strDay = "هفدهم"; break;
                case "18": strDay = "هجدهم"; break;
                case "19": strDay = "نوزدهم"; break;
                case "20": strDay = "بیستم"; break;
                case "21": strDay = "بیست و یکم"; break;
                case "22": strDay = "بیست و دوم"; break;
                case "23": strDay = "بیست و سوم"; break;
                case "24": strDay = "بیست و چهارم"; break;
                case "25": strDay = "بیست و پنجم"; break;
                case "26": strDay = "بیست و ششم"; break;
                case "27": strDay = "بیست و هفتم"; break;
                case "28": strDay = "بیست و هشتم"; break;
                case "29": strDay = "بیست و نهم"; break;
                case "30": strDay = "سیم"; break;
                case "31": strDay = "سی و یکم"; break;
            }
            return strDay;
        }
    }
}
