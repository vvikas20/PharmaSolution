using PharmaDAL.Transaction;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace PharmaBusiness.Transaction
{
    internal class ReportBiz : BaseBiz
    {

        public ReportBiz(PharmaBusinessObjects.Master.UserMaster loggedInUser) : base(loggedInUser)
        {

        }

        internal DataTable GetSaleInvoiceData(long purchaseSaleBookHeaderID)
        {
            return new ReportDao(LoggedInUser).GetSaleInvoiceData(purchaseSaleBookHeaderID);

        }

        internal DataTable GetFirmProperties(int purchaseSaleBookHeaderID)
        {
            return new ReportDao(LoggedInUser).GetFirmProperties(purchaseSaleBookHeaderID);

        }
    }
}
