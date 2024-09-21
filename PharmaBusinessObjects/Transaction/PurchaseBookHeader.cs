using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaBusinessObjects.Transaction
{
    public class PurchaseSaleBookHeader : BaseBusinessObjects
    {

        public long PurchaseSaleBookHeaderID { get; set; }
        public string VoucherTypeCode { get; set; }
        public DateTime VoucherDate { get; set; }
        public DateTime? DueDate { get; set; }
        public string PurchaseBillNo { get; set; }
        public string LedgerType { get; set; }
        public string LedgerTypeCode { get; set; }
        public decimal? Amount01 { get; set; }
        public decimal? Amount02 { get; set; }
        public decimal? Amount03 { get; set; }
        public decimal? Amount04 { get; set; }
        public decimal? Amount05 { get; set; }
        public decimal? Amount06 { get; set; }
        public decimal? Amount07 { get; set; }
        public decimal? SGST01 { get; set; }
        public decimal? SGST02 { get; set; }
        public decimal? SGST03 { get; set; }
        public decimal? SGST04 { get; set; }
        public decimal? SGST05 { get; set; }
        public decimal? SGST06 { get; set; }
        public decimal? SGST07 { get; set; }
        public decimal? IGST01 { get; set; }
        public decimal? IGST02 { get; set; }
        public decimal? IGST03 { get; set; }
        public decimal? IGST04 { get; set; }
        public decimal? IGST05 { get; set; }
        public decimal? IGST06 { get; set; }
        public decimal? IGST07 { get; set; }
        public decimal? CGST01 { get; set; }
        public decimal? CGST02 { get; set; }
        public decimal? CGST03 { get; set; }
        public decimal? CGST04 { get; set; }
        public decimal? CGST05 { get; set; }
        public decimal? CGST06 { get; set; }
        public decimal? CGST07 { get; set; }
        public decimal TotalTaxAmount { get; set; }
        public decimal? SurchargeAmount { get; set; }
        public decimal? TotalBillAmount { get; set; }
        public decimal? TotalCostAmount { get; set; }
        public decimal? TotalGrossAmount { get; set; }
        public decimal? TotalSchemeAmount { get; set; }
        public decimal? TotalDiscountAmount { get; set; }
        public decimal? OtherAmount { get; set; }
        public string FreshBreakageExcess { get; set; }
        public string ReturnBillNo { get; set; }
        public Nullable<System.DateTime> ReturBillDate { get; set; }
        public Nullable<int> CustomerTypeId { get; set; }
        public string LocalCentral { get; set; }
        public string OrderNumber { get; set; }
        public string ChallanNumber { get; set; }
        public string Message { get; set; }
        public string Deliveryddress { get; set; }
        public string DeliveredBy { get; set; }
        public string CourierName { get; set; }
        public Nullable<System.DateTime> CourierDate { get; set; }
        public decimal? CourierWeight { get; set; }
        public Nullable<int> PurchaseEntryFormID { get; set; }
        public decimal? LastBalance { get; set; }

        //public Nullable<int> ZSMId { get; set; }
        //public Nullable<int> ASMId { get; set; }
        //public Nullable<int> RSMId { get; set; }
        //public Nullable<int> AreaId { get; set; }
        public Nullable<int> SalesManId { get; set; }
        //public Nullable<int> RouteId { get; set; }

        public Nullable<long> OldPurchaseSaleBookHeaderID { get; set; }
        public long? SaleChallanHeaderID { get; set; }

    }

    public class PurchaseBookAmount : BaseBusinessObjects
    {
        public long PurchaseBookHeaderID { get; set; }
        public string PurchaseSaleTypeCode { get; set; }
        public string PurchaseSaleTypeName { get; set; }
        public decimal Amount { get; set; }
        public decimal IGST { get; set; }
        public decimal SGST { get; set; }
        public decimal CGST { get; set; }
        public decimal TaxApplicable { get; set; }
        public long PurchaseSaleBookLineItemID { get; set; }
        public decimal BillAmount { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal CostAmount { get; set; }
        public decimal GrossAmount { get; set; }
        public decimal SchemeAmount { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal SpecialDiscountAmount { get; set; }
        public decimal VolumeDiscountAmount { get; set; }
        public decimal TotalDiscountAmount { get; set; }       
    }



}
