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
    
    public partial class tblItemStockOpeningBalance
    {
        public string OpeiningId { get; set; }
        public string OpeningNo { get; set; }
        public string StoreUnitId { get; set; }
        public string ItemId { get; set; }
        public System.DateTime OBDate { get; set; }
        public decimal Rate { get; set; }
        public decimal Quantity { get; set; }
        public int CompNo { get; set; }
        public int BranchNo { get; set; }
        public System.DateTime SaveDate { get; set; }
        public int LahTransferId { get; set; }
        public string Remarks { get; set; }
        public int DeletionId { get; set; }
    }
}
