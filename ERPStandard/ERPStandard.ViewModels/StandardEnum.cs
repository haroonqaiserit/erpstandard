using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPStandard.ViewModels
{
    public enum CustomerEnum
    {
        CRMCustomer = 0,
        SalesCustomer = 1
    }
    public enum ItemClass
    {
        FinishGoods = 1,
        RawMaterial = 2,
        ToolAndSpares =3
    }
    public enum InvoiceType
    {
        Invoice_Simple=0,
        Invoice_Tax=1,
        Invoice_Tax_AddTax=2,
        Invoice_Tax_SExDuty=3,
        Invoice_Tax_AddTax_SExDuty=4
    }
}
