namespace BaranDataAccess.Common 
{
    
    
    public partial class dstItems 
    {
        public static dstItems GetItems()
        {
            dstItems returnDst = new dstItems();

            dstItemsTableAdapters.spr_Sec_Items_SelectTableAdapter adapter =
                new BaranDataAccess.Common.dstItemsTableAdapters.spr_Sec_Items_SelectTableAdapter();

            try
            {
                adapter.FillItemsTable(returnDst.spr_Sec_Items_Select);
            }
            catch 
            {
                returnDst = null;
            }

            return returnDst;
        }

        public static dstItems GetPackages()
        {
            dstItems returnDst = new dstItems();

            dstItemsTableAdapters.spr_Sec_Packages_SelectTableAdapter adapter =
                new BaranDataAccess.Common.dstItemsTableAdapters.spr_Sec_Packages_SelectTableAdapter();

            try
            {
                adapter.FillPackagesTable(returnDst.spr_Sec_Packages_Select);
            }
            catch
            {
                returnDst = null;
            }

            return returnDst;
        }
    }
}
