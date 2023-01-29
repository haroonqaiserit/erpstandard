using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPStandard.ViewModels.Purchase.Purchaser
{
    public class PurchasersViewModel
    {
        public string PurchaseId { get; set; }
        public Nullable<int> PurchaserNum { get; set; }
        public string EmpNo { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string Email { get; set; }
        public Nullable<int> CompNo { get; set; }
        public Nullable<int> BranchNo { get; set; }
        public Nullable<int> LahTransferId { get; set; }
        public Nullable<System.DateTime> SaveDate { get; set; }
        public Nullable<int> DeletionID { get; set; }

    }
}
