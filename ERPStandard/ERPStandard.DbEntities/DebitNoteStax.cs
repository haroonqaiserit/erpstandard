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
    
    public partial class DebitNoteStax
    {
        public string DebitNoteSTaxID { get; set; }
        public string DebitNoteSTaxNo { get; set; }
        public Nullable<System.DateTime> DNSTDate { get; set; }
        public string CustomerNo { get; set; }
        public Nullable<int> EmployeeNo { get; set; }
        public string Remarks { get; set; }
        public string SaleInvId { get; set; }
        public int CompNo { get; set; }
        public int BranchNo { get; set; }
        public Nullable<decimal> TotAWST { get; set; }
        public Nullable<decimal> AmountBalance { get; set; }
        public string SalesManId { get; set; }
        public Nullable<int> LahTransferId { get; set; }
        public Nullable<System.DateTime> SaveDate { get; set; }
        public Nullable<int> DeletionID { get; set; }
    }
}