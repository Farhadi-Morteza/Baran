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
    
    public partial class tbl_cmn_Province
    {
        public tbl_cmn_Province()
        {
            this.tbl_src_Collection = new HashSet<tbl_src_Collection>();
            this.tbl_src_Company = new HashSet<tbl_src_Company>();
            this.tbl_src_Person = new HashSet<tbl_src_Person>();
            this.tbl_src_Subcollection = new HashSet<tbl_src_Subcollection>();
            this.tbl_src_Part = new HashSet<tbl_src_Part>();
        }
    
        public int ProvinceID { get; set; }
        public string ProvinceName { get; set; }
    
        public virtual ICollection<tbl_src_Collection> tbl_src_Collection { get; set; }
        public virtual ICollection<tbl_src_Company> tbl_src_Company { get; set; }
        public virtual ICollection<tbl_src_Person> tbl_src_Person { get; set; }
        public virtual ICollection<tbl_src_Subcollection> tbl_src_Subcollection { get; set; }
        public virtual ICollection<tbl_src_Part> tbl_src_Part { get; set; }
    }
}
