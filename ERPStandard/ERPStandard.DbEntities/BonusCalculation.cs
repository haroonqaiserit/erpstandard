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
    
    public partial class BonusCalculation
    {
        public decimal Id { get; set; }
        public string BonusID { get; set; }
        public string EmpNo { get; set; }
        public Nullable<decimal> BasicPay { get; set; }
        public Nullable<decimal> BonusSalary { get; set; }
        public Nullable<decimal> AdvAgainstBonus { get; set; }
        public int CompNo { get; set; }
        public int BranchNo { get; set; }
        public int LahTransferId { get; set; }
        public System.DateTime SaveDate { get; set; }
        public int DeletionID { get; set; }
    
        public virtual EmployeePersonalInfo EmployeePersonalInfo { get; set; }
    }
}
