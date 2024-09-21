using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PharmaDAL.Entity;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using PharmaBusinessObjects.Common;
using PharmaBusinessObjects.Transaction;

namespace PharmaDAL.Master
{
    public class ItemDaoMaster : BaseDao
    {
        string ConnString = "";

        public ItemDaoMaster(PharmaBusinessObjects.Master.UserMaster loggedInUser) : base(loggedInUser)
        {
            
        }

        public List<PharmaBusinessObjects.Master.ItemMaster> GetAllItems()
        {
            using (PharmaDBEntities context = new PharmaDBEntities())
            {
                return context.ItemMaster.Select(p => new PharmaBusinessObjects.Master.ItemMaster()
                {
                    ItemID = p.ItemID,
                    ItemCode = p.ItemCode,
                    ItemName = p.ItemName,
                    CompanyID = p.CompanyID,
                    CompanyName = p.CompanyMaster.CompanyName,
                    ConversionRate = p.ConversionRate,
                    ShortName = p.ShortName,
                    Packing = p.Packing,
                    PurchaseRate = p.PurchaseRate,
                    MRP = p.MRP,
                    SaleRate = p.SaleRate,
                    SpecialRate = p.SpecialRate,
                    WholeSaleRate = p.WholeSaleRate,
                    SaleExcise = p.SaleExcise,
                    SurchargeOnSale = p.SurchargeOnSale,
                    TaxOnSale = p.TaxOnSale,
                    Scheme1 = p.Scheme1,
                    Scheme2 = p.Scheme2,
                    PurchaseExcise = p.PurchaseExcise,
                    UPC = p.UPC,
                    IsHalfScheme = p.IsHalfScheme,
                    IsQTRScheme = p.IsQTRScheme,
                    SpecialDiscount = p.SpecialDiscount,
                    SpecialDiscountOnQty = p.SpecialDiscountOnQty,
                    IsFixedDiscount = p.IsFixedDiscount,
                    FixedDiscountRate = p.FixedDiscountRate,
                    SurchargeOnPurchase = p.SurchargeOnPurchase,
                    TaxOnPurchase = p.TaxOnPurchase,
                    DiscountRecieved = p.DiscountRecieved,
                    SpecialDiscountRecieved = p.SpecialDiscountRecieved,
                    QtyPerCase = p.QtyPerCase,
                    Location = p.Location,
                    SaleTypeId = p.SaleTypeId,
                    PurchaseTypeId = p.PurchaseTypeId,
                    PurchaseTypeCode = p.AccountLedgerMaster1.AccountLedgerCode,
                    PurchaseTypeName = p.AccountLedgerMaster1.AccountLedgerName,
                    PurchaseTypeRate = p.AccountLedgerMaster1.SalePurchaseTaxType,
                    HSNCode = p.HSNCode,
                    Status = p.Status,
                    StatusText = p.Status ? string.Empty : Constants.Others.Inactive,
                    CompanyCode = p.CompanyMaster.CompanyCode

                }).ToList();
            }
        }

