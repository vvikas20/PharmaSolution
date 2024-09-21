using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaBusinessObjects.Common
{
    public class AccountLedgerType
    {
        public int AccountLedgerTypeID { get; set; }
        public string AccountLedgerTypeName { get; set; }
        public string AccountLedgerTypeSystemName { get; set; }
        public bool Status { get; set; }
    }
}
