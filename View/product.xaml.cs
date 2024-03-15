using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPF_Market.Model;
using WPF_Market.ViewModel;

namespace WPF_Market.View
{
    /// <summary>
    /// Interaction logic for product.xaml
    /// </summary>
    public delegate void DSetDataContextProduct(product product);
    public partial class product : Page
    {
        
        public product()
        {
            InitializeComponent();

            this.DataContext = new ProductModel("/images/Shopee1.jpg", "Ten san pham: May tinh de ban", "Gia 10000", "Da ban 100", "Dia Diem: HCM", 4.5);
            Button myButton = new Button();
            Container.Children.Add(myButton);
            myButton.SetValue(Control.TemplateProperty, Container.FindResource("ProductTemplate"));

            SQLConnection.conn.Open();
            string cmd = string.Format("Select * from Kho");
            SqlCommand sqlCommand = new SqlCommand(cmd, SQLConnection.conn);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            ProductModel model;
            int count = 0;
            while (reader.Read())
            {
                if (count == 10)
                {
                    SQLConnection.conn.Close();
                    this.DataContext = new ProductModel("/images/MayTinh1.jpg", "Ten san pham: May tinh de ban", "Gia 10000", "Da ban 100", "Dia Diem: HCM", 4.5);
                    myButton = new Button();
                    Container.Children.Add(myButton);
                    myButton.SetValue(Control.TemplateProperty, Container.FindResource("ProductTemplate"));
                    myButton = new Button();
                    Container.Children.Add(myButton);
                    myButton.SetValue(Control.TemplateProperty, Container.FindResource("ProductTemplate"));
                    myButton = new Button();
                    Container.Children.Add(myButton);
                    myButton.SetValue(Control.TemplateProperty, Container.FindResource("ProductTemplate"));
                    myButton = new Button();
                    Container.Children.Add(myButton);
                    myButton.SetValue(Control.TemplateProperty, Container.FindResource("ProductTemplate"));
                    myButton = new Button();
                    Container.Children.Add(myButton);
                    myButton.SetValue(Control.TemplateProperty, Container.FindResource("ProductTemplate"));
                    myButton = new Button();
                    Container.Children.Add(myButton);
                    myButton.SetValue(Control.TemplateProperty, Container.FindResource("ProductTemplate"));
                    myButton = new Button();
                    Container.Children.Add(myButton);
                    myButton.SetValue(Control.TemplateProperty, Container.FindResource("ProductTemplate"));
                    myButton = new Button();
                    Container.Children.Add(myButton);
                    myButton.SetValue(Control.TemplateProperty, Container.FindResource("ProductTemplate"));
                    return;
                }
                string filePath = @"C:\Users\LAPTOP\OneDrive\Desktop\LTWD\SanPham";
                string nameProduct = "Ten san pham: " + reader["Ten"].ToString();
                filePath += "/" + reader["Id_sanpham"].ToString().Trim()+"/Images.txt";
                StreamReader stream = new StreamReader(filePath);
                string linkImage = "/SanPham/" + reader["Id_sanpham"].ToString().Trim() + "/Images/"+ stream.ReadLine().Trim();
                string price = "Gia: " + (Convert.ToDouble(reader["Gia"]) * (1- Convert.ToDouble(reader["Discount"]))).ToString("N2").Trim();
                string sold = "Da ban: " + reader["NumberSold"].ToString().Trim();
                string diadiem = "HCM";
                double rating = Convert.ToDouble(reader["Rate"]);
                count++;
                ProductModel l_model = new ProductModel(linkImage, nameProduct, price, sold, diadiem, rating);
                // Tạo Button mới và gán ProductModel làm DataContext của nó
                Button button = new Button();
                button.DataContext = l_model;
                button.Template = Container.FindResource("ProductTemplate") as ControlTemplate;
                // Thêm Button vào Container
                Container.Children.Add(button);
            }
          
        }
        public void SetDataContextProduct(product model)
        {
            this.DataContext = model;
        }
    }
}
