using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_Market.Model;
using WPF_Market.View;

namespace WPF_Market.ViewModel
{
    internal interface IShowProductDetail
    {
        void ShowProductDetail(ProductModel productModel);   
    }
}
