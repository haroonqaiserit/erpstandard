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
        public CustomerViewModel All(int page, int pageSize = 10, string dtSearch = "", int clmNameOrder = 0, int CustomerType = 1)
        {
            var viewModel = new CustomerViewModel();
            using (var context = new SairaIndEntities())
            {
                var comp = context.Customers.Where(x => x.Name.Contains(dtSearch)
                        || x.Address.Contains(dtSearch)
                        || x.Phone1.Contains(dtSearch)
                        || x.Phone2.Contains(dtSearch)
                        || x.Email.Contains(dtSearch)
                        || x.WebPage.Contains(dtSearch)
                        || x.CustomerType == CustomerType
                        );

                int totalpage = comp.Select(x => x.CustomerNo).Count();
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
                else if (clmNameOrder == 4)
                {
                    comp = comp.OrderBy(x => x.AcntId);
                }
                else if (clmNameOrder == 5)
                {
                    comp = comp.OrderBy(x => x.Registered);
                }
                else
                {
                    comp = comp.OrderBy(x => x.Name);
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
                var comp = context.Customers.Where(x => x.Name.Contains(dtSearch)
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
                else if (clmNameOrder == 4)
                {
                    comp = comp.OrderBy(x => x.AcntId);
                }
                else if (clmNameOrder == 5)
                {
                    comp = comp.OrderBy(x => x.Registered);
                }
                else
                {
                    comp = comp.OrderBy(x => x.Name);
                }
                viewModel.Customers = comp.Where(x=> x.CompNo == StandardVariables.CompNo && x.BranchNo == StandardVariables.BranchNo).ToList();
                viewModel.dtSearch = dtSearch;
                viewModel.clmNameOrder = clmNameOrder;
            }
            return viewModel;
        }

        public List<CustomerListViewModel> All_List(string dtSearch = "", int clmNameOrder = 0, int? CustomerType = null)
        {
            var viewModel = new List<CustomerListViewModel>();
            using (var context = new SairaIndEntities())
            {
                var comp = context.Customers.Where(x => x.Name.Contains(dtSearch)
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
                else if (clmNameOrder == 4)
                {
                    comp = comp.OrderBy(x => x.AcntId);
                }
                else if (clmNameOrder == 5)
                {
                    comp = comp.OrderBy(x => x.Registered);
                }
                else
                {
                    comp = comp.OrderBy(x => x.Name);
                }
                var viewModel1= comp.Where(x => x.CompNo == StandardVariables.CompNo && x.BranchNo == StandardVariables.BranchNo).ToList();

                foreach (var item in viewModel1)
                {
                    CustomerListViewModel customer = new CustomerListViewModel();
                    customer.CustomerNo = item.CustomerNo;
                    customer.Name = item.Name;
                    viewModel.Add(customer);
                }
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
                Customer.CustomerNo = Customer.CustNum.ToString().PadLeft(4,'0') + '-' + StandardVariables.BLetter;
                Customer.DeletionID = 0;
                Customer.CompNo = StandardVariables.CompNo;
                Customer.BranchNo = StandardVariables.BranchNo;
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

            Customer.CompNo = brn.CompNo;
            Customer.BranchNo = brn.BranchNo;
            Customer.LahTransferId = brn.LahTransferId;
            Customer.DeletionID = brn.DeletionID;
            Customer.SaveDate = brn.SaveDate;
            //Customer.CustomerType = brn.CustomerType;

            bool flgCompany = false;
            using (var context = new SairaIndEntities())
            {
                context.Entry(Customer).State = System.Data.Entity.EntityState.Modified;
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
    