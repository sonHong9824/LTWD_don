using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Reflection;
using System.Windows.Documents;
using System.Security;
namespace WPF_Market.ViewModel
{
    public static  class DataBaseProcess
    {
        public static SqlConnection connectionString = new SqlConnection(Properties.Settings.Default.TraoDoiMuaBan);
        /// <summary>
        /// Tra ve mot tat ca cac row trong datatable
        /// </summary>
        /// <param name="dbName"></param>
        /// <returns></returns>
        public static DataTable GetDataTable(string dbName)
        {
            connectionString.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("Select * from " + dbName,connectionString);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            connectionString.Close();
            return dataTable;
        }
        // Update gia tri cua Object dua tren properties
        public static void SetItemFromRow<T>(T item, DataRow row)
            where T : new()
        {
            // go through each column
            foreach (DataColumn c in row.Table.Columns)
            {
                // find the property for the column
                PropertyInfo p = item.GetType().GetProperty(c.ColumnName);
                if (p != null && p.PropertyType == typeof(System.Security.SecureString) && row[c] != DBNull.Value)
                {
                    // Convert the value from string to SecureString
                    string valueFromRow = row[c].ToString();
                    SecureString secureValue = SecureStringProcess.ConvertToSecureString(valueFromRow);

                    // Set the SecureString value to the property
                    p.SetValue(item, secureValue, null);
                }
                // if exists, set the value
                else if (p != null && row[c] != DBNull.Value)
                {
                    p.SetValue(item, row[c], null);
                }
            }
        }
        // function that creates an object from the given data row
        public static T CreateItemFromRow<T>(DataRow row)
            where T : new()
        {
            // create a new object
            T item = new T();

            // set the item
            SetItemFromRow(item, row);

            // return 
            return item;
        }
        // Tao mot list object tu datatable
        public static List<T> CreateListFromTable<T>(DataTable tbl)
            where T : new()
        {
            // define return list
            List<T> lst = new List<T>();

            // go through each row
            foreach (DataRow r in tbl.Rows)
            {
                // add to the list
                lst.Add(CreateItemFromRow<T>(r));
            }

            // return the list
            return lst;
        }
        public static void UpdateDataBase(string dbName, DataTable dataTable)
        {
            connectionString.Open();
            SqlDataAdapter dataAdapter = new SqlDataAdapter("Select * from" + dbName,connectionString);
            SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(dataAdapter);
            dataAdapter.Update(dataTable);
            connectionString.Close();
        }

    }
}
