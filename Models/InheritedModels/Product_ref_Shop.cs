using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Market.Models.Model
{
    public class Product_ref_Shop : Inventory
    {
        string address;
        private ObservableCollection<string> imageList;
        string firstImage;

        public Product_ref_Shop() 
        {
        }

      

        public string Address { get => address; set => address = value; }
        public ObservableCollection<string> ImageList { get => imageList; set => imageList = value; }
        public string FirstImage { get => firstImage; set => firstImage = value; }
    }
}

