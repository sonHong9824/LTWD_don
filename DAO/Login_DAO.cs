using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Market.DAO
{
    public static class Login_DAO
    {
        public static bool check_valid_input(string user_name, string password)
        {
            if (string.IsNullOrEmpty(user_name) || string.IsNullOrEmpty(password)) {  return false; }
            return true;
        }
    }
}
