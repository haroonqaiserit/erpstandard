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
    
    public partial class LeaveApplication
    {
        public int AppId { get; set; }
        public string EmpId { get; set; }
        public Nullable<int> LeavTypeId { get; set; }
        public Nullable<System.DateTime> FDate { get; set; }
        public Nullable<System.DateTime> TDate { get; set; }
        public Nullable<int> TotalDays { get; set; }
        public Nullable<System.DateTime> AppliedDate { get; set; }
        public string Reason { get; set; }
        public string AppAuth { get; set; }
        public Nullable<System.DateTime> AFDate { get; set; }
        public Nullable<System.DateTime> ATDate { get; set; }
        public Nullable<int> ADays { get; set; }
        public string AppRemarks { get; set; }
        public Nullable<System.DateTime> AppDate { get; set; }
        public bool AppStatus { get; set; }
        public string RecomAuth { get; set; }
        public Nullable<int> DeptId { get; set; }
        public Nullable<int> DesigId { get; set; }
        public bool AppDelStatus { get; set; }
        public Nullable<System.DateTime> AppDelDate { get; set; }
        public Nullable<int> cid { get; set; }
        public Nullable<int> LahTransferId { get; set; }
        public Nullable<System.DateTime> SaveDate { get; set; }
        public Nullable<int> DeletionID { get; set; }
    }
}
