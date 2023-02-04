using ERPStandard.DbEntities;
using ERPStandard.Services;
using ERPStandard.ViewModels;
using ERPStandard.ViewModels.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClosedXML.Excel;
using System.IO;

namespace ERPStandard.WEB.Controllers
{
    //Colpse all open scopes
    //Ctl + M + O
    public class SalequotationController : Controller
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
            var comp = SaleQuotationService.Instance.QDtailed_Master_Detail();
            using (var workbook = new XLWorkbook())
            {
                
                var worksheet = workbook.Worksheets.Add("Quotation");
                var currentRow = 1;
                worksheet.Row(currentRow).Style.Fill.BackgroundColor = XLColor.LightBlue;
                #region Header
                int i = 1;
                worksheet.Cell(currentRow, i++).Value = "SNo";
                worksheet.Cell(currentRow, i++).Value = "QNo";
                worksheet.Cell(currentRow, i++).Value = "Date";
                worksheet.Cell(currentRow, i++).Value = "Valid Date";
                worksheet.Cell(currentRow, i++).Value = "Salesman";
                worksheet.Cell(currentRow, i++).Value = "Customer";
                worksheet.Cell(currentRow, i++).Value = "Remarks";
                worksheet.Cell(currentRow, i++).Value = "Item Code";
                worksheet.Cell(currentRow, i++).Value = "Item Detail";
                worksheet.Cell(currentRow, i++).Value = "Qty";
                worksheet.Cell(currentRow, i++).Value = "Rate";
                worksheet.Cell(currentRow, i++).Value = "Value";
                worksheet.Cell(currentRow, i++).Value = "VAT";
                worksheet.Cell(currentRow, i++).Value = "VAT Value";
                worksheet.Cell(currentRow, i++).Value = "ATax";
                worksheet.Cell(currentRow, i++).Value = "ATax Value";
                worksheet.Cell(currentRow, i++).Value = "SExduty";
                worksheet.Cell(currentRow, i++).Value = "SExduty Value";
                worksheet.Cell(currentRow, i++).Value = "Net Value";
                #endregion 
                #region Detail
                i = 1;
                foreach (var item in comp)
                {
                    foreach (var item_d in item.SaleQuotationDetail)
                    {
                        int j = 1;
                        currentRow += 1;
                        worksheet.Cell(currentRow, j++).Value = i;
                        worksheet.Cell(currentRow, j++).Value = item.SaleQuotationMaster.QuoteNo;
                        worksheet.Cell(currentRow, j++).Value = item.SaleQuotationMaster.QuoteDate.ToString("dd-MMM-yyyy");
                        worksheet.Cell(currentRow, j++).Value = item.SaleQuotationMaster.QuoteValidDate.ToString("dd-MMM-yyyy");
                        worksheet.Cell(currentRow, j++).Value = item.SaleQuotationMaster.SalesManName;
                        worksheet.Cell(currentRow, j++).Value = item.SaleQuotationMaster.CustomerName;
                        worksheet.Cell(currentRow, j++).Value = item.SaleQuotationMaster.Remarks;
                        var amount = item_d.Qty * item_d.Rate;
                        var SaleTax_amount = Math.Round(amount * item_d.SaleTaxRate / 100, 2);
                        var ASaleTax_amount = Math.Round(amount * item_d.ASaleTaxRate / 100, 2);
                        var SExDuty_amount = Math.Round(amount * item_d.SExDutyRate / 100, 2);
                        var NetTotal_amount = Math.Round(amount + SaleTax_amount + ASaleTax_amount + SExDuty_amount, 2);

                        //currentRow += 1;
                        worksheet.Cell(currentRow, j++).Value = item_d.ItemID;
                        worksheet.Cell(currentRow, j++).Value = item_d.ItemName;
                        worksheet.Cell(currentRow, j++).Value = item_d.Qty;
                        worksheet.Cell(currentRow, j++).Value = item_d.Rate;
                        worksheet.Cell(currentRow, j++).Value = amount;
                        worksheet.Cell(currentRow, j++).Value = item_d.SaleTaxRate;
                        worksheet.Cell(currentRow, j++).Value = SaleTax_amount;
                        worksheet.Cell(currentRow, j++).Value = item_d.ASaleTaxRate;
                        worksheet.Cell(currentRow, j++).Value = ASaleTax_amount;
                        worksheet.Cell(currentRow, j++).Value = item_d.SExDutyRate;
                        worksheet.Cell(currentRow, j++).Value = SExDuty_amount;
                        worksheet.Cell(currentRow, j++).Value = NetTotal_amount;
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

        public ActionResult SaleQuotationImport()
        {
            return PartialView("SaleQuotationImport");
        }
        [HttpPost]
        public ActionResult MasterDetailExcelImport(HttpPostedFileBase myExcelData)
        {
            List<SaleQuotationMasterDetailExcel> QuotationExcelList = new List<SaleQuotationMasterDetailExcel>();
            if (myExcelData.ContentLength > 0)//check is there file to upload
            {
                //string filePath = @"C:\Users\Public\Documents\";
                //string fileName = DateTime.Now.ToString("yyMMddHHmmss");
                //filePath = filePath + fileName + ".xlsx";
                //myExcelData.SaveAs(filePath);
                XLWorkbook xLWorkbook = new XLWorkbook(myExcelData.InputStream);

                var viewModel = new SaleQuotationMasterDetailViewModel();
                var SaleQuotationMaster = new SaleQuotationMasterViewModel();
                var SaleQuotationDetail = new SaleQuotationDetailViewModel();

                int row = 2;
                while(xLWorkbook.Worksheets.Worksheet(1).Cell(row, 1).GetString() != "")
                {
                    //int i = 1;
                    var QuotationExcel = new SaleQuotationMasterDetailExcel
                    {
                        SNo = int.Parse(xLWorkbook.Worksheets.Worksheet(1).Cell(row, "A").GetString()),
                        QuoteNo = decimal.Parse(xLWorkbook.Worksheets.Worksheet(1).Cell(row, "B").GetString()),
                        QuoteDate = DateTime.Parse(xLWorkbook.Worksheets.Worksheet(1).Cell(row, "C").GetString()),
                        QuoteValidDate = DateTime.Parse(xLWorkbook.Worksheets.Worksheet(1).Cell(row, "D").GetString()),
                        SalesManName = xLWorkbook.Worksheets.Worksheet(1).Cell(row, "E").GetString(),
                        SalesManId = xLWorkbook.Worksheets.Worksheet(1).Cell(row, "E").GetString(),
                        CustomerName = xLWorkbook.Worksheets.Worksheet(1).Cell(row, "F").GetString(),
                        CustomerNo = xLWorkbook.Worksheets.Worksheet(1).Cell(row, "F").GetString(),
                        Remarks = xLWorkbook.Worksheets.Worksheet(1).Cell(row, "G").GetString(),
                        ItemID = xLWorkbook.Worksheets.Worksheet(1).Cell(row, "H").GetString(),
                        ItemName = xLWorkbook.Worksheets.Worksheet(1).Cell(row, "I").GetString(),
                        Qty = decimal.Parse(xLWorkbook.Worksheets.Worksheet(1).Cell(row, "J").GetString()),
                        Rate = decimal.Parse(xLWorkbook.Worksheets.Worksheet(1).Cell(row, "K").GetString()),
                        //Value = decimal.Parse(xLWorkbook.Worksheets.Worksheet(1).Cell(row, "L").GetString()),
                        SaleTaxRate = decimal.Parse(xLWorkbook.Worksheets.Worksheet(1).Cell(row, "M").GetString()),
                        //STax = decimal.Parse(xLWorkbook.Worksheets.Worksheet(1).Cell(row, "N").GetString()),
                        ASaleTaxRate = decimal.Parse(xLWorkbook.Worksheets.Worksheet(1).Cell(row, "O").GetString()),
                        //ASTaxAmt = decimal.Parse(xLWorkbook.Worksheets.Worksheet(1).Cell(row, "P").GetString()),
                        SExDutyRate = decimal.Parse(xLWorkbook.Worksheets.Worksheet(1).Cell(row, "Q").GetString()),
                        //SExdutyAmt = decimal.Parse(xLWorkbook.Worksheets.Worksheet(1).Cell(row, "R").GetString()),
                        //NetValue = decimal.Parse(xLWorkbook.Worksheets.Worksheet(1).Cell(row, "S").GetString())
                    };
                    QuotationExcelList.Add(QuotationExcel);
                row++;
                }
            }
            else
            {
                return Json(new { success = true, message = "please upload an excel file" }, JsonRequestBehavior.AllowGet);
            }
            return PartialView("SaleQuotationExcelImport", QuotationExcelList);
        }
        #endregion

        #region Sales - Order

        [HttpGet]
        public ActionResult Search(string query, int itemclass)
        {
            // Retrieve items from database that match the query
            var items = ItemService.Instance.All_List(query, 0, itemclass);
            return Json(items, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SaleQuotationIndex()
        {
            return View();
        }
        public ActionResult SaleQuotationList(int? pageno, int pageSize = 10, string dtSearch = "", int clmNameOrder = 0, string sortorder="")
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
            var SaleQuotationViewModel = SaleQuotationListLoad(pageno.Value, pageSize, dtSearch, clmNameOrder, m_sortorder);
            return PartialView("SaleQuotationList", SaleQuotationViewModel);
        }
        public SaleQuotationViewModel SaleQuotationListLoad(int pageno, int pageSize = 10, string dtSearch = "", int clmNameOrder = 0, string sortorder = "")
        {
            SaleQuotationViewModel SaleQuotationViewModel = new SaleQuotationViewModel();
            SaleQuotationViewModel = SaleQuotationService.Instance.All(pageno, pageSize, dtSearch, clmNameOrder, sortorder);
            return SaleQuotationViewModel;
        }
        public ActionResult SaleQuotationReportView(string dtSearch = "", int clmNameOrder = 0)
        {
            var comp = SaleQuotationService.Instance.QDtailed_Master_Detail();
            return PartialView("SaleQuotationReportView", comp);
        }

        [HttpGet]
        public ActionResult SaleQuotationEdit(string Id)
        {
            var comp = SaleQuotationService.Instance.Single_Master_Detail(Id);
            comp.invoiceType = (int)InvoiceType.Invoice_Tax_AddTax;
            return PartialView("SaleQuotationEdit", comp);
        }

        [HttpPost]
        public ActionResult SaleQuotationEdit(CRM_SaleQuotation SaleQuotation, List<CRM_SaleQuotationDetail> SaleQuotationDetail)
        {
            //var flgComp = SaleQuotationService.Instance.Update(SaleQuotation);
            try
            {
                var compno = SaleQuotationService.Instance.Update(SaleQuotation, SaleQuotationDetail);
                SaleQuotationViewModel SaleQuotationViewModel = new SaleQuotationViewModel();
                SaleQuotationViewModel = SaleQuotationService.Instance.All(1);
                //return PartialView("SaleQuotationList", SaleQuotationViewModel);
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
        public ActionResult SaleQuotationCreate()
        {
            QuotationCreateNewViewModel quotationCreateNewViewModel = new QuotationCreateNewViewModel
            {
                invoiceType = (int)InvoiceType.Invoice_Tax_AddTax
            };
            return PartialView("SaleQuotationCreate", quotationCreateNewViewModel);
        }
        [HttpPost]
        public ActionResult SaleQuotationCreate(CRM_SaleQuotation SaleQuotation, List<CRM_SaleQuotationDetail> SaleQuotationDetail)
        {
            try
            {
                var compno = SaleQuotationService.Instance.Add(SaleQuotation, SaleQuotationDetail);
                SaleQuotationViewModel SaleQuotationViewModel = new SaleQuotationViewModel();
                SaleQuotationViewModel = SaleQuotationService.Instance.All(1);
                //return PartialView("SaleQuotationList", SaleQuotationViewModel);
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
        public ActionResult SaleQuotationDelete(string Id)
        {
            var flgComp = SaleQuotationService.Instance.Delete(Id);
            if (flgComp == true)
            {
                var SaleQuotationViewModel = SaleQuotationListLoad(1);
                return PartialView("SaleQuotationList", SaleQuotationViewModel);
            }
            return View();
        }
        
        [HttpGet]
        public ActionResult SaleQuotationPreview(string Id)
        {
            var root = SaleQuotationService.Instance.InvoiceReport<InvoiceDetails_ISTAX_ISExDuty>(Id);
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
        //    var root = SaleQuotationService.Instance.InvoiceReport(Id);
        //    var printpdf = new ActionAsPdf("DocumentReportTemplate", root);
        //    return printpdf;
        //}
        [HttpGet]
        public ActionResult SaleInvoiceTemplate(string Id)
        {
            var root = SaleQuotationService.Instance.InvoiceReport<InvoiceDetails_ISTAX_ISExDuty>(Id);
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
    }
}
