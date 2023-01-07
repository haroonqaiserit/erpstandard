using ERPStandard.DbEntities;
using ERPStandard.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPStandard.Services
{
    public class ChartofAccountsService
    {
        #region "Singleton"

        public static ChartofAccountsService Instance
        {
            get
            {
                if (instance == null) instance = new ChartofAccountsService();
                return instance;
            }
        }
        private static ChartofAccountsService instance { get; set; }

        private ChartofAccountsService()
        {

        }
        #endregion
        public ChartOfAccountViewModel All(int page, int pageSize = 10, string dtSearch = "", int clmNameOrder = 0)
        {

            var viewModel = new ChartOfAccountViewModel();
            using (var context = new SairaIndEntities())
            {
                var comp = context.AccountsBackUps.Where(x => x.Dscr.Contains(dtSearch)
                        || x.GAsstDscr.Contains(dtSearch)
                        || x.SGADscr.Contains(dtSearch)
                        || x.SubADscr.Contains(dtSearch)
                        || x.USubDscr.Contains(dtSearch)
                        );

                int totalpage = comp.Select(x => x.CompNo).Count();
                var pager = new Pager(totalpage, page, pageSize);
                if (clmNameOrder == 1)
                {
                    comp = comp.OrderBy(x => x.Dscr);
                }
                else if (clmNameOrder == 2)
                {
                    comp = comp.OrderBy(x => x.GAsstDscr);
                }
                else if (clmNameOrder == 3)
                {
                    comp = comp.OrderBy(x => x.SGADscr);
                }
                else if (clmNameOrder == 4)
                {
                    comp = comp.OrderBy(x => x.SubADscr);
                }
                else if (clmNameOrder == 5)
                {
                    comp = comp.OrderBy(x => x.USubDscr);
                }
                else
                {
                    comp = comp.OrderBy(x => x.AcntId);
                }

                viewModel.COA = comp.Skip((pager.CurrentPage - 1) * pager.PageSize).Take(pager.PageSize).ToList();
                viewModel.dtSearch = dtSearch;
                viewModel.clmNameOrder = clmNameOrder;
                viewModel.Pager = pager;
            }
            return viewModel;
        }
        public ChartOfAccountViewModel Report(string dtSearch = "", int clmNameOrder = 0)
        {
            var viewModel = new ChartOfAccountViewModel();
            using (var context = new SairaIndEntities())
            {
                var comp = context.AccountsBackUps.Where(x => x.Dscr.Contains(dtSearch)
                        || x.GAsstDscr.Contains(dtSearch)
                        || x.SGADscr.Contains(dtSearch)
                        || x.SubADscr.Contains(dtSearch)
                        || x.USubDscr.Contains(dtSearch)
                        );

                int totalpage = comp.Select(x => x.AcntId).Count();
                if (clmNameOrder == 1)
                {
                    comp = comp.OrderBy(x => x.Dscr);
                }
                else if (clmNameOrder == 2)
                {
                    comp = comp.OrderBy(x => x.GAsstDscr);
                }
                else if (clmNameOrder == 3)
                {
                    comp = comp.OrderBy(x => x.SGADscr);
                }
                else if (clmNameOrder == 4)
                {
                    comp = comp.OrderBy(x => x.SubADscr);
                }
                else if (clmNameOrder == 5)
                {
                    comp = comp.OrderBy(x => x.USubDscr);
                }
                else
                {
                    comp = comp.OrderBy(x => x.AcntId);
                }

                var accoun= comp.Select(x=> new { x.AcntId, x.Dscr}).ToList();
                viewModel.dtSearch = dtSearch;
                viewModel.clmNameOrder = clmNameOrder;
            }
            return viewModel;
        }

        public ChartOfAccountViewModel coaDropDown(string dtSearch = "", int clmNameOrder = 0)
        {
            var viewModel = new ChartOfAccountViewModel();
            using (var context = new SairaIndEntities())
            {
                var comp = context.AccountsBackUps.Where(x => x.Dscr.Contains(dtSearch)
                        || x.GAsstDscr.Contains(dtSearch)
                        || x.SGADscr.Contains(dtSearch)
                        || x.SubADscr.Contains(dtSearch)
                        || x.USubDscr.Contains(dtSearch)
                        );

                int totalpage = comp.Select(x => x.AcntId).Count();
                if (clmNameOrder == 1)
                {
                    comp = comp.OrderBy(x => x.Dscr);
                }
                else if (clmNameOrder == 2)
                {
                    comp = comp.OrderBy(x => x.GAsstDscr);
                }
                else if (clmNameOrder == 3)
                {
                    comp = comp.OrderBy(x => x.SGADscr);
                }
                else if (clmNameOrder == 4)
                {
                    comp = comp.OrderBy(x => x.SubADscr);
                }
                else if (clmNameOrder == 5)
                {
                    comp = comp.OrderBy(x => x.USubDscr);
                }
                else
                {
                    comp = comp.OrderBy(x => x.AcntId);
                }

                //viewModel.COA = comp.Select(x => new { x.AcntId, x.Dscr }).ToList();
                viewModel.COA = comp.ToList();
                viewModel.dtSearch = dtSearch;
                viewModel.clmNameOrder = clmNameOrder;
            }
            return viewModel;
        }

        public AccountsBackUp Single(string Id)
        {
            var viewModel = new AccountsBackUp();
            if (!string.IsNullOrEmpty(Id))
            {
                using (var context = new SairaIndEntities())
                {
                    viewModel = context.AccountsBackUps.Where(x => x.AcntId == Id).FirstOrDefault();
                }
            }
            return viewModel;
        }
        #region block code Add/Update/Delete
        /*
        public int Add(Branch branch)
        {
            int compno = 0;
            using (var context = new SairaIndEntities())
            {
                compno = context.AccountsBackUps.Select(x => x.Status).Max() + 1;
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
        */
        #endregion
    }
}
