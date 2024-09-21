using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PharmaDAL.Entity;

namespace PharmaDAL.Common
{
    public class CommonDao
    {
        public List<PharmaBusinessObjects.Common.AccountType> GetAccountTypes()
        {
            using (PharmaDBEntities context = new PharmaDBEntities())
            {
                return context.AccountType.Where(p => p.Status).Select(p => new PharmaBusinessObjects.Common.AccountType()
                {
                    AccountTypeID = p.AccountTypeID,
                    AccountTypeName = p.AccountTypeName,
                    AccountTypeShortName = p.AccountTypeShortName,
                    Status = p.Status
                }).ToList();
            }
        }

        public List<PharmaBusinessObjects.Common.AccountLedgerType> GetAccountLedgerTypes()
        {
            using (PharmaDBEntities context = new PharmaDBEntities())
            {
                return context.AccountLedgerType.Where(p => p.Status).Select(p => new PharmaBusinessObjects.Common.AccountLedgerType()
                {
                    AccountLedgerTypeID = p.AccountLedgerTypeID,
                    AccountLedgerTypeName = p.AccountLedgerTypeName   ,
                    AccountLedgerTypeSystemName = p.SystemName                 
                }).ToList();
            }
        }

        public List<PharmaBusinessObjects.Common.CustomerType> GetCustomerTypes()
        {
            using (PharmaDBEntities context = new PharmaDBEntities())
            {
                return context.CustomerType.Where(p => p.Status).Select(p => new PharmaBusinessObjects.Common.CustomerType()
                {
                    CustomerTypeId = p.CustomerTypeId,
                    CustomerTypeName = p.CustomerType1,
                    CustomerTypeShortName = p.CustomerTypeShortName,
                    Status=p.Status
                }).ToList();
            }
        }
        
        public List<PharmaBusinessObjects.Common.RateType> GetInterestTypes()
        {
            using (PharmaDBEntities context = new PharmaDBEntities())
            {
                return context.RateType.Where(p => p.Status).Select(p => new PharmaBusinessObjects.Common.RateType()
                {
                    RateTypeId = p.RateTypeId,
                    RateTypeName = p.RateTypeName,  
                    SystemName = p.SystemName   ,              
                    Status = p.Status
                }).ToList();
            }
        }
        
        public List<PharmaBusinessObjects.Common.PersonLedgerType> GetPersonLedgerTypes()
        {
            using (PharmaDBEntities context = new PharmaDBEntities())
            {
                return context.PersonLedgerType.Where(p => p.Status).Select(p => new PharmaBusinessObjects.Common.PersonLedgerType()
                {
                    PersonTypeId = p.PersonTypeId,
                    PersonType = p.PersonType,                    
                    Status = p.Status
                }).ToList();
            }
        }
        

        public List<PharmaBusinessObjects.Common.RecordType> GetRecordTypes()
        {
            using (PharmaDBEntities context = new PharmaDBEntities())
            {
                return context.RecordType.Where(p => p.Status).Select(p => new PharmaBusinessObjects.Common.RecordType()
                {
                    RecordTypeId = p.RecordTypeId,
                    RecordTypeName = p.RecordType1,
                    SystemName = p.SystemName,
                    Status = p.Status
                }).ToList();
            }
        }









    }
}
