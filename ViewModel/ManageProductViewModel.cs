using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WPF_Market.View;
using WPF_Market.Models;
namespace WPF_Market.ViewModel
{
    public class ManageProductViewModel : BaseViewModel
    {
        private string nameProduct;
        private double price;
        private double discount;
        private string newness;
        private string type;
        private string overview;
        private string configuration;
        private string additional;
        private int idSanPham;
        private string imageLinks;
        private int number = 1;
        public ObservableCollection<string> shortStringList;

        public ObservableCollection<string> ShortStringList
        {
            get { return shortStringList; }
            set
            {
                shortStringList = value;
                OnPropertyChanged(nameof(shortStringList));
            }
        }
        public ManageProductViewModel()
        {
            idSanPham = new Random().Next(1000, 9999);
            SubmitCommand = new BaseViewModelCommand(ExecuteSubmitCommand, CanExecuteSubmitCommand);
            BtnImageClick = new BaseViewModelCommand(ExecuteImageClickCommand);
            IncreaseNumberButttonClick = new BaseViewModelCommand(ExecuteIncreaseNumberCommand);
            DecreaseNumberButttonClick = new BaseViewModelCommand(ExecuteDecreaseNumberCommand, CanExecuteDecreaseNumberCommand);
            CloseForm = new BaseViewModelCommand(ExecuteCloseFormCommand);
            ShortStringList = new ObservableCollection<string>();
            ShortStringList.Add("Electronics");
            ShortStringList.Add("Fashion and Clothing");
            ShortStringList.Add("Jewellery");
            ShortStringList.Add("Health and Beauty");
            ShortStringList.Add("Books");
            ShortStringList.Add("Kids and Babies");
            ShortStringList.Add("Sports");
            ShortStringList.Add("Fruit and veg");
            ShortStringList.Add("Home and Graden");
            ShortStringList.Add("Others");
        }

        private void ExecuteCloseFormCommand(object obj)
        {
            if (Application.Current.MainWindow != null)
            {
                Application.Current.MainWindow.Close();
            }
        }

        public ManageProductViewModel(string nameProduct, double price, double discount, string newness, string type, string overview, string configuration, string additional)
        {
            this.nameProduct = nameProduct;
            this.price = price;
            this.discount = discount;
            this.newness = newness;
            this.type = type;
            this.overview = overview;
            this.configuration = configuration;
            this.additional = additional;
            SubmitCommand = new BaseViewModelCommand(ExecuteSubmitCommand);
            ShortStringList = new ObservableCollection<string>();
            IncreaseNumberButttonClick = new BaseViewModelCommand(ExecuteIncreaseNumberCommand);
            DecreaseNumberButttonClick = new BaseViewModelCommand(ExecuteDecreaseNumberCommand, CanExecuteDecreaseNumberCommand);
            ShortStringList.Add("Electronics");
            ShortStringList.Add("Fashion and Clothing");
            ShortStringList.Add("Jewellery");
            ShortStringList.Add("Health and Beauty");
            ShortStringList.Add("Books");
            ShortStringList.Add("Kids and Babies");
            ShortStringList.Add("Sports");
            ShortStringList.Add("Fruit and veg");
            ShortStringList.Add("Home and Graden");
            ShortStringList.Add("Others");
        }

        private bool CanExecuteDecreaseNumberCommand(object obj)
        {
            if (Number==1)
            {
                return false;
            }
            return true;
        }

        private void ExecuteDecreaseNumberCommand(object obj)
        {
          
            Number--;
        }

        private void ExecuteIncreaseNumberCommand(object obj)
        {
            Number++;
        }

