using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaBusiness
{
    internal abstract class BaseBiz
    {
        public BaseBiz(PharmaBusinessObjects.Master.UserMaster loggedInUser)
        {
            this.LoggedInUser = loggedInUser;
        }

        public PharmaBusinessObjects.Master.UserMaster LoggedInUser { get; set; }
    }
}
