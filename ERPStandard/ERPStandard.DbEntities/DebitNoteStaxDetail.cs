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
    
    public partial class DebitNoteStaxDetail
    {
        public string DebitNoteSTaxID { get; set; }
        public int LineNo { get; set; }
        public string ItemId { get; set; }
        public Nullable<int> RQty { get; set; }
        public Nullable<decimal> RRate { get; set; }
        public Nullable<decimal> AmtWost { get; set; }
        public Nullable<decimal> AmtStax { get; set; }
        public Nullable<decimal> AmtWst { get; set; }
        public string StaxId { get; set; }
        public Nullable<decimal> AmtAStax { get; set; }
        public Nullable<decimal> SaleTaxRate { get; set; }
        public Nullable<decimal> ASaleTaxRate { get; set; }
        public Nullable<int> LahTransferId { get; set; }
        public Nullable<System.DateTime> SaveDate { get; set; }
        public Nullable<decimal> NewAmtWost { get; set; }
        public Nullable<decimal> NewAmtWst { get; set; }
        public Nullable<decimal> NewAmtAStax { get; set; }
        public Nullable<decimal> NewSaleTax { get; set; }
        public Nullable<int> DeletionID { get; set; }
    }
}
