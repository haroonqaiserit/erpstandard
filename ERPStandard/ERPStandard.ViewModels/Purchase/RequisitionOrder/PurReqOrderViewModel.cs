using ERPStandard.DbEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPStandard.ViewModels.Purchase.RquisitionOrder
{
    public class PurReqOrderViewModel
    {
        public List<PurReqOrderMasterViewModel> RequisitionOrderMaster { get; set; }
        public Pager Pager { get; set; }
        public string dtSearch { get; set; }
        public int clmNameOrder { get; set; }
        public string sortorder { get; set; }
    }
}
