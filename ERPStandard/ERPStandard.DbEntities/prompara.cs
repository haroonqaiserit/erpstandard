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
    
    public partial class prompara
    {
        public System.DateTime fdate { get; set; }
        public System.DateTime tdate { get; set; }
        public int dept { get; set; }
        public decimal ChallanNo { get; set; }
        public string Remarks { get; set; }
        public System.DateTime TaxDate { get; set; }
        public int cid { get; set; }
        public Nullable<int> LahTransferId { get; set; }
        public Nullable<System.DateTime> SaveDate { get; set; }
        public Nullable<int> DeletionID { get; set; }
    }
}
