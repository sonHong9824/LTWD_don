using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
            
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.LeftButton == MouseButtonState.Pressed )
            {
                DragMove();
            }
        }

        private void btnMini_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
            
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btn_login_Click(object sender, RoutedEventArgs e)
        {

        }

      

        private void txb_signUp_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("sign up");
        }

        private void txb_signUp_MouseUp(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
