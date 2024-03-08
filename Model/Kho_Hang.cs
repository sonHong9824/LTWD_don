using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WPF_Market.Model
{
    public class Inventory
    {
        string ID_iventory;
        string ID_shop; // Khoa ngoai
        string ID_mat_hang; // Khoa ngoai
        // Khoa chinh

        double Price_per_one;
        int Number_product_left;

        public Inventory()
        {
        }

        public Inventory(string iD_Kho_hang, string iD_shop, string iD_mat_hang, double price_per_one, int number_product_left)
        {
            ID_iventory1 = iD_Kho_hang;
            ID_shop1 = iD_shop;
            ID_mat_hang1 = iD_mat_hang;
            Price_per_one1 = price_per_one;
            Number_product_left1 = number_product_left;
        }

       
        public string ID_shop1 { get => ID_shop; set => ID_shop = value; }
        public string ID_mat_hang1 { get => ID_mat_hang; set => ID_mat_hang = value; }
        public double Price_per_one1 { get => Price_per_one; set => Price_per_one = value; }
        public int Number_product_left1 { get => Number_product_left; set => Number_product_left = value; }
        public string ID_iventory1 { get => ID_iventory; set => ID_iventory = value; }
    }
}