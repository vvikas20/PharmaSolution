using PharmaBusinessObjects.Common;
using PharmaDAL.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaDAL.Master
{
    public class CustomerLedgerMasterDao : BaseDao
    {
        public CustomerLedgerMasterDao(PharmaBusinessObjects.Master.UserMaster loggedInUser) : base(loggedInUser)
        {

        }

        public List<PharmaBusinessObjects.Master.CustomerLedgerMaster> GetCustomerLedgers(string searchString = null)
        {
            using (PharmaDBEntities context = new PharmaDBEntities())
            {


                return context.CustomerLedger.Where(q => (string.IsNullOrEmpty(searchString) || q.CustomerLedgerName.Contains(searchString)))
                                            .Select(p => new PharmaBusinessObjects.Master.CustomerLedgerMaster()
                                            {
                                                CustomerLedgerId = p.CustomerLedgerId,
                                                CustomerLedgerCode = p.CustomerLedgerCode,
                                                CustomerLedgerName = p.CustomerLedgerName,
                                                CustomerLedgerShortName = p.CustomerLedgerShortName,
                                                Address = p.Address,
                                                ContactPerson = p.ContactPerson,
                                                Telephone = p.Telephone,
                                                Mobile = p.Mobile,
                                                OfficePhone = p.OfficePhone,
                                                ResidentPhone = p.ResidentPhone,
                                                EmailAddress = p.EmailAddress,
                                                ZSMId = p.ZSMId,
                                                ZSMName = p.PersonRouteMaster.PersonRouteName,
                                                RSMId = p.RSMId,
                                                RSMName = p.PersonRouteMaster2.PersonRouteName,
                                                ASMId = p.ASMId,
                                                ASMName = p.PersonRouteMaster1.PersonRouteName,
                                                SalesManId = p.SalesManId,
                                                SalesmanName = p.PersonRouteMaster3.PersonRouteName,
                                                AreaId = p.AreaId,
                                                AreaName = p.PersonRouteMaster4.PersonRouteName,
                                                RouteId = p.RouteId,
                                                RouteName = p.PersonRouteMaster5.PersonRouteName,
                                                CreditDebit = p.CreditDebit,
                                                DLNo = p.DLNo,
                                                GSTNo = p.GSTNo,
                                                CINNo = p.CINNo,
                                                LINNo = p.LINNo,
                                                ServiceTaxNo = p.ServiceTaxNo,
                                                PANNo = p.PANNo,
                                                OpeningBal = p.OpeningBal,
                                                TaxRetail = p.TaxRetail,
                                                Status = p.Status,
                                                CreditLimit = p.CreditLimit,
                                                CustomerTypeID = p.CustomerTypeID,
                                                CustomerTypeName = "",
                                                InterestTypeID = p.InterestTypeID,
                                                InterestTypeName = "",
                                                IsLessExcise = p.IsLessExcise,
                                                RateTypeID = p.RateTypeID,
                                                RateTypeName = "",
                                                SaleBillFormat = p.SaleBillFormat,
                                                MaxOSAmount = p.MaxOSAmount,
                                                MaxNumOfOSBill = p.MaxNumOfOSBill,
                                                MaxBillAmount = p.MaxBillAmount,
                                                MaxGracePeriod = p.MaxGracePeriod,
                                                IsFollowConditionStrictly = p.IsFollowConditionStrictly,
                                                Discount = p.Discount,
                                                CentralLocal = p.CentralLocal,
                                                StatusText = p.Status ? string.Empty : Constants.Others.Inactive
                                            }).ToList();
            }

        }

        public int AddCustomerLedger(PharmaBusinessObjects.Master.CustomerLedgerMaster p)
        {

            try
            {
                using (PharmaDBEntities context = new PharmaDBEntities())
                {
                    var maxCustmerLedgerID = context.CustomerLedger.Count() + 1;

                    var customerLedgerCode = "C" + maxCustmerLedgerID.ToString().PadLeft(6, '0');

                    Entity.CustomerLedger table = new Entity.CustomerLedger()
                    {
                        CustomerLedgerCode = customerLedgerCode,
                        CustomerLedgerName = p.CustomerLedgerName,
                        CustomerLedgerShortName = p.CustomerLedgerShortName,
                        Address = p.Address,
                        ContactPerson = p.ContactPerson,
                        Telephone=p.Telephone,
                        Mobile = p.Mobile,
                        OfficePhone = p.OfficePhone,
                        ResidentPhone = p.ResidentPhone,
                        EmailAddress = p.EmailAddress,
                        AreaId = p.AreaId,
                        CreditDebit = p.CreditDebit,
                        DLNo = p.DLNo,
                        GSTNo = p.GSTNo,
                        CINNo = p.CINNo,
                        LINNo = p.LINNo,
                        ServiceTaxNo = p.ServiceTaxNo,
                        PANNo = p.PANNo,
                        OpeningBal = p.OpeningBal,
                        TaxRetail = p.TaxRetail,
                        Status = p.Status,
                        ASMId = p.ASMId,
                        CreditLimit = p.CreditLimit,
                        CustomerTypeID = p.CustomerTypeID,
                        InterestTypeID = p.InterestTypeID,
                        IsLessExcise = p.IsLessExcise,
                        RateTypeID = p.RateTypeID,
                        RouteId = p.RouteId,
                        RSMId = p.RSMId,
                        SalesManId = p.SalesManId,
                        ZSMId = p.ZSMId,
                        SaleBillFormat = p.SaleBillFormat,
                        MaxOSAmount = p.MaxOSAmount,
                        MaxNumOfOSBill = p.MaxNumOfOSBill,
                        MaxBillAmount = p.MaxBillAmount,
                        MaxGracePeriod = p.MaxGracePeriod,
                        IsFollowConditionStrictly = p.IsFollowConditionStrictly,
                        Discount = p.Discount,
                        CentralLocal = p.CentralLocal,
                        CreatedBy = this.LoggedInUser.Username,
                        CreatedOn = System.DateTime.Now

                    };
                    context.CustomerLedger.Add(table);

                    ///Add Customer Company discount data
                    ///
                    var previousMappings= context.CustomerCompanyDiscountRef.Where(x => x.CustomerLedgerID == p.CustomerLedgerId).ToList();
                    context.CustomerCompanyDiscountRef.RemoveRange(previousMappings);

                    foreach (var newEntry in p.CustomerCopanyDiscountList)
                    {
                        context.CustomerCompanyDiscountRef.Add(new Entity.CustomerCompanyDiscountRef()
                        {
                            CustomerLedgerID = p.CustomerLedgerId,
                            CompanyID = newEntry.CompanyID,
                            Normal = newEntry.Normal,
                            Breakage = newEntry.Breakage,
                            Expired = newEntry.Expired,
                            IsLessEcise = false
                        });

                        ///All entry for item mappings
                        ///

                        if (newEntry.CustomerItemDiscountMapping != null)
                        {
                            foreach (var newItem in newEntry.CustomerItemDiscountMapping)
                            {
                                context.CustomerCompanyDiscountRef.Add(new Entity.CustomerCompanyDiscountRef()
                                {
                                    CustomerLedgerID = table.CustomerLedgerId,
                                    CompanyID = newEntry.CompanyID,
                                    ItemID = newItem.ItemID,
                                    Normal = newItem.Normal,
                                    Breakage = newItem.Breakage,
                                    Expired = newItem.Expired,
                                    IsLessEcise = false
                                });
                            }
                        }
                    }
                    return context.SaveChanges();
                }
            }
            catch (Exception)
            {
                return 0;

            }          
        }

        public int UpdateCustomerLedger(PharmaBusinessObjects.Master.CustomerLedgerMaster p)
        {
            using (PharmaDBEntities context = new PharmaDBEntities())
            {
                try
                {
                    var customerLedgerMaster = context.CustomerLedger.Where(q => q.CustomerLedgerId == p.CustomerLedgerId).FirstOrDefault();

                    if (customerLedgerMaster != null)
                    {
                        customerLedgerMaster.CustomerLedgerName = p.CustomerLedgerName;
                        customerLedgerMaster.CustomerLedgerShortName = p.CustomerLedgerShortName;
                        customerLedgerMaster.Address = p.Address;
                        customerLedgerMaster.ContactPerson = p.ContactPerson;
                        customerLedgerMaster.Telephone = p.Telephone;   
                        customerLedgerMaster.Mobile = p.Mobile;
                        customerLedgerMaster.OfficePhone = p.OfficePhone;
                        customerLedgerMaster.ResidentPhone = p.ResidentPhone;
                        customerLedgerMaster.EmailAddress = p.EmailAddress;
                        customerLedgerMaster.AreaId = p.AreaId;
                        customerLedgerMaster.CreditDebit = p.CreditDebit;
                        customerLedgerMaster.DLNo = p.DLNo;
                        customerLedgerMaster.GSTNo = p.GSTNo;
                        customerLedgerMaster.CINNo = p.CINNo;
                        customerLedgerMaster.LINNo = p.LINNo;
                        customerLedgerMaster.ServiceTaxNo = p.ServiceTaxNo;
                        customerLedgerMaster.PANNo = p.PANNo;
                        customerLedgerMaster.OpeningBal = p.OpeningBal;
                        customerLedgerMaster.TaxRetail = p.TaxRetail;
                        customerLedgerMaster.Status = p.Status;
                        customerLedgerMaster.ASMId = p.ASMId;
                        customerLedgerMaster.CreditLimit = p.CreditLimit;
                        customerLedgerMaster.CustomerTypeID = p.CustomerTypeID;
                        customerLedgerMaster.InterestTypeID = p.InterestTypeID;
                        customerLedgerMaster.IsLessExcise = p.IsLessExcise;
                        customerLedgerMaster.RateTypeID = p.RateTypeID;
                        customerLedgerMaster.RouteId = p.RouteId;
                        customerLedgerMaster.RSMId = p.RSMId;
                        customerLedgerMaster.SalesManId = p.SalesManId;
                        customerLedgerMaster.ZSMId = p.ZSMId;
                        customerLedgerMaster.SaleBillFormat = p.SaleBillFormat;
                        customerLedgerMaster.MaxOSAmount = p.MaxOSAmount;
                        customerLedgerMaster.MaxNumOfOSBill = p.MaxNumOfOSBill;
                        customerLedgerMaster.MaxBillAmount = p.MaxBillAmount;
                        customerLedgerMaster.MaxGracePeriod = p.MaxGracePeriod;
                        customerLedgerMaster.IsFollowConditionStrictly = p.IsFollowConditionStrictly;
                        customerLedgerMaster.Discount = p.Discount;
                        customerLedgerMaster.CentralLocal = p.CentralLocal;
                        customerLedgerMaster.ModifiedBy = this.LoggedInUser.Username;
                        customerLedgerMaster.ModifiedOn = System.DateTime.Now;


                        ///Add Customer Company discount data
                        ///
                        var previousMappings = context.CustomerCompanyDiscountRef.Where(x => x.CustomerLedgerID == p.CustomerLedgerId).ToList();
                        context.CustomerCompanyDiscountRef.RemoveRange(previousMappings);

                        foreach (var newEntry in p.CustomerCopanyDiscountList)
                        {
                            context.CustomerCompanyDiscountRef.Add(new Entity.CustomerCompanyDiscountRef()
                            {
                                CustomerLedgerID = p.CustomerLedgerId,
                                CompanyID = newEntry.CompanyID,
                                Normal = newEntry.Normal,
                                Breakage = newEntry.Breakage,
                                Expired = newEntry.Expired,
                                IsLessEcise = false
                            });

                            ///All entry for item mappings
                            ///
                            if (newEntry.CustomerItemDiscountMapping != null)
                            {
                                foreach (var newItem in newEntry.CustomerItemDiscountMapping)
                                {
                                    context.CustomerCompanyDiscountRef.Add(new Entity.CustomerCompanyDiscountRef()
                                    {
                                        CustomerLedgerID = p.CustomerLedgerId,
                                        CompanyID = newEntry.CompanyID,
                                        ItemID = newItem.ItemID,
                                        Normal = newItem.Normal,
                                        Breakage = newItem.Breakage,
                                        Expired = newItem.Expired,
                                        IsLessEcise = false
                                    });
                                }
                            }
                        }
                    }

                    return context.SaveChanges();
                }
                catch (System.Data.Entity.Validation.DbEntityValidationException ex)
                {
                    throw ex;
                }
            }

        }

        public List<PharmaBusinessObjects.Master.CustomerCopanyDiscount> GetExistigCompanyDiscountMappingByCustomerID(int customerLedgerID)
        {          
            try
            {
                using (PharmaDBEntities context = new PharmaDBEntities())
                {
                    List<PharmaBusinessObjects.Master.CustomerCopanyDiscount> existingDiscountMapping = new List<PharmaBusinessObjects.Master.CustomerCopanyDiscount>();

                    existingDiscountMapping = context.CustomerCompanyDiscountRef.Where(q => q.CustomerLedgerID == customerLedgerID && q.CompanyMaster.Status && q.ItemID == null)
                                                      .Select(x => new PharmaBusinessObjects.Master.CustomerCopanyDiscount()
                                                      {
                                                          CompanyID = x.CompanyMaster.CompanyId,
                                                          CompanyName = x.CompanyMaster.CompanyName,
                                                          Normal = x.Normal,
                                                          Breakage = x.Breakage,
                                                          Expired = x.Expired
                                                      }).ToList();

                    ///Isssue in a single linq
                    foreach (var item in existingDiscountMapping)
                    {
                        item.CustomerItemDiscountMapping = context.CustomerCompanyDiscountRef.Where(y => y.CompanyID == item.CompanyID && y.ItemID != null)
                                                                                                                        .Select(o => new PharmaBusinessObjects.Master.CustomerCopanyDiscount()
                                                                                                                        {
                                                                                                                            CompanyID = o.CompanyID,
                                                                                                                            CompanyName = o.CompanyMaster.CompanyName,
                                                                                                                            ItemID = o.ItemID,
                                                                                                                            ItemName = o.ItemMaster.ItemName,
                                                                                                                            Normal = o.Normal,
                                                                                                                            Breakage = o.Breakage,
                                                                                                                            Expired = o.Expired

                                                                                                                        }).ToList();
                    }

                    return existingDiscountMapping;
                }
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public List<PharmaBusinessObjects.Master.CustomerCopanyDiscount> GetCompleteCompanyDiscountList(int customerLedgerID)
        {
            try
            {
                using (PharmaDBEntities context = new PharmaDBEntities())
                {
                    List<PharmaBusinessObjects.Master.CustomerCopanyDiscount> mappedDiscount = GetExistigCompanyDiscountMappingByCustomerID(customerLedgerID);
                    List<PharmaBusinessObjects.Master.CustomerCopanyDiscount> allCompanyDiscountMapping = context.CompanyMaster.Where(q => q.Status)
                                                      .Select(x => new PharmaBusinessObjects.Master.CustomerCopanyDiscount()
                                                      {
                                                          CompanyID = x.CompanyId,
                                                          CompanyName = x.CompanyName

                                                      }).ToList();

                    allCompanyDiscountMapping.RemoveAll(x => mappedDiscount.Any(y => y.CompanyID == x.CompanyID));
                    allCompanyDiscountMapping.AddRange(mappedDiscount);

                    return allCompanyDiscountMapping.OrderBy(x=>x.CompanyName).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public int DeleteCustomerLedger(int customerLedgerID)
        {
            using (PharmaDBEntities context = new PharmaDBEntities())
            {
                var customerLedgerMaster = context.CustomerLedger.FirstOrDefault(p => p.CustomerLedgerId == customerLedgerID);

                if (customerLedgerMaster != null)
                {
                    customerLedgerMaster.Status = false;
                    customerLedgerMaster.ModifiedBy = this.LoggedInUser.Username;
                    customerLedgerMaster.ModifiedOn = System.DateTime.Now;
                }

                return context.SaveChanges();
            }
        }

        public PharmaBusinessObjects.Master.CustomerLedgerMaster GetCustomerLedgerByCode(string code)
        {
            PharmaBusinessObjects.Master.CustomerLedgerMaster customer = new PharmaBusinessObjects.Master.CustomerLedgerMaster();

            using (PharmaDBEntities context = new PharmaDBEntities())
            {
                SqlConnection connection = (SqlConnection)context.Database.Connection;

                SqlCommand cmd = new SqlCommand("GetCustomerLedgerByCode", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@customerCode", code));

                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                sda.Fill(dt);

                if (dt != null && dt.Rows.Count > 0)
                {
                    customer.CustomerLedgerId = Convert.ToInt32(dt.Rows[0]["CustomerLedgerId"]);
                    customer.CustomerLedgerCode = Convert.ToString(dt.Rows[0]["CustomerLedgerCode"]);
                    customer.CustomerLedgerName = Convert.ToString(dt.Rows[0]["CustomerLedgerName"]);
                    customer.CustomerLedgerShortName = Convert.ToString(dt.Rows[0]["CustomerLedgerShortName"]);
                    customer.Address = Convert.ToString(dt.Rows[0]["Address"]);
                    customer.ContactPerson = Convert.ToString(dt.Rows[0]["ContactPerson"]);
                    customer.Telephone = Convert.ToString(dt.Rows[0]["Telephone"]);
                    customer.Mobile = Convert.ToString(dt.Rows[0]["Mobile"]);
                    customer.OfficePhone = Convert.ToString(dt.Rows[0]["OfficePhone"]);
                    customer.ResidentPhone = Convert.ToString(dt.Rows[0]["ResidentPhone"]);
                    customer.EmailAddress = Convert.ToString(dt.Rows[0]["EmailAddress"]);
                    customer.ZSMId = Convert.IsDBNull(dt.Rows[0]["ZSMId"]) ? 0 : Convert.ToInt32(dt.Rows[0]["ZSMId"]);
                    customer.RSMId = Convert.IsDBNull(dt.Rows[0]["RSMId"]) ? 0 : Convert.ToInt32(dt.Rows[0]["RSMId"]);
                    customer.ASMId = Convert.IsDBNull(dt.Rows[0]["ASMId"]) ? 0 : Convert.ToInt32(dt.Rows[0]["ASMId"]);

                    customer.SalesManId = Convert.IsDBNull(dt.Rows[0]["SalesManId"]) ? 0 : Convert.ToInt32(dt.Rows[0]["SalesManId"]);
                    customer.SalesmanName = Convert.ToString(dt.Rows[0]["SaleManName"]);
                    customer.AreaId = Convert.IsDBNull(dt.Rows[0]["AreaId"]) ? 0 : Convert.ToInt32(dt.Rows[0]["AreaId"]);
                    customer.RouteId = Convert.IsDBNull(dt.Rows[0]["RouteId"]) ? 0 : Convert.ToInt32(dt.Rows[0]["RouteId"]);
                    customer.CreditDebit = Convert.ToString(dt.Rows[0]["CreditDebit"]);
                    customer.DLNo = Convert.ToString(dt.Rows[0]["DLNo"]);
                    customer.GSTNo = Convert.ToString(dt.Rows[0]["GSTNo"]);
                    customer.CINNo = Convert.ToString(dt.Rows[0]["CINNo"]);
                    customer.LINNo = Convert.ToString(dt.Rows[0]["LINNo"]);
                    customer.ServiceTaxNo = Convert.ToString(dt.Rows[0]["ServiceTaxNo"]);
                    customer.PANNo = Convert.ToString(dt.Rows[0]["PANNo"]);
                    customer.OpeningBal = Convert.IsDBNull(dt.Rows[0]["OpeningBal"]) ? 0L : Convert.ToDecimal(dt.Rows[0]["OpeningBal"]);
                    customer.TaxRetail = Convert.ToString(dt.Rows[0]["TaxRetail"]);
                    customer.Status = Convert.IsDBNull(dt.Rows[0]["Status"]) ? false : Convert.ToBoolean(dt.Rows[0]["Status"]);
                    customer.CreditLimit = Convert.IsDBNull(dt.Rows[0]["CreditLimit"]) ? 0 : Convert.ToInt32(dt.Rows[0]["CreditLimit"]);
                    customer.CustomerTypeID = Convert.IsDBNull(dt.Rows[0]["CustomerTypeID"]) ? 0 : Convert.ToInt32(dt.Rows[0]["CustomerTypeID"]);
                    customer.InterestTypeID = Convert.IsDBNull(dt.Rows[0]["InterestTypeID"]) ? 0 : Convert.ToInt32(dt.Rows[0]["InterestTypeID"]);
                    customer.IsLessExcise = Convert.IsDBNull(dt.Rows[0]["IsLessExcise"]) ? false : Convert.ToBoolean(dt.Rows[0]["IsLessExcise"]);
                    customer.RateTypeID = Convert.IsDBNull(dt.Rows[0]["RateTypeID"]) ? 0 : Convert.ToInt32(dt.Rows[0]["RateTypeID"]);
                    customer.RateTypeName = Convert.ToString(dt.Rows[0]["RateTypeName"]);
                    customer.SaleBillFormat = Convert.ToString(dt.Rows[0]["SaleBillFormat"]);
                    customer.MaxOSAmount = Convert.IsDBNull(dt.Rows[0]["MaxOSAmount"]) ? 0L : Convert.ToDecimal(dt.Rows[0]["MaxOSAmount"]);
                    customer.MaxNumOfOSBill = Convert.IsDBNull(dt.Rows[0]["MaxNumOfOSBill"]) ? 0 : Convert.ToInt32(dt.Rows[0]["MaxNumOfOSBill"]);
                    customer.MaxBillAmount = Convert.IsDBNull(dt.Rows[0]["MaxBillAmount"]) ? 0L : Convert.ToDecimal(dt.Rows[0]["MaxBillAmount"]);
                    customer.MaxGracePeriod = Convert.IsDBNull(dt.Rows[0]["MaxGracePeriod"]) ? 0 : Convert.ToInt32(dt.Rows[0]["MaxGracePeriod"]);
                    customer.IsFollowConditionStrictly = Convert.IsDBNull(dt.Rows[0]["IsFollowConditionStrictly"]) ? false : Convert.ToBoolean(dt.Rows[0]["IsFollowConditionStrictly"]);
                    customer.Discount = Convert.IsDBNull(dt.Rows[0]["Discount"]) ? 0L : Convert.ToDecimal(dt.Rows[0]["Discount"]);
                    customer.CentralLocal = Convert.ToString(dt.Rows[0]["CentralLocal"]);
                    customer.DueBillCount = Convert.IsDBNull(dt.Rows[0]["DueCount"]) ? 0 : Convert.ToInt32(dt.Rows[0]["DueCount"]);
                    customer.DueBillAmount = Convert.IsDBNull(dt.Rows[0]["DueAmount"]) ? 0L : Convert.ToDouble(dt.Rows[0]["DueAmount"]);
                    customer.SalesManCode = Convert.ToString(dt.Rows[0]["SaleManCode"]);
                    customer.StatusText = Convert.IsDBNull(dt.Rows[0]["Status"]) ? Constants.Others.Inactive : Convert.ToBoolean(dt.Rows[0]["Status"]) ? string.Empty : Constants.Others.Inactive ;
                }

                return customer;
            }
        }
    }
}
