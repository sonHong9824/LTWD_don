using Microsoft.Win32;
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
using System.IO;
using Path = System.IO.Path;
using static MaterialDesignThemes.Wpf.Theme;
using System.Threading;

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
        private void CopyImageToDirectory(string destinationDirectory)
        {
            //mo file
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.jpg; *.jpeg; *.png; *.gif; *.bmp)|*.jpg; *.jpeg; *.png; *.gif; *.bmp|All files (*.*)|*.*";
            openFileDialog.Title = "Select one picture";

            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    //kt thu muc id có tồn tại chưa
                    if (!Directory.Exists(destinationDirectory))
                    {
                        Directory.CreateDirectory(destinationDirectory);
                    }
                    string sourceFilePath = openFileDialog.FileName;

                    string destinationFilePath = Path.Combine(destinationDirectory, Path.GetFileName(sourceFilePath));

                    //Copy
                    File.Copy(sourceFilePath, destinationFilePath, true);

                    MessageBox.Show("Done!", "Notice", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error" + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
        private void btn_img_Click(object sender, RoutedEventArgs e)
        {
            txt_image.Text = "";
            //link thư mục sản phẩm
            string destinationDirectory = @"D:\HK2_23-24_LTwindows\15-3\SanPham\" + txt_idSP.Text; // Đường dẫn thư mục bạn muốn sao chép hình ảnh đến
            CopyImageToDirectory(destinationDirectory);
            string[] files = Directory.GetFiles(destinationDirectory);
            foreach (string file in files)
            {
                txt_image.Text += Path.GetFileName(file) + "\n";
            }
        }
        private void writeFile(string path , string content)
        {
            try
            {
                if (!File.Exists(path))
                {
                    // Nếu không tồn tại, tạo mới tệp và ghi dữ liệu
                    using (StreamWriter writer = File.CreateText(path))
                    {
                        writer.WriteLine(content);
                    }
                }
                else
                {
                    // Nếu tệp đã tồn tại, ghi đè dữ liệu
                    using (StreamWriter writer = new StreamWriter(path))
                    {
                        writer.WriteLine(content);
                    }
                }
                Thread.Sleep(100);
                new Custom_mb("Done", Custom_mb.MessageType.Success, Custom_mb.MessageButtons.Ok).ShowDialog();
            }
            catch
            {
                new Custom_mb("Fail", Custom_mb.MessageType.Error, Custom_mb.MessageButtons.Ok).ShowDialog();
            }
        }
        private void btn_submitAdd_Click(object sender, RoutedEventArgs e)
        {
            string overview = txt_overview.Text;
            string pathOver = string.Format(@"D:\HK2_23-24_LTwindows\15-3\SanPham\{0}\Tongquansanpham.txt", txt_idSP.Text);
            string tinhtranghientai = txt_configuration.Text;
            string pathTinhtrang = string.Format(@"D:\HK2_23-24_LTwindows\15-3\SanPham\{0}\Tinhtranghientai.txt", txt_idSP.Text);
            string thongtinthem = txt_Additional.Text;
            string pathThem = string.Format(@"D:\HK2_23-24_LTwindows\15-3\SanPham\{0}\Thongtinthem.txt", txt_idSP.Text);
            writeFile(pathOver, overview);
            writeFile(pathThem, thongtinthem);
            writeFile(pathTinhtrang, tinhtranghientai);
        }


        private void txt_overview_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                txt_overview.AppendText(Environment.NewLine);
                e.Handled = true;
            }
        }
    }
}
