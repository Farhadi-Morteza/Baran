//------------------------------------------------------------------------------
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
    
    public partial class spr_src_Fertilizer_Select_Result
    {
        public int FertilizerID { get; set; }
        public string Name { get; set; }
        public string Manufacture { get; set; }
        public string RegistrationNumber { get; set; }
        public string FertilizerCategory { get; set; }
        public string MaterialMode { get; set; }
        public string ProductionCategory { get; set; }
        public Nullable<int> Fk_FertilizerCategoryID { get; set; }
        public Nullable<int> Fk_MaterialModeID { get; set; }
        public Nullable<int> Fk_ProductCategoryID { get; set; }
        public Nullable<int> Fk_UnitMeasurementID { get; set; }
        public string Description { get; set; }
        public Nullable<int> CreateUserID { get; set; }
        public Nullable<int> InactivationUserID { get; set; }
        public Nullable<int> UpdateUserID { get; set; }
    }
}