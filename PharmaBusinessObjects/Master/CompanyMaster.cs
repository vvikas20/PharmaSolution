using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaBusinessObjects.Master
{
    public class CompanyMaster : BaseBusinessObjects
    {
        public int CompanyId { get; set; }
        public string CompanyCode { get; set; }
        public string CompanyName { get; set; }
        public bool Status { get; set; }
        public bool IsDirect { get; set; }
        public int OrderPreferenceRating { get; set; }
        public int BillingPreferenceRating { get; set; }
        public bool StockSummaryRequired { get; set; }
        public string DirectIndirect { get; set; }
        public string StockSummaryRequirement { get; set; }
        public string StatusText { get; set; }       
    }
}
