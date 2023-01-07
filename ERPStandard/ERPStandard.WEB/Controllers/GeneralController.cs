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
        #region Company Setup
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CompanyIndex()
        {
            return View();
        }

        public ActionResult CompanyList(int? pageno, int pageSize = 10, string dtSearch = "", int clmNameOrder = 0)
        {
            pageno = pageno.HasValue ? pageno.Value : 1;
            var company1ViewModel = CompanyListLoad(pageno.Value, pageSize, dtSearch, clmNameOrder);
            return PartialView("CompanyList", company1ViewModel);
        }
        public Company1ViewModel CompanyListLoad(int pageno, int pageSize=10, string dtSearch="", int clmNameOrder=0)
        {
            Company1ViewModel company1ViewModel = new Company1ViewModel();
            company1ViewModel = Company1Service.Instance.All(pageno, pageSize, dtSearch, clmNameOrder);
            return company1ViewModel;
        }
        public ActionResult CompanyReportView(string dtSearch = "", int clmNameOrder = 0)
        {
            var company1ViewModel = Company1Service.Instance.Report(dtSearch, clmNameOrder);
            return PartialView("CompanyReportView", company1ViewModel);
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
#endregion


        #region Branch Setup
        public ActionResult BranchIndex()
        {
            return View();
        }
        public ActionResult BranchList(int? pageno, int pageSize = 10, string dtSearch = "", int clmNameOrder = 0)
        {
            pageno = pageno.HasValue ? pageno.Value : 1;
            var viewModel = BranchListLoad(pageno.Value, pageSize, dtSearch, clmNameOrder);
            return PartialView("BranchList", viewModel);
        }
        public BranchViewModel BranchListLoad(int pageno, int pageSize = 10, string dtSearch = "", int clmNameOrder = 0)
        {
            BranchViewModel viewModel = new BranchViewModel();
            viewModel = BranchService.Instance.All(pageno, pageSize, dtSearch, clmNameOrder);
            return viewModel;
        }
        public ActionResult BranchReportView(string dtSearch = "", int clmNameOrder = 0)
        {
            var viewModel = BranchService.Instance.Report(dtSearch, clmNameOrder);
            return PartialView("BranchReportView", viewModel);
        }

        [HttpGet]
        public ActionResult BranchEdit(string Id)
        {
            var comp = BranchService.Instance.Single(int.Parse(Id));
            return PartialView("BranchEditView", comp);
        }

        [HttpPost]
        public ActionResult BranchEdit(Branch branches)
        {
            var flgComp = BranchService.Instance.Update(branches);
            if (flgComp == true)
            {
                var viewModel = BranchListLoad(1);
                return PartialView("BranchList", viewModel);
            }
            return View();
        }

        [HttpGet]
        public ActionResult BranchCreate()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult BranchCreate(Branch branch)
        {
            var compno = BranchService.Instance.Add(branch);
            BranchViewModel viewModel = new BranchViewModel();
            viewModel = BranchService.Instance.All(1);
            return PartialView("BranchList", viewModel);
        }
        [HttpPost]
        public ActionResult BranchDelete(string Id)
        {
            var flgComp = BranchService.Instance.Delete(int.Parse(Id));
            if (flgComp == true)
            {
                var viewModel = BranchListLoad(1);
                return PartialView("BranchList", viewModel);
            }
            return View();
        }
#endregion


    }
}
