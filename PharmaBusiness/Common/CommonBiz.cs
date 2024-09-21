using PharmaDAL.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaBusiness.Common
{
    class CommonBiz
    {
        public List<PharmaBusinessObjects.Common.AccountType> GetAccountTypes()
        {
            List<PharmaBusinessObjects.Common.AccountType> accountTypes = new CommonDao().GetAccountTypes();

            foreach (var accountType in accountTypes)
            {
                accountType.AccountTypeDisplayName = accountType.AccountTypeShortName + " - " + accountType.AccountTypeName;
            }

            return accountTypes;
        }

        public List<PharmaBusinessObjects.Common.AccountLedgerType> GetAccountLedgerTypes()
        {
            return new CommonDao().GetAccountLedgerTypes();
        }

        public List<PharmaBusinessObjects.Common.AccountLedgerType> GetAccountLedgerTypesWithAll()
        {
            var accountLedgerTypes = new CommonDao().GetAccountLedgerTypes() ?? new List<PharmaBusinessObjects.Common.AccountLedgerType>(); ;

            accountLedgerTypes.Insert(0, new PharmaBusinessObjects.Common.AccountLedgerType() { AccountLedgerTypeID = 0, AccountLedgerTypeName = "All" });

            return accountLedgerTypes;
        }

        public PharmaBusinessObjects.Common.AccountLedgerType GetAccountLedgerTypeByName(string name)
        {
            var accountLedgerTypes = new CommonDao().GetAccountLedgerTypes() ?? new List<PharmaBusinessObjects.Common.AccountLedgerType>(); ;
            PharmaBusinessObjects.Common.AccountLedgerType accountLedger = accountLedgerTypes.FirstOrDefault(p => p.AccountLedgerTypeName.ToLower() == name.ToLower());
            return accountLedger;
        }

        public List<PharmaBusinessObjects.Common.CustomerType> GetCustomerTypes()
        {
            return new CommonDao().GetCustomerTypes();
        }

        public List<PharmaBusinessObjects.Common.RateType> GetInterestTypes()
        {
            return new CommonDao().GetInterestTypes();
        }

        public List<PharmaBusinessObjects.Common.PersonLedgerType> GetPersonLedgerTypes()
        {
            return new CommonDao().GetPersonLedgerTypes();
        }

        public List<PharmaBusinessObjects.Common.RecordType> GetRecordTypes()
        {
            return new CommonDao().GetRecordTypes();
        }

        public List<PharmaBusinessObjects.Common.RecordType> GetRecordTypesWithAll()
        {
            var recordTypes = new CommonDao().GetRecordTypes() ?? new List<PharmaBusinessObjects.Common.RecordType>();


            recordTypes.Insert(0, new PharmaBusinessObjects.Common.RecordType() { RecordTypeId = 0, RecordTypeName = "All" });

            return recordTypes;
        }


    }
}
