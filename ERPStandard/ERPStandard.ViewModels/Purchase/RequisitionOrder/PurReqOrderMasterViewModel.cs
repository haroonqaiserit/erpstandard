using ERPStandard.DbEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPStandard.ViewModels.Purchase.RquisitionOrder
{
    public class PurReqOrderMasterViewModel
    {
        public string RequisitionID { get; set; }
        public string RefDocId { get; set; }
        public string RefDocName { get; set; }
        public System.DateTime? RefDocDate { get; set; }
        public int RequisitionOrderNo { get; set; }
        public System.DateTime RequisitionDate { get; set; }
        public string StoreUnitId { get; set; }
        public string UnitName { get; set; }
        public string Remarks { get; set; }
        public int CompNo { get; set; }
        public int BranchNo { get; set; }
        public Nullable<int> LahTransferId { get; set; }
        public Nullable<System.DateTime> SaveDate { get; set; }
        public Nullable<int> DeletionID { get; set; }
    }
}
