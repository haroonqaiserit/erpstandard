using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPStandard.ViewModels
{
    public class InvoiceTemplateViewModel
    {
        public Root root { get; set; }
        public Logo logo { get; set; }
        public Stamp stamp { get; set; }
        public Business business { get; set; }
        public Contact contact { get; set; }
        public Invoice invoice { get; set; }
        public Header header { get; set; }
        public AdditionalRow additionalRow { get; set; }
        public Footer footer { get; set; }
        public Margin margin { get; set; }
        public Style style { get; set; }
    }

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
    }

    public class Contact
    {
        public string label { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string otherInfo { get; set; }
    }

    public class Footer
    {
        public string text { get; set; }
    }

    public class Header
    {
        public string title { get; set; }
        public Style style { get; set; }
    }

    public class Invoice
    {
        public string label { get; set; }
        public int num { get; set; }
        public string invDate { get; set; }
        public string invGenDate { get; set; }
        public bool headerBorder { get; set; }
        public bool tableBodyBorder { get; set; }
        public List<Header> header { get; set; }
        public List<List<InvoiceReportDetails>> table { get; set; }
        public List<AdditionalRow> additionalRows { get; set; }
        public string invDescLabel { get; set; }
        public string invDesc { get; set; }
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
    public class Root
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
        public Invoice invoice { get; set; }
        public Footer footer { get; set; }
        public bool pageEnable { get; set; }
        public string pageLabel { get; set; }
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
