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
    
    public partial class RMItemTransferToUnit
    {
        public string TransferId { get; set; }
        public System.DateTime TransferDate { get; set; }
        public decimal TransferCode { get; set; }
        public string ItemId { get; set; }
        public decimal FromQty { get; set; }
        public decimal ToQty { get; set; }
        public string FromStoreUnitId { get; set; }
        public string ToStoreUnitId { get; set; }
        public string ReasonOfTransfer { get; set; }
        public int CompNo { get; set; }
        public int BranchNo { get; set; }
        public decimal TransferQty { get; set; }
        public decimal NewQty { get; set; }
        public Nullable<int> LahTransferId { get; set; }
        public Nullable<System.DateTime> SaveDate { get; set; }
        public Nullable<int> DeletionID { get; set; }
    }
}