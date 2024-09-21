using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PharmaBusinessObjects.Transaction
{
    public class FifoBatches
    {
        public long FifoID { get; set; }
        public Nullable<long> PurchaseSaleBookHeaderID { get; set; }
        public string VoucherNumber { get; set; }
        public System.DateTime VoucherDate { get; set; }
        public int SRLNO { get; set; }
        public string ItemCode { get; set; }
        public string PurchaseBillNo { get; set; }
        public string Batch { get; set; }
        public Nullable<System.DateTime> ExpiryDate { get; set; }
        public decimal Quantity { get; set; }
        public decimal BalanceQuanity { get; set; }
        public Nullable<int> PurchaseTypeId { get; set; }
        public decimal PurchaseRate { get; set; }
        public Nullable<decimal> EffectivePurchaseRate { get; set; }
        public decimal SaleRate { get; set; }
        public Nullable<decimal> WholeSaleRate { get; set; }
        public Nullable<decimal> SpecialRate { get; set; }
        public decimal MRP { get; set; }
        public string Scheme { get; set; }
        public Nullable<decimal> Scheme1 { get; set; }
        public Nullable<decimal> Scheme2 { get; set; }
        public Nullable<bool> IsOnHold { get; set; }
        public string OnHoldRemarks { get; set; }
        public Nullable<System.DateTime> MfgDate { get; set; }
        public string UPC { get; set; }
    }
}
