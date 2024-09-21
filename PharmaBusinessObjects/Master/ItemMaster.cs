using PharmaBusinessObjects.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaBusinessObjects.Master
{
    public class ItemMaster : BaseBusinessObjects
    {
        public int ItemID { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public int CompanyID { get; set; }
        public string CompanyCode { get; set; }
        public string CompanyName { get; set; }
        public decimal? ConversionRate { get; set; }
        public string ShortName { get; set; }
        public string Packing { get; set; }
        public decimal? PurchaseRate { get; set; }
        public decimal MRP { get; set; }
        public decimal? SaleRate { get; set; }
        public decimal? SpecialRate { get; set; }
        public decimal? WholeSaleRate { get; set; }
        public decimal? SaleExcise { get; set; }
        public decimal? SurchargeOnSale { get; set; }
        public decimal? TaxOnSale { get; set; }
        public decimal? Scheme1 { get; set; }
        public decimal? Scheme2 { get; set; }
        public decimal? PurchaseExcise { get; set; }
        public string UPC { get; set; }
        public bool IsHalfScheme { get; set; }
        public bool IsQTRScheme { get; set; }
        public decimal? SpecialDiscount { get; set; }
        public decimal? SpecialDiscountOnQty { get; set; }
        public bool IsFixedDiscount { get; set; }
        public decimal? FixedDiscountRate { get; set; }
        public decimal? MaximumQty { get; set; }
        public decimal? MaximumDiscount { get; set; }
        public decimal? SurchargeOnPurchase { get; set; }
        public decimal? TaxOnPurchase { get; set; }
        public decimal? DiscountRecieved { get; set; }
        public decimal? SpecialDiscountRecieved { get; set; }
        public decimal? QtyPerCase { get; set; }
        public string Location { get; set; }
        public int? MinimumStock { get; set; }
        public int? MaximumStock { get; set; }
        public int SaleTypeId { get; set; }
        public bool Status { get; set; }
        public string StatusText { get; set; }
        public int PurchaseTypeId { get; set; }
        public string PurchaseTypeCode { get; set; }
        public string PurchaseTypeName { get; set; }
        public decimal? PurchaseTypeRate { get; set; }
        public string HSNCode { get; set; }


        public PurchaseSaleBookLineItem ToPurchaseBookLineItem()
        {
            PurchaseSaleBookLineItem lineItem = new PurchaseSaleBookLineItem();
            lineItem.ItemCode = this.ItemCode;
            lineItem.ItemName = this.ItemName;
            lineItem.Quantity = 0;
            lineItem.IsHalfScheme = this.IsHalfScheme;
            lineItem.MRP = this.MRP;
            lineItem.Scheme1 = this.Scheme1 == null ? 0 : Convert.ToInt32(this.Scheme1);
            lineItem.Scheme2 = this.Scheme2 == null ? 0 : Convert.ToInt32(this.Scheme2);
            lineItem.Discount = this.DiscountRecieved ?? 0L;
            lineItem.SpecialDiscount = this.SpecialDiscountRecieved ?? 0L;
            lineItem.VolumeDiscount = 0L;
            lineItem.MRP = this.MRP;          
            lineItem.FreeQuantity = 0;
            lineItem.SpecialRate = this.SpecialRate ?? 0L;
            lineItem.WholeSaleRate = this.WholeSaleRate ?? 0L;
            lineItem.SaleRate = this.SaleRate ?? 0L;
            lineItem.PurchaseSaleTypeCode = this.PurchaseTypeCode;
            decimal val = 0L;
            decimal.TryParse(Convert.ToString(this.PurchaseTypeRate), out val);
            lineItem.PurchaseSaleTax = val;
            lineItem.PurchaseSaleRate = (decimal)this.PurchaseRate;
            lineItem.OldPurchaseSaleRate = lineItem.PurchaseSaleRate;
            return lineItem;
        }
    }
    
}
