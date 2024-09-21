using log4net;
using PharmaBusinessObjects.Common;
using PharmaDAL.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;

namespace PharmaDataMigration.Transaction
{
    public class TRN
    {
        private readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private void InsertData(string voucherTypeCode)
        {
            List<PharmaDAL.Entity.PurchaseSaleBookHeader> listPurchaseSaleBookHeader = new List<PharmaDAL.Entity.PurchaseSaleBookHeader>();

            using (PharmaDBEntities context = new PharmaDBEntities())
            {
                SqlConnection connection = (SqlConnection)context.Database.Connection;
                connection.Open();
                SqlCommand cmd = new SqlCommand("SaveMigrationTRN", connection);
                cmd.CommandTimeout = 0;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@VoucherTypeCode", voucherTypeCode));

                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }


        public void InsertTRNData()
        {
                InsertData(Constants.VoucherTypeCode.DEBITNOTE);
                InsertData(Constants.VoucherTypeCode.PURCHASERETURN);
                InsertData(Constants.VoucherTypeCode.PURCHASEENTRY);
                InsertData(Constants.VoucherTypeCode.CREDITNOTE);
                InsertData(Constants.VoucherTypeCode.BREAKAGEEXPIRY);
                InsertData(Constants.VoucherTypeCode.SALERETURNBREAKAGEEXPIRY);
                InsertData(Constants.VoucherTypeCode.SALERETURN);
                InsertData(Constants.VoucherTypeCode.SALEENTRY);

        }

    }
}
