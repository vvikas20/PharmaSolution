using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaBusinessObjects.Common
{
    public class Enums
    {
        public enum Choice
        {
            No,
            Yes
        };

        public enum Status
        {
            Inactive,
            Active
        };

        public enum DI
        {
            Indirect,
            Direct
        };

        public enum TransType
        {
            C,
            D
        };

        public enum TaxRetail
        {
            T,
            R
        };

        public enum LocalCentral
        {
            L,
            C
        };

        public enum LineItemUpdateMode
        {
            Batch,
            Scheme,
            Discount
        };

        public enum SaleEntryChangeType
        {
            TemporaryChange,
            CompanyWiseChange,
            ItemWiseChange
        };

        public enum ReceiptPaymentState
        {
            Save,
            Cancel
        };
    }
}
