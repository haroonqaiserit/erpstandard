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
    
    public partial class Owner
    {
        public int OwnerId { get; set; }
        public Nullable<int> OStatusId { get; set; }
        public bool Registered { get; set; }
        public bool NonRegistered { get; set; }
        public Nullable<int> STaxId { get; set; }
        public Nullable<int> STaxRate { get; set; }
        public Nullable<int> ASTaxRate { get; set; }
        public string Remarks { get; set; }
        public string name { get; set; }
        public string Address { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string Staxno { get; set; }
        public string NationalTaxNo { get; set; }
        public string NICNo { get; set; }
        public string CashAc { get; set; }
        public string CashSaleAc { get; set; }
        public string SaleReturnAc { get; set; }
        public string CreditSaleAc { get; set; }
        public string ExportSaleAc { get; set; }
        public Nullable<int> LahTransferId { get; set; }
        public Nullable<System.DateTime> SaveDate { get; set; }
        public Nullable<int> DeletionID { get; set; }
    }
}
