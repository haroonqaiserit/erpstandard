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
    
    public partial class SaleInvoiceWeb
    {
        public int Id { get; set; }
        public string SaleInvId { get; set; }
        public string InvRef { get; set; }
        public System.DateTime SaleDate { get; set; }
        public string CustOrderNo { get; set; }
        public string CustomerCode { get; set; }
        public string ProductCode { get; set; }
        public string ProductBarCode { get; set; }
        public decimal Qty { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal DeliveryCharges { get; set; }
        public decimal TaxRate { get; set; }
        public decimal TaxAmount { get; set; }
        public System.DateTime SaveDate { get; set; }
        public int CompNo { get; set; }
        public int BranchNo { get; set; }
    }
}
