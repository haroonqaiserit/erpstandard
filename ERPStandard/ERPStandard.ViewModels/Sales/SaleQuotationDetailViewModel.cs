using ERPStandard.DbEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPStandard.ViewModels.Sales
{
    public class SaleQuotationDetailViewModel
    {
        public string QuoteId { get; set; }
        public string ItemID { get; set; }
        public string ItemName { get; set; }
        public decimal Qty { get; set; }
        public decimal Rate { get; set; }
        public decimal SaleTaxRate { get; set; }
        public decimal ASaleTaxRate { get; set; }
        public decimal SExDutyRate { get; set; }
        public int CompNo { get; set; }
        public int BranchNo { get; set; }
        public int LahTransferId { get; set; }
        public System.DateTime SaveDate { get; set; }
        public int DeletionID { get; set; }

    }
}
