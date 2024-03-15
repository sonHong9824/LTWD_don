using MaterialDesignThemes.Wpf.Transitions;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WPF_Market.ViewModel;
namespace WPF_Market.View
{
    /// <summary>
    /// Interaction logic for Signup.xaml
    /// </summary>
    public partial class Signup : Window
    {
        public Signup()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new Login_new().Show();

            this.Close();
           
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void btn_signup_Click(object sender, RoutedEventArgs e)
        {
            if (!Signup_DAO.Add_account(txt_user_name.Text, txt_email.Text, txt_password.Password.ToString(),txt_repeat_password.Password.ToString(), (bool)cb_condition.IsChecked))
            {
                new Custom_mb("An error has occured during your sign up process!\nPlease check your informations carefully again~~"
                    ,Custom_mb.MessageType.Error, Custom_mb.MessageButtons.Ok).ShowDialog();
                return;
            }
            new Custom_mb("Successfully sign up! Turning back to login page!"
                 , Custom_mb.MessageType.Success, Custom_mb.MessageButtons.Ok).ShowDialog();
            new Login_new().Show();
            this.Close();
            return;
        }
    }
}
