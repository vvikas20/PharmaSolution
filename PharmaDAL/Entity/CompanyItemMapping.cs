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
    using System.Collections.Generic;
    
    public partial class CompanyItemMapping
    {
        public int ItemID { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public int CompanyID { get; set; }
        public string CompanyName { get; set; }
        public decimal BalanceQuantity { get; set; }
        public string CompanyCode { get; set; }
        public Nullable<decimal> ConversionRate { get; set; }
        public string ShortName { get; set; }
        public string Packing { get; set; }
        public Nullable<decimal> PurchaseRate { get; set; }
        public decimal MRP { get; set; }
        public Nullable<decimal> SaleRate { get; set; }
        public Nullable<decimal> SpecialRate { get; set; }
        public Nullable<decimal> WholeSaleRate { get; set; }
        public Nullable<decimal> SaleExcise { get; set; }
        public Nullable<decimal> SurchargeOnSale { get; set; }
        public Nullable<decimal> TaxOnSale { get; set; }
        public Nullable<decimal> Scheme1 { get; set; }
        public Nullable<decimal> Scheme2 { get; set; }
        public Nullable<decimal> PurchaseExcise { get; set; }
        public string UPC { get; set; }
        public bool IsHalfScheme { get; set; }
        public bool IsQTRScheme { get; set; }
        public Nullable<decimal> SpecialDiscount { get; set; }
        public Nullable<decimal> SpecialDiscountOnQty { get; set; }
        public bool IsFixedDiscount { get; set; }
        public Nullable<decimal> FixedDiscountRate { get; set; }
        public Nullable<decimal> MaximumQty { get; set; }
        public Nullable<decimal> MaximumDiscount { get; set; }
        public Nullable<decimal> SurchargeOnPurchase { get; set; }
        public Nullable<decimal> TaxOnPurchase { get; set; }
        public Nullable<decimal> DiscountRecieved { get; set; }
        public Nullable<decimal> SpecialDiscountRecieved { get; set; }
        public Nullable<decimal> QtyPerCase { get; set; }
        public string Location { get; set; }
        public Nullable<int> MinimumStock { get; set; }
        public Nullable<int> MaximumStock { get; set; }
        public int SaleTypeId { get; set; }
        public int PurchaseTypeId { get; set; }
        public bool Status { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public string BATCH { get; set; }
        public Nullable<System.DateTime> ExpiryDate { get; set; }
        public Nullable<decimal> OpeningQty { get; set; }
        public Nullable<decimal> ClosingQty { get; set; }
        public string SaltCode { get; set; }
        public string SaltName { get; set; }
        public string HSNCode { get; set; }
        public string PurchaseTypeCode { get; set; }
        public string PurchaseTypeName { get; set; }
        public Nullable<decimal> PurchaseTypeRate { get; set; }
    }
}
