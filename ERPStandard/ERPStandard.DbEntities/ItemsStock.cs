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
    
    public partial class ItemsStock
    {
        public string ItemID { get; set; }
        public int ItemNo { get; set; }
        public string Dscr { get; set; }
        public int ItemClass { get; set; }
        public int ItemStore { get; set; }
        public bool SPD { get; set; }
        public decimal SPDRate { get; set; }
        public string Packing { get; set; }
        public decimal Weight { get; set; }
        public string GodownId { get; set; }
        public string BrandId { get; set; }
        public string STaxId { get; set; }
        public string PuchaseAcntId { get; set; }
        public string PuchaseRAcntId { get; set; }
        public string CashSaleGlAcnt { get; set; }
        public string CreditSaleGlAcnt { get; set; }
        public Nullable<int> OpeningRate { get; set; }
        public Nullable<decimal> OpeningQty { get; set; }
        public Nullable<System.DateTime> OpeningDate { get; set; }
        public int CompNo { get; set; }
        public int BranchNo { get; set; }
        public System.DateTime SaveDate { get; set; }
        public int DeletionID { get; set; }
        public int LahTransferId { get; set; }
        public string PartCode { get; set; }
        public string ItemCode { get; set; }
        public int ItemStoreCode { get; set; }
        public decimal StockMinQty { get; set; }
        public decimal StockMaxQty { get; set; }
        public decimal Rate { get; set; }
        public int UOMId { get; set; }
    }
}
