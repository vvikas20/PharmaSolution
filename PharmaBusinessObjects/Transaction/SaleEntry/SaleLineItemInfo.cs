using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaBusinessObjects.Transaction.SaleEntry
{
    public class SaleLineItemInfo
    {
        public decimal Balance { get; set; }
        public string Packing { get; set; }
        public string SaleType { get; set; }
        public decimal InvAmount { get; set; }
        public decimal Scheme1 { get; set; }
        public decimal Scheme2 { get; set; }
        public bool IsHalf { get; set; }
        public decimal CaseQty { get; set; }
        public decimal Discount { get; set; }
        public decimal Surcharge { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal HalfAmount { get; set; }
        public LastBillInfo LastBillInfo { get; set; }
    }

    public class LastBillInfo
    {
        public DateTime BillDate { get; set; }
        public decimal Rate { get; set; }
        public decimal Discount { get; set; }
        public decimal SpecialDiscount { get; set; }
        public decimal Tax { get; set; }
        public string Batch { get; set; }
        public decimal Scheme1 { get; set; }
        public decimal Scheme2 { get; set; }
    }
}
