using System;
using System.Collections.Generic;
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

namespace WPF_Market.View
{
    /// <summary>
    /// Interaction logic for Manage_Product.xaml
    /// </summary>
    public partial class Manage_Product : Window
    {
        public Manage_Product()
        {
            InitializeComponent();
            btn_submitEdit.Visibility = Visibility.Collapsed;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        private void btn_img_Click(object sender, RoutedEventArgs e)
        {
            string folderPath = @"D:\";

            try
            {
                Process.Start("explorer.exe", folderPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }
    }
}
