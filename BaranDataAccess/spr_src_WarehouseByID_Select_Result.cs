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
    
    public partial class spr_src_WarehouseByID_Select_Result
    {
        public int WarehouseID { get; set; }
        public string Name { get; set; }
        public Nullable<decimal> Area { get; set; }
        public string WarehouseKeeper { get; set; }
        public string Address { get; set; }
        public Nullable<int> FK_WarehouseType { get; set; }
        public Nullable<int> CreateUserID { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<int> InactivationUserID { get; set; }
        public Nullable<System.DateTime> InactivationDate { get; set; }
        public Nullable<int> UpdateUserID { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
        public string Description { get; set; }
        public Nullable<int> Fk_PartID { get; set; }
        public Nullable<int> Fk_WarehouseUseTypeID { get; set; }
        public Nullable<decimal> Volume { get; set; }
    }
}