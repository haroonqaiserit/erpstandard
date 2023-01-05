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

        public Company1ViewModel CompanyListLoad(int pageno, int pageSize=10, string dtSearch="", int clmNameOrder=0)
        {
            Company1ViewModel company1ViewModel = new Company1ViewModel();
            company1ViewModel = Company1Service.Instance.All(pageno, pageSize, dtSearch, clmNameOrder);
            return company1ViewModel;
        }
        public ActionResult CompanyList(int? pageno, int pageSize = 10, string dtSearch = "", int clmNameOrder=0)
        {
            pageno = pageno.HasValue ? pageno.Value : 1;
            var company1ViewModel = CompanyListLoad(pageno.Value, pageSize, dtSearch, clmNameOrder);
            return PartialView("CompanyList", company1ViewModel);
        }

        [HttpGet]
        public ActionResult CompanyEdit(string Id)
        {
            var comp = Company1Service.Instance.Single(int.Parse(Id));
            return PartialView("CompanyEditView", comp);
        }

        [HttpPost]
        public ActionResult CompanyEdit(Company1 company)
        {
            var flgComp= Company1Service.Instance.Update(company);
            if (flgComp == true)
            {
                var company1ViewModel = CompanyListLoad(1);
                return PartialView("CompanyList", company1ViewModel);
            }
            return View();
        }

        [HttpGet]
        public ActionResult CompanyCreate()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult CompanyCreate(Company1 company1)
        {
            var compno = Company1Service.Instance.Add(company1);
            Company1ViewModel company1ViewModel = new Company1ViewModel();
            company1ViewModel = Company1Service.Instance.All(1);
            return PartialView("CompanyList", company1ViewModel);
        }
        [HttpPost]
        public ActionResult CompanyDelete(string Id)
        {
            var flgComp = Company1Service.Instance.Delete(int.Parse(Id));
            if (flgComp == true)
            {
                var company1ViewModel = CompanyListLoad(1);
                return PartialView("CompanyList", company1ViewModel);
            }
            return View();
        }

    }
}