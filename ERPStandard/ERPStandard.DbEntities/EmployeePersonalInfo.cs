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
    
    public partial class EmployeePersonalInfo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EmployeePersonalInfo()
        {
            this.AdvanceAgainstBonus = new HashSet<AdvanceAgainstBonu>();
            this.AdvanceAgainstSalaries = new HashSet<AdvanceAgainstSalary>();
            this.BonusCalculations = new HashSet<BonusCalculation>();
            this.IncomeTaxSetups = new HashSet<IncomeTaxSetup>();
            this.LoanAdjuststments = new HashSet<LoanAdjuststment>();
            this.LoanTakens = new HashSet<LoanTaken>();
            this.SalaryMasters = new HashSet<SalaryMaster>();
        }
    
        public string EmpNo { get; set; }
        public string TitleID { get; set; }
        public string Name { get; set; }
        public string FathName { get; set; }
        public string Domicile { get; set; }
        public string Religion { get; set; }
        public string Nationality { get; set; }
        public string NICNo { get; set; }
        public string BloodGrp { get; set; }
        public Nullable<System.DateTime> BrthDate { get; set; }
        public string EmerCont { get; set; }
        public string MaritStat { get; set; }
        public string EmerPhon { get; set; }
        public Nullable<int> ChildNo { get; set; }
        public string LatQual { get; set; }
        public string HelthIssu { get; set; }
        public string Sex { get; set; }
        public string SpouseName { get; set; }
        public string Pic { get; set; }
        public Nullable<System.DateTime> SpouseDob { get; set; }
        public Nullable<int> LahTransferId { get; set; }
        public Nullable<int> CompNo { get; set; }
        public Nullable<int> BranchNo { get; set; }
        public Nullable<int> EmpNum { get; set; }
        public Nullable<System.DateTime> SaveDate { get; set; }
        public Nullable<int> DeletionID { get; set; }
        public string EmpType { get; set; }
        public string DEPT { get; set; }
        public string DESIG { get; set; }
        public string Address { get; set; }
        public string Address1 { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string HF { get; set; }
        public Nullable<System.DateTime> HireDate { get; set; }
        public byte[] EmpPic { get; set; }
        public string emal { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AdvanceAgainstBonu> AdvanceAgainstBonus { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AdvanceAgainstSalary> AdvanceAgainstSalaries { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BonusCalculation> BonusCalculations { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IncomeTaxSetup> IncomeTaxSetups { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LoanAdjuststment> LoanAdjuststments { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LoanTaken> LoanTakens { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SalaryMaster> SalaryMasters { get; set; }
    }
}
