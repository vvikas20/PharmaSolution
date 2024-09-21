using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaBusinessObjects.Master
{
    public class Role : BaseBusinessObjects
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public bool Status { get; set; }
        public string Privledges { get; set; }
        public List<Privledge> PrivledgeList { get; set; }
    }

    public class Privledge : BaseBusinessObjects
    {
        public int PrivledgeId { get; set; }
        public string PrivledgeName { get; set; }
        public string ControlName { get; set; }
        public bool Status { get; set; }
    }
}
