using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WPF_Market
{
    public static class SQLConnection
    {
        public static SqlConnection conn = new SqlConnection(Properties.Settings.Default.TraoDoiMuban);
    }
}
