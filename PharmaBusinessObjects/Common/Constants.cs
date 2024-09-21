using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaBusinessObjects.Common
{
    public static class Constants
    {
        public static class Messages
        {
            public const string RequiredField = "Field is Required";
            public const string DeletePrompt = "Do you want to delete ?";
            public const string ClosePrompt = "Do you want to close ?";
            public const string SaveDataPrompt = "Do you want to save all data ?";
            public const string Confirmation = "Confirmation";
            public const string InValidEmail = "Please enter valid EmailId";
            public const string ErrorOccured = "Something went wrong";
            public const string PersonRouteCreate = "{0} does not exist. Do you want to add new {0} ?";
            public const string NotFound = "* Not Found ";
            public const string NotExists = "{0} does not exists. Do you want to add new?";
            public const string UnsavedDataWarning = "Unsaved data will be lost";
            public const string InValidDate = "Please enter valid date with format {DD/MM/YYYY}";
            public const string InValidCheque = "Please enter valid cheque number";
        }

        public static class Others
        {
            public const string Inactive = "Inactive";
        }

        public static class RecordType
        {
            public const string ASM = "ASM";
            public const string RSM = "RSM";
            public const string ZSM = "ZSM";
            public const string SALESMAN = "SALESMAN";
            public const string AREA = "AREA";
            public const string ROUTE = "ROUTE";
            public const string NONE = "NONE";

            public const string ASMDISPLAYNAME = "A.S.M";
            public const string RSMDISPLAYNAME = "R.S.M";
            public const string ZSMDISPLAYNAME = "Z.S.M";
            public const string SALESMANDISPLAYNAME = "Sales Man";
            public const string AREADISPLAYNAME = "Area";
            public const string ROUTEDISPLAYNAME = "Route";
            public const string NONEDISPLAYNAME = "NONE";
        }

        public static class AccountLedgerType
        {
            public const string IncomeLedger = "IncomeLedger";
            public const string ExpenditureLedger = "ExpenditureLedger";
            public const string TransactionBooks = "TransactionBooks";
            public const string GeneralLedger = "GeneralLedger";
            public const string PurchaseLedger = "PurchaseLedger";
            public const string SaleLedger = "SaleLedger";
            public const string ControlCodes = "ControlCodes";
        }

        public static class AccountLedgerTypeText
        {
            public const string IncomeLedger = "Income Ledger";
            public const string ExpenditureLedger = "Expenditure Ledger";
            public const string TransactionBooks = "Transaction Books";
            public const string GeneralLedger = "General Ledger";
            public const string PurchaseLedger = "Purchase Ledger";
            public const string SaleLedger = "Sale Ledger";
            public const string ControlCodes = "Control Codes";
        }

        public static class LedgerType
        {
            public const string CustomerLedger = "CUSTOMERLEDGER";
            public const string SupplierLedger = "SUPPLIERLEDGER";
        }

        public static class PurchaseTypeCode
        {
            public const string PurchaseType1 = "PUR0000001";
            public const string PurchaseType2 = "PUR0000002";
            public const string PurchaseType3 = "PUR0000003";
            public const string PurchaseType4 = "PUR0000004";
            public const string PurchaseType5 = "PUR0000005";
            public const string PurchaseType6 = "PUR0000006";
            public const string PurchaseType7 = "PUR0000007";
        }

        public static class VoucherTypeCode
        {
            public const string CREDITNOTE = "CREDITNOTE";
            public const string DEBITNOTE = "DEBITNOTE";
            public const string PURCHASEENTRY = "PURCHASEENTRY";
            public const string PURCHASERETURN = "PURCHASERETURN";
            public const string SALEENTRY = "SALEENTRY";
            public const string SALERETURN = "SALERETURN";
            public const string STOCKADUSTMENT = "STOCKADUSTMENT";
            public const string VOUCHERENTRY = "VOUCHERENTRY";
            public const string SALEONCHALLAN = "SALEONCHALLAN";
            public const string SALERETURNBREAKAGEEXPIRY = "SALERETURNBREAKAGEEXPIRY";
            public const string BREAKAGEEXPIRY = "BREAKAGEEXPIRY";
            public const string RECEIPTFROMCUSTOMER = "RECEIPTFROMCUSTOMER";
            public const string PAYMENTTOSUPPLIER = "PAYMENTTOSUPPLIER";
        }

        public static class PaymentMode
        {
            public const string CASH = "C";
            public const string CHEQUE = "Q";
            public const string ADJUST = "A";

            public const string CASHTEXT = "CASH";
            public const string CHEQUETEXT = "CHEQUE";
            public const string ADJUSTTEXT = "ADJUSTED";
        }

    }
}
