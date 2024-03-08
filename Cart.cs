using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WPF_Market
{
    public class Cart
    {
        string User_ID;
        string Cart_ID;
        string ID_Shop;
        string ID_Product;
        int number;
        public Cart()
        {
        }

        public Cart(string user_ID, string cart_ID, string iD_Shop, string iD_Product, int number = 0)
        {
            User_ID1 = user_ID;
            Cart_ID1 = cart_ID;
            ID_Shop1 = iD_Shop;
            ID_Product1 = iD_Product;
            this.number = number;
        }

        public string User_ID1 { get => User_ID; set => User_ID = value; }
        public string Cart_ID1 { get => Cart_ID; set => Cart_ID = value; }
        public string ID_Shop1 { get => ID_Shop; set => ID_Shop = value; }
        public string ID_Product1 { get => ID_Product; set => ID_Product = value; }
        public int Number { get => number; set => number = value; }
    }
}