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
    
    public partial class Carleasedetail
    {
        public int LeId { get; set; }
        public string EmpId { get; set; }
        public Nullable<int> DeptId { get; set; }
        public Nullable<int> DesigId { get; set; }
        public Nullable<decimal> Amt { get; set; }
        public int InstallNo { get; set; }
        public Nullable<System.DateTime> InstallDate { get; set; }
        public bool MonthStat { get; set; }
        public Nullable<System.DateTime> Deldate { get; set; }
        public bool DelStatus { get; set; }
        public string Remarks { get; set; }
        public Nullable<int> TotInstall { get; set; }
        public string LeNo { get; set; }
        public Nullable<int> CompId { get; set; }
        public decimal LeAmt { get; set; }
        public decimal AmtPaid { get; set; }
        public Nullable<int> LahTransferId { get; set; }
        public Nullable<System.DateTime> SaveDate { get; set; }
        public Nullable<int> DeletionID { get; set; }
    }
}