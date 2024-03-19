using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPF_Market.Model;
using WPF_Market.ViewModel;
using WPF_Market.ViewModel.ProductViewModel;
using static MaterialDesignThemes.Wpf.Theme;
namespace WPF_Market.View
{
    /// <summary>
    /// Interaction logic for product.xaml
    /// </summary>

    public partial class product : Page
    {
        private ObservableCollection<ProductModel> listProduct;
        Window parentWindow;
        IShowProductDetail showProductDetai;
        public product(Window parentWindow)
        {

            InitializeComponent();
            this.parentWindow = parentWindow;
            // Get list Product
            ListProductViewModel listProduct = new ListProductViewModel();
            this.ListProduct = listProduct.ProductList;
            GenerateComponent();
        }

        public ObservableCollection<ProductModel> ListProduct { get => listProduct; set => listProduct = value; }

        public void GenerateComponent()
        {
            foreach (var item in ListProduct)
            {
                // Tao buttom
                System.Windows.Controls.Button button = new System.Windows.Controls.Button();
                showProductDetai = new DisplayDetailProduct(parentWindow);
                button.DataContext = new SpecificProductViewModel(item, showProductDetai, parentWindow);
                button.Template = Container.FindResource("ProductTemplate") as ControlTemplate;
                Container.Children.Add(button);
            }
        }
        public class DisplayDetailProduct : IShowProductDetail
        {
            private Window parentWindow;
            public DisplayDetailProduct(Window parentWindow)
            {
                ParentWindow = parentWindow;
            }

            public Window ParentWindow { get => parentWindow; set => parentWindow = value; }

            public void ShowProductDetail(ProductModel productModel, Window parentWindow)
            {
                detail_product product = new detail_product(productModel);
                product.Owner = parentWindow;
                parentWindow.Hide();
                product.ShowDialog();
                parentWindow.Show();
            }
        }
    }
}
