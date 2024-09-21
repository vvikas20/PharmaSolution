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
    public class PurchaseSaleBookHeaderMigration
    {
        private readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private DBFConnectionManager dbConnection;

        public PurchaseSaleBookHeaderMigration()
        {
            dbConnection = new DBFConnectionManager(Common.DataDirectory);
        }


        private int InsertData(DataTable dtSalePur)
        {
            int result = 0;

            List<PharmaDAL.Entity.PurchaseSaleBookHeader> listPurchaseSaleBookHeader = new List<PharmaDAL.Entity.PurchaseSaleBookHeader>();

            using (PharmaDBEntities context = new PharmaDBEntities())
            {
                if (dtSalePur != null && dtSalePur.Rows.Count > 0)
                {
                    var personRouteList = context.PersonRouteMaster.Select(r => r).ToList();
                    var areaList = personRouteList.Where(q => q.RecordType.SystemName == PharmaBusinessObjects.Common.Constants.RecordType.AREA).Select(r => r).ToList();
                    var salesmanList = personRouteList.Where(q => q.RecordType.SystemName == PharmaBusinessObjects.Common.Constants.RecordType.SALESMAN).Select(r => r).ToList();
                    var routeList = personRouteList.Where(q => q.RecordType.SystemName == PharmaBusinessObjects.Common.Constants.RecordType.ROUTE).Select(r => r).ToList();
                    var asmList = personRouteList.Where(q => q.RecordType.SystemName == PharmaBusinessObjects.Common.Constants.RecordType.ASM).Select(r => r).ToList();
                    var rsmList = personRouteList.Where(q => q.RecordType.SystemName == PharmaBusinessObjects.Common.Constants.RecordType.RSM).Select(r => r).ToList();
                    var zsmList = personRouteList.Where(q => q.RecordType.SystemName == PharmaBusinessObjects.Common.Constants.RecordType.ZSM).Select(r => r).ToList();

                    var customerTypeList = context.CustomerType.Select(p => p);

                    foreach (DataRow dr in dtSalePur.Rows)
                    {
                        try
                        {
                            PharmaDAL.Entity.PurchaseSaleBookHeader newPurchaseSaleBookHeader = new PharmaDAL.Entity.PurchaseSaleBookHeader();

                            string oldVNo = Convert.ToString(dr["vno"]).Trim();
                            string newVNo = (Convert.ToString(dr["vno"]).Trim()).PadLeft(8, '0');

                            Common.voucherNumberMap.Add(new VoucherNumberMap() { OriginalVoucherNumber = oldVNo, MappedVoucherNumber = newVNo });

                            string ledgerType = string.Empty;
                            string ledgerTypeCode = string.Empty;

                            string originalVoucherTypeCode = Convert.ToString(dr["vtyp"]).Trim();
                            string mappedVoucherTypeCode = Common.voucherTypeMap.Where(x => x.OriginalVoucherType == originalVoucherTypeCode).Select(x => x.MappedVoucherType).FirstOrDefault();

                            if (!string.IsNullOrEmpty(mappedVoucherTypeCode))
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

                               // log.Info(string.Format("PurchaseSaleBookHeader LOCALCENTRAL --> {0} for VNO ", Convert.ToString(dr["SALE_LORC"]), oldVNo));

                                if (dr["SALE_LORC"] == null || string.IsNullOrEmpty(Convert.ToString(dr["SALE_LORC"]).Trim()))
                                {
                                    newPurchaseSaleBookHeader.LocalCentral = "L";
                                }
                                else
                                {
                                    newPurchaseSaleBookHeader.LocalCentral = Convert.ToString(dr["SALE_LORC"]);
                                }

                                newPurchaseSaleBookHeader.VoucherTypeCode = mappedVoucherTypeCode;
                                newPurchaseSaleBookHeader.VoucherNumber = newVNo;
                                newPurchaseSaleBookHeader.VoucherDate = Convert.ToDateTime(dr["vdt"]);
                                newPurchaseSaleBookHeader.DueDate = Convert.ToDateTime(dr["DUEDT"]);
                                newPurchaseSaleBookHeader.PurchaseBillNo = Convert.ToString(dr["PBILLNO"]).Trim();
                                newPurchaseSaleBookHeader.LedgerType = ledgerType;
                                newPurchaseSaleBookHeader.LedgerTypeCode = ledgerTypeCode;


                                newPurchaseSaleBookHeader.Amount01 = CommonMethods.SafeConversionDecimal(Convert.ToString(dr["AMT03"]));
                                newPurchaseSaleBookHeader.Amount02 = CommonMethods.SafeConversionDecimal(Convert.ToString(dr["AMT01"]));
                                newPurchaseSaleBookHeader.Amount03 = default(decimal);
                                newPurchaseSaleBookHeader.Amount04 = CommonMethods.SafeConversionDecimal(Convert.ToString(dr["AMT02"]));
                                newPurchaseSaleBookHeader.Amount05 = CommonMethods.SafeConversionDecimal(Convert.ToString(dr["AMT04"]));
                                newPurchaseSaleBookHeader.Amount06 = CommonMethods.SafeConversionDecimal(Convert.ToString(dr["AMT05"]));
                                newPurchaseSaleBookHeader.Amount07 = default(decimal);                               

                                newPurchaseSaleBookHeader.SGST01 = default(decimal);                               
                                newPurchaseSaleBookHeader.SGST03 = default(decimal);
                                newPurchaseSaleBookHeader.SGST07 = default(decimal);
                                newPurchaseSaleBookHeader.IGST01 = default(decimal);
                                newPurchaseSaleBookHeader.IGST03 = default(decimal);
                                newPurchaseSaleBookHeader.IGST07 = default(decimal);
                                newPurchaseSaleBookHeader.CGST01 = default(decimal);
                                newPurchaseSaleBookHeader.CGST03 = default(decimal);
                                newPurchaseSaleBookHeader.CGST07 = default(decimal);

                                if (newPurchaseSaleBookHeader.LocalCentral == "L")
                                {
                                    newPurchaseSaleBookHeader.SGST02 = CommonMethods.SafeConversionDecimal(Convert.ToString(dr["TAXAMT"])) * (decimal)0.5;
                                    newPurchaseSaleBookHeader.SGST04 = CommonMethods.SafeConversionDecimal(Convert.ToString(dr["SCAMT"])) * (decimal)0.5;
                                    newPurchaseSaleBookHeader.SGST05 = CommonMethods.SafeConversionDecimal(Convert.ToString(dr["TAMT4"])) * (decimal)0.5;
                                    newPurchaseSaleBookHeader.SGST06 = CommonMethods.SafeConversionDecimal(Convert.ToString(dr["TAMT5"])) * (decimal)0.5;

                                    newPurchaseSaleBookHeader.CGST02 = CommonMethods.SafeConversionDecimal(Convert.ToString(dr["TAXAMT"])) * (decimal)0.5;
                                    newPurchaseSaleBookHeader.CGST04 = CommonMethods.SafeConversionDecimal(Convert.ToString(dr["SCAMT"])) * (decimal)0.5;
                                    newPurchaseSaleBookHeader.CGST05 = CommonMethods.SafeConversionDecimal(Convert.ToString(dr["TAMT4"])) * (decimal)0.5;
                                    newPurchaseSaleBookHeader.CGST06 = CommonMethods.SafeConversionDecimal(Convert.ToString(dr["TAMT5"])) * (decimal)0.5;
                                }
                                else
                                {
                                    newPurchaseSaleBookHeader.IGST02 = CommonMethods.SafeConversionDecimal(Convert.ToString(dr["TAXAMT"]));
                                    newPurchaseSaleBookHeader.IGST04 = CommonMethods.SafeConversionDecimal(Convert.ToString(dr["SCAMT"]));
                                    newPurchaseSaleBookHeader.IGST05 = CommonMethods.SafeConversionDecimal(Convert.ToString(dr["TAMT4"]));
                                    newPurchaseSaleBookHeader.IGST06 = CommonMethods.SafeConversionDecimal(Convert.ToString(dr["TAMT5"]));
                                }

                                newPurchaseSaleBookHeader.TotalTaxAmount =Convert.ToDecimal(CommonMethods.SafeConversionDecimal(Convert.ToString(dr["TAXAMT"]))
                                    + CommonMethods.SafeConversionDecimal(Convert.ToString(dr["SCAMT"]))
                                    + CommonMethods.SafeConversionDecimal(Convert.ToString(dr["TAMT4"]))
                                    + CommonMethods.SafeConversionDecimal(Convert.ToString(dr["TAMT5"])));


                                newPurchaseSaleBookHeader.SurchargeAmount = default(decimal);
                                newPurchaseSaleBookHeader.TotalGrossAmount = default(decimal);

                                if (mappedVoucherTypeCode == Constants.VoucherTypeCode.SALEENTRY
                                    || mappedVoucherTypeCode == Constants.VoucherTypeCode.SALEONCHALLAN
                                    || mappedVoucherTypeCode == Constants.VoucherTypeCode.SALERETURN
                                    || mappedVoucherTypeCode == Constants.VoucherTypeCode.SALERETURNBREAKAGEEXPIRY
                                    || mappedVoucherTypeCode == Constants.VoucherTypeCode.CREDITNOTE
                                    || mappedVoucherTypeCode == Constants.VoucherTypeCode.BREAKAGEEXPIRY)
                                {
                                    newPurchaseSaleBookHeader.TotalBillAmount = CommonMethods.SafeConversionDecimal(Convert.ToString(dr["RNDAMT"]));

                                }
                                else if(mappedVoucherTypeCode == Constants.VoucherTypeCode.PURCHASEENTRY
                                    || mappedVoucherTypeCode == Constants.VoucherTypeCode.PURCHASERETURN
                                    || mappedVoucherTypeCode == Constants.VoucherTypeCode.DEBITNOTE)
                                {
                                    newPurchaseSaleBookHeader.TotalBillAmount = CommonMethods.SafeConversionDecimal(Convert.ToString(dr["AMT"]));

                                }
                                else
                                {
                                    newPurchaseSaleBookHeader.TotalBillAmount = default(decimal);

                                }

                                newPurchaseSaleBookHeader.TotalCostAmount = CommonMethods.SafeConversionDecimal(Convert.ToString(dr["COSTAMT"]));                                
                                newPurchaseSaleBookHeader.TotalSchemeAmount = CommonMethods.SafeConversionDecimal(Convert.ToString(dr["HSAMT"]));
                                newPurchaseSaleBookHeader.TotalDiscountAmount = CommonMethods.SafeConversionDecimal(Convert.ToString(dr["DISAMT"]));
                                newPurchaseSaleBookHeader.OtherAmount = default(decimal);

                                

                                try
                                {
                                    string areaCode = string.IsNullOrEmpty(Convert.ToString(dr["Parea"]).Trim()) ? null : Common.areaCodeMap.Where(p => p.OriginalAreaCode == Convert.ToString(dr["Parea"]).Trim()).FirstOrDefault().MappedAreaCode;
                                    int? areaID = areaCode == null ? (int?)null : areaList.Where(q => q.PersonRouteCode == areaCode).FirstOrDefault().PersonRouteID;
                                    newPurchaseSaleBookHeader.AreaId = areaID;
                                }
                                catch { }

                                try
                                {
                                    string salesmanCode = string.IsNullOrEmpty(Convert.ToString(dr["Sman"]).Trim())
                                                        ? null : Common.salesmanCodeMap.Where(p => p.OriginalSalesManCode == Convert.ToString(dr["Sman"]).Trim()).FirstOrDefault().MappedSalesManCode;
                                    int? salesmanID = salesmanCode == null ? (int?)null : salesmanList.Where(q => q.PersonRouteCode == salesmanCode).FirstOrDefault().PersonRouteID;
                                    newPurchaseSaleBookHeader.SalesManId = salesmanID;
                                }
                                catch { }

                                try
                                {
                                    string routeCode = string.IsNullOrEmpty(Convert.ToString(dr["Route"]).Trim()) ? null : Common.routeCodeMap.Where(p => p.OriginalRouteCode == Convert.ToString(dr["Route"]).Trim()).FirstOrDefault().MappedRouteCode;
                                    int? routeID = routeCode == null ? (int?)null : routeList.Where(q => q.PersonRouteCode == routeCode).FirstOrDefault().PersonRouteID;
                                    newPurchaseSaleBookHeader.RouteId = routeID;
                                }
                                catch { }

                                try
                                {
                                    string asmCode = string.IsNullOrEmpty(Convert.ToString(dr["Asm"]).Trim()) ? null : Common.asmCodeMap.Where(p => p.OriginalASMCode == Convert.ToString(dr["Asm"]).Trim()).FirstOrDefault().MappedASMCode;
                                    int? asmID = asmCode == null ? (int?)null : asmList.Where(q => q.PersonRouteCode == asmCode).FirstOrDefault().PersonRouteID;
                                    newPurchaseSaleBookHeader.ASMId = asmID;
                                }
                                catch { }

                                try
                                {
                                    string rsmCode = string.IsNullOrEmpty(Convert.ToString(dr["Rsm"]).Trim()) ? null : Common.rsmCodeMap.Where(p => p.OriginalRSMCode == Convert.ToString(dr["Rsm"]).Trim()).FirstOrDefault().MappedRSMCode;
                                    int? rsmID = rsmCode == null ? (int?)null : rsmList.Where(q => q.PersonRouteCode == rsmCode).FirstOrDefault().PersonRouteID;
                                    newPurchaseSaleBookHeader.RSMId = rsmID;
                                }
                                catch { }

                                try
                                {
                                    string zsmCode = string.IsNullOrEmpty(Convert.ToString(dr["Zsm"]).Trim()) ? null : Common.zsmCodeMap.Where(p => p.OriginalZSMCode == Convert.ToString(dr["Zsm"]).Trim()).FirstOrDefault().MappedZSMCode;
                                    int? zsmID = zsmCode == null ? (int?)null : zsmList.Where(q => q.PersonRouteCode == zsmCode).FirstOrDefault().PersonRouteID;
                                    newPurchaseSaleBookHeader.ZSMId = zsmID;
                                }
                                catch { }

                                try
                                {
                                    string customerType = Convert.ToString(dr["Wr"]).Trim();
                                    int customerTypeID = customerTypeList.Where(p => p.CustomerTypeShortName == customerType).FirstOrDefault().CustomerTypeId;
                                    newPurchaseSaleBookHeader.CustomerTypeId = customerTypeID;
                                }
                                catch { }

                                try
                                {
                                    if (dr[""] != null)
                                    {
                                        newPurchaseSaleBookHeader.RateTypeId = Convert.ToInt32(dr["SB_TYPE"]);
                                    }
                                }
                                catch { }


                                newPurchaseSaleBookHeader.FreshBreakageExcess = Convert.ToString(dr["FRBR"]);
                                newPurchaseSaleBookHeader.ReturnBillNo = Convert.ToString(dr["RINVNO"]);

                                if (dr["RINVDT"] != null)
                                {
                                    newPurchaseSaleBookHeader.ReturBillDate = Convert.ToDateTime(dr["RINVDT"]);
                                }

                               

                                newPurchaseSaleBookHeader.OrderNumber = Convert.ToString(dr["ORDNO1"]);
                                newPurchaseSaleBookHeader.ChallanNumber = Convert.ToString(dr["CHNO1"]);
                                newPurchaseSaleBookHeader.Message = Convert.ToString(dr["MESS1"]);
                                newPurchaseSaleBookHeader.Deliveryddress = Convert.ToString(dr["DLFROM"]);
                                newPurchaseSaleBookHeader.DeliveredBy = Convert.ToString(dr["DLBY"]);
                                newPurchaseSaleBookHeader.CourierName = Convert.ToString(dr["AIRBLNO"]);

                                if (dr["AIRBLDT"] != null)
                                {
                                    newPurchaseSaleBookHeader.CourierDate = Convert.ToDateTime(dr["AIRBLDT"]);
                                }

                                newPurchaseSaleBookHeader.CourierWeight = dr["WEIGHT"] == null ? default(decimal) : Convert.ToDecimal(dr["WEIGHT"]);
                                newPurchaseSaleBookHeader.LastBalance = dr["LBAL"] == null ? default(decimal) : Convert.ToDecimal(dr["LBAL"]);

                                //newPurchaseSaleBookHeader.PurchaseSaleEntryFormID = (Convert.ToString(dr["vno"]).Trim()).PadLeft(8, '0');

                                newPurchaseSaleBookHeader.CreatedBy = "admin";
                                newPurchaseSaleBookHeader.CreatedOn = DateTime.Now;



                                listPurchaseSaleBookHeader.Add(newPurchaseSaleBookHeader);
                            }
                            else
                            {
                                log.Info(string.Format("PurchaseSaleBookHeader: Error in Voucher Type {0} for VNo {1}}", Convert.ToString(dr["vtyp"]).Trim(), Convert.ToString(dr["vno"]).Trim()));
                            }
                        }
                        catch (Exception ex)
                        {
                            log.Info(string.Format("PurchaseSaleBookHeader: Error in Voucher Number {0}", Convert.ToString(dr["vno"]).Trim()));
                        }
                    }
                }

                context.PurchaseSaleBookHeader.AddRange(listPurchaseSaleBookHeader);
                result = context.SaveChanges();


                return result;
               
            }

        }

        public int InsertPurchaseSaleBookHeaderData()
        {
            try
            {
                int _result = 0;

                foreach (var item in Common.voucherTypeMap)
                {
                    string query = string.Format("select * from SalePur1 WHERE VTYP = '{0}'", item.OriginalVoucherType);
                    DataTable dtSalePur = dbConnection.GetData(query);
                    _result += InsertData(dtSalePur);
                }
               
                FillVoucherNumberMapping();

                return _result;
            }
            catch (DbEntityValidationException ex)
            {
                log.Info(string.Format("PurchaseSaleBookHeader: Error {0}", ex.Message));

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

                log.Info(string.Format("PurchaseSaleBookHeader: Error {0}", ex.Message));
                throw ex;
            }
        }

        private void FillVoucherNumberMapping()
        {
            try
            {
                using (PharmaDBEntities context = new PharmaDBEntities())
                {
                    var list = context.PurchaseSaleBookHeader.Select(p => new 
                    {
                        PurchaseSaleBookHeaderID = p.PurchaseSaleBookHeaderID,
                        VoucherNumber = p.VoucherNumber,
                        LocalCentral = p.LocalCentral
                    }).ToList();

                    if (list != null && list.Count > 0)
                    {
                        foreach (var item in Common.voucherNumberMap)
                        {
                            var dd = list.Where(p => p.VoucherNumber == item.MappedVoucherNumber).FirstOrDefault();
                            item.MappedPurchaseHeaderID = dd.PurchaseSaleBookHeaderID;
                            item.LocalCentral = dd.LocalCentral;
                        }
                    }
                }
            }
            catch(Exception ex) {
                log.Info("PurchaseSaleBookHeader FillVoucherNumberMapping -->  " + ex.Message);
            }
        }
    }
}
