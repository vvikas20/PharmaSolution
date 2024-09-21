using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using PharmaDAL.Entity;
using log4net;
using System.Reflection;
using System.Data.Entity.Validation;

namespace PharmaDataMigration.Master
{
    public class SupplierLedgerMaster
    {
        private readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private DBFConnectionManager dbConnection;

        public SupplierLedgerMaster()
        {
            dbConnection = new DBFConnectionManager(Common.DataDirectory);
        }

        public int InsertSupplierLedgerMasterData()
        {
            try
            {
                string query = "select * from ACM where slcd = 'SL'";

                DataTable dtSupplierLedgerMaster = dbConnection.GetData(query);

                List<SupplierLedger> listSupplierLedgerMaster = new List<SupplierLedger>();

                int _result = 0;
                                
                using (PharmaDBEntities context = new PharmaDBEntities())
                {
                    var maxSupplierLedgerID = context.SupplierLedger.Count();

                    if (dtSupplierLedgerMaster != null && dtSupplierLedgerMaster.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dtSupplierLedgerMaster.Rows)
                        {
                            try
                            {
                                maxSupplierLedgerID++;

                                string supplierLedgerCode = "S" + maxSupplierLedgerID.ToString().PadLeft(6, '0');
                                string originalSupplierLedgerCode = Convert.ToString(dr["ACNO"]).Trim();
                                Common.supplierLedgerCodeMap.Add(new SupplierLedgerCodeMap() { OriginalSupplierLedgerCode = originalSupplierLedgerCode, MappedSupplierLedgerCode = supplierLedgerCode });

                                string areaCode = Common.areaCodeMap.Where(p => p.OriginalAreaCode == Convert.ToString(dr["PAREA"]).Trim()).FirstOrDefault().MappedAreaCode;
                                int areaID = context.PersonRouteMaster.Where(q => q.PersonRouteCode == areaCode).FirstOrDefault().PersonRouteID;
                                string purchaseLedgerCode = Common.accountLedgerCodeMap.Where(q => q.OriginalAccountLedgerCode == Convert.ToString(dr["PCODE"]).Trim()).FirstOrDefault().MappedAccountLedgerCode;
                                int purchaseTypeID = context.AccountLedgerMaster.Where(p => p.AccountLedgerCode == purchaseLedgerCode).FirstOrDefault().AccountLedgerID;

                                SupplierLedger newSupplierLedgerMaster = new SupplierLedger()
                                {
                                    SupplierLedgerCode = supplierLedgerCode,
                                    SupplierLedgerName = Convert.ToString(dr["ACName"]).Trim(),
                                    SupplierLedgerShortName = Convert.ToString(dr["Alt_name_1"]).Trim(),
                                    SupplierLedgerShortDesc = Convert.ToString(dr["Alt_name_2"]).Trim(),
                                    Address = string.Concat(Convert.ToString(dr["ACAD1"]).Trim(), " ", Convert.ToString(dr["ACAD2"]).Trim(), " ", Convert.ToString(dr["ACAD3"]).Trim()),
                                    ContactPerson = Convert.ToString(dr["ACAD4"]).Trim(),
                                    Mobile = Convert.ToString(dr["Mobile"]).Trim(),
                                    //Pager = Convert.ToString(dr["Pager"]).Trim(),
                                    //Fax = Convert.ToString(dr["Fax"]).Trim(),
                                    OfficePhone = Convert.ToString(dr["Telo"]).Trim(),
                                    ResidentPhone = Convert.ToString(dr["Telr"]).Trim(),
                                    EmailAddress = Convert.ToString(dr["Email"]).Trim(),
                                    AreaId = areaID,
                                    CreditDebit = Convert.ToDecimal(dr["Abop"]) > 0 ? Convert.ToString(PharmaBusinessObjects.Common.Enums.TransType.D) : Convert.ToString(PharmaBusinessObjects.Common.Enums.TransType.C),
                                    DLNo ="test", // Convert.ToString(dr["Stnol"]).Trim(),
                                    OpeningBal = Convert.ToDecimal(dr["Abop"]),
                                    TaxRetail = Convert.ToString(dr["Vat"]).Trim(),
                                    Status = Convert.ToChar(dr["ACSTS"]) == '*' ? false : true,
                                    PurchaseTypeID = purchaseTypeID,
                                    CreatedBy = "admin",
                                    CreatedOn = DateTime.Now
                                };

                                listSupplierLedgerMaster.Add(newSupplierLedgerMaster);
                            }
                            catch (Exception)
                            {
                                log.Info("SuPPLIER LEDGER : Error in ACName --> " + Convert.ToString(dr["ACName"]).Trim());

                            }
                        }
                    }

                    context.SupplierLedger.AddRange(listSupplierLedgerMaster);
                    _result = context.SaveChanges();

                    return _result;
                }
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


        public int InsertSupplierCompanyReferenceData()
        {
            try
            {
                //string query = "select * from DIS where Icode not in (select distinct acno from masters where slcd = 'IT') and Ccode not in (select distinct acno from masters where slcd = 'CO')";
                string query = "select * from DIS1 WHERE Disamt > 0";

                DataTable dtSupplierCompanyRef = dbConnection.GetData(query);

                List<SupplierCompanyDiscountRef> listSupplierCompanyRef = new List<SupplierCompanyDiscountRef>();

                int _result = 0;

                using (PharmaDBEntities context = new PharmaDBEntities())
                {
                    if (dtSupplierCompanyRef != null && dtSupplierCompanyRef.Rows.Count > 0)
                    {
                        var companyList = context.CompanyMaster.Select(p => p).ToList();
                        var supplierLedgerList = context.SupplierLedger.Select(p => p).ToList();
                        var itemList = context.ItemMaster.Select(p => p).ToList();

                        foreach (DataRow dr in dtSupplierCompanyRef.Rows)
                        {
                            try
                            {
                                if (dr["Disamt"] != null && Convert.ToDecimal(dr["Disamt"]) > 0)
                                {

                                    string supplierLedgerCode = Common.supplierLedgerCodeMap.Where(p => p.OriginalSupplierLedgerCode == Convert.ToString(dr["PCode"]).Trim()).FirstOrDefault().MappedSupplierLedgerCode;
                                    int supplierLedgerID = supplierLedgerList.Where(p => p.SupplierLedgerCode == supplierLedgerCode).FirstOrDefault().SupplierLedgerId;
                                    string companyCode = string.Empty;

                                    var company = Common.companyCodeMap.Where(p => p.OriginalCompanyCode == Convert.ToString(dr["Ccode"]).Trim()).FirstOrDefault();

                                    if (company == null)
                                    {
                                        continue;
                                    }

                                    companyCode = company.MappedCompanyCode;
                                    int companyID = companyList.Where(p => p.CompanyCode == companyCode).FirstOrDefault().CompanyId;

                                    string itemCode = string.IsNullOrEmpty(Convert.ToString(dr["ICode"]).Trim()) ? null : Common.itemCodeMap.Where(p => p.OriginalItemCode == Convert.ToString(dr["ICode"]).Trim()).FirstOrDefault().MappedItemCode;
                                    int? itemID = itemCode == null ? (int?)null : itemList.Where(p => p.ItemCode == itemCode).FirstOrDefault().ItemID;

                                    SupplierCompanyDiscountRef newSupplierCompanyRef = new SupplierCompanyDiscountRef()
                                    {
                                        SupplierLedgerID = supplierLedgerID,
                                        CompanyID = companyID,
                                        ItemID = itemID,
                                        Normal = Convert.ToDecimal(dr["Disamt"]),
                                        Breakage = Convert.ToDecimal(dr["Disamtbe"]),
                                        Expired = Convert.ToDecimal(dr["Disamtex"]),
                                        IsLessEcise = Convert.ToString(dr["Less_ex"]) == "Y" ? true : false
                                    };

                                    listSupplierCompanyRef.Add(newSupplierCompanyRef);
                                }
                            }
                            catch (Exception)
                            {
                                //throw ex;
                            }
                        }
                    }

                    context.SupplierCompanyDiscountRef.AddRange(listSupplierCompanyRef);
                    _result = context.SaveChanges();

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
