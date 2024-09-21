using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace PharmaDAL.Transaction
{
    public class ReportDao : BaseDao
    {
        public ReportDao(PharmaBusinessObjects.Master.UserMaster loggedInUser) : base(loggedInUser)
        {

        }

        public DataTable GetSaleInvoiceData(long purchaseSaleBookHeaderID)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["PharmaDBConn"].ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SaleInvoice", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@PurchaseSaleBookHeaderID", purchaseSaleBookHeaderID.ToString()));

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);

            }

            return dt;

        }

        public DataTable GetFirmProperties(int purchaseSaleBookHeaderID)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["PharmaDBConn"].ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("GetFirmProperties", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@PurchaseSaleBookHeaderID", purchaseSaleBookHeaderID.ToString()));

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);

            }

            return dt;

        }
    }
}
