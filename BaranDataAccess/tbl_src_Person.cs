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
    
    public partial class tbl_src_Person
    {
        public int PersonID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NikName { get; set; }
        public Nullable<int> Fk_GenderID { get; set; }
        public string NationalCode { get; set; }
        public string PostalCode { get; set; }
        public Nullable<int> Fk_ProvinceID { get; set; }
        public Nullable<int> Fk_TownshipID { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Telephone { get; set; }
        public string Mobile { get; set; }
        public Nullable<int> Fk_PersonCategoryID { get; set; }
        public string Introducing { get; set; }
        public string Description { get; set; }
        public Nullable<int> CreateUserID { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<int> InactivationUserID { get; set; }
        public Nullable<System.DateTime> InactivationDate { get; set; }
        public Nullable<int> UpdateUserID { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
        public Nullable<int> Fk_PartID { get; set; }
    
        public virtual tbl_cmn_Province tbl_cmn_Province { get; set; }
        public virtual tbl_src_PersonCategory tbl_src_PersonCategory { get; set; }
    }
}
