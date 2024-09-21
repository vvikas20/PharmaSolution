using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PharmaDAL
{
    internal static class CommonDaoMethods
    {
        internal static DataTable CreateDataTable<T>(IEnumerable<T> list)
        {
            Type type = typeof(T);
            var properties = type.GetProperties();
            properties = properties.Where(p => p.Name != "OldPurchaseSaleRate").ToArray();

            DataTable dataTable = new DataTable();

            foreach (PropertyInfo info in properties)
            {
                dataTable.Columns.Add(new DataColumn(info.Name, Nullable.GetUnderlyingType(info.PropertyType) ?? info.PropertyType));
            }


            foreach (T entity in list)
            {
                object[] values = new object[properties.Length];

                for (int i = 0; i < properties.Length; i++)
                {
                    values[i] = properties[i].GetValue(entity,null);
                }

                dataTable.Rows.Add(values);
            }

            return dataTable;
        }
    }
}
