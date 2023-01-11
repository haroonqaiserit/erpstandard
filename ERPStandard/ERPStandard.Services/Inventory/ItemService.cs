using ERPStandard.DbEntities;
using ERPStandard.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPStandard.Services
{
    public class ItemService
    {
        #region "Singleton"

        public static ItemService Instance
        {
            get
            {
                if (instance == null) instance = new ItemService();
                return instance;
            }
        }
        private static ItemService instance { get; set; }

        private ItemService()
        {

        }
        #endregion
        public ItemViewModel All(int page, int pageSize = 10, string dtSearch = "", int clmNameOrder = 0, int ItemClass = 2)
        {
            var viewModel = new ItemViewModel();
            using (var context = new SairaIndEntities())
            {
                var comp = context.ItemsStocks.Where(x => x.Dscr.Contains(dtSearch)
                        || x.ItemClass == ItemClass
                        );

                int totalpage = comp.Select(x => x.ItemID).Count();
                var pager = new Pager(totalpage, page, pageSize);
                if (clmNameOrder == 1)
                {
                    comp = comp.OrderBy(x => x.Dscr);
                }
                else if (clmNameOrder == 2)
                {
                    comp = comp.OrderBy(x => x.GodownId);
                }
                else if (clmNameOrder == 3)
                {
                    comp = comp.OrderBy(x => x.BrandId);
                }
                else
                {
                    comp = comp.OrderBy(x => x.Dscr);
                }

                viewModel.Items = comp.Skip((pager.CurrentPage - 1) * pager.PageSize).Take(pager.PageSize).ToList();
                viewModel.dtSearch = dtSearch;
                viewModel.clmNameOrder = clmNameOrder;
                viewModel.Pager = pager;
            }
            return viewModel;
        }
        public ItemViewModel Report(string dtSearch = "", int clmNameOrder = 0, int ItemClass = 2)
        {
            var viewModel = new ItemViewModel();
            using (var context = new SairaIndEntities())
            {
                var comp = context.ItemsStocks.Where(x => x.Dscr.Contains(dtSearch)
                        || x.ItemClass == ItemClass
                        );

                int totalpage = comp.Select(x => x.ItemID).Count();
                
                if (clmNameOrder == 1)
                {
                    comp = comp.OrderBy(x => x.Dscr);
                }
                else if (clmNameOrder == 2)
                {
                    comp = comp.OrderBy(x => x.GodownId);
                }
                else if (clmNameOrder == 3)
                {
                    comp = comp.OrderBy(x => x.BrandId);
                }
                else
                {
                    comp = comp.OrderBy(x => x.Dscr);
                }
                viewModel.Items = comp.Where(x=> x.CompNo == StandardVariables.CompNo && x.BranchNo == StandardVariables.BranchNo).ToList();
                viewModel.dtSearch = dtSearch;
                viewModel.clmNameOrder = clmNameOrder;
            }
            return viewModel;
        }

        public List<ItemsStock> All_List(string dtSearch = "", int clmNameOrder = 0, int? ItemClass=null)
        {
            var viewModel = new List<ItemsStock>();
            using (var context = new SairaIndEntities())
            {
                var comp = context.ItemsStocks.Where(x => x.Dscr.Contains(dtSearch)
                        );
                if (ItemClass.HasValue) { 
                comp = comp.Where(x => x.ItemClass == ItemClass);
                }
                int totalpage = comp.Select(x => x.ItemID).Count();

                if (clmNameOrder == 1)
                {
                    comp = comp.OrderBy(x => x.Dscr);
                }
                else if (clmNameOrder == 2)
                {
                    comp = comp.OrderBy(x => x.GodownId);
                }
                else if (clmNameOrder == 3)
                {
                    comp = comp.OrderBy(x => x.BrandId);
                }
                else
                {
                    comp = comp.OrderBy(x => x.Dscr);
                }
                viewModel = comp.Take(5).Where(x => x.CompNo == StandardVariables.CompNo && x.BranchNo == StandardVariables.BranchNo).ToList();
            }
            return viewModel;
        }

        public ItemsStock SingleFirstRec(string dtSearch = "")
        {
            var viewModel = new ItemsStock();
            using (var context = new SairaIndEntities())
            {
                var comp = context.ItemsStocks.Where(x => x.Dscr.Contains(dtSearch)
                        );
                    comp = comp.OrderBy(x => x.Dscr);
                viewModel = comp.Where(x => x.CompNo == StandardVariables.CompNo && x.BranchNo == StandardVariables.BranchNo).FirstOrDefault();
            }
            return viewModel;
        }


        public ItemsStock Single(string Id)
        {
            var viewModel = new ItemsStock();
            if (!string.IsNullOrEmpty(Id))
            {
                using (var context = new SairaIndEntities())
                {
                    viewModel = context.ItemsStocks.Where(x => x.ItemID== Id).FirstOrDefault();
                }
            }
            return viewModel;
        }
        public int Add(ItemsStock Item)
        {
            int compno = 0;
            using (var context = new SairaIndEntities())
            {
                compno = context.ItemsStocks.Select(x => x.ItemNo).Max() + 1;
                Item.ItemNo = compno;
                Item.ItemID = Item.ItemNo.ToString().PadLeft(4,'0') + '-' + StandardVariables.BLetter;
                Item.DeletionID = 0;
                Item.CompNo = StandardVariables.CompNo;
                Item.BranchNo = StandardVariables.BranchNo;
                Item.LahTransferId = 0;
                Item.SaveDate = DateTime.Now;
                context.ItemsStocks.Add(Item);
                context.SaveChanges();
            }
            return compno;
        }
        public bool Update(ItemsStock Item)
        {
            var brn = Single(Item.ItemID);

            Item.CompNo = brn.CompNo;
            Item.BranchNo = brn.BranchNo;
            Item.LahTransferId = brn.LahTransferId;
            Item.DeletionID = brn.DeletionID;
            Item.SaveDate = brn.SaveDate;
            //Item.ItemType = brn.ItemType;

            bool flgCompany = false;
            using (var context = new SairaIndEntities())
            {
                context.Entry(Item).State = System.Data.Entity.EntityState.Modified;
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
                    var comp = context.ItemsStocks.Where(x => x.ItemID == Id).FirstOrDefault();
                    context.ItemsStocks.Remove(comp);
                    context.SaveChanges();
                    flgCompany = true;
                }
            }
            return flgCompany;
        }
    }
}
    