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
    
    public partial class PurchaseRequisitionOrderDetail
    {
        public string RequisitionID { get; set; }
        public int LineNo { get; set; }
        public string StoreUnitId { get; set; }
        public System.DateTime RequisitionDate { get; set; }
        public string ItemId { get; set; }
        public Nullable<decimal> StockQty { get; set; }
        public string ItemMeasureUnit { get; set; }
        public string ItemSpecification { get; set; }
        public Nullable<decimal> RequiredQty { get; set; }
        public Nullable<System.DateTime> RequiredDate { get; set; }
        public Nullable<decimal> BalanceQty { get; set; }
        public Nullable<int> ItemClearedStatus { get; set; }
        public Nullable<int> LahTransferId { get; set; }
        public Nullable<System.DateTime> SaveDate { get; set; }
        public Nullable<int> DeletionID { get; set; }
        public string GrnID { get; set; }
        public Nullable<decimal> GrnBalanceQty { get; set; }
        public string GrnItemClearedStatus { get; set; }
        public Nullable<System.DateTime> GrnDate { get; set; }
        public Nullable<decimal> LstPurQty { get; set; }
        public Nullable<decimal> GrnRate { get; set; }
        public string CostCenterId { get; set; }
        public int CompNo { get; set; }
        public int BranchNo { get; set; }
        public string DemandPerson { get; set; }
        public Nullable<bool> ApprovedStatus { get; set; }
        public Nullable<decimal> EstRate { get; set; }
    }
}
