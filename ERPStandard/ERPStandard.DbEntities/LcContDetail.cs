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
    
    public partial class LcContDetail
    {
        public decimal LcContId { get; set; }
        public int LineNo { get; set; }
        public Nullable<int> ItemId { get; set; }
        public int Qty { get; set; }
        public float UnitRate { get; set; }
        public Nullable<decimal> Tamt { get; set; }
        public Nullable<int> LahTransferId { get; set; }
        public Nullable<System.DateTime> SaveDate { get; set; }
        public Nullable<int> DeletionID { get; set; }
    }
}
