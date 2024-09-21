using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaDAL
{
    public abstract class BaseDao
    {
        public BaseDao(PharmaBusinessObjects.Master.UserMaster loggedInUser)
        {
            this.LoggedInUser = loggedInUser;

        }

        public PharmaBusinessObjects.Master.UserMaster LoggedInUser { get; set; }
    }
}
