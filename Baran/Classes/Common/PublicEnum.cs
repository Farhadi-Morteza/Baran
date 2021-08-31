using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Baran.Classes.Common
{
    public static class PublicEnum
    {
        public enum EnmComboSource
        {
            srcProvince = 1,
            srcTownship = 2,
            srcCompanyCategory   = 3,
            srcCollection = 4,
            srcSubcollection = 5,
            srcPart = 6,
            srcSoilTexture = 7,
            srcOwnership = 8,
            srcFieldUseType = 9,
            srcWaterSourceType = 10,
            srcWarehouseType = 11,
            srcMachineryCategory = 12,
            srcBuildingsCategory = 13,
            srcWarehouseUseType = 14,
            srcWaterTransmissionType =15,
            srcUserType = 16,
            srcCompany = 17,
            srcCrop = 18,
            srcField = 19,
            srcCultivar = 20,
            srcActivity = 21,
            srcCropCategory = 22,
            srcUnitMeasurement = 23,
            srcCountry = 24,

            srcFont = 26,
            srcFontStyle = 27,
            srcFontSize = 28 ,
            srcDatabase = 34,
            srcFertilizerCategory = 35,
            srcMaterialMode = 36,
            srcProductCategory = 37,
            srcElement = 38,
            srcUnitMeasurementAll = 39,
            srcTreeType = 40,
            srcBusinessCategory = 41,
            srcBusiness = 42,
            srcTaskCategory = 43,
            srcPesticideCategory = 44,
            srcPersonCategory = 45,
            srcGender = 46,
            srcChemicalAnalysCategory = 47,
            srcTaskSubCategory = 48,
            srcTask = 49,
            srcTasklist = 50,
            srcTasklistCropByCropID = 51,
            srcFieldByUserID = 52,
            srcBusinessByBusinessCategoryID = 53,
            srcActivityByBusinessID = 54,
            srcStatus = 55,
            srcPersonByPersonCategoryIDCmb = 56,
            srcMachineryByUserIDCmb = 57,
            srcWaterByUserIDCmb = 58,
            srcWaterStorageByUserIDCmb = 59,
            srcTaskSubCategoryByTaskCategoryID = 60,
            srcLand = 61,
            srcProductionByUserID = 62,
        }

        public enum EnmMessageType
        {
            msgSaveConfirm = 0,
            msgEditConfirm = 1,
            msgDeleteConfirm = 2,
            msgSaveSuccessful = 3,
            msgEditSuccessful = 4,
            msgDeleteSuccessful = 5,
            msgSaveFail = 6,
            msgEditFail = 7,
            msgDeleteFail = 8,
            msgRecordNotFound = 9,
            msgDeleteAccessDenied = 10,
            msgImportSuccessful = 11,
            msgImportFail = 12,
            msgExportSuccessful = 13,
            msgExportFail = 14,
            msgDateInvalid = 15,
            msgImportConfirm = 16,
            msgExportConfirm = 17,
            msgReplaceConfirm = 18,
            msgPrintConfirm = 19,
            msgPrintSuccessful = 20,
            msgPrintFail = 21,
            msgLogOff = 22,
            msgDonnotPermission = 23,
            msgSaveAndOpenFile = 24,
            msgSavedLastTimeEditConfirm = 25,
            msgSaveNotLastTimeSaveConfirm = 26,
            msgExitConfirm = 27,
            msgFileExists = 28,
        }

        public enum EnmMessageCategory
        { 
            Danger = 1,
            Success = 2,
            Info = 3,
            Warning =4
        }

        public enum EnmformItemId
        {
            WaterStorage = 38
            , WaterTransmissionLine = 40
            , Field = 79
            , Map = 6
            , Machinery = 139
            , Collection = 9
            , Subcollecion = 59
            , Part = 61
            , Warehouse = 127
            , Buildings = 43
            , Water = 125
            , Crop = 157
            , Document = 159
            , ProductionTask = 171
            , Land = 178
        }

        public enum EnmShapeType
        {
            point = 1
            , Polygon = 2
            , Rout = 3
        }
    }
}
