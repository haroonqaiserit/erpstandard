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
    
    public partial class PaymentDetail
    {
        public string PayId { get; set; }
        public int lineno { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public string ItemId { get; set; }
        public Nullable<int> HoldingTaxStatus { get; set; }
        public string HTaxAccnt { get; set; }
        public Nullable<decimal> HtaxRate { get; set; }
        public Nullable<decimal> HTaxAmt { get; set; }
        public Nullable<decimal> HTaxNetAmnt { get; set; }
        public Nullable<int> LahTransferId { get; set; }
        public Nullable<System.DateTime> SaveDate { get; set; }
        public Nullable<int> DeletionID { get; set; }
    }
}
