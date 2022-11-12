using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace WPF3._1cw
{
    internal class Product
    {
        public string Name { get; set; }
        public string MadeBy { get; set; }
        public float Price { get; set; }

        public string Image { get; set; }

        public BitmapImage ImageSource
        {
            get => new BitmapImage(new Uri(Image));
            set => ImageSource = value;
        }

        public Product() { }
        public Product(string name, string madeBy, float price, string image)
        {
            Name = name;
            MadeBy = madeBy;
            Price = price;
            Image = image;
        }
    }
}
