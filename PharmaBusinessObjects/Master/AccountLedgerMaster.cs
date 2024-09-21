using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaBusinessObjects.Master
{
    public class AccountLedgerMaster : BaseBusinessObjects
    {
        public int AccountLedgerID { get; set; }
        public string AccountLedgerCode { get; set; }
        public string AccountLedgerName { get; set; }       
        public int AccountLedgerTypeId { get; set; }
        public string AccountLedgerType { get; set; }
        public string AccountLedgerTypeSystemName { get; set; }
        public decimal OpeningBalance { get; set; }
        public string CreditDebit { get; set; }
        public int AccountTypeId { get; set; }
        public string AccountType { get; set; }
        public int? DebitControlCodeID { get; set; }
        public string DebitControlCode { get; set; }
        public int? CreditControlCodeID { get; set; }
        public string CreditControlCode { get; set; }
        public bool Status { get; set; }
        public string StatusText { get; set; }
        

        public decimal? SalePurchaseTaxValue{ get; set; }


        public List<Common.AccountLedgerType> AccountLedgerTypeList { get; set; }
        public List<Common.AccountType> AccountTypeList { get; set; }
        public List<Common.AccountLedgerType> CreditControlCodeList { get; set; }
        public List<Common.AccountLedgerType> DebitControlCodeList { get; set; }
    }
}
