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
    
    public partial class spr_src_TreeLocation_Rpt_Result
    {
        public string PartName { get; set; }
        public string SubcollectionName { get; set; }
        public string CollectionName { get; set; }
        public int PartID { get; set; }
        public int SubCollectionID { get; set; }
        public int CollectionID { get; set; }
        public string FieldName { get; set; }
        public string BaseCultivar { get; set; }
        public string BaseType { get; set; }
        public Nullable<System.DateTime> DatePlanting { get; set; }
        public string SubInformation { get; set; }
        public Nullable<short> Row { get; set; }
        public Nullable<short> Column { get; set; }
        public System.Data.Spatial.DbGeometry Location { get; set; }
    }
}