using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPF_Market.Models.Model;
using WPF_Market.View;

namespace WPF_Market.ViewModel
{
    public interface IShowProductDetail
    {
        void ShowProductDetail(Product_ref_Shop productModel);   
    }
}
