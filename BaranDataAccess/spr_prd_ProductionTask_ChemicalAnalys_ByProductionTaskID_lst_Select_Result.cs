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
    
    public partial class spr_prd_ProductionTask_ChemicalAnalys_ByProductionTaskID_lst_Select_Result
    {
        public string ChemicalAnalysName { get; set; }
        public string ChemicalAnalysDate { get; set; }
        public string CategoryName { get; set; }
        public string SourceName { get; set; }
        public string AnalysNumber { get; set; }
        public string LabratoryName { get; set; }
        public int ProductionTaskChemicalAnalysID { get; set; }
        public Nullable<int> Fk_ProductionTaskID { get; set; }
        public Nullable<int> Fk_ChemicalAnalysID { get; set; }
    }
}