namespace BaranDataAccess.Reports
{


    public partial class dstReportSetting
    {
        public static dstReportSetting GetReportSetting()
        {

            BaranDataAccess.Reports.dstReportSetting returnDst = new dstReportSetting();
            BaranDataAccess.Reports.dstReportSettingTableAdapters.spr_Rpt_ReportSetting_SelectTableAdapter adapter =
                new dstReportSettingTableAdapters.spr_Rpt_ReportSetting_SelectTableAdapter();
            try
            {
                adapter.FillReportSettingsTable(returnDst.spr_Rpt_ReportSetting_Select);
            }
            catch (System.Exception)
            {

                returnDst = null;
            }
            return returnDst;
        }

        public static dstReportSetting GetChequeReportSetting()
        {

            BaranDataAccess.Reports.dstReportSetting returnDst = new dstReportSetting();
            BaranDataAccess.Reports.dstReportSettingTableAdapters.spr_Rpt_ChequePrintSettin_SelectTableAdapter adapter =
                new dstReportSettingTableAdapters.spr_Rpt_ChequePrintSettin_SelectTableAdapter();
            try
            {
                adapter.FillChequePrintSetting(returnDst.spr_Rpt_ChequePrintSettin_Select);
            }
            catch (System.Exception)
            {

                returnDst = null;
            }
            return returnDst;
        }
    }


}
