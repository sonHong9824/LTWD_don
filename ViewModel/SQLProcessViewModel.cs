using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_Market.Model;

namespace WPF_Market.ViewModel
{
    public class SQLProcessViewModel
    {
        public void GetallData(string tablename)
        {
          /*  SQLConnection.conn.Open();
            string cmd = string.Format("Select * from Account where user_name = '{0}'", user_name);
            SqlCommand sqlCommand = new SqlCommand(cmd, SQLConnection.conn);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            object returnData = null;
            if (reader.Read())
            {
                returnData = new Acccount(reader["email"].ToString(), reader["user_name"].ToString(), reader["password"].ToString());
            }*/
        }
    }
}
