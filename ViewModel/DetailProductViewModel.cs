using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_Market.Model;

namespace WPF_Market.ViewModel
{
    class DetailProductViewModel: BaseViewModel
    {
        private ProductModel _product;
        private ObservableCollection<string> imagelist;
        private string defaultImage;
        double ratingValue;
        string tenSanPham;
        string tongQuan;
        double price;
        string likeNew;
        string tTThem;
        string baoHanh;
        public DetailProductViewModel()
        {
        }

        public DetailProductViewModel(ProductModel productViewModel)
        {
            Product = productViewModel;
            Imagelist = productViewModel.ImageList;
            defaultImage = imagelist[0];
            ratingValue = productViewModel.Rating;
            tenSanPham = productViewModel.Txt_NameProduct;
            ReadTongQuan(); 
            price = productViewModel.Txt_Price;
            likeNew = productViewModel.Like_New.Trim();
            ReadTTThem();
            ReadTThientai();
        }
        private void ReadTongQuan()
        {
            string filepath = @"D:\HK2_23-24_LTwindows\15-3\SanPham\" + Product.Id_sanpham.ToString().Trim() + "/Tongquansanpham.txt";
            StreamReader reader = new StreamReader(filepath);
            while (!reader.EndOfStream)
            {
                TongQuan = reader.ReadToEnd();
            }
            reader.Close();
        }
        private void ReadTTThem()
        {
            string filepath = @"D:\HK2_23-24_LTwindows\15-3\SanPham\" + Product.Id_sanpham.ToString().Trim() + "/Thongtinthem.txt";
            StreamReader reader = new StreamReader(filepath);
            while (!reader.EndOfStream)
            {
                TTThem = reader.ReadToEnd();
            }
            reader.Close();
        }
        private void ReadTThientai()
        {
            string filepath = @"D:\HK2_23-24_LTwindows\15-3\SanPham\" + Product.Id_sanpham.ToString().Trim() + "/Tinhtranghientai.txt";
            StreamReader reader = new StreamReader(filepath);
            while (!reader.EndOfStream)
            {
                BaoHanh = reader.ReadToEnd();
            }
            reader.Close();
        }
        public ProductModel Product { get => _product; set => _product = value; }
        public ObservableCollection<string> Imagelist { get => imagelist; set => imagelist = value; }
        public string DefaultImage { get => defaultImage; set => defaultImage = value; }
        public double RatingValue { get => ratingValue; set => ratingValue = value; }
        public string TenSanPham { get => tenSanPham; set => tenSanPham = value; }
        public string TongQuan { get => tongQuan; set => tongQuan = value; }
        public double Price { get => price; set => price = value; }
        public string LikeNew { get => likeNew; set => likeNew = value; }
        public string TTThem { get => tTThem; set => tTThem = value; }
        public string BaoHanh { get => baoHanh; set => baoHanh = value; }
    }
}
