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
    
    public partial class PurchaseRequisitionOrder
    {
        public string RequisitionID { get; set; }
        public string RequisitionOrderNo { get; set; }
        public System.DateTime RequisitionDate { get; set; }
        public string StoreUnitId { get; set; }
        public string Remarks { get; set; }
        public Nullable<int> ExpireDaysStatus { get; set; }
        public string IndentoCode { get; set; }
        public int CompNo { get; set; }
        public int BranchNo { get; set; }
        public Nullable<int> LahTransferId { get; set; }
        public Nullable<System.DateTime> SaveDate { get; set; }
        public Nullable<int> DeletionID { get; set; }
        public string PurchaserID { get; set; }
    }
}
