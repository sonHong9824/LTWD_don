using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Market.Model
{
    public class Acccount

    {
        string email;
        string user_name;
        string password;

        public Acccount()
        {
        }

        public Acccount(string email, string user_name, string password)
        {
            this.Email = email;
            this.User_name = user_name;
            this.Password = password;
        }

        public string Email { get => email; set => email = value; }
        public string User_name { get => user_name; set => user_name = value; }
        public string Password { get => password; set => password = value; }
    }
}
