using ERPStandard.DbEntities;
using ERPStandard.ViewModels;
using ERPStandard.ViewModels.Purchase.GoodReceptNote;
using ERPStandard.ViewModels.Purchase.RquisitionOrder;
using ERPStandard.ViewModels.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPStandard.Services
{
    public class PurReqOrderService
    {
        #region "Singleton"

        public static PurReqOrderService Instance
        {
            get
            {
                if (instance == null) instance = new PurReqOrderService();
                return instance;
            }
        }
        private static PurReqOrderService instance { get; set; }

        private PurReqOrderService()
        {

        }
        #endregion
        public PurReqOrderViewModel All(int page, int pageSize = 10, string dtSearch = "", int clmNameOrder = 0, string sortorder = "")
        {
            var viewModel = new PurReqOrderViewModel();
            using (var context = new SairaIndEntities())
            {
                var comp = context.PurchaseRequisitionOrders
                    .Join(context.tblStoreUnits,
                        o => o.StoreUnitId,
                        unit => unit.StoreUnitId,
                    (o, unit) => new PurReqOrderMasterViewModel
                    {
                        RequisitionID = o.RequisitionID,
                        RequisitionOrderNo = o.RequisitionOrderNo,
                        RequisitionDate = o.RequisitionDate,
                        StoreUnitId = o.StoreUnitId,
                        UnitName = unit.UnitName,
                        Remarks = o.Remarks,
                        CompNo = o.CompNo,
                        BranchNo = o.BranchNo,
                        DeletionID = o.DeletionID,
                        SaveDate = o.SaveDate,
                        RefDocId = o.RefDocId,
                        RefDocName = o.RefDocName,
                        RefDocDate = o.RefDocDate.Value
                    }
                ).Where(x => x.RequisitionID.Contains(dtSearch)
                        || x.Remarks.Contains(dtSearch)
                        || x.RefDocName.Contains(dtSearch)
                        || x.UnitName.Contains(dtSearch)
                        );
                int totalpage = comp.Select(x => x.RequisitionID).Count();
                var pager = new Pager(totalpage, page, pageSize);
                if (clmNameOrder == 1)
                {
                    comp = sortorder=="asc"? comp.OrderBy(x => x.RequisitionOrderNo) : comp.OrderByDescending(x => x.RequisitionOrderNo);
                }
                else if (clmNameOrder == 2)
                {
                    comp = sortorder == "asc" ? comp.OrderBy(x => x.RequisitionDate) : comp.OrderByDescending(x => x.RequisitionDate);
                }
                else if (clmNameOrder == 3)
                {
                    comp = sortorder == "asc" ? comp.OrderBy(x => x.UnitName) : comp.OrderByDescending(x => x.UnitName);
                }
                else if (clmNameOrder == 4)
                {
                    comp = sortorder == "asc" ? comp.OrderBy(x => x.Remarks) : comp.OrderByDescending(x => x.Remarks);
                }
                else
                {
                    comp = sortorder == "asc" ? comp.OrderBy(x => x.RequisitionOrderNo) : comp.OrderByDescending(x => x.RequisitionOrderNo);
                }

                viewModel.RequisitionOrderMaster = comp.Skip((pager.CurrentPage - 1) * pager.PageSize).Take(pager.PageSize).ToList();
                viewModel.dtSearch = dtSearch;
                viewModel.clmNameOrder = clmNameOrder;
                viewModel.sortorder = sortorder;
                viewModel.Pager = pager;
            }
            return viewModel;
        }
        public PurReqOrderViewModel Report(string dtSearch = "", int clmNameOrder = 0)
        {
            var viewModel = new PurReqOrderViewModel();
            using (var context = new SairaIndEntities())
            {
                var comp = context.PurchaseRequisitionOrders
                    .Join(context.tblStoreUnits,
                        o => o.StoreUnitId,
                        unit => unit.StoreUnitId,
                    (o, unit) => new PurReqOrderMasterViewModel
                    {
                        RequisitionID = o.RequisitionID,
                        RequisitionOrderNo = o.RequisitionOrderNo,
                        RequisitionDate = o.RequisitionDate,
                        StoreUnitId = o.StoreUnitId,
                        UnitName = unit.UnitName,
                        Remarks = o.Remarks,
                        CompNo = o.CompNo,
                        BranchNo = o.BranchNo,
                        DeletionID = o.DeletionID,
                        SaveDate = o.SaveDate,
                        RefDocId = o.RefDocId,
                        RefDocName = o.RefDocName,
                        RefDocDate = o.RefDocDate.Value
                    }
                ).Where(x => x.RequisitionID.Contains(dtSearch)
                        || x.Remarks.Contains(dtSearch)
                        || x.RefDocName.Contains(dtSearch)
                        || x.UnitName.Contains(dtSearch)
                        );

                int totalpage = comp.Select(x => x.RequisitionID).Count();
                if (clmNameOrder == 1)
                {
                    comp =  comp.OrderByDescending(x => x.RequisitionOrderNo);
                }
                else if (clmNameOrder == 2)
                {
                    comp = comp.OrderByDescending(x => x.RequisitionDate);
                }
                else if (clmNameOrder == 3)
                {
                    comp = comp.OrderByDescending(x => x.UnitName);
                }
                else if (clmNameOrder == 4)
                {
                    comp = comp.OrderByDescending(x => x.Remarks);
                }
                else
                {
                    comp = comp.OrderByDescending(x => x.RequisitionOrderNo);
                }
                viewModel.RequisitionOrderMaster = comp.ToList();
                viewModel.dtSearch = dtSearch;
                viewModel.clmNameOrder = clmNameOrder;
            }
            return viewModel;
        }
        public PurReqOrderRoot<T> RequsitionOrderReportList<T>(string Id)
        {
            var root = new PurReqOrderRoot<T>();
            PurchaseReqDetaillist<T> invoice = new PurchaseReqDetaillist<T>();
            PurReqOrderHeaders invoiceHeaders = new PurReqOrderHeaders();
            string documentname = "Requisition";
            root.fileName = "Sale " + documentname;
            root.orientationLandscape = false;

            int TotalAmnt = 0;
            int InvNetTotalAmnt = 0;
            List<T> invoice_report_details = new List<T>();
            using (var context = new SairaIndEntities())
            {
                var inv_Master = (from master in context.PurchaseRequisitionOrders
                                  where master.CompNo == StandardVariables.CompNo
                                  && master.BranchNo == StandardVariables.BranchNo
                                  && master.RequisitionID == Id
                                  join detail in context.tblStoreUnits on master.StoreUnitId equals detail.StoreUnitId
                                  where detail.CompNo == master.CompNo & detail.BranchNo == master.BranchNo
                                  join customer in context.Company1 on master.CompNo equals customer.CompNo
                                  select new { master, detail, customer}).FirstOrDefault();
                //Business class settings - Root
                Business business = new Business();
                business.name = inv_Master.customer.Company_Name == null ? "" : inv_Master.customer.Company_Name;
                business.address = inv_Master.customer.Company_address == null ? "" : inv_Master.customer.Company_address;
                business.phone = inv_Master.customer.Company_phones == null ? "" : inv_Master.customer.Company_phones;
                business.email = inv_Master.customer.Company_email == null ? "" : inv_Master.customer.Company_email;
                business.email_1 = "";
                business.website = ""; //inv_Master.c.company_website;
                business.STaxRegNo = inv_Master.customer.STaxRegNo == null ? "" : inv_Master.customer.STaxRegNo;
                business.NationalTaxNo = inv_Master.customer.NationalTaxNo == null ? "" : inv_Master.customer.NationalTaxNo;
                business.City = inv_Master.customer.CityName == null ? "" : inv_Master.customer.CityName;
                root.business = business;
                ViewModels.Contact contact = new ViewModels.Contact();
                contact.label = "Invoice issued for:";
                contact.name = "";
                contact.address = "";
                contact.phone = "";
                contact.email = "";
                contact.website = "";
                contact.STaxRegNo = "";
                contact.NationalTaxNo = "";
                contact.City = "";
                //contact.otherInfo = inv_Master.d.r;
                root.contact = contact;

                invoice.label = documentname;
                invoice.DocumentNum = inv_Master.master.RequisitionOrderNo.ToString();
                invoice.DocumentDate = inv_Master.master.RequisitionDate.ToString("dd-MMM-yyyy");
                invoice.UnitName = inv_Master.detail.UnitName;
                invoice.DocumentGenDate = "Print Date: " + DateTime.Now.ToString("dd-MMM-yyyy hh:mm tt"); ;
                invoice.headerBorder = true;
                invoice.tableBodyBorder = true;
                invoice.RefDocId = inv_Master.master.RefDocId == null ? "" : inv_Master.master.RefDocId;
                invoice.RefDocName = inv_Master.master.RefDocName == null ? "" : inv_Master.master.RefDocName;
                invoice.DocumentDesc = inv_Master.master.Remarks;
                root.pageLabel = inv_Master.master.StoreUnitId == null ? "" : "this " + documentname + " is valid till " + inv_Master.detail.UnitName;

                invoice.header = invoiceHeaders.invoiceListHeaders();

                var inv_detail = (from m in context.PurchaseRequisitionOrders
                    where m.CompNo == StandardVariables.CompNo
                        && m.BranchNo == StandardVariables.BranchNo
                        && m.RequisitionID == Id
                    join su in context.tblStoreUnits on m.StoreUnitId equals su.StoreUnitId
                    where su.CompNo == m.CompNo
                        && su.BranchNo == m.BranchNo
                    join d in context.PurchaseRequisitionOrderDetails on m.RequisitionID equals d.RequisitionID
                    where d.CompNo == m.CompNo
                        && d.BranchNo == m.BranchNo
                    join cc in context.CostCenterNews on d.CostCenterId equals cc.CostCenterId
                    where cc.CompNo == d.CompNo
                        && cc.BranchNo == d.BranchNo
                    join itm in context.ItemsStocks on d.ItemId equals itm.ItemID
                    where itm.CompNo == d.CompNo
                        && itm.BranchNo == d.BranchNo
                    join uom in context.tblUOMs on d.ItemMeasureUnit equals uom.ID into uomJoin
                    from uomJ in uomJoin.DefaultIfEmpty()
                    select new PurReqOrderDetails
                    {
                        serialnum = 1,
                        GRNID = d.GrnID,
                        ItemID = itm.ItemID,
                        Item = itm.Dscr + Environment.NewLine + d.ItemSpecification,
                        StockQty = d.StockQty,
                        Qty = d.RequiredQty.Value,
                        EstRate = d.EstRate,
                        UOM = uomJ.Name?? d.ItemMeasureUnit,
                        Amount = Math.Round(d.RequiredQty.Value * d.EstRate??1, 0),
                        UnitName = su.UnitName,
                        Required_Date = d.RequiredDate,
                        DemandPerson = d.DemandPerson,
                        ApprovedStatus = d.ApprovedStatus==true?"Approved":"Reject"
                    });
                var t = inv_detail.ToList();
                var GRNID = t.Select(x => x.GRNID).FirstOrDefault();
                var grnRec = (from grn in context.RmGrns
                              join grnd in context.RmGrnDetails on grn.GRNID equals grnd.GRNID
                              where grn.CompNo == grnd.Compno && grn.BranchNo == grnd.Branchno
                              && grn.GRNID == GRNID
                              && grnd.RepairItem == 0
                              select new
                              {
                                  grn.GRNID,
                                  grn.GrnDate,
                                  grn.StoreUnitId,
                                  grnd.ItemId,
                                  grnd.QtyAcc,
                                  grnd.Rate,
                                  grn.CompNo,
                                  grn.BranchNo
                              }).Where(x => x.CompNo == StandardVariables.CompNo && x.BranchNo == StandardVariables.BranchNo).ToList();


                foreach (var item in t)
                {
                    var lstGRNItemId = grnRec.Where(x => x.ItemId == item.ItemID).Select(x => x.ItemId).FirstOrDefault();
                    if (lstGRNItemId != null) { 
                    item.LDate = grnRec.Where(x => x.ItemId == item.ItemID).Select(x => x.GrnDate).FirstOrDefault().ToString("dd-MMM-yy");
                    item.LQty = grnRec.Where(x => x.ItemId == item.ItemID).Select(x => x.QtyAcc).FirstOrDefault();
                    item.LRate = grnRec.Where(x => x.ItemId == item.ItemID).Select(x => x.Rate).FirstOrDefault();
                    }

                    if (item.Required_Date.Value.Date == inv_Master.master.RequisitionDate.Date)
                    {
                        item.RequiredDate = "Urgent";
                    }
                    else
                    {
                        item.RequiredDate = item.Required_Date.Value.ToString("dd-MMM-yy");
                    }


                    //item.RequiredDate = item.Required_Date.Value.ToString("dd-MMM-yy");
                };


                    var count = 1;
                    foreach (var x in t) x.serialnum = count++;
                    TotalAmnt = (int)Math.Round((double)t.Sum(n => n.Amount), 0);
                    var ReqQty = (int)Math.Round((double)t.Sum(n => n.Qty), 0);
                    InvNetTotalAmnt = TotalAmnt;
                    PurReqOrderDetails TotalRow = new PurReqOrderDetails
                    {
                        serialnum = null,
                        Item = "TOTAL",
                        Qty = ReqQty,
                        Amount = TotalAmnt
                    };
                    t.Add(TotalRow);
                    invoice_report_details = t as List<T>;
                    invoice.table = invoice_report_details;
            }
            invoice.TotalAmntInWords = StandardVariables.ConvertNumberToWords(InvNetTotalAmnt);
            invoice.DocumentNetlAmount = InvNetTotalAmnt;
            root.invoice = invoice;
            return root;
        }

        decimal cal(decimal qty, decimal rate)
        {
            decimal amt = 0;
            amt = Math.Round(qty * rate, 2);
            return amt;
        }
        public PurReqOrderRoot<T> InvoiceReport<T> (string Id = "")
        {
            var root = new PurReqOrderRoot<T>();

            root = RequsitionOrderReportList<T>(Id);

            //logo class settings
            Logo logo = new Logo();
            logo.src = "https://raw.githubusercontent.com/edisonneza/jspdf-invoice-template/demo/images/logo.png";
            logo.width = 53.33;
            logo.height = 26.66;
            //Margin for Logo class settings
            Margin margin = new Margin();
            margin.top = 0;
            margin.left = 0;
            logo.margin = margin;
            root.logo = logo;
            //Stamp class settings - Root
            Stamp stamp = new Stamp();
            stamp.inAllPages = true;
            stamp.src = "https://raw.githubusercontent.com/edisonneza/jspdf-invoice-template/demo/images/qr_code.jpg";
            stamp.width = 20; //aspect ratio = width/height
            stamp.height= 20;
            //Margin for Stamp class settings
            margin.top = 0;
            margin.left = 0;
            stamp.margin = margin;
            root.stamp = stamp;


            //tbl.Add(invoice_report_details);
            Footer footer = new Footer();
            footer.text = "The invoice is created on a computer and is valid without the signature and stamp.";
            root.pageEnable=true;
            root.footer = footer;
            return root;
        }
        public PurReqOrdMstDtlViewModel Single_Master_Detail(string Id)
        {
            var viewModel = new PurReqOrdMstDtlViewModel();
            
            using (var context = new SairaIndEntities())
            {
                var comp = context.PurchaseRequisitionOrders
                    .Join(context.tblStoreUnits,
                        o => o.StoreUnitId,
                        unit => unit.StoreUnitId,
                        (o, unit) => new PurReqOrdMstDtlViewModel
                        {
                            RequisitionID = o.RequisitionID,
                            RequisitionOrderNo = o.RequisitionOrderNo,
                            RequisitionDate = o.RequisitionDate,
                            StoreUnitId = o.StoreUnitId,
                            UnitName = unit.UnitName,
                            Remarks = o.Remarks,
                            CompNo = o.CompNo,
                            BranchNo = o.BranchNo,
                            DeletionID = o.DeletionID,
                            SaveDate = o.SaveDate,
                            RefDocId = o.RefDocId,
                            RefDocName = o.RefDocName,
                            RefDocDate = o.RefDocDate.Value
                        })
                .Where(x => x.RequisitionID==Id
                        && x.CompNo == StandardVariables.CompNo
                        && x.BranchNo == StandardVariables.BranchNo
                        );

                var grnRec = (from grn in context.RmGrns
                              join grnd in context.RmGrnDetails on grn.GRNID equals grnd.GRNID
                              where grn.CompNo == grnd.Compno && grn.BranchNo == grnd.Branchno
                              && grnd.RepairItem == 0
                              select new
                              {
                                  grn.GRNID,
                                  grn.GrnDate,
                                  grn.StoreUnitId,
                                  grnd.ItemId,
                                  grnd.QtyAcc,
                                  grnd.Rate,
                                  grn.CompNo,
                                  grn.BranchNo,
                              }).Where(x => x.CompNo == StandardVariables.CompNo && x.BranchNo == StandardVariables.BranchNo);


                var compDetail = (from m in context.PurchaseRequisitionOrders
                                  where m.CompNo == StandardVariables.CompNo
                                      && m.BranchNo == StandardVariables.BranchNo
                                  join d in context.PurchaseRequisitionOrderDetails on m.RequisitionID equals d.RequisitionID
                                  where d.CompNo == m.CompNo
                                      && d.BranchNo == m.BranchNo
                                      && m.RequisitionID == Id
                                  join itm in context.ItemsStocks on d.ItemId equals itm.ItemID
                                  where itm.CompNo == d.CompNo
                                      && itm.BranchNo == d.BranchNo
                                  join su in context.tblStoreUnits on m.StoreUnitId equals su.StoreUnitId
                                  where itm.CompNo == d.CompNo
                                      && itm.BranchNo == d.BranchNo
                                  join cst in context.CostCenterNews on d.CostCenterId equals cst.CostCenterName
                                  where cst.CompNo == d.CompNo
                                      && cst.BranchNo == d.BranchNo
                                  join e in context.EmployeePersonalInfoes on d.DemandPerson equals e.EmpNo
                                  where itm.CompNo == d.CompNo
                                      && itm.BranchNo == d.BranchNo
                                  join grn in grnRec on d.ItemId equals grn.ItemId into grn_rec
                                  from grn in grn_rec.DefaultIfEmpty()
                                  select new PurReqOrdDtlViewModel
                                  {
                                      LineNo = 1,
                                      ItemID = itm.ItemID,
                                      ItemName = itm.Dscr,
                                      StockQty = d.StockQty,
                                      ItemMeasureUnit = d.ItemMeasureUnit,
                                      ItemSpecification = d.ItemSpecification,
                                      RequiredDate = d.RequiredDate,
                                      RequiredQty = d.RequiredQty.Value,
                                      LastRate = grn.Rate,
                                      CostCenterId = d.CostCenterId,
                                      CostCenterName = cst.CostCenterName,
                                      DemandPerson = d.DemandPerson,
                                      GrnID = d.GrnID,
                                      ApprovedStatus = d.ApprovedStatus.Value
                                  });
                //List<PurReqOrdDtlViewModel> viewModel1 = new List<PurReqOrdDtlViewModel>();
                viewModel = comp.FirstOrDefault();
                viewModel.PurReqOrderDetail = compDetail.ToList();
            }
            return viewModel;
        }

        public List<PurReqOrdMstDtlViewModel> QDtailed_Master_Detail()
        {
            var viewModelDetail = new List<PurReqOrdMstDtlViewModel>();
            using (var context = new SairaIndEntities())
            {
                var comp = context.PurchaseRequisitionOrders
                    .Join(context.tblStoreUnits,
                        o => o.StoreUnitId,
                        unit => unit.StoreUnitId,
                        (o, unit) => new PurReqOrdMstDtlViewModel
                        {
                            RequisitionID = o.RequisitionID,
                            RequisitionOrderNo = o.RequisitionOrderNo,
                            RequisitionDate = o.RequisitionDate,
                            StoreUnitId = o.StoreUnitId,
                            UnitName = unit.UnitName,
                            Remarks = o.Remarks,
                            CompNo = o.CompNo,
                            BranchNo = o.BranchNo,
                            DeletionID = o.DeletionID,
                            SaveDate = o.SaveDate,
                            RefDocId = o.RefDocId,
                            RefDocName = o.RefDocName,
                            RefDocDate = o.RefDocDate.Value
                        })
                .Where(x => x.CompNo == StandardVariables.CompNo
                        && x.BranchNo == StandardVariables.BranchNo
                        ).ToList();

                var grnRec = (from grn in context.RmGrns
                              join grnd in context.RmGrnDetails on grn.GRNID equals grnd.GRNID
                              where grn.CompNo == grnd.Compno && grn.BranchNo == grnd.Branchno
                              && grnd.RepairItem == 0
                              select new
                              {
                                  grn.GRNID,
                                  grn.GrnDate,
                                  grn.StoreUnitId,
                                  grnd.ItemId,
                                  grnd.QtyAcc,
                                  grnd.Rate,
                                  grn.CompNo,
                                  grn.BranchNo
                              }).Where(x => x.CompNo == StandardVariables.CompNo && x.BranchNo == StandardVariables.BranchNo);


                var compDetail = (from m in context.PurchaseRequisitionOrders
                    where m.CompNo == StandardVariables.CompNo
                        && m.BranchNo == StandardVariables.BranchNo
                    join d in context.PurchaseRequisitionOrderDetails on m.RequisitionID equals d.RequisitionID
                    where d.CompNo == m.CompNo
                        && d.BranchNo == m.BranchNo
                    join itm in context.ItemsStocks on d.ItemId equals itm.ItemID
                    where itm.CompNo == d.CompNo
                        && itm.BranchNo == d.BranchNo
                    join su in context.tblStoreUnits on m.StoreUnitId equals su.StoreUnitId
                    where itm.CompNo == d.CompNo
                        && itm.BranchNo == d.BranchNo
                    join cst in context.CostCenterNews on d.CostCenterId equals cst.CostCenterName
                    where cst.CompNo == d.CompNo
                        && cst.BranchNo == d.BranchNo
                    join e in context.EmployeePersonalInfoes on d.DemandPerson equals e.EmpNo
                    where itm.CompNo == d.CompNo
                        && itm.BranchNo == d.BranchNo
                    join grn in grnRec on d.ItemId equals grn.ItemId into grn_rec
                    from grn in grn_rec.DefaultIfEmpty()
                    select new PurReqOrdDtlViewModel
                    {
                        LineNo = 1,
                        RequisitionID = m.RequisitionID,
                        ItemID = itm.ItemID,
                        ItemName = itm.Dscr,
                        StockQty = d.StockQty,
                        ItemMeasureUnit = d.ItemMeasureUnit,
                        ItemSpecification = d.ItemSpecification,
                        RequiredDate = d.RequiredDate,
                        RequiredQty = d.RequiredQty.Value,
                        LastRate = grn.Rate,
                        CostCenterId = d.CostCenterId,
                        CostCenterName = cst.CostCenterName,
                        DemandPerson = d.DemandPerson,
                        GrnID = d.GrnID,
                        ApprovedStatus = d.ApprovedStatus.Value
                    }).ToList();

                foreach (var item in comp)
                {
                    var viewModel = new PurReqOrdMstDtlViewModel();
                    viewModel = item;
                    viewModel.PurReqOrderDetail = (List<PurReqOrdDtlViewModel>)compDetail.Where(x => x.RequisitionID == item.RequisitionID);
                    viewModelDetail.Add(viewModel);
                }
            }
            return viewModelDetail;
        }

        public PurchaseRequisitionOrder Single(string Id)
        {
            var viewModel = new PurchaseRequisitionOrder();
            if (!string.IsNullOrEmpty(Id))
            {
                using (var context = new SairaIndEntities())
                {
                    viewModel = context.PurchaseRequisitionOrders.Where(x => x.RequisitionID == Id).FirstOrDefault();
                }
            }
            return viewModel;
        }
        public int Add(PurchaseRequisitionOrder PurchaseRequisitionOrder, List<PurchaseRequisitionOrderDetail> PurchaseRequisitionOrderDetails)
        {
            int savechanges = 0;
            using (var context = new SairaIndEntities())
            {
                
                int compno = (int)context.PurchaseRequisitionOrders.Select(x => x.RequisitionOrderNo).Max() + 1;
                PurchaseRequisitionOrder.RequisitionOrderNo = compno;
                PurchaseRequisitionOrder.RequisitionID = PurchaseRequisitionOrder.RequisitionOrderNo.ToString().PadLeft(4, '0') + '-' + StandardVariables.BLetter;
                PurchaseRequisitionOrder.DeletionID = 0;
                PurchaseRequisitionOrder.LahTransferId = 0;
                PurchaseRequisitionOrder.SaveDate = DateTime.Now;
                PurchaseRequisitionOrder.CompNo = GlobalVariables.CompNo;
                PurchaseRequisitionOrder.BranchNo = GlobalVariables.BranchNo;
                //PurchaseRequisitionOrderDetails saledetail = new PurchaseRequisitionOrderDetails();
                foreach (var item in PurchaseRequisitionOrderDetails)
                {
                    item.RequisitionDate = PurchaseRequisitionOrder.RequisitionDate;
                    item.StoreUnitId = PurchaseRequisitionOrder.StoreUnitId;
                    item.RequisitionID = PurchaseRequisitionOrder.RequisitionID;
                    item.DeletionID = 0;
                    item.LahTransferId = 0;
                    item.SaveDate = DateTime.Now;
                    item.CompNo = PurchaseRequisitionOrder.CompNo;
                    item.BranchNo = PurchaseRequisitionOrder.BranchNo;
                }
                
                context.PurchaseRequisitionOrders.Add(PurchaseRequisitionOrder);
                context.PurchaseRequisitionOrderDetails.AddRange(PurchaseRequisitionOrderDetails);
                savechanges = context.SaveChanges();
            }
            return savechanges;
        }
        public int Update(PurchaseRequisitionOrder PurchaseRequisitionOrder, List<PurchaseRequisitionOrderDetail> PurchaseRequisitionOrderDetails)
        {
            var entityMain = Single(PurchaseRequisitionOrder.RequisitionID);
            
            PurchaseRequisitionOrder.CompNo = entityMain.CompNo;
            PurchaseRequisitionOrder.BranchNo = entityMain.BranchNo;
            PurchaseRequisitionOrder.LahTransferId = entityMain.LahTransferId;
            PurchaseRequisitionOrder.DeletionID = entityMain.DeletionID;

            int savechanges = 0;
            using (var context = new SairaIndEntities())
            {
                //PurchaseRequisitionOrderDetails saledetail = new PurchaseRequisitionOrderDetails();
                foreach (var item in PurchaseRequisitionOrderDetails)
                {
                    item.RequisitionID = PurchaseRequisitionOrder.RequisitionID;
                    item.DeletionID = 0;
                    item.LahTransferId = 0;
                    item.SaveDate = DateTime.Now;
                    item.CompNo = entityMain.CompNo;
                    item.BranchNo = entityMain.BranchNo;
                }
                var compDetail = context.PurchaseRequisitionOrderDetails.Where(x => x.RequisitionID == entityMain.RequisitionID).ToList();
                context.PurchaseRequisitionOrderDetails.RemoveRange(compDetail);
                context.Entry(PurchaseRequisitionOrder).State = System.Data.Entity.EntityState.Modified;
                context.PurchaseRequisitionOrderDetails.AddRange(PurchaseRequisitionOrderDetails);
                savechanges = context.SaveChanges();
            }

            return savechanges;
        }
        public bool Delete(string Id)
        {
            bool flgCompany = false;
            using (var context = new SairaIndEntities())
            {
                if (!string.IsNullOrEmpty(Id))
                {
                    var compDetail = context.PurchaseRequisitionOrderDetails.Where(x => x.RequisitionID == Id).ToList();
                    var comp = context.PurchaseRequisitionOrders.Where(x => x.RequisitionID == Id).FirstOrDefault();
                    context.PurchaseRequisitionOrderDetails.RemoveRange(compDetail);
                    context.PurchaseRequisitionOrders.Remove(comp);
                    context.SaveChanges();
                    flgCompany = true;
                }
            }
            return flgCompany;
        }
        public lastGRNViewModel LastGRN(string ItemId)
        {
            lastGRNViewModel lstGRN = new lastGRNViewModel();
            using (var context = new SairaIndEntities())
            {
                //here in the below query applied finncialyear check
                //because gap needs to cover this in saira industry
                if (!string.IsNullOrEmpty(ItemId))
                {
                    lstGRN = (from grn in context.RmGrns
                                      join grnd in context.RmGrnDetails on grn.GRNID equals grnd.GRNID
                                      where grn.CompNo == grnd.Compno
                                      && grn.BranchNo == grn.BranchNo
                                      && grn.GrnDate >= StandardVariables.FinYearFrom
                                      && grn.CompNo == StandardVariables.CompNo
                                      && grn.BranchNo == StandardVariables.BranchNo
                                      && grnd.ItemId == ItemId
                              select new lastGRNViewModel
                                      {
                                          lstGRNID= grn.GRNID,
                                          lstQty=grnd.QtyAcc,
                                          lstRate= grnd.Rate,
                                          lstGrnDate= grn.GrnDate,
                                          //lstGrnDateString = grn.GrnDate.ToString("dd-MMM-yyyy")
                                      }).OrderByDescending(x => x.lstGrnDate)
                                      .Take(1)
                                      .FirstOrDefault();
                }
            }
            return lstGRN;
        }
    }
}
