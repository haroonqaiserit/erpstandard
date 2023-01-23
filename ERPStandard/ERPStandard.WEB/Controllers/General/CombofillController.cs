using ERPStandard.DbEntities;
using ERPStandard.Services;
using ERPStandard.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERPStandard.WEB.Controllers
{
    public class CombofillController : Controller
    {
        // GET: Combofill
        #region Common - Drop Downs
        [HttpGet]
        public ActionResult CompanyDropdown()
        {
            var ddlData = Company1Service.Instance.All_List();
            var dd = ddlData;
            return Json(dd, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Accounts - Drop Downs 
        [HttpGet]
        public ActionResult AccountDropdown()
        {
            var ddlData = ChartofAccountsService.Instance.coaDropDown("Profit");
            var dd = ddlData.COA;
            return Json(dd, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Sales - Drop Downs
        [HttpGet]
        public ActionResult CustomerDropdown()
        {
            var ddlData = CustomerService.Instance.All_List();
            return Json(ddlData, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult SalesmanDropdown()
        {
            var ddlData = SalesmanService.Instance.All_List();
            return Json(ddlData, JsonRequestBehavior.AllowGet);
        }
        #endregion



        #region Inventory - Drop Downs
        [HttpGet]
        public ActionResult ItemDropdown(string Search, int ItemClass)
        {
            var ddlData = ItemService.Instance.All_List(Search,0, ItemClass);
            return PartialView("ItemDropdown", ddlData);
        }

        public ActionResult SingleFirstRec(DateTime? docdate,string Search)
        {
            var ddlData = ItemService.Instance.SingleFirstRec(docdate,Search);
            return Json(ddlData, JsonRequestBehavior.AllowGet);
        }

        #endregion


    }
}
