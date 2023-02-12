using ERPStandard.DbEntities;
using ERPStandard.Services;
using ERPStandard.ViewModels;
using ERPStandard.ViewModels.Purchase.RquisitionOrder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClosedXML.Excel;
using System.IO;
using ERPStandard.ViewModels.Inventory;
using ERPStandard.ViewModels.Purchase.GoodReceptNote;
using ERPStandard.ViewModels.Purchase.RequisitionOrder;

namespace ERPStandard.WEB.Controllers
{
    //Colpse all open scopes
    //Ctl + M + O
    public class PurReqOrderController : Controller
    {
        // In the name of Allah, The Most Merciful, The Most Benificial
        // Created on 08-Jan-2022
        // Created by Haroon
        // Sales Order Master Detail Form
        #region Excel Export Methods
        public byte[] Export<T>(List<T> list, string file, string sheetName)
        {
            byte[] content;
            XLWorkbook _workbook = new XLWorkbook();
            using (XLWorkbook workbook = new XLWorkbook())
            {
                workbook.AddWorksheet(sheetName).FirstCell().InsertTable<T>(list, false);

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    content = stream.ToArray();
                }


            }
            return content;
        }
        public ActionResult excelexport()
        {
            var o1 = new { Id = 1, Name = "Foo" };
            var o2 = new { Id = 2, Name = "Bar" };
            var list = new[] { o1, o2 }.ToList();
            byte[] content = Export(list, "excelexport", "sheet2");

            return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Quotation.xlsx");

        }
        public ActionResult MasterDetailExcelExport()
        {
            var comp = PurReqOrderService.Instance.QDtailed_Master_Detail();
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Requisition");
                var currentRow = 1;
                worksheet.Row(currentRow).Style.Fill.BackgroundColor = XLColor.LightBlue;
                #region Header
                int i = 1;
                worksheet.Cell(currentRow, i++).Value = "SNo";
                worksheet.Cell(currentRow, i++).Value = "ReqNo";
                worksheet.Cell(currentRow, i++).Value = "Date";
                worksheet.Cell(currentRow, i++).Value = "StoreUnitId";
                worksheet.Cell(currentRow, i++).Value = "UnitName";
                worksheet.Cell(currentRow, i++).Value = "Remarks";
                worksheet.Cell(currentRow, i++).Value = "RefDocId";
                worksheet.Cell(currentRow, i++).Value = "Item Code";
                worksheet.Cell(currentRow, i++).Value = "Item Detail";
                worksheet.Cell(currentRow, i++).Value = "ItemSpecification";
                worksheet.Cell(currentRow, i++).Value = "RequiredQty";
                worksheet.Cell(currentRow, i++).Value = "ItemMeasureUnit";
                worksheet.Cell(currentRow, i++).Value = "RequiredDate";
                worksheet.Cell(currentRow, i++).Value = "CostCenterId";
                worksheet.Cell(currentRow, i++).Value = "UnitName";
                worksheet.Cell(currentRow, i++).Value = "DemandPerson";
                #endregion 
                #region Detail
                i = 1;
                foreach (var item in comp)
                {
                    foreach (var item_d in item.PurReqOrderDetail)
                    {
                        int j = 1;
                        currentRow += 1;
                        worksheet.Cell(currentRow, j++).Value = i;
                        worksheet.Cell(currentRow, j++).Value = item.RequisitionOrderNo;
                        worksheet.Cell(currentRow, j++).Value = item.RequisitionDate.ToString("dd-MMM-yyyy");
                        worksheet.Cell(currentRow, j++).Value = item.StoreUnitId;
                        worksheet.Cell(currentRow, j++).Value = item.UnitName;
                        worksheet.Cell(currentRow, j++).Value = item.Remarks;
                        worksheet.Cell(currentRow, j++).Value = item.RefDocId;

                        //currentRow += 1;
                        worksheet.Cell(currentRow, j++).Value = item_d.ItemID;
                        worksheet.Cell(currentRow, j++).Value = item_d.ItemName;
                        worksheet.Cell(currentRow, j++).Value = item_d.ItemSpecification;
                        worksheet.Cell(currentRow, j++).Value = item_d.RequiredQty;
                        worksheet.Cell(currentRow, j++).Value = item_d.CostCenterId;
                        worksheet.Cell(currentRow, j++).Value = item_d.CostCenterName;
                        worksheet.Cell(currentRow, j++).Value = item_d.DemandPerson;
                    }
                    i++;
                }
                #endregion 
                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "QuotationDetail.xlsx");
                }
            }
        }

        public ActionResult PurReqOrderImport()
        {
            return PartialView("PurReqOrderImport");
        }
        [HttpPost]
        public ActionResult MasterDetailExcelImport(HttpPostedFileBase myExcelData)
        {
            List<PurRequOrderMstrDtlExcel> PurReqExcelList = new List<PurRequOrderMstrDtlExcel>();
            if (myExcelData.ContentLength > 0)//check is there file to upload
            {
                //string filePath = @"C:\Users\Public\Documents\";
                //string fileName = DateTime.Now.ToString("yyMMddHHmmss");
                //filePath = filePath + fileName + ".xlsx";
                //myExcelData.SaveAs(filePath);
                XLWorkbook xLWorkbook = new XLWorkbook(myExcelData.InputStream);

                var viewModel = new PurRequOrderMstrDtlExcel();
                var PurReqOrderMaster = new PurReqOrderMasterViewModel();
                var PurReqOrderDetail = new PurchaseRequisitionOrderDetail();

                int row = 2;
                while(xLWorkbook.Worksheets.Worksheet(1).Cell(row, 1).GetString() != "")
                {
                    //int i = 1;
                    var QuotationExcel = new PurRequOrderMstrDtlExcel
                    {
                        //SNo = int.Parse(xLWorkbook.Worksheets.Worksheet(1).Cell(row, "A").GetString()),
                        //QuoteNo = decimal.Parse(xLWorkbook.Worksheets.Worksheet(1).Cell(row, "B").GetString()),
                        //QuoteDate = DateTime.Parse(xLWorkbook.Worksheets.Worksheet(1).Cell(row, "C").GetString()),
                        //QuoteValidDate = DateTime.Parse(xLWorkbook.Worksheets.Worksheet(1).Cell(row, "D").GetString()),
                        //SalesManName = xLWorkbook.Worksheets.Worksheet(1).Cell(row, "E").GetString(),
                        //SalesManId = xLWorkbook.Worksheets.Worksheet(1).Cell(row, "E").GetString(),
                        //CustomerName = xLWorkbook.Worksheets.Worksheet(1).Cell(row, "F").GetString(),
                        //CustomerNo = xLWorkbook.Worksheets.Worksheet(1).Cell(row, "F").GetString(),
                        //Remarks = xLWorkbook.Worksheets.Worksheet(1).Cell(row, "G").GetString(),
                        //ItemID = xLWorkbook.Worksheets.Worksheet(1).Cell(row, "H").GetString(),
                        //ItemName = xLWorkbook.Worksheets.Worksheet(1).Cell(row, "I").GetString(),
                        //Qty = decimal.Parse(xLWorkbook.Worksheets.Worksheet(1).Cell(row, "J").GetString()),
                        //Rate = decimal.Parse(xLWorkbook.Worksheets.Worksheet(1).Cell(row, "K").GetString()),
                        ////Value = decimal.Parse(xLWorkbook.Worksheets.Worksheet(1).Cell(row, "L").GetString()),
                        //SaleTaxRate = decimal.Parse(xLWorkbook.Worksheets.Worksheet(1).Cell(row, "M").GetString()),
                        ////STax = decimal.Parse(xLWorkbook.Worksheets.Worksheet(1).Cell(row, "N").GetString()),
                        //ASaleTaxRate = decimal.Parse(xLWorkbook.Worksheets.Worksheet(1).Cell(row, "O").GetString()),
                        ////ASTaxAmt = decimal.Parse(xLWorkbook.Worksheets.Worksheet(1).Cell(row, "P").GetString()),
                        //SExDutyRate = decimal.Parse(xLWorkbook.Worksheets.Worksheet(1).Cell(row, "Q").GetString()),
                        ////SExdutyAmt = decimal.Parse(xLWorkbook.Worksheets.Worksheet(1).Cell(row, "R").GetString()),
                        ////NetValue = decimal.Parse(xLWorkbook.Worksheets.Worksheet(1).Cell(row, "S").GetString())
                    };
                    PurReqExcelList.Add(QuotationExcel);
                row++;
                }
            }
            else
            {
                return Json(new { success = true, message = "please upload an excel file" }, JsonRequestBehavior.AllowGet);
            }
            return PartialView("PurReqOrderExcelImport", PurReqExcelList);
        }
        #endregion

        #region Sales - Order

        public ActionResult PurReqOrderIndex()
        {
            return View();
        }
        public ActionResult PurReqOrderList(int? pageno, int pageSize = 10, string dtSearch = "", int clmNameOrder = 0, string sortorder="")
        {
            string m_sortorder = "desc";
            if(sortorder == "asc")
            {
                m_sortorder = "desc";
            }else if(sortorder == "desc")
            {
                m_sortorder = "asc";
            }

            pageno = pageno ?? 1;
            var PurReqOrderViewModel = PurReqOrderListLoad(pageno.Value, pageSize, dtSearch, clmNameOrder, m_sortorder);
            return PartialView("PurReqOrderList", PurReqOrderViewModel);
        }
        public PurReqOrderViewModel PurReqOrderListLoad(int pageno, int pageSize = 10, string dtSearch = "", int clmNameOrder = 0, string sortorder = "")
        {
            PurReqOrderViewModel PurReqOrderViewModel = new PurReqOrderViewModel();
            PurReqOrderViewModel = PurReqOrderService.Instance.All(pageno, pageSize, dtSearch, clmNameOrder, sortorder);
            return PurReqOrderViewModel;
        }
        public ActionResult PurReqOrderReportView(string dtSearch = "", int clmNameOrder = 0)
        {
            var comp = PurReqOrderService.Instance.QDtailed_Master_Detail();
            return PartialView("PurReqOrderReportView", comp);
        }

        [HttpGet]
        public ActionResult PurReqOrderEdit(string Id)
        {
            var comp = PurReqOrderService.Instance.Single_Master_Detail(Id);
            comp.invoiceType = (int)InvoiceType.Invoice_Tax_AddTax;
            return PartialView("PurReqOrderEdit", comp);
        }

        [HttpPost]
        public ActionResult PurReqOrderEdit(PurchaseRequisitionOrder PurReqOrder, List<PurchaseRequisitionOrderDetail> PurReqOrderDetail)
        {
            //var flgComp = PurReqOrderService.Instance.Update(PurReqOrder);
            try
            {
                var compno = PurReqOrderService.Instance.Update(PurReqOrder, PurReqOrderDetail);
                PurReqOrderViewModel PurReqOrderViewModel = new PurReqOrderViewModel();
                PurReqOrderViewModel = PurReqOrderService.Instance.All(1);
                //return PartialView("PurReqOrderList", PurReqOrderViewModel);
                if (compno > 0)
                {
                    return Json(new { result = "ture" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { result = "false" }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(new { result = "false: " + ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult PurReqOrderCreate()
        {
            QuotationCreateNewViewModel quotationCreateNewViewModel = new QuotationCreateNewViewModel
            {
                invoiceType = (int)InvoiceType.Invoice_Tax_AddTax
            };
            return PartialView("PurReqOrderCreate", quotationCreateNewViewModel);
        }
        [HttpPost]
        public ActionResult PurReqOrderCreate(PurchaseRequisitionOrder PurReqOrder, List<PurchaseRequisitionOrderDetail> PurReqOrderDetail)
        {
            try
            {
                var compno = PurReqOrderService.Instance.Add(PurReqOrder, PurReqOrderDetail);
                PurReqOrderViewModel PurReqOrderViewModel = new PurReqOrderViewModel();
                PurReqOrderViewModel = PurReqOrderService.Instance.All(1);
                //return PartialView("PurReqOrderList", PurReqOrderViewModel);
                if (compno > 0)
                {
                    return Json(new { result= "ture"}, JsonRequestBehavior.AllowGet);
 //                   return Json(root, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { result = "false"}, JsonRequestBehavior.AllowGet); 
                }
            }
            catch (Exception ex)
            {
                return Json(new { result = "false: " + ex.Message}, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public ActionResult PurReqOrderDelete(string Id)
        {
            var flgComp = PurReqOrderService.Instance.Delete(Id);
            if (flgComp == true)
            {
                var PurReqOrderViewModel = PurReqOrderListLoad(1);
                return PartialView("PurReqOrderList", PurReqOrderViewModel);
            }
            return View();
        }
        
        [HttpGet]
        public ActionResult PurReqOrderPreview(string Id)
        {
            var root = PurReqOrderService.Instance.InvoiceReport<PurReqOrderDetails>(Id);
            if (root != null)
            {
                return Json(root, JsonRequestBehavior.AllowGet);
            }
            return View();
        }
        //public ActionResult SaleInvoiceTemplate(string Id)
        //{
        //    if (string.IsNullOrEmpty(Id))
        //    {
        //        Id = "1 -L";
        //    }
        //    var root = PurReqOrderService.Instance.InvoiceReport(Id);
        //    var printpdf = new ActionAsPdf("DocumentReportTemplate", root);
        //    return printpdf;
        //}
        [HttpGet]
        public ActionResult SaleInvoiceTemplate(string Id)
        {
            var root = PurReqOrderService.Instance.InvoiceReport<InvoiceDetails_ISTAX_ISExDuty>(Id);
            if (root != null)
            {
                try
                {

                    //return Json(root, JsonRequestBehavior.AllowGet);
                    //return PartialView("DocumentReportTemplate", root);
                    //return ActionAsPdf("DocumentReportTemplate", root);
                    return PartialView("SaleInvoiceTemplate", root);
                }
                catch (Exception ex)
                {
                    return Json(ex, JsonRequestBehavior.AllowGet);
                }
            }
            return View();
        }
        #endregion
        [HttpGet]
        public  ActionResult ItemCurrentStock(ItemStockStatusViewModel stockstatus)
        {
            ItemStockStatusViewModel itemStock = new ItemStockStatusViewModel();
            stockstatus.CompNo = StandardVariables.CompNo.ToString();
            stockstatus.BranchNo = StandardVariables.BranchNo.ToString();
            stockstatus.GodownId = string.IsNullOrEmpty(stockstatus.GodownId) ? "" : stockstatus.GodownId;
            stockstatus.ToDate = string.IsNullOrEmpty(stockstatus.ToDate) ? "" : stockstatus.ToDate;
            itemStock = ItemService.Instance.StockStatus(stockstatus);
            
            lastGRNViewModel last = new lastGRNViewModel();
            last = PurReqOrderService.Instance.LastGRN(stockstatus.ItemId);
            last.lstGrnDateString = last.lstGrnDate.ToString("dd-MMM-yy");
            PItemStockandGRNStatus pItem = new PItemStockandGRNStatus();
            pItem.lsgGRN = last;
            pItem.ItemStockStatus = itemStock;
            return Json(pItem, JsonRequestBehavior.AllowGet);
        }

    }
}
