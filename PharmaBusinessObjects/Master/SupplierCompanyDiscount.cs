using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaBusinessObjects.Master
{
    public class SupplierCompanyDiscount : CompanyItemDiscountBase
    {
        public int SupplierCompDiscountRefID { get; set; }
        public int SupplierLedgerID { get; set; }
       
        public List<SupplierCompanyDiscount> SupplierItemDiscountMapping { get; set; }
    }
}
