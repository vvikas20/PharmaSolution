using PharmaBusinessObjects.Common;
using PharmaBusinessObjects.Master;
using PharmaDAL.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaDAL.Master
{
    public class SupplierLedgerMasterDao : BaseDao
    {
        public SupplierLedgerMasterDao(PharmaBusinessObjects.Master.UserMaster loggedInUser) : base(loggedInUser)
        {

        }

        public List<PharmaBusinessObjects.Master.SupplierLedgerMaster> GetSupplierLedgers(string searchText)
        {
            using (PharmaDBEntities context = new PharmaDBEntities())
            {
                return context.SupplierLedger.Where(p => (string.IsNullOrEmpty(searchText) || p.SupplierLedgerName.Contains(searchText))).Select(p => new PharmaBusinessObjects.Master.SupplierLedgerMaster()
                {
                    SupplierLedgerId = p.SupplierLedgerId,
                    SupplierLedgerCode = p.SupplierLedgerCode,
                    SupplierLedgerName = p.SupplierLedgerName,
                    SupplierLedgerShortName = p.SupplierLedgerShortName,
                    Address = p.Address,
                    ContactPerson = p.ContactPerson,
                    Mobile = p.Mobile,
                    OfficePhone = p.OfficePhone,
                    ResidentPhone = p.ResidentPhone,
                    EmailAddress = p.EmailAddress,                   
                    AreaId = p.AreaId,
                    AreaName = p.PersonRouteMaster.PersonRouteName,
                    CreditDebit = p.CreditDebit,
                    OpeningBal = p.OpeningBal,
                    TaxRetail = p.TaxRetail,
                    DLNo = p.DLNo,
                    GSTNo = p.GSTNo,
                    CINNo = p.CINNo,
                    LINNo = p.LINNo,
                    ServiceTaxNo = p.ServiceTaxNo,
                    PANNo = p.PANNo,
                    Status = p.Status,
                    StatusText = p.Status ? string.Empty : Constants.Others.Inactive

                }).ToList();
            }

        }

        public SupplierLedgerMaster GetSupplierLedgerById(int supplierId)
        {
            using (PharmaDBEntities context = new PharmaDBEntities())
            {
                return context.SupplierLedger.Where(p => p.SupplierLedgerId == supplierId).Select(p => new PharmaBusinessObjects.Master.SupplierLedgerMaster()
                {
                    SupplierLedgerId = p.SupplierLedgerId,
                    SupplierLedgerCode = p.SupplierLedgerCode,
                    SupplierLedgerName = p.SupplierLedgerName,
                    SupplierLedgerShortName = p.SupplierLedgerShortName,
                    Address = p.Address,
                    ContactPerson = p.ContactPerson,
                    Mobile = p.Mobile,
                    OfficePhone = p.OfficePhone,
                    ResidentPhone = p.ResidentPhone,
                    EmailAddress = p.EmailAddress,
                    AreaId = p.AreaId,
                    AreaName = p.PersonRouteMaster.PersonRouteName,
                    CreditDebit = p.CreditDebit,
                    OpeningBal = p.OpeningBal,
                    TaxRetail = p.TaxRetail,
                    DLNo = p.DLNo,
                    GSTNo = p.GSTNo,
                    CINNo = p.CINNo,
                    LINNo = p.LINNo,
                    ServiceTaxNo = p.ServiceTaxNo,
                    PANNo = p.PANNo,
                    Status = p.Status,
                    StatusText = p.Status ? string.Empty : Constants.Others.Inactive
                }).FirstOrDefault();

            }
        }

        public int AddSupplierLedger(PharmaBusinessObjects.Master.SupplierLedgerMaster p)
        {
            using (PharmaDBEntities context = new PharmaDBEntities())
            {
                try
                {
                    var maxSupplierLedgerID = context.SupplierLedger.Count() + 1;
                    var supplierLedgerCode = "S" + maxSupplierLedgerID.ToString().PadLeft(6, '0');

                    Entity.SupplierLedger table = new Entity.SupplierLedger()
                    {
                        SupplierLedgerCode = supplierLedgerCode,
                        SupplierLedgerName = p.SupplierLedgerName,
                        SupplierLedgerShortName = p.SupplierLedgerShortName,
                        Address = p.Address,
                        ContactPerson = p.ContactPerson,
                        Mobile = p.Mobile,
                        OfficePhone = p.OfficePhone,
                        ResidentPhone = p.ResidentPhone,
                        EmailAddress = p.EmailAddress,
                        AreaId = p.AreaId,
                        CreditDebit = p.CreditDebit,
                        OpeningBal = p.OpeningBal,
                        TaxRetail = p.TaxRetail,
                        PurchaseTypeID = p.PurchaseTypeId,
                        DLNo = p.DLNo,
                        GSTNo = p.GSTNo,
                        CINNo = p.CINNo,
                        LINNo = p.LINNo,
                        ServiceTaxNo = p.ServiceTaxNo,
                        PANNo = p.PANNo,
                        Status = p.Status,
                        CreatedBy = this.LoggedInUser.Username,
                        CreatedOn = System.DateTime.Now
                    };

                    context.SupplierLedger.Add(table);


                    ///Add Supplier Company discount data
                    ///
                    var previousMappings = context.SupplierCompanyDiscountRef.Where(x => x.SupplierLedgerID == p.SupplierLedgerId).ToList();
                    context.SupplierCompanyDiscountRef.RemoveRange(previousMappings);

                    foreach (var newEntry in p.SupplierCompanyDiscountList)
                    {
                        context.SupplierCompanyDiscountRef.Add(new Entity.SupplierCompanyDiscountRef()
                        {
                            SupplierLedgerID = p.SupplierLedgerId,
                            CompanyID = newEntry.CompanyID,
                            Normal = newEntry.Normal,
                            Breakage = newEntry.Breakage,
                            Expired = newEntry.Expired
                        });

                        ///All entry for item mappings
                        ///

                        if (newEntry.SupplierItemDiscountMapping != null)
                        {
                            foreach (var newItem in newEntry.SupplierItemDiscountMapping)
                            {
                                context.SupplierCompanyDiscountRef.Add(new Entity.SupplierCompanyDiscountRef()
                                {
                                    SupplierLedgerID = table.SupplierLedgerId,
                                    CompanyID = newEntry.CompanyID,
                                    ItemID = newItem.ItemID,
                                    Normal = newItem.Normal,
                                    Breakage = newItem.Breakage,
                                    Expired = newItem.Expired
                                });
                            }
                        }
                    }

                    return context.SaveChanges();
                }
                catch (DbEntityValidationException ex)
                {
                    throw ex;
                }
            }
        }

        public int UpdateSupplierLedger(PharmaBusinessObjects.Master.SupplierLedgerMaster p)
        {
            using (PharmaDBEntities context = new PharmaDBEntities())
            {
                try
                {
                    var supplierLedgerMaster = context.SupplierLedger.Where(q => q.SupplierLedgerId == p.SupplierLedgerId).FirstOrDefault();

                    if (supplierLedgerMaster != null)
                    {                      
                        supplierLedgerMaster.SupplierLedgerName = p.SupplierLedgerName;
                        supplierLedgerMaster.SupplierLedgerShortName = p.SupplierLedgerShortName;
                        supplierLedgerMaster.Address = p.Address;
                        supplierLedgerMaster.ContactPerson = p.ContactPerson;
                        supplierLedgerMaster.Mobile = p.Mobile;
                        supplierLedgerMaster.OfficePhone = p.OfficePhone;
                        supplierLedgerMaster.ResidentPhone = p.ResidentPhone;
                        supplierLedgerMaster.EmailAddress = p.EmailAddress;
                        supplierLedgerMaster.AreaId = p.AreaId;
                        supplierLedgerMaster.CreditDebit = p.CreditDebit;
                        supplierLedgerMaster.OpeningBal = p.OpeningBal;
                        supplierLedgerMaster.TaxRetail = p.TaxRetail;
                        supplierLedgerMaster.DLNo = p.DLNo;
                        supplierLedgerMaster.GSTNo = p.GSTNo;
                        supplierLedgerMaster.CINNo = p.CINNo;
                        supplierLedgerMaster.LINNo = p.LINNo;
                        supplierLedgerMaster.ServiceTaxNo = p.ServiceTaxNo;
                        supplierLedgerMaster.PANNo = p.PANNo;
                        supplierLedgerMaster.Status = p.Status;
                        supplierLedgerMaster.ModifiedBy = this.LoggedInUser.Username;
                        supplierLedgerMaster.ModifiedOn = System.DateTime.Now;
                    }

                    ///Add Supplier Company discount data
                    ///
                    var previousMappings = context.SupplierCompanyDiscountRef.Where(x => x.SupplierLedgerID == p.SupplierLedgerId).ToList();
                    context.SupplierCompanyDiscountRef.RemoveRange(previousMappings);

                    foreach (var newEntry in p.SupplierCompanyDiscountList)
                    {
                        context.SupplierCompanyDiscountRef.Add(new Entity.SupplierCompanyDiscountRef()
                        {
                            SupplierLedgerID = p.SupplierLedgerId,
                            CompanyID = newEntry.CompanyID,
                            Normal = newEntry.Normal,
                            Breakage = newEntry.Breakage,
                            Expired = newEntry.Expired
                        });

                        ///All entry for item mappings
                        ///

                        if (newEntry.SupplierItemDiscountMapping != null)
                        {
                            foreach (var newItem in newEntry.SupplierItemDiscountMapping)
                            {
                                context.SupplierCompanyDiscountRef.Add(new Entity.SupplierCompanyDiscountRef()
                                {
                                    SupplierLedgerID = p.SupplierLedgerId,
                                    CompanyID = newEntry.CompanyID,
                                    ItemID = newItem.ItemID,
                                    Normal = newItem.Normal,
                                    Breakage = newItem.Breakage,
                                    Expired = newItem.Expired
                                });
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

        public List<PharmaBusinessObjects.Master.SupplierCompanyDiscount> GetExistigCompanyDiscountMappingBySupplierID(int supplierLedgerID)
        {
            try
            {
                using (PharmaDBEntities context = new PharmaDBEntities())
                {
                    List<PharmaBusinessObjects.Master.SupplierCompanyDiscount> existingDiscountMapping = new List<PharmaBusinessObjects.Master.SupplierCompanyDiscount>();

                    existingDiscountMapping = context.SupplierCompanyDiscountRef.Where(q => q.SupplierLedgerID == supplierLedgerID && q.CompanyMaster.Status && q.ItemID == null)
                                                      .Select(x => new PharmaBusinessObjects.Master.SupplierCompanyDiscount()
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
                        item.SupplierItemDiscountMapping = context.SupplierCompanyDiscountRef.Where(y => y.CompanyID == item.CompanyID && y.ItemID != null)
                                                                                                                        .Select(o => new PharmaBusinessObjects.Master.SupplierCompanyDiscount()
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

        public List<PharmaBusinessObjects.Master.SupplierCompanyDiscount> GetCompleteCompanyDiscountListBySupplierID(int supplierLedgerID)
        {
            try
            {
                using (PharmaDBEntities context = new PharmaDBEntities())
                {
                    List<PharmaBusinessObjects.Master.SupplierCompanyDiscount> mappedDiscount = GetExistigCompanyDiscountMappingBySupplierID(supplierLedgerID);
                    List<PharmaBusinessObjects.Master.SupplierCompanyDiscount> allCompanyDiscountMapping = context.CompanyMaster.Where(q => q.Status)
                                                      .Select(x => new PharmaBusinessObjects.Master.SupplierCompanyDiscount()
                                                      {
                                                          CompanyID = x.CompanyId,
                                                          CompanyName = x.CompanyName

                                                      }).ToList();

                    allCompanyDiscountMapping.RemoveAll(x => mappedDiscount.Any(y => y.CompanyID == x.CompanyID));
                    allCompanyDiscountMapping.AddRange(mappedDiscount);

                    return allCompanyDiscountMapping.OrderBy(x => x.CompanyName).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
    }
}
