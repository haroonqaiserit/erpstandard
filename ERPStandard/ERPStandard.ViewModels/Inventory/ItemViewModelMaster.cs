using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPStandard.ViewModels.Inventory
{
    public class ItemViewModelMaster
    {
        public string ItemID { get; set; }
        public string Dscr { get; set; }
        public string STaxId { get; set; }
        public Nullable<int> SaleTaxNum { get; set; }
        public decimal? Rate { get; set; }
        public decimal? STaxRate { get; set; }
        public decimal? ASTaxRate { get; set; }
        public decimal? ExcDuty { get; set; }
        public System.DateTime? SaleTaxDate { get; set; }
        public System.DateTime? DtpAplicalbeDate { get; set; }
        public int CompNo { get; set; }
        public int BranchNo { get; set; }
    }
}
