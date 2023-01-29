using ERPStandard.DbEntities;
using ERPStandard.ViewModels.Purchase.Purchaser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPStandard.ViewModels
{
    public class PurchaserViewModel
    {
        public List<PurchasersViewModel> Purchasers { get; set; }
        public Pager Pager { get; set; }
        public string dtSearch { get; set; }
        public int clmNameOrder { get; set; }
    }
}
