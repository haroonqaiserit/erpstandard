using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPStandard.ViewModels
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class AdditionalRow
    {
        public string col1 { get; set; }
        public string col2 { get; set; }
        public string col3 { get; set; }
        public Style style { get; set; }
    }

    public class Business
    {
        public string name { get; set; }
        public string address { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string email_1 { get; set; }
        public string website { get; set; }
        public string STaxRegNo { get; set; } = "";
        public string NationalTaxNo { get; set; } = "";
        public string City { get; set; } = "";
    }

    public class Contact
    {
        public string label { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string website { get; set; }
        public string STaxRegNo { get; set; } = "";
        public string NationalTaxNo { get; set; } = "";
        public string City { get; set; } = "";
        public string otherInfo { get; set; }
    }

    public class Footer
    {
        public string text { get; set; }
    }

    public class Header
    {
        public string title { get; set; } 
        public string dataKey { get; set; }
        public Style style { get; set; }
    }

    public class InvoiceHeaders
    {
        //InvoiceDetails_ISTAX invoice = new InvoiceDetails_ISTAX();
        public List<Header> invoiceListHeaders(InvoiceType invoiceType)
        {
            List<Header> header_L = new List<Header>();
            Style style = new Style();
            Header header = new Header();
            //Header 1 Setting
            header_L = headersMasterlist();

            switch (invoiceType)
            {
                case InvoiceType.Invoice_Tax:
                    header_L.AddRange(headersMasterlist_SaleTax());
                    header_L.AddRange(headersMasterlist_NetAmt());
                    break;
                case InvoiceType.Invoice_Tax_AddTax:
                    header_L.AddRange(headersMasterlist_STax_AddSTax());
                    header_L.AddRange(headersMasterlist_NetAmt());
                    break;
                case InvoiceType.Invoice_Tax_SExDuty:
                    header_L.AddRange(headersMasterlist_STax_SEDuty());
                    header_L.AddRange(headersMasterlist_NetAmt());
                    break;
                case InvoiceType.Invoice_Tax_AddTax_SExDuty:
                    header_L.AddRange(headersMasterlist_STax_AddSTax_SEDuty());
                    header_L.AddRange(headersMasterlist_NetAmt());
                    break;
                default:
                    header_L = headersMasterlist();
                    break;
            }
            return header_L;
        }
        List<Header> headersMasterlist_NetAmt()
        {
            List<Header> header_L = new List<Header>();
            Style style = new Style();
            Header header = new Header();

            header = new Header();
            header.title = "Net Amt"; //9
            header.dataKey = "NetAmount";
            header.style = style;
            header_L.Add(header);

            return header_L;
        }
        List<Header> headersMasterlist_SaleTax(string STaxDisplayHead = "VAT")
        {
            List<Header> header_L = new List<Header>();
            Style style = new Style();
            Header header = new Header();

            header = new Header();
            header.title = STaxDisplayHead + "%"; //5
            header.dataKey = "STaxRate";
            header.style = style;
            header_L.Add(header);

            header = new Header();
            header.title = STaxDisplayHead + " Amt"; //6
            header.dataKey = "STaxAmount";
            header.style = style;
            header_L.Add(header);

            return header_L;
        }
        List<Header> headersMasterlist_STax_AddSTax()
        {
            List<Header> header_L = new List<Header>();
            Style style = new Style();
            Header header = new Header();

            header_L = headersMasterlist_SaleTax();

            header = new Header();
            header.title = "ASTax%"; //5
            header.dataKey = "ASTaxRate";
            header.style = style;
            header_L.Add(header);

            header = new Header();
            header.title = "ASTax Amt"; //6
            header.dataKey = "ASTaxAmount";
            header.style = style;
            header_L.Add(header);
            return header_L;
        }
        List<Header> headersMasterlist_STax_SEDuty()
        {
            List<Header> header_L = new List<Header>();
            Style style = new Style();
            Header header = new Header();

            header_L = headersMasterlist_SaleTax();

            header = new Header();
            header.title = "SED%"; //7
            header.dataKey = "SExDutyRate";
            header.style = style;
            header_L.Add(header);

            header = new Header();
            header.title = "SED Amt"; //8
            header.dataKey = "SExDutyAmount";
            header.style = style;
            header_L.Add(header);
            return header_L;
        }
        List<Header> headersMasterlist_STax_AddSTax_SEDuty()
        {
            List<Header> header_L = new List<Header>();
            Style style = new Style();
            Header header = new Header();

            header_L = headersMasterlist_STax_AddSTax();

            header = new Header();
            header.title = "SED%"; //7
            header.dataKey = "SExDutyRate";
            header.style = style;
            header_L.Add(header);

            header = new Header();
            header.title = "SED Amt"; //8
            header.dataKey = "SExDutyAmount";
            header.style = style;
            header_L.Add(header);
            return header_L;
        }
        List<Header> headersMasterlist()
        {
            List<Header> header_L = new List<Header>();
            Style style = new Style();
            Header header = new Header();
            //Header 1 Setting
            header.title = "Sr"; //1
            style.width = 5;
            header.dataKey = "serialnum";
            header.style = style;
            header_L.Add(header);

            header = new Header();
            header.title = "Description"; //2
            header.dataKey = "Item";
            style.width = 30;
            header.style = style;
            header_L.Add(header);

            //Header 3 Setting
            header = new Header();
            header.title = "Qty";  //3
            header.dataKey = "Qty";
            header.style = style;
            header_L.Add(header);

            //Header 3 Setting
            header = new Header();
            header.title = "Rate"; //4
            header.dataKey = "rate";
            header.style = style;
            header_L.Add(header);

            header = new Header();
            header.title = "Amount"; //9
            header.dataKey = "Amount";
            header.style = style;
            header_L.Add(header);
            return header_L;
        }

    }

    public class Invoice<T>
    {
        public string label { get; set; }
        public string num { get; set; }
        public string invDate { get; set; }
        public string ValidDate { get; set; }
        public string invGenDate { get; set; }
        public bool headerBorder { get; set; }
        public bool tableBodyBorder { get; set; }
        public List<Header> header { get; set; }
        public List<T> table { get; set; }
        public List<AdditionalRow> additionalRows { get; set; }
        public string invDescLabel { get; set; }
        public string invDesc { get; set; }
        public double InvNetlAmount { get; set; }
        public double DeliveryCharges { get; set; }
        public string RefDocId { get; set; }
        public string RefDocName { get; set; }
        public string InvNetTotalAmnt { get; set; }
        public string SaleTotalAmnt { get; set; }
        public string AddSaleTaxTotalAmnt { get; set; }
        public string SExDutyTotalAmnt { get; set; }
        public string TotalAmntInWords { get; set; }

    }

    public class Logo
    {
        public string src { get; set; }
        public double width { get; set; }
        public double height { get; set; }
        public Margin margin { get; set; }
    }

    public class Margin
    {
        public int top { get; set; }
        public int left { get; set; }
    }

    //const jsPDFInvoiceTemplate.OutputType.Save;
    public class Root<T>
    {
        public string outputType { get; set; } = "jsPDFInvoiceTemplate.OutputType.Save";
        public bool returnJsPDFDocObject { get; set; } = true;
        public string fileName { get; set; } = "Invoice";
        public bool orientationLandscape { get; set; } = false;
        public bool compress { get; set; } = true;
        public Logo logo { get; set; }
        public Stamp stamp { get; set; }
        public Business business { get; set; }
        public Contact contact { get; set; }
        public Invoice<T> invoice { get; set; }
        public Footer footer { get; set; }
        public bool pageEnable { get; set; }
        public string pageLabel { get; set; }
        public string DisplayCurrency { get; set; } = "Rs.";
        public string SoftwareCompanyDisplayText { get; set; } = "System Generated Report by Finanical Pro®";
    }

    public class Stamp
    {
        public bool inAllPages { get; set; }
        public string src { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public Margin margin { get; set; }
    }

    public class Style
    {
        public int width { get; set; }
        public int fontSize { get; set; }
    }
}

