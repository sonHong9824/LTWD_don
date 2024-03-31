using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPF_Market.Models;
using WPF_Market.View;

namespace WPF_Market.ViewModel
{
    public class ShopViewModel : BaseViewModel
    {
        private ObservableCollection<Inventory> shopInventory;
        private int iDShop = CurrentApplicationStatus.CurrentID;
        public ShopViewModel()
        {
            ShopInventory = new ObservableCollection<Inventory>(DataProvider.Instance.DB.Inventories.Where(p=> p.IDShop == CurrentApplicationStatus.CurrentID));
            EditProductCommand = new BaseViewModelCommand(ExecuteEditProductCommand);
            DeleteProductCommand = new BaseViewModelCommand(ExecuteDeleteProductCommand);
        }

        private void ExecuteDeleteProductCommand(object obj)
        {
            System.Windows.Forms.MessageBox.Show("Test form delete");
        }

        private void ExecuteEditProductCommand(object obj)
        {
            var newWindow = new Manage_Product();
            newWindow.Owner = CurrentApplicationStatus.MainBoardWindow;
            newWindow.Show();
        }

        public ObservableCollection<Inventory> ShopInventory { get => shopInventory; set => shopInventory = value; }
        public ICommand EditProductCommand { get; }
        public ICommand DeleteProductCommand { get; }
        public int IDShop { get => iDShop; set => iDShop = value; }
    }
}