        public bool AddNewItem(PharmaBusinessObjects.Master.ItemMaster newItem)
        {
            try
            {
                using (PharmaDBEntities context = new PharmaDBEntities())
                {
                    using (var transaction = context.Database.BeginTransaction())
                    {
                        try
                        {

                            int _result = 0;
                            int totalItemsFromSameCompany = context.ItemMaster.Where(p => p.CompanyID == newItem.CompanyID).Count();
                            totalItemsFromSameCompany++;

                            //Add HSN if does not exist
                            if (!context.HSNCode.Where(x => x.HSNCode1 == newItem.HSNCode).Any())
                            {
                                Entity.HSNCode HSNCodeDBEntry = new HSNCode()
                                {
                                    HSNCode1 = newItem.HSNCode,
                                    HSNDescription = newItem.HSNCode + "- Default Description",
                                    CreatedBy = this.LoggedInUser.Username,
                                    CreatedOn = System.DateTime.Now
                                };

                                context.HSNCode.Add(HSNCodeDBEntry);
                            }


                            string companyCode = context.CompanyMaster.Where(p => p.CompanyId == newItem.CompanyID).FirstOrDefault().CompanyCode;

                            Entity.ItemMaster newItemMasterDB = new Entity.ItemMaster();

                            newItemMasterDB.ItemCode = string.Concat(companyCode, totalItemsFromSameCompany.ToString().PadLeft((9 - companyCode.Length), '0'));
                            newItemMasterDB.ItemName = newItem.ItemName;
                            newItemMasterDB.CompanyID = newItem.CompanyID;
                            newItemMasterDB.ConversionRate = newItem.ConversionRate;
                            newItemMasterDB.ShortName = newItem.ShortName;
                            newItemMasterDB.Packing = newItem.Packing;
                            newItemMasterDB.PurchaseRate = newItem.PurchaseRate;
                            newItemMasterDB.MRP = newItem.MRP;
                            newItemMasterDB.SaleRate = newItem.SaleRate;
                            newItemMasterDB.SpecialRate = newItem.SpecialRate;
                            newItemMasterDB.WholeSaleRate = newItem.WholeSaleRate;
                            newItemMasterDB.SaleExcise = newItem.SaleExcise;
                            newItemMasterDB.SurchargeOnSale = newItem.SurchargeOnSale;
                            newItemMasterDB.TaxOnSale = newItem.TaxOnSale;
                            newItemMasterDB.Scheme1 = newItem.Scheme1;
                            newItemMasterDB.Scheme2 = newItem.Scheme2;
                            newItemMasterDB.PurchaseExcise = newItem.PurchaseExcise;
                            newItemMasterDB.UPC = newItem.UPC;
                            newItemMasterDB.IsHalfScheme = newItem.IsHalfScheme;
                            newItemMasterDB.IsQTRScheme = newItem.IsQTRScheme;
                            newItemMasterDB.SpecialDiscount = newItem.SpecialDiscount;
                            newItemMasterDB.SpecialDiscountOnQty = newItem.SpecialDiscountOnQty;
                            newItemMasterDB.IsFixedDiscount = newItem.IsFixedDiscount;
                            newItemMasterDB.FixedDiscountRate = newItem.FixedDiscountRate;
                            newItemMasterDB.SurchargeOnPurchase = newItem.SurchargeOnPurchase;
                            newItemMasterDB.TaxOnPurchase = newItem.TaxOnPurchase;
                            newItemMasterDB.DiscountRecieved = newItem.DiscountRecieved;
                            newItemMasterDB.SpecialDiscountRecieved = newItem.SpecialDiscountRecieved;
                            newItemMasterDB.QtyPerCase = newItem.QtyPerCase;
                            newItemMasterDB.Location = newItem.Location;
                            newItemMasterDB.SaleTypeId = newItem.SaleTypeId;
                            newItemMasterDB.PurchaseTypeId = newItem.PurchaseTypeId;
                            newItemMasterDB.HSNCode = newItem.HSNCode;
                            newItemMasterDB.Status = newItem.Status;
                            newItemMasterDB.CreatedBy = this.LoggedInUser.Username;
                            newItemMasterDB.CreatedOn = System.DateTime.Now;

                            context.ItemMaster.Add(newItemMasterDB);
                            _result = context.SaveChanges();

                            transaction.Commit();

                            if (_result > 0)
                                return true;
                            else
                                return false;
                        }
                        catch (DbEntityValidationException ex)
                        {
                            transaction.Rollback();
                            throw ex;
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            throw ex;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public bool UpdateItem(PharmaBusinessObjects.Master.ItemMaster existingItem)
        {
            using (PharmaDBEntities context = new PharmaDBEntities())
            {

                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        int _result = 0;

                        Entity.ItemMaster existingItemDB = context.ItemMaster.Where(p => p.ItemCode == existingItem.ItemCode && p.Status).FirstOrDefault();

                        //Add HSN if does not exist
                        if (!context.HSNCode.Where(x => x.HSNCode1 == existingItem.HSNCode).Any())
                        {
                            Entity.HSNCode HSNCodeDBEntry = new HSNCode()
                            {
                                HSNCode1 = existingItem.HSNCode,
                                HSNDescription = existingItem.HSNCode + "- Default Description",
                                CreatedBy = this.LoggedInUser.Username,
                                CreatedOn = System.DateTime.Now
                            };
                            context.HSNCode.Add(HSNCodeDBEntry);
                        }

                        if (existingItemDB != null)
                        {
                            existingItemDB.ItemName = existingItem.ItemName;
                            existingItemDB.CompanyID = existingItem.CompanyID;
                            existingItemDB.ConversionRate = existingItem.ConversionRate;
                            existingItemDB.ShortName = existingItem.ShortName;
                            existingItemDB.Packing = existingItem.Packing;
                            existingItemDB.PurchaseRate = existingItem.PurchaseRate;
                            existingItemDB.MRP = existingItem.MRP;
                            existingItemDB.SaleRate = existingItem.SaleRate;
                            existingItemDB.SpecialRate = existingItem.SpecialRate;
                            existingItemDB.WholeSaleRate = existingItem.WholeSaleRate;
                            existingItemDB.SaleExcise = existingItem.SaleExcise;
                            existingItemDB.SurchargeOnSale = existingItem.SurchargeOnSale;
                            existingItemDB.TaxOnSale = existingItem.TaxOnSale;
                            existingItemDB.Scheme1 = existingItem.Scheme1;
                            existingItemDB.Scheme2 = existingItem.Scheme2;
                            existingItemDB.PurchaseExcise = existingItem.PurchaseExcise;
                            existingItemDB.UPC = existingItem.UPC;
                            existingItemDB.IsHalfScheme = existingItem.IsHalfScheme;
                            existingItemDB.IsQTRScheme = existingItem.IsQTRScheme;
                            existingItemDB.SpecialDiscount = existingItem.SpecialDiscount;
                            existingItemDB.SpecialDiscountOnQty = existingItem.SpecialDiscountOnQty;
                            existingItemDB.IsFixedDiscount = existingItem.IsFixedDiscount;
                            existingItemDB.FixedDiscountRate = existingItem.FixedDiscountRate;
                            existingItemDB.SurchargeOnPurchase = existingItem.SurchargeOnPurchase;
                            existingItemDB.TaxOnPurchase = existingItem.TaxOnPurchase;
                            existingItemDB.DiscountRecieved = existingItem.DiscountRecieved;
                            existingItemDB.SpecialDiscountRecieved = existingItem.SpecialDiscountRecieved;
                            existingItemDB.QtyPerCase = existingItem.QtyPerCase;
                            existingItemDB.Location = existingItem.Location;
                            existingItemDB.SaleTypeId = existingItem.SaleTypeId;
                            existingItemDB.PurchaseTypeId = existingItem.PurchaseTypeId;
                            existingItemDB.HSNCode = existingItem.HSNCode;
                            existingItemDB.Status = existingItem.Status;
                            existingItemDB.ModifiedBy = this.LoggedInUser.Username;
                            existingItemDB.ModifiedOn = System.DateTime.Now;
                        }

                        _result = context.SaveChanges();
                        transaction.Commit();

                        _result = 1;

                        if (_result > 0)
                            return true;
                        else
                            return false;

                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        return false;
                    }
                }
            }
        }

        public bool DeleteItem(PharmaBusinessObjects.Master.ItemMaster existingItem)
        {
            using (PharmaDBEntities context = new PharmaDBEntities())
            {
                int _result = 0;

                Entity.ItemMaster existingItemDB = context.ItemMaster.Where(p => p.ItemCode == existingItem.ItemCode && p.Status).FirstOrDefault();

                if (existingItemDB != null)
                {
                    existingItemDB.Status = false;
                    existingItemDB.Status = existingItem.Status;
                    existingItemDB.ModifiedBy = this.LoggedInUser.Username;
                    existingItemDB.ModifiedOn = System.DateTime.Now;
                }
                _result = context.SaveChanges();

                if (_result > 0)
                    return true;
                else
                    return false;
            }
        }

        public int TotalItemsFromSameCompany(string companyCode)
        {
            using (PharmaDBEntities context = new PharmaDBEntities())
            {
                return context.ItemMaster.Where(p => p.CompanyMaster.CompanyCode == companyCode).Count();
            }
        }



        public DataTable GetAllItemsBySearch()
        {
            ConnString = ConfigurationManager.ConnectionStrings["PharmaDBConn"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(ConnString))
            {

                List<PharmaBusinessObjects.Master.ItemMaster> itemList = new List<PharmaBusinessObjects.Master.ItemMaster>();

                SqlCommand cmd = new SqlCommand("SELECT * FROM CompanyItemMapping", connection);
                cmd.CommandType = System.Data.CommandType.Text;

                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                sda.Fill(dt);

                if (dt != null)
                {
                    return dt;
                }
                else
                    return new DataTable();
            }
        }
       

        public List<PharmaBusinessObjects.Master.ItemMaster> GetAllItemByCompanyID(int CompanyID)
        {
            using (PharmaDBEntities context = new PharmaDBEntities())
            {
                List<PharmaBusinessObjects.Master.ItemMaster> allItemByCompanyID = new List<PharmaBusinessObjects.Master.ItemMaster>();

                allItemByCompanyID = context.ItemMaster.Where(item => item.CompanyID == CompanyID && item.Status)
                                                                 .Select(item => new PharmaBusinessObjects.Master.ItemMaster()
                                                                 {
                                                                     CompanyID = CompanyID,
                                                                     CompanyName = item.CompanyMaster.CompanyName,
                                                                     ItemID = item.ItemID,
                                                                     ItemName = item.ItemName

                                                                 }).ToList();

                return allItemByCompanyID;
            }
        }

        public List<PharmaBusinessObjects.Master.HSNCodes> GetAllHSNCodes()
        {
            using (PharmaDBEntities context = new PharmaDBEntities())
            {
                List<PharmaBusinessObjects.Master.HSNCodes> allHSNCode = new List<PharmaBusinessObjects.Master.HSNCodes>();

                allHSNCode = context.HSNCode.Select(hsn => new PharmaBusinessObjects.Master.HSNCodes()
                {
                    HSNID = hsn.HSNID,
                    HSNCode = hsn.HSNCode1,
                    HSNDescription = hsn.HSNDescription

                }).ToList();
                return allHSNCode;
            }
        }


        public PharmaBusinessObjects.Master.ItemMaster GetItemByCodeAndCustomer(int itemCode, string customerCode)
        {
            PharmaBusinessObjects.Master.ItemMaster master = new PharmaBusinessObjects.Master.ItemMaster();

            using (PharmaDBEntities context = new PharmaDBEntities())
            {
                SqlConnection connection = (SqlConnection)context.Database.Connection;

                SqlCommand cmd = new SqlCommand("GetSaleLineItemByCode", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@ItemCode", itemCode));
                cmd.Parameters.Add(new SqlParameter("@CustomerCode", customerCode));

                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                sda.Fill(dt);

                if (dt != null && dt.Rows.Count > 0)
                {
                    master.ItemID = Convert.IsDBNull(dt.Rows[0]["ItemId"]) ? 0 : Convert.ToInt32(dt.Rows[0]["ItemId"]);
                    master.ItemCode = Convert.ToString(dt.Rows[0]["ItemCode"]);
                    master.ItemName = Convert.ToString(dt.Rows[0]["ItemName"]);
                    master.CompanyID = Convert.IsDBNull(dt.Rows[0]["CompanyID"]) ? 0 : Convert.ToInt32(dt.Rows[0]["CompanyID"]);
                    master.SaleRate = Convert.IsDBNull(dt.Rows[0]["SaleRate"]) ? 0 : Convert.ToDecimal(dt.Rows[0]["SaleRate"]);
                    master.SpecialRate = Convert.IsDBNull(dt.Rows[0]["SpecialRate"]) ? 0 : Convert.ToDecimal(dt.Rows[0]["SpecialRate"]);
                    master.WholeSaleRate = Convert.IsDBNull(dt.Rows[0]["WholeSaleRate"]) ? 0 : Convert.ToDecimal(dt.Rows[0]["WholeSaleRate"]);
                    master.SaleExcise = Convert.IsDBNull(dt.Rows[0]["SaleExcise"]) ? 0 : Convert.ToDecimal(dt.Rows[0]["SaleExcise"]);
                    master.SurchargeOnSale = Convert.IsDBNull(dt.Rows[0]["SurchargeOnSale"]) ? 0 : Convert.ToDecimal(dt.Rows[0]["SurchargeOnSale"]);
                    master.TaxOnSale = Convert.IsDBNull(dt.Rows[0]["TaxOnSale"]) ? 0 : Convert.ToDecimal(dt.Rows[0]["TaxOnSale"]);
                    master.Scheme1 = Convert.IsDBNull(dt.Rows[0]["Scheme1"]) ? 0 : Convert.ToDecimal(dt.Rows[0]["Scheme1"]);
                    master.Scheme2 = Convert.IsDBNull(dt.Rows[0]["Scheme2"]) ? 0 : Convert.ToDecimal(dt.Rows[0]["Scheme2"]);
                    master.IsHalfScheme = Convert.IsDBNull(dt.Rows[0]["IsHalfScheme"]) ? false : Convert.ToBoolean(dt.Rows[0]["IsHalfScheme"]);
                    master.IsQTRScheme = Convert.IsDBNull(dt.Rows[0]["IsQTRScheme"]) ? false : Convert.ToBoolean(dt.Rows[0]["IsQTRScheme"]);
                    master.SpecialDiscount = Convert.IsDBNull(dt.Rows[0]["SpecialDiscount"]) ? 0 : Convert.ToDecimal(dt.Rows[0]["SpecialDiscount"]);
                    master.SpecialDiscountOnQty = Convert.IsDBNull(dt.Rows[0]["SpecialDiscountOnQty"]) ? 0 : Convert.ToDecimal(dt.Rows[0]["SpecialDiscountOnQty"]);
                    master.IsFixedDiscount = Convert.IsDBNull(dt.Rows[0]["IsFixedDiscount"]) ? false : Convert.ToBoolean(dt.Rows[0]["IsFixedDiscount"]);
                    master.FixedDiscountRate = Convert.IsDBNull(dt.Rows[0]["FixedDiscountRate"]) ? 0 : Convert.ToDecimal(dt.Rows[0]["FixedDiscountRate"]);
                    master.QtyPerCase = Convert.IsDBNull(dt.Rows[0]["QtyPerCase"]) ? 0 : Convert.ToDecimal(dt.Rows[0]["QtyPerCase"]);
                    master.Location = Convert.ToString(dt.Rows[0]["Location"]);
                    master.SaleTypeId = Convert.IsDBNull(dt.Rows[0]["SaleTypeId"]) ? 0 : Convert.ToInt32(dt.Rows[0]["SaleTypeId"]);
                    //master.Discount = Convert.IsDBNull(dt.Rows[0]["Discount"]) ? 0 : Convert.ToDouble(dt.Rows[0]["Discount"]);
                    //  master.Batch = Convert.ToString(dt.Rows[0]["Batch"]);
                    master.Packing = Convert.ToString(dt.Rows[0]["Packing"]);
                    master.PurchaseRate = Convert.IsDBNull(dt.Rows[0]["PurchaseRate"]) ? 0 : Convert.ToDecimal(dt.Rows[0]["PurchaseRate"]);
                    // master.FifoID = Convert.IsDBNull(dt.Rows[0]["FifoID"]) ? 0 : Convert.ToInt32(dt.Rows[0]["FifoID"]);
                }
            }

            return master;
        }
        
        public List<FifoBatches> GetFifoBatchesByItemCode(string itemCode)
        {
            using (PharmaDBEntities context = new PharmaDBEntities())
            {
                List<FifoBatches> list = new List<FifoBatches>();

                list = context.FIFO.Where(p => p.ItemCode == itemCode).Select(batch => new FifoBatches()
                {

                    FifoID = batch.FifoID,
                    PurchaseSaleBookHeaderID = batch.PurchaseSaleBookHeaderID,
                    ItemCode = batch.ItemCode,
                    PurchaseBillNo = batch.PurchaseBillNo,
                    Batch = batch.Batch,
                    PurchaseRate = batch.PurchaseRate,
                    SaleRate = batch.SaleRate,
                    WholeSaleRate = batch.WholeSaleRate,
                    BalanceQuanity = batch.BalanceQuanity,
                    Quantity = batch.Quantity,
                    EffectivePurchaseRate = batch.EffectivePurchaseRate,
                    ExpiryDate = batch.ExpiryDate,
                    MfgDate = batch.MfgDate,
                    MRP = batch.MRP,
                    SpecialRate = batch.SpecialRate,
                    SRLNO = batch.SRLNO,
                    VoucherDate = batch.VoucherDate,
                    VoucherNumber = batch.VoucherNumber,
                    Scheme1 = batch.Scheme1,
                    Scheme2 = batch.Scheme2,
                    IsOnHold = batch.IsOnHold,
                    OnHoldRemarks = batch.OnHoldRemarks,
                    UPC = batch.UPC,
                   // Scheme=  Convert.ToString(batch.Scheme1 ?? default(decimal)) + Convert.ToString(batch.Scheme2 ?? default(decimal))

                }).ToList();

                return list;
            }
        }

        public int UpdateFifoBatchesByItemCode(FifoBatches fifoBatch)
        {
            using (PharmaDBEntities context = new PharmaDBEntities())
            {
                FIFO fifo = context.FIFO.Where(p => p.FifoID == fifoBatch.FifoID).FirstOrDefault();

                if (fifo != null)
                {
                    fifo.Batch = fifoBatch.Batch;
                    fifo.SaleRate = fifoBatch.SaleRate;
                    fifo.WholeSaleRate = fifoBatch.WholeSaleRate;
                    fifo.SpecialRate = fifoBatch.SpecialRate;
                    fifo.MRP = fifoBatch.MRP;
                    fifo.PurchaseRate = fifoBatch.PurchaseRate;
                    fifo.IsOnHold = fifoBatch.IsOnHold;
                    fifo.OnHoldRemarks = fifoBatch.OnHoldRemarks;
                    fifo.MfgDate = fifoBatch.MfgDate;
                    fifo.ExpiryDate = fifoBatch.ExpiryDate;

                    context.SaveChanges();




                    return 1;
                }
                else
                {
                    return 0;
                }




            }
        }


    }
}