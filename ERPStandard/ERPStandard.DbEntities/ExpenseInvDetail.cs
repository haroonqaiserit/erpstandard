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
    
    public partial class ExpenseInvDetail
    {
        public string ExpInvId { get; set; }
        public int LineNo { get; set; }
        public Nullable<int> MesleneiousId { get; set; }
        public Nullable<int> Amount { get; set; }
        public Nullable<int> STaxPayAble { get; set; }
        public Nullable<int> AmtWSt { get; set; }
        public Nullable<int> TaxIdentityId { get; set; }
        public int STaxCalFlag { get; set; }
        public Nullable<int> LahTransferId { get; set; }
        public Nullable<System.DateTime> SaveDate { get; set; }
        public Nullable<int> DeletionID { get; set; }
    }
}
