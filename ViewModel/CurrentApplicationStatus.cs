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
        public static Window MainBoardWindow;
        public static ObservableCollection<Kho> ProductList = new ObservableCollection<Kho>(
            DataProvider.Instance.DB.Khos.ToList());
        public static void UpdateProductList()
        {
            ProductList = new ObservableCollection<Kho>(
            DataProvider.Instance.DB.Khos.ToList());
        }
    }
}
