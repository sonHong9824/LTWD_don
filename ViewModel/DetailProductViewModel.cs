using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media.Effects;
using WPF_Market.Models.Model;

namespace WPF_Market.ViewModel
{
    class DetailProductViewModel: BaseViewModel
    {
        private Product_ref_Shop _product;
        private string defaultImage;
        string tongQuan;
        string tTThem;
        string baoHanh;
        private double currentPrice;
        public DetailProductViewModel()
        {

        }

        public DetailProductViewModel(Product_ref_Shop productViewModel)
        {
            Product = productViewModel;
            DefaultImage = Product.FirstImage;
            ReadTongQuan(); 
            ReadTTThem();
            ReadTThientai();
            ChangePicture = new BaseViewModelCommand(SelectImageCommand);
        }

        private void SelectImageCommand(object obj)
        {
         
            string linkImage = (string)obj;
            DefaultImage = linkImage;
        }

        private void ReadTongQuan()
        {
            string filepath = @"D:\LTWD\LTWD_FinalProject\SanPham\" + Product.IDProduct.ToString().Trim() + "/Tongquansanpham.txt";
            StreamReader reader = new StreamReader(filepath);
            while (!reader.EndOfStream)
            {
                TongQuan = reader.ReadToEnd();
            }
            reader.Close();
        }
        private void ReadTTThem()
        {
            string filepath = @"D:\LTWD\LTWD_FinalProject\SanPham\" + Product.IDProduct.ToString().Trim() + "/Thongtinthem.txt";
            StreamReader reader = new StreamReader(filepath);
            while (!reader.EndOfStream)
            {
                TTThem = reader.ReadToEnd();
            }
            reader.Close();
        }
        private void ReadTThientai()
        {
            string filepath = @"D:\LTWD\LTWD_FinalProject\SanPham\" + Product.IDProduct.ToString().Trim() + "/Tinhtranghientai.txt";
            StreamReader reader = new StreamReader(filepath);
            while (!reader.EndOfStream)
            {
                BaoHanh = reader.ReadToEnd();
            }
            reader.Close();
        }
        public Product_ref_Shop Product
        {
            get { return _product; }
            set
            {
                _product = value;
                OnPropertyChanged(nameof(Product));
            }
        }
        public string TongQuan { get => tongQuan; set => tongQuan = value; }
        public string TTThem { get => tTThem; set => tTThem = value; }
        public string BaoHanh { get => baoHanh; set => baoHanh = value; }
        
        public ICommand ChangePicture {  get;}
        public string DefaultImage
        {
            get => defaultImage;
            set
            {
                defaultImage = value;
                OnPropertyChanged(nameof(DefaultImage));
            }
        }

        public double CurrentPrice { get => (double)(Product.Price *  (100 - Product.Discount)/100) ; set { currentPrice = value; OnPropertyChanged(nameof(CurrentPrice)); } }
    }
}
