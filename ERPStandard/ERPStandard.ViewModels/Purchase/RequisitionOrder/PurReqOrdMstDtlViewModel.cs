using ERPStandard.DbEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPStandard.ViewModels.Purchase.RquisitionOrder
{
    public class PurReqOrdMstDtlViewModel: PurReqOrderMasterViewModel
    {
        public int invoiceType { get; set; }
        //public PurReqOrderMasterViewModel SaleQuotationMaster { get; set; }
        public List<PurReqOrdDtlViewModel> PurReqOrderDetail { get; set; }
    }
}
