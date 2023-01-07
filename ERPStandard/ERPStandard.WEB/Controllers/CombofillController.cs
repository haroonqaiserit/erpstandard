﻿using ERPStandard.DbEntities;
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
        public ActionResult CompanyDropdown()
        {
            var ddlData = Company1Service.Instance.All_List();
            var dd = ddlData;
            return Json(dd, JsonRequestBehavior.AllowGet);
        }
        #endregion


    }
}