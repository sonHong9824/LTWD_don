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

            SQLConnection.conn = new SqlConnection(Properties.Settings.Default.TraoDoiMuaBan);
            SQLConnection.conn.Open();
            string cmd = string.Format("Select * from Account where user_name = '{0}'", user_name);
            SqlCommand sqlCommand = new SqlCommand(cmd,SQLConnection.conn);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            if (reader.Read())
            {
                return new Acccount(reader["email"].ToString(),reader["user_name"].ToString(), reader["password"].ToString());
            }
            SQLConnection.conn.Close();
            return null;
        }
    }
}
