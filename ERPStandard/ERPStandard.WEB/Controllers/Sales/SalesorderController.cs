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
    public class SalesorderController : Controller
    {
        // In the name of Allah, the most merciful
        // Created on 08-Jan-2022
        // Created by Haroon
        // Sales Order Master Detail Form

        #region Sales - Order

        public ActionResult SalesOrderIndex()
        {
            return View();
        }

        //public ActionResult SalesOrderList(int? pageno, int pageSize = 10, string dtSearch = "", int clmNameOrder = 0)
        //{
        //    pageno = pageno.HasValue ? pageno.Value : 1;
        //    var SalesOrderViewModel = SalesOrderListLoad(pageno.Value, pageSize, dtSearch, clmNameOrder);
        //    return PartialView("SalesOrderList", SalesOrderViewModel);
        //}
        //public SalesOrderViewModel SalesOrderListLoad(int pageno, int pageSize = 10, string dtSearch = "", int clmNameOrder = 0)
        //{
        //    SalesOrderViewModel SalesOrderViewModel = new SalesOrderViewModel();
        //    SalesOrderViewModel = SalesOrderService.Instance.All(pageno, pageSize, dtSearch, clmNameOrder);
        //    return SalesOrderViewModel;
        //}
        //public ActionResult SalesOrderReportView(string dtSearch = "", int clmNameOrder = 0)
        //{
        //    var SalesOrderViewModel = SalesOrderService.Instance.Report(dtSearch, clmNameOrder);
        //    return PartialView("SalesOrderReportView", SalesOrderViewModel);
        //}

        //[HttpGet]
        //public ActionResult SalesOrderEdit(string Id)
        //{
        //    var comp = SalesOrderService.Instance.Single(int.Parse(Id));
        //    return PartialView("SalesOrderEditView", comp);
        //}

        //[HttpPost]
        //public ActionResult SalesOrderEdit(SalesOrder SalesOrder)
        //{
        //    var flgComp = SalesOrderService.Instance.Update(SalesOrder);
        //    if (flgComp == true)
        //    {
        //        var SalesOrderViewModel = SalesOrderListLoad(1);
        //        return PartialView("SalesOrderList", SalesOrderViewModel);
        //    }
        //    return View();
        //}

        //[HttpGet]
        //public ActionResult SalesOrderCreate()
        //{
        //    return PartialView();
        //}
        //[HttpPost]
        //public ActionResult SalesOrderCreate(SalesOrder SalesOrder)
        //{
        //    var compno = SalesOrderService.Instance.Add(SalesOrder);
        //    SalesOrderViewModel SalesOrderViewModel = new SalesOrderViewModel();
        //    SalesOrderViewModel = SalesOrderService.Instance.All(1);
        //    return PartialView("SalesOrderList", SalesOrderViewModel);
        //}
        //[HttpPost]
        //public ActionResult SalesOrderDelete(string Id)
        //{
        //    var flgComp = SalesOrderService.Instance.Delete(int.Parse(Id));
        //    if (flgComp == true)
        //    {
        //        var SalesOrderViewModel = SalesOrderListLoad(1);
        //        return PartialView("SalesOrderList", SalesOrderViewModel);
        //    }
        //    return View();
        //}


        #endregion
    }
}
