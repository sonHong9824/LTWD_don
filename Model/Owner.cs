using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WPF_Market.Model
{
    public class Owner : Person
    {
        string ID_shop;
        public Owner()
        {
        }

        public Owner(string iD_shop1)
        {
            ID_shop1 = iD_shop1;
        }

        public string ID_shop1 { get => ID_shop; set => ID_shop = value; }
    }
}