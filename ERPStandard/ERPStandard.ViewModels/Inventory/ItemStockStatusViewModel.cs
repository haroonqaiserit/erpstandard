using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPStandard.ViewModels.Inventory
{
    public class ItemStockStatusViewModel
    {
        public string ItemId { get; set; }
        public string CompNo { get; set; }
        public string BranchNo { get; set; }
        public string StoreUnitId { get; set; }
        public string GodownId { get; set; }
        public string ToDate { get; set; }
        public decimal? StockQty { get; set; } = 0;
        public decimal? AvgRate { get; set; }= 0;
    }
}
