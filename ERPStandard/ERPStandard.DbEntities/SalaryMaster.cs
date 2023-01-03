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
    
    public partial class SalaryMaster
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SalaryMaster()
        {
            this.SalaryDetails = new HashSet<SalaryDetail>();
        }
    
        public string SalaryId { get; set; }
        public Nullable<int> SalaryNum { get; set; }
        public string Remarks { get; set; }
        public string EmpNo { get; set; }
        public Nullable<int> CompNo { get; set; }
        public Nullable<int> BranchNo { get; set; }
        public Nullable<int> LahTransferId { get; set; }
        public Nullable<System.DateTime> SaveDate { get; set; }
        public Nullable<int> DeletionID { get; set; }
    
        public virtual EmployeePersonalInfo EmployeePersonalInfo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SalaryDetail> SalaryDetails { get; set; }
    }
}
