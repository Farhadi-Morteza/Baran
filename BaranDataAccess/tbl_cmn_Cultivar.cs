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
    
    public partial class tbl_cmn_Cultivar
    {
        public int CultivarID { get; set; }
        public string NameFa { get; set; }
        public string NameEn { get; set; }
        public int Fk_CountryID { get; set; }
        public string Property { get; set; }
        public string CultivatedClimate { get; set; }
        public Nullable<decimal> YieldPerHectare { get; set; }
        public Nullable<int> CreateUserID { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<int> InactivationUserID { get; set; }
        public Nullable<System.DateTime> InactivationDate { get; set; }
        public Nullable<int> UpdateUserID { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
        public string Description { get; set; }
        public Nullable<int> Fk_CropID { get; set; }
    }
}
