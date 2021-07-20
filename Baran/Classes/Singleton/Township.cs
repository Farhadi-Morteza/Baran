
namespace Baran.Classes.Singleton
{
    public class Township
    {
        private static Township _instance;
        public static Township Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Township();
                }
                return _instance;
            }
            set
            {
                _instance = value;
            }

        }

        private Township()
        {
            _dstTownship = BaranDataAccess.Common.dstCommon.TownshipTable();
        }

        private BaranDataAccess.Common.dstCommon _dstTownship;
        public BaranDataAccess.Common.dstCommon DstTownship
        {
            get
            {
                return _dstTownship;
            }
            set
            {
                _dstTownship = value;
            }
        }
    }
}
