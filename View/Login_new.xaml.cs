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
using WPF_Market.Model;
using WPF_Market.ViewModel;

namespace WPF_Market
{
    /// <summary>
    /// Interaction logic for Login_new.xaml
    /// </summary>
    public partial class Login_new : Window
    {
        public Login_new()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new Signup().Show();
            this.Close();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Acccount acccount = Account_DAO.Return_account(txt_user.Text,txt_password.ToString());
            if (acccount != null) 
            {
                new Custom_mb("Login successfully!\nWelcome back, " + acccount.User_name, Custom_mb.MessageType.Success, Custom_mb.MessageButtons.Ok).ShowDialog();
                new Main_page().Show();
                this.Close();
                return;
            }
            new Custom_mb("Fail to login, your information is wrong!", Custom_mb.MessageType.Warning, Custom_mb.MessageButtons.Ok).ShowDialog();
            return;
        }
    }
}
