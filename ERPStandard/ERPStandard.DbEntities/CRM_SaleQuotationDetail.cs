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
    
    public partial class CRM_SaleQuotationDetail
    {
        public decimal Id { get; set; }
        public string QuoteId { get; set; }
        public string ItemID { get; set; }
        public decimal Qty { get; set; }
        public decimal Rate { get; set; }
        public decimal SaleTaxRate { get; set; }
        public decimal ASaleTaxRate { get; set; }
        public decimal SExDutyRate { get; set; }
        public int CompNo { get; set; }
        public int BranchNo { get; set; }
        public int LahTransferId { get; set; }
        public System.DateTime SaveDate { get; set; }
        public int DeletionID { get; set; }
    }
}
