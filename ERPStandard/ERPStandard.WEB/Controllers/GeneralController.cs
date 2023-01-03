using ERPStandard.DbEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERPStandard.WEB.Controllers
{
    public class GeneralController : Controller
    {
        // GET: General
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CompanyIndex()
        {
            return View();
        }

        public ActionResult CompanyList()
        {
            return PartialView("CompanyList");
        }
        [HttpGet]
        public ActionResult CompanyEdit()
        {
            return PartialView();
        }

        [HttpGet]
        public ActionResult CompanyCreate()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult CompanyCreate(Company1 company1)
        {
            //var result = new HttpStatusCodeResult(200);
            return PartialView("CompanyList");
            //return View("CompanyList");
        }
        [HttpPost]
        public ActionResult CompanyDelete(string Id)
        {
            return PartialView("CompanyList");
        }

    }
}