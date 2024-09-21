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
using System.Diagnostics;

namespace PharmaDataMigration.Master
{
    public class FIFO
    {
        private readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private DBFConnectionManager dbConnection;

        public FIFO()
        {
            dbConnection = new DBFConnectionManager(Common.DataDirectory);
        }

        public int InsertFIFOData()
        {
            try
            {
                string query = "select * from FIFO";
                DataTable dtFIFO = dbConnection.GetData(query);

                List<PharmaDAL.Entity.FIFO> listFIFO = new List<PharmaDAL.Entity.FIFO>();
                int _result = 0;

                using (PharmaDBEntities context = new PharmaDBEntities())
                {
                    if (dtFIFO != null && dtFIFO.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dtFIFO.Rows)
                        {
                            try
                            {
                                string originalItemCode = Convert.ToString(dr["itemc"]).Trim();
                                string mappedItemCode = Common.itemCodeMap.Where(x => x.OriginalItemCode == originalItemCode).Select(x => x.MappedItemCode).FirstOrDefault();

                                if (string.IsNullOrEmpty(mappedItemCode))
                                {
                                    log.Info(string.Format("FIFO: Item Code Not found in Item Master {0}", originalItemCode));
                                    throw new Exception();
                                }                                

                                PharmaDAL.Entity.FIFO newFIFO = new PharmaDAL.Entity.FIFO();

                                string oldVNo = Convert.ToString(dr["vno"]).Trim();
                                var header = Common.voucherNumberMap.Where(p => p.OriginalVoucherNumber.Trim() == oldVNo).FirstOrDefault();

                                if (header != null)
                                {
                                    newFIFO.PurchaseSaleBookHeaderID = header.MappedPurchaseHeaderID;
                                    newFIFO.VoucherNumber = header.MappedVoucherNumber;
                                }
                                else
                                {
                                    newFIFO.VoucherNumber = (Convert.ToString(dr["vno"]).Trim()).PadLeft(8, '0');
                                    log.Info(string.Format("FIFO: Voucher No  Not found in for VNO {0}", oldVNo));
                                }


                                newFIFO.VoucherDate = Convert.ToDateTime(dr["vdt"]);
                                newFIFO.SRLNO = Convert.ToInt32(dr["srlno"]);
                                newFIFO.ItemCode = mappedItemCode;
                                newFIFO.PurchaseBillNo = Convert.ToString(dr["pbillno"]).Trim();
                                newFIFO.Batch = Convert.ToString(dr["batch"]).Trim();
                                newFIFO.ExpiryDate = CommonMethods.SafeConversionDatetime(Convert.ToString(dr["expdt"]).Trim());
                                newFIFO.Quantity = CommonMethods.SafeConversionDecimal(Convert.ToString(dr["qty"]).Trim()) ?? default(decimal);
                                newFIFO.BalanceQuanity = CommonMethods.SafeConversionDecimal(Convert.ToString(dr["bqty"]).Trim()) ?? default(decimal);
                                newFIFO.PurchaseTypeId = null;
                                newFIFO.PurchaseRate = CommonMethods.SafeConversionDecimal(Convert.ToString(dr["prate"]).Trim()) ?? default(decimal);
                                newFIFO.EffectivePurchaseRate = CommonMethods.SafeConversionDecimal(Convert.ToString(dr["eprate"]).Trim());
                                newFIFO.SaleRate = CommonMethods.SafeConversionDecimal(Convert.ToString(dr["srate"]).Trim()) ?? default(decimal);
                                newFIFO.WholeSaleRate = CommonMethods.SafeConversionDecimal(Convert.ToString(dr["wsrate"]).Trim());
                                newFIFO.SpecialRate = CommonMethods.SafeConversionDecimal(Convert.ToString(dr["splrate"]).Trim());
                                newFIFO.MRP = CommonMethods.SafeConversionDecimal(Convert.ToString(dr["mrp"]).Trim()) ?? default(decimal);
                                newFIFO.Scheme1 = CommonMethods.SafeConversionDecimal(Convert.ToString(dr["scheme1"]).Trim());
                                newFIFO.Scheme2 = CommonMethods.SafeConversionDecimal(Convert.ToString(dr["scheme2"]).Trim());
                                newFIFO.IsOnHold = false;// Convert.ToString(dr["hold"]).Trim() == "Y" ? true : false;
                                newFIFO.OnHoldRemarks = null;
                                newFIFO.MfgDate = CommonMethods.SafeConversionDatetime(Convert.ToString(dr["mfgdt"]).Trim());
                                newFIFO.UPC = Convert.ToString(dr["barcode"]).Trim();

                                listFIFO.Add(newFIFO);
                            }
                            catch (Exception ex)
                            {
                                log.Info(string.Format("FIFO: Error in Voucher Number {0}", Convert.ToString(dr["vno"]).Trim()));

                                //Get a StackTrace object for the exception
                                StackTrace st = new StackTrace(ex, true);


                            }
                        }
                    }

                    context.FIFO.AddRange(listFIFO);
                    _result = context.SaveChanges();

                    return _result;
                }
            }
            catch (DbEntityValidationException ex)
            {
                log.Info(string.Format("FIFO: Error {0}", ex.Message));
                throw ex;
            }
            catch (Exception ex)
            {
               
                log.Info(string.Format("FIFO: Error {0}", ex.Message));
                throw ex;
            }
        }

    }
}

