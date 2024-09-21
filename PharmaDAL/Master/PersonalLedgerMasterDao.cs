using PharmaBusinessObjects.Common;
using PharmaDAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaDAL.Master
{
    public class PersonalLedgerMasterDao : BaseDao
    {
        public PersonalLedgerMasterDao(PharmaBusinessObjects.Master.UserMaster loggedInUser) : base(loggedInUser)
        {

        }

        public List<PharmaBusinessObjects.Master.PersonalLedgerMaster> GetPersonalLedgers(string searchString = "")
        {
            using (PharmaDBEntities context = new PharmaDBEntities())
            {
                return context.PersonalLedger.Where(p=>p.Status
                  && (string.IsNullOrEmpty(searchString) || p.PersonalLedgerName.Contains(searchString))
                ).Select(p => new PharmaBusinessObjects.Master.PersonalLedgerMaster()
                {
                    PersonalLedgerId = p.PersonalLedgerId,
                    PersonalLedgerCode = p.PersonalLedgerCode,
                    PersonalLedgerName = p.PersonalLedgerName,
                    PersonalLedgerShortName = p.PersonalLedgerShortName,
                    Address = p.Address,
                    ContactPerson = p.ContactPerson,
                    Mobile = p.Mobile,
                    //Pager = p.Pager,
                    //Fax = p.Fax,
                    OfficePhone = p.OfficePhone,
                    ResidentPhone = p.ResidentPhone,
                    EmailAddress=p.EmailAddress,
                    Status= p.Status ,
                    StatusText = p.Status ? string.Empty : Constants.Others.Inactive

                }).ToList();
            }

        }

        public int AddPersonalLedger(PharmaBusinessObjects.Master.PersonalLedgerMaster p)
        {
            using (PharmaDBEntities context = new PharmaDBEntities())
            {
                var maxAccountLedgerID = context.PersonalLedger.Count() > 0 ? context.PersonalLedger.Max(q => q.PersonalLedgerId) + 1 : 1;

                var personaltLedgerCode = "P" + maxAccountLedgerID.ToString().PadLeft(6, '0');

                PersonalLedger table = new PersonalLedger()
                {                   
                    PersonalLedgerCode = personaltLedgerCode,
                    PersonalLedgerName = p.PersonalLedgerName,
                    PersonalLedgerShortName = p.PersonalLedgerShortName,
                    Address = p.Address,
                    ContactPerson = p.ContactPerson,
                    Mobile = p.Mobile,
                    //Pager = p.Pager,
                    //Fax = p.Fax,
                    OfficePhone = p.OfficePhone,
                    ResidentPhone = p.ResidentPhone,
                    EmailAddress = p.EmailAddress,
                    Status = p.Status,
                    CreatedBy = this.LoggedInUser.Username,
                    CreatedOn = System.DateTime.Now
                };                

                context.PersonalLedger.Add(table);
                return context.SaveChanges();
            }
        }

        public int UpdatePersonalLedger(PharmaBusinessObjects.Master.PersonalLedgerMaster p)
        {
            using (PharmaDBEntities context = new PharmaDBEntities())
            {
                try
                {
                    var personlLedgerMaster = context.PersonalLedger.Where(q => q.PersonalLedgerId == p.PersonalLedgerId).FirstOrDefault();

                    if (personlLedgerMaster != null)
                    {
                        
                        personlLedgerMaster.PersonalLedgerName = p.PersonalLedgerName;
                        personlLedgerMaster.PersonalLedgerShortName = p.PersonalLedgerShortName;
                        personlLedgerMaster.Address = p.Address;
                        personlLedgerMaster.ContactPerson = p.ContactPerson;
                        personlLedgerMaster.Mobile = p.Mobile;
                        //personlLedgerMaster.Pager = p.Pager;
                        //personlLedgerMaster.Fax = p.Fax;
                        personlLedgerMaster.OfficePhone = p.OfficePhone;
                        personlLedgerMaster.ResidentPhone = p.ResidentPhone;
                        personlLedgerMaster.EmailAddress = p.EmailAddress;
                        personlLedgerMaster.Status = p.Status;
                        personlLedgerMaster.ModifiedBy = this.LoggedInUser.Username;
                        personlLedgerMaster.ModifiedOn = System.DateTime.Now;
                    }

                    return context.SaveChanges();
                }
                catch (System.Data.Entity.Validation.DbEntityValidationException ex)
                {
                    throw ex;
                }
            }

        }

        public int DeletePersonalLedger(PharmaBusinessObjects.Master.PersonalLedgerMaster p)
        {
            using (PharmaDBEntities context = new PharmaDBEntities())
            {
                var personalLedgerMaster = context.PersonalLedger.FirstOrDefault(q => q.PersonalLedgerCode == p.PersonalLedgerCode);

                if (personalLedgerMaster != null)
                {
                    personalLedgerMaster.Status = false;
                    personalLedgerMaster.ModifiedBy = this.LoggedInUser.Username;
                    personalLedgerMaster.ModifiedOn = System.DateTime.Now;
                }

                return context.SaveChanges();
            }
        }
    }
}
