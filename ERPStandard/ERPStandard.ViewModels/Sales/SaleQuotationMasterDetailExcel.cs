using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPStandard.ViewModels.Sales
{
    public class SaleQuotationMasterDetailExcel
    {
        #region Quotation Master Data
        public int SNo { get; set; }
        public string QuoteId { get; set; }
        public decimal QuoteNo { get; set; }
        public System.DateTime QuoteDate { get; set; }
        public System.DateTime QuoteValidDate { get; set; }
        public string CustomerNo { get; set; }
        public string SalesManId { get; set; }
        public string SalesManName { get; set; }
        public string CustomerName { get; set; }
        public string Remarks { get; set; }
        public int DeletionID { get; set; }
        public string RefDocId { get; set; }
        public string RefDocName { get; set; }
        #endregion
        #region Quotation Detail Data
        public string ItemID { get; set; }
        public string ItemName { get; set; }
        public decimal Qty { get; set; }
        public decimal Rate { get; set; }
        public decimal SaleTaxRate { get; set; }
        public decimal ASaleTaxRate { get; set; }
        public decimal SExDutyRate { get; set; }
        #endregion

    }
}
