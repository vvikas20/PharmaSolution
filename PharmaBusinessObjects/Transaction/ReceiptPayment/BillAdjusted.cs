using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaBusinessObjects.Transaction.ReceiptPayment
{
    public class BillAdjusted : BaseBusinessObjects
    {
        public long BillOutStandingsAudjustmentID { get; set; }
        public long ? PurchaseSaleBookHeaderID { get; set; }
        public string VoucherNumber { get; set; }
        public string VoucherTypeCode { get; set; }
        public System.DateTime VoucherDate { get; set; }
        public long ? ReceiptPaymentID { get; set; }
        public long BillOutStandingsID { get; set; }
        public string AdjustmentVoucherNumber { get; set; }
        public string AdjustmentVoucherTypeCode { get; set; }
        public System.DateTime AdjustmentVoucherDate { get; set; }
        public string LedgerType { get; set; }
        public string LedgerTypeCode { get; set; }
        public string InvoiceNumber { get; set; }
        public System.DateTime InvoiceDate { get; set; }
        public decimal? Amount { get; set; }
        public decimal OSAmount { get; set; }
        public string ChequeNumber { get; set; }
    }
}
