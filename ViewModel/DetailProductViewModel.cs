﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media.Effects;
using WPF_Market.Models;
using WPF_Market.View;
namespace WPF_Market.ViewModel
{
    class DetailProductViewModel: BaseViewModel
    {
        private Inventory _product;
        private string defaultImage;
        string tongQuan;
        string tTThem;
        string baoHanh;
        private double currentPrice;
        private int number = 1;
        private ObservableCollection<string>  listImage = new ObservableCollection<string>();
        public DetailProductViewModel()
        {

        }

        public DetailProductViewModel(Inventory productViewModel)
        {
            Product = productViewModel;
            foreach (var item in Product.ImageLinks)
            {
                ListImage.Add(item.ImageLink1);
            }
            DefaultImage = Product.ImageLinks.FirstOrDefault().FirstImage;
            ReadTongQuan(); 
            ReadTTThem();
            ReadTThientai();
            ChangePicture = new BaseViewModelCommand(SelectImageCommand);
            AddProduct = new BaseViewModelCommand(ExecuteAddProductCommand);
            IncreaseNumberButttonClick = new BaseViewModelCommand(ExecuteIncreaseNumberCommand);
            DecreaseNumberButttonClick = new BaseViewModelCommand(ExecuteDecreaseNumberCommand, CanExecuteDecreaseNumberCommand);
        }
        private void ExecuteDecreaseNumberCommand(object obj)
        {

            Number--;
        }

        private void ExecuteIncreaseNumberCommand(object obj)
        {
            Number++;
        }
        private bool CanExecuteDecreaseNumberCommand(object obj)
        {
            if (Number == 1)
            {
                return false;
            }
            return true;
        }
     

        private void ExecuteAddProductCommand(object obj)
        {
            var temp = DataProvider.Instance.DB.Carts.Where(p=> p.IDProduct == Product.IDProduct).FirstOrDefault();
            if (temp != null)
            {
                temp.NumberOfProduct += Number;
                DataProvider.Instance.DB.SaveChanges();
                new Custom_mb("Succesfully add to your cart!", Custom_mb.MessageType.Confirmation, Custom_mb.MessageButtons.Ok).ShowDialog();
                return;
            }
            DataProvider.Instance.DB.Carts.Add(new Models.Cart { IDProduct = Product.IDProduct, CurrentPrice = CurrentPrice, 
                IDUser = CurrentApplicationStatus.CurrentID, 
                NumberOfProduct = Number });
            DataProvider.Instance.DB.SaveChanges();

            new Custom_mb("Succesfully add to your cart!", Custom_mb.MessageType.Success, Custom_mb.MessageButtons.Ok).ShowDialog();
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
        public Inventory Product
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
        public ICommand AddProduct { get;}
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

        public ObservableCollection<string> ListImage { get => listImage; set => listImage = value; }
        public ICommand IncreaseNumberButttonClick { get; }
        public ICommand DecreaseNumberButttonClick { get; }
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
