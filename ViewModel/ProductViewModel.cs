using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_Market.Model;

namespace WPF_Market.ViewModel
{
    class ProductViewModel
    {
        public ProductViewModel()
        {
            SQLConnection.conn.Open();
            
            string cmd = string.Format("Select * from Kho");
            SqlCommand sqlCommand = new SqlCommand(cmd, SQLConnection.conn);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            ProductModel model;
            int count = 0;
            if (reader.Read())
            {
                //model = new ProductModel(reader["Ten"].ToString(), "D:/" + reader["Id_shop"].ToString()+read);
            }
        }
    }
}
