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
    public class StoreUnitService
    {
        #region "Singleton"

        public static StoreUnitService Instance
        {
            get
            {
                if (instance == null) instance = new StoreUnitService();
                return instance;
            }
        }
        private static StoreUnitService instance { get; set; }

        private StoreUnitService()
        {

        }
        #endregion
        public StoreUnitViewModel All(int page, int pageSize = 10, string dtSearch = "", int clmNameOrder = 0)
        {
            var viewModel = new StoreUnitViewModel();
            using (var context = new SairaIndEntities())
            {
                var comp = context.tblStoreUnits.Where(x => x.UnitName.Contains(dtSearch)
                        );

                int totalpage = comp.Select(x => x.CompNo).Count();
                var pager = new Pager(totalpage, page, pageSize);
                if (clmNameOrder == 1)
                {
                    comp = comp.OrderBy(x => x.UnitName);
                }
                else
                {
                    comp = comp.OrderBy(x => x.StoreUnitNo);
                }

                viewModel.StoreUnits = comp.Skip((pager.CurrentPage - 1) * pager.PageSize).Take(pager.PageSize).ToList();
                viewModel.dtSearch = dtSearch;
                viewModel.clmNameOrder = clmNameOrder;
                viewModel.Pager = pager;
            }
            return viewModel;
        }
        public StoreUnitViewModel Report(string dtSearch = "", int clmNameOrder = 0)
        {
            var viewModel = new StoreUnitViewModel();
            using (var context = new SairaIndEntities())
            {
                var comp = context.tblStoreUnits.Where(x => x.UnitName.Contains(dtSearch)
                        );

                int totalpage = comp.Select(x => x.CompNo).Count();
                if (clmNameOrder == 1)
                {
                    comp = comp.OrderBy(x => x.UnitName);
                }
                else
                {
                    comp = comp.OrderBy(x => x.UnitName);
                }
                viewModel.StoreUnits = comp.ToList();
                viewModel.dtSearch = dtSearch;
                viewModel.clmNameOrder = clmNameOrder;
            }
            return viewModel;
        }

        public List<StoreUnitListViewModel> All_List(string dtSearch = "", int clmNameOrder = 0)
        {
            var viewModel = new List<StoreUnitListViewModel>();
            using (var context = new SairaIndEntities())
            {
                var comp = context.tblStoreUnits.Where(x => x.UnitName.Contains(dtSearch)
                        );

                if (clmNameOrder == 1)
                {
                    comp = comp.OrderBy(x => x.UnitName);
                }
                else
                {
                    comp = comp.OrderBy(x => x.StoreUnitNo);
                }
                var viewModel1 = comp.Where(x => x.CompNo == StandardVariables.CompNo && x.BranchNo == StandardVariables.BranchNo).ToList();

                foreach (var item in viewModel1)
                {
                    StoreUnitListViewModel storeunit = new StoreUnitListViewModel();
                    storeunit.StoreUnitId = item.StoreUnitId;
                    storeunit.Name = item.UnitName;
                    viewModel.Add(storeunit);
                }
            }
            return viewModel;
        }

        public tblStoreUnit Single(string Id)
        {
            var viewModel = new tblStoreUnit();
            if (!string.IsNullOrEmpty(Id))
            {
                using (var context = new SairaIndEntities())
                {
                    viewModel = context.tblStoreUnits.Where(x => x.StoreUnitId == Id).FirstOrDefault();
                }
            }
            return viewModel;
        }
        public int Add(tblStoreUnit StoreUnit)
        {
            int compno = 0;
            using (var context = new SairaIndEntities())
            {
                compno = context.tblStoreUnits.Select(x => x.StoreUnitNo).Max() + 1;
                StoreUnit.StoreUnitId = compno.ToString().PadLeft(2) + StandardVariables.BLetter;
                StoreUnit.DeletionID = 0;
                StoreUnit.SaveDate = DateTime.Now;
                context.tblStoreUnits.Add(StoreUnit);
                context.SaveChanges();
            }
            return compno;
        }
        public bool Update(tblStoreUnit StoreUnit)
        {
            var brn = Single(StoreUnit.StoreUnitId);
            StoreUnit.StoreUnitNo = brn.StoreUnitNo;
            StoreUnit.SaveDate = brn.SaveDate;
            StoreUnit.DeletionID = brn.DeletionID;
            bool flgCompany = false;
            using (var context = new SairaIndEntities())
            {
                context.Entry(StoreUnit).State = System.Data.Entity.EntityState.Modified;
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
                    var comp = context.tblStoreUnits.Where(x => x.StoreUnitId == Id).FirstOrDefault();
                    context.tblStoreUnits.Remove(comp);
                    context.SaveChanges();
                    flgCompany = true;
                }
            }
            return flgCompany;
        }
    }
}
