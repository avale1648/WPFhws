using System;
using System.Collections.Generic;
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

namespace WPF1hw
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int imageIndex = 1;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Next(object sender, RoutedEventArgs e)
        {
            imageIndex++;
            if(imageIndex > 9)
                imageIndex = 1;
            ImageCollection.Source = new BitmapImage(new Uri(@"Images/" + imageIndex + ".jpg", UriKind.Relative));

        }

        private void Prev(object sender, RoutedEventArgs e)
        {
            imageIndex--;
            if (imageIndex < 1)
                imageIndex = 9;
            ImageCollection.Source = new BitmapImage(new Uri(@"Images/" + imageIndex + ".jpg", UriKind.Relative));
        }

        private void First(object sender, RoutedEventArgs e)
        {
            imageIndex = 1;
            ImageCollection.Source = new BitmapImage(new Uri(@"Images/" + imageIndex + ".jpg", UriKind.Relative));
        }

        private void Last(object sender, RoutedEventArgs e)
        {
            imageIndex = 9;
            ImageCollection.Source = new BitmapImage(new Uri(@"Images/" + imageIndex + ".jpg", UriKind.Relative));
        }
        private void Play(object sender, RoutedEventArgs e)
        {
            imageIndex = 1;
            while(imageIndex < 11)
            {
                imageIndex++;
                ImageCollection.Source = new BitmapImage(new Uri(@"Images/" + imageIndex + ".jpg", UriKind.Relative));
                ImageCollection.InvalidateVisual();
            }
        }
    }
}
