using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPStandard.ViewModels.Purchase.GoodReceptNote
{
    public class lastGRNViewModel
    {
        public string lstGRNID { get; set; }
        public decimal lstQty { get; set; }
        public decimal lstRate { get; set; }
        public DateTime lstGrnDate { get; set; }
        public string lstGrnDateString { get; set; }
    }
}
