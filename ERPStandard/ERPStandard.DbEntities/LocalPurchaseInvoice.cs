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
    
    public partial class LocalPurchaseInvoice
    {
        public string PInvoiceId { get; set; }
        public string PInvoiceNo { get; set; }
        public Nullable<System.DateTime> PDate { get; set; }
        public string AllSupplierNo { get; set; }
        public string PurchaserId { get; set; }
        public Nullable<decimal> AmtWST { get; set; }
        public Nullable<decimal> TAmount { get; set; }
        public string Remarks { get; set; }
        public int PurchaseType { get; set; }
        public int PaymentTypeid { get; set; }
        public string AdvanceId { get; set; }
        public int CompNo { get; set; }
        public int BranchNo { get; set; }
        public int Paid { get; set; }
        public Nullable<decimal> PAmount { get; set; }
        public Nullable<decimal> BAmount { get; set; }
        public string BillNo { get; set; }
        public Nullable<int> LahTransferId { get; set; }
        public Nullable<System.DateTime> SaveDate { get; set; }
        public Nullable<int> DeletionID { get; set; }
        public string GRNID { get; set; }
    }
}
