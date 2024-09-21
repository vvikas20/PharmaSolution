using PharmaBusinessObjects.Common;
using PharmaBusinessObjects.Transaction.SaleEntry;
using PharmaDAL.Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaDAL.Transaction
{
    public class SaleEntryDao : BaseDao
    {
        public SaleEntryDao(PharmaBusinessObjects.Master.UserMaster loggedInUser) : base(loggedInUser)
        {

        }

        public PharmaBusinessObjects.Transaction.PurchaseSaleBookLineItem GetNewSaleLineItem(string itemCode, string customerCode)
        {
            PharmaBusinessObjects.Transaction.PurchaseSaleBookLineItem master = new PharmaBusinessObjects.Transaction.PurchaseSaleBookLineItem();

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
                    master.PurchaseSaleBookLineItemID = 0;
                    master.ItemCode = Convert.ToString(dt.Rows[0]["ItemCode"]);
                    master.ItemName = Convert.ToString(dt.Rows[0]["ItemName"]);
                    master.SaleRate = Convert.IsDBNull(dt.Rows[0]["SaleRate"]) ? 0 : Convert.ToDecimal(dt.Rows[0]["SaleRate"]);
                    master.SpecialRate = Convert.IsDBNull(dt.Rows[0]["SpecialRate"]) ? 0 : Convert.ToDecimal(dt.Rows[0]["SpecialRate"]);
                    master.WholeSaleRate = Convert.IsDBNull(dt.Rows[0]["WholeSaleRate"]) ? 0 : Convert.ToDecimal(dt.Rows[0]["WholeSaleRate"]);



                    master.PurchaseBillDate = Convert.IsDBNull(dt.Rows[0]["PurchaseBillDate"]) ? DateTime.Now : Convert.ToDateTime(dt.Rows[0]["PurchaseBillDate"]);
                    master.PurchaseVoucherNumber = Convert.ToString(dt.Rows[0]["PurchaseVoucherNumber"]);
                    master.PurchaseSrlNo = Convert.IsDBNull(dt.Rows[0]["PurchaseSrlNo"]) ? 0 : Convert.ToInt32(dt.Rows[0]["PurchaseSrlNo"]);
                    master.Quantity = 0;
                    master.FreeQuantity = 0;
                    master.Scheme1 = Convert.IsDBNull(dt.Rows[0]["Scheme1"]) ? 0 : Convert.ToDecimal(dt.Rows[0]["Scheme1"]);
                    master.Scheme2 = Convert.IsDBNull(dt.Rows[0]["Scheme2"]) ? 0 : Convert.ToDecimal(dt.Rows[0]["Scheme2"]);
                    master.IsHalfScheme = Convert.IsDBNull(dt.Rows[0]["IsHalfScheme"]) ? false : Convert.ToBoolean(dt.Rows[0]["IsHalfScheme"]);
                    master.HalfSchemeRate = Convert.IsDBNull(dt.Rows[0]["HalfSchemeRate"]) ? 0 : Convert.ToDecimal(dt.Rows[0]["HalfSchemeRate"]);
                    //master.IsQTRScheme = Convert.IsDBNull(dt.Rows[0]["IsQTRScheme"]) ? false : Convert.ToBoolean(dt.Rows[0]["IsQTRScheme"]);
                    master.SpecialDiscount = Convert.IsDBNull(dt.Rows[0]["SpecialDiscount"]) ? 0 : Convert.ToDecimal(dt.Rows[0]["SpecialDiscount"]);
                    master.PurchaseSaleTax = Convert.IsDBNull(dt.Rows[0]["SalePurchaseTax"]) ? 0 : Convert.ToDecimal(dt.Rows[0]["SalePurchaseTax"]);
                    //master.IsFixedDiscount = Convert.IsDBNull(dt.Rows[0]["IsFixedDiscount"]) ? false : Convert.ToBoolean(dt.Rows[0]["IsFixedDiscount"]);
                    master.SurCharge = Convert.IsDBNull(dt.Rows[0]["SurCharge"]) ? 0 : Convert.ToDecimal(dt.Rows[0]["SurCharge"]);
                    master.SGST = Convert.IsDBNull(dt.Rows[0]["SGST"]) ? 0 : Convert.ToDecimal(dt.Rows[0]["SGST"]);
                    master.IGST = Convert.IsDBNull(dt.Rows[0]["IGST"]) ? 0 : Convert.ToDecimal(dt.Rows[0]["IGST"]);
                    master.CGST = Convert.IsDBNull(dt.Rows[0]["CGST"]) ? 0 : Convert.ToDecimal(dt.Rows[0]["CGST"]);
                    master.Amount = Convert.IsDBNull(dt.Rows[0]["Amount"]) ? 0 : Convert.ToDecimal(dt.Rows[0]["Amount"]);
                    master.DiscountQuantity = Convert.IsDBNull(dt.Rows[0]["DiscountQuantity"]) ? 0 : Convert.ToDecimal(dt.Rows[0]["DiscountQuantity"]);
                    master.VolumeDiscount = Convert.IsDBNull(dt.Rows[0]["VolumeDiscount"]) ? 0 : Convert.ToDecimal(dt.Rows[0]["VolumeDiscount"]);
                    master.ConversionRate = Convert.IsDBNull(dt.Rows[0]["ConversionRate"]) ? 0 : Convert.ToDecimal(dt.Rows[0]["ConversionRate"]);
                    master.MRP = Convert.IsDBNull(dt.Rows[0]["MRP"]) ? 0 : Convert.ToDecimal(dt.Rows[0]["MRP"]);

                    if(!Convert.IsDBNull(dt.Rows[0]["ExpiryDate"]))
                    {
                        master.ExpiryDate = Convert.ToDateTime(dt.Rows[0]["ExpiryDate"]);
                    }
                   
                    master.WholeSaleRate = Convert.IsDBNull(dt.Rows[0]["WholeSaleRate"]) ? 0 : Convert.ToDecimal(dt.Rows[0]["WholeSaleRate"]);
                    master.SpecialRate = Convert.IsDBNull(dt.Rows[0]["SpecialRate"]) ? 0 : Convert.ToDecimal(dt.Rows[0]["SpecialRate"]);
                    master.LocalCentral = Convert.ToString(dt.Rows[0]["LocalCentral"]);
                    master.PurchaseSaleTypeCode = Convert.ToString(dt.Rows[0]["PurchaseSaleTypeCode"]);
                    master.Discount = Convert.IsDBNull(dt.Rows[0]["Discount"]) ? 0 : Convert.ToDecimal(dt.Rows[0]["Discount"]);
                    master.Batch = Convert.ToString(dt.Rows[0]["Batch"]);
                    master.BatchNew = Convert.ToString(dt.Rows[0]["BatchNew"]);
                    master.EffecivePurchaseSaleRate = Convert.IsDBNull(dt.Rows[0]["EffecivePurchaseSaleRate"]) ? 0 : Convert.ToDecimal(dt.Rows[0]["EffecivePurchaseSaleRate"]);
                    master.PurchaseSaleRate = Convert.IsDBNull(dt.Rows[0]["PurchaseSaleRate"]) ? 0 : Convert.ToDecimal(dt.Rows[0]["PurchaseSaleRate"]);
                    master.FifoID = Convert.IsDBNull(dt.Rows[0]["Fifoid"]) ? 0 : Convert.ToInt32(dt.Rows[0]["Fifoid"]);
                    master.BalanceQuantity = Convert.IsDBNull(dt.Rows[0]["BalanceQuantity"]) ? 0 : Convert.ToDecimal(dt.Rows[0]["BalanceQuantity"]);

                }
            }
            return master;
        }

        public SaleLineItemInfo GetSaleLineItemInfo(string itemCode, long FifoID)
        {
            SaleLineItemInfo info = new SaleLineItemInfo();


            using (PharmaDBEntities context = new PharmaDBEntities())
            {
                SqlConnection connection = (SqlConnection)context.Database.Connection;

                SqlCommand cmd = new SqlCommand("GetSaleLineItemInfo", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@ItemCode", itemCode));
                cmd.Parameters.Add(new SqlParameter("@FifoID", FifoID));

                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                sda.Fill(dt);

                if (dt != null && dt.Rows.Count > 0)
                {
                    info.TaxAmount = Convert.IsDBNull(dt.Rows[0]["TaxOnSale"]) ? 0 : Convert.ToDecimal(dt.Rows[0]["TaxOnSale"]);
                    info.Scheme1 = Convert.IsDBNull(dt.Rows[0]["Scheme1"]) ? 0 : Convert.ToDecimal(dt.Rows[0]["Scheme1"]);
                    info.Scheme2 = Convert.IsDBNull(dt.Rows[0]["Scheme2"]) ? 0 : Convert.ToDecimal(dt.Rows[0]["Scheme2"]);
                    info.Balance = Convert.IsDBNull(dt.Rows[0]["Balance"]) ? 0 : Convert.ToDecimal(dt.Rows[0]["Balance"]);
                    info.IsHalf = Convert.IsDBNull(dt.Rows[0]["IsHalfScheme"]) ? false : Convert.ToBoolean(dt.Rows[0]["IsHalfScheme"]);
                    info.CaseQty = Convert.IsDBNull(dt.Rows[0]["QtyPerCase"]) ? 0 : Convert.ToDecimal(dt.Rows[0]["QtyPerCase"]);
                    info.SaleType = Convert.ToString(dt.Rows[0]["AccountLedgerName"]);
                    info.Packing = Convert.ToString(dt.Rows[0]["Packing"]);
                    info.Surcharge = Convert.IsDBNull(dt.Rows[0]["SurchargeOnSale"]) ? 0 : Convert.ToDecimal(dt.Rows[0]["SurchargeOnSale"]);
                    info.LastBillInfo = new LastBillInfo();
                    info.LastBillInfo.Batch = Convert.ToString(dt.Rows[0]["Batch"]);
                    info.LastBillInfo.Rate = Convert.IsDBNull(dt.Rows[0]["SaleRate"]) ? 0 : Convert.ToDecimal(dt.Rows[0]["SaleRate"]);
                    info.LastBillInfo.Discount = Convert.IsDBNull(dt.Rows[0]["Discount"]) ? 0 : Convert.ToDecimal(dt.Rows[0]["Discount"]);
                    info.LastBillInfo.SpecialDiscount = Convert.IsDBNull(dt.Rows[0]["SpecialDiscount"]) ? 0 : Convert.ToDecimal(dt.Rows[0]["SpecialDiscount"]);
                    info.LastBillInfo.Scheme1 = Convert.IsDBNull(dt.Rows[0]["Scheme1"]) ? 0 : Convert.ToDecimal(dt.Rows[0]["Scheme1"]);
                    info.LastBillInfo.Scheme2 = Convert.IsDBNull(dt.Rows[0]["Scheme2"]) ? 0 : Convert.ToDecimal(dt.Rows[0]["Scheme2"]);
                    info.LastBillInfo.BillDate = Convert.IsDBNull(dt.Rows[0]["DueDate"]) ? DateTime.MinValue : Convert.ToDateTime(dt.Rows[0]["DueDate"]);

                }
            }
            return info;
        }

        public List<PharmaBusinessObjects.Transaction.PurchaseSaleBookLineItem> InsertUpdateTempPurchaseBookLineItemForSale(PharmaBusinessObjects.Transaction.PurchaseSaleBookLineItem lineItem)
        {
            try
            {

                List<PharmaBusinessObjects.Transaction.PurchaseSaleBookLineItem> lineItemList = new List<PharmaBusinessObjects.Transaction.PurchaseSaleBookLineItem>();
                //List<PurchaseBookAmount> purchaseBookAmounts = new List<PurchaseBookAmount>();

                // lineItem.ExpiryDate = DateTime.Now;
                lineItem.CreatedBy = LoggedInUser.Username;
                lineItem.ModifiedBy = LoggedInUser.Username;
                lineItem.CreatedOn = DateTime.Now;
                lineItem.ModifiedOn = DateTime.Now;
                using (PharmaDBEntities context = new PharmaDBEntities())
                {
                    SqlConnection connection = (SqlConnection)context.Database.Connection;

                    SqlCommand cmd = new SqlCommand("InsertUpdateInvetoryLineItemInTempTableForSale", connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    List<PharmaBusinessObjects.Transaction.PurchaseSaleBookLineItem> list = new List<PharmaBusinessObjects.Transaction.PurchaseSaleBookLineItem>();
                    list.Add(lineItem);

                    SqlParameter parameter = new SqlParameter();
                    parameter.SqlDbType = SqlDbType.Structured;
                    parameter.TypeName = "dbo.TableTypePurchaseSaleBookLineItem";
                    parameter.ParameterName = "@TableTypePurchaseSaleBookLineItem";

                    parameter.Value = CommonDaoMethods.CreateDataTable<PharmaBusinessObjects.Transaction.PurchaseSaleBookLineItem>(list);

                    cmd.Parameters.Add(parameter);


                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();

                    sda.Fill(dt);

                    if (dt != null && dt.Rows.Count > 0)
                    {
                        foreach (DataRow row in dt.Rows)
                        {
                            PharmaBusinessObjects.Transaction.PurchaseSaleBookLineItem item = new PharmaBusinessObjects.Transaction.PurchaseSaleBookLineItem();

                            item.PurchaseSaleBookLineItemID = Convert.ToInt32(row["PurchaseSaleBookLineItemID"]);
                            item.PurchaseSaleBookHeaderID = Convert.ToInt32(row["PurchaseSaleBookHeaderID"]);
                            item.ItemCode = Convert.ToString(row["ItemCode"]);
                            item.ItemName = Convert.ToString(row["ItemName"]);
                            item.SaleRate = Convert.IsDBNull(row["SaleRate"]) ? 0 : Convert.ToDecimal(row["SaleRate"]);
                            item.SpecialRate = Convert.IsDBNull(row["SpecialRate"]) ? 0 : Convert.ToDecimal(row["SpecialRate"]);
                            item.WholeSaleRate = Convert.IsDBNull(row["WholeSaleRate"]) ? 0 : Convert.ToDecimal(row["WholeSaleRate"]);
                            item.PurchaseBillDate = Convert.IsDBNull(row["PurchaseBillDate"]) ? DateTime.MinValue : Convert.ToDateTime(row["PurchaseBillDate"]);
                            item.PurchaseVoucherNumber = Convert.ToString(row["PurchaseVoucherNumber"]);
                            item.PurchaseSrlNo = Convert.IsDBNull(row["PurchaseSrlNo"]) ? 0 : Convert.ToInt32(row["PurchaseSrlNo"]);
                            item.Quantity = Convert.IsDBNull(row["Quantity"]) ? 0 : Convert.ToInt32(row["Quantity"]);
                            item.FreeQuantity = Convert.IsDBNull(row["FreeQuantity"]) ? 0 : Convert.ToInt32(row["FreeQuantity"]);
                            item.Scheme1 = Convert.IsDBNull(row["Scheme1"]) ? 0 : Convert.ToDecimal(row["Scheme1"]);
                            item.Scheme2 = Convert.IsDBNull(row["Scheme2"]) ? 0 : Convert.ToDecimal(row["Scheme2"]);
                            item.IsHalfScheme = Convert.IsDBNull(row["IsHalfScheme"]) ? false : Convert.ToBoolean(row["IsHalfScheme"]);
                            item.HalfSchemeRate = Convert.IsDBNull(row["HalfSchemeRate"]) ? 0 : Convert.ToDecimal(row["HalfSchemeRate"]);
                            //item.IsQTRScheme = Convert.IsDBNull(row["IsQTRScheme"]) ? false : Convert.ToBoolean(row["IsQTRScheme"]);
                            item.SpecialDiscount = Convert.IsDBNull(row["SpecialDiscount"]) ? 0 : Convert.ToDecimal(row["SpecialDiscount"]);
                            item.PurchaseSaleTax = Convert.IsDBNull(row["SalePurchaseTax"]) ? 0 : Convert.ToDecimal(row["SalePurchaseTax"]);
                            //item.IsFixedDiscount = Convert.IsDBNull(row["IsFixedDiscount"]) ? false : Convert.ToBoolean(row["IsFixedDiscount"]);
                            item.SurCharge = Convert.IsDBNull(row["SurCharge"]) ? 0 : Convert.ToDecimal(row["SurCharge"]);
                            item.SGST = Convert.IsDBNull(row["SGST"]) ? 0 : Convert.ToDecimal(row["SGST"]);
                            item.IGST = Convert.IsDBNull(row["IGST"]) ? 0 : Convert.ToDecimal(row["IGST"]);
                            item.CGST = Convert.IsDBNull(row["CGST"]) ? 0 : Convert.ToDecimal(row["CGST"]);
                            item.Amount = Convert.IsDBNull(row["Amount"]) ? 0 : Convert.ToDecimal(row["Amount"]);
                            item.DiscountQuantity = Convert.IsDBNull(row["DiscountQuantity"]) ? 0 : Convert.ToDecimal(row["DiscountQuantity"]);
                            item.VolumeDiscount = Convert.IsDBNull(row["VolumeDiscount"]) ? 0 : Convert.ToDecimal(row["VolumeDiscount"]);
                            item.ConversionRate = Convert.IsDBNull(row["ConversionRate"]) ? 0 : Convert.ToDecimal(row["ConversionRate"]);
                            item.MRP = Convert.IsDBNull(row["MRP"]) ? 0 : Convert.ToDecimal(row["MRP"]);
                            item.ExpiryDate = Convert.IsDBNull(row["ExpiryDate"]) ? DateTime.MinValue : Convert.ToDateTime(row["ExpiryDate"]);
                            item.WholeSaleRate = Convert.IsDBNull(row["WholeSaleRate"]) ? 0 : Convert.ToDecimal(row["WholeSaleRate"]);
                            item.SpecialRate = Convert.IsDBNull(row["SpecialRate"]) ? 0 : Convert.ToDecimal(row["SpecialRate"]);
                            item.LocalCentral = Convert.ToString(row["LocalCentral"]);
                            item.PurchaseSaleTypeCode = Convert.ToString(row["PurchaseSaleTypeCode"]);
                            item.Discount = Convert.IsDBNull(row["Discount"]) ? 0 : Convert.ToDecimal(row["Discount"]);
                            item.Batch = Convert.ToString(row["Batch"]);
                            item.BatchNew = Convert.ToString(row["BatchNew"]);
                            item.EffecivePurchaseSaleRate = Convert.IsDBNull(row["EffecivePurchaseSaleRate"]) ? 0 : Convert.ToDecimal(row["EffecivePurchaseSaleRate"]);
                            item.PurchaseSaleRate = Convert.IsDBNull(row["PurchaseSaleRate"]) ? 0 : Convert.ToDecimal(row["PurchaseSaleRate"]);
                            item.FifoID = Convert.IsDBNull(row["Fifoid"]) ? 0 : Convert.ToInt32(row["Fifoid"]);
                            item.LineItemGroupID = Convert.IsDBNull(row["LineItemGroupID"]) ? 0 : Convert.ToInt32(row["LineItemGroupID"]);
                            item.SchemeAmount = Convert.IsDBNull(row["SchemeAmount"]) ? 0 : Convert.ToDecimal(row["SchemeAmount"]);
                            item.GrossAmount = Convert.IsDBNull(row["GrossAmount"]) ? 0 : Convert.ToDecimal(row["GrossAmount"]);
                            item.TaxAmount = Convert.IsDBNull(row["TaxAmount"]) ? 0 : Convert.ToDecimal(row["TaxAmount"]);
                            item.TotalDiscountAmount = Convert.IsDBNull(row["DiscountAmount"]) ? 0 : Convert.ToDecimal(row["DiscountAmount"]);
                            item.CostAmount = Convert.IsDBNull(row["BillAmount"]) ? 0 : Convert.ToDecimal(row["BillAmount"]);
                            lineItemList.Add(item);
                            //PurchaseBookAmount obj = new PurchaseBookAmount()
                            //{
                            //    PurchaseSaleBookLineItemID = row["PurchaseSaleBookLineItemID"] == null ? 0 : Convert.ToInt64(row["PurchaseSaleBookLineItemID"]),
                            //    PurchaseBookHeaderID = Convert.ToInt64(row["PurchaseSaleBookHeaderID"]),
                            //    BillAmount = Convert.ToInt64(row["BillAmount"]),
                            //    TaxAmount = Convert.ToInt64(row["TaxAmount"]),
                            //    CostAmount = Convert.ToInt64(row["CostAmount"]),
                            //    GrossAmount = Convert.ToInt64(row["GrossAmount"]),
                            //    SchemeAmount = Convert.ToInt64(row["SchemeAmount"]),
                            //    DiscountAmount = Convert.ToInt64(row["DiscountAmount"]),
                            //    SpecialDiscountAmount = Convert.ToInt64(row["SpecialDiscountAmount"]),
                            //    VolumeDiscountAmount = Convert.ToInt64(row["VolumeDiscountAmount"]),
                            //    TotalDiscountAmount = Convert.ToInt64(row["TotalDiscountAmount"])
                            //};

                            //purchaseBookAmounts.Add(obj);
                        }

                    }
                }


                return lineItemList;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void UpdateSaleDiscount(PharmaBusinessObjects.Common.Enums.SaleEntryChangeType changeType, decimal discount, decimal specialDiscount, decimal volumeDiscount,string itemCode, string customerCode)
        {
            using (PharmaDBEntities context = new PharmaDBEntities())
            {
                CustomerLedger ledger = context.CustomerLedger.FirstOrDefault(p => p.CustomerLedgerCode == customerCode);
                ItemMaster master = context.ItemMaster.FirstOrDefault(p => p.ItemCode == itemCode);

                if (changeType == PharmaBusinessObjects.Common.Enums.SaleEntryChangeType.CompanyWiseChange)
                {
                    var compItem = context.CustomerCompanyDiscountRef.Where(p => p.CustomerLedgerID == ledger.CustomerLedgerId && p.CompanyID == master.CompanyID && p.ItemID == null).FirstOrDefault();
                    if (compItem != null)
                    {
                        compItem.Normal = discount;
                    }
                }
                else
                {
                    var disItem = context.CustomerCompanyDiscountRef.Where(p => p.CustomerLedgerID == ledger.CustomerLedgerId && p.CompanyID == master.CompanyID && p.ItemID == master.ItemID).FirstOrDefault();
                    if (disItem != null)
                    {
                        disItem.Normal = discount;
                       
                    }
                    master.SpecialDiscount = specialDiscount;
                    
                }

                context.SaveChanges();
            }
        }

        public List<PharmaBusinessObjects.Transaction.PurchaseSaleBookLineItem> DeleteSaleLineItem(int saleBookHeaderID, int saleBookLineItemID)
        {
            List<PharmaBusinessObjects.Transaction.PurchaseSaleBookLineItem> itemList = new List<PharmaBusinessObjects.Transaction.PurchaseSaleBookLineItem>();

            using (PharmaDBEntities context = new PharmaDBEntities())
            {
                SqlConnection connection = (SqlConnection)context.Database.Connection;

                SqlCommand cmd = new SqlCommand("DeleteSaleLineItem", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("PurchaseSaleBookHeaderID", saleBookHeaderID));
                cmd.Parameters.Add(new SqlParameter("TempPurchaseSaleBookLineItemID", saleBookLineItemID));

                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                sda.Fill(dt);

                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        PharmaBusinessObjects.Transaction.PurchaseSaleBookLineItem item = new PharmaBusinessObjects.Transaction.PurchaseSaleBookLineItem();

                        item.PurchaseSaleBookLineItemID = Convert.ToInt32(row["PurchaseSaleBookLineItemID"]);
                        item.PurchaseSaleBookHeaderID = Convert.ToInt32(row["PurchaseSaleBookHeaderID"]);

                        item.SchemeAmount = Convert.IsDBNull(row["SchemeAmount"]) ? 0 : Convert.ToDecimal(row["SchemeAmount"]);
                        item.GrossAmount = Convert.IsDBNull(row["GrossAmount"]) ? 0 : Convert.ToDecimal(row["GrossAmount"]);
                        item.TaxAmount = Convert.IsDBNull(row["TaxAmount"]) ? 0 : Convert.ToDecimal(row["TaxAmount"]);
                        item.TotalDiscountAmount = Convert.IsDBNull(row["DiscountAmount"]) ? 0 : Convert.ToDecimal(row["DiscountAmount"]);
                        item.CostAmount = Convert.IsDBNull(row["BillAmount"]) ? 0 : Convert.ToDecimal(row["BillAmount"]);

                        itemList.Add(item);
                    }
                }

            }

            return itemList;
        }

        public bool IsQuantityAvailable(long headerID, long lineItemID, string itemCode, decimal quantity, decimal freeQuantity, ref decimal calcFreeQuantity)
        {
            using (PharmaDBEntities context = new PharmaDBEntities())
            {
                SqlConnection connection = (SqlConnection)context.Database.Connection;

                SqlCommand cmd = new SqlCommand("CheckQuantityIfAvailableForSale", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@PurchaseSaleBookHeaderID", headerID));
                cmd.Parameters.Add(new SqlParameter("@PurchaseSaleBookLineItemID", lineItemID));
                cmd.Parameters.Add(new SqlParameter("@ItemCode", itemCode));
                cmd.Parameters.Add(new SqlParameter("@Quantity", quantity));
                cmd.Parameters.Add(new SqlParameter("@FreeQuantity", freeQuantity));

                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                sda.Fill(dt);

                if (dt != null && dt.Rows.Count > 0)
                {
                    int result = 0;
                    Int32.TryParse(dt.Rows[0]["IsAvailable"].ToString(), out result);

                    calcFreeQuantity = 0;
                    decimal.TryParse(dt.Rows[0]["FreeQuantity"].ToString(), out calcFreeQuantity);
                    return result > 0;
                }
            }

            return false;
        }

        public long SaveSaleEntryData(long purchaseBookHeaderID)
        {
            string ConnString = ConfigurationManager.ConnectionStrings["PharmaDBConn"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(ConnString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("SaveSaleEntryData", connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@PurchaseSaleBookHeaderID", purchaseBookHeaderID));

                    DataTable dt = new DataTable();
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    sda.Fill(dt);

                    if(dt.Rows.Count > 0)
                    {
                        return Convert.ToInt64(dt.Rows[0]["PurchaseSaleHeaderID"].ToString());
                    }

                    return 0;
                }
                finally
                {

                    connection.Close();
                }
            }
           
        }

        public bool IsTempSaleEntryExists(long purchaseSaleBookHeaderID)
        {
            using (PharmaDBEntities context = new PharmaDBEntities())
            {
                return context.TempPurchaseSaleBookHeader.Any(p => p.PurchaseSaleBookHeaderID == purchaseSaleBookHeaderID);
            }
        }

        public void RollbackSaleEntry(long purchaseSaleBookHeaderID)
        {
            string ConnString = ConfigurationManager.ConnectionStrings["PharmaDBConn"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(ConnString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("DeleteSaleEntryData", connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@PurchaseSaleBookHeaderID", purchaseSaleBookHeaderID));
                    connection.Open();
                    cmd.ExecuteNonQuery();

                }
                finally
                {

                    connection.Close();
                }

            }
        }


        public List<PharmaBusinessObjects.Transaction.ReceiptPayment.BillOutstanding> GetAllSaleInvoiceForCustomer(string customerCode, string invoiceDate)
        {
            DateTime dt;
            DateTime.TryParse(invoiceDate, out dt);

            DateTime.TryParse(dt.ToString("dd/MM/yyyy h:mm:ss"), out dt);
            using (PharmaDBEntities context = new PharmaDBEntities())
            {
                return context.BillOutStandings.Where(q => q.LedgerTypeCode == customerCode && q.PurchaseSaleBookHeaderID != null)
                .Select(p => new PharmaBusinessObjects.Transaction.ReceiptPayment.BillOutstanding()
                {
                    BillOutStandingsID = p.BillOutStandingsID,
                    PurchaseSaleBookHeaderID = (long)p.PurchaseSaleBookHeaderID,
                    VoucherNumber = p.VoucherNumber,
                    VoucherTypeCode = p.VoucherTypeCode,
                    VoucherDate = p.VoucherDate,
                    InvoiceNumber = p.VoucherNumber,
                    InvoiceDate = p.PurchaseSaleBookHeader.VoucherDate,
                    LedgerType = p.LedgerType,
                    LedgerTypeCode = p.LedgerTypeCode,
                    BillAmount = p.BillAmount,
                    OSAmount = p.OSAmount,
                    IsHold = p.IsHold,
                    HOLDRemarks = p.HOLDRemarks
                }).ToList().Where(p => p.InvoiceDate.Date == dt.Date).ToList();
            }
        }

        public List<PharmaBusinessObjects.Transaction.ReceiptPayment.BillOutstanding> GetSaleChallanByCustomer(string customerCode, string invoiceDate)
        {
            
            DateTime dt;
            dt = DateTime.ParseExact(invoiceDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture );

            using (PharmaDBEntities context = new PharmaDBEntities())
            {
                
                return (
                            from challan in context.PurchaseSaleBookHeader
                            join invoice in context.PurchaseSaleBookHeader
                            on challan.PurchaseSaleBookHeaderID equals invoice.SaleChallanHeaderID ?? 0
                            into t
                            from f in t.DefaultIfEmpty()
                            join tempInvoice in context.TempPurchaseSaleBookHeader
                            on challan.PurchaseSaleBookHeaderID equals tempInvoice.SaleChallanHeaderID ?? 0
                            into p
                            from l in p.DefaultIfEmpty()
                            where f == null && l == null && challan.VoucherTypeCode == Constants.VoucherTypeCode.SALEONCHALLAN
                            select new PharmaBusinessObjects.Transaction.ReceiptPayment.BillOutstanding()
                            {
                                BillOutStandingsID = 0,
                                PurchaseSaleBookHeaderID = (long)challan.PurchaseSaleBookHeaderID,
                                VoucherNumber = challan.VoucherNumber,
                                VoucherTypeCode = challan.VoucherTypeCode,
                                VoucherDate = challan.VoucherDate,
                                InvoiceNumber = challan.VoucherNumber,
                                InvoiceDate = challan.VoucherDate,
                                LedgerType = challan.LedgerType,
                                LedgerTypeCode = challan.LedgerTypeCode,
                                BillAmount = challan.TotalBillAmount ?? 0,
                                OSAmount = challan.TotalBillAmount ?? 0

                            }
                        ).ToList().Where(p => p.InvoiceDate.Date == dt.Date).ToList(); 
                    
            }

        }


        public List<PharmaBusinessObjects.Transaction.PurchaseSaleBookLineItem> GetSaleChallanLineItems(long saleChallanHeaderID, long purchaseSaleBookHeaderID)
        {
            List<PharmaBusinessObjects.Transaction.PurchaseSaleBookLineItem> lineitems = new List<PharmaBusinessObjects.Transaction.PurchaseSaleBookLineItem>();

            string ConnString = ConfigurationManager.ConnectionStrings["PharmaDBConn"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(ConnString))
            {

                SqlCommand cmd = new SqlCommand("GetSaleChallanLineItems", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter() { ParameterName = "@PurchaseSaleBookHeaderID", Value = purchaseSaleBookHeaderID });
                cmd.Parameters.Add(new SqlParameter() { ParameterName = "@SaleChallanHeaderID", Value = saleChallanHeaderID });


                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                sda.Fill(dt);

                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        PharmaBusinessObjects.Transaction.PurchaseSaleBookLineItem obj = new PharmaBusinessObjects.Transaction.PurchaseSaleBookLineItem()
                        {
                            PurchaseSaleBookHeaderID = Convert.ToInt64(row["PurchaseSaleBookHeaderID"]),
                            PurchaseSaleBookLineItemID = Convert.ToInt64(row["PurchaseSaleBookLineItemID"]),
                            FifoID = Convert.ToInt64(row["FifoID"] == DBNull.Value ? 0 : row["FifoID"]),
                            ItemCode = Convert.ToString(row["ItemCode"]),
                            ItemName = Convert.ToString(row["ItemName"]),
                            Batch = Convert.ToString(row["Batch"]),
                            Quantity = Convert.ToDecimal(row["Quantity"] == DBNull.Value ? 0 : row["Quantity"]),
                            FreeQuantity = Convert.ToDecimal(row["FreeQuantity"] == DBNull.Value ? 0 : row["FreeQuantity"]),
                            PurchaseSaleRate = Convert.ToDecimal(row["PurchaseSaleRate"] == DBNull.Value ? 0 : row["PurchaseSaleRate"]),
                            OldPurchaseSaleRate = Convert.ToDecimal(row["PurchaseSaleRate"] == DBNull.Value ? 0 : row["PurchaseSaleRate"]),
                            EffecivePurchaseSaleRate = Convert.ToDecimal(row["EffecivePurchaseSaleRate"] == DBNull.Value ? 0 : row["EffecivePurchaseSaleRate"]),
                            PurchaseSaleTypeCode = Convert.ToString(row["PurchaseSaleTypeCode"]),
                            PurchaseSaleTax = Convert.ToDecimal(row["PurchaseSaleTax"] == DBNull.Value ? 0 : row["PurchaseSaleTax"]),
                            SurCharge = Convert.ToDecimal(row["SurCharge"] == DBNull.Value ? 0 : row["SurCharge"]),
                            LocalCentral = Convert.ToString(row["LocalCentral"]),
                            SGST = Convert.ToDecimal(row["SGST"] == DBNull.Value ? 0 : row["SGST"]),
                            IGST = Convert.ToDecimal(row["IGST"] == DBNull.Value ? 0 : row["IGST"]),
                            CGST = Convert.ToDecimal(row["CGST"] == DBNull.Value ? 0 : row["CGST"]),
                            Amount = Convert.ToDecimal(row["Amount"] == DBNull.Value ? 0 : row["Amount"]),
                            Discount = Convert.ToDecimal(row["Discount"] == DBNull.Value ? 0 : row["Discount"]),
                            SpecialDiscount = Convert.ToDecimal(row["SpecialDiscount"] == DBNull.Value ? 0 : row["SpecialDiscount"]),
                            DiscountQuantity = Convert.ToDecimal(row["DiscountQuantity"] == DBNull.Value ? 0 : row["DiscountQuantity"]),
                            VolumeDiscount = Convert.ToDecimal(row["VolumeDiscount"] == DBNull.Value ? 0 : row["VolumeDiscount"]),
                            Scheme1 = Convert.ToDecimal(row["Scheme1"] == DBNull.Value ? 0 : row["Scheme1"]),
                            Scheme2 = Convert.ToDecimal(row["Scheme2"] == DBNull.Value ? 0 : row["Scheme2"]),
                            IsHalfScheme = Convert.ToBoolean(row["IsHalfScheme"] == DBNull.Value ? false : row["IsHalfScheme"]),
                            HalfSchemeRate = Convert.ToDecimal(row["HalfSchemeRate"] == DBNull.Value ? 0 : row["HalfSchemeRate"]),
                            CostAmount = Convert.ToDecimal(row["CostAmount"] == DBNull.Value ? 0 : row["CostAmount"]),
                            GrossAmount = Convert.ToDecimal(row["GrossAmount"] == DBNull.Value ? 0 : row["GrossAmount"]),
                            SchemeAmount = Convert.ToDecimal(row["SchemeAmount"] == DBNull.Value ? 0 : row["SchemeAmount"]),
                            DiscountAmount = Convert.ToDecimal(row["DiscountAmount"] == DBNull.Value ? 0 : row["DiscountAmount"]),
                            SurchargeAmount = Convert.ToDecimal(row["SurchargeAmount"] == DBNull.Value ? 0 : row["SurchargeAmount"]),
                            ConversionRate = Convert.ToDecimal(row["ConversionRate"] == DBNull.Value ? 0 : row["ConversionRate"]),
                            MRP = Convert.ToDecimal(row["MRP"] == DBNull.Value ? 0 : row["MRP"]),
                            ExpiryDate = Convert.ToDateTime(row["ExpiryDate"]),
                            SaleRate = Convert.ToDecimal(row["SaleRate"] == DBNull.Value ? 0 : row["SaleRate"]),
                            WholeSaleRate = Convert.ToDecimal(row["WholeSaleRate"] == DBNull.Value ? 0 : row["WholeSaleRate"]),
                            SpecialRate = Convert.ToDecimal(row["SpecialRate"] == DBNull.Value ? 0 : row["SpecialRate"]),
                            TaxAmount = Convert.ToDecimal(row["TaxAmount"] == DBNull.Value ? 0 : row["TaxAmount"]),
                            SpecialDiscountAmount = Convert.ToDecimal(row["SpecialDiscountAmount"] == DBNull.Value ? 0 : row["SpecialDiscountAmount"]),
                            VolumeDiscountAmount = Convert.ToDecimal(row["VolumeDiscountAmount"] == DBNull.Value ? 0 : row["VolumeDiscountAmount"]),
                            TotalDiscountAmount = Convert.ToDecimal(row["TotalDiscountAmount"] == DBNull.Value ? 0 : row["TotalDiscountAmount"]),
                            OldPurchaseSaleBookLineItemID = Convert.ToInt64(row["OldPurchaseSaleBookLineItemID"] == DBNull.Value ? 0 : row["OldPurchaseSaleBookLineItemID"]),
                            BalanceQuantity = Convert.ToDecimal(row["BalanceQuantity"] == DBNull.Value ? 0 : row["BalanceQuantity"]),
                            UsedQuantity = Convert.ToDecimal(row["UsedQuantity"] == DBNull.Value ? 0 : row["UsedQuantity"]),
                            PurchaseBillDate = row["PurchaseBillDate"] != DBNull.Value ? Convert.ToDateTime(row["PurchaseBillDate"]) : (DateTime?)null,
                            PurchaseSrlNo = row["PurchaseSrlNo"] != null ? Convert.ToInt32(row["PurchaseSrlNo"]) : (int?)null,
                            PurchaseVoucherNumber = row["PurchaseVoucherNumber"] != null ? Convert.ToString(row["PurchaseVoucherNumber"]) : null,
                            MfgDate = row["MfgDate"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(row["MfgDate"])
                        };

                        lineitems.Add(obj);
                    }


                }
            }
            return lineitems;
        }

    }
}
