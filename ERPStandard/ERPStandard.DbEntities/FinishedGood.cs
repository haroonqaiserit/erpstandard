//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ERPStandard.DbEntities
{
    using System;
    using System.Collections.Generic;
    
    public partial class FinishedGood
    {
        public string ItemId { get; set; }
        public string FGId { get; set; }
        public string BrandId { get; set; }
        public string TypeId { get; set; }
        public int CompNo { get; set; }
        public int BranchNo { get; set; }
        public string GodownId { get; set; }
        public Nullable<int> LahTransferId { get; set; }
        public Nullable<System.DateTime> SaveDate { get; set; }
        public Nullable<int> DeletionID { get; set; }
    }
}
