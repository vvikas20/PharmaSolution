using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaBusinessObjects.Master
{
    public class CustomerCopanyDiscount : CompanyItemDiscountBase
    {
        public int CustCompDiscountRefID { get; set; }
        public int CustomerLedgerID { get; set; }
     
        public List<CustomerCopanyDiscount> CustomerItemDiscountMapping { get; set; }
    }
}
