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
    
    public partial class SalCalc
    {
        public decimal SalId { get; set; }
        public Nullable<decimal> HR { get; set; }
        public Nullable<decimal> Util { get; set; }
        public Nullable<decimal> AnUtil { get; set; }
        public Nullable<decimal> AnHR { get; set; }
        public Nullable<decimal> BS { get; set; }
        public Nullable<decimal> GS { get; set; }
        public Nullable<decimal> AnBs { get; set; }
        public Nullable<decimal> AnGs { get; set; }
        public Nullable<decimal> SlabRate { get; set; }
        public Nullable<decimal> NetAmtTaxDed { get; set; }
        public Nullable<decimal> TotalInc { get; set; }
        public Nullable<decimal> TotalSalAll { get; set; }
        public Nullable<decimal> TaxDeduct { get; set; }
        public Nullable<decimal> RedInTax { get; set; }
        public Nullable<decimal> TaxForMonth { get; set; }
        public Nullable<decimal> BankPayment { get; set; }
        public string EmpId { get; set; }
        public Nullable<int> DeptId { get; set; }
        public Nullable<int> CompId { get; set; }
        public Nullable<int> DesigId { get; set; }
        public Nullable<System.DateTime> SalDate { get; set; }
        public string Remarks { get; set; }
        public Nullable<decimal> LoanIns { get; set; }
        public Nullable<decimal> Adv { get; set; }
        public Nullable<decimal> fine { get; set; }
        public Nullable<System.DateTime> AdvDt { get; set; }
        public Nullable<decimal> upto { get; set; }
        public Nullable<System.DateTime> FromDate { get; set; }
        public Nullable<System.DateTime> ToDate { get; set; }
        public Nullable<decimal> Arrears { get; set; }
        public Nullable<decimal> abfine { get; set; }
        public Nullable<decimal> others { get; set; }
        public string EmpType { get; set; }
        public Nullable<int> DaysWorked { get; set; }
        public Nullable<int> LahTransferId { get; set; }
        public Nullable<System.DateTime> SaveDate { get; set; }
        public Nullable<int> DeletionID { get; set; }
    }
}