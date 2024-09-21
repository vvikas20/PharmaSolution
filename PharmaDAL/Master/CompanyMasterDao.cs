using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PharmaDAL.Entity;
using static PharmaBusinessObjects.Common.Enums;
using PharmaBusinessObjects.Common;

namespace PharmaDAL.Master
{
    public class CompanyMasterDao : BaseDao
    {
        public CompanyMasterDao(PharmaBusinessObjects.Master.UserMaster loggedInUser) : base(loggedInUser)
        {

        }

        public List<PharmaBusinessObjects.Master.CompanyMaster> GetCompanies(string searchText)
        {
            using (PharmaDBEntities context = new PharmaDBEntities())
            {
                List<PharmaBusinessObjects.Master.CompanyMaster> companyList = context.CompanyMaster.Where(p => (string.IsNullOrEmpty(searchText) || p.CompanyName.Contains(searchText))).Select(p => new PharmaBusinessObjects.Master.CompanyMaster()
                                            {
                                                CompanyId = p.CompanyId,
                                                CompanyName = p.CompanyName,
                                                OrderPreferenceRating = p.OrderPreferenceRating,
                                                BillingPreferenceRating = p.BillingPreferenceRating,
                                                CompanyCode = p.CompanyCode,                                               
                                                IsDirect = p.IsDirect,
                                                StockSummaryRequired = p.StockSummaryRequired,
                                                Status = p.Status,
                                                StatusText = p.Status ? string.Empty : Constants.Others.Inactive

                }).ToList();

                companyList.ForEach(p => {
                    p.DirectIndirect = p.IsDirect ? Enum.GetName(typeof(DI), 1) : Enum.GetName(typeof(DI), 0);
                    p.StockSummaryRequirement = p.StockSummaryRequired ? Enum.GetName(typeof(Choice), 1) : Enum.GetName(typeof(Choice), 0);
                });

                return companyList;
            }
        }

        public PharmaBusinessObjects.Master.CompanyMaster GetCompanyById(int companyId)
        {
            using (PharmaDBEntities context = new PharmaDBEntities())
            {
                return context.CompanyMaster.Where(p => p.CompanyId == companyId).Select(p => new PharmaBusinessObjects.Master.CompanyMaster()
                {
                    CompanyId = p.CompanyId,
                    CompanyName = p.CompanyName,
                    OrderPreferenceRating = p.OrderPreferenceRating,
                    BillingPreferenceRating = p.BillingPreferenceRating,
                    CompanyCode = p.CompanyCode,
                    Status = p.Status,
                    IsDirect = p.IsDirect,
                    StockSummaryRequired = p.StockSummaryRequired,
                    StatusText = p.Status ? string.Empty : Constants.Others.Inactive
                }).FirstOrDefault();
            }
        }

        public int AddCompany(PharmaBusinessObjects.Master.CompanyMaster company)
        {
            using (PharmaDBEntities context = new PharmaDBEntities())
            {
                List<string> companyCodeList = context.CompanyMaster.Select(p => p.CompanyCode).ToList();
                    
                int maxCompanyCode = companyCodeList.Count > 0 ? companyCodeList.Max(p=>Convert.ToInt32(p)) + 1 : 1;

                var companyCode = maxCompanyCode.ToString().PadLeft(6, '0');

                Entity.CompanyMaster table = new Entity.CompanyMaster()
                {
                    CompanyCode = companyCode,
                    Status = company.Status,
                    StockSummaryRequired = company.StockSummaryRequired,
                    IsDirect = company.IsDirect,
                    OrderPreferenceRating = company.OrderPreferenceRating,
                    BillingPreferenceRating = company.BillingPreferenceRating,
                    CompanyName = company.CompanyName,
                    CreatedBy = this.LoggedInUser.Username,
                    CreatedOn = System.DateTime.Now
                };

                context.CompanyMaster.Add(table);

                if (context.SaveChanges() > 0)
                    return table.CompanyId;
                else
                    return 0;
            }
        }

        public int UpdateCompany(PharmaBusinessObjects.Master.CompanyMaster company)
        {
            using (PharmaDBEntities context = new PharmaDBEntities())
            {
                var companyMaster = context.CompanyMaster.FirstOrDefault(p=>p.CompanyId == company.CompanyId);

                if (companyMaster != null)
                {
                    companyMaster.Status = company.Status;
                    companyMaster.StockSummaryRequired = company.StockSummaryRequired;
                    companyMaster.IsDirect = company.IsDirect;
                    companyMaster.OrderPreferenceRating = company.OrderPreferenceRating;
                    companyMaster.BillingPreferenceRating = company.BillingPreferenceRating;
                    companyMaster.CompanyName = company.CompanyName;
                    companyMaster.ModifiedBy = this.LoggedInUser.Username;
                    companyMaster.ModifiedOn = System.DateTime.Now;
                }

                return context.SaveChanges();
            }
        }

        public int DeleteCompany(int companyId)
        {
            using (PharmaDBEntities context = new PharmaDBEntities())
            {
                var companyMaster = context.CompanyMaster.FirstOrDefault(p => p.CompanyId == companyId);

                if (companyMaster != null)
                {
                    companyMaster.Status = false;
                    companyMaster.ModifiedBy = this.LoggedInUser.Username;
                    companyMaster.ModifiedOn = System.DateTime.Now;
                }

                return context.SaveChanges();
            }
        }
    }


}
