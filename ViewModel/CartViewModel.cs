using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using WPF_Market.Models;
using WPF_Market.View;
using WPF_Market.ViewModel.CartsWrapper;
namespace WPF_Market.ViewModel
{
    public class CartViewModel : BaseViewModel
    {
      
        private ObservableCollection<CartWrapper> carts;
        private double subTotal = 0;

        private double moneyToPay = 0;
        private bool isCheckedPickup;
        private bool isCheckedDelivery;
        private CartWrapper selectedChanged;
        public CartViewModel()
        {
            var lst = DataProvider.Instance.DB.Carts.Include(p=>p.IDProductNavigation.ImageLinks).Where(p=>p.IDUser == CurrentApplicationStatus.CurrentID).ToList();
            carts = new ObservableCollection<CartWrapper>();
            foreach (var item in lst)
            {
                carts.Add(new CartWrapper(item));
            }
            carts.CollectionChanged += Carts_CollectionChanged;
            Delivery = new BaseViewModelCommand(ExecuteDeliveryCommand);
            Pickup = new BaseViewModelCommand(ExecutePickupCommand);
            IsCheckedCommand = new BaseViewModelCommand(ExecuteIsCheckedCommand);
            ShowContextMenu = new BaseViewModelCommand(ExecuteShowContextMenu);
            ShowDetailCommand = new BaseViewModelCommand(ExecuteShowDetailCommand);
            DeleteProductCommand = new BaseViewModelCommand(ExecuteDeleteProductCommand);
        }

        private void ExecuteDeleteProductCommand(object obj)
        {
            var cart = obj as CartWrapper;
            Carts.Remove(cart);
            DataProvider.Instance.DB.Remove(cart.Cart);
            DataProvider.Instance.DB.SaveChanges();
        }

        private void ExecuteShowDetailCommand(object obj)
        {
            var cart = obj as CartWrapper;
            var detail = new detail_product(cart.Cart.IDProductNavigation);
            detail.Owner = CurrentApplicationStatus.MainBoardWindow;
            detail.ShowDialog();
        }

        private void ExecuteShowContextMenu(object obj)
        {
            throw new NotImplementedException();
        }

        private void ExecuteIsCheckedCommand(object obj)
        {
           ChangeSubTotal((CartWrapper)obj);
        }

        private void Carts_CollectionChanged(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            return;
        }   
        private void ExecutePickupCommand(object obj)
        {
            if (IsCheckedDelivery == true)
            {
                MoneyToPay -= 15;
            }
            IsCheckedDelivery = false;
        }

        private void ExecuteDeliveryCommand(object obj)
        {
            IsCheckedPickup = false;
            MoneyToPay += 15;
        }

        public ObservableCollection<CartWrapper> Carts { get => carts; set { carts = value; 
                OnPropertyChanged(nameof(Carts)); } }

        public void ChangeSubTotal(CartWrapper cart)
        {
            if (cart.CartWrapperIsChecked == true)
            {
                SubTotal += cart.CartWrapperCurrentPrice;
                MoneyToPay += SubTotal;
            }
            else
            {
                SubTotal -= cart.CartWrapperCurrentPrice;
                MoneyToPay -= SubTotal;
            }
            return;
        }

        public double MoneyToPay { get => moneyToPay; set { moneyToPay = value; OnPropertyChanged(nameof(MoneyToPay)); } }
        public bool IsCheckedPickup { get => isCheckedPickup; set { isCheckedPickup = value; OnPropertyChanged(nameof(isCheckedPickup)); } }
        public bool IsCheckedDelivery { get => isCheckedDelivery; set { isCheckedDelivery = value; OnPropertyChanged(nameof(IsCheckedDelivery)); } }
        public double SubTotal { get => subTotal; set { subTotal = value; OnPropertyChanged(nameof(SubTotal)); } }
        public ICommand Delivery { get; }
        public ICommand Pickup { get; }
        public ICommand IsCheckedCommand { get; }
        public ICommand ShowContextMenu { get; }
        public ICommand ShowDetailCommand { get; }
        public ICommand DeleteProductCommand { get; }   
        public CartWrapper SelectedChanged { get => selectedChanged; set { selectedChanged = value;/* System.Windows.Forms.MessageBox.Show("Test");*/ OnPropertyChanged(nameof(SelectedChanged)); } }
      
    }

}
