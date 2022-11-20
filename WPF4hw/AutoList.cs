using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace WPF4hw
{
    internal class AutoList
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Photo { get; set; }

        public BitmapImage ImageSource
        {
            get { return new BitmapImage(new Uri(Photo)); }
            set { ImageSource = value; }
        }

        public AutoList() { }
        public AutoList(string brand, string model, string photo)
        {
            Brand = brand;
            Model = model;
            Photo = photo;
        }
    }
}
