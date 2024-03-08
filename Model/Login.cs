using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Market.Model
{
    internal class Login
    {
        int ID;
        string user_name;
        string password;

        public Login()
        {
        }

        public Login(int iD, string user_name, string password)
        {
            ID1 = iD;
            this.User_name = user_name;
            this.Password = password;
        }

        public int ID1 { get => ID; set => ID = value; }
        public string User_name { get => user_name; set => user_name = value; }
        public string Password { get => password; set => password = value; }
    }
}
