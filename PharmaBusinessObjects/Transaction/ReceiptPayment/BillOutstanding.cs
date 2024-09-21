using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaBusinessObjects.Transaction.ReceiptPayment
{
    public class BillOutstanding : BaseBusinessObjects
    {
        public long BillOutStandingsID { get; set; }
        public long PurchaseSaleBookHeaderID { get; set; }
        public string VoucherNumber { get; set; }
        public string VoucherTypeCode { get; set; }
        public System.DateTime VoucherDate { get; set; }
        public string InvoiceNumber { get; set; }
        public System.DateTime InvoiceDate { get; set; }
        public string LedgerType { get; set; }
        public string LedgerTypeCode { get; set; }
        public decimal BillAmount { get; set; }
        public decimal OSAmount { get; set; }
        public bool ? IsHold { get; set; }
        public string HOLDRemarks { get; set; }
    }
}
