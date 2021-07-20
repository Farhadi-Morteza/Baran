namespace BaranDataAccess.Common {
    
    
    public partial class dstProvince 
    {
        public static dstProvince ProvinceTable()
        {
            dstProvince returnDst = new dstProvince();
            dstProvinceTableAdapters.spr_cmn_Province_SelectTableAdapter adapter =
                new dstProvinceTableAdapters.spr_cmn_Province_SelectTableAdapter();
            try
            {
                adapter.FillProvinceTable(returnDst.spr_cmn_Province_Select);
            }
            catch
            {
                returnDst = null;
            }
            return returnDst;
        }
    }
}
