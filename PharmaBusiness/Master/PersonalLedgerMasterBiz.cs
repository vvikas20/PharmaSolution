using PharmaDAL.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaBusiness.Master
{
    internal class PersonalLedgerMasterBiz : BaseBiz
    {
        public PersonalLedgerMasterBiz(PharmaBusinessObjects.Master.UserMaster loggedInUser) : base(loggedInUser)
        {

        }
    
        internal List<PharmaBusinessObjects.Master.PersonalLedgerMaster> GetPersonalLedgers(string searchString)
        {
            return new PersonalLedgerMasterDao(this.LoggedInUser).GetPersonalLedgers(searchString);
        }

        internal int AddPersonalLedger(PharmaBusinessObjects.Master.PersonalLedgerMaster p)
        {
            return new PersonalLedgerMasterDao(this.LoggedInUser).AddPersonalLedger(p);
        }

        internal int UpdatePersonalLedger(PharmaBusinessObjects.Master.PersonalLedgerMaster p)
        {
            return new PersonalLedgerMasterDao(this.LoggedInUser).UpdatePersonalLedger(p);
        }

        internal int DeletePersonalLedger(PharmaBusinessObjects.Master.PersonalLedgerMaster p)
        {
            return new PersonalLedgerMasterDao(this.LoggedInUser).DeletePersonalLedger(p);
        }

        
    }
}
