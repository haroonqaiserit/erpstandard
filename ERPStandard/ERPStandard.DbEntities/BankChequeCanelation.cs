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
    
    public partial class BankChequeCanelation
    {
        public string ChequeCancelId { get; set; }
        public string CheqBookId { get; set; }
        public int ChequeCancelNo { get; set; }
        public System.DateTime ChequeCancelDate { get; set; }
        public decimal ChequeStopedNo { get; set; }
        public decimal CheckBookSerialId { get; set; }
        public int CompNo { get; set; }
        public int BranchNo { get; set; }
        public int LahTransferId { get; set; }
        public int DeletionId { get; set; }
        public Nullable<System.DateTime> SaveDate { get; set; }
    }
}
