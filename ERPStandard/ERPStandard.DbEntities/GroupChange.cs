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
    
    public partial class GroupChange
    {
        public string GCId { get; set; }
        public Nullable<int> GCNum { get; set; }
        public string EmpId { get; set; }
        public string DeptId { get; set; }
        public string DesigId { get; set; }
        public Nullable<System.DateTime> ChangeDt { get; set; }
        public Nullable<int> OldGid { get; set; }
        public Nullable<int> NewGid { get; set; }
        public int CompNo { get; set; }
        public int BranchNo { get; set; }
        public Nullable<int> LahTransferId { get; set; }
        public Nullable<System.DateTime> SaveDate { get; set; }
        public Nullable<int> DeletionID { get; set; }
    }
}
