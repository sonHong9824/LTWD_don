using Microsoft.EntityFrameworkCore;
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
using System.Windows.Media;
using WPF_Market.Models;
using WPF_Market.Models.Model;
using WPF_Market.View;
namespace WPF_Market.ViewModel
{
    public class ListProductViewModel : BaseViewModel
    {
        private ObservableCollection<Product_ref_Shop> productList = new ObservableCollection<Product_ref_Shop>();
        private IShowProductDetail showProductDetail;
        private string address;
        public ListProductViewModel()
        {
            GetProductDataFromDataBase();
            SeeDetailCommand = new BaseViewModelCommand(ExecuteSeeDetailCommand);
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
           /* SQLConnection.conn.Open();
            string cmd = string.Format("Select * from Kho");
            SqlCommand sqlCommand = new SqlCommand(cmd, SQLConnection.conn);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                string filePath = @"D:\LTWD\LTWD_FinalProject\SanPham\";
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
            SQLConnection.conn.Close();*/
           foreach (var item in CurrentApplicationStatus.ProductList)
            {
                var shop = DataProvider.Instance.DB.Shops.Where(p=>p.IdShop == item.IdShop).FirstOrDefault();
                if (shop != null)
                {
                    string filePath = @"D:\LTWD\LTWD_FinalProject\SanPham\" + item.IdSanpham.ToString()+ "/Images";
                    ObservableCollection<string> imageList = new ObservableCollection<string>();
                    string[] link = Directory.GetFiles(filePath);
                    foreach (string linkItem in link)
                    {
                        imageList.Add(linkItem);
                    }
                    ProductList.Add(new Product_ref_Shop(item.IdSanpham, item.IdShop, item.Ten,item.Gia, item.Discount, item.DoMoi, item.Type
                        , item.Rate, item.Number, item.NumberSold, item.IdShopNavigation, shop.Address, imageList, imageList[0]));
                }
            }
        }
        public ICommand SeeDetailCommand { get; }
        public string Address { get => address; set { address = value; OnPropertyChanged(nameof(Address)); } }

        private void ExecuteSeeDetailCommand(object obj)
        {
            showProductDetail = new DisplayDetailProduct();
            showProductDetail.ShowProductDetail((Product_ref_Shop)obj);
        }
    }
    public class DisplayDetailProduct : IShowProductDetail
    {
        private Window parentWindow;
        public DisplayDetailProduct()
        {

        }

        public Window ParentWindow { get => parentWindow; set => parentWindow = value; }

        public void ShowProductDetail(Product_ref_Shop productModel)
        {
            detail_product product = new detail_product(productModel);          
            product.Owner = CurrentApplicationStatus.MainBoardWindow;
            CurrentApplicationStatus.MainBoardWindow.Hide();
            product.ShowDialog();
            CurrentApplicationStatus.MainBoardWindow.Show();
        }
    }
}
