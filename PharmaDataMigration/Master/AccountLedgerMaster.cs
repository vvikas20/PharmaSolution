using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using PharmaDAL.Entity;
using PharmaBusinessObjects.Common;
using log4net;
using System.Reflection;

namespace PharmaDataMigration.Master
{
    public class AccountLedgerMaster
    {
        private readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private DBFConnectionManager dbConnection;
        public AccountLedgerMaster()
        {
            dbConnection = new DBFConnectionManager(Common.DataDirectory);
          
        }

        public int InsertControlCodesData()
        {
            try
            {
                string query = "select * from ACM where slcd = 'CC'";

                DataTable dtControlCodesMaster = dbConnection.GetData(query);

                List<PharmaDAL.Entity.AccountLedgerMaster> listControlCodesMaster = new List<PharmaDAL.Entity.AccountLedgerMaster>();
                int _result = 0;

                using (PharmaDBEntities context = new PharmaDBEntities())
                {
                    var maxAccountLedgerID = context.AccountLedgerMaster.Count();
                    int accountLedgerTypeID = context.AccountLedgerType.Where(p => p.SystemName == PharmaBusinessObjects.Common.Constants.AccountLedgerType.ControlCodes).FirstOrDefault().AccountLedgerTypeID;
                    
                    if (dtControlCodesMaster != null && dtControlCodesMaster.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dtControlCodesMaster.Rows)
                        {
                            try
                            {
                                maxAccountLedgerID++;
                                string accountTypeShortName = Convert.ToString(dr["Actyp"]).Trim();
                                int accountTypeID = context.AccountType.Where(p => p.AccountTypeShortName == accountTypeShortName).FirstOrDefault().AccountTypeID;
                                string accountLedgerCode = "CTRL" + maxAccountLedgerID.ToString().PadLeft(6, '0');
                                string originalAccountLedgerCode = Convert.ToString(dr["ACNO"]).Trim();
                                Common.controlCodeMap.Add(new ControlCodeMap() { OriginalControlCode = originalAccountLedgerCode, MappedControlCode = accountLedgerCode });

                                PharmaDAL.Entity.AccountLedgerMaster newControlCodeMaster = new PharmaDAL.Entity.AccountLedgerMaster()
                                {
                                    AccountLedgerName = Convert.ToString(dr["ACName"]).Trim(),
                                    AccountLedgerCode = accountLedgerCode,
                                    AccountLedgerTypeId = accountLedgerTypeID,
                                    AccountTypeId = accountTypeID,
                                    OpeningBalance = Convert.ToDecimal(dr["Abop"]),
                                    CreditDebit = Convert.ToDecimal(dr["Abop"]) > 0 ? Convert.ToString(PharmaBusinessObjects.Common.Enums.TransType.D) : Convert.ToString(PharmaBusinessObjects.Common.Enums.TransType.C),
                                    Status = Convert.ToChar(dr["ACSTS"]) == '*' ? false : true,
                                    CreditControlCodeID = null,
                                    DebitControlCodeID = null,
                                    CreatedBy = "admin",
                                    CreatedOn = DateTime.Now,
                                    SalePurchaseTaxType = null
                                };

                                listControlCodesMaster.Add(newControlCodeMaster);
                            }
                            catch (Exception)
                            {
                                log.Info("CONTROL CODES: Error in ACName --> " + Convert.ToString(dr["ACName"]).Trim());
                            }
                        }
                    }

                    context.AccountLedgerMaster.AddRange(listControlCodesMaster);
                    _result = context.SaveChanges();

                    return _result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int InsertIncomeLedgerData()
        {
            try
            {
                string query = "select * from ACM where slcd = '01'";

                DataTable dtIncomeLedgerMaster = dbConnection.GetData(query);

                List<PharmaDAL.Entity.AccountLedgerMaster> listIncomeLedgerMaster = new List<PharmaDAL.Entity.AccountLedgerMaster>();
                int _result = 0;

                using (PharmaDBEntities context = new PharmaDBEntities())
                {
                    var maxAccountLedgerID = context.AccountLedgerMaster.Count();
                    int accountLedgerTypeID = context.AccountLedgerType.Where(p => p.SystemName == PharmaBusinessObjects.Common.Constants.AccountLedgerType.IncomeLedger).FirstOrDefault().AccountLedgerTypeID;
                    
                    if (dtIncomeLedgerMaster != null && dtIncomeLedgerMaster.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dtIncomeLedgerMaster.Rows)
                        {
                            try
                            {

                                maxAccountLedgerID++;
                                string accountTypeShortName = Convert.ToString(dr["Actyp"]).Trim();
                                int accountTypeID = context.AccountType.Where(p => p.AccountTypeShortName == accountTypeShortName).FirstOrDefault().AccountTypeID;
                                string accountLedgerCode = "INC" + maxAccountLedgerID.ToString().PadLeft(7, '0');
                                string originalAccountLedgerCode = Convert.ToString(dr["ACNO"]).Trim();
                                string originalCreditControlCode = Convert.ToString(dr["Cac"]).Trim();
                                string mappedCreditControlCode = Common.controlCodeMap.Where(q => q.OriginalControlCode == originalCreditControlCode).FirstOrDefault().MappedControlCode;
                                int creditControlCodeID = context.AccountLedgerMaster.Where(p => p.AccountLedgerCode == mappedCreditControlCode).FirstOrDefault().AccountLedgerID;
                                string originalDebitControlCode = Convert.ToString(dr["Cad"]).Trim();
                                string mappedDebitControlCode = Common.controlCodeMap.Where(q => q.OriginalControlCode == originalDebitControlCode).FirstOrDefault().MappedControlCode;
                                int debitControlCodeID = context.AccountLedgerMaster.Where(p => p.AccountLedgerCode == mappedDebitControlCode).FirstOrDefault().AccountLedgerID;
                                Common.accountLedgerCodeMap.Add(new AccountLedgerCodeMap() { OriginalAccountLedgerCode = originalAccountLedgerCode, MappedAccountLedgerCode = accountLedgerCode, AccountLedgerTypeID = accountLedgerTypeID });

                                if (Convert.ToString(dr["ACName"]).Trim().ToUpper().Equals("ROUNDED OFF ADJUSTMENT A/C"))
                                {
                                    accountLedgerCode = "ADJ" + Convert.ToString("1").PadLeft(7, '0');
                                }

                                PharmaDAL.Entity.AccountLedgerMaster newIncomeLedgerMaster = new PharmaDAL.Entity.AccountLedgerMaster()
                                {
                                    AccountLedgerName = Convert.ToString(dr["ACName"]).Trim(),
                                    AccountLedgerCode = accountLedgerCode,
                                    AccountLedgerTypeId = accountLedgerTypeID,
                                    AccountTypeId = accountTypeID,
                                    OpeningBalance = Convert.ToDecimal(dr["Abop"]),
                                    CreditDebit = Convert.ToDecimal(dr["Abop"]) > 0 ? Convert.ToString(PharmaBusinessObjects.Common.Enums.TransType.D) : Convert.ToString(PharmaBusinessObjects.Common.Enums.TransType.C),
                                    Status = Convert.ToChar(dr["ACSTS"]) == '*' ? false : true,
                                    CreditControlCodeID = creditControlCodeID,
                                    DebitControlCodeID = debitControlCodeID,
                                    CreatedBy = "admin",
                                    CreatedOn = DateTime.Now,
                                    SalePurchaseTaxType = null
                                };

                                listIncomeLedgerMaster.Add(newIncomeLedgerMaster);
                            }
                            catch (Exception)
                            {
                                log.Info("INCOME LEDGER : Error in ACName --> " + Convert.ToString(dr["ACName"]).Trim());
                            }
                        }
                    }

                    context.AccountLedgerMaster.AddRange(listIncomeLedgerMaster);
                    _result = context.SaveChanges();

                    return _result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int InsertExpenditureLedgerData()
        {
            try
            {
                string query = "select * from ACM where slcd = '02'";

                DataTable dtExpenditureLedgerMaster = dbConnection.GetData(query);

                List<PharmaDAL.Entity.AccountLedgerMaster> listExpenditureLedgerMaster = new List<PharmaDAL.Entity.AccountLedgerMaster>();
                int _result = 0;

                using (PharmaDBEntities context = new PharmaDBEntities())
                {
                    var maxAccountLedgerID = context.AccountLedgerMaster.Count();
                    int accountLedgerTypeID = context.AccountLedgerType.Where(p => p.SystemName == PharmaBusinessObjects.Common.Constants.AccountLedgerType.ExpenditureLedger).FirstOrDefault().AccountLedgerTypeID;

                    if (dtExpenditureLedgerMaster != null && dtExpenditureLedgerMaster.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dtExpenditureLedgerMaster.Rows)
                        {
                            try
                            {
                                maxAccountLedgerID++;
                                string accountTypeShortName = Convert.ToString(dr["Actyp"]).Trim();
                                int accountTypeID = context.AccountType.Where(p => p.AccountTypeShortName == accountTypeShortName).FirstOrDefault().AccountTypeID;
                                string accountLedgerCode = "EXP" + maxAccountLedgerID.ToString().PadLeft(7, '0');
                                string originalAccountLedgerCode = Convert.ToString(dr["ACNO"]).Trim();
                                string originalCreditControlCode = Convert.ToString(dr["Cac"]).Trim();
                                string mappedCreditControlCode = Common.controlCodeMap.Where(q => q.OriginalControlCode == originalCreditControlCode).FirstOrDefault().MappedControlCode;
                                int creditControlCodeID = context.AccountLedgerMaster.Where(p => p.AccountLedgerCode == mappedCreditControlCode).FirstOrDefault().AccountLedgerID;
                                string originalDebitControlCode = Convert.ToString(dr["Cad"]).Trim();
                                string mappedDebitControlCode = Common.controlCodeMap.Where(q => q.OriginalControlCode == originalDebitControlCode).FirstOrDefault().MappedControlCode;
                                int debitControlCodeID = context.AccountLedgerMaster.Where(p => p.AccountLedgerCode == mappedDebitControlCode).FirstOrDefault().AccountLedgerID;
                                Common.accountLedgerCodeMap.Add(new AccountLedgerCodeMap() { OriginalAccountLedgerCode = originalAccountLedgerCode, MappedAccountLedgerCode = accountLedgerCode, AccountLedgerTypeID = accountLedgerTypeID });

                                PharmaDAL.Entity.AccountLedgerMaster newExpenditureLedgerMaster = new PharmaDAL.Entity.AccountLedgerMaster()
                                {
                                    AccountLedgerName = Convert.ToString(dr["ACName"]).Trim(),
                                    AccountLedgerCode = accountLedgerCode,
                                    AccountLedgerTypeId = accountLedgerTypeID,
                                    AccountTypeId = accountTypeID,
                                    OpeningBalance = Convert.ToDecimal(dr["Abop"]),
                                    CreditDebit = Convert.ToDecimal(dr["Abop"]) > 0 ? Convert.ToString(PharmaBusinessObjects.Common.Enums.TransType.D) : Convert.ToString(PharmaBusinessObjects.Common.Enums.TransType.C),
                                    Status = Convert.ToChar(dr["ACSTS"]) == '*' ? false : true,
                                    CreditControlCodeID = creditControlCodeID,
                                    DebitControlCodeID = debitControlCodeID,
                                    CreatedBy = "admin",
                                    CreatedOn = DateTime.Now,
                                    SalePurchaseTaxType = null
                                };

                                listExpenditureLedgerMaster.Add(newExpenditureLedgerMaster);
                            }
                            catch (Exception)
                            {
                                log.Info("EXPENDITURE LEDGER : Error in ACName --> " + Convert.ToString(dr["ACName"]).Trim());
                            }
                        }
                    }

                    context.AccountLedgerMaster.AddRange(listExpenditureLedgerMaster);
                    _result = context.SaveChanges();

                    return _result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int InsertTransactionLedgerData()
        {
            try
            {
                string query = "select * from ACM where slcd = '03'";

                DataTable dtTransactionLedgerMaster = dbConnection.GetData(query);

                List<PharmaDAL.Entity.AccountLedgerMaster> listTransactionLedgerMaster = new List<PharmaDAL.Entity.AccountLedgerMaster>();
                int _result = 0;

                using (PharmaDBEntities context = new PharmaDBEntities())
                {
                    var maxAccountLedgerID = context.AccountLedgerMaster.Count();
                    int accountLedgerTypeID = context.AccountLedgerType.Where(p => p.SystemName == PharmaBusinessObjects.Common.Constants.AccountLedgerType.TransactionBooks).FirstOrDefault().AccountLedgerTypeID;

                    if (dtTransactionLedgerMaster != null && dtTransactionLedgerMaster.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dtTransactionLedgerMaster.Rows)
                        {
                            try
                            {
                                maxAccountLedgerID++;
                                string accountTypeShortName = Convert.ToString(dr["Actyp"]).Trim();
                                int accountTypeID = context.AccountType.Where(p => p.AccountTypeShortName == accountTypeShortName).FirstOrDefault().AccountTypeID;
                                string accountLedgerCode = "TRN" + maxAccountLedgerID.ToString().PadLeft(7, '0');
                                string originalAccountLedgerCode = Convert.ToString(dr["ACNO"]).Trim();
                                string originalCreditControlCode = Convert.ToString(dr["Cac"]).Trim();
                                string mappedCreditControlCode = Common.controlCodeMap.Where(q => q.OriginalControlCode == originalCreditControlCode).FirstOrDefault().MappedControlCode;
                                int creditControlCodeID = context.AccountLedgerMaster.Where(p => p.AccountLedgerCode == mappedCreditControlCode).FirstOrDefault().AccountLedgerID;
                                string originalDebitControlCode = Convert.ToString(dr["Cad"]).Trim();
                                string mappedDebitControlCode = Common.controlCodeMap.Where(q => q.OriginalControlCode == originalDebitControlCode).FirstOrDefault().MappedControlCode;
                                int debitControlCodeID = context.AccountLedgerMaster.Where(p => p.AccountLedgerCode == mappedDebitControlCode).FirstOrDefault().AccountLedgerID;
                                Common.accountLedgerCodeMap.Add(new AccountLedgerCodeMap()
                                {
                                    OriginalAccountLedgerCode = originalAccountLedgerCode
                                    , MappedAccountLedgerCode = accountLedgerCode
                                    , AccountLedgerTypeID = accountLedgerTypeID
                                    ,AccountLedgerName = Convert.ToString(dr["ACName"]).Trim()
                                });

                                PharmaDAL.Entity.AccountLedgerMaster newTransactionLedgerMaster = new PharmaDAL.Entity.AccountLedgerMaster()
                                {
                                    AccountLedgerName = Convert.ToString(dr["ACName"]).Trim(),
                                    AccountLedgerCode = accountLedgerCode,
                                    AccountLedgerTypeId = accountLedgerTypeID,
                                    AccountTypeId = accountTypeID,
                                    OpeningBalance = Convert.ToDecimal(dr["Abop"]),
                                    CreditDebit = Convert.ToDecimal(dr["Abop"]) > 0 ? Convert.ToString(PharmaBusinessObjects.Common.Enums.TransType.D) : Convert.ToString(PharmaBusinessObjects.Common.Enums.TransType.C),
                                    Status = Convert.ToChar(dr["ACSTS"]) == '*' ? false : true,
                                    CreditControlCodeID = creditControlCodeID,
                                    DebitControlCodeID = debitControlCodeID,
                                    CreatedBy = "admin",
                                    CreatedOn = DateTime.Now,
                                    SalePurchaseTaxType = null
                                };

                                listTransactionLedgerMaster.Add(newTransactionLedgerMaster);
                            }
                            catch (Exception)
                            {
                                log.Info("TRANSACTION LEDGER : Error in ACName --> " + Convert.ToString(dr["ACName"]).Trim());
                            }
                        }
                    }

                    context.AccountLedgerMaster.AddRange(listTransactionLedgerMaster);
                    _result = context.SaveChanges();

                    return _result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int InsertGeneralLedgerData()
        {
            try
            {
                int debitCreditControlId = 0;

                string query = "select * from ACM where slcd = '04'";

                DataTable dtGeneralLedgerMaster = dbConnection.GetData(query);

                List<PharmaDAL.Entity.AccountLedgerMaster> listGeneralLedgerMaster = new List<PharmaDAL.Entity.AccountLedgerMaster>();
                int _result = 0;

                using (PharmaDBEntities context = new PharmaDBEntities())
                {
                    var maxAccountLedgerID = context.AccountLedgerMaster.Count();
                    int accountLedgerTypeID = context.AccountLedgerType.Where(p => p.SystemName == PharmaBusinessObjects.Common.Constants.AccountLedgerType.GeneralLedger).FirstOrDefault().AccountLedgerTypeID;

                    if (dtGeneralLedgerMaster != null && dtGeneralLedgerMaster.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dtGeneralLedgerMaster.Rows)
                        {
                            try
                            {
                                maxAccountLedgerID++;
                                string accountTypeShortName = Convert.ToString(dr["Actyp"]).Trim();
                                int accountTypeID = context.AccountType.Where(p => p.AccountTypeShortName == accountTypeShortName).FirstOrDefault().AccountTypeID;
                                string accountLedgerCode = "GEN" + maxAccountLedgerID.ToString().PadLeft(7, '0');
                                string originalAccountLedgerCode = Convert.ToString(dr["ACNO"]).Trim();
                                string originalCreditControlCode = Convert.ToString(dr["Cac"]).Trim();
                                string mappedCreditControlCode = Common.controlCodeMap.Where(q => q.OriginalControlCode == originalCreditControlCode).FirstOrDefault().MappedControlCode;
                                int creditControlCodeID = context.AccountLedgerMaster.Where(p => p.AccountLedgerCode == mappedCreditControlCode).FirstOrDefault().AccountLedgerID;
                                string originalDebitControlCode = Convert.ToString(dr["Cad"]).Trim();
                                string mappedDebitControlCode = Common.controlCodeMap.Where(q => q.OriginalControlCode == originalDebitControlCode).FirstOrDefault().MappedControlCode;
                                int debitControlCodeID = context.AccountLedgerMaster.Where(p => p.AccountLedgerCode == mappedDebitControlCode).FirstOrDefault().AccountLedgerID;

                                if (Convert.ToString(dr["ACNO"]).Trim().ToUpper().Contains("PTAX01") || Convert.ToString(dr["ACNO"]).Trim().ToUpper().Contains("STAX01"))
                                {
                                    debitCreditControlId = debitControlCodeID;
                                    continue;
                                }

                                Common.accountLedgerCodeMap.Add(new AccountLedgerCodeMap() { OriginalAccountLedgerCode = originalAccountLedgerCode, MappedAccountLedgerCode = accountLedgerCode, AccountLedgerTypeID = accountLedgerTypeID });

                                PharmaDAL.Entity.AccountLedgerMaster newGeneralLedgerMaster = new PharmaDAL.Entity.AccountLedgerMaster()
                                {
                                    AccountLedgerName = Convert.ToString(dr["ACName"]).Trim(),
                                    AccountLedgerCode = accountLedgerCode,
                                    AccountLedgerTypeId = accountLedgerTypeID,
                                    AccountTypeId = accountTypeID,
                                    OpeningBalance = Convert.ToDecimal(dr["Abop"]),
                                    CreditDebit = Convert.ToDecimal(dr["Abop"]) > 0 ? Convert.ToString(PharmaBusinessObjects.Common.Enums.TransType.D) : Convert.ToString(PharmaBusinessObjects.Common.Enums.TransType.C),
                                    Status = Convert.ToChar(dr["ACSTS"]) == '*' ? false : true,
                                    CreditControlCodeID = creditControlCodeID,
                                    DebitControlCodeID = debitControlCodeID,
                                    CreatedBy = "admin",
                                    CreatedOn = DateTime.Now,
                                    SalePurchaseTaxType = null
                                };

                                listGeneralLedgerMaster.Add(newGeneralLedgerMaster);
                            }
                            catch (Exception)
                            {
                                log.Info("GENERAL LEDGER : Error in ACName --> " + Convert.ToString(dr["ACName"]).Trim());
                            }
                        }
                    }

                    context.AccountLedgerMaster.AddRange(listGeneralLedgerMaster);
                    _result = context.SaveChanges();

                    try
                    {

                        var generlLedges = context.AccountLedgerMaster.Where(p => p.AccountLedgerType.SystemName == Constants.AccountLedgerType.GeneralLedger
                                                   && (
                                                       p.AccountLedgerCode.StartsWith("IGST")
                                                       || p.AccountLedgerCode.StartsWith("SGST")
                                                       || p.AccountLedgerCode.StartsWith("CGST")
                                                       )
                                                    ).ToList();

                        if (generlLedges != null && generlLedges.Count > 0)
                        {
                            foreach (var item in generlLedges)
                            {
                                item.DebitControlCodeID = debitCreditControlId;
                                item.CreditControlCodeID = debitCreditControlId;
                            }

                            context.SaveChanges();

                        }
                    }
                    catch (Exception)
                    {
                        log.Info("GENERAL LEDGER : Error in Set Debit/Credit contorl if for IGST/CGST/SGST ");
                    }

                    return _result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int InsertPurchaseLedgerData()
        {
            try
            {
                List<PharmaDAL.Entity.AccountLedgerMaster> purchaseMasters;
                int debitControlCodeIDGlobal = 0;

                string query = "select * from ACM where slcd = '05'";

                DataTable dtPurchaseLedgerMaster = dbConnection.GetData(query);

                List<PharmaDAL.Entity.AccountLedgerMaster> listPurchaseLedgerMaster = new List<PharmaDAL.Entity.AccountLedgerMaster>();
                int _result = 0;

                using (PharmaDBEntities context = new PharmaDBEntities())
                {
                    purchaseMasters = context.AccountLedgerMaster.Where(p => p.AccountLedgerType.SystemName == Constants.AccountLedgerType.PurchaseLedger).Select(p=>p).ToList();


                    var maxAccountLedgerID = context.AccountLedgerMaster.Count();
                    int accountLedgerTypeID = context.AccountLedgerType.Where(p => p.SystemName == PharmaBusinessObjects.Common.Constants.AccountLedgerType.PurchaseLedger).FirstOrDefault().AccountLedgerTypeID;

                    if (dtPurchaseLedgerMaster != null && dtPurchaseLedgerMaster.Rows.Count > 0)
                    {

                        foreach (DataRow dr in dtPurchaseLedgerMaster.Rows)
                        {
                            try
                            {
                                bool bcontinue = false;

                                decimal? salePurchaseTaxType = null;

                                if (string.Compare(Convert.ToString(dr["ACNAME"]).Trim(), "PURCHASE - TAXABLE 5%") == 0)
                                {
                                    salePurchaseTaxType = Convert.ToDecimal(5);
                                    bcontinue = true;
                                }
                                else if (string.Compare(Convert.ToString(dr["ACNAME"]).Trim(), "PURCHASE - TAXABLE 12.5%") == 0 || (string.Compare(Convert.ToString(dr["ACNAME"]).Trim(), "PURCHASE - TAXABLE 12%") == 0))
                                {
                                    salePurchaseTaxType = Convert.ToDecimal(12);
                                    bcontinue = true;
                                }
                                else if (string.Compare(Convert.ToString(dr["ACNAME"]).Trim(), "PURCHASE - TAXABLE 18%") == 0)
                                {
                                    salePurchaseTaxType = Convert.ToDecimal(18);
                                    bcontinue = true;
                                }
                                else if (string.Compare(Convert.ToString(dr["ACNAME"]).Trim(), "PURCHASE - TAXABLE 28%") == 0)
                                {
                                    salePurchaseTaxType = Convert.ToDecimal(28);
                                    bcontinue = true;
                                }
                                else if (string.Compare(Convert.ToString(dr["ACNAME"]).Trim(), "PURCHASE - TAX EXEMPTED") == 0)
                                {
                                    salePurchaseTaxType = 0;
                                    bcontinue = true;
                                }

                                maxAccountLedgerID++;
                                string accountTypeShortName = Convert.ToString(dr["Actyp"]).Trim();
                                int accountTypeID = context.AccountType.Where(p => p.AccountTypeShortName == accountTypeShortName).FirstOrDefault().AccountTypeID;
                                string accountLedgerCode = "PUR" + maxAccountLedgerID.ToString().PadLeft(7, '0');
                                string originalAccountLedgerCode = Convert.ToString(dr["ACNO"]).Trim();
                                string originalCreditControlCode = Convert.ToString(dr["Cac"]).Trim();
                                string mappedCreditControlCode = Common.controlCodeMap.Where(q => q.OriginalControlCode == originalCreditControlCode).FirstOrDefault().MappedControlCode;
                                int creditControlCodeID = context.AccountLedgerMaster.Where(p => p.AccountLedgerCode == mappedCreditControlCode).FirstOrDefault().AccountLedgerID;
                                string originalDebitControlCode = Convert.ToString(dr["Cad"]).Trim();
                                string mappedDebitControlCode = Common.controlCodeMap.Where(q => q.OriginalControlCode == originalDebitControlCode).FirstOrDefault().MappedControlCode;
                                int debitControlCodeID = context.AccountLedgerMaster.Where(p => p.AccountLedgerCode == mappedDebitControlCode).FirstOrDefault().AccountLedgerID;

                                debitControlCodeIDGlobal = debitControlCodeID;

                                Common.accountLedgerCodeMap.Add(new AccountLedgerCodeMap()
                                {
                                    OriginalAccountLedgerCode = originalAccountLedgerCode,
                                    MappedAccountLedgerCode = purchaseMasters.Where(p => p.SalePurchaseTaxType == salePurchaseTaxType).FirstOrDefault().AccountLedgerCode,
                                    AccountLedgerTypeID = accountLedgerTypeID
                                });

                            }
                            catch (Exception)
                            {
                                log.Info("PURCHASE LEDGER : Error in ACName --> " + Convert.ToString(dr["ACName"]).Trim());
                            }
                        }
                    }

                    //context.AccountLedgerMaster.AddRange(listPurchaseLedgerMaster);
                    //_result = context.SaveChanges();

                    foreach (var item in purchaseMasters)
                    {
                        item.DebitControlCodeID = debitControlCodeIDGlobal;
                        item.CreditControlCodeID = debitControlCodeIDGlobal;
                    }

                    context.SaveChanges();

                    return _result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int InsertSaleLedgerData()
        {
            try
            {
                List<PharmaDAL.Entity.AccountLedgerMaster> saleMasters;
                int debitControlCodeIDGlobal = 0;

                string query = "select * from ACM where slcd = '06'";

                DataTable dtSaleLedgerMaster = dbConnection.GetData(query);

                List<PharmaDAL.Entity.AccountLedgerMaster> listSaleLedgerMaster = new List<PharmaDAL.Entity.AccountLedgerMaster>();
                int _result = 0;

                using (PharmaDBEntities context = new PharmaDBEntities())
                {

                    saleMasters = context.AccountLedgerMaster.Where(p => p.AccountLedgerType.SystemName == Constants.AccountLedgerType.SaleLedger).Select(p => p).ToList();
                    
                    var maxAccountLedgerID = context.AccountLedgerMaster.Count();
                    int accountLedgerTypeID = context.AccountLedgerType.Where(p => p.SystemName == PharmaBusinessObjects.Common.Constants.AccountLedgerType.SaleLedger).FirstOrDefault().AccountLedgerTypeID;

                    if (dtSaleLedgerMaster != null && dtSaleLedgerMaster.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dtSaleLedgerMaster.Rows)
                        {
                            try
                            {

                                decimal? salePurchaseTaxType = null;

                                if (string.Compare(Convert.ToString(dr["ACNAME"]).Trim(), "SALE - TAXABLE 5%") == 0)
                                {
                                    salePurchaseTaxType = Convert.ToDecimal(5);
                                }
                                else if (string.Compare(Convert.ToString(dr["ACNAME"]).Trim(), "SALE - TAXABLE 12.5%") == 0 || (string.Compare(Convert.ToString(dr["ACNAME"]).Trim(), "SALE - TAXABLE 12%") == 0))
                                {
                                    salePurchaseTaxType = Convert.ToDecimal(12);                                    
                                }
                                else if (string.Compare(Convert.ToString(dr["ACNAME"]).Trim(), "SALE - TAXABLE 18%") == 0)
                                {
                                    salePurchaseTaxType = Convert.ToDecimal(18);
                                }
                                else if (string.Compare(Convert.ToString(dr["ACNAME"]).Trim(), "SALE - TAXABLE 28%") == 0)
                                {
                                    salePurchaseTaxType = Convert.ToDecimal(28);
                                }
                                else if (string.Compare(Convert.ToString(dr["ACNAME"]).Trim(), "SALE - TAX EXEMPTED") == 0)
                                {
                                    salePurchaseTaxType = 0;
                                }

                                maxAccountLedgerID++;
                                string accountTypeShortName = Convert.ToString(dr["Actyp"]).Trim();
                                int accountTypeID = context.AccountType.Where(p => p.AccountTypeShortName == accountTypeShortName).FirstOrDefault().AccountTypeID;
                                string accountLedgerCode = "SALE" + maxAccountLedgerID.ToString().PadLeft(6, '0');
                                string originalAccountLedgerCode = Convert.ToString(dr["ACNO"]).Trim();
                                string originalCreditControlCode = Convert.ToString(dr["Cac"]).Trim();
                                string mappedCreditControlCode = Common.controlCodeMap.Where(q => q.OriginalControlCode == originalCreditControlCode).FirstOrDefault().MappedControlCode;
                                int creditControlCodeID = context.AccountLedgerMaster.Where(p => p.AccountLedgerCode == mappedCreditControlCode).FirstOrDefault().AccountLedgerID;
                                string originalDebitControlCode = Convert.ToString(dr["Cad"]).Trim();
                                string mappedDebitControlCode = Common.controlCodeMap.Where(q => q.OriginalControlCode == originalDebitControlCode).FirstOrDefault().MappedControlCode;
                                int debitControlCodeID = context.AccountLedgerMaster.Where(p => p.AccountLedgerCode == mappedDebitControlCode).FirstOrDefault().AccountLedgerID;
                                //Common.accountLedgerCodeMap.Add(new AccountLedgerCodeMap() { OriginalAccountLedgerCode = originalAccountLedgerCode, MappedAccountLedgerCode = accountLedgerCode, AccountLedgerTypeID = accountLedgerTypeID });


                                debitControlCodeIDGlobal = debitControlCodeID;


                                Common.accountLedgerCodeMap.Add(new AccountLedgerCodeMap()
                                {
                                    OriginalAccountLedgerCode = originalAccountLedgerCode,
                                    MappedAccountLedgerCode = saleMasters.Where(p => p.SalePurchaseTaxType == salePurchaseTaxType).FirstOrDefault().AccountLedgerCode,
                                    AccountLedgerTypeID = accountLedgerTypeID
                                });


                            }
                            catch (Exception)
                            {
                                log.Info("SALE LEDGER : Error in ACName --> " + Convert.ToString(dr["ACName"]).Trim());

                            }
                        }
                    }

                    //context.AccountLedgerMaster.AddRange(listPurchaseLedgerMaster);
                    //_result = context.SaveChanges();

                    foreach (var item in saleMasters)
                    {
                        item.DebitControlCodeID = debitControlCodeIDGlobal;
                        item.CreditControlCodeID = debitControlCodeIDGlobal;
                    }

                    context.SaveChanges();

                    return _result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
