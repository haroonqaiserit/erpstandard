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
    
    public partial class OverTime
    {
        public int OTId { get; set; }
        public string EmpId { get; set; }
        public Nullable<int> DeptId { get; set; }
        public Nullable<int> DesigId { get; set; }
        public Nullable<int> Hours { get; set; }
        public Nullable<int> Minutes { get; set; }
        public Nullable<int> Rate { get; set; }
        public Nullable<decimal> Amt { get; set; }
        public Nullable<System.DateTime> OverTimeDt { get; set; }
        public Nullable<System.DateTime> DelDate { get; set; }
        public bool Status { get; set; }
        public Nullable<int> LahTransferId { get; set; }
        public Nullable<System.DateTime> SaveDate { get; set; }
        public Nullable<int> DeletionID { get; set; }
    }
}
