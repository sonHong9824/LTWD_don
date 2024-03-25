using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Market.Models.Model
{
    public class Product_ref_Shop : Kho
    {
        string address;
        private ObservableCollection<string> imageList;
        string firstImage;

        public Product_ref_Shop() 
        {
        }

        public Product_ref_Shop(int idSanpham, int idShop, string ten, float? gia, float? discount, string doMoi, string type, float? rate, int? number, int? numberSold, Shop idShopNavigation, string address = null, ObservableCollection<string> imageList = null, string firstImage = null) : base(idSanpham, idShop, ten, gia, discount, doMoi, type, rate, number, numberSold, idShopNavigation)
        {
            this.address = address;
            this.imageList = imageList;
            this.firstImage = firstImage;
        }

        public string Address { get => address; set => address = value; }
        public ObservableCollection<string> ImageList { get => imageList; set => imageList = value; }
        public string FirstImage { get => firstImage; set => firstImage = value; }
    }
}

