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
    public class tblUOMService
    {
        #region "Singleton"

        public static tblUOMService Instance
        {
            get
            {
                if (instance == null) instance = new tblUOMService();
                return instance;
            }
        }
        private static tblUOMService instance { get; set; }

        private tblUOMService()
        {

        }
        #endregion
        public tblUOMViewModel All(int page, int pageSize = 10, string dtSearch = "", int clmNameOrder = 0)
        {
            var viewModel = new tblUOMViewModel();
            using (var context = new SairaIndEntities())
            {
                var comp = context.tblUOMs.Where(x => x.Name.Contains(dtSearch)
                        );

                int totalpage = comp.Count();
                var pager = new Pager(totalpage, page, pageSize);
                if (clmNameOrder == 1)
                {
                    comp = comp.OrderBy(x => x.Name);
                }
                else if (clmNameOrder == 2)
                {
                    comp = comp.OrderBy(x => x.ConversionFactor);
                }
                else
                {
                    comp = comp.OrderBy(x => x.Name);
                }

                viewModel.UOM = comp.Skip((pager.CurrentPage - 1) * pager.PageSize).Take(pager.PageSize).ToList();
                viewModel.dtSearch = dtSearch;
                viewModel.clmNameOrder = clmNameOrder;
                viewModel.Pager = pager;
            }
            return viewModel;
        }
        public List<UOMListViewModel> All_List(string dtSearch = "", int clmNameOrder = 0)
        {
            var viewModel = new List<UOMListViewModel>();
            using (var context = new SairaIndEntities())
            {
                var comp = context.tblUOMs.Where(x => x.Name.Contains(dtSearch)
                        );

                if (clmNameOrder == 1)
                {
                    comp = comp.OrderBy(x => x.ID);
                }
                else
                {
                    comp = comp.OrderBy(x => x.ID);
                }
                var viewModel1 = comp.ToList();

                foreach (var item in viewModel1)
                {
                    UOMListViewModel storeunit = new UOMListViewModel();
                    storeunit.Id = item.ID;
                    storeunit.Name = item.Name;
                    viewModel.Add(storeunit);
                }
            }
            return viewModel;
        }

        public tblUOMViewModel Report(string dtSearch = "", int clmNameOrder = 0)
        {
            var viewModel = new tblUOMViewModel();
            using (var context = new SairaIndEntities())
            {
                var comp = context.tblUOMs.Where(x => x.Name.Contains(dtSearch)
                        );

                int totalpage = comp.Count();
                if (clmNameOrder == 1)
                {
                    comp = comp.OrderBy(x => x.Name);
                }
                else if (clmNameOrder == 2)
                {
                    comp = comp.OrderBy(x => x.ConversionFactor);
                }
                else
                {
                    comp = comp.OrderBy(x => x.Name);
                }
                viewModel.UOM = comp.ToList();
                viewModel.dtSearch = dtSearch;
                viewModel.clmNameOrder = clmNameOrder;
            }
            return viewModel;
        }
        public tblUOM Single(string Id)
        {
            var viewModel = new tblUOM();
            if (!string.IsNullOrEmpty(Id))
            {
                using (var context = new SairaIndEntities())
                {
                    viewModel = context.tblUOMs.Where(x => x.ID == Id).FirstOrDefault();
                }
            }
            return viewModel;
        }
        public int Add(tblUOM uom)
        {
            int compno = 0;
            using (var context = new SairaIndEntities())
            {
                context.tblUOMs.Add(uom);
                context.SaveChanges();
            }
            return compno;
        }
        public bool Update(tblUOM uom)
        {
            var _uom = Single(uom.ID);
            _uom.Name = uom.Name;

            bool flgCompany = false;
            using (var context = new SairaIndEntities())
            {
                context.Entry(_uom).State = System.Data.Entity.EntityState.Modified;
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
                    var comp = context.tblUOMs.Where(x => x.ID == Id).FirstOrDefault();
                    context.tblUOMs.Remove(comp);
                    context.SaveChanges();
                    flgCompany = true;
                }
            }
            return flgCompany;
        }
    }
}
