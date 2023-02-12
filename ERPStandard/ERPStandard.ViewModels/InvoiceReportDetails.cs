using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPStandard.ViewModels
{
    #region Sales Invoice
    public interface ISTAX
    {
        decimal? STaxRate { get; set; }
        decimal? STaxAmount { get; set; }
    }
    public interface IASTAX
    {
        decimal? ASTaxRate { get; set; }
        decimal? ASTaxAmount { get; set; }
    }
    public interface ISExDuty
    {
        decimal? SExDutyRate { get; set; }
        decimal? SExDutyAmount { get; set; }
    }
    public interface IDis
    {
        decimal? DiscountRate { get; set; }
        decimal? DiscountAmount { get; set; }
    }
    public class InvoiceDetails
    {
        public int? serialnum { get; set; }
        public string Item { get; set; }
        public decimal? Qty { get; set; }
        public decimal? rate { get; set; }
        public decimal Amount { get; set; }
        public decimal NetAmount { get; set; }
    }
    public class InvoiceDetails_IDis : InvoiceDetails, IDis
    {
        public decimal? DiscountRate { get; set; }
        public decimal? DiscountAmount { get; set; }
    }
    public class InvoiceDetails_ISTAX : InvoiceDetails, ISTAX
    {
        public decimal? STaxRate { get; set; }
        public decimal? STaxAmount { get; set; }
    }
    public class InvoiceDetails_ISTAX_IDis : InvoiceDetails, ISTAX, IDis
    {
        public decimal? STaxRate { get; set; }
        public decimal? STaxAmount { get; set; }
        public decimal? DiscountRate { get; set; }
        public decimal? DiscountAmount { get; set; }
    }
    public class InvoiceDetails_ISTAX_IASTAX : InvoiceDetails, ISTAX, IASTAX
    {
        public decimal? STaxRate { get; set; }
        public decimal? STaxAmount { get; set; }
        public decimal? ASTaxRate { get; set; }
        public decimal? ASTaxAmount { get; set; }
    }
    public class InvoiceDetails_ISTAX_ISExDuty : InvoiceDetails, ISTAX, ISExDuty
    {
        public decimal? STaxRate { get; set; }
        public decimal? STaxAmount { get; set; }
        public decimal? SExDutyRate { get; set; }
        public decimal? SExDutyAmount { get; set; }
    }
    public class InvoiceDetails_ISTAX_IASTAX_ISExDuty : InvoiceDetails, ISTAX, IASTAX, ISExDuty
    {
        public decimal? STaxRate { get; set; }
        public decimal? STaxAmount { get; set; }
        public decimal? ASTaxRate { get; set; }
        public decimal? ASTaxAmount { get; set; }
        public decimal? SExDutyRate { get; set; }
        public decimal? SExDutyAmount { get; set; }
    }
    public class InvoiceDetails_ISTAX_IASTAX_ISExDuty_IDis : InvoiceDetails, ISTAX, IASTAX, ISExDuty, IDis
    {
        public decimal? STaxRate { get; set; }
        public decimal? STaxAmount { get; set; }
        public decimal? ASTaxRate { get; set; }
        public decimal? ASTaxAmount { get; set; }
        public decimal? SExDutyRate { get; set; }
        public decimal? SExDutyAmount { get; set; }
        public decimal? DiscountRate { get; set; }
        public decimal? DiscountAmount { get; set; }
    }
    #endregion Sales Invoice

    #region Purchase
    #region Purchase Requsition Order
    public class PurReqOrderDetails
    {
        public int? serialnum { get; set; }
        public string ItemID { get; set; }
        public string Item { get; set; }
        public string GRNID { get; set; }
        public string LDate { get; set; }
        public DateTime? L_Date { get; set; }
        public decimal? LQty { get; set; }
        public decimal? LRate { get; set; }
        public decimal? EstRate { get; set; }
        public decimal? StockQty { get; set; }
        public decimal Qty { get; set; }
        public string UOM { get; set; }
        public decimal? Amount { get; set; }
        public string UnitName { get; set; }
        public string RequiredDate { get; set; }
        public DateTime? Required_Date { get; set; }
        public string DemandPerson { get; set; }
        public string ApprovedStatus { get; set; }
            }
    #endregion
    #endregion Purchase

}