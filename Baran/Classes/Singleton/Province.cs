using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baran.Classes.Singleton
{
    public class Province
    {
        private static Province _instance;
        public static Province Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Province();
                }
                return _instance;
            }
            set
            {
                _instance = value;
            }
        }
        private Province()
        {
            _dstProvince = BaranDataAccess.Common.dstCommon.ProvinceTable();
        }
        private BaranDataAccess.Common.dstCommon _dstProvince;
        public BaranDataAccess.Common.dstCommon DstProvince
        {
            get
            {
                return _dstProvince;
            }
            set
            {
                _dstProvince = value;
            }
        }

    }
}

