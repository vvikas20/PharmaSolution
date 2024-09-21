using PharmaBusinessObjects.Master;
using PharmaDAL.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaBusiness.Master
{
    internal class PersonRouteMasterBiz : BaseBiz
    {
        public PersonRouteMasterBiz(PharmaBusinessObjects.Master.UserMaster loggedInUser) : base(loggedInUser)
        {

        }

        internal List<PharmaBusinessObjects.Master.PersonRouteMaster> GetPersonRoutes()
        {
            return new PersonRouteMasterDao(this.LoggedInUser).GetPersonRoutes();
        }

        internal int AddPersonRoute(PharmaBusinessObjects.Master.PersonRouteMaster p)
        {
            return new PersonRouteMasterDao(this.LoggedInUser).AddPersonRoute(p);
        }
        
        internal int UpdatePersonRoute(PharmaBusinessObjects.Master.PersonRouteMaster p)
        {
            return new PersonRouteMasterDao(this.LoggedInUser).UpdatePersonRoute(p);
        }

        internal List<PharmaBusinessObjects.Master.PersonRouteMaster> GetPersonRoutesByRecordTypeIdAndSearch(int recordTypeID, string searchString = null)
        {
            return new PersonRouteMasterDao(this.LoggedInUser).GetPersonRoutesByRecordTypeIdAndSearch(recordTypeID,searchString);

        }

        internal List<PharmaBusinessObjects.Master.PersonRouteMaster> GetPersonRoutesBySystemName(string systemName)
        {
            var personRouteList = new PersonRouteMasterDao(this.LoggedInUser).GetPersonRoutes().Where(p => p.SystemName == systemName && p.Status).ToList();
            return personRouteList;
        }

        internal PersonRouteMaster GetPersonRouteMasterByCode(string personRouteCode)
        {
            return new PersonRouteMasterDao(this.LoggedInUser).GetPersonRouteMasterByCode(personRouteCode);
        }
        }
}
