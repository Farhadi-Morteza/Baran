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
    
    public partial class tbl_tsk_Tasklist_Task_Link
    {
        public int TasklistTaskID { get; set; }
        public int Fk_TasklistID { get; set; }
        public int Fk_TaskID { get; set; }
        public Nullable<short> DaysAfterStartDeason { get; set; }
        public Nullable<short> TaskPeriod { get; set; }
    }
}
