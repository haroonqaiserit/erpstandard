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
    
    public partial class Carlease
    {
        public int CLeId { get; set; }
        public string EmpId { get; set; }
        public Nullable<int> DesigId { get; set; }
        public Nullable<int> DeptId { get; set; }
        public string LeNo { get; set; }
        public string LeComp { get; set; }
        public Nullable<decimal> LeAmt { get; set; }
        public Nullable<decimal> Intrest { get; set; }
        public Nullable<int> Installments { get; set; }
        public string VehNo { get; set; }
        public Nullable<System.DateTime> StDate { get; set; }
        public Nullable<System.DateTime> EdDate { get; set; }
        public string Duration { get; set; }
        public Nullable<decimal> LeInstall { get; set; }
        public Nullable<decimal> DownPay { get; set; }
        public Nullable<System.DateTime> DelDate { get; set; }
        public bool DelStatus { get; set; }
        public Nullable<decimal> LePayment { get; set; }
        public Nullable<int> CompId { get; set; }
        public Nullable<int> LahTransferId { get; set; }
        public Nullable<int> CompNo { get; set; }
        public Nullable<int> BranchNo { get; set; }
        public Nullable<System.DateTime> SaveDate { get; set; }
        public Nullable<int> DeletionID { get; set; }
    }
}
