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
    
    public partial class ItemFinishGoodRegister
    {
        public int id { get; set; }
        public string ItemID { get; set; }
        public string Dscr { get; set; }
        public System.DateTime OpeningDate { get; set; }
        public string Type { get; set; }
        public decimal OpeningQty { get; set; }
        public decimal ReceivedQty { get; set; }
        public decimal IssuedQty { get; set; }
        public System.DateTime fdate { get; set; }
        public System.DateTime tdate { get; set; }
        public int CompNo { get; set; }
        public int BranchNo { get; set; }
        public decimal Balance { get; set; }
        public Nullable<decimal> OldOpeningBalance { get; set; }
        public Nullable<int> LahTransferId { get; set; }
        public Nullable<System.DateTime> SaveDate { get; set; }
        public Nullable<int> DeletionID { get; set; }
    }
}
