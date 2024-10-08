//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PharmaDAL.Entity
{
    using System;
    
    public partial class GetPurchaseSaleBookLineItemsForModify_Result
    {
        public long PurchaseSaleBookHeaderID { get; set; }
        public long PurchaseSaleBookLineItemID { get; set; }
        public Nullable<long> FifoID { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string Batch { get; set; }
        public string BatchNew { get; set; }
        public Nullable<System.DateTime> PurchaseBillDate { get; set; }
        public string PurchaseVoucherNumber { get; set; }
        public Nullable<int> PurchaseSrlNo { get; set; }
        public decimal Quantity { get; set; }
        public Nullable<decimal> FreeQuantity { get; set; }
        public decimal PurchaseSaleRate { get; set; }
        public Nullable<decimal> EffecivePurchaseSaleRate { get; set; }
        public string PurchaseSaleTypeCode { get; set; }
        public Nullable<decimal> SurCharge { get; set; }
        public Nullable<decimal> PurchaseSaleTax { get; set; }
        public string LocalCentral { get; set; }
        public Nullable<decimal> SGST { get; set; }
        public Nullable<decimal> IGST { get; set; }
        public Nullable<decimal> CGST { get; set; }
        public decimal Amount { get; set; }
        public Nullable<decimal> Discount { get; set; }
        public Nullable<decimal> SpecialDiscount { get; set; }
        public Nullable<decimal> DiscountQuantity { get; set; }
        public Nullable<decimal> VolumeDiscount { get; set; }
        public Nullable<decimal> Scheme1 { get; set; }
        public Nullable<decimal> Scheme2 { get; set; }
        public bool IsHalfScheme { get; set; }
        public Nullable<decimal> HalfSchemeRate { get; set; }
        public Nullable<decimal> CostAmount { get; set; }
        public Nullable<decimal> GrossAmount { get; set; }
        public Nullable<decimal> SchemeAmount { get; set; }
        public Nullable<decimal> DiscountAmount { get; set; }
        public Nullable<decimal> SurchargeAmount { get; set; }
        public Nullable<decimal> ConversionRate { get; set; }
        public Nullable<decimal> MRP { get; set; }
        public System.DateTime ExpiryDate { get; set; }
        public Nullable<decimal> SaleRate { get; set; }
        public Nullable<decimal> WholeSaleRate { get; set; }
        public Nullable<decimal> SpecialRate { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public Nullable<decimal> TaxAmount { get; set; }
        public Nullable<decimal> SpecialDiscountAmount { get; set; }
        public Nullable<decimal> VolumeDiscountAmount { get; set; }
        public Nullable<decimal> TotalDiscountAmount { get; set; }
        public Nullable<long> OldPurchaseSaleBookLineItemID { get; set; }
        public decimal BalanceQuantity { get; set; }
        public decimal UsedQuantity { get; set; }
    }
}
