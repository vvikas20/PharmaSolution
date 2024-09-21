using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using PharmaDAL.Entity;
using PharmaDAL.Master;
using System.Data.Entity.Validation;
using System.Windows.Forms;
using PharmaBusinessObjects.Common;
using log4net;
using System.Reflection;

namespace PharmaDataMigration.Master
{
    public class ItemMaster
    {
        private readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private ItemDaoMaster itemMasterDao; 
        private DBFConnectionManager dbConnection;
        private List<CompanyCodeCounts> companyCodeCounts;

        public ItemMaster()
        {
            itemMasterDao = new ItemDaoMaster(Common.LoggedInUser);
            dbConnection = new DBFConnectionManager(Common.DataDirectory);
            companyCodeCounts = new List<CompanyCodeCounts>();
        }        

        public int InsertItemMasterData()
        {
            try
            {
                string query = "select * from MASTERS where slcd = 'IT'";

                DataTable dtItemMaster = dbConnection.GetData(query);

                List<PharmaDAL.Entity.ItemMaster> listItemMaster = new List<PharmaDAL.Entity.ItemMaster>();
                int _result = 0;
                companyCodeCounts = TotalItemsByCompany();

                using (PharmaDBEntities context = new PharmaDBEntities())
                {
                    if (dtItemMaster != null && dtItemMaster.Rows.Count > 0)
                    {
                        var companyMaster = context.CompanyMaster.Select(p => p).ToList();
                        var accountLedgerMaster = context.AccountLedgerMaster.Select(p => p).ToList();

                        foreach (DataRow dr in dtItemMaster.Rows)
                        {
                            try
                            {
                                string originalItemCompanyCode = Convert.ToString(dr["CompCD"]).TrimEnd();
                                string companyCode = Common.companyCodeMap.Where(p => p.OriginalCompanyCode == originalItemCompanyCode).FirstOrDefault().MappedCompanyCode;
                                int companyID = companyMaster.Where(p => p.CompanyCode == companyCode).FirstOrDefault().CompanyId;
                                int totalItemsFromSameCompany = companyCodeCounts.Where(p => p.CompanyCode == companyCode).Select(p => p.CompanyCodeCount).FirstOrDefault();

                                totalItemsFromSameCompany++;

                                if (totalItemsFromSameCompany > 1)
                                {
                                    foreach (var item in companyCodeCounts.Where(p => p.CompanyCode == companyCode))
                                    {
                                        item.CompanyCodeCount = totalItemsFromSameCompany;
                                    }
                                }
                                else
                                {
                                    companyCodeCounts.Add(new CompanyCodeCounts() { CompanyCode = companyCode, CompanyCodeCount = totalItemsFromSameCompany });
                                }

                                string itemCode = string.Concat(companyCode, totalItemsFromSameCompany.ToString().PadLeft((9 - companyCode.Length), '0'));
                                string originalItemCode = Convert.ToString(dr["ACNO"]).TrimEnd();

                                Common.itemCodeMap.Add(new ItemCodeMap() { OriginalItemCode = originalItemCode, MappedItemCode = itemCode });

                                string originalSleType = Convert.ToString(dr["SType"]).TrimEnd();
                                string saleLedgerCode = Common.accountLedgerCodeMap.Where(q => q.OriginalAccountLedgerCode == originalSleType).FirstOrDefault().MappedAccountLedgerCode;
                                var saleType = accountLedgerMaster.Where(p => p.AccountLedgerCode == saleLedgerCode).FirstOrDefault();

                                PharmaDAL.Entity.AccountLedgerMaster purchaseType = null;

                                if (saleType.SalePurchaseTaxType == 5)
                                {
                                    purchaseType = accountLedgerMaster.Where(p => p.SalePurchaseTaxType == 5 && p.AccountLedgerType.SystemName == Constants.AccountLedgerType.PurchaseLedger).FirstOrDefault();
                                }
                                else if (saleType.SalePurchaseTaxType == 12)
                                {
                                    purchaseType = accountLedgerMaster.Where(p => p.SalePurchaseTaxType == 12 && p.AccountLedgerType.SystemName == Constants.AccountLedgerType.PurchaseLedger).FirstOrDefault();
                                }
                                else if (saleType.SalePurchaseTaxType == 0)
                                {
                                    purchaseType = accountLedgerMaster.Where(p => p.SalePurchaseTaxType == 0 && p.AccountLedgerType.SystemName == Constants.AccountLedgerType.PurchaseLedger).FirstOrDefault();
                                }


                                PharmaDAL.Entity.ItemMaster newItemMaster = new PharmaDAL.Entity.ItemMaster()
                                {
                                    ItemCode = itemCode,
                                    ItemName = Convert.ToString(dr["ACName"]).TrimEnd(),
                                    CompanyID = companyID,
                                    ConversionRate = Convert.ToDecimal(dr["ConvRate"]),
                                    ShortName = Convert.ToString(dr["ALT_Name"]).TrimEnd(),
                                    Packing = Convert.ToString(dr["Size"]).TrimEnd(),
                                    PurchaseRate = Convert.ToDecimal(dr["PRate"]),
                                    MRP = Convert.ToDecimal(dr["MRP"]),
                                    SaleRate = Convert.ToDecimal(dr["SRate"]),
                                    SpecialRate = Convert.ToDecimal(dr["SPLRate"]),
                                    WholeSaleRate = Convert.ToDecimal(dr["WSRATE"]),
                                    SaleExcise = Convert.ToDecimal(dr["EXCISES"]),
                                    SurchargeOnSale = Convert.ToDecimal(dr["SC"]),
                                    TaxOnSale = Convert.ToDecimal(dr["STax"]),
                                    Scheme1 = Convert.ToDecimal(dr["Scheme1"]),
                                    Scheme2 = Convert.ToDecimal(dr["Scheme2"]),
                                    PurchaseExcise = Convert.ToDecimal(dr["ExciseP"]),
                                    UPC = Convert.ToString(dr["UPC"]).TrimEnd(),
                                    IsHalfScheme = Convert.ToChar(dr["half"]) == 'Y' ? true : false,
                                    IsQTRScheme = Convert.ToChar(dr["qtr"]) == 'Y' ? true : false,
                                    SpecialDiscount = Convert.ToDecimal(dr["SPLDIS"]),
                                    SpecialDiscountOnQty = Convert.ToDecimal(dr["DISQTY"]),
                                    IsFixedDiscount = Convert.ToChar(dr["check_dis"]) == 'Y' ? true : false,
                                    FixedDiscountRate = Convert.ToDecimal(dr["drate1"]),
                                    //MaximumQty = Convert.ToDecimal(dr["MAX_QTY"]),
                                    //MaximumDiscount = Convert.ToDecimal(dr["max_dis"]),
                                    SurchargeOnPurchase = Convert.ToDecimal(dr["PSC"]),
                                    TaxOnPurchase = Convert.ToDecimal(dr["PTax"]),
                                    DiscountRecieved = Convert.ToDecimal(dr["PDIS"]),
                                    SpecialDiscountRecieved = Convert.ToDecimal(dr["PSPLDIS"]),
                                    QtyPerCase = Convert.ToDecimal(dr["Case_Qty"]),
                                    Location = Convert.ToString(dr["location"]).TrimEnd(),
                                    //MinimumStock = Convert.ToInt32(dr["min"]),
                                    //MaximumStock = Convert.ToInt32(dr["max"]),
                                    SaleTypeId = saleType.AccountLedgerID,
                                    PurchaseTypeId = purchaseType.AccountLedgerID,
                                    Status = Convert.ToChar(dr["ACSTS"]) == '*' ? false : true,
                                    CreatedBy = "admin",
                                    CreatedOn = DateTime.Now,
                                    HSNCode = "HSNCODE001"
                                };

                                listItemMaster.Add(newItemMaster);

                            }
                            catch (Exception)
                            {
                                log.Info("ITEM MASTER : Error in ACName --> " + Convert.ToString(dr["ACName"]).TrimEnd() + "   ACNO -->" + Convert.ToString(dr["ACName"]).TrimEnd() + "  Comp Code -->" + Convert.ToString(dr["CompCD"]).TrimEnd());
                            }
                        }
                    }

                    context.ItemMaster.AddRange(listItemMaster);
                    _result = context.SaveChanges();
                   
                    return _result;
                }
            }
            catch(DbEntityValidationException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CompanyCodeCounts> TotalItemsByCompany()
        {
            using (PharmaDBEntities context = new PharmaDBEntities())
            {
                var companyCodeCounts = itemMasterDao.GetAllItems().GroupBy(p => p.CompanyCode)
                                                                    .Select(q => new CompanyCodeCounts()
                                                                                    {
                                                                                        CompanyCode = q.Key,
                                                                                        CompanyCodeCount = q.Count()
                                                                                    }
                                                                    ).ToList();

                return companyCodeCounts;
            }
        }
    }

    public class CompanyCodeCounts
    {
        public string CompanyCode { get; set; }
        public int CompanyCodeCount { get; set; }
    }
}
