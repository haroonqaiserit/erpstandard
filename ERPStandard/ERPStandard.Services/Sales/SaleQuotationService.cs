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
        public int Add(CRM_SaleQuotation SaleQuotation, List<CRM_SaleQuotationDetail> SaleQuotationDetail)
        {
            int savechanges = 0;
            using (var context = new SairaIndEntities())
            {
                int compno = (int)context.CRM_SaleQuotation.Select(x => x.QuoteNo).Max() + 1;
                SaleQuotation.QuoteNo = compno;
                SaleQuotation.QuoteId = SaleQuotation.QuoteNo.ToString().PadLeft(4, '0') + '-' + StandardVariables.BLetter; ;
                SaleQuotation.DeletionID = 0;
                SaleQuotation.LahTransferId = 0;
                SaleQuotation.SaveDate = DateTime.Now;
                SaleQuotation.CompNo = GlobalVariables.CompNo;
                SaleQuotation.BranchNo = GlobalVariables.BranchNo;
                CRM_SaleQuotationDetail saledetail = new CRM_SaleQuotationDetail();
                foreach (var item in SaleQuotationDetail)
                {
                    item.QuoteId = SaleQuotation.QuoteId;
                    item.DeletionID = 0;
                    item.LahTransferId = 0;
                    item.SaveDate = DateTime.Now;
                    item.CompNo = SaleQuotation.CompNo;
                    item.BranchNo = SaleQuotation.BranchNo;
                }
                
                context.CRM_SaleQuotation.Add(SaleQuotation);
                context.CRM_SaleQuotationDetail.AddRange(SaleQuotationDetail);
                savechanges = context.SaveChanges();
            }
            return savechanges;
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
