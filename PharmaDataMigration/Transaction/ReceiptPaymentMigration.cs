using log4net;
using PharmaBusinessObjects.Common;
using PharmaDAL.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Validation;
using System.Linq;
using System.Reflection;
using System.Text;

namespace PharmaDataMigration.Transaction
{
    public class ReceiptPaymentMigration
    {
        private readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private DBFConnectionManager dbConnection;

        public ReceiptPaymentMigration()
        {
            dbConnection = new DBFConnectionManager(Common.DataDirectory);
        }




        private int InsertData(DataTable dt)
        {
            int result = 0;

            List<PharmaDAL.Entity.ReceiptPayment> listReceiptPayment = new List<PharmaDAL.Entity.ReceiptPayment>();

            using (PharmaDBEntities context = new PharmaDBEntities())
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    var accountLedgerTypeId = context.AccountLedgerType.Where(p => p.SystemName == Constants.AccountLedgerType.TransactionBooks).Select(p => p.AccountLedgerTypeID).FirstOrDefault();

                    var accountLedgerCodeMap = Common.accountLedgerCodeMap.Where(p => p.AccountLedgerTypeID == accountLedgerTypeId).ToList();

                    foreach (DataRow dr in dt.Rows)
                    {
                        try
                        {
                            PharmaDAL.Entity.ReceiptPayment newReceiptPayment = new PharmaDAL.Entity.ReceiptPayment();

                            string oldVNo = Convert.ToString(dr["vno"]).Trim();
                            string newVNo = (Convert.ToString(dr["vno"]).Trim()).PadLeft(8, '0');

                            Common.receiptPaymentVoucherNumberMap.Add(new ReceiptPaymentVoucherMap() { OriginalVoucherNumber = oldVNo, MappedVoucherNumber = newVNo });

                            string ledgerType = string.Empty;
                            string ledgerTypeCode = string.Empty;
                            string ledgerTypeName = string.Empty;

                            string originalVoucherTypeCode = Convert.ToString(dr["vtyp"]).Trim();
                            string mappedVoucherTypeCode = Common.voucherTypeMap.Where(x => x.OriginalVoucherType == originalVoucherTypeCode).Select(x => x.MappedVoucherType).FirstOrDefault();

                            if (!string.IsNullOrEmpty(mappedVoucherTypeCode))
                            {

                                if (Convert.ToString(dr["slcd"]).Trim() == "SL")
                                {
                                    ledgerType = Common.ledgerTypeMap.Where(p => p.OriginaLedgerType == "SL").Select(p => p.MappedLedgerType).FirstOrDefault();
                                    var supp = Common.supplierLedgerCodeMap.Where(p => p.OriginalSupplierLedgerCode == Convert.ToString(dr["ACNO"]).Trim()).FirstOrDefault();
                                    ledgerTypeCode = supp.MappedSupplierLedgerCode;
                                    ledgerTypeName = supp.SupplierLedgerName;

                                }
                                else if (Convert.ToString(dr["slcd"]).Trim() == "CL")
                                {
                                    ledgerType = Common.ledgerTypeMap.Where(p => p.OriginaLedgerType == "CL").Select(p => p.MappedLedgerType).FirstOrDefault();
                                    var cust = Common.customerLedgerCodeMap.Where(p => p.OriginalCustomerLedgerCode == Convert.ToString(dr["ACNO"]).Trim()).FirstOrDefault();
                                    ledgerTypeCode = cust.MappedCustomerLedgerCode;
                                    ledgerTypeName = cust.CustomerLedgerName;
                                }


                                newReceiptPayment.VoucherTypeCode = mappedVoucherTypeCode;
                                newReceiptPayment.VoucherNumber = newVNo;
                                newReceiptPayment.VoucherDate = Convert.ToDateTime(dr["vdt"]);
                                newReceiptPayment.LedgerType = ledgerType;
                                newReceiptPayment.LedgerTypeCode = ledgerTypeCode;
                                newReceiptPayment.LedgerTypeName = ledgerTypeName;

                                newReceiptPayment.PaymentMode = Convert.ToString(dr["MODE"]).Trim();

                                string bankAccountLedgerTypeCode = string.Empty;
                                string bankAccountLedgerTypeName = string.Empty;
                                string mappedBankAccountLedgerTypeCode = string.Empty;
                                
                                if (newReceiptPayment.PaymentMode == "Q")
                                {
                                    string originalBankAccountLedgerTypeCode = Convert.ToString(dr["BACNO"]).Trim();

                                    if(string.IsNullOrEmpty(originalBankAccountLedgerTypeCode))
                                    {
                                        log.Info(string.Format("BACNO iS BLANK FOR Q and VNO is {0}", oldVNo));
                                        throw new Exception("");
                                    }

                                    var bac  = accountLedgerCodeMap.Where(p => p.OriginalAccountLedgerCode == originalBankAccountLedgerTypeCode).FirstOrDefault();

                                    if (bac == null)
                                    {
                                        log.Info(string.Format("accountLedgerCodeMap iS BLANK FOR Q and BAC is {0}", originalBankAccountLedgerTypeCode));
                                        throw new Exception("");
                                    }

                                    bankAccountLedgerTypeCode = bac.MappedAccountLedgerCode;
                                    bankAccountLedgerTypeName = bac.AccountLedgerName; 
                                }
                                else
                                {
                                    var bac = accountLedgerCodeMap.Where(p => p.AccountLedgerName.Contains("CASH")).FirstOrDefault();

                                    if (bac == null)
                                    {
                                        log.Info(string.Format("accountLedgerCodeMap iS BLANK FOR C and BAC is {0}", "CASH"));
                                        throw new Exception("");
                                    }

                                    bankAccountLedgerTypeCode = bac.MappedAccountLedgerCode;
                                    bankAccountLedgerTypeName = bac.AccountLedgerName;
                                }

                                newReceiptPayment.BankAccountLedgerTypeCode = bankAccountLedgerTypeCode;
                                newReceiptPayment.BankAccountLedgerTypeName = bankAccountLedgerTypeName;


                                newReceiptPayment.Amount = CommonMethods.SafeConversionDecimal(Convert.ToString(dr["AMT"]).Trim()) ?? default(decimal);
                                newReceiptPayment.ChequeNumber = Convert.ToString(dr["CHQNO"]);
                                newReceiptPayment.ChequeDate = (DateTime)CommonMethods.SafeConversionDatetime(Convert.ToString(dr["CHQDT"]).Trim());
                                newReceiptPayment.ChequeClearDate = (DateTime)CommonMethods.SafeConversionDatetime(Convert.ToString(dr["CLRDT"]).Trim());
                                newReceiptPayment.IsChequeCleared = false;// dr["CLEARED"] == null ? false : Convert.ToBoolean( dr["CLEARED"]);
                                newReceiptPayment.POST = "";
                                newReceiptPayment.PISNumber = Convert.ToString(dr["PISNO"]).Trim();
                                newReceiptPayment.UnadjustedAmount = 0;

                                listReceiptPayment.Add(newReceiptPayment);
                            }
                            else
                            {
                                log.Info(string.Format("ReceiptPayment: Error in Voucher Type {0} for VNo {1}}", Convert.ToString(dr["vtyp"]).Trim(), Convert.ToString(dr["vno"]).Trim()));
                            }
                        }
                        catch (Exception ex)
                        {
                            log.Info(string.Format("ReceiptPayment: Error in Voucher Number {0} and error {1}", Convert.ToString(dr["vno"]).Trim(),ex.ToString()));
                        }
                    }
                }

