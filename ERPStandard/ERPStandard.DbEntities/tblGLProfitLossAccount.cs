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
    
    public partial class tblGLProfitLossAccount
    {
        public string ProfitLossId { get; set; }
        public string AcntId { get; set; }
        public string AcntType { get; set; }
        public int CompNo { get; set; }
        public int BranchNo { get; set; }
        public System.DateTime SaveDate { get; set; }
        public int LahTransferId { get; set; }
        public int DeletionId { get; set; }
    }
}
