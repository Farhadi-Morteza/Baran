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
    
    public partial class spr_AccessibleItemsForCurrentUser_Select_Result
    {
        public int ItemUserID { get; set; }
        public long FK_UserID { get; set; }
        public int FK_ItemID { get; set; }
        public bool HasWrite { get; set; }
        public Nullable<bool> bitSave { get; set; }
        public Nullable<bool> bitChange { get; set; }
        public Nullable<bool> bitDelete { get; set; }
        public Nullable<bool> bitNew { get; set; }
        public Nullable<bool> bitPrint { get; set; }
        public string RelatedFormName { get; set; }
        public int FK_PackageID { get; set; }
        public int OrderInLevel { get; set; }
        public byte[] ItemLogo { get; set; }
        public string ItemName { get; set; }
        public int ItemID { get; set; }
        public Nullable<bool> EnableOnExplorerBar { get; set; }
        public int PackageID { get; set; }
        public string PackageName { get; set; }
        public byte[] PackageLogo { get; set; }
        public int PackageOrder { get; set; }
        public Nullable<int> PackageFormsHeaderColor1 { get; set; }
        public Nullable<int> PackageFormsHeaderColor2 { get; set; }
    }
}