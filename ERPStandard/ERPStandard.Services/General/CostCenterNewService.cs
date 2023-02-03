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
    public class CostCenterNewService
    {
        #region "Singleton"

        public static CostCenterNewService Instance
        {
            get
            {
                if (instance == null) instance = new CostCenterNewService();
                return instance;
            }
        }
        private static CostCenterNewService instance { get; set; }

        private CostCenterNewService()
        {

        }
        #endregion
        public CostCenterViewModel All(int page, int pageSize = 10, string dtSearch = "", int clmNameOrder = 0)
        {
            var viewModel = new CostCenterViewModel();
            using (var context = new SairaIndEntities())
            {
                var comp = context.CostCenterNews.Where(x => x.CostCenterName.Contains(dtSearch)
                        );

                int totalpage = comp.Select(x => x.CompNo).Count();
                var pager = new Pager(totalpage, page, pageSize);
                if (clmNameOrder == 1)
                {
                    comp = comp.OrderBy(x => x.CostCenterName);
                }
                else
                {
                    comp = comp.OrderBy(x => x.CostCenterId);
                }

                viewModel.CostCenters = comp.Skip((pager.CurrentPage - 1) * pager.PageSize).Take(pager.PageSize).ToList();
                viewModel.dtSearch = dtSearch;
                viewModel.clmNameOrder = clmNameOrder;
                viewModel.Pager = pager;
            }
            return viewModel;
        }
        public CostCenterViewModel Report(string dtSearch = "", int clmNameOrder = 0)
        {
            var viewModel = new CostCenterViewModel();
            using (var context = new SairaIndEntities())
            {
                var comp = context.CostCenterNews.Where(x => x.CostCenterName.Contains(dtSearch)
                        );

                int totalpage = comp.Select(x => x.CompNo).Count();
                if (clmNameOrder == 1)
                {
                    comp = comp.OrderBy(x => x.CostCenterName);
                }
                else
                {
                    comp = comp.OrderBy(x => x.CostCenterName);
                }
                viewModel.CostCenters = comp.ToList();
                viewModel.dtSearch = dtSearch;
                viewModel.clmNameOrder = clmNameOrder;
            }
            return viewModel;
        }

        public List<CostCenterListViewModel> All_List(string dtSearch = "", int clmNameOrder = 0)
        {
            var viewModel = new List<CostCenterListViewModel>();
            using (var context = new SairaIndEntities())
            {
                var comp = context.CostCenterNews.Where(x => x.CostCenterName.Contains(dtSearch)
                        );

                if (clmNameOrder == 1)
                {
                    comp = comp.OrderBy(x => x.CostCenterName);
                }
                else
                {
                    comp = comp.OrderBy(x => x.CostCenterId);
                }
                var viewModel1 = comp.Where(x => x.CompNo == StandardVariables.CompNo && x.BranchNo == StandardVariables.BranchNo).ToList();

                foreach (var item in viewModel1)
                {
                    CostCenterListViewModel lv = new CostCenterListViewModel();
                    lv.CostCenterId = item.CostCenterId;
                    lv.Name = item.CostCenterName;
                    viewModel.Add(lv);
                }
            }
            return viewModel;
        }

        public CostCenterNew Single(string Id)
        {
            var viewModel = new CostCenterNew();
            if (!string.IsNullOrEmpty(Id))
            {
                using (var context = new SairaIndEntities())
                {
                    viewModel = context.CostCenterNews.Where(x => x.CostCenterId == Id).FirstOrDefault();
                }
            }
            return viewModel;
        }
        public int Add(CostCenterNew StoreUnit)
        {
            int compno = 0;
            //using (var context = new SairaIndEntities())
            //{
            //    compno = context.CostCenterNews.Select(x => x.StoreUnitNo).Max() + 1;
            //    StoreUnit.CostCenterId = compno.ToString().PadLeft(2) + StandardVariables.BLetter;
            //    StoreUnit.DeletionID = 0;
            //    StoreUnit.SaveDate = DateTime.Now;
            //    context.CostCenterNews.Add(StoreUnit);
            //    context.SaveChanges();
            //}
            return compno;
        }
        public bool Update(CostCenterNew StoreUnit)
        {
            bool flgCompany = false;
            //var brn = Single(StoreUnit.CostCenterId);
            //StoreUnit.StoreUnitNo = brn.StoreUnitNo;
            //StoreUnit.SaveDate = brn.SaveDate;
            //StoreUnit.DeletionID = brn.DeletionID;
            //using (var context = new SairaIndEntities())
            //{
            //    context.Entry(StoreUnit).State = System.Data.Entity.EntityState.Modified;
            //    context.SaveChanges();
            //    flgCompany = true;
            //}
            return flgCompany;
        }
        public bool Delete(string Id)
        {
            bool flgCompany = false;
            using (var context = new SairaIndEntities())
            {
                if (!string.IsNullOrEmpty(Id))
                {
                    var comp = context.CostCenterNews.Where(x => x.CostCenterId == Id).FirstOrDefault();
                    context.CostCenterNews.Remove(comp);
                    context.SaveChanges();
                    flgCompany = true;
                }
            }
            return flgCompany;
        }
    }
}
