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
    
    public partial class ItemRawMaterialRegister
    {
        public int id { get; set; }
        public string ItemId { get; set; }
        public string ItemName { get; set; }
        public string DocumentNo { get; set; }
        public System.DateTime DocDate { get; set; }
        public string Packing { get; set; }
        public decimal Quantity { get; set; }
        public int CompNo { get; set; }
        public int BranchNo { get; set; }
        public Nullable<int> ItemClass { get; set; }
        public decimal OBQuantity { get; set; }
        public decimal GRNQty { get; set; }
        public decimal IssQty { get; set; }
        public Nullable<decimal> OldOpeningBalance { get; set; }
        public System.DateTime fdate { get; set; }
        public System.DateTime tdate { get; set; }
        public string CostCenterId { get; set; }
        public string CostCenterName { get; set; }
        public string StoreUnitId { get; set; }
        public string UnitName { get; set; }
        public Nullable<decimal> Rate { get; set; }
        public Nullable<decimal> Amount { get; set; }
    }
}
