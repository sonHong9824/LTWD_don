using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPF_Market.Model;
namespace WPF_Market.ViewModel.ProductViewModel
{
    public class ListProductViewModel
    {
        private ObservableCollection<ProductModel> productList = new ObservableCollection<ProductModel>();
        public ListProductViewModel()
        {
            GetProductDataFromDataBase();   
        }

        public ObservableCollection<ProductModel> ProductList { get => productList; set => productList = value; }

        private void GetProductDataFromDataBase()
        {
            SQLConnection.conn.Open();
            string cmd = string.Format("Select * from Kho");
            SqlCommand sqlCommand = new SqlCommand(cmd, SQLConnection.conn);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            int count = 0;
            while (reader.Read())
            {

                count++;
                if (count == 11)
                    break;
                string filePath = @"C:\Users\LAPTOP\OneDrive\Desktop\LTWD\SanPham";

                int idSanPham = Convert.ToInt32(reader["Id_sanpham"]);
                int idShop = 1; // Se thay doi sau khi co database cua shop
                string nameProduct = "Product's name: " + reader["Ten"].ToString();
                double price = Convert.ToDouble(reader["Gia"]);
                double discount = Convert.ToDouble(reader["Discount"]);
                string domoi = (reader["Domoi"] as string).Trim() + "%";
                string type = reader["Type"] as string;
                double rating = Convert.ToDouble(reader["Rate"]);
                int number = Convert.ToInt32(reader["Number"]);
                int sold = Convert.ToInt32(reader["NumberSold"]);

                string linkImage = filePath + "/" + idSanPham.ToString().Trim() + "/Images/";
                filePath += "/" + reader["Id_sanpham"].ToString().Trim() + "/Images.txt";
                StreamReader stream = new StreamReader(filePath);
                ObservableCollection<string> imageList = new ObservableCollection<string>();
                while (!stream.EndOfStream)
                {
                    var temp = linkImage + stream.ReadLine().Trim();

                    imageList.Add(temp);

                }
                stream.Close();
                ProductModel model = new ProductModel(idSanPham, idShop, nameProduct, price, discount, domoi, type, rating, number, sold, imageList);
                ProductList.Add(model);
            }
            SQLConnection.conn.Close();
        }
    }
}
