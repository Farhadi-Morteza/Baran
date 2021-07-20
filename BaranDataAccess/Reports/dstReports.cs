namespace BaranDataAccess.Reports 
{
    
    
    public partial class dstReports
    {

    #region Factor Print
        public static dstReports GetFactorCrRpt(long prmFactorNumber)
        {
            dstReports returnDst = new dstReports();
            BaranDataAccess.Reports.dstReportsTableAdapters.spr_Fac_Factor_CrRpt_SelectTableAdapter adapter =
                new dstReportsTableAdapters.spr_Fac_Factor_CrRpt_SelectTableAdapter();

            try
            {
                adapter.FillFactorCrRptTable(returnDst.spr_Fac_Factor_CrRpt_Select, prmFactorNumber);
            }
            catch 
            {
                returnDst = null;
            }
            return returnDst;
        }
    #endregion

        public static dstReports GetChequeCrRpt(long prmSafeID)
        {
            dstReports returnDst = new dstReports();
            BaranDataAccess.Reports.dstReportsTableAdapters.spr_Doc_Cheques_CrRpt_SelectTableAdapter adapter =
                new dstReportsTableAdapters.spr_Doc_Cheques_CrRpt_SelectTableAdapter();

            try
            {
                adapter.FillChequeCrRpt(returnDst.spr_Doc_Cheques_CrRpt_Select,prmSafeID);
            }
            catch 
            {
                returnDst = null;
            }
            return returnDst;
        
        }


    }
}
