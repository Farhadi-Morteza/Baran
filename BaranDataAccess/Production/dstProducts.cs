namespace BaranDataAccess.Production
{


    public partial class dstProducts
    {
        public static dstProducts ProductonCmbTable(int userID)
        {
            dstProducts returnDst = new dstProducts();
            dstProductsTableAdapters.spr_prd_Production_cmb_SelectTableAdapter adapter =
                new dstProductsTableAdapters.spr_prd_Production_cmb_SelectTableAdapter();
            try
            {
                adapter.FillProductionCmbTable(returnDst.spr_prd_Production_cmb_Select, userID);
            }
            catch
            {
                returnDst = null;
            }
            return returnDst;
        }
    }
}