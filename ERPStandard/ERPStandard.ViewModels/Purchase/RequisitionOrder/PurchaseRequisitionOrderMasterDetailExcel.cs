using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPStandard.ViewModels.Sales
{
    public class PurchaseRequisitionOrderMasterDetailExcel
    {
        #region Requisition Master Data
        public int SNo { get; set; }
        public string RequisitionID { get; set; }
        public string RequisitionOrderNo { get; set; }
        public System.DateTime RequisitionDate { get; set; }
        public string StoreUnitId { get; set; }
        public string Remarks { get; set; }
        public Nullable<int> ExpireDaysStatus { get; set; }
        public string IndentoCode { get; set; }
        public int CompNo { get; set; }
        public int BranchNo { get; set; }
        public Nullable<int> LahTransferId { get; set; }
        public Nullable<System.DateTime> SaveDate { get; set; }
        public Nullable<int> DeletionID { get; set; }
        public string RefDocId { get; set; }
        public string RefDocName { get; set; }
        #endregion
        #region Requosition Detail Data
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
        public string DemandPerson { get; set; }
        public bool ApprovedStatus { get; set; }
        #endregion

    }
}
