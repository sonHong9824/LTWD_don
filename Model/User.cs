using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WPF_Market.Model
{
    public class User : Person
    {
        int ID_fav_product;
        int ID_fav_shop; //Khoa ngoai tham chieu den Shop.ID
        double Budget; // 0 VND :>

        public User()
        {
        }

        public User(int iD_fav_product, int iD_fav_shop, double budget)
        {
            ID_fav_product = iD_fav_product;
            ID_fav_shop = iD_fav_shop;
            Budget = budget;
        }
        public int ID_fav_product1 { get => ID_fav_product; set => ID_fav_product = value; }
        public int ID_fav_shop1 { get => ID_fav_shop; set => ID_fav_shop = value; }
        public double Budget1 { get => Budget; set => Budget = value; }
    }
}