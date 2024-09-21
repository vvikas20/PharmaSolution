using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaBusinessObjects.Common
{
    public class ExcludedControls
    {
        public string Name { get; set; }
    }

    public static class Exclude
    {
        private static List<ExcludedControls> excludeControlsList;

        public static List<ExcludedControls> GetExcludedControls()
        {
            excludeControlsList = new List<ExcludedControls>();

            excludeControlsList.Add(new ExcludedControls()
            {
                Name = "lblSearch"
            });

            excludeControlsList.Add(new ExcludedControls()
            {
                Name = "txtSearch"
            });

            excludeControlsList.Add(new ExcludedControls()
            {
                Name = "lblPersonRouteType"
            });

            excludeControlsList.Add(new ExcludedControls()
            {
                Name = "lblTotalCash"
            });
            excludeControlsList.Add(new ExcludedControls()
            {
                Name = "lblCashVal"
            });
            excludeControlsList.Add(new ExcludedControls()
            {
                Name = "lblTotalCQ"
            });
            excludeControlsList.Add(new ExcludedControls()
            {
                Name = "lblCQVal"
            });
            excludeControlsList.Add(new ExcludedControls()
            {
                Name = "lblAmtOS"
            });
            excludeControlsList.Add(new ExcludedControls()
            {
                Name = "lblAmtOSVal"
            });
            excludeControlsList.Add(new ExcludedControls()
            {
                Name = "lblAmtAdj"
            });
            excludeControlsList.Add(new ExcludedControls()
            {
                Name = "lblAmtAdjVal"
            });
            excludeControlsList.Add(new ExcludedControls()
            {
                Name = "dtReceiptPayment"
            });

            excludeControlsList.Add(new ExcludedControls()
            {
                Name = "lblTransAccount"
            });

            excludeControlsList.Add(new ExcludedControls()
            {
                Name = "txtTransactAccount"
            });
            



            return excludeControlsList;
        }
    }

}
