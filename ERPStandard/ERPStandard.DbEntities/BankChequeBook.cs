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
    
    public partial class BankChequeBook
    {
        public string CheqBookId { get; set; }
        public int CheqBookNo { get; set; }
        public int CheckBookSerialId { get; set; }
        public System.DateTime ChequeBookDate { get; set; }
        public string BankAcntId { get; set; }
        public decimal FromChequeNo { get; set; }
        public decimal ToChequeNo { get; set; }
        public int CompNo { get; set; }
        public int BranchNo { get; set; }
        public int LahTransferId { get; set; }
        public int DeletionId { get; set; }
        public Nullable<System.DateTime> SaveDate { get; set; }
    }
}