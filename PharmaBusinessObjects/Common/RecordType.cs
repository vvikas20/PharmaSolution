using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaBusinessObjects.Common
{
    public class RecordType
    {
        public int RecordTypeId { get; set; }
        public string RecordTypeName { get; set; }
        public string SystemName { get; set; }
        public bool Status { get; set; }
    }
}
