using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WPF_Market.Model;

namespace WPF_Market.ViewModel
{
    public static class Account_DAO
    {
        public static Acccount Return_account(string user_name, string password)
        {
            if (string.IsNullOrEmpty(user_name) || string.IsNullOrEmpty(password)) { return null; }
            SQLConnection.conn.Open();
            string cmd = string.Format("Select * from Account where user_name = '{0}' and password = '{1}'", user_name,password);
            SqlCommand sqlCommand = new SqlCommand(cmd,SQLConnection.conn);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            Acccount account = null;
            if (reader.Read())
            {
                account = new Acccount(reader["email"].ToString(),reader["user_name"].ToString(), reader["password"].ToString());
            }
            SQLConnection.conn.Close();
            return account;
        }
    }
}
