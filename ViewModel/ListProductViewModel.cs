using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WPF_Market.Model;
using WPF_Market.View;
namespace WPF_Market.ViewModel
{
    public class ListProductViewModel : BaseViewModel
    {
        private ObservableCollection<Product_ref_Shop> productList = new ObservableCollection<Product_ref_Shop>();
        private IShowProductDetail showProductDetail;
        private Window parentWindow;
        public ListProductViewModel(Window parentWindow)
        {
            GetProductDataFromDataBase();
            this.parentWindow = parentWindow;
            SeeDetailCommand = new BaseViewModelCommand(ExecuteSeeDetailCommand);
          
        }

        public ListProductViewModel()
        {

        }

        public ObservableCollection<Product_ref_Shop> ProductList
        {
            get
            {
                return productList;

            }
            set
            {
                productList = value;
                OnPropertyChanged(nameof(productList)); 
            }
        }
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

                string filePath = @"D:\HK2_23-24_LTwindows\15-3\SanPham\";


                int idSanPham = Convert.ToInt32(reader["Id_sanpham"]);
                int idShop = Convert.ToInt32(reader["Id_shop"].ToString().Trim()); // Se thay doi sau khi co database cua shop

                string subcmd = string.Format("Select * from Shop where ID_shop = '{0}'", idShop);
                SqlCommand subSqlCommand = new SqlCommand(subcmd, SQLConnection.conn);
                SqlDataReader subReader = subSqlCommand.ExecuteReader();
                string shopAddress = "";
                if (subReader.Read())
                {
                   shopAddress = subReader["Address"].ToString();
                }
                

                string nameProduct = "Product's name: " + reader["Ten"].ToString();
                double price = Convert.ToDouble(reader["Gia"]);
                double discount = Convert.ToDouble(reader["Discount"]);
                string domoi = (reader["Domoi"] as string).Trim() + "%";
                string type = reader["Type"] as string;
                double rating = Convert.ToDouble(reader["Rate"]);
                int number = Convert.ToInt32(reader["Number"]);
                int sold = Convert.ToInt32(reader["NumberSold"]);    
                filePath += "/" + reader["Id_sanpham"].ToString().Trim() + "/Images";      
                ObservableCollection<string> imageList = new ObservableCollection<string>();
                string[] link = Directory.GetFiles(filePath);
                foreach (string linkItem in link)
                {
                    imageList.Add(linkItem);
                }
                Product_ref_Shop model = new Product_ref_Shop(idSanPham, idShop, nameProduct, price, discount, domoi, type, rating, number, sold, imageList, shopAddress);
                ProductList.Add(model);
            }
            SQLConnection.conn.Close();
        }
        public ICommand SeeDetailCommand { get; }
        private void ExecuteSeeDetailCommand(object obj)
        {
            showProductDetail = new DisplayDetailProduct(parentWindow);
            showProductDetail.ShowProductDetail((Product_ref_Shop)obj, parentWindow);
        }
    }
    public class DisplayDetailProduct : IShowProductDetail
    {
        private Window parentWindow;
        public DisplayDetailProduct(Window parentWindow)
        {
            //ParentWindow = parentWindow;
        }

        public Window ParentWindow { get => parentWindow; set => parentWindow = value; }

        public void ShowProductDetail(Product_ref_Shop productModel, Window parentWindow)
        {
            detail_product product = new detail_product(productModel);
            product.Owner = parentWindow;
            parentWindow.Hide();
            product.ShowDialog();
            parentWindow.Show();
        }
    }
}
