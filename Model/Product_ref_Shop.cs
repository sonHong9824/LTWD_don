using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Market.Model
{
    public class Product_ref_Shop : ProductModel
    {
        string address;

        public Product_ref_Shop()
        {
        }

        public Product_ref_Shop(int id_sanpham, int id_shop, string txt_NameProduct, double txt_Price, double discount, string like_New, string type, double rating, int number_Of_Product, int number_Sold, ObservableCollection<string> imageList = null, string address = null) : base(id_sanpham, id_shop, txt_NameProduct, txt_Price, discount, like_New, type, rating, number_Of_Product, number_Sold, imageList)
        {
            this.address = address;
        }

        public string Address { get => address; set => address = value; }
    }
}
