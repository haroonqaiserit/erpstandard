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
    
    public partial class Attendence
    {
        public string AttendenceId { get; set; }
        public string EmpId { get; set; }
        public Nullable<System.DateTime> SignIn { get; set; }
        public Nullable<System.DateTime> SignOut { get; set; }
        public Nullable<System.DateTime> AttendDate { get; set; }
        public string Reason { get; set; }
        public Nullable<decimal> TotalHrs { get; set; }
        public Nullable<int> DesignationId { get; set; }
        public Nullable<int> DeptId { get; set; }
        public bool Attendelestatus { get; set; }
        public Nullable<System.DateTime> Attendeledate { get; set; }
        public int halfday { get; set; }
        public int sNO { get; set; }
        public bool AttendStatus { get; set; }
        public string status { get; set; }
        public string leavestatus { get; set; }
        public Nullable<int> cid { get; set; }
        public string EmpType { get; set; }
        public int CompNo { get; set; }
        public int BranchNo { get; set; }
        public Nullable<int> LahTransferId { get; set; }
        public Nullable<int> DeletionID { get; set; }
    }
}
