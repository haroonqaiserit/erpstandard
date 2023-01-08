using ERPStandard.DbEntities;
using ERPStandard.ViewModels;
using ERPStandard.ViewModels.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPStandard.Services
{
    public class SaleQuotationService
    {
        #region "Singleton"

        public static SaleQuotationService Instance
        {
            get
            {
                if (instance == null) instance = new SaleQuotationService();
                return instance;
            }
        }
        private static SaleQuotationService instance { get; set; }

        private SaleQuotationService()
        {

        }
        #endregion
        public SaleQuotationViewModel All(int page, int pageSize = 10, string dtSearch = "", int clmNameOrder = 0)
        {
            var viewModel = new SaleQuotationViewModel();
            using (var context = new SairaIndEntities())
            {
                var comp = context.CRM_SaleQuotation.Where(x => x.QuoteId.Contains(dtSearch)
                        || x.Remarks.Contains(dtSearch)
                        || x.RefDocName.Contains(dtSearch)
                        );

                int totalpage = comp.Select(x => x.QuoteId).Count();
                var pager = new Pager(totalpage, page, pageSize);
                if (clmNameOrder == 1)
                {
                    comp = comp.OrderBy(x => x.QuoteNo);
                }
                else if (clmNameOrder == 2)
                {
                    comp = comp.OrderBy(x => x.QuoteDate);
                }
                else if (clmNameOrder == 3)
                {
                    comp = comp.OrderBy(x => x.QuoteValidDate);
                }
                else if (clmNameOrder == 4)
                {
                    comp = comp.OrderBy(x => x.Remarks);
                }
                else
                {
                    comp = comp.OrderBy(x => x.QuoteNo);
                }

                viewModel.SaleQuotation = comp.Skip((pager.CurrentPage - 1) * pager.PageSize).Take(pager.PageSize).ToList();
                viewModel.dtSearch = dtSearch;
                viewModel.clmNameOrder = clmNameOrder;
                viewModel.Pager = pager;
            }
            return viewModel;
        }
        public SaleQuotationViewModel Report(string dtSearch = "", int clmNameOrder = 0)
        {
            var viewModel = new SaleQuotationViewModel();
            using (var context = new SairaIndEntities())
            {
                var comp = context.CRM_SaleQuotation.Where(x => x.QuoteId.Contains(dtSearch)
                        || x.Remarks.Contains(dtSearch)
                        || x.RefDocName.Contains(dtSearch)
                        );

                int totalpage = comp.Select(x => x.QuoteId).Count();
                if (clmNameOrder == 1)
                {
                    comp = comp.OrderBy(x => x.QuoteNo);
                }
                else if (clmNameOrder == 2)
                {
                    comp = comp.OrderBy(x => x.QuoteDate);
                }
                else if (clmNameOrder == 3)
                {
                    comp = comp.OrderBy(x => x.QuoteValidDate);
                }
                else if (clmNameOrder == 4)
                {
                    comp = comp.OrderBy(x => x.Remarks);
                }
                else
                {
                    comp = comp.OrderBy(x => x.QuoteNo);
                }

                viewModel.SaleQuotation = comp.ToList();
                viewModel.dtSearch = dtSearch;
                viewModel.clmNameOrder = clmNameOrder;
            }
            return viewModel;
        }
        public CRM_SaleQuotation Single(string Id)
        {
            var viewModel = new CRM_SaleQuotation();
            if (!string.IsNullOrEmpty(Id))
            {
                using (var context = new SairaIndEntities())
                {
                    viewModel = context.CRM_SaleQuotation.Where(x => x.QuoteId == Id).FirstOrDefault();
                }
            }
            return viewModel;
        }
        public int Add(CRM_SaleQuotation SaleQuotation)
        {
            int compno = 0;
            using (var context = new SairaIndEntities())
            {
                compno = context.CRM_SaleQuotation.Select(x => int.Parse(x.QuoteNo.ToString())).Max() + 1;
                SaleQuotation.QuoteNo = compno;
                SaleQuotation.DeletionID = 0;
                SaleQuotation.LahTransferId = 0;
                SaleQuotation.SaveDate = DateTime.Now;
                SaleQuotation.CompNo = GlobalVariables.CompNo;
                SaleQuotation.BranchNo = GlobalVariables.BranchNo;
                context.CRM_SaleQuotation.Add(SaleQuotation);
                context.SaveChanges();
            }
            return compno;
        }
        public bool Update(CRM_SaleQuotation SaleQuotation)
        {
            var entityMain = Single(SaleQuotation.QuoteId);

            SaleQuotation.CompNo = entityMain.CompNo;
            SaleQuotation.BranchNo = entityMain.BranchNo;
            SaleQuotation.SaveDate = DateTime.Now;
            SaleQuotation.DeletionID = 0;
            SaleQuotation.LahTransferId = 0;

            bool flgCompany = false;
            using (var context = new SairaIndEntities())
            {
                context.Entry(SaleQuotation).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
                flgCompany = true;
            }
            return flgCompany;
        }
        public bool Delete(string Id)
        {
            bool flgCompany = false;
            using (var context = new SairaIndEntities())
            {
                if (!string.IsNullOrEmpty(Id))
                {
                    var comp = context.CRM_SaleQuotation.Where(x => x.QuoteId == Id).FirstOrDefault();
                    context.CRM_SaleQuotation.Remove(comp);
                    context.SaveChanges();
                    flgCompany = true;
                }
            }
            return flgCompany;
        }
    }
}
