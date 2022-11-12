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

namespace WPF3._1cw
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private GridView gridView = new GridView();
        private DataTemplate large;
        private DataTemplate small;
        private ItemsPanelTemplate table;
        private ItemsPanelTemplate smallIcons;
        private ItemsPanelTemplate largeIcons;
        public MainWindow()
        {
            //Product(string name, string madeBy, float price, string image, BitmapImage imageSource)
            InitializeComponent();
            productsListBox.Items.Add(new Product("CommParty China  +1000 sc", "China", 1000f, @"Images\1.jpg"));
            productsListBox.Items.Add(new Product("CommParty China  +1000 sc", "China", 1000f, @"Images\2.jpg"));
            productsListBox.Items.Add(new Product("CommParty China  +1000 sc", "China", 1000f, @"Images\3.jpg"));
            productsListBox.Items.Add(new Product("CommParty China  +1000 sc", "China", 1000f, @"Images\4.jpg"));
            productsListBox.Items.Add(new Product("CommParty China  +1000 sc", "China", 1000f, @"Images\5.jpg"));
            productsListBox.Items.Add(new Product("CommParty China  +1000 sc", "China", 1000f, @"Images\6.jpg"));
            productsListBox.Items.Add(new Product("CommParty China  +1000 sc", "China", 1000f, @"Images\7.jpg"));

            CreateTableView();
            CreateBigIcons();
        }
        private void CreateBigIcons()
        {
            FrameworkElementFactory StackPanelF_Big = new FrameworkElementFactory(typeof(StackPanel));
            StackPanelF_Big.SetValue(StackPanel.BackgroundProperty, Background = new SolidColorBrush(Colors.Beige));

            FrameworkElementFactory ImageFB = new FrameworkElementFactory(typeof(Image));
            ImageFB.SetValue(Image.SourceProperty, new Binding("Image"));
            ImageFB.SetValue(Image.WidthProperty, Width = 200);
            StackPanelF_Big.AppendChild(ImageFB);

            FrameworkElementFactory LableF = new FrameworkElementFactory(typeof(Label));
            LableF.SetValue(Label.ContentProperty, new Binding("Name"));
            LableF.SetValue(Label.WidthProperty, Width = 50);
            StackPanelF_Big.AppendChild(LableF);

            FrameworkElementFactory LableC = new FrameworkElementFactory(typeof(Label));
            LableC.SetValue(Label.ContentProperty, new Binding("MadeBy"));
            LableC.SetValue(Label.WidthProperty, Width = 50);
            StackPanelF_Big.AppendChild(LableC);

            large = new DataTemplate();
            large.VisualTree = StackPanelF_Big;
            largeIcons = new ItemsPanelTemplate();

            FrameworkElementFactory WPF_Big = new FrameworkElementFactory(typeof(WrapPanel));
            WPF_Big.SetValue(WrapPanel.OrientationProperty, Orientation.Horizontal);

            Binding B_W = new Binding("ActualWidth");
            B_W.Source = this.productsListBox;
            WPF_Big.SetValue(WrapPanel.WidthProperty, B_W);

            Binding B_H = new Binding("ActualHeight");
            B_H.Source = this.productsListBox;
            WPF_Big.SetValue(WrapPanel.HeightProperty, B_H);

            largeIcons.VisualTree = WPF_Big;
        }
        private void CreateTableView()
        {
            GridViewColumn gridViewColumn1 = new GridViewColumn();
            GridViewColumnHeader gridViewColumnHeader1 = new GridViewColumnHeader();
            gridViewColumnHeader1.Content = "Name";
            gridViewColumn1.Header = gridViewColumnHeader1;
            gridViewColumn1.DisplayMemberBinding = new Binding("Name");

            GridViewColumn gridViewColumn2 = new GridViewColumn();
            GridViewColumnHeader gridViewColumnHeader2 = new GridViewColumnHeader();
            gridViewColumnHeader2.Content = "Made in/by";
            gridViewColumn2.Header = gridViewColumnHeader2;
            gridViewColumn2.DisplayMemberBinding = new Binding("MadeBy");

            GridViewColumn gridViewColumn3 = new GridViewColumn();
            GridViewColumnHeader gridViewColumnHeader3 = new GridViewColumnHeader();
            gridViewColumnHeader3.Content = "Price";
            gridViewColumn3.Header = gridViewColumnHeader3;
            gridViewColumn3.DisplayMemberBinding = new Binding("Price");

            GridViewColumn gridViewColumn4 = new GridViewColumn();
            gridViewColumn4.Header = "Photo";

            DataTemplate dataTemplateCell = new DataTemplate();
            FrameworkElementFactory frameworkElementFactory =
                new FrameworkElementFactory(typeof(Image));
            frameworkElementFactory.SetValue(Image.SourceProperty, new Binding("Image"));
            frameworkElementFactory.SetValue(Image.WidthProperty, Width = 60);
            dataTemplateCell.VisualTree = frameworkElementFactory;
            gridViewColumn4.CellTemplate = dataTemplateCell;

            gridView.Columns.Add(gridViewColumn1);
            gridView.Columns.Add(gridViewColumn2);
            gridView.Columns.Add(gridViewColumn3);
            gridView.Columns.Add(gridViewColumn4);

            productsListBox.View = gridView;
            table = new ItemsPanelTemplate();
            FrameworkElementFactory WPFTable = new FrameworkElementFactory(typeof(StackPanel));
            WPFTable.SetValue(WrapPanel.OrientationProperty, Orientation.Vertical);
            table.VisualTree = WPFTable;
        }

        private void productsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (productsListBox == null) return;
            switch((sender as ComboBox).SelectedIndex)
            {
                case 0:
                    productsListBox.ItemsPanel = table;
                    productsListBox.View = gridView;
                    break;
                case 1:
                    productsListBox.ItemTemplate = large;
                    productsListBox.ItemsPanel = largeIcons;
                    productsListBox.View = gridView;
                    break;
                default:
                    break;
            }
        }
    }
}
