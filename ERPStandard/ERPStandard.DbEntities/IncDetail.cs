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
    
    public partial class IncDetail
    {
        public string IncId { get; set; }
        public string EmpId { get; set; }
        public string DesigId { get; set; }
        public string DeptId { get; set; }
        public string AppAuth { get; set; }
        public Nullable<System.DateTime> IncDate { get; set; }
        public Nullable<decimal> IncAmt { get; set; }
        public Nullable<System.DateTime> EffctDate { get; set; }
        public string IncTypeId { get; set; }
        public string RecomAuth { get; set; }
        public Nullable<decimal> NewSal { get; set; }
        public Nullable<decimal> CurrSal { get; set; }
        public Nullable<int> IncPer { get; set; }
        public Nullable<int> cid { get; set; }
        public Nullable<int> LahTransferId { get; set; }
        public Nullable<System.DateTime> SaveDate { get; set; }
        public Nullable<int> DeletionID { get; set; }
    }
}