        private void ExecuteImageClickCommand(object obj)
        {
            ImageLinks = "";
            //link thư mục sản phẩm
            string destinationDirectory = @"D:\LTWD\LTWD_FinalProject\SanPham\Images\" + idSanPham.ToString().Trim(); // Đường dẫn thư mục bạn muốn sao chép hình ảnh đến
            CopyImageToDirectory(destinationDirectory);
            string[] files = Directory.GetFiles(destinationDirectory);
            foreach (string file in files)
            {
                ImageLinks += Path.GetFileName(file) + "\n";
            }
          
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
                    new Custom_mb("Operation successfully!", Custom_mb.MessageType.Success, Custom_mb.MessageButtons.Ok).ShowDialog();
                   
                }
                catch (Exception ex)
                {
                    new Custom_mb("Operation failed!", Custom_mb.MessageType.Error, Custom_mb.MessageButtons.Ok).ShowDialog();
                }
            }
        }

        private bool CanExecuteSubmitCommand(object obj)
        {
            if (string.IsNullOrEmpty(imageLinks) || string.IsNullOrEmpty(type) ||
                string.IsNullOrEmpty(overview) || string.IsNullOrEmpty(Additional) ||
                string.IsNullOrEmpty(Configuration) || string.IsNullOrEmpty(NameProduct) ||
                string.IsNullOrEmpty(Newness))
            {    
                return false; 
            }
            return true;
        }

     
        private void ExecuteSubmitCommand(object obj)
        {

            string pathOver = string.Format(@"D:\LTWD\LTWD_FinalProject\SanPham\{0}\Tongquansanpham.txt", idSanPham.ToString().Trim());
            string pathTinhtrang = string.Format(@"D:\LTWD\LTWD_FinalProject\SanPham\{0}\Tinhtranghientai.txt", idSanPham.ToString().Trim());
            string pathThem = string.Format(@"D:\LTWD\LTWD_FinalProject\SanPham\{0}\Thongtinthem.txt", idSanPham.ToString().Trim());
            bool writeOverview = writeFile(pathOver, Overview);
            bool writeAdditional = writeFile(pathThem, Additional);
            bool writeConfiguration = writeFile(pathTinhtrang, Configuration);
            if (writeOverview && writeAdditional && writeConfiguration)
            {
                /*SQLConnection.conn.Open();
                string sqlCmd = string.Format("Insert into Kho(Id_sanpham, Id_shop, Ten, Gia, Discount, DoMoi, Type, Rate, Number, NumberSold) values " + "('{0}', '{1}', '{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}')", idSanPham
                    , 1, NameProduct, Price, Discount, Newness, Type, 0, number, 0);
                SqlCommand cmd = new SqlCommand(sqlCmd, SQLConnection.conn);
                if (cmd.ExecuteNonQuery() > 0)
                    new Custom_mb("Done", Custom_mb.MessageType.Success, Custom_mb.MessageButtons.Ok).ShowDialog();
                SQLConnection.conn.Close();*/
              
                DataProvider.Instance.DB.Add(new Inventory { IDShop = CurrentApplicationStatus.CurrentID, Name = NameProduct, Price = (float)Price, Discount = (float)Discount, Newness = Newness, Type = Type
                , Rating = 0, Number = Number, NumberSold=0});
                DataProvider.Instance.DB.SaveChanges();
                return;
            }
            new Custom_mb("Fail", Custom_mb.MessageType.Error, Custom_mb.MessageButtons.Ok).ShowDialog();
        }
        private bool writeFile(string path, string content)
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
                return true;
            }
            catch
            {

            }
            return false;
        }

        public string NameProduct
        {
            get { return nameProduct; }
            set
            {
                nameProduct = value;
                OnPropertyChanged(nameof(nameProduct));
            }
        }
        public double Price
        {
            get { return price; }
            set
            {
                price = value;
                OnPropertyChanged(nameof(price));
            }
        }
        public double Discount
        {
            get => discount;
            set
            {
                discount = value;
                OnPropertyChanged(nameof(discount));
            }
        }
        public string Newness
        {
            get
            { return newness; }
            set
            {
                newness = value;
                OnPropertyChanged(nameof(newness));
            }
        }
        public string Type
        {
            get => type;
            set
            {
                type = value;
                OnPropertyChanged(nameof(type));
            }
        }
        public string Overview
        {
            get { return overview; }
            set
            {
                overview = value;
                OnPropertyChanged(nameof(overview));
            }
        }
        public string Configuration
        {
            get => configuration;
            set
            {
                configuration = value;
                OnPropertyChanged(nameof(configuration));
            }
        }
        public string Additional
        {
            get { return additional; }
            set
            {
                additional = value;
                OnPropertyChanged(nameof(additional));
            }
        }
        // Commands
        public ICommand SubmitCommand { get; }
        public ICommand BtnImageClick { get; }
        public ICommand IncreaseNumberButttonClick { get; }
        public ICommand DecreaseNumberButttonClick { get; }
        public ICommand CloseForm {  get; }
        public int IdSanPham { get => idSanPham; set => idSanPham = value; }
        public string ImageLinks
        {
            get { return imageLinks; }
            set
            {
                imageLinks = value;
                OnPropertyChanged(nameof(imageLinks));
            }
        }

        public int Number
        {
            get
            {
                return number;
            }
            set
            {
                number = value;
                OnPropertyChanged(nameof(number));
            }
        }
    }
}
