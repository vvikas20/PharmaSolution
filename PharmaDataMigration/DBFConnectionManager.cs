using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace PharmaDataMigration
{
    public class DBFConnectionManager
    {
        public OleDbConnection dbConnection { get; set; }
        private string dataDirectory { get; set; }

        public DBFConnectionManager(string _dataDirectory)
        {
            dataDirectory = _dataDirectory; //F:\PHARMA\DATA\
            CreateOleDBConnection();
        }

        ~DBFConnectionManager()
        {
            CloseOleDBConnection();
        }

        private void CreateOleDBConnection()
        {
            dbConnection = new OleDbConnection(@"Provider=VFPOLEDB.1;Data Source=" + dataDirectory);
            // Open the connection, and if open successfully, you can try to query it
            dbConnection.Open();
        }

        private void CloseOleDBConnection()
        {
           // dbConnection.Close();
        }

        public DataTable GetData(string query)
        {
            try
            {

                DataTable dtResult = new DataTable();

                if (dbConnection.State == ConnectionState.Open)
                {
                    OleDbCommand cmd = new OleDbCommand(query, dbConnection);
                    OleDbDataAdapter DA = new OleDbDataAdapter(cmd);

                    DA.Fill(dtResult);
                }

                return dtResult;
            }            
            finally
            {
                CloseOleDBConnection();
            }
        }
    }
}
