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
    
    public partial class tblUOMItemMapping
    {
        public int Id { get; set; }
        public string ItemId { get; set; }
        public int UOMId { get; set; }
        public decimal ConversionFactor { get; set; }
    }
}
