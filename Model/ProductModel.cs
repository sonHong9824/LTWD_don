using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Market.Model
{
    public class ProductModel
    {
        private string image_link;
        private string txt_NameProduct;
        private string txt_Price;
        private string txt_Sold;
        private string txt_DiaDiem;
        private double rating;
        public ProductModel()
        {
        }

        public ProductModel(string image_link, string txt_NameProduct, string txt_Price, string txt_Sold, string txt_DiaDiem, double rating)
        {
            this.image_link = image_link;
            this.txt_NameProduct = txt_NameProduct;
            this.txt_Price = txt_Price;
            this.txt_Sold = txt_Sold;
            this.txt_DiaDiem = txt_DiaDiem;
            this.rating = rating;
        }

        public string Image_link { get => image_link; set => image_link = value; }
        public string Txt_NameProduct { get => txt_NameProduct; set => txt_NameProduct = value; }
        public string Txt_Price { get => txt_Price; set => txt_Price = value; }
        public string Txt_Sold { get => txt_Sold; set => txt_Sold = value; }
        public string Txt_DiaDiem { get => txt_DiaDiem; set => txt_DiaDiem = value; }
        public double Rating { get => rating; set => rating = value; }
    }
}
