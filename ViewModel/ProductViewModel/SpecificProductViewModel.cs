using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WPF_Market.Model;
namespace WPF_Market.ViewModel.ProductViewModel
{
    public class SpecificProductViewModel
    {
        private ProductModel product;
        private IShowProductDetail showProductDetail;
        private Window parentWindow; 
        public SpecificProductViewModel(ProductModel product, IShowProductDetail showproductdetail, Window parentWindow)
        {
            Product = product;
            showProductDetail = showproductdetail;
            SeeDetailCommand = new BaseViewModelCommand(ExecuteSeeDetailCommand);
            this.ParentWindow = parentWindow;
        }
        public ProductModel Product { get => product; set => product = value; }
        public string FirstImage { get => Product.FirstImage; set => Product.FirstImage = value; }
        public string NameProduct { get => Product.Txt_NameProduct; set => Product.Txt_NameProduct = value; }
        public double Price { get => Product.Txt_Price; set => Product.Txt_Price = value; }
        public double Rating { get => Product.Rating; set => Product.Rating = value; }
        public int NumberSold { get => Product.Number_Sold; set => Product.Number_Sold = value; }
        // Command
        public ICommand SeeDetailCommand { get; }
        public Window ParentWindow { get => parentWindow; set => parentWindow = value; }

        private void ExecuteSeeDetailCommand(object obj)
        {
            showProductDetail.ShowProductDetail(product, parentWindow);
        }
    }
}
