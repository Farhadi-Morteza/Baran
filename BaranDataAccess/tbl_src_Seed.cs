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
    using System.Collections.Generic;
    
    public partial class tbl_src_Seed
    {
        public int SeedID { get; set; }
        public string SeedNameFa { get; set; }
        public string SeedNameEn { get; set; }
        public string CaloriesPergr { get; set; }
        public Nullable<int> Fk_SeedTypeID { get; set; }
        public Nullable<int> Fk_UnitMeasurementID { get; set; }
        public Nullable<bool> IsActive { get; set; }
    }
}