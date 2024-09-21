
using PharmaBusinessObjects.Common;
using PharmaDAL.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaDAL.Master
{
    public class AccountLedgerMasterDao : BaseDao
    {
        public AccountLedgerMasterDao(PharmaBusinessObjects.Master.UserMaster loggedInUser) : base(loggedInUser)
        {

        }

        public List<PharmaBusinessObjects.Master.AccountLedgerMaster> GetAccountLedgers()
        {
            using (PharmaDBEntities context = new PharmaDBEntities())
            {
                return context.AccountLedgerMaster.Select(p => new PharmaBusinessObjects.Master.AccountLedgerMaster()
                {
                    AccountLedgerID = p.AccountLedgerID,
                    AccountLedgerName = p.AccountLedgerName,
                    AccountLedgerCode = p.AccountLedgerCode,
                    AccountLedgerTypeId = p.AccountLedgerTypeId,
                    AccountLedgerType = p.AccountLedgerType.AccountLedgerTypeName,
                    AccountLedgerTypeSystemName = p.AccountLedgerType.SystemName,
                    AccountTypeId = p.AccountTypeId,
                    AccountType = p.AccountType.AccountTypeName,
                    CreditControlCodeID = p.CreditControlCodeID,
                    DebitControlCodeID = p.DebitControlCodeID,
                    OpeningBalance = p.OpeningBalance,
                    CreditDebit = p.CreditDebit,
                    SalePurchaseTaxValue = p.SalePurchaseTaxType,
                    Status = p.Status,
                    StatusText = p.Status ? string.Empty : Constants.Others.Inactive

                }).ToList();
            }

        }

        public PharmaBusinessObjects.Master.AccountLedgerMaster GetAccountLedgerById(int accountLedgerID)
        {
            using (PharmaDBEntities context = new PharmaDBEntities())
            {
                return context.AccountLedgerMaster.Where(p => p.AccountLedgerID == accountLedgerID).Select(p => new PharmaBusinessObjects.Master.AccountLedgerMaster()
                {
                    AccountLedgerID = p.AccountLedgerID,
                    AccountLedgerName = p.AccountLedgerName,
                    AccountLedgerCode = p.AccountLedgerCode,
                    AccountLedgerTypeId = p.AccountLedgerTypeId,
                    AccountLedgerType = p.AccountLedgerType.AccountLedgerTypeName,
                    AccountLedgerTypeSystemName = p.AccountLedgerType.SystemName,
                    AccountTypeId = p.AccountTypeId,
                    AccountType = p.AccountType.AccountTypeName,
                    CreditControlCodeID = p.CreditControlCodeID,
                    DebitControlCodeID = p.DebitControlCodeID,
                    DebitControlCode = p.AccountLedgerMaster3.AccountLedgerName,
                    CreditControlCode = p.AccountLedgerMaster2.AccountLedgerName,
                    OpeningBalance = p.OpeningBalance,
                    CreditDebit = p.CreditDebit,
                    SalePurchaseTaxValue = p.SalePurchaseTaxType,
                    Status = p.Status,
                    StatusText = p.Status ? string.Empty : Constants.Others.Inactive

                }).FirstOrDefault();
            }

        }

        public int AddAccountLedger(PharmaBusinessObjects.Master.AccountLedgerMaster p)
        {
            using (PharmaDBEntities context = new PharmaDBEntities())
            {
                var maxAccountLedgerID = context.AccountLedgerMaster.Count() > 0 ? context.AccountLedgerMaster.Max(q => q.AccountLedgerID) + 1 : 1;

                var accountLedgerCode = "L" + maxAccountLedgerID.ToString().PadLeft(6, '0');

                AccountLedgerMaster table = new AccountLedgerMaster()
                {

                    AccountLedgerName = p.AccountLedgerName,
                    AccountLedgerCode = accountLedgerCode,
                    AccountLedgerTypeId = p.AccountLedgerTypeId,
                    AccountTypeId = p.AccountTypeId,
                    OpeningBalance = p.OpeningBalance,
                    CreditDebit = p.CreditDebit,
                    SalePurchaseTaxType = p.SalePurchaseTaxValue,
                    Status = p.Status,
                    CreatedBy = this.LoggedInUser.Username,
                    CreatedOn = System.DateTime.Now
                };

                var accountLedger = new Common.CommonDao().GetAccountLedgerTypes().Where(q => q.AccountLedgerTypeID == p.AccountLedgerTypeId).FirstOrDefault();

                if (accountLedger.AccountLedgerTypeSystemName != Constants.AccountLedgerType.ControlCodes)
                {
                    table.CreditControlCodeID = p.CreditControlCodeID;
                    table.DebitControlCodeID = p.DebitControlCodeID;
                }

                context.AccountLedgerMaster.Add(table);
                return context.SaveChanges();
            }
        }

        public int UpdateAccountLedger(PharmaBusinessObjects.Master.AccountLedgerMaster p)
        {
            using (PharmaDBEntities context = new PharmaDBEntities())
            {
                try
                {
                    var accountLedgerMaster = context.AccountLedgerMaster.Where(q => q.AccountLedgerID == p.AccountLedgerID).FirstOrDefault();

                    if (accountLedgerMaster != null)
                    {
                        accountLedgerMaster.AccountLedgerName = p.AccountLedgerName;
                        accountLedgerMaster.AccountLedgerCode = p.AccountLedgerCode;
                        accountLedgerMaster.AccountLedgerTypeId = p.AccountLedgerTypeId;
                        accountLedgerMaster.AccountTypeId = p.AccountTypeId;
                        accountLedgerMaster.CreditControlCodeID = p.CreditControlCodeID;
                        accountLedgerMaster.DebitControlCodeID = p.DebitControlCodeID;
                        accountLedgerMaster.OpeningBalance = p.OpeningBalance;
                        accountLedgerMaster.CreditDebit = p.CreditDebit;
                        accountLedgerMaster.Status = p.Status;
                        accountLedgerMaster.SalePurchaseTaxType = p.SalePurchaseTaxValue;
                        accountLedgerMaster.CreatedBy = this.LoggedInUser.Username;
                        accountLedgerMaster.CreatedOn = System.DateTime.Now;
                    }

                    return context.SaveChanges();
                }
                catch (DbEntityValidationException ex)
                {
                    throw ex;
                }
            }

        }

        public List<PharmaBusinessObjects.Master.AccountLedgerMaster> GetAccountLedgerByLedgerTypeIdAndSearch(int ledgerTypeID, string searchString = null)
        {
            using (PharmaDBEntities context = new PharmaDBEntities())
            {
                var accountLedgers = (from p in context.AccountLedgerMaster
                                      where (ledgerTypeID == 0 || p.AccountLedgerTypeId == ledgerTypeID)
                                      && (string.IsNullOrEmpty(searchString) || p.AccountLedgerName.Contains(searchString))
                                      select new PharmaBusinessObjects.Master.AccountLedgerMaster()
                                      {
                                          AccountLedgerID = p.AccountLedgerID,
                                          AccountLedgerName = p.AccountLedgerName,
                                          AccountLedgerCode = p.AccountLedgerCode,
                                          AccountLedgerTypeId = p.AccountLedgerTypeId,
                                          AccountLedgerType = p.AccountLedgerType.AccountLedgerTypeName,
                                          AccountLedgerTypeSystemName = p.AccountLedgerType.SystemName,
                                          AccountTypeId = p.AccountTypeId,
                                          AccountType = p.AccountType.AccountTypeName,
                                          CreditControlCodeID = p.CreditControlCodeID,
                                          DebitControlCodeID = p.DebitControlCodeID,
                                          DebitControlCode = p.AccountLedgerMaster3.AccountLedgerName,
                                          CreditControlCode = p.AccountLedgerMaster2.AccountLedgerName,
                                          OpeningBalance = p.OpeningBalance,
                                          CreditDebit = p.CreditDebit,
                                          SalePurchaseTaxValue = p.SalePurchaseTaxType,
                                          Status = p.Status,
                                          StatusText = p.Status ? string.Empty : Constants.Others.Inactive
                                      }).ToList();

                return accountLedgers;

            }



        }

        public PharmaBusinessObjects.Master.AccountLedgerMaster GetAccountLedgerByCode(string code)
        {
            using (PharmaDBEntities context = new PharmaDBEntities())
            {
                var accountLedger = (from p in context.AccountLedgerMaster
                                     where (p.AccountLedgerCode.ToLower() == code.ToLower())
                                     select new PharmaBusinessObjects.Master.AccountLedgerMaster()
                                     {
                                         AccountLedgerID = p.AccountLedgerID,
                                         AccountLedgerName = p.AccountLedgerName,
                                         AccountLedgerCode = p.AccountLedgerCode,
                                         AccountLedgerTypeId = p.AccountLedgerTypeId,
                                         AccountLedgerType = p.AccountLedgerType.AccountLedgerTypeName,
                                         AccountLedgerTypeSystemName = p.AccountLedgerType.SystemName,
                                         AccountTypeId = p.AccountTypeId,
                                         AccountType = p.AccountType.AccountTypeName,
                                         CreditControlCodeID = p.CreditControlCodeID,
                                         DebitControlCodeID = p.DebitControlCodeID,
                                         DebitControlCode = p.AccountLedgerMaster3.AccountLedgerName,
                                         CreditControlCode = p.AccountLedgerMaster2.AccountLedgerName,
                                         OpeningBalance = p.OpeningBalance,
                                         CreditDebit = p.CreditDebit,
                                         SalePurchaseTaxValue = p.SalePurchaseTaxType,
                                         Status = p.Status,
                                         StatusText = p.Status ? string.Empty : Constants.Others.Inactive
                                     }).FirstOrDefault();

                return accountLedger;

            }

        }

    }
}
