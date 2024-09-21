using PharmaBusinessObjects.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaBusinessObjects.Master
{
    public class CustomerLedgerMaster : BaseBusinessObjects
    {
        public string ZSMName { get; set; }
        public string SalesmanName { get; set; }
        public string RSMName { get; set; }
        public string RouteName { get; set; }
        public string RateTypeName { get; set; }
        public string InterestTypeName { get; set; }
        public string CustomerTypeName { get; set; }
        public string ASMName { get; set; }
        public string AreaName { get; set; }

        public int CustomerLedgerId { get; set; }
        public string CustomerLedgerCode { get; set; }
        public string CustomerLedgerName { get; set; }
        public string CustomerLedgerShortName { get; set; }
        public string Address { get; set; }
        public string ContactPerson { get; set; }
        public string Telephone { get; set; }
        public string Mobile { get; set; }
        public string OfficePhone { get; set; }
        public string ResidentPhone { get; set; }
        public string EmailAddress { get; set; }
        public  decimal ? OpeningBal { get; set; }
        public string CreditDebit { get; set; }
        public string TaxRetail { get; set; }
        public bool Status { get; set; }
        public  int ? ZSMId { get; set; }
        public  int ? ASMId { get; set; }
        public  int ? RSMId { get; set; }
        public  int ? AreaId { get; set; }
        public  int ? SalesManId { get; set; }
        public  int ? RouteId { get; set; }
        public string DLNo { get; set; }
        public string GSTNo { get; set; }
        public string CINNo { get; set; }
        public string LINNo { get; set; }
        public string ServiceTaxNo { get; set; }
        public string PANNo { get; set; }
        public int CreditLimit { get; set; }
        public  int ? RateTypeID { get; set; }
        public bool IsLessExcise { get; set; }
        public int CustomerTypeID { get; set; }
        public int InterestTypeID { get; set; }
        public decimal ?  MaxOSAmount { get; set; }
        public  int ? MaxNumOfOSBill { get; set; }
        public decimal ?  MaxBillAmount { get; set; }
        public  int ? MaxGracePeriod { get; set; }
        public string SaleBillFormat { get; set; }
        public bool IsFollowConditionStrictly { get; set; }
        public decimal ?  Discount { get; set; }
        public string CentralLocal { get; set; }
        public List<CustomerCopanyDiscount> CustomerCopanyDiscountList { get; set; }
        public string StatusText { get; set; }       

        #region SaleEntry
        public string SalesManCode { get; set; }
        public double? DueBillAmount { get; set; }
        public int DueBillCount { get; set; }
        #endregion

    }
}
