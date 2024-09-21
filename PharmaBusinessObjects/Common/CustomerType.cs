using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaBusinessObjects.Common
{
    public class CustomerType
    {
        public int CustomerTypeId { get; set; }
        public string CustomerTypeName { get; set; }
        public string CustomerTypeShortName { get; set; }
        public bool Status { get; set; }
    }
}
