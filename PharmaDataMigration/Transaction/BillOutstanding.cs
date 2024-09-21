 using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using PharmaDAL.Entity;
using log4net;
using System.Reflection;
using System.Windows.Forms;
using System.Data.Entity.Validation;
using PharmaBusinessObjects.Common;

namespace PharmaDataMigration.Master
{
    public class BillOutstanding
    {
        private readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private DBFConnectionManager dbConnection;        

        public BillOutstanding()
        {
            dbConnection = new DBFConnectionManager(Common.DataDirectory);           
        }      

        public int InsertBillOutstandingData()
        {
            try
            {
                string query = "select * from BILLOS";
                DataTable dtBillOutstanding = dbConnection.GetData(query);

                List<PharmaDAL.Entity.BillOutStandings> listBillOutstandings = new List<PharmaDAL.Entity.BillOutStandings>();
                int _result = 0;

                using (PharmaDBEntities context = new PharmaDBEntities())
                {
                    if (dtBillOutstanding != null && dtBillOutstanding.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dtBillOutstanding.Rows)
                        {
                            try
                            {
                                string ledgerType = string.Empty;
                                string ledgerTypeCode = string.Empty;

                                if(string.IsNullOrWhiteSpace(Convert.ToString(dr["vno"]).Trim()))
                                {
                                    throw new Exception();
                                }
                                else if(Convert.ToString(dr["vno"]).Trim().Length > 8)
                                {
                                    log.Error("BillOS : VNO Length is greater than 8 -->" + Convert.ToString(dr["vno"]).Trim());
                                    throw new Exception();
                                }

                                string originalVoucherTypeCode = Convert.ToString(dr["vtyp"]).Trim();
                                string mappedVoucherTypeCode = Common.voucherTypeMap.Where(x => x.OriginalVoucherType == originalVoucherTypeCode).Select(x => x.MappedVoucherType).FirstOrDefault();

                                if (Convert.ToString(dr["slcd"]).Trim() == "SL")
                                {
                                    ledgerType = Common.ledgerTypeMap.Where(p => p.OriginaLedgerType == "SL").Select(p => p.MappedLedgerType).FirstOrDefault();
                                    ledgerTypeCode= Common.supplierLedgerCodeMap.Where(p => p.OriginalSupplierLedgerCode == Convert.ToString(dr["ACNO"]).Trim()).Select(x=>x.MappedSupplierLedgerCode).FirstOrDefault();                                  
                                }
                                else if (Convert.ToString(dr["slcd"]).Trim() == "CL")
                                {
                                    ledgerType = Common.ledgerTypeMap.Where(p => p.OriginaLedgerType == "CL").Select(p => p.MappedLedgerType).FirstOrDefault();
                                    ledgerTypeCode = Common.customerLedgerCodeMap.Where(p => p.OriginalCustomerLedgerCode == Convert.ToString(dr["ACNO"]).Trim()).Select(x=>x.MappedCustomerLedgerCode).FirstOrDefault();
                                }

                                string oldVNo = Convert.ToString(dr["vno"]).Trim();
                                var header = Common.voucherNumberMap.Where(p => p.OriginalVoucherNumber == oldVNo).FirstOrDefault();

                               PharmaDAL.Entity.BillOutStandings newBillOS = new PharmaDAL.Entity.BillOutStandings();

                                if (header != null)
                                {
                                    newBillOS.PurchaseSaleBookHeaderID = header.MappedPurchaseHeaderID;
                                    newBillOS.VoucherNumber = header.MappedVoucherNumber;
                                }
                                else
                                {
                                    newBillOS.VoucherNumber = (Convert.ToString(dr["vno"]).Trim()).PadLeft(8, '0');
                                    //log.Info(string.Format("BILLOS: Voucher No  Not found in for VNO {0}", oldVNo));
                                }
                                                               
                                newBillOS.VoucherTypeCode = mappedVoucherTypeCode;
                                newBillOS.VoucherDate = (DateTime)CommonMethods.SafeConversionDatetime(Convert.ToString(dr["vdt"]));
                                newBillOS.DueDate = CommonMethods.SafeConversionDatetime(Convert.ToString(dr["duedt"]));
                                newBillOS.LedgerType = ledgerType;
                                newBillOS.LedgerTypeCode = ledgerTypeCode;
                                newBillOS.BillAmount = CommonMethods.SafeConversionDecimal(Convert.ToString(dr["osamt"])) ?? default(decimal);
                                newBillOS.OSAmount = CommonMethods.SafeConversionDecimal(Convert.ToString(dr["osamt"])) ?? default(decimal);
                                newBillOS.IsHold = Convert.ToString(dr["vno"]).Trim() == "Y" ? true : false;
                                newBillOS.HOLDRemarks = null;
                                

                                listBillOutstandings.Add(newBillOS);
                            }
                            catch (Exception)
                            {
                                log.Info(string.Format("BILL OUTSTANDING: Error in Voucher Number {0}", Convert.ToString(dr["vno"]).Trim()));
                            }
                        }
                    }

                    context.BillOutStandings.AddRange(listBillOutstandings);
                    _result = context.SaveChanges();
                   
                }

                FillBillOsId();

                return _result;
            }
            catch (DbEntityValidationException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void FillBillOsId()
        {
            try
            {
                log.Info("BillOutStandings FillBillOustandingIDs --> STARTED ");
                using (PharmaDBEntities context = new PharmaDBEntities())
                {
                    var list = context.BillOutStandings.Select(p => new
                    {
                        PurchaseSaleBookHeaderID = p.PurchaseSaleBookHeaderID,
                        VoucherNumber = p.VoucherNumber,
                        BillOutStandingsID = p.BillOutStandingsID
                    }).ToList();

                    log.Info("BillOutStandings FillBillOustandingIDs --> list --> " + list.Count.ToString());

                    if (list != null && list.Count > 0)
                    {
                        foreach (var item in Common.voucherNumberMap)
                        {
                            var dd = list.Where(p => p.VoucherNumber == item.MappedVoucherNumber).FirstOrDefault();

                            if (dd != null)
                            {
                                item.BillOutstandingID = dd.BillOutStandingsID;
                            }                       
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                log.Info("BillOutStandings FillBillOustandingIDs -->  " + ex.Message);
            }
        }
    }
}
