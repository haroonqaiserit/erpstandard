using ERPStandard.DbEntities;
using ERPStandard.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPStandard.Services
{
    public class CustomerService
    {
        #region "Singleton"

        public static CustomerService Instance
        {
            get
            {
                if (instance == null) instance = new CustomerService();
                return instance;
            }
        }
        private static CustomerService instance { get; set; }

        private CustomerService()
        {

        }
        #endregion
        public CustomerViewModel All(int page, int pageSize = 10, string dtSearch = "", int clmNameOrder = 0)
        {
            var viewModel = new CustomerViewModel();
            using (var context = new SairaIndEntities())
            {
                var comp = context.Customers.Where(x => x.CustomerName.Contains(dtSearch)
                        || x.Dscr.Contains(dtSearch)
                        || x.CustomerAddress.Contains(dtSearch)
                        );

                int totalpage = comp.Select(x => x.CompNo).Count();
                var pager = new Pager(totalpage, page, pageSize);
                if (clmNameOrder == 1)
                {
                    comp = comp.OrderBy(x => x.CustomerName);
                }
                else if (clmNameOrder == 2)
                {
                    comp = comp.OrderBy(x => x.Dscr);
                }
                else if (clmNameOrder == 3)
                {
                    comp = comp.OrderBy(x => x.CustomerAddress);
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

                viewModel.Customers = comp.Skip((pager.CurrentPage - 1) * pager.PageSize).Take(pager.PageSize).ToList();
                viewModel.dtSearch = dtSearch;
                viewModel.clmNameOrder = clmNameOrder;
                viewModel.Pager = pager;
            }
            return viewModel;
        }
        public CustomerViewModel Report(string dtSearch = "", int clmNameOrder = 0)
        {
            var viewModel = new CustomerViewModel();
            using (var context = new SairaIndEntities())
            {
                var comp = context.Customers.Where(x => x.CustomerName.Contains(dtSearch)
                        || x.Dscr.Contains(dtSearch)
                        || x.CustomerAddress.Contains(dtSearch)
                        );

                int totalpage = comp.Select(x => x.CompNo).Count();
                if (clmNameOrder == 1)
                {
                    comp = comp.OrderBy(x => x.CustomerName);
                }
                else if (clmNameOrder == 2)
                {
                    comp = comp.OrderBy(x => x.Dscr);
                }
                else if (clmNameOrder == 3)
                {
                    comp = comp.OrderBy(x => x.CustomerAddress);
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
                viewModel.Customers = comp.ToList();
                viewModel.dtSearch = dtSearch;
                viewModel.clmNameOrder = clmNameOrder;
            }
            return viewModel;
        }
        public Customer Single(string Id)
        {
            var viewModel = new Customer();
            if (!string.IsNullOrEmpty(Id))
            {
                using (var context = new SairaIndEntities())
                {
                    viewModel = context.Customers.Where(x => x.CustomerNo == Id).FirstOrDefault();
                }
            }
            return viewModel;
        }
        public int Add(Customer Customer)
        {
            int compno = 0;
            using (var context = new SairaIndEntities())
            {
                compno = context.Customers.Select(x => x.CustNum).Max() + 1;
                Customer.CustNum = compno;
                Customer.CustomerNo = compno;
                Customer.DeletionID = 0;
                Customer.LahTransferId = 0;
                Customer.SaveDate = DateTime.Now;
                context.Customers.Add(Customer);
                context.SaveChanges();
            }
            return compno;
        }
        public bool Update(Customer Customer)
        {
            var brn = Single(Customer.CustomerNo);
            brn.CompNo = Customer.CompNo;
            brn.Dscr = Customer.Dscr;
            brn.CustomerName = Customer.CustomerName;
            brn.CustomerAddress = Customer.CustomerAddress;
            brn.AcntId = Customer.AcntId;

            bool flgCompany = false;
            using (var context = new SairaIndEntities())
            {
                context.Entry(brn).State = System.Data.Entity.EntityState.Modified;
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
                    var comp = context.Customers.Where(x => x.CustomerNo == Id).FirstOrDefault();
                    context.Customers.Remove(comp);
                    context.SaveChanges();
                    flgCompany = true;
                }
            }
            return flgCompany;
        }
    }
}
    