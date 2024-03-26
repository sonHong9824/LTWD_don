using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPF_Market.Models;

namespace WPF_Market.ViewModel
{
    public static class CurrentApplicationStatus
    {
        public static int CurrentID;
        public static Window MainBoardWindow;
        public static ObservableCollection<Inventory> ProductList = new ObservableCollection<Inventory>(
            DataProvider.Instance.DB.Inventories.ToList());
        public static void UpdateProductList()
        {
            ProductList = new ObservableCollection<Inventory>(
            DataProvider.Instance.DB.Inventories.ToList());
        }
    }
}
