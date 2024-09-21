using log4net;
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
    public class BillOutStandingsAudjustmentMigration
    {

        private readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private DBFConnectionManager dbConnection;

        public BillOutStandingsAudjustmentMigration()
        {
            dbConnection = new DBFConnectionManager(Common.DataDirectory);
        }

        private int InsertData(DataTable dtSalePur)
        {
            int result = 0;

            List<PharmaDAL.Entity.BillOutStandingsAudjustment> listBillOutStandingsAudjustment = new List<PharmaDAL.Entity.BillOutStandingsAudjustment>();

            using (PharmaDBEntities context = new PharmaDBEntities())
            {
                if (dtSalePur != null && dtSalePur.Rows.Count > 0)
                {                  
                    foreach (DataRow dr in dtSalePur.Rows)
                    {
                        try
                        {
                            

                            PharmaDAL.Entity.BillOutStandingsAudjustment newBillOutStandingsAudjustment = new PharmaDAL.Entity.BillOutStandingsAudjustment();

                            string oldVNo = Convert.ToString(dr["vno"]).Trim();

                           // log.Info(string.Format("BillOutStandingsAudjustment: Process Startr FOR VNO{0} for AVNo {1}", Convert.ToString(dr["vno"]).Trim(), Convert.ToString(dr["avno"]).Trim()));

                            if (string.IsNullOrEmpty(oldVNo))
                            {
                                throw new Exception(" oldVNo is BLANK");
                            }

                            var header = Common.receiptPaymentVoucherNumberMap.Where(p => p.OriginalVoucherNumber.Trim() == oldVNo).FirstOrDefault();

                            if (header != null)
                            {                               
                                string ledgerType = string.Empty;
                                string ledgerTypeCode = string.Empty;

                                string originalVoucherTypeCode = Convert.ToString(dr["vtyp"]).Trim();

                                if(string.IsNullOrEmpty(originalVoucherTypeCode))
                                {
                                    throw new Exception(" originalVoucherTypeCode is BLANK");
                                }                                

                                var mappedVoucherTypeCode = Common.voucherTypeMap.Where(x => x.OriginalVoucherType == originalVoucherTypeCode).FirstOrDefault();

                                if (mappedVoucherTypeCode != null)
                                {
                                    if (Convert.ToString(dr["slcd"]).Trim() == "SL")
                                    {
                                        ledgerType = Common.ledgerTypeMap.Where(p => p.OriginaLedgerType == "SL").Select(p => p.MappedLedgerType).FirstOrDefault();
                                        ledgerTypeCode = Common.supplierLedgerCodeMap.Where(p => p.OriginalSupplierLedgerCode == Convert.ToString(dr["ACNO"]).Trim()).Select(x => x.MappedSupplierLedgerCode).FirstOrDefault();
                                    }
                                    else if (Convert.ToString(dr["slcd"]).Trim() == "CL")
                                    {
                                        ledgerType = Common.ledgerTypeMap.Where(p => p.OriginaLedgerType == "CL").Select(p => p.MappedLedgerType).FirstOrDefault();
                                        ledgerTypeCode = Common.customerLedgerCodeMap.Where(p => p.OriginalCustomerLedgerCode == Convert.ToString(dr["ACNO"]).Trim()).Select(x => x.MappedCustomerLedgerCode).FirstOrDefault();
                                    }

                                    newBillOutStandingsAudjustment.ReceiptPaymentID = header.MappedReceiptPaymentID;
                                    newBillOutStandingsAudjustment.VoucherNumber = header.MappedVoucherNumber;
                                    newBillOutStandingsAudjustment.VoucherTypeCode = mappedVoucherTypeCode.MappedVoucherType;
                                    newBillOutStandingsAudjustment.VoucherDate = (DateTime)CommonMethods.SafeConversionDatetime(Convert.ToString(dr["vdt"]));

                                    newBillOutStandingsAudjustment.LedgerType = ledgerType;
                                    newBillOutStandingsAudjustment.LedgerTypeCode = ledgerTypeCode;

                                    string avtyp = Convert.ToString(dr["AVTYP"]).Trim();

                                    DateTime AVDT = (DateTime)CommonMethods.SafeConversionDatetime(Convert.ToString(dr["AVDT"]).Trim());
                                    string AVNO = Convert.ToString(dr["AVNO"]).Trim();


                                    if (string.IsNullOrEmpty(avtyp))
                                    {
                                        throw new Exception("AVTYP is BLANK.");
                                    }

                                    if (string.IsNullOrEmpty(AVNO))
                                    {
                                        throw new Exception("AVNO is BLANK.");
                                    }

                                    var av = Common.voucherNumberMap.Where(p => p.OriginalVoucherNumber == AVNO).FirstOrDefault();

                                    if (av == null)
                                    {
                                        throw new Exception("AV is NULL. for Original AVNO IS  --> " + AVNO);
                                    }
                                    else
                                    {
                                        //log.Info(string.Format("BillOutStandingsAudjustment: VNO {0} , AVNO {1} , MAPPED {2} , BILL OS ID {3}"
                                        //    , Convert.ToString(dr["vno"]).Trim()
                                        //    , Convert.ToString(dr["avno"]).Trim()
                                        //    ,av.MappedVoucherNumber,
                                        //    av.BillOutstandingID));

                                        if(av.BillOutstandingID == 0)
                                        {
                                            throw new Exception("Bill OS ID IS 0");
                                        }

                                        newBillOutStandingsAudjustment.BillOutStandingsID = av.BillOutstandingID;
                                        newBillOutStandingsAudjustment.AdjustmentVoucherNumber = av.MappedVoucherNumber;
                                    }

                                    var avt = Common.voucherTypeMap.Where(p => p.OriginalVoucherType == avtyp).FirstOrDefault();

                                    if(avt == null)
                                    {
                                        throw new Exception("AVT is NULL.");
                                    }
                                    else
                                    {
                                        newBillOutStandingsAudjustment.AdjustmentVoucherTypeCode = avt.MappedVoucherType;
                                    }
                                    
                                    newBillOutStandingsAudjustment.AdjustmentVoucherDate = AVDT;

                                    newBillOutStandingsAudjustment.Amount = Convert.ToDecimal(dr["AMT"]);
                                    newBillOutStandingsAudjustment.ChequeNumber = Convert.ToString(dr["CHQNO"]);

                                    listBillOutStandingsAudjustment.Add(newBillOutStandingsAudjustment);
                                }
                                else
                                {
                                    log.Info(string.Format("BillOutStandingsAudjustment: Error in VTY NOT FOUND Voucher Type {0} for VNo {1}", Convert.ToString(dr["vtyp"]).Trim(), Convert.ToString(dr["vno"]).Trim()));
                                }
                            }
                            else
                            {                               
                                log.Info(string.Format("BillOutStandingsAudjustment: Voucher No  Not found in for VNO {0}", oldVNo));
                            }
                        }
                        catch (Exception ex)
                        {
                            log.Info(string.Format("BillOutStandingsAudjustment: Error in Voucher Number {0}", Convert.ToString(dr["vno"]).Trim() + "  ERROR IS  --> " + ex.Message));
                        }
                    }
                }

                context.BillOutStandingsAudjustment.AddRange(listBillOutStandingsAudjustment);
                result = context.SaveChanges();

                return result;
            }
        }

        public int InsertBillOutStandingsAudjustmentData()
        {
            try
            {
                int _result = 0;

                string query = "select  * from ADJSTMNT WHERE VTYP = 'RT' OR VTYP = 'PT' ";
                //string query = "select top 10 * from ADJSTMNT WHERE VTYP = 'RT' order by vtyp";
                DataTable dtSalePur = dbConnection.GetData(query);
                _result += InsertData(dtSalePur);

                return _result;
            }
            catch (DbEntityValidationException ex)
            {
                log.Info(string.Format("BillOutStandingsAudjustment: Error {0}", ex.Message));

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
                Exception e = ex;
                while (e.InnerException != null)
                {
                    e = e.InnerException;
                }

                log.Info(string.Format("BillOutStandingsAudjustment: Error {0}", e.Message));

               
                log.Info(string.Format("BillOutStandingsAudjustment: Error {0}", ex.Message));
                throw ex;
            }
        }


    }
}
