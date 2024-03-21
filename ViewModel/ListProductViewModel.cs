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
        private ObservableCollection<ProductModel> productList = new ObservableCollection<ProductModel>();
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

        public ObservableCollection<ProductModel> ProductList
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
                string filePath = @"D:\LTWD\LTWD_FinalProject\SanPham\";

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
        public ICommand SeeDetailCommand { get; }
        private void ExecuteSeeDetailCommand(object obj)
        {
            showProductDetail = new DisplayDetailProduct(parentWindow);
            showProductDetail.ShowProductDetail((ProductModel)obj, parentWindow);
        }
    }
    public class DisplayDetailProduct : IShowProductDetail
    {
        private Window parentWindow;
        public DisplayDetailProduct(Window parentWindow)
        {
            ParentWindow = parentWindow;
        }

        public Window ParentWindow { get => parentWindow; set => parentWindow = value; }

        public void ShowProductDetail(ProductModel productModel, Window parentWindow)
        {
            detail_product product = new detail_product(productModel);
            product.Owner = parentWindow;
            parentWindow.Hide();
            product.ShowDialog();
            parentWindow.Show();
        }
    }
}
