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
    
    public partial class LcCont
    {
        public decimal LcContId { get; set; }
        public string LcContNo { get; set; }
        public Nullable<int> TypeId { get; set; }
        public Nullable<int> BankNo { get; set; }
        public Nullable<int> LCTypeId { get; set; }
        public Nullable<int> FSupplierId { get; set; }
        public Nullable<System.DateTime> LcExpDate { get; set; }
        public Nullable<decimal> ValueOfLC { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public Nullable<System.DateTime> LastShipDate { get; set; }
        public Nullable<System.DateTime> PayDueDate { get; set; }
        public Nullable<int> CorBankId { get; set; }
        public Nullable<int> InsPolicyId { get; set; }
        public Nullable<int> CurrencyNo { get; set; }
        public Nullable<float> CurRate { get; set; }
        public Nullable<System.DateTime> ExRateDate { get; set; }
        public Nullable<int> CountryId { get; set; }
        public string Remarks { get; set; }
        public int LcContractId { get; set; }
        public Nullable<decimal> TQty { get; set; }
        public Nullable<decimal> MarginPaid { get; set; }
        public Nullable<decimal> MarginBal { get; set; }
        public bool FullShip { get; set; }
        public bool PartShip { get; set; }
        public string AcntID { get; set; }
        public bool LCStatus { get; set; }
        public string PortOfLoading { get; set; }
        public string PortOfDischarge { get; set; }
        public Nullable<System.DateTime> LcExpireDate { get; set; }
        public string VoucherNo { get; set; }
        public string VoucherTypeID { get; set; }
        public string PostedBy { get; set; }
        public string MarginAcc { get; set; }
        public Nullable<decimal> LCOpenCharges { get; set; }
        public Nullable<int> Booked { get; set; }
        public Nullable<int> CorrBankNo { get; set; }
        public int CompNo { get; set; }
        public int BranchNo { get; set; }
        public Nullable<int> LahTransferId { get; set; }
        public Nullable<System.DateTime> SaveDate { get; set; }
        public Nullable<int> DeletionID { get; set; }
    }
}
