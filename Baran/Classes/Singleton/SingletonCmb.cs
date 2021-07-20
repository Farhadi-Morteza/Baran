
namespace Baran.Classes.Singleton
{
    #region Fertilizer Category

    public class FertilizerCategory
    {              
        private static FertilizerCategory _instance;
        public static FertilizerCategory Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new FertilizerCategory();

                return _instance;
            }
            set
            {
                _instance = value;
            }
        }

        private FertilizerCategory()
        {
            _Dst = BaranDataAccess.Product.dstProduct.FertilizerCategoryCmbTable();
        }

        private BaranDataAccess.Product.dstProduct _Dst;
        public BaranDataAccess.Product.dstProduct  FertilizerCategoryDst
        {
            get
            {
                return _Dst;
            }
            set
            {
                _Dst = value;
            }
        }
    }

    #endregion
    #region Material Mode
    public class MaterialMode
    {
        private static MaterialMode _instance;
        public static MaterialMode Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new MaterialMode();

                return _instance;
            }
            set
            {
                _instance = value;
            }
        }

        private MaterialMode()
        {
            _Dst = BaranDataAccess.Common.dstCommon.MaterialModeCmbTable();
        }

        private BaranDataAccess.Common.dstCommon _Dst;
        public BaranDataAccess.Common.dstCommon MaterialModeDst
        {
            get
            {
                return _Dst;
            }
            set
            {
                _Dst = value;
            }
        }
    }
    #endregion
    #region Product Category
    public class ProductCategory
    {
        private static ProductCategory _instance;
        public static ProductCategory Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ProductCategory();

                return _instance;
            }
            set
            {
                _instance = value;
            }
        }

        private ProductCategory()
        {
            _Dst = BaranDataAccess.Common.dstCommon.ProductCategoryCmbTable();
        }

        private BaranDataAccess.Common.dstCommon _Dst;
        public BaranDataAccess.Common.dstCommon ProductCategoryDst
        {
            get
            {
                return _Dst;
            }
            set
            {
                _Dst = value;
            }
        }
    }
    #endregion
    #region Element
    public class Element
    {
        private static Element _instance;
        public static Element Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Element();

                return _instance;
            }
            set
            {
                _instance = value;
            }
        }

        private Element()
        {
            _Dst = BaranDataAccess.Common.dstCommon.ElementCmbTable();
        }

        private BaranDataAccess.Common.dstCommon _Dst;
        public BaranDataAccess.Common.dstCommon ElementDst
        {
            get
            {
                return _Dst;
            }
            set
            {
                _Dst = value;
            }
        }
    }
    #endregion
    #region Unit Measurement
    public class UnitMeasurement
    {
        private static UnitMeasurement _instance;
        public static UnitMeasurement Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new UnitMeasurement();

                return _instance;
            }
            set
            {
                _instance = value;
            }
        }

        private UnitMeasurement()
        {
            _Dst = BaranDataAccess.Common.dstCommon.UnitMeasurmentCmbTable();
        }

        private BaranDataAccess.Common.dstCommon _Dst;
        public BaranDataAccess.Common.dstCommon UnitMeasurementDst
        {
            get
            {
                return _Dst;
            }
            set
            {
                _Dst = value;
            }
        }
    }
    #endregion
    #region Tree Type
    public class TreeType
    {
        private static TreeType _instance;
        public static TreeType Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new TreeType();

                return _instance;
            }
            set
            {
                _instance = value;
            }
        }

        private TreeType()
        {
            _Dst = BaranDataAccess.Product.dstProduct.TreeTypeCmdTable();
        }

        private BaranDataAccess.Product.dstProduct _Dst;
        public BaranDataAccess.Product.dstProduct TreeTypeDst
        {
            get
            {
                return _Dst;
            }
            set
            {
                _Dst = value;
            }
        }
    }
    #endregion
    #region Field
    public class Field
    {
        //private static Field _instance;
        //public static Field Instance()
        //{
        //    get
        //    {
        //        if (_instance == null)
        //            _instance = new Field();

        //        return _instance;
        //    }
        //    set
        //    {
        //        _instance = value;
        //    }
        //}

        //private Field()
        //{
        //    _Dst = BaranDataAccess.Product.dstProduct.TreeTypeCmdTable();
        //}

        //private BaranDataAccess.Product.dstProduct _Dst;
        //public BaranDataAccess.Product.dstProduct TreeTypeDst
        //{
        //    get
        //    {
        //        return _Dst;
        //    }
        //    set
        //    {
        //        _Dst = value;
        //    }
        //}
    }
    #endregion
    #region Status
    public class Status
    {
        private static Status _instance;
        public static Status Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Status();

                return _instance;
            }
            set
            {
                _instance = value;
            }
        }

        private Status()
        {
            _Dst = BaranDataAccess.Common.dstCommon.StatusCmbTable();
        }

        private BaranDataAccess.Common.dstCommon _Dst;
        public BaranDataAccess.Common.dstCommon StatusDst
        {
            get
            {
                return _Dst;
            }
            set
            {
                _Dst = value;
            }
        }
    }
    #endregion
}
