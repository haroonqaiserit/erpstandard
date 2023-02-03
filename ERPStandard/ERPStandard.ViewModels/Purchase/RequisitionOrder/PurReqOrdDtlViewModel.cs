using ERPStandard.DbEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPStandard.ViewModels.Purchase.RquisitionOrder
{
    public class PurReqOrdDtlViewModel
    {
        public string RequisitionID { get; set; }
        public int LineNo { get; set; }
        public string ItemID { get; set; }
        public string ItemName { get; set; }
        public Nullable<decimal> StockQty { get; set; }
        public string ItemMeasureUnit { get; set; }
        public string ItemSpecification { get; set; }
        public Nullable<decimal> RequiredQty { get; set; }
        public Nullable<System.DateTime> RequiredDate { get; set; }
        public Nullable<decimal> BalanceQty { get; set; }
        public Nullable<int> ItemClearedStatus { get; set; }
        public string GrnID { get; set; }
        public decimal LastRate { get; set; }
        public string CostCenterId { get; set; }
        public string CostCenterName { get; set; }
        public string DemandPerson { get; set; }
        public bool ApprovedStatus { get; set; }
        public int CompNo { get; set; }
        public int BranchNo { get; set; }
        public int LahTransferId { get; set; }
        public System.DateTime SaveDate { get; set; }
        public int DeletionID { get; set; }

    }
}
