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
    
    public partial class Company1
    {
        public string Company_Name { get; set; }
        public string company_desc { get; set; }
        public string Company_address { get; set; }
        public string Company_phones { get; set; }
        public string Company_email { get; set; }
        public string Company_fax { get; set; }
        public int CompNo { get; set; }
        public Nullable<int> LahTransferId { get; set; }
        public Nullable<System.DateTime> SaveDate { get; set; }
        public Nullable<int> DeletionID { get; set; }
        public string CityName { get; set; }
        public string PostCode { get; set; }
        public string STaxRegNo { get; set; }
        public string NationalTaxNo { get; set; }
    }
}