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
    public class SupplierService
    {
        #region "Singleton"

        public static SupplierService Instance
        {
            get
            {
                if (instance == null) instance = new SupplierService();
                return instance;
            }
        }
        private static SupplierService instance { get; set; }

        private SupplierService()
        {

        }
        #endregion
        public SupplierViewModel All(int page, int pageSize = 10, string dtSearch = "", int clmNameOrder = 0, int SupplierType = 1)
        {
            var viewModel = new SupplierViewModel();
            using (var context = new SairaIndEntities())
            {
                var comp = context.LocalSuppliers.Where(x => x.Name.Contains(dtSearch)
                        || x.Address.Contains(dtSearch)
                        || x.Phone1.Contains(dtSearch)
                        || x.Phone2.Contains(dtSearch)
                        || x.Email.Contains(dtSearch)
                        || x.WebPage.Contains(dtSearch)
                        || x.SupplierType == SupplierType
                        );

                int totalpage = comp.Select(x => x.LocalSupplierNo).Count();
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

                viewModel.Suppliers = comp.Skip((pager.CurrentPage - 1) * pager.PageSize).Take(pager.PageSize).ToList();
                viewModel.dtSearch = dtSearch;
                viewModel.clmNameOrder = clmNameOrder;
                viewModel.Pager = pager;
            }
            return viewModel;
        }
        public SupplierViewModel Report(string dtSearch = "", int clmNameOrder = 0)
        {
            var viewModel = new SupplierViewModel();
            using (var context = new SairaIndEntities())
            {
                var comp = context.LocalSuppliers.Where(x => x.Name.Contains(dtSearch)
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
                viewModel.Suppliers = comp.Where(x=> x.CompNo == StandardVariables.CompNo && x.BranchNo == StandardVariables.BranchNo).ToList();
                viewModel.dtSearch = dtSearch;
                viewModel.clmNameOrder = clmNameOrder;
            }
            return viewModel;
        }

        public List<SupplierListViewModel> All_List(string dtSearch = "", int clmNameOrder = 0, int? SupplierType = null)
        {
            var viewModel = new List<SupplierListViewModel>();
            using (var context = new SairaIndEntities())
            {
                var comp = context.LocalSuppliers.Where(x => x.Name.Contains(dtSearch)
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
                    SupplierListViewModel Supplier = new SupplierListViewModel();
                    Supplier.SupplierNo = item.LocalSupplierNo;
                    Supplier.Name = item.Name;
                    viewModel.Add(Supplier);
                }
            }
            return viewModel;
        }


        public LocalSupplier Single(string Id)
        {
            var viewModel = new LocalSupplier();
            if (!string.IsNullOrEmpty(Id))
            {
                using (var context = new SairaIndEntities())
                {
                    viewModel = context.LocalSuppliers.Where(x => x.LocalSupplierNo == Id).FirstOrDefault();
                }
            }
            return viewModel;
        }
        public int Add(LocalSupplier Supplier)
        {
            int compno = 0;
            using (var context = new SairaIndEntities())
            {
                compno = (int)context.LocalSuppliers.Select(x => x.SupplierNum).Max() + 1;
                Supplier.SupplierNum = compno;
                Supplier.LocalSupplierNo = Supplier.SupplierNum.ToString().PadLeft(4,'0') + '-' + StandardVariables.BLetter;
                Supplier.DeletionID = 0;
                Supplier.CompNo = StandardVariables.CompNo;
                Supplier.BranchNo = StandardVariables.BranchNo;
                Supplier.LahTransferId = 0;
                Supplier.SaveDate = DateTime.Now;
                context.LocalSuppliers.Add(Supplier);
                context.SaveChanges();
            }
            return compno;
        }
        public bool Update(LocalSupplier Supplier)
        {
            var brn = Single(Supplier.LocalSupplierNo);

            Supplier.CompNo = brn.CompNo;
            Supplier.BranchNo = brn.BranchNo;
            Supplier.LahTransferId = brn.LahTransferId;
            Supplier.DeletionID = brn.DeletionID;
            Supplier.SaveDate = brn.SaveDate;
            //Supplier.SupplierType = brn.SupplierType;

            bool flgCompany = false;
            using (var context = new SairaIndEntities())
            {
                context.Entry(Supplier).State = System.Data.Entity.EntityState.Modified;
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
                    var comp = context.LocalSuppliers.Where(x => x.LocalSupplierNo == Id).FirstOrDefault();
                    context.LocalSuppliers.Remove(comp);
                    context.SaveChanges();
                    flgCompany = true;
                }
            }
            return flgCompany;
        }
    }
}
    