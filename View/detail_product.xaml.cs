using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for detail_product.xaml
    /// </summary>
    public partial class detail_product : Window
    {
        private ProductModel model = new ProductModel();
        public detail_product(object productdetail)
        {
            InitializeComponent();
            model = (ProductModel)productdetail;
            DetailProductViewModel viewModel = new DetailProductViewModel(model);
            this.DataContext = viewModel;
        }

    }
}
