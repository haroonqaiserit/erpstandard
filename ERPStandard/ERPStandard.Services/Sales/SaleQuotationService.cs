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
        public SaleQuotationViewModel All(int page, int pageSize = 10, string dtSearch = "", int clmNameOrder = 0, string sortorder = "")
        {
            var viewModel = new SaleQuotationViewModel();
            using (var context = new SairaIndEntities())
            {
                var comp = context.CRM_SaleQuotation
                    .Join(context.Customers,
                        o => o.CustomerNo,
                        cust => cust.CustomerNo,
                        (o, cust) => new
                        {
                            o.QuoteId,
                            o.QuoteNo,
                            o.QuoteDate,
                            o.QuoteValidDate,
                            o.RefDocId,
                            o.RefDocName,
                            o.Remarks,
                            o.DeletionID,
                            o.SalesManId,
                            CustomerName = cust.Name,
                        })
                .Join(context.SalesMen,
                    o => o.SalesManId,
                    sal => sal.SalesManId,
                    (o, sal) => new SaleQuotationMasterViewModel
                    {
                        QuoteId = o.QuoteId,
                        QuoteNo = o.QuoteNo,
                        QuoteDate = o.QuoteDate,
                        QuoteValidDate = o.QuoteValidDate,
                        RefDocId = o.RefDocId,
                        RefDocName = o.RefDocName,
                        Remarks = o.Remarks,
                        DeletionID = o.DeletionID,
                        CustomerName = o.CustomerName,
                        SalesManName = sal.Name
                    }
                ).Where(x => x.QuoteId.Contains(dtSearch)
                        || x.Remarks.Contains(dtSearch)
                        || x.RefDocName.Contains(dtSearch)
                        || x.CustomerName.Contains(dtSearch)
                        || x.SalesManName.Contains(dtSearch)
                        );
                int totalpage = comp.Select(x => x.QuoteId).Count();
                var pager = new Pager(totalpage, page, pageSize);
                if (clmNameOrder == 1)
                {
                    comp = sortorder=="asc"? comp.OrderBy(x => x.QuoteNo): comp.OrderByDescending(x => x.QuoteNo);
                }
                else if (clmNameOrder == 2)
                {
                    comp = sortorder == "asc" ? comp.OrderBy(x => x.QuoteDate) : comp.OrderByDescending(x => x.QuoteDate);
                }
                else if (clmNameOrder == 3)
                {
                    comp = sortorder == "asc" ? comp.OrderBy(x => x.QuoteValidDate) : comp.OrderByDescending(x => x.QuoteValidDate);
                }
                else if (clmNameOrder == 4)
                {
                    comp = sortorder == "asc" ? comp.OrderBy(x => x.Remarks) : comp.OrderByDescending(x => x.Remarks);
                }
                else
                {
                    comp = sortorder == "asc" ? comp.OrderBy(x => x.QuoteNo) : comp.OrderByDescending(x => x.QuoteNo);
                }

                viewModel.SaleQuotation = comp.Skip((pager.CurrentPage - 1) * pager.PageSize).Take(pager.PageSize).ToList();
                viewModel.dtSearch = dtSearch;
                viewModel.clmNameOrder = clmNameOrder;
                viewModel.sortorder = sortorder;
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
                        ).Join(context.Customers,
                        o => o.CustomerNo,
                        cust => cust.CustomerNo,
                        (o, cust) => new
                        {
                            o.QuoteId,
                            o.QuoteNo,
                            o.QuoteDate,
                            o.QuoteValidDate,
                            o.RefDocId,
                            o.RefDocName,
                            o.Remarks,
                            o.DeletionID,
                            o.SalesManId,
                            CustomerName = cust.Name,
                        }).Where(x => x.CustomerName.Contains(dtSearch))
                .Join(context.SalesMen,
                    o => o.SalesManId,
                    sal => sal.SalesManId,
                    (o, sal) => new SaleQuotationMasterViewModel
                    {
                        QuoteId = o.QuoteId,
                        QuoteNo = o.QuoteNo,
                        QuoteDate = o.QuoteDate,
                        QuoteValidDate = o.QuoteValidDate,
                        RefDocId = o.RefDocId,
                        RefDocName = o.RefDocName,
                        Remarks = o.Remarks,
                        DeletionID = o.DeletionID,
                        CustomerName = o.CustomerName,
                        SalesManName = sal.Name
                    }
                ).Where(x => x.SalesManName.Contains(dtSearch));


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

        //public Root InvoiceReport(string Id = "")

        public Root<T> InvoiceReportList<T>(string Id)
        {
            var root = new Root<T>();
            Invoice<T> invoice = new Invoice<T>();
            InvoiceHeaders invoiceHeaders = new InvoiceHeaders();
            string documentname = "Quotation";
            root.fileName = "Sale " + documentname;
            root.orientationLandscape = false;

            int TotalAmnt = 0;
            int SaleTotalAmnt = 0;
            int AddSaleTaxTotalAmnt = 0;
            int SExDutyTotalAmnt = 0;
            int InvNetTotalAmnt = 0;
            List<T> invoice_report_details = new List<T>();
            using (var context = new SairaIndEntities())
            {
                var inv_Master = (from master in context.CRM_SaleQuotation
                                  where master.CompNo == StandardVariables.CompNo
                                  && master.BranchNo == StandardVariables.BranchNo
                                  && master.QuoteId == Id
                                  join detail in context.Customers on master.CustomerNo equals detail.CustomerNo
                                  where detail.CompNo == master.CompNo & detail.BranchNo == master.BranchNo
                                  join customer in context.Company1 on master.CompNo equals customer.CompNo
                                  join city in context.Cities on detail.CityId equals city.CityId
                                  select new { master, detail, customer, city }).FirstOrDefault();
                //Business class settings - Root
                Business business = new Business();
                business.name = inv_Master.customer.Company_Name == null ? "" : inv_Master.customer.Company_Name;
                business.address = inv_Master.customer.Company_address == null ? "" : inv_Master.customer.Company_address;
                business.phone = inv_Master.customer.Company_phones == null ? "" : inv_Master.customer.Company_phones;
                business.email = inv_Master.customer.Company_email == null ? "" : inv_Master.customer.Company_email;
                business.email_1 = "";
                business.website = ""; //inv_Master.c.company_website;
                business.STaxRegNo = inv_Master.customer.STaxRegNo == null ? "" : inv_Master.customer.STaxRegNo;
                business.NationalTaxNo = inv_Master.customer.NationalTaxNo == null ? "" : inv_Master.customer.NationalTaxNo;
                business.City = inv_Master.customer.CityName == null ? "" : inv_Master.customer.CityName;
                root.business = business;
                ViewModels.Contact contact = new ViewModels.Contact();
                contact.label = "Invoice issued for:";
                contact.name = inv_Master.detail.Name == null ? "" : inv_Master.detail.Name;
                contact.address = inv_Master.detail.Address == null ? "" : inv_Master.detail.Address;
                contact.phone = inv_Master.detail.Phone1 == null ? "" : inv_Master.detail.Phone1;
                contact.email = inv_Master.detail.Email == null ? "" : inv_Master.detail.Email;
                contact.website = inv_Master.detail.WebPage == null ? "" : inv_Master.detail.WebPage;
                contact.STaxRegNo = inv_Master.detail.SaleTaxRegisterNo == null ? "" : inv_Master.detail.SaleTaxRegisterNo;
                contact.NationalTaxNo = inv_Master.detail.NationalTaxNo == null ? "" : inv_Master.detail.NationalTaxNo;
                contact.City = inv_Master.city.CityDesc == null ? "" : inv_Master.city.CityDesc;
                //contact.otherInfo = inv_Master.d.r;
                root.contact = contact;

                invoice.label = documentname;
                invoice.num = inv_Master.master.QuoteNo.ToString();
                invoice.invDate = inv_Master.master.QuoteDate.ToString("dd-MMM-yyyy");
                invoice.ValidDate = inv_Master.master.QuoteValidDate.ToString("dd-MMM-yyyy");
                invoice.invGenDate = "Print Date: " + DateTime.Now.ToString("dd-MMM-yyyy hh:mm tt"); ;
                invoice.headerBorder = true;
                invoice.tableBodyBorder = true;
                invoice.RefDocId = inv_Master.master.RefDocId == null ? "" : inv_Master.master.RefDocId;
                invoice.RefDocName = inv_Master.master.RefDocName == null ? "" : inv_Master.master.RefDocName;
                invoice.invDesc = inv_Master.master.Remarks;
                root.pageLabel = inv_Master.master.QuoteValidDate == null ? "" : "this " + documentname + " is valid till " + inv_Master.master.QuoteValidDate.ToString("dd-MMM-yyyy");


                if (typeof(T) == typeof(InvoiceDetails))
                {
                    invoice.header = invoiceHeaders.invoiceListHeaders(InvoiceType.Invoice_Simple);
                    var inv_detail = (from m in context.CRM_SaleQuotation
                                      where m.CompNo == StandardVariables.CompNo
                                         && m.BranchNo == StandardVariables.BranchNo
                                      join d in context.CRM_SaleQuotationDetail on m.QuoteId equals d.QuoteId
                                      where d.CompNo == m.CompNo
                                         && d.BranchNo == m.BranchNo
                                         && m.QuoteId == Id
                                      join itm in context.ItemsStocks on d.ItemID equals itm.ItemID
                                      where itm.CompNo == d.CompNo
                                         && itm.BranchNo == d.BranchNo
                                      select new InvoiceDetails
                                      {
                                          serialnum = 1,
                                          Item = itm.Dscr,
                                          Qty = d.Qty,
                                          rate = d.Rate,
                                          Amount = Math.Round(d.Qty * d.Rate, 0),
                                      });
                    var t = inv_detail.ToList();
                    var count = 1;
                    foreach (var x in t) x.serialnum = count++;
                    TotalAmnt = (int)Math.Round(t.Sum(n => n.Amount), 0);
                    AddSaleTaxTotalAmnt = 0;
                    SExDutyTotalAmnt = 0;
                    SaleTotalAmnt = 0;
                    InvNetTotalAmnt = TotalAmnt;


                    InvoiceDetails TotalRow = new InvoiceDetails
                    {
                        serialnum = null,
                        Item = "TOTAL",
                        Qty = null,
                        rate = null,
                        Amount = TotalAmnt
                    };
                    t.Add(TotalRow);
                    invoice_report_details = t as List<T>;
                    invoice.table = invoice_report_details;
                }
                else if (typeof(T) == typeof(InvoiceDetails_ISTAX))
                {
                    invoice.header = invoiceHeaders.invoiceListHeaders(InvoiceType.Invoice_Tax);
                    var inv_detail = (from m in context.CRM_SaleQuotation
                                      where m.CompNo == StandardVariables.CompNo
                                         && m.BranchNo == StandardVariables.BranchNo
                                      join d in context.CRM_SaleQuotationDetail on m.QuoteId equals d.QuoteId
                                      where d.CompNo == m.CompNo
                                         && d.BranchNo == m.BranchNo
                                         && m.QuoteId == Id
                                      join itm in context.ItemsStocks on d.ItemID equals itm.ItemID
                                      where itm.CompNo == d.CompNo
                                         && itm.BranchNo == d.BranchNo
                                      select new InvoiceDetails_ISTAX
                                      {
                                          serialnum = 1,
                                          Item = itm.Dscr,
                                          Qty = d.Qty,
                                          rate = d.Rate,
                                          Amount = Math.Round(d.Qty * d.Rate, 0),
                                          STaxRate = d.SaleTaxRate,
                                          STaxAmount = Math.Round((d.Qty * d.Rate) * d.SaleTaxRate / 100, 0),
                                          NetAmount = Math.Round((d.Qty * d.Rate) + (d.Qty * d.Rate) * (d.SaleTaxRate / 100) , 0)
                                      });
                    var t = inv_detail.ToList();
                    var count = 1;
                    foreach (var x in t) x.serialnum = count++;
                    TotalAmnt = (int)Math.Round(t.Sum(n => n.Amount), 0);
                    AddSaleTaxTotalAmnt =0;
                    SExDutyTotalAmnt = 0;
                    SaleTotalAmnt = (int)Math.Round(t.Sum(n => n.STaxAmount.Value), 0);
                    InvNetTotalAmnt = (int)Math.Round(t.Sum(n => n.NetAmount), 0);

                    InvoiceDetails_ISTAX TotalRow = new InvoiceDetails_ISTAX
                    {
                        serialnum = null,
                        Item = "TOTAL",
                        Qty = null,
                        rate = null,
                        Amount = TotalAmnt,
                        STaxRate = null,
                        STaxAmount = SaleTotalAmnt,
                        NetAmount = InvNetTotalAmnt
                    };
                    t.Add(TotalRow);
                    invoice_report_details = t as List<T>;
                    invoice.table = invoice_report_details;
                }

                else if (typeof(T) == typeof(InvoiceDetails_ISTAX_IASTAX))
                {
                    invoice.header = invoiceHeaders.invoiceListHeaders(InvoiceType.Invoice_Tax_AddTax);
                    var inv_detail = (from m in context.CRM_SaleQuotation
                                      where m.CompNo == StandardVariables.CompNo
                                         && m.BranchNo == StandardVariables.BranchNo
                                      join d in context.CRM_SaleQuotationDetail on m.QuoteId equals d.QuoteId
                                      where d.CompNo == m.CompNo
                                         && d.BranchNo == m.BranchNo
                                         && m.QuoteId == Id
                                      join itm in context.ItemsStocks on d.ItemID equals itm.ItemID
                                      where itm.CompNo == d.CompNo
                                         && itm.BranchNo == d.BranchNo
                                      select new InvoiceDetails_ISTAX_IASTAX
                                      {
                                          serialnum = 1,
                                          Item = itm.Dscr,
                                          Qty = d.Qty,
                                          rate = d.Rate,
                                          Amount = Math.Round(d.Qty * d.Rate, 0),
                                          STaxRate = d.SaleTaxRate,
                                          STaxAmount = Math.Round((d.Qty * d.Rate) * d.SaleTaxRate / 100, 0),
                                          ASTaxRate = d.ASaleTaxRate,
                                          ASTaxAmount = Math.Round((d.Qty * d.Rate) * (d.ASaleTaxRate / 100), 0),
                                          NetAmount = Math.Round((d.Qty * d.Rate) + (d.Qty * d.Rate) * d.SaleTaxRate / 100 + (d.Qty * d.Rate) * (d.ASaleTaxRate / 100), 0)
                                      });
                    var t = inv_detail.ToList();
                    var count = 1;
                    foreach (var x in t) x.serialnum = count++;
                    TotalAmnt = (int)Math.Round(t.Sum(n => n.Amount), 0);
                    SaleTotalAmnt = (int)Math.Round(t.Sum(n => n.STaxAmount.Value), 0);
                    AddSaleTaxTotalAmnt = (int)Math.Round(t.Sum(n=> n.ASTaxAmount.Value), 0);
                    SExDutyTotalAmnt = 0;
                    InvNetTotalAmnt = (int)Math.Round(t.Sum(n => n.NetAmount), 0);
                    InvoiceDetails_ISTAX_IASTAX TotalRow = new InvoiceDetails_ISTAX_IASTAX
                    {
                        serialnum = null,
                        Item = "TOTAL",
                        Qty = null,
                        rate = null,
                        Amount = TotalAmnt,
                        STaxRate = null,
                        STaxAmount = SaleTotalAmnt,
                        ASTaxRate = null,
                        ASTaxAmount= AddSaleTaxTotalAmnt,
                        NetAmount = InvNetTotalAmnt
                    };
                    t.Add(TotalRow);
                    invoice_report_details = t as List<T>;
                    invoice.table = invoice_report_details;
                }

                else if (typeof(T) == typeof(InvoiceDetails_ISTAX_ISExDuty))
                {
                    invoice.header = invoiceHeaders.invoiceListHeaders(InvoiceType.Invoice_Tax_SExDuty);
                    var inv_detail = (from m in context.CRM_SaleQuotation
                                      where m.CompNo == StandardVariables.CompNo
                                         && m.BranchNo == StandardVariables.BranchNo
                                      join d in context.CRM_SaleQuotationDetail on m.QuoteId equals d.QuoteId
                                      where d.CompNo == m.CompNo
                                         && d.BranchNo == m.BranchNo
                                         && m.QuoteId == Id
                                      join itm in context.ItemsStocks on d.ItemID equals itm.ItemID
                                      where itm.CompNo == d.CompNo
                                         && itm.BranchNo == d.BranchNo
                                      select new InvoiceDetails_ISTAX_ISExDuty
                                      {
                                          serialnum = 1,
                                          Item = itm.Dscr,
                                          Qty = d.Qty,
                                          rate = d.Rate,
                                          Amount = Math.Round(d.Qty * d.Rate, 0),
                                          STaxRate = d.SaleTaxRate,
                                          STaxAmount = Math.Round((d.Qty * d.Rate) * d.SaleTaxRate / 100, 0),
                                          SExDutyRate = d.SExDutyRate,
                                          SExDutyAmount = Math.Round((d.Qty * d.Rate) * (d.SExDutyRate / 100), 0),
                                          NetAmount = Math.Round((d.Qty * d.Rate) + (d.Qty * d.Rate) * d.SaleTaxRate / 100 + (d.Qty * d.Rate) * (d.SExDutyRate / 100), 0)
                                      });
                    var t = inv_detail.ToList();
                    var count = 1;
                    foreach (var x in t) x.serialnum = count++;
                    TotalAmnt = (int)Math.Round(t.Sum(n => n.Amount), 0);
                    SaleTotalAmnt = (int)Math.Round(t.Sum(n => n.STaxAmount.Value), 0);
                    AddSaleTaxTotalAmnt = 0;
                    SExDutyTotalAmnt = (int)Math.Round(t.Sum(n => n.SExDutyAmount.Value), 0);
                    InvNetTotalAmnt = (int)Math.Round(t.Sum(n => n.NetAmount), 0);

                    InvoiceDetails_ISTAX_ISExDuty TotalRow = new InvoiceDetails_ISTAX_ISExDuty
                    {
                        serialnum = null,
                        Item = "TOTAL",
                        Qty = null,
                        rate = null,
                        Amount = TotalAmnt,
                        STaxRate = null,
                        STaxAmount = SaleTotalAmnt,
                        SExDutyRate = null,
                        SExDutyAmount = SExDutyTotalAmnt,
                        NetAmount = InvNetTotalAmnt
                    };
                    t.Add(TotalRow);
                    invoice_report_details = t as List<T>;
                    invoice.table = invoice_report_details;
                }

                else if (typeof(T) == typeof(InvoiceDetails_ISTAX_IASTAX_ISExDuty))
                {
                    invoice.header = invoiceHeaders.invoiceListHeaders(InvoiceType.Invoice_Tax_AddTax_SExDuty);
                    var inv_detail = (from m in context.CRM_SaleQuotation
                                      where m.CompNo == StandardVariables.CompNo
                                         && m.BranchNo == StandardVariables.BranchNo
                                      join d in context.CRM_SaleQuotationDetail on m.QuoteId equals d.QuoteId
                                      where d.CompNo == m.CompNo
                                         && d.BranchNo == m.BranchNo
                                         && m.QuoteId == Id
                                      join itm in context.ItemsStocks on d.ItemID equals itm.ItemID
                                      where itm.CompNo == d.CompNo
                                         && itm.BranchNo == d.BranchNo
                                      select new InvoiceDetails_ISTAX_IASTAX_ISExDuty
                                      {
                                          serialnum = 1,
                                          Item = itm.Dscr,
                                          Qty = d.Qty,
                                          rate = d.Rate,
                                          Amount = Math.Round(d.Qty * d.Rate, 0),
                                          STaxRate = d.SaleTaxRate,
                                          ASTaxRate = d.ASaleTaxRate,
                                          ASTaxAmount = Math.Round((d.Qty * d.Rate) * (d.ASaleTaxRate / 100), 0),
                                          STaxAmount = Math.Round((d.Qty * d.Rate) * d.SaleTaxRate / 100, 0),
                                          SExDutyRate = d.SExDutyRate,
                                          SExDutyAmount = Math.Round((d.Qty * d.Rate) * (d.SExDutyRate / 100), 0),
                                          NetAmount = Math.Round((d.Qty * d.Rate) + (d.Qty * d.Rate) * (d.SaleTaxRate / 100) + (d.Qty * d.Rate) * (d.ASaleTaxRate / 100) + (d.Qty * d.Rate) * (d.SExDutyRate / 100), 0)
                                      });
                    var t = inv_detail.ToList();
                    var count = 1;
                    foreach (var x in t) x.serialnum = count++;
                    TotalAmnt = (int)Math.Round(t.Sum(n => n.Amount), 0);
                    SaleTotalAmnt = (int)Math.Round(t.Sum(n => n.STaxAmount.Value), 0);
                    AddSaleTaxTotalAmnt = (int)Math.Round(t.Sum(n => n.ASTaxAmount.Value), 0);
                    SExDutyTotalAmnt = (int)Math.Round(t.Sum(n => n.SExDutyAmount.Value), 0);
                    InvNetTotalAmnt = (int)Math.Round(t.Sum(n => n.NetAmount), 0);
                    InvoiceDetails_ISTAX_IASTAX_ISExDuty TotalRow = new InvoiceDetails_ISTAX_IASTAX_ISExDuty
                    {
                        serialnum = null,
                        Item = "TOTAL",
                        Qty = null,
                        rate = null,
                        Amount = TotalAmnt,
                        STaxRate = null,
                        STaxAmount = SaleTotalAmnt,
                        ASTaxRate = null,
                        ASTaxAmount = AddSaleTaxTotalAmnt,
                        SExDutyRate = null,
                        SExDutyAmount = SExDutyTotalAmnt,
                        NetAmount = InvNetTotalAmnt
                    };
                    t.Add(TotalRow);
                    invoice_report_details = t as List<T>;
                    invoice.table = invoice_report_details;
                }
            }
            invoice.invDescLabel = "";//"This Quotation is Valid till: " + String.IsNullOrEmpty(inv_Master.m.QuoteValidDate.ToString()) ? DateTime.Now : inv_Master.m.QuoteValidDate;
            invoice.InvNetTotalAmnt = InvNetTotalAmnt.ToString();
            invoice.SaleTotalAmnt = SaleTotalAmnt == 0 ? "" : SaleTotalAmnt.ToString();
            invoice.AddSaleTaxTotalAmnt = AddSaleTaxTotalAmnt == 0 ? "" : AddSaleTaxTotalAmnt.ToString();
            invoice.SExDutyTotalAmnt = SExDutyTotalAmnt == 0 ? "" : SExDutyTotalAmnt.ToString();
            invoice.TotalAmntInWords = StandardVariables.ConvertNumberToWords(InvNetTotalAmnt);

            root.invoice = invoice;
            return root;
        }

        public Root<T> InvoiceReport<T> (string Id = "")
        {
            var root = new Root<T>();

            root = InvoiceReportList<T>(Id);

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


            //tbl.Add(invoice_report_details);
            Footer footer = new Footer();
            footer.text = "The invoice is created on a computer and is valid without the signature and stamp.";
            root.pageEnable=true;
            root.footer = footer;
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
                    var compDetail = context.CRM_SaleQuotationDetail.Where(x => x.QuoteId == Id).ToList();
                    var comp = context.CRM_SaleQuotation.Where(x => x.QuoteId == Id).FirstOrDefault();
                    context.CRM_SaleQuotationDetail.RemoveRange(compDetail);
                    context.CRM_SaleQuotation.Remove(comp);
                    context.SaveChanges();
                    flgCompany = true;
                }
            }
            return flgCompany;
        }
    }
}
