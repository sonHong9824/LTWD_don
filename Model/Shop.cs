using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WPF_Market.Model
{
    public class Shop
    {
        string ID_Shop;
        string ID_Owner;
        // Khoa chinh

        string ID_Kho_hang;
        string Name_shop;
        string Avatar_shop_source;

        public Shop()
        {
        }

        public Shop(string iD_Shop, string iD_Owner, string iD_Kho_hang, string name_shop, string avatar_shop_source)
        {
            ID_Shop1 = iD_Shop;
            ID_Owner1 = iD_Owner;
            ID_Kho_hang1 = iD_Kho_hang;
            Name_shop1 = name_shop;
            Avatar_shop_source1 = avatar_shop_source;
        }

        public string ID_Shop1 { get => ID_Shop; set => ID_Shop = value; }
        public string ID_Owner1 { get => ID_Owner; set => ID_Owner = value; }
        public string ID_Kho_hang1 { get => ID_Kho_hang; set => ID_Kho_hang = value; }
        public string Name_shop1 { get => Name_shop; set => Name_shop = value; }
        public string Avatar_shop_source1 { get => Avatar_shop_source; set => Avatar_shop_source = value; }
    }
}