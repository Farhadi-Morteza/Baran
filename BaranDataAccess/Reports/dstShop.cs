namespace BaranDataAccess.Reports
{


    public partial class dstShop
    {
        public static dstShop GetShopDescription()
        {
            BaranDataAccess.Reports.dstShop returnDst = new dstShop();
            BaranDataAccess.Reports.dstShopTableAdapters.spr_Sec_Shop_SelectTableAdapter adapter =
                new dstShopTableAdapters.spr_Sec_Shop_SelectTableAdapter();

            try
            {
                adapter.FillShopReportTable(returnDst.spr_Sec_Shop_Select);
            }
            catch
            {
                returnDst = null;
            }
            return returnDst;
        }
    }
}
