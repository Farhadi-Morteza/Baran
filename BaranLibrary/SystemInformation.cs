

namespace BaranLibrary
{
    static public class SystemInformation
    {
        static private int intFK_ShopID = 1;
        static public int FK_ShopID
        {
            get
            {
                return intFK_ShopID;
            }
            set
            {
                intFK_ShopID = value;
            }
        }
        static private string shopEconomicCode = "1";
        static public string ShopEconomicCode
        {
            get
            {
                return shopEconomicCode;
            }
            set
            {
                shopEconomicCode = value;
            }
        }
        //static public string versionnumber = "1.0.0.0";
        //static public string VersionNumber
        //{
        //    get
        //    {
        //        return versionnumber;
        //    }
        //    set
        //    {
        //        versionnumber = value;
        //    }
        //}
        }
}
