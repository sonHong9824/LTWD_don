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

namespace WPF_Market.View
{
    /// <summary>
    /// Interaction logic for product.xaml
    /// </summary>

    public partial class product : Page
    {
        private ObservableCollection<ProductModel> listComponent;
        private Dictionary<ProductModel, ICommand> productCommandPair;
        public product()
        {

            InitializeComponent();
            IShowProductDetail showProductDetail = new DisplayDetailProduct();
            ProductViewModel productViewModel = new ProductViewModel(showProductDetail);
            listComponent = productViewModel.ProductList;
            GenerateComponent();
        }

        public void GenerateComponent()
        {
            foreach (var item in listComponent)
            {
                Button button = new Button();
                button.Tag = item.Id_sanpham;
                button.DataContext = item;
                button.Template = Container.FindResource("ProductTemplate") as ControlTemplate;
                button.CommandParameter = item;
                //button.Command = productCommandPair[item];
                button.Click += Button_Click;
                Container.Children.Add(button);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window window = Window.GetWindow(this);
            detail_product product = new detail_product();
            product.Owner = window;
            product.ShowDialog();
            
        }
        public class DisplayDetailProduct : IShowProductDetail
        {
            public void ShowProductDetail(ProductModel productModel)
            {
                MessageBox.Show(productModel.Id_sanpham.ToString());
                detail_product product = new detail_product();
                product.ShowDialog();
            }
        }
    }
}
