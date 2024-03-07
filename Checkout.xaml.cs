using System;
using System.Collections.Generic;
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

namespace WPF_Market
{
    /// <summary>
    /// Interaction logic for Checkout.xaml
    /// </summary>
    public partial class Checkout : Page
    {
        public Checkout()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
          
            

            int n = 5;
            for (int i = 0; i < n; i++)
            {
                StackPanel Interal_stp = new StackPanel();
                Interal_stp.HorizontalAlignment = HorizontalAlignment.Left;
                Interal_stp.VerticalAlignment = VerticalAlignment.Center;
                Interal_stp.Height = 200;
                Interal_stp.Orientation = Orientation.Horizontal;
                Interal_stp.Margin=new Thickness(0,5,0,5);

                CheckBox checkBox = new CheckBox();
                checkBox.IsChecked = false;
                checkBox.Width = 50;
                checkBox.Height = 50;
                checkBox.Margin = new Thickness(10, 0, 10, 0);
                checkBox.VerticalAlignment = VerticalAlignment.Center;
                checkBox.HorizontalAlignment = HorizontalAlignment.Center;
                Interal_stp.Children.Add(checkBox);
              

                Image image = new Image();
                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.UriSource = new Uri("/Image_shopping/keyboard1.jpg", UriKind.Relative);
                bitmapImage.EndInit();
                image.Stretch = Stretch.Fill;
                image.Source = bitmapImage;
                image.Margin = new Thickness(10, 0, 10, 0);
                image.Width = 100;
                image.Height = 100;
                Interal_stp.Children.Add(image);  

                TextBlock tbl_price_per_one = new TextBlock();
                
                //Phai chinh lai theo cong thuc: Dongia * SoLuong sau khi lam db
                tbl_price_per_one.Text = "1000";
                tbl_price_per_one.Width = 100;
                tbl_price_per_one.Height = 50;
                tbl_price_per_one.HorizontalAlignment = HorizontalAlignment.Center;
                tbl_price_per_one.VerticalAlignment = VerticalAlignment.Center;
                Interal_stp.Children.Add(tbl_price_per_one);
                tbl_price_per_one.Margin = new Thickness(10, 0, 10, 0);

                Button btn_increase = new Button();
                Button btn_decrease = new Button();
                TextBlock tbl_number = new TextBlock();
                btn_decrease.Content = "-";
                btn_increase.Content = "+";
                tbl_number.Text = "1";
                tbl_number.Width = 100;
                tbl_number.Height = 50;
                tbl_number.VerticalAlignment = VerticalAlignment.Center;
                tbl_number.HorizontalAlignment = HorizontalAlignment.Center;
                btn_decrease.Width = 50;
                btn_decrease.Height = 50;
                btn_increase.Height = 50;
                btn_increase.Width = 50;
                Interal_stp.Children.Add(btn_decrease);
                Interal_stp.Children.Add(tbl_number);
                Interal_stp.Children.Add(btn_increase);
                btn_decrease.Margin= new Thickness(10,0,0,0);
                btn_increase.Margin = new Thickness(0, 0, 10, 0);

                TextBlock tbl_price = new TextBlock();
                tbl_price.HorizontalAlignment = HorizontalAlignment.Left;
                tbl_price.VerticalAlignment = VerticalAlignment.Center;
                //Phai chinh lai theo cong thuc: Dongia * SoLuong sau khi lam db
                tbl_price.Text = "1000";
                Interal_stp.Children.Add(tbl_price);
                tbl_price.VerticalAlignment= VerticalAlignment.Center;
                tbl_price.HorizontalAlignment= HorizontalAlignment.Center;
                tbl_price.Margin = new Thickness(5,0,0,0);

                Button btn_delete = new Button();
                btn_delete.Content = "Remove this product";
                btn_delete.VerticalContentAlignment = VerticalAlignment.Center;
                btn_delete.HorizontalContentAlignment = HorizontalAlignment.Center;
                btn_delete.Width = 200;
                btn_delete.Height = 50;
                btn_delete.Margin = new Thickness(10,0,0,5);
                Interal_stp.Children.Add(btn_delete);

                External_stkp.Children.Add(Interal_stp);
            }
               
            
        }
    }
}
