using ERPStandard.DbEntities;
using ERPStandard.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPStandard.Services
{
    public class BranchService
    {
        #region "Singleton"

        public static BranchService Instance
        {
            get
            {
                if (instance == null) instance = new BranchService();
                return instance;
            }
        }
        private static BranchService instance { get; set; }

        private BranchService()
        {

        }
        #endregion
        public BranchViewModel All(int page, int pageSize = 10, string dtSearch = "", int clmNameOrder = 0)
        {
            var viewModel = new BranchViewModel();
            using (var context = new SairaIndEntities())
            {
                var comp = context.Branches.Where(x => x.BranchName.Contains(dtSearch)
                        || x.Dscr.Contains(dtSearch)
                        || x.BranchAddress.Contains(dtSearch)
                        );

                int totalpage = comp.Select(x => x.CompNo).Count();
                var pager = new Pager(totalpage, page, pageSize);
                if (clmNameOrder == 1)
                {
                    comp = comp.OrderBy(x => x.BranchName);
                }
                else if (clmNameOrder == 2)
                {
                    comp = comp.OrderBy(x => x.Dscr);
                }
                else if (clmNameOrder == 3)
                {
                    comp = comp.OrderBy(x => x.BranchAddress);
                }
                else if (clmNameOrder == 4)
                {
                    comp = comp.OrderBy(x => x.AcntId);
                }
                else if (clmNameOrder == 5)
                {
                    comp = comp.OrderBy(x => x.CompNo);
                }
                else
                {
                    comp = comp.OrderBy(x => x.Status);
                }

                viewModel.Branches = comp.Skip((pager.CurrentPage - 1) * pager.PageSize).Take(pager.PageSize).ToList();
                viewModel.dtSearch = dtSearch;
                viewModel.clmNameOrder = clmNameOrder;
                viewModel.Pager = pager;
            }
            return viewModel;
        }
        public BranchViewModel Report(string dtSearch = "", int clmNameOrder = 0)
        {
            var viewModel = new BranchViewModel();
            using (var context = new SairaIndEntities())
            {
                var comp = context.Branches.Where(x => x.BranchName.Contains(dtSearch)
                        || x.Dscr.Contains(dtSearch)
                        || x.BranchAddress.Contains(dtSearch)
                        );

                int totalpage = comp.Select(x => x.CompNo).Count();
                if (clmNameOrder == 1)
                {
                    comp = comp.OrderBy(x => x.BranchName);
                }
                else if (clmNameOrder == 2)
                {
                    comp = comp.OrderBy(x => x.Dscr);
                }
                else if (clmNameOrder == 3)
                {
                    comp = comp.OrderBy(x => x.BranchAddress);
                }
                else if (clmNameOrder == 4)
                {
                    comp = comp.OrderBy(x => x.AcntId);
                }
                else if (clmNameOrder == 5)
                {
                    comp = comp.OrderBy(x => x.CompNo);
                }
                else
                {
                    comp = comp.OrderBy(x => x.Status);
                }
                viewModel.Branches = comp.ToList();
                viewModel.dtSearch = dtSearch;
                viewModel.clmNameOrder = clmNameOrder;
            }
            return viewModel;
        }
        public Branch Single(int Id)
        {
            var viewModel = new Branch();
            if (Id > 0)
            {
                using (var context = new SairaIndEntities())
                {
                    viewModel = context.Branches.Where(x => x.Status == Id).FirstOrDefault();
                }
            }
            return viewModel;
        }
        public int Add(Branch branch)
        {
            int compno = 0;
            using (var context = new SairaIndEntities())
            {
                compno = context.Branches.Select(x => x.Status).Max() + 1;
                branch.Status = compno;
                branch.DeletionID = 0;
                branch.LahTransferId = 0;
                branch.SaveDate = DateTime.Now;
                context.Branches.Add(branch);
                context.SaveChanges();
            }
            return compno;
        }
        public bool Update(Branch branch)
        {
            var brn = Single(branch.Status);
            brn.CompNo = branch.CompNo;
            brn.Dscr = branch.Dscr;
            brn.BranchName = branch.BranchName;
            brn.BranchAddress = branch.BranchAddress;
            brn.AcntId = branch.AcntId;

            bool flgCompany = false;
            using (var context = new SairaIndEntities())
            {
                context.Entry(brn).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
                flgCompany = true;
            }
            return flgCompany;
        }
        public bool Delete(int Id)
        {
            bool flgCompany = false;
            using (var context = new SairaIndEntities())
            {
                if (Id > 0)
                {
                    var comp = context.Branches.Where(x => x.Status == Id).FirstOrDefault();
                    context.Branches.Remove(comp);
                    context.SaveChanges();
                    flgCompany = true;
                }
            }
            return flgCompany;
        }
    }
}
