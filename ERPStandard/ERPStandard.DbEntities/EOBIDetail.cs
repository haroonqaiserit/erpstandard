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
    
    public partial class EOBIDetail
    {
        public string EOBIId { get; set; }
        public decimal EOBIAmount { get; set; }
        public decimal EOBIAge { get; set; }
        public System.DateTime DateAppFrom { get; set; }
        public System.DateTime DateAppTo { get; set; }
        public int CompNo { get; set; }
        public int BranchNo { get; set; }
        public Nullable<int> LahTransferId { get; set; }
        public Nullable<System.DateTime> SaveDate { get; set; }
        public Nullable<int> DeletionID { get; set; }
    
        public virtual EOBISetup EOBISetup { get; set; }
    }
}
