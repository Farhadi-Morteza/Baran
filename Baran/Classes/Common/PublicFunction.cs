using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Baran.Classes.Common
{
    public class PublicFunction
    {
        public static decimal CalcPercent(decimal Value, decimal Percent)
        {
            decimal dclResult;

            dclResult = ( Value + (Value * ( Percent / 100)));
            return dclResult;
        }

        public static int FactorNumberFormat(string factorNumber, string factorType, string storeID)
        {
            int ReturnValue;
            string strFactorNumber, strNumber;
            strNumber = string.Empty;

            if (factorNumber.Length >= 6)
                strNumber = factorNumber.Remove(0, 4);
            else
                strNumber = factorNumber; // factorNumber.Remove(0, 2);

            string strYear =  CurrentDate.Instance.CurrentDateShamsi.ToString().Substring(2,2);


            //strFactorNumber = factorNumber.Substring(0, 2) + factorType + storeID + strNumber.PadLeft(5, '0');
            strFactorNumber = strYear + factorType + storeID + strNumber.PadLeft(5, '0');

            ReturnValue = Convert.ToInt32(strFactorNumber);

            return ReturnValue;
        }

        public static int GetFactorOperationType(string prmFactorNumber)
        {
            int intReturnValu;
            string strFactorOperationType;

            strFactorOperationType = prmFactorNumber.Substring(2, 2);
            intReturnValu = Convert.ToInt32(strFactorOperationType);

            return intReturnValu;
        }

        public static double GetDistanceOfTwoPoints(float X1, float X2, float Y1, float Y2, System.Drawing.Graphics g)
        {


            double result;


            //distance in pixel given 2 point coordinates


            double pixelDistance = Math.Sqrt(Math.Pow(X2 - (X1), 2) + Math.Pow(Y2 - (Y1), 2));


            //Get Hypotenuse


            double hipoScreen = Math.Sqrt(Math.Pow(SystemInformation.PrimaryMonitorSize.Width, 2) + Math.Pow(SystemInformation.PrimaryMonitorSize.Height, 2));


            //Get width in inches


            double widthInInches = (SystemInformation.PrimaryMonitorSize.Width * 14.1) / hipoScreen;



            //Get physical dpi


            double physicalDPI = SystemInformation.PrimaryMonitorSize.Width / widthInInches;


            //Distance in inches
            result = (pixelDistance / physicalDPI);



            //Inches to mm
            result = result * cnsUnitConverters.InchPerMillimeter;


            return result;
        }

        public static int MillimeterToPixel(double millimeter, Control control)
        {
            double pixel = -1;  
            using (System.Drawing.Graphics g = control.CreateGraphics())  
            {
                pixel = millimeter * g.DpiY / cnsUnitConverters.InchPerMillimeter;
            }
            return (int)Math.Round(pixel);
        }

        public static System.Drawing.Size MillimeterToPixel(double WidthInCm, double HeightInCm, Control control)
        {
            double pixelWidth = -1, pixelHeight = 1;

            using (System.Drawing.Graphics g = control.CreateGraphics())
            {
                pixelHeight = HeightInCm * g.DpiY / cnsUnitConverters.InchPerMillimeter;
                pixelWidth = WidthInCm * g.DpiX / cnsUnitConverters.InchPerMillimeter;
            }
            return new System.Drawing.Size((int)Math.Round(WidthInCm), (int)Math.Round( HeightInCm));
        }

        public static int PixelToMillimeter(double pixel, Control control)
        {
            double mm = -1;
            using (System.Drawing.Graphics g = control.CreateGraphics())
            {
                mm = (pixel * cnsUnitConverters.InchPerMillimeter) / g.DpiY;
            }
             int oo = (int)Math.Round( mm);
             return oo;
        }

        public static int MillimeterToTWIPS(int millimeter)
        {
            double twips = -1;
            twips = millimeter * cnsUnitConverters.MillimeterPerTWIPS;

            return (int)Math.Round(twips);
        }

        public static double MillimeterToInch(int millimeter)
        {
            double inch = -1;
            inch = millimeter / cnsUnitConverters.InchPerMillimeter;

            return Math.Round(inch);
        }
    }
}
