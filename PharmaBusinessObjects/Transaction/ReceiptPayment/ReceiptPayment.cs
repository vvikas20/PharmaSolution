using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaBusinessObjects.Transaction.ReceiptPayment
{
    public class ReceiptPaymentItem : BaseBusinessObjects
    {
        public long ReceiptPaymentID { get; set; }
        public long OldReceiptPaymentID { get; set; }

        public string VoucherNumber { get; set; }
        public string VoucherTypeCode { get; set; }
        public System.DateTime VoucherDate { get; set; }
        public string LedgerType { get; set; }
        public string LedgerTypeCode { get; set; }
        public string LedgerTypeName { get; set; }
        public string PaymentMode { get; set; }
        public decimal ? Amount { get; set; }
        public string ChequeNumber { get; set; }
        public string BankAccountLedgerTypeCode { get; set; }
        public string BankAccountLedgerTypeName { get; set; }
        public System.DateTime ? ChequeDate { get; set; }
        public System.DateTime ? ChequeClearDate { get; set; }
        public bool ? IsChequeCleared { get; set; }
        public string POST { get; set; }
        public string PISNumber { get; set; }
        public decimal? UnadjustedAmount { get; set; }
        public decimal? ConsumedAmount { get; set; }
    }
}
