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
    
    public partial class TempAtt
    {
        public Nullable<decimal> AttendenceId { get; set; }
        public string EmpId { get; set; }
        public Nullable<System.DateTime> SignIn { get; set; }
        public Nullable<System.DateTime> SignOut { get; set; }
        public Nullable<System.DateTime> AttendDate { get; set; }
        public string Reason { get; set; }
        public Nullable<decimal> TotalHrs { get; set; }
        public string DesignationId { get; set; }
        public string DeptId { get; set; }
        public bool Attendelestatus { get; set; }
        public Nullable<System.DateTime> Attendeledate { get; set; }
        public Nullable<int> halfday { get; set; }
        public Nullable<int> sNO { get; set; }
        public bool AttendStatus { get; set; }
        public string status { get; set; }
        public string leavesstatus { get; set; }
        public Nullable<int> cid { get; set; }
        public string EmpType { get; set; }
        public Nullable<int> LahTransferId { get; set; }
        public Nullable<System.DateTime> SaveDate { get; set; }
        public Nullable<int> DeletionID { get; set; }
    }
}