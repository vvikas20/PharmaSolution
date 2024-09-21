using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaBusinessObjects.Master
{
    public class CompanyItemDiscountBase:BaseBusinessObjects
    {
        public string CompanyName { get; set; }
        public int CompanyID { get; set; }
        public string ItemName { get; set; }
        public int? ItemID { get; set; }
        public decimal? Normal { get; set; }
        public decimal? Breakage { get; set; }
        public decimal? Expired { get; set; }
    }
}
