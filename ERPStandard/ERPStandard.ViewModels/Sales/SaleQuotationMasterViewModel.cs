using ERPStandard.DbEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPStandard.ViewModels.Sales
{
    public class SaleQuotationMasterViewModel
    {
        public string QuoteId { get; set; }
        public decimal QuoteNo { get; set; }
        public System.DateTime QuoteDate { get; set; }
        public System.DateTime QuoteValidDate { get; set; }
        public string SalesManName { get; set; }
        public string CustomerName { get; set; }
        public string Remarks { get; set; }
        public int DeletionID { get; set; }
        public string RefDocId { get; set; }
        public string RefDocName { get; set; }
        public int CompNo { get; set; }
        public int BranchNo { get; set; }
        public int invoiceType { get; set; }
        public virtual List<CRM_SaleQuotationDetail> QuotationDetail { get; set; }
    }
}
