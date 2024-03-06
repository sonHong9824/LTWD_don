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

namespace WPF_Market
{
    /// <summary>
    /// Interaction logic for Main_page.xaml
    /// </summary>
    public partial class Main_page : Window
    {
        public Main_page()
        {
            InitializeComponent();
            Window
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
    }
}
