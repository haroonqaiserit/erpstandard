using ERPStandard.DbEntities;
using ERPStandard.Services;
using ERPStandard.ViewModels;
using ERPStandard.ViewModels.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERPStandard.WEB.Controllers
{
    public class SalequotationController : Controller
    {
        // In the name of Allah, the most merciful
        // Created on 08-Jan-2022
        // Created by Haroon
        // Sales Order Master Detail Form

        #region Sales - Order

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

            pageno = pageno.HasValue ? pageno.Value : 1;
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
            var SaleQuotationViewModel = SaleQuotationService.Instance.Report(dtSearch, clmNameOrder);
            return PartialView("SaleQuotationReportView", SaleQuotationViewModel);
        }

        [HttpGet]
        public ActionResult SaleQuotationEdit(string Id)
        {
            var comp = SaleQuotationService.Instance.Single(Id);
            return PartialView("SaleQuotationEditView", comp);
        }

        [HttpPost]
        public ActionResult SaleQuotationEdit(CRM_SaleQuotation SaleQuotation)
        {
            var flgComp = SaleQuotationService.Instance.Update(SaleQuotation);
            if (flgComp == true)
            {
                var SaleQuotationViewModel = SaleQuotationListLoad(1);
                return PartialView("SaleQuotationList", SaleQuotationViewModel);
            }
            return View();
        }

        [HttpGet]
        public ActionResult SaleQuotationCreate()
        {
            SaleQuotationMasterViewModel saleQuotationMasterViewModel = new SaleQuotationMasterViewModel();
            saleQuotationMasterViewModel.invoiceType = (int)InvoiceType.Invoice_Tax_AddTax;
            return PartialView("SaleQuotationCreate", saleQuotationMasterViewModel);
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
