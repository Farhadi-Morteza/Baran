using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BaranDataAccess.Common;
using System.Runtime.InteropServices;
using System.Drawing;

namespace Baran.Classes.Common
{
    class ComboBoxSetting
    {
        private static Windows.Forms.ComboBox InitializeComboBox(Windows.Forms.ComboBox cmb, Enum e)
        {
            //cmb.DataSource = Enum.GetValues(typeof(e));            
            return cmb;
        }

        public static void FillComboBox(PublicEnum.EnmComboSource ComboSurce, Baran.Windows.Forms.UltraComboEditor ComboName, [Optional] string OptParam)
        {
            try
            {
                switch (ComboSurce)
                {
                    #region Province
                    case PublicEnum.EnmComboSource.srcProvince:
                        {
                            BaranDataAccess.Common.dstCommon ProvinceDst;
                            ProvinceDst = BaranDataAccess.Common.dstCommon.ProvinceTable();

                            ComboName.DataSource = ProvinceDst.spr_cmn_Province_Select;
                            ComboName.ValueMember = ProvinceDst.spr_cmn_Province_Select.ProvinceIDColumn.ColumnName;
                            ComboName.DisplayMember = ProvinceDst.spr_cmn_Province_Select.ProvinceNameColumn.ColumnName;
                            break;
                        }
                    #endregion
                    #region Township
                    case PublicEnum.EnmComboSource.srcTownship:
                        {

                            BaranDataAccess.Common.dstCommon TownshipDst;
                            BaranDataAccess.Common.dstCommon TownshipFilterDst = new dstCommon();

                            TownshipDst = Baran.Classes.Singleton.Township.Instance.DstTownship;                            

                            TownshipFilterDst.Merge(TownshipDst.spr_cmn_Township_Select.Select(" Fk_ProvinceID =  " + OptParam));

                            ComboName.DataSource = TownshipFilterDst.spr_cmn_Township_Select;
                            ComboName.ValueMember = TownshipFilterDst.spr_cmn_Township_Select.TownshipIDColumn.ColumnName;
                            ComboName.DisplayMember = TownshipFilterDst.spr_cmn_Township_Select.TownshipNameColumn.ColumnName;
                            break;
                        }
                    #endregion
                    #region Company
                    case PublicEnum.EnmComboSource.srcCompany:
                        {
                            BaranDataAccess.Company.dstCompany CompanyDst;
                            CompanyDst = BaranDataAccess.Company.dstCompany.CompanyTable(CurrentUser.Instance.UserID);

                            ComboName.DataSource = CompanyDst.spr_src_Company_Select;
                            ComboName.ValueMember = CompanyDst.spr_src_Company_Select.CompanyIDColumn.ColumnName;
                            ComboName.DisplayMember = CompanyDst.spr_src_Company_Select.NameColumn.ColumnName;
                            break;
                        }
                    #endregion
                    #region CompanyCategory
                    case PublicEnum.EnmComboSource.srcCompanyCategory:
                        {
                            BaranDataAccess.Company.dstCompany CompanyCategoryDst;
                            CompanyCategoryDst = BaranDataAccess.Company.dstCompany.CompanyCategoryTable();

                            ComboName.DataSource = CompanyCategoryDst.spr_src_CompanyCategory_Select;
                            ComboName.ValueMember = CompanyCategoryDst.spr_src_CompanyCategory_Select.CompanyCategoryIDColumn.ColumnName;
                            ComboName.DisplayMember = CompanyCategoryDst.spr_src_CompanyCategory_Select.NameFaColumn.ColumnName;
                            break;
                        }
                    #endregion
                    #region Collection
                    case PublicEnum.EnmComboSource.srcCollection:
                        {
                            BaranDataAccess.Company.dstCompany CollectionDst;
                            CollectionDst = BaranDataAccess.Company.dstCompany.CollectionTable(CurrentUser.Instance.UserID);

                            ComboName.DataSource = CollectionDst.spr_src_Collection_Select ;
                            ComboName.ValueMember = CollectionDst.spr_src_Collection_Select.CollectionIDColumn.ColumnName;
                            ComboName.DisplayMember = CollectionDst.spr_src_Collection_Select.NameColumn.ColumnName;
                            break;
                        }
                    #endregion
                    #region Subcollection
                    case PublicEnum.EnmComboSource.srcSubcollection:
                        {
                            BaranDataAccess.Company.dstCompany SubcollectionDst;
                            SubcollectionDst = BaranDataAccess.Company.dstCompany.SubcollectionTable(CurrentUser.Instance.UserID);

                            ComboName.DataSource = SubcollectionDst.spr_src_Subcollection_Select;
                            ComboName.ValueMember = SubcollectionDst.spr_src_Subcollection_Select.SubCollectionIDColumn.ColumnName;
                            ComboName.DisplayMember = SubcollectionDst.spr_src_Subcollection_Select.NameColumn.ColumnName;
                            break;
                        }
                    #endregion
                    #region Part
                    case PublicEnum.EnmComboSource.srcPart:
                        {
                            BaranDataAccess.Company.dstCompany PartDst;
                            PartDst = BaranDataAccess.Company.dstCompany.PartTable(CurrentUser.Instance.UserID);

                            ComboName.DataSource = PartDst.spr_src_Part_Select;
                            ComboName.ValueMember = PartDst.spr_src_Part_Select.PartIDColumn.ColumnName;
                            ComboName.DisplayMember = PartDst.spr_src_Part_Select.NameColumn.ColumnName;
                            break;
                        }
                    #endregion
                    #region SoilTexture
                    case PublicEnum.EnmComboSource.srcSoilTexture:
                        {
                            BaranDataAccess.Common.dstCommon SoilTextureDst;
                            SoilTextureDst = BaranDataAccess.Common.dstCommon.SoilTextureTable();

                            ComboName.DataSource = SoilTextureDst.spr_cmn_SoilTexture_Select;
                            ComboName.ValueMember = SoilTextureDst.spr_cmn_SoilTexture_Select.SoilTextureIDColumn.ColumnName;
                            ComboName.DisplayMember = SoilTextureDst.spr_cmn_SoilTexture_Select.NameColumn.ColumnName;
                            break;
                        }
                    #endregion
                    #region Ownership
                    case PublicEnum.EnmComboSource.srcOwnership:
                        {
                            BaranDataAccess.Common.dstCommon OwnershipDst;
                            OwnershipDst = BaranDataAccess.Common.dstCommon.OwnershipTable();

                            ComboName.DataSource = OwnershipDst.spr_cmn_Ownership_Select;
                            ComboName.ValueMember = OwnershipDst.spr_cmn_Ownership_Select.OwnershipIDColumn.ColumnName;
                            ComboName.DisplayMember = OwnershipDst.spr_cmn_Ownership_Select.NameFaColumn.ColumnName;
                            break;
                        }
                    #endregion
                    #region Activity
                    case PublicEnum.EnmComboSource.srcActivity:
                        {
                            BaranDataAccess.Common.dstCommon ActivityDst;
                            ActivityDst = BaranDataAccess.Common.dstCommon.ActivityTable();

                            ComboName.DataSource = ActivityDst.spr_cmn_Activity_Select;
                            ComboName.ValueMember = ActivityDst.spr_cmn_Activity_Select.ActivityIDColumn.ColumnName;
                            ComboName.DisplayMember = ActivityDst.spr_cmn_Activity_Select.NameColumn.ColumnName;
                            break;
                        }
                    #endregion
                    #region Activity by BusinessID
                    case PublicEnum.EnmComboSource.srcActivityByBusinessID:
                        {
                            BaranDataAccess.Common.dstCommon ActivityDst;
                            ActivityDst = BaranDataAccess.Common.dstCommon.ActivityByBusinessIDTable(Convert.ToInt32(OptParam));

                            ComboName.DataSource = ActivityDst.spr_cmn_Activity_Select;
                            ComboName.ValueMember = ActivityDst.spr_cmn_Activity_Select.ActivityIDColumn.ColumnName;
                            ComboName.DisplayMember = ActivityDst.spr_cmn_Activity_Select.NameColumn.ColumnName;
                            break;
                        }
                    #endregion
                    #region Crop
                    case PublicEnum.EnmComboSource.srcCrop:
                        {
                            BaranDataAccess.Common.dstCommon CropDst;

                            if (Convert.ToInt32( OptParam ) > 0)
                                CropDst = dstCommon.CropCmbTable(Convert.ToInt32(OptParam));
                            else
                                CropDst = dstCommon.CropCmbTable(null);

                            ComboName.DataSource = CropDst.spr_cmn_Crop_cmb_Select;
                            ComboName.ValueMember = CropDst.spr_cmn_Crop_cmb_Select.CropIDColumn.ColumnName;
                            ComboName.DisplayMember = CropDst.spr_cmn_Crop_cmb_Select.NameFaColumn.ColumnName;
                            break;
                        }
                    #endregion 
                    #region CropCategory
                    case PublicEnum.EnmComboSource.srcCropCategory:
                        {
                            BaranDataAccess.Common.dstCommon CropDst;
                            CropDst = BaranDataAccess.Common.dstCommon.CropCategoryTable();

                            ComboName.DataSource = CropDst.spr_cmn_CropCategory_Select;
                            ComboName.ValueMember = CropDst.spr_cmn_CropCategory_Select.CropCategoryIDColumn.ColumnName;
                            ComboName.DisplayMember = CropDst.spr_cmn_CropCategory_Select.NameColumn.ColumnName;
                            break;
                        }
                    #endregion
                    #region FieldUseType
                    case PublicEnum.EnmComboSource.srcFieldUseType:
                        {
                            BaranDataAccess.Common.dstCommon FielUseTypeDst;
                            FielUseTypeDst = BaranDataAccess.Common.dstCommon.FieldUseTypeTable();

                            ComboName.DataSource = FielUseTypeDst.spr_src_FieldUseType_Select;
                            ComboName.ValueMember = FielUseTypeDst.spr_src_FieldUseType_Select.FieldUseTypeIDColumn.ColumnName;
                            ComboName.DisplayMember = FielUseTypeDst.spr_src_FieldUseType_Select.NameFaColumn.ColumnName;
                            break;
                        }
                    #endregion
                    #region WaterSourceType
                    case PublicEnum.EnmComboSource.srcWaterSourceType:
                        {
                            BaranDataAccess.Common.dstCommon WaterSourceTypeDst;
                            WaterSourceTypeDst = BaranDataAccess.Common.dstCommon.WaterSourceTypeTable();

                            ComboName.DataSource = WaterSourceTypeDst.spr_src_WaterSourcType_Select;
                            ComboName.ValueMember = WaterSourceTypeDst.spr_src_WaterSourcType_Select.WaterSourceTypeIDColumn.ColumnName;
                            ComboName.DisplayMember = WaterSourceTypeDst.spr_src_WaterSourcType_Select.NameFaColumn.ColumnName;
                            break;
                        }
                    #endregion
                    #region WarehouseType
                    case PublicEnum.EnmComboSource.srcWarehouseType:
                        {
                            BaranDataAccess.Common.dstCommon WarehouseTypeDst;
                            WarehouseTypeDst = BaranDataAccess.Common.dstCommon.WarehouseTypeTable();

                            ComboName.DataSource = WarehouseTypeDst.spr_src_WarehouseType_Select;
                            ComboName.ValueMember = WarehouseTypeDst.spr_src_WarehouseType_Select.WarehouseTypeIDColumn.ColumnName;
                            ComboName.DisplayMember = WarehouseTypeDst.spr_src_WarehouseType_Select.NameColumn.ColumnName;
                            break;
                        }
                    #endregion
                    #region MachineryCategory
                    case PublicEnum.EnmComboSource.srcMachineryCategory:
                        {
                            BaranDataAccess.Common.dstCommon MachineryCategoryDst;
                            MachineryCategoryDst = BaranDataAccess.Common.dstCommon.MachineryCategoryTable();

                            ComboName.DataSource = MachineryCategoryDst.spr_src_MachineryCategory_Select;
                            ComboName.ValueMember = MachineryCategoryDst.spr_src_MachineryCategory_Select.MachineryCategoryIDColumn.ColumnName;
                            ComboName.DisplayMember = MachineryCategoryDst.spr_src_MachineryCategory_Select.MachineryCategoryNameColumn.ColumnName;
                            break;
                        }
                    #endregion
                    #region BuildingsCategory
                    case PublicEnum.EnmComboSource.srcBuildingsCategory:
                        {
                            BaranDataAccess.Common.dstCommon BuildingsCategoryDst;
                            BuildingsCategoryDst = BaranDataAccess.Common.dstCommon.BuildingsCategoryTable();

                            ComboName.DataSource = BuildingsCategoryDst.spr_src_BuildingsCategory_Select;
                            ComboName.ValueMember = BuildingsCategoryDst.spr_src_BuildingsCategory_Select.BuildingsCategoryIDColumn.ColumnName;
                            ComboName.DisplayMember = BuildingsCategoryDst.spr_src_BuildingsCategory_Select.NameColumn.ColumnName;
                            break;
                        }
                    #endregion
                    #region WarehouseUseType
                    case PublicEnum.EnmComboSource.srcWarehouseUseType:
                        {
                            BaranDataAccess.Common.dstCommon WarehouseUseTypeDst;
                            WarehouseUseTypeDst = BaranDataAccess.Common.dstCommon.WarehouseUseTypeTable();

                            ComboName.DataSource = WarehouseUseTypeDst.spr_src_WarehouseUseType_Select;
                            ComboName.ValueMember = WarehouseUseTypeDst.spr_src_WarehouseUseType_Select.WarehouseUseTypeIDColumn.ColumnName;
                            ComboName.DisplayMember = WarehouseUseTypeDst.spr_src_WarehouseUseType_Select.NameColumn.ColumnName;
                            break;
                        }
                    #endregion
                    #region WaterTransmissionType
                    case PublicEnum.EnmComboSource.srcWaterTransmissionType:
                        {
                            BaranDataAccess.Common.dstCommon WaterTransmissionTypeDst;
                            WaterTransmissionTypeDst = BaranDataAccess.Common.dstCommon.WaterTransmissionTypeTable();

                            ComboName.DataSource = WaterTransmissionTypeDst.spr_src_WaterTransmissionType_Select;
                            ComboName.ValueMember = WaterTransmissionTypeDst.spr_src_WaterTransmissionType_Select.WaterTransmissionTypeIDColumn.ColumnName;
                            ComboName.DisplayMember = WaterTransmissionTypeDst.spr_src_WaterTransmissionType_Select.NameColumn.ColumnName;
                            break;
                        }
                    #endregion
                    #region UserAccessType
                    case PublicEnum.EnmComboSource.srcUserType:
                        {

                            BaranDataAccess.Security.dstSecurity UserTypeDst;
                            UserTypeDst = BaranDataAccess.Security.dstSecurity.GetUserType();

                            ComboName.DataSource = UserTypeDst.spr_Sec_UserType_Select;
                            ComboName.ValueMember = UserTypeDst.spr_Sec_UserType_Select.UserTypeIDColumn.ColumnName;
                            ComboName.DisplayMember = UserTypeDst.spr_Sec_UserType_Select.UserTypeNameColumn.ColumnName;
                            break;
                        }
                    #endregion
                    #region Field
                    case PublicEnum.EnmComboSource.srcFieldByUserID:
                        {
                            BaranDataAccess.Common.dstCommon FieldDst;
                            FieldDst = BaranDataAccess.Common.dstCommon.FieldByUserID(CurrentUser.Instance.UserID);

                            ComboName.DataSource = FieldDst.spr_src_FieldByUserID_Select;
                            ComboName.ValueMember = FieldDst.spr_src_FieldByUserID_Select.FieldIDColumn.ColumnName;
                            ComboName.DisplayMember = FieldDst.spr_src_FieldByUserID_Select.NameColumn.ColumnName;
                            break;
                        }
                    #endregion
                    #region Land
                    case PublicEnum.EnmComboSource.srcLand:
                        {
                            BaranDataAccess.Common.dstCommon LandDst;
                            LandDst = BaranDataAccess.Common.dstCommon.LandByUserID(CurrentUser.Instance.UserID);

                            ComboName.DataSource = LandDst.spr_src_LandByUserID_Select;
                            ComboName.ValueMember = LandDst.spr_src_LandByUserID_Select.LandIDColumn.ColumnName;
                            ComboName.DisplayMember = LandDst.spr_src_LandByUserID_Select.NameColumn.ColumnName;
                            break;
                        }
                    #endregion
                    #region Cultivar
                    case PublicEnum.EnmComboSource.srcCultivar:
                        {
                            BaranDataAccess.Common.dstCommon CultivarDst;
                            CultivarDst = BaranDataAccess.Common.dstCommon.CultivarByCropIDTable(Convert.ToInt32(OptParam));

                            ComboName.DataSource = CultivarDst.spr_cmn_CultivarByCropId_Select;
                            ComboName.ValueMember = CultivarDst.spr_cmn_CultivarByCropId_Select.CultivarIDColumn.ColumnName;
                            ComboName.DisplayMember = CultivarDst.spr_cmn_CultivarByCropId_Select.NameFaColumn.ColumnName;
                            break;
                        }
                    #endregion
                    #region UnitMeasurement
                    case PublicEnum.EnmComboSource.srcUnitMeasurement:
                        {
                            BaranDataAccess.Common.dstCommon UnitMeasurementDst;
                            if (OptParam != null)
                            {
                                UnitMeasurementDst = dstCommon.UnitMeasurementTable(Convert.ToInt32(OptParam));
                            }
                            else
                                UnitMeasurementDst = dstCommon.UnitMeasurementTable(null);

                            ComboName.DataSource = UnitMeasurementDst.spr_cmn_UnitMeasurement_Select;
                            ComboName.ValueMember = UnitMeasurementDst.spr_cmn_UnitMeasurement_Select.UnitMeasurementIDColumn.ColumnName;
                            ComboName.DisplayMember = UnitMeasurementDst.spr_cmn_UnitMeasurement_Select.NameFaColumn.ColumnName;
                            break;
                        }
                    #endregion                        
                    #region Country
                    case PublicEnum.EnmComboSource.srcCountry:
                        {
                            BaranDataAccess.Common.dstCommon CountryDst;

                            CountryDst = BaranDataAccess.Common.dstCommon.CountryTable();

                            ComboName.DataSource = CountryDst.spr_cmn_Country_cmb_Select;
                            ComboName.ValueMember = CountryDst.spr_cmn_Country_cmb_Select.CountryIDColumn.ColumnName;
                            ComboName.DisplayMember = CountryDst.spr_cmn_Country_cmb_Select.NameColumn.ColumnName;
                            break;
                        }
                    #endregion
                    #region Fertilizer Category
                    case PublicEnum.EnmComboSource.srcFertilizerCategory:
                        {
                            BaranDataAccess.Product.dstProduct FertilizerCategoryDst;

                            FertilizerCategoryDst = Baran.Classes.Singleton.FertilizerCategory.Instance.FertilizerCategoryDst;

                            ComboName.DataSource = FertilizerCategoryDst.spr_src_FertilizerCategory_cmb_Select;
                            ComboName.ValueMember = FertilizerCategoryDst.spr_src_FertilizerCategory_cmb_Select.FertilizerCategoryIDColumn.ColumnName;
                            ComboName.DisplayMember = FertilizerCategoryDst.spr_src_FertilizerCategory_cmb_Select.NameFaColumn.ColumnName;
                            break;
                        }
                    #endregion
                    #region Pesticide Category
                    case PublicEnum.EnmComboSource.srcPesticideCategory:
                        {
                            BaranDataAccess.Product.dstProduct PesticideCategoryDst;

                            PesticideCategoryDst = BaranDataAccess.Product.dstProduct.PesticideCategoryCmbTable();

                            ComboName.DataSource = PesticideCategoryDst.spr_src_PesticideCategory_cmb_Select;
                            ComboName.ValueMember = PesticideCategoryDst.spr_src_PesticideCategory_cmb_Select.PesticideCategoryIDColumn.ColumnName;
                            ComboName.DisplayMember = PesticideCategoryDst.spr_src_PesticideCategory_cmb_Select.NameFaColumn.ColumnName;
                            break;
                        }
                    #endregion
                    #region Person Category
                    case PublicEnum.EnmComboSource.srcPersonCategory:
                        {
                            BaranDataAccess.Product.dstProduct PersonCategoryDst;
                            PersonCategoryDst = BaranDataAccess.Product.dstProduct.PersonCategoryCmbTable();

                            ComboName.DataSource = PersonCategoryDst.spr_src_PersonCategory_cmb_Select;
                            ComboName.ValueMember = PersonCategoryDst.spr_src_PersonCategory_cmb_Select.PersonCategoryIDColumn.ColumnName;
                            ComboName.DisplayMember = PersonCategoryDst.spr_src_PersonCategory_cmb_Select.NameFaColumn.ColumnName;
                            break;
                        }
                    #endregion
                    #region Person by Category Cmb
                    case PublicEnum.EnmComboSource.srcPersonByPersonCategoryIDCmb:
                        {
                            BaranDataAccess.Product.dstProduct PersonByCategoryDst;
                            PersonByCategoryDst = BaranDataAccess.Product.dstProduct.PersonByPersosnCategoryCmbTable(Convert.ToInt32(OptParam), CurrentUser.Instance.UserID);

                            ComboName.DataSource = PersonByCategoryDst.spr_src_PersonByPersonCategoriID_Cmb_Select;
                            ComboName.ValueMember = PersonByCategoryDst.spr_src_PersonByPersonCategoriID_Cmb_Select.PersonIDColumn.ColumnName;
                            ComboName.DisplayMember = PersonByCategoryDst.spr_src_PersonByPersonCategoriID_Cmb_Select.PersonNameColumn.ColumnName;
                            break;
                        }
                    #endregion
                    #region Material Mode
                    case PublicEnum.EnmComboSource.srcMaterialMode:
                        {
                            BaranDataAccess.Common.dstCommon MaterialModeDst;                            
                            MaterialModeDst = Baran.Classes.Singleton.MaterialMode.Instance.MaterialModeDst;

                            ComboName.DataSource = MaterialModeDst.spr_cmn_MaterialMode_cmb_Select;
                            ComboName.ValueMember = MaterialModeDst.spr_cmn_MaterialMode_cmb_Select.MaterialModeIDColumn.ColumnName;
                            ComboName.DisplayMember = MaterialModeDst.spr_cmn_MaterialMode_cmb_Select.NameFaColumn.ColumnName;
                            break;
                        }
                    #endregion
                    #region Product Category
                    case PublicEnum.EnmComboSource.srcProductCategory:
                        {
                            BaranDataAccess.Common.dstCommon ProductCategoryDst;
                            ProductCategoryDst = Baran.Classes.Singleton.ProductCategory.Instance.ProductCategoryDst;

                            ComboName.DataSource = ProductCategoryDst.spr_cmn_ProductCategory_cmb_Select;
                            ComboName.ValueMember = ProductCategoryDst.spr_cmn_ProductCategory_cmb_Select.ProductCategoryIDColumn.ColumnName;
                            ComboName.DisplayMember = ProductCategoryDst.spr_cmn_ProductCategory_cmb_Select.NameFaColumn.ColumnName;
                            break;
                        }
                    #endregion
                    #region Element
                    case PublicEnum.EnmComboSource.srcElement:
                        {
                            BaranDataAccess.Common.dstCommon ElementDst;
                            ElementDst = Baran.Classes.Singleton.Element.Instance.ElementDst;

                            ComboName.DataSource = ElementDst.spr_cmn_Element_cmb_Select;
                            ComboName.ValueMember = ElementDst.spr_cmn_Element_cmb_Select.ElementIDColumn.ColumnName;
                            ComboName.DisplayMember = ElementDst.spr_cmn_Element_cmb_Select.NameFaColumn.ColumnName;
                            break;
                        }
                    #endregion
                    #region Unit measurment
                    case PublicEnum.EnmComboSource.srcUnitMeasurementAll:
                        {
                            BaranDataAccess.Common.dstCommon UnitMeasurementAllDst;
                            UnitMeasurementAllDst = Baran.Classes.Singleton.UnitMeasurement.Instance.UnitMeasurementDst;

                            ComboName.DataSource = UnitMeasurementAllDst.spr_cmn_UnitMeasurement_cmb_Select;
                            ComboName.ValueMember = UnitMeasurementAllDst.spr_cmn_UnitMeasurement_cmb_Select.UnitMeasurementIDColumn.ColumnName;
                            ComboName.DisplayMember = UnitMeasurementAllDst.spr_cmn_UnitMeasurement_cmb_Select.NameFaColumn.ColumnName;
                            break;
                        }
                    #endregion
                    #region Tree Type
                    case PublicEnum.EnmComboSource.srcTreeType:
                        {
                            BaranDataAccess.Product.dstProduct TreeTypeDst;
                            TreeTypeDst = Baran.Classes.Singleton.TreeType.Instance.TreeTypeDst;

                            ComboName.DataSource = TreeTypeDst.spr_src_TreeType_Cmd_Select;
                            ComboName.ValueMember = TreeTypeDst.spr_src_TreeType_Cmd_Select.TreeTypeIDColumn.ColumnName;
                            ComboName.DisplayMember = TreeTypeDst.spr_src_TreeType_Cmd_Select.NameColumn.ColumnName;
                            break;
                        }
                    #endregion
                    #region Tasklist
                    case PublicEnum.EnmComboSource.srcTasklist:
                        {
                            BaranDataAccess.Task.dstTask TasklistDst;
                            TasklistDst = BaranDataAccess.Task.dstTask.TasklistCmbTable();

                            ComboName.DataSource = TasklistDst.spr_tsk_Tasklist_cmb_Select;
                            ComboName.ValueMember = TasklistDst.spr_tsk_Tasklist_cmb_Select.TasklistIDColumn.ColumnName;
                            ComboName.DisplayMember = TasklistDst.spr_tsk_Tasklist_cmb_Select.TasklistNameColumn.ColumnName;
                            break;
                        }
                    #endregion
                    #region TasklistCrop By CropID
                    case PublicEnum.EnmComboSource.srcTasklistCropByCropID:
                        {
                            BaranDataAccess.Task.dstTask TasklistCropByCropIDDst;
                            TasklistCropByCropIDDst = BaranDataAccess.Task.dstTask.TasklistCropCmbByCropIDTable(Convert.ToInt32(OptParam));

                            ComboName.DataSource = TasklistCropByCropIDDst.spr_tsk_TasklistCrop_cmb_ByCropID_Select;
                            ComboName.ValueMember = TasklistCropByCropIDDst.spr_tsk_TasklistCrop_cmb_ByCropID_Select.TasklistIDColumn.ColumnName;
                            ComboName.DisplayMember = TasklistCropByCropIDDst.spr_tsk_TasklistCrop_cmb_ByCropID_Select.TasklistNameColumn.ColumnName;
                            break;
                        }
                    #endregion
                    #region Task Categori
                    case PublicEnum.EnmComboSource.srcTaskCategory:
                        {
                            BaranDataAccess.Task.dstTask TaskCategoryDst;
                            TaskCategoryDst = BaranDataAccess.Task.dstTask.TaskCategoryCmbTable();

                            ComboName.DataSource = TaskCategoryDst.spr_tsk_TaskCategori_Cmb_Select;
                            ComboName.ValueMember = TaskCategoryDst.spr_tsk_TaskCategori_Cmb_Select.TaskCategoryIDColumn.ColumnName;
                            ComboName.DisplayMember = TaskCategoryDst.spr_tsk_TaskCategori_Cmb_Select.TaskCategoryNameColumn.ColumnName;
                            break;
                        }
                    #endregion
                    #region Task SubCategori
                    case PublicEnum.EnmComboSource.srcTaskSubCategory:
                        {
                            BaranDataAccess.Task.dstTask TaskSubCategoryDst;
                            TaskSubCategoryDst = BaranDataAccess.Task.dstTask.TaskSubCategoryCmbTable();

                            ComboName.DataSource = TaskSubCategoryDst.spr_tsk_TaskSubCategori_Cmb_Select;
                            ComboName.ValueMember = TaskSubCategoryDst.spr_tsk_TaskSubCategori_Cmb_Select.TaskSubCategoryIDColumn.ColumnName;
                            ComboName.DisplayMember = TaskSubCategoryDst.spr_tsk_TaskSubCategori_Cmb_Select.TaskSubCategoryNameColumn.ColumnName;
                            break;
                        }
                    #endregion
                    #region Task SubCategori By Task Category ID
                    case PublicEnum.EnmComboSource.srcTaskSubCategoryByTaskCategoryID:
                        {
                            BaranDataAccess.Task.dstTask TaskSubCategoryDst;
                            TaskSubCategoryDst = BaranDataAccess.Task.dstTask.TaskSubCategoryByTaskCategoryIDCmbTable(Convert.ToInt32(OptParam));

                            ComboName.DataSource = TaskSubCategoryDst.spr_tsk_TaskSubCategori_Cmb_Select;
                            ComboName.ValueMember = TaskSubCategoryDst.spr_tsk_TaskSubCategori_Cmb_Select.TaskSubCategoryIDColumn.ColumnName;
                            ComboName.DisplayMember = TaskSubCategoryDst.spr_tsk_TaskSubCategori_Cmb_Select.TaskSubCategoryNameColumn.ColumnName;
                            break;
                        }
                    #endregion
                    #region Business
                    case PublicEnum.EnmComboSource.srcBusiness:
                        {
                            BaranDataAccess.Common.dstCommon BusinessDst;
                            BusinessDst = BaranDataAccess.Common.dstCommon.BusinessTable();

                            ComboName.DataSource = BusinessDst.spr_cmn_Business_cmb_Select;
                            ComboName.ValueMember = BusinessDst.spr_cmn_Business_cmb_Select.BusinessIDColumn.ColumnName;
                            ComboName.DisplayMember = BusinessDst.spr_cmn_Business_cmb_Select.NameFaColumn.ColumnName;
                            break;
                        }
                    #endregion
                    #region Business by BusinessCategoryID
                    case PublicEnum.EnmComboSource.srcBusinessByBusinessCategoryID:
                        {
                            BaranDataAccess.Common.dstCommon BusinessDst;
                            BusinessDst = BaranDataAccess.Common.dstCommon.BusinessByBusinessCategoryIDTable(Convert.ToInt32( OptParam));

                            ComboName.DataSource = BusinessDst.spr_cmn_Business_cmb_Select;
                            ComboName.ValueMember = BusinessDst.spr_cmn_Business_cmb_Select.BusinessIDColumn.ColumnName;
                            ComboName.DisplayMember = BusinessDst.spr_cmn_Business_cmb_Select.NameFaColumn.ColumnName;
                            break;
                        }
                    #endregion

                    #region Business Category
                    case PublicEnum.EnmComboSource.srcBusinessCategory:
                        {
                            BaranDataAccess.Common.dstCommon BusinessCategoryDst;
                            BusinessCategoryDst = BaranDataAccess.Common.dstCommon.BusinessCategoryTable();

                            ComboName.DataSource = BusinessCategoryDst.spr_cmn_BusinessCategory_cmb_Select;
                            ComboName.ValueMember = BusinessCategoryDst.spr_cmn_BusinessCategory_cmb_Select.BusinessCategoryIDColumn.ColumnName;
                            ComboName.DisplayMember = BusinessCategoryDst.spr_cmn_BusinessCategory_cmb_Select.NameColumn.ColumnName;
                            break;
                        }
                    #endregion
                    #region Gender
                    case PublicEnum.EnmComboSource.srcGender:
                        {
                            BaranDataAccess.Common.dstCommon GenderDst;
                            GenderDst = BaranDataAccess.Common.dstCommon.GenderCmbTable();

                            ComboName.DataSource = GenderDst.spr_cmn_Gender_cmb_Select;
                            ComboName.ValueMember = GenderDst.spr_cmn_Gender_cmb_Select.GenderIDColumn.ColumnName;
                            ComboName.DisplayMember = GenderDst.spr_cmn_Gender_cmb_Select.NameFaColumn.ColumnName;
                            break;
                        }
                    #endregion
                    #region Chemaical Analys Category
                    case PublicEnum.EnmComboSource.srcTask:
                        {
                            BaranDataAccess.Task.dstTask TaskDst;
                            TaskDst = BaranDataAccess.Task.dstTask.TaskCmbTable();

                            ComboName.DataSource = TaskDst.spr_tsk_Task_cmb_Select;
                            ComboName.ValueMember = TaskDst.spr_tsk_Task_cmb_Select.TaskIDColumn.ColumnName;
                            ComboName.DisplayMember = TaskDst.spr_tsk_Task_cmb_Select.TaskNameColumn.ColumnName;
                            break;
                        }
                    #endregion
                    #region Status
                    case PublicEnum.EnmComboSource.srcStatus:
                        {
                            BaranDataAccess.Common.dstCommon dst;
                            dst = Baran.Classes.Singleton.Status.Instance.StatusDst;// BaranDataAccess.Common.dstCommon.StatusCmbTable();

                            ComboName.DataSource = dst.spr_cmn_Status_cmb_Select;
                            ComboName.ValueMember = dst.spr_cmn_Status_cmb_Select.StatusIDColumn.ColumnName;
                            ComboName.DisplayMember = dst.spr_cmn_Status_cmb_Select.StatusNameColumn.ColumnName;
                            break;
                        }
                    #endregion
                    #region Machinery by User ID Cmb
                    case PublicEnum.EnmComboSource.srcMachineryByUserIDCmb:
                        {
                            BaranDataAccess.Source.dstSource dst;
                            dst = BaranDataAccess.Source.dstSource.MachineryByUserIDCmbTable(Convert.ToInt32(OptParam));

                            ComboName.DataSource = dst.spr_src_MachineryByUserID_cmb_Select;
                            ComboName.ValueMember = dst.spr_src_MachineryByUserID_cmb_Select.MachineryIDColumn.ColumnName;
                            ComboName.DisplayMember = dst.spr_src_MachineryByUserID_cmb_Select.NameColumn.ColumnName;
                            break;
                        }
                    #endregion
                    #region Water by User ID Cmb
                    case PublicEnum.EnmComboSource.srcWaterByUserIDCmb:
                        {
                            BaranDataAccess.Source.dstSource dst;
                            dst = BaranDataAccess.Source.dstSource.WaterByUserIDCmbTable(Convert.ToInt32(OptParam));

                            ComboName.DataSource = dst.spr_src_WaterByUserID_cmb_Select;
                            ComboName.ValueMember = dst.spr_src_WaterByUserID_cmb_Select.WaterIDColumn.ColumnName;
                            ComboName.DisplayMember = dst.spr_src_WaterByUserID_cmb_Select.NameColumn.ColumnName;
                            break;
                        }
                    #endregion
                    #region Water Storage by User ID Cmb
                    case PublicEnum.EnmComboSource.srcWaterStorageByUserIDCmb:
                        {
                            BaranDataAccess.Source.dstSource dst;
                            dst = BaranDataAccess.Source.dstSource.WaterStorageByUserIDCmbTable(Convert.ToInt32(OptParam));

                            ComboName.DataSource = dst.spr_src_WaterStorageByUserID_cmb_Select;
                            ComboName.ValueMember = dst.spr_src_WaterStorageByUserID_cmb_Select.WaterStorageIDColumn.ColumnName;
                            ComboName.DisplayMember = dst.spr_src_WaterStorageByUserID_cmb_Select.NameColumn.ColumnName;
                            break;
                        }
                    #endregion
                    #region Chemical Analys Category
                    case PublicEnum.EnmComboSource.srcChemicalAnalysCategory:
                        {
                            BaranDataAccess.Product.dstProduct dst;
                            dst = BaranDataAccess.Product.dstProduct.ChemicalAnalysCategoryCmbTable();

                            ComboName.DataSource = dst.spr_src_ChemicalAnalysCategory_cmb_Select;
                            ComboName.ValueMember = dst.spr_src_ChemicalAnalysCategory_cmb_Select.ChemicalAnalysisCategoryIDColumn.ColumnName;
                            ComboName.DisplayMember = dst.spr_src_ChemicalAnalysCategory_cmb_Select.NameFaColumn.ColumnName;
                            break;
                        }
                    #endregion


                    #region Font
                    case PublicEnum.EnmComboSource.srcFont:
                        {
                            ComboName.Items.Clear();
                            ComboName.ResetText();

                            ComboName.DataSource = null;
                            ComboName.ValueMember = null;
                            foreach (FontFamily fontFamily in FontFamily.Families)
                            {

                                ComboName.Items.Add(fontFamily.Name);
                            }

                            break;
                        }
                    #endregion
                    #region FontSize
                    case PublicEnum.EnmComboSource.srcFontSize:
                        {
                            ComboName.Items.Clear();
                            ComboName.ResetText();

                            ComboName.DataSource = null;
                            ComboName.ValueMember = null;

                            string[] aryFontSize = { "8", "9", "10", "11", "12", "14", "16" , "18", "20", "22", "24", "26", "28", "36", "48", "72"};
                            foreach (var fontSize in aryFontSize)
                            {

                                ComboName.Items.Add(fontSize);
                            }

                            break;
                        }
                    #endregion
                    #region Databeses
                    case PublicEnum.EnmComboSource.srcDatabase:
                        {
                            BaranDataAccess.Security.dstSecurity DatabaseDst;
                            DatabaseDst = BaranDataAccess.Security.dstSecurity.GetDatabases();

                            ComboName.DataSource = DatabaseDst.spr_Sec_Databases_Select;
                            ComboName.ValueMember = DatabaseDst.spr_Sec_Databases_Select.dbidColumn.ColumnName;
                            ComboName.DisplayMember = DatabaseDst.spr_Sec_Databases_Select.dbNameColumn.ColumnName;
                            break;
                        }
                    #endregion                
                }

            }
            catch (Exception)
            {


            }
        }

    }
}
