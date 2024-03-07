using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Market.PNG
{
    class Cb_menu_item
    {
        string Source = "";
        string text = "";

        public Cb_menu_item()
        {
        }

        public Cb_menu_item(string source, string text)
        {
            Source = source;
            this.text = text;
        }

        public string Text { get => text; set => text = value; }
        public string Source1 { get => Source; set => Source = value; }
    }
}
