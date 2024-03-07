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
using System.Windows.Shapes;
using WPF_Market.PNG;

namespace WPF_Market
{
    /// <summary>
    /// Interaction logic for Main_page.xaml
    /// </summary>
    public partial class Main_page : Window
    {
        List<Cb_menu_item> cb_Menu_Items = new List<Cb_menu_item>();
        public Main_page()
        {
            InitializeComponent();
        }

       
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void btn_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (sender is Button)
            {
                Button? button = sender as Button;
                button.Foreground = Brushes.Orange; // Đặt màu chữ là màu cam khi rê chuột vào
                button.Background = Brushes.Transparent;
            }
        }
        private void btn_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (sender is Button)
            {
                Button? button = sender as Button;
                button.Foreground = Brushes.White; // Đặt màu chữ là màu đen khi rời chuột khỏi
            }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnMini_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnmaximized_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Normal)
            {
                WindowState = WindowState.Maximized;
            }
            else
            {
                WindowState = WindowState.Normal;
            }
        }

        private void Icon_category_MouseEnter(object sender, MouseEventArgs e)
        {
           
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            List<Cb_menu_item> cb_Menu_Items = new List<Cb_menu_item>() { 
            new Cb_menu_item(){Source1 = "/Image_shopping/coupon.png", Text = "Sale product"}, 
            new Cb_menu_item(){Source1 = "/Image_shopping/laundry.png", Text = "Clothes"},
            new Cb_menu_item(){Source1 = "/Image_shopping/vegetables.png", Text = "Vegetable"},
            new Cb_menu_item(){Source1 = "/Image_shopping/technology.png", Text = "Technology"},
            new Cb_menu_item(){Source1 = "/Image_shopping/restaurant.png", Text = "Food"},
            };


            cb_Menu.ItemsSource = cb_Menu_Items;

            cb_Menu.SelectionChanged += Cb_Menu_SelectionChanged;
            F_Display_current_content.Content = new Sale_Product_page();
        }



        private void Cb_Menu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Cb_menu_item item = (Cb_menu_item)cb_Menu.SelectedItem;
            if (item != null)
            {
                txt_search.Text = item.Text;
            }
            cb_Menu.SelectedItem = null;

        }

        private void txt_search_TextChanged(object sender, TextChangedEventArgs e)
        {
            txt_search.Foreground = Brushes.Black;
        }

        private void txt_search_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
           
        }

        private void txt_search_MouseEnter(object sender, MouseEventArgs e)
        {
            txt_search.SelectAll();
        }
    }
}
