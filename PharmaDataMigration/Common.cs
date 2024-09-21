using System.Collections.Generic;

namespace PharmaDataMigration
{
    public class Common
    {
        public static PharmaBusinessObjects.Master.UserMaster LoggedInUser;
        public static string DataDirectory;// = @"F:\PHARMA\DATA\";
        public static List<CompanyCodeMap> companyCodeMap;
        public static List<ItemCodeMap> itemCodeMap;
        public static List<ASMCodeMap> asmCodeMap;
        public static List<RSMCodeMap> rsmCodeMap;
        public static List<ZSMCodeMap> zsmCodeMap;
        public static List<SalesManCodeMap> salesmanCodeMap;
        public static List<AreaCodeMap> areaCodeMap;
        public static List<RouteCodeMap> routeCodeMap;
        public static List<PersonalLedgerCodeMap> personalLedgerCodeMap;
        public static List<ControlCodeMap> controlCodeMap;
        public static List<AccountLedgerCodeMap> accountLedgerCodeMap;
        public static List<SupplierLedgerCodeMap> supplierLedgerCodeMap;
        public static List<CustomerLedgerCodeMap> customerLedgerCodeMap;
        public static List<VoucherTypeMap> voucherTypeMap;
        public static List<LedgerTypeMap> ledgerTypeMap;
        public static List<VoucherNumberMap> voucherNumberMap;
        public static List<ReceiptPaymentVoucherMap> receiptPaymentVoucherNumberMap;

    }

    public class ReceiptPaymentVoucherMap
    {
        public string OriginalVoucherNumber { get; set; }
        public string MappedVoucherNumber { get; set; }
        public long MappedReceiptPaymentID { get; set; }
       
        
    }

    public class VoucherNumberMap
    {
        public string OriginalVoucherNumber { get; set; }
        public string MappedVoucherNumber { get; set; }
        public long MappedPurchaseHeaderID { get; set; }
        public string LocalCentral { get; set; }
        public long BillOutstandingID { get; set; }
    }   

    public class LedgerTypeMap
    {
        public string OriginaLedgerType { get; set; }
        public string MappedLedgerType { get; set; }
    }

    public class VoucherTypeMap
    {
        public string OriginalVoucherType { get; set; }
        public string MappedVoucherType { get; set; }
    }

    public class CompanyCodeMap
    {
        public string OriginalCompanyCode { get; set; }
        public string MappedCompanyCode { get; set; }
    }

    public class ItemCodeMap
    {
        public string OriginalItemCode { get; set; }
        public string MappedItemCode { get; set; }
    }

    public class ASMCodeMap
    {
        public string OriginalASMCode { get; set; }
        public string MappedASMCode { get; set; }
    }

    public class RSMCodeMap
    {
        public string OriginalRSMCode { get; set; }
        public string MappedRSMCode { get; set; }
    }

    public class ZSMCodeMap
    {
        public string OriginalZSMCode { get; set; }
        public string MappedZSMCode { get; set; }
    }

    public class SalesManCodeMap
    {
        public string OriginalSalesManCode { get; set; }
        public string MappedSalesManCode { get; set; }
    }

    public class AreaCodeMap
    {
        public string OriginalAreaCode { get; set; }
        public string MappedAreaCode { get; set; }
    }

    public class RouteCodeMap
    {
        public string OriginalRouteCode { get; set; }
        public string MappedRouteCode { get; set; }
    }

    public class PersonalLedgerCodeMap
    {
        public string OriginalPersonalLedgerCode { get; set; }
        public string MappedPersonalLedgerCode { get; set; }
    }

    public class ControlCodeMap
    {
        public string OriginalControlCode { get; set; }
        public string MappedControlCode { get; set; }
    }

    public class AccountLedgerCodeMap
    {
        public string OriginalAccountLedgerCode { get; set; }
        public string MappedAccountLedgerCode { get; set; }
        public int AccountLedgerTypeID { get; set; }
        public string AccountLedgerName { get; set; }
    }

    public class SupplierLedgerCodeMap
    {
        public string OriginalSupplierLedgerCode { get; set; }
        public string MappedSupplierLedgerCode { get; set; }

        public string SupplierLedgerName { get; set; }
    }

    public class CustomerLedgerCodeMap
    {
        public string OriginalCustomerLedgerCode { get; set; }
        public string MappedCustomerLedgerCode { get; set; }
        public string CustomerLedgerName { get; set; }
    }
}
