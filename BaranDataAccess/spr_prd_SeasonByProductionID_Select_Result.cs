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
    
    public partial class spr_prd_SeasonByProductionID_Select_Result
    {
        public int SeasonID { get; set; }
        public string SeasonName { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public Nullable<int> Fk_ProductionID { get; set; }
        public Nullable<int> Fk_TasklistCropID { get; set; }
        public Nullable<int> FK_Status { get; set; }
        public Nullable<int> CreateUserID { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<int> InactivationUserID { get; set; }
        public Nullable<System.DateTime> InactivationDate { get; set; }
        public Nullable<int> UpdateUserID { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
    }
}
