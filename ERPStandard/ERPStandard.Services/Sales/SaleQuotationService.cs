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
    public class SaleQuotationService
    {
        #region "Singleton"

        public static SaleQuotationService Instance
        {
            get
            {
                if (instance == null) instance = new SaleQuotationService();
                return instance;
            }
        }
        private static SaleQuotationService instance { get; set; }

        private SaleQuotationService()
        {

        }
        #endregion
        public SaleQuotationViewModel All(int page, int pageSize = 10, string dtSearch = "", int clmNameOrder = 0)
        {
            var viewModel = new SaleQuotationViewModel();
            using (var context = new SairaIndEntities())
            {
                var comp = context.CRM_SaleQuotation.Where(x => x.QuoteId.Contains(dtSearch)
                        || x.Remarks.Contains(dtSearch)
                        || x.RefDocName.Contains(dtSearch)
                        );

                int totalpage = comp.Select(x => x.QuoteId).Count();
                var pager = new Pager(totalpage, page, pageSize);
                if (clmNameOrder == 1)
                {
                    comp = comp.OrderBy(x => x.QuoteNo);
                }
                else if (clmNameOrder == 2)
                {
                    comp = comp.OrderBy(x => x.QuoteDate);
                }
                else if (clmNameOrder == 3)
                {
                    comp = comp.OrderBy(x => x.QuoteValidDate);
                }
                else if (clmNameOrder == 4)
                {
                    comp = comp.OrderBy(x => x.Remarks);
                }
                else
                {
                    comp = comp.OrderBy(x => x.QuoteNo);
                }

                viewModel.SaleQuotation = comp.Skip((pager.CurrentPage - 1) * pager.PageSize).Take(pager.PageSize).ToList();
                viewModel.dtSearch = dtSearch;
                viewModel.clmNameOrder = clmNameOrder;
                viewModel.Pager = pager;
            }
            return viewModel;
        }
        public SaleQuotationViewModel Report(string dtSearch = "", int clmNameOrder = 0)
        {
            var viewModel = new SaleQuotationViewModel();
            using (var context = new SairaIndEntities())
            {
                var comp = context.CRM_SaleQuotation.Where(x => x.QuoteId.Contains(dtSearch)
                        || x.Remarks.Contains(dtSearch)
                        || x.RefDocName.Contains(dtSearch)
                        );

                int totalpage = comp.Select(x => x.QuoteId).Count();
                if (clmNameOrder == 1)
                {
                    comp = comp.OrderBy(x => x.QuoteNo);
                }
                else if (clmNameOrder == 2)
                {
                    comp = comp.OrderBy(x => x.QuoteDate);
                }
                else if (clmNameOrder == 3)
                {
                    comp = comp.OrderBy(x => x.QuoteValidDate);
                }
                else if (clmNameOrder == 4)
                {
                    comp = comp.OrderBy(x => x.Remarks);
                }
                else
                {
                    comp = comp.OrderBy(x => x.QuoteNo);
                }

                viewModel.SaleQuotation = comp.ToList();
                viewModel.dtSearch = dtSearch;
                viewModel.clmNameOrder = clmNameOrder;
            }
            return viewModel;
        }

        public Root InvoiceReport(string Id = "")
        {
            string documentname = "Quotation";
            var root = new Root();
            using (var context = new SairaIndEntities())
            {

                var inv_Master = (from m in context.CRM_SaleQuotation
                         where m.CompNo == StandardVariables.CompNo 
                         && m.BranchNo == StandardVariables.BranchNo
                         && m.QuoteId == Id
                         join d in context.Customers on m.CustomerNo equals d.CustomerNo
                         where d.CompNo == m.CompNo & d.BranchNo == m.BranchNo
                         select new { m, d }).FirstOrDefault();


                var inv_detail = (from m in context.CRM_SaleQuotation
                                  where m.CompNo == StandardVariables.CompNo
                                     && m.BranchNo == StandardVariables.BranchNo
                                  join d in context.CRM_SaleQuotationDetail on m.QuoteId equals d.QuoteId
                                  where d.CompNo == m.CompNo
                                     && d.BranchNo == m.BranchNo
                                     && m.QuoteId == Id
                                  select new InvoiceReportDetails {
                                      serialnum = (int)m.QuoteNo,
                                      Item = d.ItemID,
                                      Qty = d.Qty,
                                      rate = d.Rate,
                                      STax=d.SaleTaxRate,
                                      ASTax=d.ASaleTaxRate,
                                      SExDuty = d.SExDutyRate,
                                      discount=0,
                                      Amount= d.Qty*d.Rate
                                  });
                List<InvoiceReportDetails> invoice_report_details = new List<InvoiceReportDetails>();
                invoice_report_details= inv_detail.ToList();
                var company = Company1Service.Instance.Single(StandardVariables.CompNo);


                root.outputType = "jsPDFInvoiceTemplate.OutputType.Save";
                root.returnJsPDFDocObject = true;
                root.fileName = "Sale " + documentname;
                root.orientationLandscape = false;
                //logo class settings
                Logo logo = new Logo();
                logo.src = "https://raw.githubusercontent.com/edisonneza/jspdf-invoice-template/demo/images/logo.png";
                logo.width = 53.33;
                logo.height = 26.66;
                //Margin for Logo class settings
                Margin margin = new Margin();
                margin.top = 0;
                margin.left = 0;
                logo.margin = margin;
                root.logo = logo;
                //Stamp class settings - Root
                Stamp stamp = new Stamp();
                stamp.inAllPages = true;
                stamp.src = "https://raw.githubusercontent.com/edisonneza/jspdf-invoice-template/demo/images/qr_code.jpg";
                stamp.width = 20; //aspect ratio = width/height
                stamp.height= 20;
                //Margin for Stamp class settings
                margin.top = 0;
                margin.left = 0;
                stamp.margin = margin;
                root.stamp = stamp;
                //Business class settings - Root
                Business business = new Business();
                business.name = "Saira Industries";
                business.address = "";
                business.phone = "";
                business.email = "";
                business.email_1 = "";
                business.website = "";
                root.business = business;
                ViewModels.Contact contact = new ViewModels.Contact();
                contact.label = "Invoice issued for:";
                contact.label = "Client Name";
                contact.address = "Albania, Tirane, Astir";
                contact.phone = "";
                contact.email = "";
                contact.otherInfo = "";
                root.contact = contact;
                Invoice invoice = new Invoice();


                invoice.label = documentname + " #: ";
                invoice.num = 19;
                invoice.invDate = documentname + " Date: " + DateTime.Now;
                invoice.invGenDate = "Print Date: " + DateTime.Now;
                invoice.headerBorder = true;
                invoice.tableBodyBorder = true;
                //Header Class Setting for Invoice table
                List<Header> header_L = new List<Header>();
                Header header = new Header();
                Style style = new Style();
                //Header 1 Setting


                //header.title = "#";
                //style.width = 10;
                //header.style = style;
                //header_L.Add(header);
                //Header 2 Setting
                header.title = "Sr"; //1
                style.width = 5;
                header.style = style;
                header_L.Add(header);

                header.title = "Description"; //2
                style.width = 30;
                header.style = style;
                header_L.Add(header);

                //Header 3 Setting
                header.title = "Qty";  //3
                header.style = style;
                header_L.Add(header);

                //Header 3 Setting
                header.title = "Rate"; //4
                header.style = style;
                header_L.Add(header);

                header.title = "STax"; //5
                header.style = style;
                header_L.Add(header);

                header.title = "VAT"; //6
                header.style = style;
                header_L.Add(header);

                header.title = "ExDuty"; //7
                header.style = style;
                header_L.Add(header);

                header.title = "Dis"; //8
                header.style = style;
                header_L.Add(header);

                header.title = "Amount"; //9
                header.style = style;
                header_L.Add(header);
                invoice.header = header_L;
                //invoice.table = inv_detail;
                List<List<InvoiceReportDetails>> tbl = new List<List<InvoiceReportDetails>>();
                List<object> list = new List<object>();
                object l = new InvoiceReportDetails();
                tbl.Add(invoice_report_details);
                invoice.table = tbl;
                invoice.invDescLabel = "This Quotation is Valid till: " + inv_Master.m.QuoteValidDate;
                invoice.invDesc = inv_Master.m.Remarks;
                root.invoice = invoice;
                //tbl.Add(invoice_report_details);
                Footer footer = new Footer();
                footer.text = "The invoice is created on a computer and is valid without the signature and stamp.";
                root.pageEnable=true;
                root.footer = footer;
                root.pageLabel = "Page Label here";
            }
            return root;
        }


        public CRM_SaleQuotation Single(string Id)
        {
            var viewModel = new CRM_SaleQuotation();
            if (!string.IsNullOrEmpty(Id))
            {
                using (var context = new SairaIndEntities())
                {
                    viewModel = context.CRM_SaleQuotation.Where(x => x.QuoteId == Id).FirstOrDefault();
                }
            }
            return viewModel;
        }
        public int Add(CRM_SaleQuotation SaleQuotation, List<CRM_SaleQuotationDetail> SaleQuotationDetail)
        {
            int savechanges = 0;
            using (var context = new SairaIndEntities())
            {
                int compno = (int)context.CRM_SaleQuotation.Select(x => x.QuoteNo).Max() + 1;
                SaleQuotation.QuoteNo = compno;
                SaleQuotation.QuoteId = SaleQuotation.QuoteNo.ToString().PadLeft(4, '0') + '-' + StandardVariables.BLetter; ;
                SaleQuotation.DeletionID = 0;
                SaleQuotation.LahTransferId = 0;
                SaleQuotation.SaveDate = DateTime.Now;
                SaleQuotation.CompNo = GlobalVariables.CompNo;
                SaleQuotation.BranchNo = GlobalVariables.BranchNo;
                CRM_SaleQuotationDetail saledetail = new CRM_SaleQuotationDetail();
                foreach (var item in SaleQuotationDetail)
                {
                    item.QuoteId = SaleQuotation.QuoteId;
                    item.DeletionID = 0;
                    item.LahTransferId = 0;
                    item.SaveDate = DateTime.Now;
                    item.CompNo = SaleQuotation.CompNo;
                    item.BranchNo = SaleQuotation.BranchNo;
                }
                
                context.CRM_SaleQuotation.Add(SaleQuotation);
                context.CRM_SaleQuotationDetail.AddRange(SaleQuotationDetail);
                savechanges = context.SaveChanges();
            }
            return savechanges;
        }
        public bool Update(CRM_SaleQuotation SaleQuotation)
        {
            var entityMain = Single(SaleQuotation.QuoteId);

            SaleQuotation.CompNo = entityMain.CompNo;
            SaleQuotation.BranchNo = entityMain.BranchNo;
            SaleQuotation.SaveDate = DateTime.Now;
            SaleQuotation.DeletionID = 0;
            SaleQuotation.LahTransferId = 0;

            bool flgCompany = false;
            using (var context = new SairaIndEntities())
            {
                context.Entry(SaleQuotation).State = System.Data.Entity.EntityState.Modified;
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
                    var comp = context.CRM_SaleQuotation.Where(x => x.QuoteId == Id).FirstOrDefault();
                    context.CRM_SaleQuotation.Remove(comp);
                    context.SaveChanges();
                    flgCompany = true;
                }
            }
            return flgCompany;
        }
    }
}
