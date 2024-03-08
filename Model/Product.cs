using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WPF_Market.Model
{
    public class Product
    {
        string ID_Product;
        string ID_Shop;

        // Khoa chinh

        string Name_product;
        string Name_producer;

        public Product()
        {
        }

        public Product(string iD_Product, string iD_Shop, string name_product, string name_producer)
        {
            ID_Product1 = iD_Product;
            ID_Shop1 = iD_Shop;
            Name_product1 = name_product;
            Name_producer1 = name_producer;
        }

        public string Name_product1 { get => Name_product; set => Name_product = value; }
        public string Name_producer1 { get => Name_producer; set => Name_producer = value; }
        public string ID_Product1 { get => ID_Product; set => ID_Product = value; }
        public string ID_Shop1 { get => ID_Shop; set => ID_Shop = value; }
    }
}