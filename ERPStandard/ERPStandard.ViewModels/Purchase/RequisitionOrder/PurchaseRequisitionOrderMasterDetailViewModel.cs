using ERPStandard.DbEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPStandard.ViewModels.Sales
{
    public class PurchaseRequisitionOrderMasterDetailViewModel: PurchaseRequisitionOrderMasterViewModel
    {
        public int invoiceType { get; set; }
        //public PurchaseRequisitionOrderMasterViewModel SaleQuotationMaster { get; set; }
        public List<PurchaseRequisitionOrderDetailViewModel> SaleQuotationDetail { get; set; }
    }
}
