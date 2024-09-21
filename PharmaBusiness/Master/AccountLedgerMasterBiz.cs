using PharmaBusiness.Common;
using PharmaDAL.Common;
using PharmaDAL.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaBusiness.Master
{
    internal class AccountLedgerMasterBiz : BaseBiz
    {
        public AccountLedgerMasterBiz(PharmaBusinessObjects.Master.UserMaster loggedInUser) : base(loggedInUser)
        {

        }

        internal List<PharmaBusinessObjects.Master.AccountLedgerMaster> GetAccountLedgers()
        {

            CommonDao commonDao = new CommonDao();

            var accountLedgerMasterList = new AccountLedgerMasterDao(this.LoggedInUser).GetAccountLedgers();

            var accountLedgerTypeList = commonDao.GetAccountLedgerTypes() ?? new List<PharmaBusinessObjects.Common.AccountLedgerType>();
            var AccountTypeList = new CommonBiz().GetAccountTypes() ?? new List<PharmaBusinessObjects.Common.AccountType>();
            var creditControlCodeList = commonDao.GetAccountLedgerTypes().Where(p => p.AccountLedgerTypeSystemName == "ControlCodes").ToList() ?? new List<PharmaBusinessObjects.Common.AccountLedgerType>();
            var debitControlCodeList = commonDao.GetAccountLedgerTypes().Where(p => p.AccountLedgerTypeSystemName == "ControlCodes").ToList() ?? new List<PharmaBusinessObjects.Common.AccountLedgerType>();


            foreach (var accountLedger in accountLedgerMasterList)
            {
                accountLedger.AccountLedgerTypeList = accountLedgerTypeList ?? new List<PharmaBusinessObjects.Common.AccountLedgerType>();
                accountLedger.AccountTypeList = AccountTypeList ?? new List<PharmaBusinessObjects.Common.AccountType>();
                accountLedger.CreditControlCodeList = creditControlCodeList ?? new List<PharmaBusinessObjects.Common.AccountLedgerType>();
                accountLedger.DebitControlCodeList = debitControlCodeList ?? new List<PharmaBusinessObjects.Common.AccountLedgerType>();
            }

            return accountLedgerMasterList;
        }

        internal PharmaBusinessObjects.Master.AccountLedgerMaster GetAccountLedgerById(int accountLedgerID)
        {
            CommonDao commonDao = new CommonDao();

            PharmaBusinessObjects.Master.AccountLedgerMaster accountLedger =  new AccountLedgerMasterDao(this.LoggedInUser).GetAccountLedgerById(accountLedgerID);
            accountLedger.AccountLedgerTypeList = commonDao.GetAccountLedgerTypes() ?? new List<PharmaBusinessObjects.Common.AccountLedgerType>();
            accountLedger.AccountTypeList = new CommonBiz().GetAccountTypes() ?? new List<PharmaBusinessObjects.Common.AccountType>();
            accountLedger.CreditControlCodeList = commonDao.GetAccountLedgerTypes().Where(p => p.AccountLedgerTypeSystemName == "ControlCodes").ToList() ?? new List<PharmaBusinessObjects.Common.AccountLedgerType>();
            accountLedger.DebitControlCodeList = commonDao.GetAccountLedgerTypes().Where(p => p.AccountLedgerTypeSystemName == "ControlCodes").ToList() ?? new List<PharmaBusinessObjects.Common.AccountLedgerType>();


            return accountLedger;
        }

        internal int AddAccountLedger(PharmaBusinessObjects.Master.AccountLedgerMaster p)
        {
            return new AccountLedgerMasterDao(this.LoggedInUser).AddAccountLedger(p);
        }

        internal int UpdateAccountLedger(PharmaBusinessObjects.Master.AccountLedgerMaster p)
        {
            return new AccountLedgerMasterDao(this.LoggedInUser).UpdateAccountLedger(p);
        }

        internal List<PharmaBusinessObjects.Master.AccountLedgerMaster> GetAccountLedgerByLedgerTypeIdAndSearch(int ledgerTypeID, string searchString = null)
        {
            CommonDao commonDao = new CommonDao();

            var accountLedgerMasterList = new AccountLedgerMasterDao(this.LoggedInUser).GetAccountLedgerByLedgerTypeIdAndSearch(ledgerTypeID,searchString);

            var accountLedgerTypeList = commonDao.GetAccountLedgerTypes() ?? new List<PharmaBusinessObjects.Common.AccountLedgerType>();
            var AccountTypeList = new CommonBiz().GetAccountTypes() ?? new List<PharmaBusinessObjects.Common.AccountType>();
            var creditControlCodeList = commonDao.GetAccountLedgerTypes().Where(p => p.AccountLedgerTypeSystemName == "ControlCodes").ToList() ?? new List<PharmaBusinessObjects.Common.AccountLedgerType>();
            var debitControlCodeList = commonDao.GetAccountLedgerTypes().Where(p => p.AccountLedgerTypeSystemName == "ControlCodes").ToList() ?? new List<PharmaBusinessObjects.Common.AccountLedgerType>();

            foreach (var accountLedger in accountLedgerMasterList)
            {
                accountLedger.AccountLedgerTypeList = accountLedgerTypeList ?? new List<PharmaBusinessObjects.Common.AccountLedgerType>();
                accountLedger.AccountTypeList = AccountTypeList ?? new List<PharmaBusinessObjects.Common.AccountType>();
                accountLedger.CreditControlCodeList = creditControlCodeList ?? new List<PharmaBusinessObjects.Common.AccountLedgerType>();
                accountLedger.DebitControlCodeList = debitControlCodeList ?? new List<PharmaBusinessObjects.Common.AccountLedgerType>();
            }

            return accountLedgerMasterList; 
        }

        internal List<PharmaBusinessObjects.Master.AccountLedgerMaster> GetAccountLedgerBySystemName(string systemName)
        {

            var accountLedgerMasterList = new AccountLedgerMasterDao(this.LoggedInUser).GetAccountLedgers().Where(p=>p.AccountLedgerTypeSystemName == systemName).ToList();          
            return accountLedgerMasterList;
        }

        internal PharmaBusinessObjects.Master.AccountLedgerMaster GetAccountLedgerByCode(string code)
        {
            return new AccountLedgerMasterDao(this.LoggedInUser).GetAccountLedgerByCode(code);
        }
        }
}
