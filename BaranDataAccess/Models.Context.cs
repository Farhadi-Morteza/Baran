﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BaranDataAccess
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Objects;
    using System.Data.Objects.DataClasses;
    using System.Linq;
    
    public partial class AMSEntities : DbContext
    {
        public AMSEntities()
            : base("name=AMSEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<sysdiagrams> sysdiagrams { get; set; }
        public DbSet<tbl_cmn_Activity> tbl_cmn_Activity { get; set; }
        public DbSet<tbl_cmn_Alarm> tbl_cmn_Alarm { get; set; }
        public DbSet<tbl_cmn_Business> tbl_cmn_Business { get; set; }
        public DbSet<tbl_cmn_BusinessCategory> tbl_cmn_BusinessCategory { get; set; }
        public DbSet<tbl_cmn_Country> tbl_cmn_Country { get; set; }
        public DbSet<tbl_cmn_Crop> tbl_cmn_Crop { get; set; }
        public DbSet<tbl_cmn_CropCategory> tbl_cmn_CropCategory { get; set; }
        public DbSet<tbl_cmn_Cultivar> tbl_cmn_Cultivar { get; set; }
        public DbSet<tbl_cmn_Document> tbl_cmn_Document { get; set; }
        public DbSet<tbl_cmn_Element> tbl_cmn_Element { get; set; }
        public DbSet<tbl_cmn_Gender> tbl_cmn_Gender { get; set; }
        public DbSet<tbl_cmn_Irrigation> tbl_cmn_Irrigation { get; set; }
        public DbSet<tbl_cmn_IrrigationType> tbl_cmn_IrrigationType { get; set; }
        public DbSet<tbl_cmn_MaterialMode> tbl_cmn_MaterialMode { get; set; }
        public DbSet<tbl_cmn_MeasurementCategory> tbl_cmn_MeasurementCategory { get; set; }
        public DbSet<tbl_cmn_Ownership> tbl_cmn_Ownership { get; set; }
        public DbSet<tbl_cmn_ProductCategory> tbl_cmn_ProductCategory { get; set; }
        public DbSet<tbl_cmn_Province> tbl_cmn_Province { get; set; }
        public DbSet<tbl_cmn_SoilTexture> tbl_cmn_SoilTexture { get; set; }
        public DbSet<tbl_cmn_Status> tbl_cmn_Status { get; set; }
        public DbSet<tbl_cmn_Township> tbl_cmn_Township { get; set; }
        public DbSet<tbl_cmn_UnitMeasurement> tbl_cmn_UnitMeasurement { get; set; }
        public DbSet<tbl_geo_Location> tbl_geo_Location { get; set; }
        public DbSet<tbl_Per_PersonGroups> tbl_Per_PersonGroups { get; set; }
        public DbSet<tbl_prd_Production> tbl_prd_Production { get; set; }
        public DbSet<tbl_prd_Production_Field_Link> tbl_prd_Production_Field_Link { get; set; }
        public DbSet<tbl_prd_ProductionTask> tbl_prd_ProductionTask { get; set; }
        public DbSet<tbl_prd_ProductionTask_ChemicalAnalys_Link> tbl_prd_ProductionTask_ChemicalAnalys_Link { get; set; }
        public DbSet<tbl_prd_ProductionTask_Discussion> tbl_prd_ProductionTask_Discussion { get; set; }
        public DbSet<tbl_prd_ProductionTask_Doc> tbl_prd_ProductionTask_Doc { get; set; }
        public DbSet<tbl_prd_ProductionTask_Fertilizer_Link> tbl_prd_ProductionTask_Fertilizer_Link { get; set; }
        public DbSet<tbl_prd_ProductionTask_Machinery_Link> tbl_prd_ProductionTask_Machinery_Link { get; set; }
        public DbSet<tbl_prd_ProductionTask_Person_Link> tbl_prd_ProductionTask_Person_Link { get; set; }
        public DbSet<tbl_prd_ProductionTask_Pesticide_Link> tbl_prd_ProductionTask_Pesticide_Link { get; set; }
        public DbSet<tbl_prd_ProductionTask_Water_Link> tbl_prd_ProductionTask_Water_Link { get; set; }
        public DbSet<tbl_prd_ProductionTask_WaterStorage_Link> tbl_prd_ProductionTask_WaterStorage_Link { get; set; }
        public DbSet<tbl_prd_Season> tbl_prd_Season { get; set; }
        public DbSet<tbl_Rpt_ReportSettings> tbl_Rpt_ReportSettings { get; set; }
        public DbSet<tbl_Sec_Current_User> tbl_Sec_Current_User { get; set; }
        public DbSet<tbl_Sec_Items> tbl_Sec_Items { get; set; }
        public DbSet<tbl_Sec_Items_Users_Link> tbl_Sec_Items_Users_Link { get; set; }
        public DbSet<tbl_Sec_Packages> tbl_Sec_Packages { get; set; }
        public DbSet<tbl_Sec_SetupFormsSequenceNumber> tbl_Sec_SetupFormsSequenceNumber { get; set; }
        public DbSet<tbl_Sec_Shops> tbl_Sec_Shops { get; set; }
        public DbSet<tbl_sec_UserCategory> tbl_sec_UserCategory { get; set; }
        public DbSet<tbl_Sec_Users> tbl_Sec_Users { get; set; }
        public DbSet<tbl_Sec_UserTypes> tbl_Sec_UserTypes { get; set; }
        public DbSet<tbl_Setting_Version> tbl_Setting_Version { get; set; }
        public DbSet<tbl_src_Buildings> tbl_src_Buildings { get; set; }
        public DbSet<tbl_src_BuildingsCategory> tbl_src_BuildingsCategory { get; set; }
        public DbSet<tbl_src_ChemicalAnalys> tbl_src_ChemicalAnalys { get; set; }
        public DbSet<tbl_src_ChemicalAnalysisCategory> tbl_src_ChemicalAnalysisCategory { get; set; }
        public DbSet<tbl_src_ChemicalAnalysisElement> tbl_src_ChemicalAnalysisElement { get; set; }
        public DbSet<tbl_src_Collection> tbl_src_Collection { get; set; }
        public DbSet<tbl_src_Company> tbl_src_Company { get; set; }
        public DbSet<tbl_src_CompanyCategory> tbl_src_CompanyCategory { get; set; }
        public DbSet<tbl_src_Fertilizer> tbl_src_Fertilizer { get; set; }
        public DbSet<tbl_src_FertilizerCategory> tbl_src_FertilizerCategory { get; set; }
        public DbSet<tbl_src_FertilizerElement> tbl_src_FertilizerElement { get; set; }
        public DbSet<tbl_src_Field> tbl_src_Field { get; set; }
        public DbSet<tbl_src_FieldUseType> tbl_src_FieldUseType { get; set; }
        public DbSet<tbl_src_Machinery> tbl_src_Machinery { get; set; }
        public DbSet<tbl_src_MachineryCategory> tbl_src_MachineryCategory { get; set; }
        public DbSet<tbl_src_Person> tbl_src_Person { get; set; }
        public DbSet<tbl_src_PersonCategory> tbl_src_PersonCategory { get; set; }
        public DbSet<tbl_src_Pesticide> tbl_src_Pesticide { get; set; }
        public DbSet<tbl_src_PesticideCategory> tbl_src_PesticideCategory { get; set; }
        public DbSet<tbl_src_Seed> tbl_src_Seed { get; set; }
        public DbSet<tbl_src_SeedType> tbl_src_SeedType { get; set; }
        public DbSet<tbl_src_Subcollection> tbl_src_Subcollection { get; set; }
        public DbSet<tbl_src_Tree> tbl_src_Tree { get; set; }
        public DbSet<tbl_src_TreeType> tbl_src_TreeType { get; set; }
        public DbSet<tbl_src_Warehouse> tbl_src_Warehouse { get; set; }
        public DbSet<tbl_src_WarehouseType> tbl_src_WarehouseType { get; set; }
        public DbSet<tbl_src_WareHouseUseType> tbl_src_WareHouseUseType { get; set; }
        public DbSet<tbl_src_Water> tbl_src_Water { get; set; }
        public DbSet<tbl_src_WaterSourceType> tbl_src_WaterSourceType { get; set; }
        public DbSet<tbl_src_WaterStorage> tbl_src_WaterStorage { get; set; }
        public DbSet<tbl_src_WaterStorageD> tbl_src_WaterStorageD { get; set; }
        public DbSet<tbl_src_WaterTransmissionLine> tbl_src_WaterTransmissionLine { get; set; }
        public DbSet<tbl_src_WaterTransmissionType> tbl_src_WaterTransmissionType { get; set; }
        public DbSet<tbl_tsk_Task> tbl_tsk_Task { get; set; }
        public DbSet<tbl_tsk_TaskCategory> tbl_tsk_TaskCategory { get; set; }
        public DbSet<tbl_tsk_Tasklist> tbl_tsk_Tasklist { get; set; }
        public DbSet<tbl_tsk_Tasklist_Crop_Link> tbl_tsk_Tasklist_Crop_Link { get; set; }
        public DbSet<tbl_tsk_Tasklist_Task_Link> tbl_tsk_Tasklist_Task_Link { get; set; }
        public DbSet<tbl_tsk_TaskSubCategory> tbl_tsk_TaskSubCategory { get; set; }
        public DbSet<tbl_src_Land> tbl_src_Land { get; set; }
        public DbSet<tbl_src_Part> tbl_src_Part { get; set; }
        public DbSet<viw_Part_Location> viw_Part_Location { get; set; }
    
        public virtual ObjectResult<spr_src_Land_Map_Select_Result> spr_src_Land_Map_Select(Nullable<int> action, string whereClause, string userID)
        {
            var actionParameter = action.HasValue ?
                new ObjectParameter("Action", action) :
                new ObjectParameter("Action", typeof(int));
    
            var whereClauseParameter = whereClause != null ?
                new ObjectParameter("WhereClause", whereClause) :
                new ObjectParameter("WhereClause", typeof(string));
    
            var userIDParameter = userID != null ?
                new ObjectParameter("UserID", userID) :
                new ObjectParameter("UserID", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spr_src_Land_Map_Select_Result>("spr_src_Land_Map_Select", actionParameter, whereClauseParameter, userIDParameter);
        }
    
        public virtual ObjectResult<spr_src_Field_Map_Select_Result> spr_src_Field_Map_Select(Nullable<int> action, string whereClause, string userID)
        {
            var actionParameter = action.HasValue ?
                new ObjectParameter("Action", action) :
                new ObjectParameter("Action", typeof(int));
    
            var whereClauseParameter = whereClause != null ?
                new ObjectParameter("WhereClause", whereClause) :
                new ObjectParameter("WhereClause", typeof(string));
    
            var userIDParameter = userID != null ?
                new ObjectParameter("UserID", userID) :
                new ObjectParameter("UserID", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spr_src_Field_Map_Select_Result>("spr_src_Field_Map_Select", actionParameter, whereClauseParameter, userIDParameter);
        }
    
        public virtual ObjectResult<spr_src_Buildings_Map_Select_Result> spr_src_Buildings_Map_Select(Nullable<int> action, string whereClause, string userID)
        {
            var actionParameter = action.HasValue ?
                new ObjectParameter("Action", action) :
                new ObjectParameter("Action", typeof(int));
    
            var whereClauseParameter = whereClause != null ?
                new ObjectParameter("WhereClause", whereClause) :
                new ObjectParameter("WhereClause", typeof(string));
    
            var userIDParameter = userID != null ?
                new ObjectParameter("UserID", userID) :
                new ObjectParameter("UserID", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spr_src_Buildings_Map_Select_Result>("spr_src_Buildings_Map_Select", actionParameter, whereClauseParameter, userIDParameter);
        }
    
        public virtual ObjectResult<spr_src_WareHouse_Map_Select_Result> spr_src_WareHouse_Map_Select(Nullable<int> action, string whereClause, string userID)
        {
            var actionParameter = action.HasValue ?
                new ObjectParameter("Action", action) :
                new ObjectParameter("Action", typeof(int));
    
            var whereClauseParameter = whereClause != null ?
                new ObjectParameter("WhereClause", whereClause) :
                new ObjectParameter("WhereClause", typeof(string));
    
            var userIDParameter = userID != null ?
                new ObjectParameter("UserID", userID) :
                new ObjectParameter("UserID", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spr_src_WareHouse_Map_Select_Result>("spr_src_WareHouse_Map_Select", actionParameter, whereClauseParameter, userIDParameter);
        }
    
        public virtual ObjectResult<spr_src_PartLocation_Rpt_Result> spr_src_PartLocation_Rpt(Nullable<int> collectionID, Nullable<int> subcollectionID, Nullable<int> partID)
        {
            var collectionIDParameter = collectionID.HasValue ?
                new ObjectParameter("CollectionID", collectionID) :
                new ObjectParameter("CollectionID", typeof(int));
    
            var subcollectionIDParameter = subcollectionID.HasValue ?
                new ObjectParameter("SubcollectionID", subcollectionID) :
                new ObjectParameter("SubcollectionID", typeof(int));
    
            var partIDParameter = partID.HasValue ?
                new ObjectParameter("PartID", partID) :
                new ObjectParameter("PartID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spr_src_PartLocation_Rpt_Result>("spr_src_PartLocation_Rpt", collectionIDParameter, subcollectionIDParameter, partIDParameter);
        }
    
        public virtual ObjectResult<spr_src_BuildingsLocation_Rpt_Result> spr_src_BuildingsLocation_Rpt(Nullable<int> collectionID, Nullable<int> subcollectionID, Nullable<int> partID)
        {
            var collectionIDParameter = collectionID.HasValue ?
                new ObjectParameter("CollectionID", collectionID) :
                new ObjectParameter("CollectionID", typeof(int));
    
            var subcollectionIDParameter = subcollectionID.HasValue ?
                new ObjectParameter("SubcollectionID", subcollectionID) :
                new ObjectParameter("SubcollectionID", typeof(int));
    
            var partIDParameter = partID.HasValue ?
                new ObjectParameter("PartID", partID) :
                new ObjectParameter("PartID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spr_src_BuildingsLocation_Rpt_Result>("spr_src_BuildingsLocation_Rpt", collectionIDParameter, subcollectionIDParameter, partIDParameter);
        }
    
        public virtual ObjectResult<spr_src_FieldLocation_Rpt_Result> spr_src_FieldLocation_Rpt(Nullable<int> collectionID, Nullable<int> subcollectionID, Nullable<int> partID)
        {
            var collectionIDParameter = collectionID.HasValue ?
                new ObjectParameter("CollectionID", collectionID) :
                new ObjectParameter("CollectionID", typeof(int));
    
            var subcollectionIDParameter = subcollectionID.HasValue ?
                new ObjectParameter("SubcollectionID", subcollectionID) :
                new ObjectParameter("SubcollectionID", typeof(int));
    
            var partIDParameter = partID.HasValue ?
                new ObjectParameter("PartID", partID) :
                new ObjectParameter("PartID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spr_src_FieldLocation_Rpt_Result>("spr_src_FieldLocation_Rpt", collectionIDParameter, subcollectionIDParameter, partIDParameter);
        }
    
        public virtual ObjectResult<spr_src_LandLocation_Rpt_Result> spr_src_LandLocation_Rpt(Nullable<int> collectionID, Nullable<int> subcollectionID, Nullable<int> partID)
        {
            var collectionIDParameter = collectionID.HasValue ?
                new ObjectParameter("CollectionID", collectionID) :
                new ObjectParameter("CollectionID", typeof(int));
    
            var subcollectionIDParameter = subcollectionID.HasValue ?
                new ObjectParameter("SubcollectionID", subcollectionID) :
                new ObjectParameter("SubcollectionID", typeof(int));
    
            var partIDParameter = partID.HasValue ?
                new ObjectParameter("PartID", partID) :
                new ObjectParameter("PartID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spr_src_LandLocation_Rpt_Result>("spr_src_LandLocation_Rpt", collectionIDParameter, subcollectionIDParameter, partIDParameter);
        }
    
        public virtual ObjectResult<spr_src_WarehouseLocation_Rpt_Result> spr_src_WarehouseLocation_Rpt(Nullable<int> collectionID, Nullable<int> subcollectionID, Nullable<int> partID)
        {
            var collectionIDParameter = collectionID.HasValue ?
                new ObjectParameter("CollectionID", collectionID) :
                new ObjectParameter("CollectionID", typeof(int));
    
            var subcollectionIDParameter = subcollectionID.HasValue ?
                new ObjectParameter("SubcollectionID", subcollectionID) :
                new ObjectParameter("SubcollectionID", typeof(int));
    
            var partIDParameter = partID.HasValue ?
                new ObjectParameter("PartID", partID) :
                new ObjectParameter("PartID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spr_src_WarehouseLocation_Rpt_Result>("spr_src_WarehouseLocation_Rpt", collectionIDParameter, subcollectionIDParameter, partIDParameter);
        }
    
        public virtual ObjectResult<spr_src_WaterLocation_Rpt_Result> spr_src_WaterLocation_Rpt(Nullable<int> collectionID, Nullable<int> subcollectionID, Nullable<int> partID)
        {
            var collectionIDParameter = collectionID.HasValue ?
                new ObjectParameter("CollectionID", collectionID) :
                new ObjectParameter("CollectionID", typeof(int));
    
            var subcollectionIDParameter = subcollectionID.HasValue ?
                new ObjectParameter("SubcollectionID", subcollectionID) :
                new ObjectParameter("SubcollectionID", typeof(int));
    
            var partIDParameter = partID.HasValue ?
                new ObjectParameter("PartID", partID) :
                new ObjectParameter("PartID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spr_src_WaterLocation_Rpt_Result>("spr_src_WaterLocation_Rpt", collectionIDParameter, subcollectionIDParameter, partIDParameter);
        }
    
        public virtual ObjectResult<spr_src_WaterStorageLocation_Rpt_Result> spr_src_WaterStorageLocation_Rpt(Nullable<int> collectionID, Nullable<int> subcollectionID, Nullable<int> partID)
        {
            var collectionIDParameter = collectionID.HasValue ?
                new ObjectParameter("CollectionID", collectionID) :
                new ObjectParameter("CollectionID", typeof(int));
    
            var subcollectionIDParameter = subcollectionID.HasValue ?
                new ObjectParameter("SubcollectionID", subcollectionID) :
                new ObjectParameter("SubcollectionID", typeof(int));
    
            var partIDParameter = partID.HasValue ?
                new ObjectParameter("PartID", partID) :
                new ObjectParameter("PartID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spr_src_WaterStorageLocation_Rpt_Result>("spr_src_WaterStorageLocation_Rpt", collectionIDParameter, subcollectionIDParameter, partIDParameter);
        }
    
        public virtual ObjectResult<spr_src_WaterTransmissionLineLocation_Rpt_Result> spr_src_WaterTransmissionLineLocation_Rpt(Nullable<int> collectionID, Nullable<int> subcollectionID, Nullable<int> partID)
        {
            var collectionIDParameter = collectionID.HasValue ?
                new ObjectParameter("CollectionID", collectionID) :
                new ObjectParameter("CollectionID", typeof(int));
    
            var subcollectionIDParameter = subcollectionID.HasValue ?
                new ObjectParameter("SubcollectionID", subcollectionID) :
                new ObjectParameter("SubcollectionID", typeof(int));
    
            var partIDParameter = partID.HasValue ?
                new ObjectParameter("PartID", partID) :
                new ObjectParameter("PartID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spr_src_WaterTransmissionLineLocation_Rpt_Result>("spr_src_WaterTransmissionLineLocation_Rpt", collectionIDParameter, subcollectionIDParameter, partIDParameter);
        }
    }
}
