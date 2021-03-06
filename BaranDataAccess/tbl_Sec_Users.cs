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
    
    public partial class tbl_Sec_Users
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public Nullable<bool> IsActiveUser { get; set; }
        public System.DateTime UpdateDate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mobile { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public int FK_ShopID { get; set; }
        public string UserAddress { get; set; }
        public string Description { get; set; }
        public Nullable<bool> IsManager { get; set; }
        public Nullable<bool> IsAccountant { get; set; }
        public Nullable<bool> IsSalesPerson { get; set; }
        public Nullable<bool> IsOtherStaff { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<long> CreateUserID { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<long> InactivationUserID { get; set; }
        public Nullable<System.DateTime> InactivationDate { get; set; }
        public byte[] UserImage { get; set; }
        public Nullable<int> Fk_UserTypeID { get; set; }
        public Nullable<int> Fk_CompanyID { get; set; }
        public Nullable<int> Fk_CollectionID { get; set; }
        public Nullable<int> Fk_SubcollectionID { get; set; }
        public Nullable<int> Fk_PartID { get; set; }
    
        public virtual tbl_Sec_Shops tbl_Sec_Shops { get; set; }
    }
}
