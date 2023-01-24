using ERPStandard.DbEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPStandard.ViewModels.Sales
{
    public class SaleQuotationMasterDetailViewModel
    {
        public int invoiceType { get; set; }
        public SaleQuotationMasterViewModel SaleQuotationMaster { get; set; }
        public List<SaleQuotationDetailViewModel> SaleQuotationDetail { get; set; }
    }
}
