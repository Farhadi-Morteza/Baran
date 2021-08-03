namespace BaranDataAccess.Common
{
}

namespace BaranDataAccess.Common
{


    public partial class dstCommon
    {

        public static dstCommon ProvinceTable()
        {
            dstCommon returnDst = new dstCommon();
            dstCommonTableAdapters.spr_cmn_Province_SelectTableAdapter adapter =
                new dstCommonTableAdapters.spr_cmn_Province_SelectTableAdapter();
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

        public static dstCommon TownshipTable()
        {
            dstCommon returnDst = new dstCommon();
            dstCommonTableAdapters.spr_cmn_Township_SelectTableAdapter adapter =
                new dstCommonTableAdapters.spr_cmn_Township_SelectTableAdapter();
            try
            {
                adapter.FillTownshipTable(returnDst.spr_cmn_Township_Select);
            }
            catch
            {
                returnDst = null;
            }
            return returnDst;
        }

        public static dstCommon SoilTextureTable()
        {
            dstCommon returnDst = new dstCommon();
            dstCommonTableAdapters.spr_cmn_SoilTexture_SelectTableAdapter adapter =
                new dstCommonTableAdapters.spr_cmn_SoilTexture_SelectTableAdapter();
            try
            {
                adapter.FillSoilTextureTable(returnDst.spr_cmn_SoilTexture_Select);
            }
            catch
            {
                returnDst = null;
            }
            return returnDst;
        }

        public static dstCommon OwnershipTable()
        {
            dstCommon returnDst = new dstCommon();
            dstCommonTableAdapters.spr_cmn_Ownership_SelectTableAdapter adapter =
                new dstCommonTableAdapters.spr_cmn_Ownership_SelectTableAdapter();
            try
            {
                adapter.FillOwnershipTable(returnDst.spr_cmn_Ownership_Select);
            }
            catch
            {
                returnDst = null;
            }
            return returnDst;
        }

        public static dstCommon FieldUseTypeTable()
        {
            dstCommon returnDst = new dstCommon();
            dstCommonTableAdapters.spr_src_FieldUseType_SelectTableAdapter adapter =
                new dstCommonTableAdapters.spr_src_FieldUseType_SelectTableAdapter();
            try
            {
                adapter.FillFieldUseTypeTable(returnDst.spr_src_FieldUseType_Select);
            }
            catch
            {
                returnDst = null;
            }
            return returnDst;
        }

        public static dstCommon WaterSourceTypeTable()
        {
            dstCommon returnDst = new dstCommon();
            dstCommonTableAdapters.spr_src_WaterSourcType_SelectTableAdapter adapter =
                new dstCommonTableAdapters.spr_src_WaterSourcType_SelectTableAdapter();
            try
            {
                adapter.FillWaterSourcTypeTable(returnDst.spr_src_WaterSourcType_Select);
            }
            catch
            {
                returnDst = null;
            }
            return returnDst;
        }

        public static dstCommon WarehouseTypeTable()
        {
            dstCommon returnDst = new dstCommon();
            dstCommonTableAdapters.spr_src_WarehouseType_SelectTableAdapter adapter =
                new dstCommonTableAdapters.spr_src_WarehouseType_SelectTableAdapter();
            try
            {
                adapter.FillWarehouseTypeTable(returnDst.spr_src_WarehouseType_Select);
            }
            catch
            {
                returnDst = null;
            }
            return returnDst;
        }

        public static dstCommon MachineryCategoryTable()
        {
            dstCommon returnDst = new dstCommon();
            dstCommonTableAdapters.spr_src_MachineryCategory_SelectTableAdapter adapter =
                new dstCommonTableAdapters.spr_src_MachineryCategory_SelectTableAdapter();
            try
            {
                adapter.FillMachineryCategoryTable(returnDst.spr_src_MachineryCategory_Select);
            }
            catch
            {
                returnDst = null;
            }
            return returnDst;
        }

        public static dstCommon BuildingsCategoryTable()
        {
            dstCommon returnDst = new dstCommon();
            dstCommonTableAdapters.spr_src_BuildingsCategory_SelectTableAdapter adapter =
                new dstCommonTableAdapters.spr_src_BuildingsCategory_SelectTableAdapter();
            try
            {
                adapter.FillBuildingsCategoryTable(returnDst.spr_src_BuildingsCategory_Select);
            }
            catch
            {
                returnDst = null;
            }
            return returnDst;
        }

        public static dstCommon WarehouseUseTypeTable()
        {
            dstCommon returnDst = new dstCommon();
            dstCommonTableAdapters.spr_src_WarehouseUseType_SelectTableAdapter adapter =
                new dstCommonTableAdapters.spr_src_WarehouseUseType_SelectTableAdapter();
            try
            {
                adapter.FillWarehouseUseTypeTable(returnDst.spr_src_WarehouseUseType_Select);
            }
            catch
            {
                returnDst = null;
            }
            return returnDst;
        }

        public static dstCommon WaterTransmissionTypeTable()
        {
            dstCommon returnDst = new dstCommon();
            dstCommonTableAdapters.spr_src_WaterTransmissionType_SelectTableAdapter adapter =
                new dstCommonTableAdapters.spr_src_WaterTransmissionType_SelectTableAdapter();
            try
            {
                adapter.FillWaterTransmissionTypeTable(returnDst.spr_src_WaterTransmissionType_Select);
            }
            catch
            {
                returnDst = null;
            }
            return returnDst;
        }

        public static dstCommon ActivityTable()
        {
            dstCommon returnDst = new dstCommon();
            dstCommonTableAdapters.spr_cmn_Activity_SelectTableAdapter adapter =
                new dstCommonTableAdapters.spr_cmn_Activity_SelectTableAdapter();

            try
            {
                adapter.FillActivityTable(returnDst.spr_cmn_Activity_Select);
            }
            catch
            {
                returnDst = null;
            }

            return returnDst;
        }

        public static dstCommon ActivityByBusinessIDTable(int businessID)
        {
            dstCommon returnDst = new dstCommon();
            dstCommonTableAdapters.spr_cmn_Activity_SelectTableAdapter adapter =
                new dstCommonTableAdapters.spr_cmn_Activity_SelectTableAdapter();

            try
            {
                adapter.FillActivityByBusinessIDTable(returnDst.spr_cmn_Activity_Select, businessID);
            }
            catch
            {
                returnDst = null;
            }

            return returnDst;
        }

        public static dstCommon BusinessTable()
        {
            dstCommon returnDst = new dstCommon();
            dstCommonTableAdapters.spr_cmn_Business_cmb_SelectTableAdapter adapter =
                new dstCommonTableAdapters.spr_cmn_Business_cmb_SelectTableAdapter();

            try
            {
                adapter.FillBusinessTable(returnDst.spr_cmn_Business_cmb_Select);
            }
            catch
            {
                returnDst = null;
            }

            return returnDst;
        }

        public static dstCommon BusinessByBusinessCategoryIDTable(int businessCategoryID)
        {
            dstCommon returnDst = new dstCommon();
            dstCommonTableAdapters.spr_cmn_Business_cmb_SelectTableAdapter adapter =
                new dstCommonTableAdapters.spr_cmn_Business_cmb_SelectTableAdapter();

            try
            {
                adapter.FillBusinessByBusinessCategoryIDTable(returnDst.spr_cmn_Business_cmb_Select, businessCategoryID);
            }
            catch
            {
                returnDst = null;
            }

            return returnDst;
        }

        public static dstCommon BusinessCategoryTable()
        {
            dstCommon returnDst = new dstCommon();
            dstCommonTableAdapters.spr_cmn_BusinessCategory_cmb_SelectTableAdapter adapter =
                new dstCommonTableAdapters.spr_cmn_BusinessCategory_cmb_SelectTableAdapter();

            try
            {
                adapter.FillBusinessCategoryTable(returnDst.spr_cmn_BusinessCategory_cmb_Select);
            }
            catch
            {
                returnDst = null;
            }

            return returnDst;
        }

        public static dstCommon CropTable()
        {
            dstCommon returnDst = new dstCommon();
            dstCommonTableAdapters.spr_cmn_Crop_SelectTableAdapter adapter =
                new dstCommonTableAdapters.spr_cmn_Crop_SelectTableAdapter();

            try
            {
                adapter.FillCropTable(returnDst.spr_cmn_Crop_Select);
            }
            catch
            {
                returnDst = null;
            }

            return returnDst;
        }

        public static dstCommon CropCmbTable(int? activiyID)
        {
            dstCommon returnDst = new dstCommon();
            dstCommonTableAdapters.spr_cmn_Crop_cmb_SelectTableAdapter adapter =
                new dstCommonTableAdapters.spr_cmn_Crop_cmb_SelectTableAdapter();

            try
            {
                adapter.FillCropCmbTable(returnDst.spr_cmn_Crop_cmb_Select, activiyID);
            }
            catch
            {
                returnDst = null;
            }

            return returnDst;
        }

        public static dstCommon CropCategoryTable()
        {
            dstCommon returnDst = new dstCommon();
            dstCommonTableAdapters.spr_cmn_CropCategory_SelectTableAdapter adapter =
                new dstCommonTableAdapters.spr_cmn_CropCategory_SelectTableAdapter();

            try
            {
                adapter.FillCropCategoryTable(returnDst.spr_cmn_CropCategory_Select);
            }
            catch
            {
                returnDst = null;
            }

            return returnDst;
        }

        public static dstCommon CultivarByCropIDTable(int cropID)
        {
            dstCommon returnDst = new dstCommon();
            dstCommonTableAdapters.spr_cmn_CultivarByCropId_SelectTableAdapter adapter =
                new dstCommonTableAdapters.spr_cmn_CultivarByCropId_SelectTableAdapter();

            try
            {
                adapter.FillCultivarByCropIDTable(returnDst.spr_cmn_CultivarByCropId_Select, cropID);
            }
            catch
            {
                returnDst = null;
            }

            return returnDst;
        }

        public static dstCommon FieldByUserID(int userID)
        {
            dstCommon returnDst = new dstCommon();
            dstCommonTableAdapters.spr_src_FieldByUserID_SelectTableAdapter adapter =
                new dstCommonTableAdapters.spr_src_FieldByUserID_SelectTableAdapter();
            try
            {
                adapter.FillFieldByUserIDTable(returnDst.spr_src_FieldByUserID_Select, userID);
            }
            catch
            {
                returnDst = null;
            }
            return returnDst;
        }
        public static dstCommon LandByUserID(int userID)
        {
            dstCommon returnDst = new dstCommon();
            dstCommonTableAdapters.spr_src_LandByUserID_SelectTableAdapter adapter =
                new dstCommonTableAdapters.spr_src_LandByUserID_SelectTableAdapter();
            try
            {
                adapter.FillLandByUserIDTable(returnDst.spr_src_LandByUserID_Select, userID);
            }
            catch
            {
                returnDst = null;
            }
            return returnDst;
        }
        public static dstCommon UnitMeasurementTable(int? measurementCategroryID)
        {
            dstCommon returnDst = new dstCommon();
            dstCommonTableAdapters.spr_cmn_UnitMeasurement_SelectTableAdapter adapter =
                new dstCommonTableAdapters.spr_cmn_UnitMeasurement_SelectTableAdapter();
            try
            {
                adapter.FillUnitMeasurementTable(returnDst.spr_cmn_UnitMeasurement_Select, measurementCategroryID);
            }
            catch
            {
                returnDst = null;
            }
            return returnDst;
        }

        public static dstCommon CropListTable()
        {
            dstCommon returnDst = new dstCommon();
            dstCommonTableAdapters.spr_cmn_CropList_SelectTableAdapter adapter =
                new dstCommonTableAdapters.spr_cmn_CropList_SelectTableAdapter();
            try
            {
                adapter.FillCropListTable(returnDst.spr_cmn_CropList_Select);
            }
            catch
            {
                returnDst = null;
            }
            return returnDst;
        }

        public static dstCommon CountryTable()
        {
            dstCommon returnDst = new dstCommon();
            dstCommonTableAdapters.spr_cmn_Country_cmb_SelectTableAdapter adapter =
                new dstCommonTableAdapters.spr_cmn_Country_cmb_SelectTableAdapter();
            try
            {
                adapter.FillCountryCmbTable(returnDst.spr_cmn_Country_cmb_Select);
            }
            catch
            {
                returnDst = null;
            }
            return returnDst;
        }

        public static dstCommon MaterialModeCmbTable()
        {
            dstCommon returnDst = new dstCommon();
            dstCommonTableAdapters.spr_cmn_MaterialMode_cmb_SelectTableAdapter adapter =
                new dstCommonTableAdapters.spr_cmn_MaterialMode_cmb_SelectTableAdapter();
            try
            {
                adapter.FillMaterialModeCmbTabel(returnDst.spr_cmn_MaterialMode_cmb_Select);
            }
            catch
            {
                returnDst = null;
            }
            return returnDst;
        }

        public static dstCommon ProductCategoryCmbTable()
        {
            dstCommon returnDst = new dstCommon();
            dstCommonTableAdapters.spr_cmn_ProductCategory_cmb_SelectTableAdapter adapter =
                new dstCommonTableAdapters.spr_cmn_ProductCategory_cmb_SelectTableAdapter();
            try
            {
                adapter.FillProductCategoryCmbTable(returnDst.spr_cmn_ProductCategory_cmb_Select);
            }
            catch
            {
                returnDst = null;
            }
            return returnDst;
        }

        public static dstCommon UnitMeasurmentCmbTable()
        {
            dstCommon returnDst = new dstCommon();
            dstCommonTableAdapters.spr_cmn_UnitMeasurement_cmb_SelectTableAdapter adapter =
                new dstCommonTableAdapters.spr_cmn_UnitMeasurement_cmb_SelectTableAdapter();
            try
            {
                adapter.FillUnitMeasurementCmbTable(returnDst.spr_cmn_UnitMeasurement_cmb_Select);
            }
            catch
            {
                returnDst = null;
            }
            return returnDst;
        }

        public static dstCommon ElementCmbTable()
        {
            dstCommon returnDst = new dstCommon();
            dstCommonTableAdapters.spr_cmn_Element_cmb_SelectTableAdapter adapter =
                new dstCommonTableAdapters.spr_cmn_Element_cmb_SelectTableAdapter();
            try
            {
                adapter.FillElementCmbTable(returnDst.spr_cmn_Element_cmb_Select);
            }
            catch
            {
                returnDst = null;
            }
            return returnDst;
        }

        public static dstCommon GenderCmbTable()
        {
            dstCommon returnDst = new dstCommon();
            dstCommonTableAdapters.spr_cmn_Gender_cmb_SelectTableAdapter adapter =
                new dstCommonTableAdapters.spr_cmn_Gender_cmb_SelectTableAdapter();
            try
            {
                adapter.FillGenderTable(returnDst.spr_cmn_Gender_cmb_Select);
            }
            catch
            {
                returnDst = null;
            }
            return returnDst;
        }

        public static dstCommon StatusCmbTable()
        {
            dstCommon returnDst = new dstCommon();
            dstCommonTableAdapters.spr_cmn_Status_cmb_SelectTableAdapter adapter =
                new dstCommonTableAdapters.spr_cmn_Status_cmb_SelectTableAdapter();
            try
            {
                adapter.FillStatusCmbTable(returnDst.spr_cmn_Status_cmb_Select);
            }
            catch
            {
                returnDst = null;
            }
            return returnDst;
        }
    }
}
