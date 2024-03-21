using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WPF_Market.View;
using WPF_Market.ViewModel;
namespace WPF_Market.Model
{
    public class ProductModel 
    {
        private int id_sanpham;
        private int id_shop;
        private string txt_NameProduct;
        private double txt_Price;
        private double discount;
        private string like_New;
        private string type;
        private double rating;
        private int number_Of_Product;
        private int number_Sold;
        private ObservableCollection<string> imageList;
        string firstImage;
        public ProductModel()
        {
        }

        public ProductModel(int id_sanpham, int id_shop, string txt_NameProduct, 
            double txt_Price, double discount, string like_New, string type, double rating, 
            int number_Of_Product, int number_Sold, ObservableCollection<string> imageList = null)
        {
            this.Id_sanpham = id_sanpham;
            this.Id_shop = id_shop;
            this.Txt_NameProduct = txt_NameProduct;
            this.Txt_Price = txt_Price;
            this.Discount = discount;
            this.Like_New = like_New;
            this.Type = type;
            this.rating = rating;
            this.Number_Of_Product = number_Of_Product;
            this.Number_Sold = number_Sold;
            this.ImageList = imageList;
            firstImage = imageList[0];
        }

        public int Id_sanpham { get => id_sanpham; set => id_sanpham = value; }
        public int Id_shop { get => id_shop; set => id_shop = value; }
        public string Txt_NameProduct { get => txt_NameProduct; set => txt_NameProduct = value; }
        public double Txt_Price { get => txt_Price/24000; set => txt_Price = value; }
        public double Discount { get => discount; set => discount = value; }
        public string Like_New { get => like_New; set => like_New = value; }
        public string Type { get => type; set => type = value; }
        public double Rating { get => rating; set => rating = value; }
        public int Number_Of_Product { get => number_Of_Product; set => number_Of_Product = value; }
        public int Number_Sold { get => number_Sold; set => number_Sold = value; }
        public ObservableCollection<string> ImageList { get => imageList; set => imageList = value; }
        public string FirstImage { get => firstImage; set => firstImage = value; }
    }
}
