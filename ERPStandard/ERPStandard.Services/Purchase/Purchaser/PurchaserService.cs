using ERPStandard.DbEntities;
using ERPStandard.ViewModels;
using ERPStandard.ViewModels.Purchase.Purchaser;
using ERPStandard.ViewModels.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPStandard.Services
{
    public class PurchaserService
    {
        #region "Singleton"

        public static PurchaserService Instance
        {
            get
            {
                if (instance == null) instance = new PurchaserService();
                return instance;
            }
        }
        private static PurchaserService instance { get; set; }

        private PurchaserService()
        {

        }
        #endregion
        public PurchaserViewModel All(int page, int pageSize = 10, string dtSearch = "", int clmNameOrder = 0, int PurchaserType = 1)
        {
            var viewModel = new PurchaserViewModel();
            using (var context = new SairaIndEntities())
            {
                var comp = context.Purchasers
                    .Join(context.EmployeePersonalInfoes,
                    x => x.EmpNo,
                    y => y.EmpNo,
                    (x, y) => new PurchasersViewModel
                    {
                        EmpNo = x.EmpNo,
                        PurchaseId = x.PurchaseId,
                        PurchaserNum = x.PurchaserNum,
                        Address = y.Address,
                        Name = y.Name,
                        DeletionID = y.DeletionID,
                        Phone1 = y.Phone1,
                        Phone2 = y.Phone2,
                        Email = y.emal,
                        CompNo = x.CompNo,
                        BranchNo =x.BranchNo,
                        SaveDate = x.SaveDate
                    }).Where(x => x.CompNo == StandardVariables.CompNo
                        && x.BranchNo == StandardVariables.BranchNo
                    ).Where(x => x.Name.Contains(dtSearch)
                        || x.Address.Contains(dtSearch)
                        || x.Phone1.Contains(dtSearch)
                        || x.Phone2.Contains(dtSearch)
                        || x.Email.Contains(dtSearch));
                    
                int totalpage = comp.Select(x => x.PurchaseId).Count();
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

                viewModel.Purchasers = comp.Skip((pager.CurrentPage - 1) * pager.PageSize).Take(pager.PageSize).ToList();
                viewModel.dtSearch = dtSearch;
                viewModel.clmNameOrder = clmNameOrder;
                viewModel.Pager = pager;
            }
            return viewModel;
        }
        public PurchaserViewModel Report(string dtSearch = "", int clmNameOrder = 0)
        {
            var viewModel = new PurchaserViewModel();
            using (var context = new SairaIndEntities())
            {
                var comp = context.Purchasers
                    .Join(context.EmployeePersonalInfoes,
                    x => x.EmpNo,
                    y => y.EmpNo,
                    (x, y) => new PurchasersViewModel
                    {
                        EmpNo = x.EmpNo,
                        PurchaseId = x.PurchaseId,
                        PurchaserNum = x.PurchaserNum,
                        Address = y.Address,
                        Name = y.Name,
                        DeletionID = y.DeletionID,
                        Phone1 = y.Phone1,
                        Phone2 = y.Phone2,
                        Email = y.emal,
                        CompNo = x.CompNo,
                        BranchNo = x.BranchNo,
                        SaveDate = x.SaveDate
                    }).Where(x => x.CompNo == StandardVariables.CompNo
                        && x.BranchNo == StandardVariables.BranchNo
                    ).Where(x => x.Name.Contains(dtSearch)
                        || x.Address.Contains(dtSearch)
                        || x.Phone1.Contains(dtSearch)
                        || x.Phone2.Contains(dtSearch)
                        || x.Email.Contains(dtSearch));

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

                viewModel.Purchasers = comp.Where(x=> x.CompNo == StandardVariables.CompNo && x.BranchNo == StandardVariables.BranchNo).ToList();
                viewModel.dtSearch = dtSearch;
                viewModel.clmNameOrder = clmNameOrder;
            }
            return viewModel;
        }

        public List<PurchasersViewModel> All_List(string dtSearch = "", int clmNameOrder = 0, int? PurchaserType = null)
        {
            var viewModel = new List<PurchasersViewModel>();
            using (var context = new SairaIndEntities())
            {
                var comp = context.Purchasers
                .Join(context.EmployeePersonalInfoes,
                x => x.EmpNo,
                y => y.EmpNo,
                (x, y) => new PurchasersViewModel
                {
                    EmpNo = x.EmpNo,
                    PurchaseId = x.PurchaseId,
                    PurchaserNum = x.PurchaserNum,
                    Address = y.Address,
                    Name = y.Name,
                    DeletionID = y.DeletionID,
                    Phone1 = y.Phone1,
                    Phone2 = y.Phone2,
                    Email = y.emal,
                    CompNo = x.CompNo,
                    BranchNo = x.BranchNo,
                    SaveDate = x.SaveDate
                }).Where(x => x.CompNo == StandardVariables.CompNo
                    && x.BranchNo == StandardVariables.BranchNo
                ).Where(x => x.Name.Contains(dtSearch)
                    || x.Address.Contains(dtSearch)
                    || x.Phone1.Contains(dtSearch)
                    || x.Phone2.Contains(dtSearch)
                    || x.Email.Contains(dtSearch));

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


        public PurchasersViewModel Single(string Id)
        {
            var viewModel = new PurchasersViewModel();
            if (!string.IsNullOrEmpty(Id))
            {
                using (var context = new SairaIndEntities())
                {
                    var comp = context.Purchasers
                    .Join(context.EmployeePersonalInfoes,
                    x => x.EmpNo,
                    y => y.EmpNo,
                    (x, y) => new PurchasersViewModel
                    {
                        EmpNo = x.EmpNo,
                        PurchaseId = x.PurchaseId,
                        PurchaserNum = x.PurchaserNum,
                        Address = y.Address,
                        Name = y.Name,
                        DeletionID = y.DeletionID,
                        Phone1 = y.Phone1,
                        Phone2 = y.Phone2,
                        Email = y.emal,
                        CompNo = x.CompNo,
                        BranchNo = x.BranchNo,
                        SaveDate = x.SaveDate
                    }).Where(x => x.CompNo == StandardVariables.CompNo
                        && x.BranchNo == StandardVariables.BranchNo
                        && x.PurchaseId == Id);
                    viewModel = comp.Where(x => x.CompNo == StandardVariables.CompNo && x.BranchNo == StandardVariables.BranchNo).FirstOrDefault();
                }
            }
            return viewModel;
        }
        public int Add(Purchaser Purchaser)
        {
            int compno = 0;
            using (var context = new SairaIndEntities())
            {
                compno = (int)context.Purchasers.Select(x => x.PurchaserNum).Max() + 1;
                Purchaser.PurchaserNum = compno;
                Purchaser.PurchaseId = Purchaser.PurchaserNum.ToString().PadLeft(4,'0') + '-' + StandardVariables.BLetter;
                Purchaser.DeletionID = 0;
                Purchaser.CompNo = StandardVariables.CompNo;
                Purchaser.BranchNo = StandardVariables.BranchNo;
                Purchaser.LahTransferId = 0;
                Purchaser.SaveDate = DateTime.Now;
                context.Purchasers.Add(Purchaser);
                context.SaveChanges();
            }
            return compno;
        }
        public bool Update(Purchaser Purchaser)
        {
            var brn = Single(Purchaser.PurchaseId);

            Purchaser.CompNo = brn.CompNo;
            Purchaser.BranchNo = brn.BranchNo;
            Purchaser.LahTransferId = brn.LahTransferId;
            Purchaser.DeletionID = brn.DeletionID;
            Purchaser.SaveDate = brn.SaveDate;
            //Purchaser.PurchaserType = brn.PurchaserType;

            bool flgCompany = false;
            using (var context = new SairaIndEntities())
            {
                context.Entry(Purchaser).State = System.Data.Entity.EntityState.Modified;
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
                    var comp = context.Purchasers.Where(x => x.PurchaseId == Id).FirstOrDefault();
                    context.Purchasers.Remove(comp);
                    context.SaveChanges();
                    flgCompany = true;
                }
            }
            return flgCompany;
        }
    }
}
    