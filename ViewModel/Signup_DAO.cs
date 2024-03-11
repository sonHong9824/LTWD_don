using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_Market.Model;
namespace WPF_Market.ViewModel
{
    public static class Signup_DAO
    {
        public static Acccount Check_input(string txt_user_name, string txt_email, string txt_password, string txt_repeat_password)
        {
            if (!txt_email.Contains("@gmail.com") || txt_user_name==null || txt_password == null || txt_repeat_password == null || txt_repeat_password!=txt_password)
                return null;
            SQLConnection.conn.Open();
            string cmd = string.Format("Select * from Account where user_name = '{0}'",txt_user_name);
            SqlCommand sqlcmd = new SqlCommand(cmd,SQLConnection.conn);
            SqlDataReader reader = sqlcmd.ExecuteReader();

            while (reader.Read())
            {
                if (reader.IsDBNull(0))
                {
                    break;
                }
                Acccount acccount = new Acccount(reader["email"].ToString(), reader["user_name"].ToString(), reader["password"].ToString());
                if (acccount.User_name == txt_user_name)
                {
                    SQLConnection.conn.Close();
                    return null;
                }
            }
            SQLConnection.conn.Close();
            return new Acccount(txt_email, txt_user_name, txt_password);

        }
        public static bool Add_account(string txt_user_name, string txt_email, string txt_password, string txt_repeat_password)
        {
            Acccount acccount = Check_input(txt_user_name, txt_email, txt_password, txt_repeat_password);
            if (acccount==null)
                return false;

            SQLConnection.conn.Open();
            string cmnd = string.Format("Insert into Account(email, user_name, password) values ('{0}', '{1}','{2}')",txt_email,txt_user_name,txt_password);
            SqlCommand sqlCommand = new SqlCommand (cmnd,SQLConnection.conn);
            if (sqlCommand.ExecuteNonQuery()>0) 
            {
                SQLConnection.conn.Close();
                return true;
            }
            SQLConnection.conn.Close();
            return false;
        }
    }
}
