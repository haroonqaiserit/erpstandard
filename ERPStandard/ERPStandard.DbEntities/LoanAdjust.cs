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
    
    public partial class LoanAdjust
    {
        public Nullable<double> LoanAdjId { get; set; }
        public string EmpId { get; set; }
        public Nullable<double> DesigId { get; set; }
        public Nullable<double> DeptId { get; set; }
        public Nullable<double> LoanTypeId { get; set; }
        public string AppAuth { get; set; }
        public Nullable<decimal> LoanAmt { get; set; }
        public Nullable<decimal> AdjAmt { get; set; }
        public Nullable<System.DateTime> AdjDate { get; set; }
        public Nullable<decimal> InstallAmt { get; set; }
        public Nullable<double> InstallNo { get; set; }
        public Nullable<System.DateTime> DelDate { get; set; }
        public bool DelStatus { get; set; }
        public Nullable<double> RemainInstall { get; set; }
        public Nullable<decimal> LoanRece { get; set; }
        public bool isadjust { get; set; }
        public Nullable<System.DateTime> instdate { get; set; }
        public bool stat { get; set; }
        public Nullable<double> cid { get; set; }
        public Nullable<double> LoantakenId { get; set; }
        public Nullable<double> LahTransferId { get; set; }
        public Nullable<System.DateTime> SaveDate { get; set; }
        public Nullable<double> DeletionID { get; set; }
    }
}
