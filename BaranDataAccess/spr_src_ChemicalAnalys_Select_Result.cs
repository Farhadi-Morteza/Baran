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
    
    public partial class spr_src_ChemicalAnalys_Select_Result
    {
        public int ChemicalAnalysID { get; set; }
        public string Name { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public string AnalysNumber { get; set; }
        public string SamplingDepth { get; set; }
        public string LabratoryName { get; set; }
        public string LabratoryCode { get; set; }
        public string LabratoryPhone { get; set; }
        public string LabratoryAddress { get; set; }
        public string Description { get; set; }
        public Nullable<int> Fk_ChemicalAnalysisCategoryID { get; set; }
        public Nullable<int> Fk_FieldID { get; set; }
        public Nullable<int> Fk_WaterID { get; set; }
        public Nullable<int> Fk_FertilizerID { get; set; }
        public Nullable<int> CreateUserID { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<int> InactivationUserID { get; set; }
        public Nullable<System.DateTime> InactivationDate { get; set; }
        public Nullable<int> UpdateUserID { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
    }
}
