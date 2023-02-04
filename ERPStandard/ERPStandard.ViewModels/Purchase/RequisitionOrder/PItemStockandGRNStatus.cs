using ERPStandard.ViewModels.Inventory;
using ERPStandard.ViewModels.Purchase.GoodReceptNote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPStandard.ViewModels.Purchase.RequisitionOrder
{
    public class PItemStockandGRNStatus
    {
        public lastGRNViewModel lsgGRN { get; set; }
        public ItemStockStatusViewModel ItemStockStatus { get; set; }
    }
}
