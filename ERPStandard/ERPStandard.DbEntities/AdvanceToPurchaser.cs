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
    
    public partial class AdvanceToPurchaser
    {
        public string PurAdvanceID { get; set; }
        public string PurAdvanceNo { get; set; }
        public string Remarks { get; set; }
        public Nullable<System.DateTime> PurAdvanceDate { get; set; }
        public string PrId { get; set; }
        public Nullable<int> CompNo { get; set; }
        public Nullable<int> BranchNo { get; set; }
        public string PurchaserID { get; set; }
        public Nullable<int> PayTypeId { get; set; }
        public string BankNo { get; set; }
        public string VoucherNo { get; set; }
        public string Cheque { get; set; }
        public Nullable<int> LahTransferId { get; set; }
        public Nullable<System.DateTime> SaveDate { get; set; }
        public Nullable<int> DeletionID { get; set; }
    }
}