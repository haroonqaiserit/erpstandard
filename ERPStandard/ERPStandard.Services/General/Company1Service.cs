using ERPStandard.DbEntities;
using ERPStandard.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ERPStandard.Services
{
    public class Company1Service 
    {
        #region "Singleton"
        
        public static Company1Service Instance 
        { get
            {
                if (instance == null) instance = new Company1Service();
                return instance;
            }
        }
        private static Company1Service instance { get; set; }

        private Company1Service()
        {
            
        }
        #endregion
        public Company1ViewModel All(int page, int pageSize=10, string dtSearch="", int clmNameOrder=0) 
        {
            var viewModel = new Company1ViewModel();
            using (var context = new SairaIndEntities())
            {
                var comp = context.Company1.Where(x=> x.Company_Name.Contains(dtSearch) 
                        || x.company_desc.Contains(dtSearch)
                        || x.Company_address.Contains(dtSearch)
                        || x.Company_email.Contains(dtSearch)
                        || x.Company_phones.Contains(dtSearch)
                        );

                int totalpage = comp.Select(x=> x.CompNo).Count();
                var pager = new Pager(totalpage, page, pageSize);
                if (clmNameOrder == 1){
                    comp = comp.OrderBy(x => x.Company_Name);
                }
                else if (clmNameOrder == 2){
                    comp = comp.OrderBy(x => x.Company_address);
                }
                else if (clmNameOrder == 3){
                    comp = comp.OrderBy(x => x.Company_email);
                }
                else if (clmNameOrder == 4)
                {
                    comp = comp.OrderBy(x => x.Company_phones);
                }
                else if (clmNameOrder == 5)
                {
                    comp = comp.OrderBy(x => x.STaxRegNo);
                }
                else if (clmNameOrder == 6)
                {
                    comp = comp.OrderBy(x => x.NationalTaxNo);
                }
                else
                {
                    comp = comp.OrderBy(x => x.CompNo);
                }

                viewModel.Company = comp.Skip((pager.CurrentPage - 1) * pager.PageSize).Take(pager.PageSize).ToList();
                viewModel.dtSearch = dtSearch;
                viewModel.clmNameOrder = clmNameOrder;
                viewModel.Pager = pager;
            }
            return viewModel;
        }
        public Company1ViewModel Report(string dtSearch = "", int clmNameOrder = 0)
        {
            var viewModel = new Company1ViewModel();
            using (var context = new SairaIndEntities())
            {
                var comp = context.Company1.Where(x => x.Company_Name.Contains(dtSearch)
                        || x.company_desc.Contains(dtSearch)
                        || x.Company_address.Contains(dtSearch)
                        || x.Company_email.Contains(dtSearch)
                        || x.Company_phones.Contains(dtSearch)
                        );

                int totalpage = comp.Select(x => x.CompNo).Count();
                if (clmNameOrder == 1)
                {
                    comp = comp.OrderBy(x => x.Company_Name);
                }
                else if (clmNameOrder == 2)
                {
                    comp = comp.OrderBy(x => x.Company_address);
                }
                else if (clmNameOrder == 3)
                {
                    comp = comp.OrderBy(x => x.Company_email);
                }
                else if (clmNameOrder == 4)
                {
                    comp = comp.OrderBy(x => x.Company_phones);
                }
                else if (clmNameOrder == 5)
                {
                    comp = comp.OrderBy(x => x.STaxRegNo);
                }
                else if (clmNameOrder == 6)
                {
                    comp = comp.OrderBy(x => x.NationalTaxNo);
                }
                else
                {
                    comp = comp.OrderBy(x => x.CompNo);
                }
                viewModel.Company = comp.ToList();
                viewModel.dtSearch = dtSearch;
                viewModel.clmNameOrder = clmNameOrder;
            }
            return viewModel;
        }

        public List<Company1> All_List()
        {
            var viewModel = new List<Company1>();
            using (var context = new SairaIndEntities())
            {
                viewModel = context.Company1.ToList();
            }
            return viewModel;
        }

        public Company1 Single(int Id)
        {
            var viewModel = new Company1();
            if (Id > 0) {
                using (var context = new SairaIndEntities())
                {
                    viewModel = context.Company1.Where(x=> x.CompNo == Id).FirstOrDefault();
                }
            }
            return viewModel;
        }
        public int Add(Company1 company)
        {
            int compno=0;
            using (var context = new SairaIndEntities())
            {
                compno = context.Company1.Select(x => x.CompNo).Max()+1;
                company.CompNo = compno;
                company.DeletionID = 0;
                company.LahTransferId = 0;
                company.SaveDate = DateTime.Now;
                context.Company1.Add(company);
                compno = context.SaveChanges();
            }
            return compno;
        }
        public bool Update(Company1 company) 
        {
            bool flgCompany = false;
            using (var context = new SairaIndEntities())
            {
                context.Entry(company).State = System.Data.Entity.EntityState.Modified;
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
                if (Id > 0) { 
                var comp = context.Company1.Where(x => x.CompNo == Id).FirstOrDefault();
                context.Company1.Remove(comp);
                context.SaveChanges();
                flgCompany = true;
                }
            }
            return flgCompany;
        }
    }
}
