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
    
    public partial class LoanTaken
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LoanTaken()
        {
            this.LoanAdjuststments = new HashSet<LoanAdjuststment>();
        }
    
        public string LoanTakenId { get; set; }
        public string LoanTypeId { get; set; }
        public Nullable<int> LoanTakenNum { get; set; }
        public string EmpNo { get; set; }
        public Nullable<System.DateTime> DateLend { get; set; }
        public Nullable<decimal> LoanAmt { get; set; }
        public Nullable<int> NoOfInstallation { get; set; }
        public Nullable<int> NewNoOfInstallation { get; set; }
        public Nullable<decimal> InstallAmt { get; set; }
        public Nullable<decimal> NewInstallAmt { get; set; }
        public string AppAuth { get; set; }
        public string RecomAuth { get; set; }
        public Nullable<int> CompNo { get; set; }
        public Nullable<int> BranchNo { get; set; }
        public Nullable<int> LahTransferId { get; set; }
        public Nullable<System.DateTime> SaveDate { get; set; }
        public Nullable<int> DeletionID { get; set; }
        public int AdjustedBit { get; set; }
        public Nullable<System.DateTime> AdjustedDate { get; set; }
        public Nullable<decimal> PreviousAdv { get; set; }
        public decimal GrossSalary { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LoanAdjuststment> LoanAdjuststments { get; set; }
        public virtual EmployeePersonalInfo EmployeePersonalInfo { get; set; }
    }
}
