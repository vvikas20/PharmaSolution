using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PharmaDataMigration
{
    public static class CommonMethods
    {

        public static int? SafeConversionInt(string inputVal)
        {
            int outputVal;

            if (!int.TryParse(inputVal, out outputVal))
            {
                return null;
            }
            else
            {
                return outputVal;
            }
        }

        public static double? SafeConversionDouble(string inputVal)
        {
            double outputVal;
            if (!double.TryParse(inputVal, out outputVal))
            {
                return null;
            }
            else
            {
                return outputVal;
            }
        }

        public static decimal? SafeConversionDecimal(string inputVal)
        {
            decimal outputVal;
            if (!decimal.TryParse(inputVal, out outputVal))
            {
                return null;
            }
            else
            {
                return outputVal;
            }
        }

        public static DateTime ? SafeConversionDatetime(string inputVal)
        {
            DateTime outputVal;
            if (!DateTime.TryParse(inputVal, out outputVal))
            {
                return null;
            }
            else
            {
                return outputVal;
            }
        }
    }
}
