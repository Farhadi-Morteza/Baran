using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Baran.Classes.Common
{
    public static class PublicPropertise
    {
        private static string _fiscalYearName;
        public static string FiscalYearName
        {
            get
            {
                return _fiscalYearName;
            }
            set
            {
                _fiscalYearName = value;
            }
        }

        private static int _fiscalYearID;
        public static int FiscalYearID
        {
            get
            {
                return _fiscalYearID;
            }
            set
            {
                _fiscalYearID = value;
            }
        }

        private static int _filterAction = cnsFilterActioon.WithoutFilter;
        public static int FilterAction
        {
            get
            {
                return _filterAction;
            }
            set
            {
                _filterAction = value;
            }
        }

        private static int _activityID;
        public static int ActivityID
        {
            get
            {
                return _activityID;
            }
            set
            {
                _activityID = value;
            }
        }

        private static int _ProductionFieldID;
        public static int ProductionFieldID
        {
            get
            {
                return _ProductionFieldID;
            }
            set
            {
                _ProductionFieldID = value;
            }
        }

        private static int _productionID;
        public static int ProductionID
        {
            get
            {
                return _productionID;
            }
            set
            {
                _productionID = value;
            }
        }

        private static int _cropID;
        public static int CropID
        {
            get
            {
                return _cropID;
            }
            set
            {
                _cropID = value;
            }
        }

        private static bool _productionInUpdate = false;
        public static bool ProductionInUpate
        {
            get
            {
                return _productionInUpdate;
            }
            set
            {
                _productionInUpdate = value;
            }
        }
    }
}
