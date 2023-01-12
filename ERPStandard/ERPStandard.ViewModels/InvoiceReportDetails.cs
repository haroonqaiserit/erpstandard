using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPStandard.ViewModels
{
    public class InvoiceReportDetails
    {
        public int serialnum { get; set; }
        public string Item { get; set; }
        public decimal Qty { get; set; }
        public decimal rate { get; set; }
        public decimal STax { get; set; }
        public decimal ASTax { get; set; }
        public decimal SExDuty { get; set; }
        public decimal discount { get; set; }
        public decimal Amount { get; set; }
    }
}
