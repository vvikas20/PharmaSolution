using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaBusinessObjects.Common
{
    public class AccountType
    {
        public int AccountTypeID { get; set; }
        public string AccountTypeName { get; set; }
        public string AccountTypeShortName { get; set; }
        public bool Status { get; set; }
        
        public string AccountTypeDisplayName { get; set; }
    }
}
