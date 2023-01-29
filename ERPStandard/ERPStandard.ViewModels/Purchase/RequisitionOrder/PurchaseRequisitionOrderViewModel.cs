using ERPStandard.DbEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPStandard.ViewModels.Sales
{
    public class PurchaseRequisitionOrderViewModel
    {
        public List<PurchaseRequisitionOrderMasterViewModel> RequisitionOrderMaster { get; set; }
        public Pager Pager { get; set; }
        public string dtSearch { get; set; }
        public int clmNameOrder { get; set; }
        public string sortorder { get; set; }
    }
}
