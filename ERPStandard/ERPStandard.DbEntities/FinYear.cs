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
    
    public partial class FinYear
    {
        public int FinYearId { get; set; }
        public System.DateTime FYDate { get; set; }
        public System.DateTime FinYearFrom { get; set; }
        public System.DateTime FinYearTo { get; set; }
        public string Remarks { get; set; }
        public Nullable<int> YearStatus { get; set; }
        public Nullable<int> LahTransferId { get; set; }
        public Nullable<System.DateTime> SaveDate { get; set; }
        public Nullable<int> DeletionID { get; set; }
    }
}