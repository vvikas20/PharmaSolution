using PharmaBusinessObjects.Common;
using PharmaDAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaDAL.Master
{
    public class PersonRouteMasterDao : BaseDao
    {
        public PersonRouteMasterDao(PharmaBusinessObjects.Master.UserMaster loggedInUser) : base(loggedInUser)
        {

        }
        public List<PharmaBusinessObjects.Master.PersonRouteMaster> GetPersonRoutes()
        {
            using (PharmaDBEntities context = new PharmaDBEntities())
            {
                return context.PersonRouteMaster.Select(p => new PharmaBusinessObjects.Master.PersonRouteMaster()
                {
                    PersonRouteID = p.PersonRouteID,
                    PersonRouteCode = p.PersonRouteCode,
                    PersonRouteName = p.PersonRouteName,
                    RecordTypeId = p.RecordTypeId,
                    RecordTypeNme = p.RecordType.RecordType1,
                    Status = p.Status,
                    SystemName = p.RecordType.SystemName,
                    StatusText = p.Status ? string.Empty : Constants.Others.Inactive
                }).ToList();
            }
        }

        public int AddPersonRoute(PharmaBusinessObjects.Master.PersonRouteMaster p)
        {
            using (PharmaDBEntities context = new PharmaDBEntities())
            {
                try
                {
                    var maxPersonRouteMasterID = context.PersonRouteMaster.Where(q => q.RecordTypeId == p.RecordTypeId).Count() + 1;

                    var systemName = context.RecordType.Where(q => q.RecordTypeId == p.RecordTypeId).FirstOrDefault().SystemName;

                    var personRouteCode = systemName + maxPersonRouteMasterID.ToString().PadLeft(3, '0');

                    Entity.PersonRouteMaster table = new Entity.PersonRouteMaster()
                    {
                        PersonRouteID = p.PersonRouteID,
                        PersonRouteCode = personRouteCode,
                        PersonRouteName = p.PersonRouteName,
                        RecordTypeId = p.RecordTypeId,
                        CreatedBy = this.LoggedInUser.LastName,
                        CreatedOn = System.DateTime.Now,
                        Status = p.Status
                    };

                    context.PersonRouteMaster.Add(table);

                    if (context.SaveChanges() > 0)
                        return table.PersonRouteID;
                    else
                        return 0;

                }
                catch (System.Data.Entity.Validation.DbEntityValidationException ex)
                {
                    throw ex;
                }
            }
        }

        public int UpdatePersonRoute(PharmaBusinessObjects.Master.PersonRouteMaster p)
        {
            using (PharmaDBEntities context = new PharmaDBEntities())
            {
                try
                {
                    var personRouteMaster = context.PersonRouteMaster.Where(q => q.PersonRouteID == p.PersonRouteID).FirstOrDefault();

                    if (personRouteMaster != null)
                    {
                        //personRouteMaster.PersonRouteCode = p.PersonRouteCode;
                        personRouteMaster.PersonRouteName = p.PersonRouteName;
                        personRouteMaster.ModifiedBy = this.LoggedInUser.Username;
                        personRouteMaster.ModifiedOn = System.DateTime.Now;
                        personRouteMaster.Status = p.Status;
                    }

                    if (context.SaveChanges() > 0)
                        return personRouteMaster.PersonRouteID;
                    else
                        return 0;
                }
                catch (System.Data.Entity.Validation.DbEntityValidationException ex)
                {
                    throw ex;
                }
            }

        }

        public List<PharmaBusinessObjects.Master.PersonRouteMaster> GetPersonRoutesByRecordTypeIdAndSearch(int recordTypeID, string searchString = null)
        {
            using (PharmaDBEntities context = new PharmaDBEntities())
            {
                var personRoutes = (from p in context.PersonRouteMaster
                                    where (recordTypeID == 0 || p.RecordTypeId == recordTypeID)
                                    && (string.IsNullOrEmpty(searchString) || p.PersonRouteName.Contains(searchString))
                                    select new PharmaBusinessObjects.Master.PersonRouteMaster()
                                    {
                                        PersonRouteID = p.PersonRouteID,
                                        PersonRouteCode = p.PersonRouteCode,
                                        PersonRouteName = p.PersonRouteName,
                                        RecordTypeId = p.RecordTypeId,
                                        RecordTypeNme = p.RecordType.RecordType1,
                                        Status = p.Status,
                                        SystemName = p.RecordType.SystemName,
                                        StatusText = p.Status ? string.Empty : Constants.Others.Inactive
                                    }).ToList();

                return personRoutes;

            }

        }

        public PharmaBusinessObjects.Master.PersonRouteMaster GetPersonRouteMasterByCode(string personRouteCode)
        {
            using (PharmaDBEntities context = new PharmaDBEntities())
            {
                return context.PersonRouteMaster.Where(p => p.PersonRouteCode == personRouteCode)
                    .Select(p=>new PharmaBusinessObjects.Master.PersonRouteMaster() {
                        PersonRouteCode = p.PersonRouteCode,
                        PersonRouteName=p.PersonRouteName,
                        PersonRouteID = p.PersonRouteID,
                    }).FirstOrDefault();
            }
        }

    }
}
