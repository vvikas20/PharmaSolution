using log4net;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace PharmaDataMigration.DBFWriter
{
    public class DBFFileWriter
    {
        private readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        //private DBFConnectionManager dbConnection;

        public DBFFileWriter()
        {
           // dbConnection = new DBFConnectionManager(Common.DataDirectory);
        }

        public void WriteFile()
        {

            for (int i = 1; i <= 1; i++)
            {                
                DataSetIntoDBF(ReadExcel(i.ToString()));
            }
        }

        private DataTable ReadExcel(string filename)
        {
            try
            {
                // string con = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\PharmaProject\TestDBF\" + filename + ".xlsx;" + @"Extended Properties='Excel 8.0;HDR=Yes;'";

                string con = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\PharmaProject\TestDBF\HSN" + filename + ".xlsx;Extended Properties='Excel 12.0;HDR=YES;IMEX=1;';";

                using (OleDbConnection connection = new OleDbConnection(con))
                {
                    DataTable dt = new DataTable();

                    OleDbDataAdapter oda = new OleDbDataAdapter("select * from [HSNCode$]", con);
                    oda.Fill(dt);

                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        ArrayList list = new ArrayList();

        public void DataSetIntoDBF(DataTable dataSet)
        {          

            string fileName = "HSN";
            string createSql = "";

            if (!File.Exists(@"D:\PharmaProject\TestDBF\HSN.dbf"))
            {
                createSql = "create table " + fileName + " (";

                foreach (DataColumn dc in dataSet.Columns)
                {
                    string fieldName = dc.ColumnName;

                    string type = dc.DataType.ToString();

                    switch (type)
                    {
                        case "System.String":
                            type = "varchar(100)";
                            break;

                        case "System.Boolean":
                            type = "varchar(10)";
                            break;

                        case "System.Int32":
                            type = "varchar(10)";
                            break;

                        case "System.Double":
                            type = "varchar(10)";
                            break;

                        case "System.DateTime":
                            type = "TimeStamp";
                            break;
                    }

                    createSql = createSql + "[" + fieldName + "]" + " " + type + ",";

                    list.Add(fieldName);
                }

                createSql = createSql.Substring(0, createSql.Length - 1) + ")";
            }

            using (OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; " + " Data Source=" + Common.DataDirectory + "; " + "Extended Properties=dBase IV"))
            {
                OleDbCommand cmd = new OleDbCommand();

                cmd.Connection = con;

                con.Open();

                if (!string.IsNullOrEmpty(createSql))
                {
                    cmd.CommandText = createSql;

                    cmd.ExecuteNonQuery();
                }

                foreach (DataRow row in dataSet.Rows)
                {
                    string insertSql = "insert into " + fileName + " values(";

                    for (int i = 0; i < list.Count; i++)
                    {
                        insertSql = insertSql + "'" + ReplaceEscape(row[list[i].ToString()].ToString()) + "',";
                    }

                    insertSql = insertSql.Substring(0, insertSql.Length - 1) + ")";

                    cmd.CommandText = insertSql;

                    cmd.ExecuteNonQuery();
                }

                
            }
        }

        public string ReplaceEscape(string str)
        {
            str = str.Replace("'", "''");
            return str;
        }

    }
}
