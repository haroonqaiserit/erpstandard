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
    
    public partial class EmpSalary
    {
        public string EmpNo { get; set; }
        public Nullable<decimal> BasicSalary { get; set; }
        public Nullable<decimal> HouseRent { get; set; }
        public Nullable<decimal> Utilites { get; set; }
        public Nullable<decimal> Coneyance { get; set; }
        public Nullable<decimal> Other { get; set; }
        public Nullable<int> CompNo { get; set; }
        public Nullable<int> BranchNo { get; set; }
        public Nullable<System.DateTime> SaveDate { get; set; }
        public Nullable<int> DeletionID { get; set; }
    }
}
