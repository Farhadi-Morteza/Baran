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
    
    public partial class spr_src_Buildings_Select_Result
    {
        public int BuildingsID { get; set; }
        public string Name { get; set; }
        public Nullable<decimal> Area { get; set; }
        public Nullable<int> Fk_BuildingsCategoryID { get; set; }
        public Nullable<int> Fk_SubCollectionID { get; set; }
        public Nullable<int> CreateUserID { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<int> InactivationUserID { get; set; }
        public Nullable<System.DateTime> InactivationDate { get; set; }
        public Nullable<int> UpdateUserID { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
        public string Description { get; set; }
        public string BuildingsCategroyName { get; set; }
        public string CollectionName { get; set; }
        public string SubCollectionName { get; set; }
    }
}
