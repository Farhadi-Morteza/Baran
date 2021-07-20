using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Baran.Classes.Singleton
{
    public class ReportSetting
    {
        private static ReportSetting _instance;
        public static ReportSetting Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ReportSetting();
                }
                return _instance;
            }
            set
            {
                _instance = value;
            }

        }


        private ReportSetting()
        {
            _ReportSetting = BaranDataAccess.Reports.dstReportSetting.GetReportSetting();
        }


        private BaranDataAccess.Reports.dstReportSetting _ReportSetting;
        public BaranDataAccess.Reports.dstReportSetting DstReportSetting
        {
            get
            {
                return _ReportSetting;
            }
            set
            {
                _ReportSetting = value;
            }
        }

    }
}
