using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaBusinessObjects.Master
{
    public class UserMaster : BaseBusinessObjects
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool Status { get; set; }
       public bool IsSystemAdmin { get; set; }
        public int RoleID { get; set; }
        public string RoleName { get; set; }
        public List<Privledge> Privledges { get; set; }
    }
}