                context.ReceiptPayment.AddRange(listReceiptPayment);
                result = context.SaveChanges();


                return result;

            }

        }

        public int InsertReceiptPaymentData()
        {
            try
            {
                int _result = 0;

                foreach (var item in Common.voucherTypeMap.Where(p=>p.OriginalVoucherType == "RT" || p.OriginalVoucherType == "PT"))
                {
                    string query = string.Format("select * from RCPTPYMT WHERE VTYP = '{0}'", item.OriginalVoucherType);
                    DataTable dt = dbConnection.GetData(query);
                    _result += InsertData(dt);
                }

                FillVoucherNumberMapping();

                return _result;
            }
            catch (DbEntityValidationException ex)
            {
                log.Info(string.Format("ReceiptPayment: Error {0}", ex.Message));

                // Retrieve the error messages as a list of strings.
                var errorMessages = ex.EntityValidationErrors
                        .SelectMany(x => x.ValidationErrors)
                        .Select(x => x.ErrorMessage);

                // Join the list to a single string.
                var fullErrorMessage = string.Join("; ", errorMessages);

                // Combine the original exception message with the new one.
                var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);
                log.Info(exceptionMessage);

                throw ex;
            }
            catch (Exception ex)
            {

                log.Info(string.Format("ReceiptPayment: Error {0}", ex.Message));
                throw ex;
            }
        }

        private void FillVoucherNumberMapping()
        {
            try
            {
                using (PharmaDBEntities context = new PharmaDBEntities())
                {
                    var list = context.ReceiptPayment.Select(p => new
                    {
                        PurchaseSaleBookHeaderID = p.ReceiptPaymentID,
                        VoucherNumber = p.VoucherNumber
                    }).ToList();

                    if (list != null && list.Count > 0)
                    {
                        foreach (var item in Common.receiptPaymentVoucherNumberMap)
                        {
                            var dd = list.Where(p => p.VoucherNumber == item.MappedVoucherNumber).FirstOrDefault();

                            if (dd != null)
                            {
                                item.MappedReceiptPaymentID = dd.PurchaseSaleBookHeaderID;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                log.Info("ReceiptPayment FillVoucherNumberMapping -->  " + ex.Message);
            }
        }



    }
}
