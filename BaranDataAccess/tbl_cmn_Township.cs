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
    
    public partial class tbl_cmn_Township
    {
        public int TownshipID { get; set; }
        public string TownshipName { get; set; }
        public Nullable<int> Fk_ProvinceID { get; set; }
    }
}