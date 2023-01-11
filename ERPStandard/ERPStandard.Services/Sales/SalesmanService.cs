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
    public class SalesmanService
    {
        #region "Singleton"

        public static SalesmanService Instance
        {
            get
            {
                if (instance == null) instance = new SalesmanService();
                return instance;
            }
        }
        private static SalesmanService instance { get; set; }

        private SalesmanService()
        {

        }
        #endregion
        public SalesManViewModel All(int page, int pageSize = 10, string dtSearch = "", int clmNameOrder = 0, int SalesmanType = 1)
        {
            var viewModel = new SalesManViewModel();
            using (var context = new SairaIndEntities())
            {
                var comp = context.SalesMen.Where(x => x.Name.Contains(dtSearch)
                        || x.Address.Contains(dtSearch)
                        || x.Phone1.Contains(dtSearch)
                        || x.Phone2.Contains(dtSearch)
                        || x.Email.Contains(dtSearch)
                        || x.WebPage.Contains(dtSearch)
                        );

                int totalpage = comp.Select(x => x.SalesManId).Count();
                var pager = new Pager(totalpage, page, pageSize);
                if (clmNameOrder == 1)
                {
                    comp = comp.OrderBy(x => x.Name);
                }
                else if (clmNameOrder == 2)
                {
                    comp = comp.OrderBy(x => x.Address);
                }
                else if (clmNameOrder == 3)
                {
                    comp = comp.OrderBy(x => x.Phone1);
                }
                else
                {
                    comp = comp.OrderBy(x => x.Name);
                }

                viewModel.Salesman = comp.Skip((pager.CurrentPage - 1) * pager.PageSize).Take(pager.PageSize).ToList();
                viewModel.dtSearch = dtSearch;
                viewModel.clmNameOrder = clmNameOrder;
                viewModel.Pager = pager;
            }
            return viewModel;
        }
        public SalesManViewModel Report(string dtSearch = "", int clmNameOrder = 0)
        {
            var viewModel = new SalesManViewModel();
            using (var context = new SairaIndEntities())
            {
                var comp = context.SalesMen.Where(x => x.Name.Contains(dtSearch)
                        || x.Address.Contains(dtSearch)
                        || x.Phone1.Contains(dtSearch)
                        || x.Phone2.Contains(dtSearch)
                        || x.Email.Contains(dtSearch)
                        || x.WebPage.Contains(dtSearch)
                        );

                if (clmNameOrder == 1)
                {
                    comp = comp.OrderBy(x => x.Name);
                }
                else if (clmNameOrder == 2)
                {
                    comp = comp.OrderBy(x => x.Address);
                }
                else if (clmNameOrder == 3)
                {
                    comp = comp.OrderBy(x => x.Phone1);
                }
                else
                {
                    comp = comp.OrderBy(x => x.Name);
                }

                viewModel.Salesman = comp.Where(x=> x.CompNo == StandardVariables.CompNo && x.BranchNo == StandardVariables.BranchNo).ToList();
                viewModel.dtSearch = dtSearch;
                viewModel.clmNameOrder = clmNameOrder;
            }
            return viewModel;
        }

        public List<SalesMan> All_List(string dtSearch = "", int clmNameOrder = 0, int? SalesmanType = null)
        {
            var viewModel = new List<SalesMan>();
            using (var context = new SairaIndEntities())
            {
                var comp = context.SalesMen.Where(x => x.Name.Contains(dtSearch)
                        || x.Address.Contains(dtSearch)
                        || x.Phone1.Contains(dtSearch)
                        || x.Phone2.Contains(dtSearch)
                        || x.Email.Contains(dtSearch)
                        || x.WebPage.Contains(dtSearch)
                        );

                if (clmNameOrder == 1)
                {
                    comp = comp.OrderBy(x => x.Name);
                }
                else if (clmNameOrder == 2)
                {
                    comp = comp.OrderBy(x => x.Address);
                }
                else if (clmNameOrder == 3)
                {
                    comp = comp.OrderBy(x => x.Phone1);
                }
                else
                {
                    comp = comp.OrderBy(x => x.Name);
                }

                viewModel = comp.Where(x => x.CompNo == StandardVariables.CompNo && x.BranchNo == StandardVariables.BranchNo).ToList();
            }
            return viewModel;
        }


        public SalesMan Single(string Id)
        {
            var viewModel = new SalesMan();
            if (!string.IsNullOrEmpty(Id))
            {
                using (var context = new SairaIndEntities())
                {
                    viewModel = context.SalesMen.Where(x => x.SalesManId == Id).FirstOrDefault();
                }
            }
            return viewModel;
        }
        public int Add(SalesMan Salesman)
        {
            int compno = 0;
            using (var context = new SairaIndEntities())
            {
                compno = context.SalesMen.Select(x => x.SalesManNum).Max() + 1;
                Salesman.SalesManNum = compno;
                Salesman.SalesManId = Salesman.SalesManNum.ToString().PadLeft(4,'0') + '-' + StandardVariables.BLetter;
                Salesman.DeletionID = 0;
                Salesman.CompNo = StandardVariables.CompNo;
                Salesman.BranchNo = StandardVariables.BranchNo;
                Salesman.LahTransferId = 0;
                Salesman.SaveDate = DateTime.Now;
                context.SalesMen.Add(Salesman);
                context.SaveChanges();
            }
            return compno;
        }
        public bool Update(SalesMan Salesman)
        {
            var brn = Single(Salesman.SalesManId);

            Salesman.CompNo = brn.CompNo;
            Salesman.BranchNo = brn.BranchNo;
            Salesman.LahTransferId = brn.LahTransferId;
            Salesman.DeletionID = brn.DeletionID;
            Salesman.SaveDate = brn.SaveDate;
            //Salesman.SalesmanType = brn.SalesmanType;

            bool flgCompany = false;
            using (var context = new SairaIndEntities())
            {
                context.Entry(Salesman).State = System.Data.Entity.EntityState.Modified;
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
                    var comp = context.SalesMen.Where(x => x.SalesManId == Id).FirstOrDefault();
                    context.SalesMen.Remove(comp);
                    context.SaveChanges();
                    flgCompany = true;
                }
            }
            return flgCompany;
        }
    }
}
    