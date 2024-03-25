using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Market.Model
{
    public class Acccount
    {
        private int iD;
        private string email;
        private string userName;
        private SecureString password;
        public Acccount()
        {
        }
        public Acccount(int iD, string email, string userName, SecureString password)
        {
            this.iD = iD;
            this.email = email;
            this.userName = userName;
            this.password = password;
        }

        public int ID { get => iD; set => iD = value; }
        public string Email { get => email; set => email = value; }
        public string UserName { get => userName; set => userName = value; }
        public SecureString Password { get => password; set => password = value; }
    }
}
