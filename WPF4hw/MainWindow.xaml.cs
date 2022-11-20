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

namespace WPF4hw
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        GridView GV = new GridView();
        DataTemplate DT_Big;
        DataTemplate DT_Small;
        DataTemplate DT_List;
        ItemsPanelTemplate IPT_Tabel;
        ItemsPanelTemplate IPT_Big;
        ItemsPanelTemplate IPT_Small;
        ItemsPanelTemplate IPT_List;
        public MainWindow()
        {
            InitializeComponent();
            Girland.Items.Add(new AutoList("Ford", "Focus", @"images\1.jpg"));
            Girland.Items.Add(new AutoList("Ford", "Unfocus", @"images\2.jpg"));
            Girland.Items.Add(new AutoList("Ford", "Refocus", @"images\3.jpg"));
            Girland.Items.Add(new AutoList("Ford", "Prefocus", @"images\4.jpg"));
            Girland.Items.Add(new AutoList("Ford", "Nonfocus", @"images\5.jpg"));
            Girland.Items.Add(new AutoList("Ford", "Infocus", @"images\6.jpg"));
            Girland.Items.Add(new AutoList("Ford", "Onfocus", @"images\7.jpg"));
            Girland.Items.Add(new AutoList("Ford", "Byfocus", @"images\8.jpg"));
            Girland.Items.Add(new AutoList("Ford", "Forfocus", @"images\9.jpg"));
            Girland.Items.Add(new AutoList("Ford", "Tofocus", @"images\10.jpg"));

            CreateTableView();
            CreateBig();
            CreateSmall();
            CreateList();
        }

        private void CreateTableView()
        {
            
            GridViewColumn col1 = new GridViewColumn();
            GridViewColumnHeader col1H = new GridViewColumnHeader();
            col1H.Content = "Brand";
            col1.Header = col1H;
            col1.DisplayMemberBinding = new Binding("Brand");

            GridViewColumn col2 = new GridViewColumn();
            GridViewColumnHeader col2H = new GridViewColumnHeader();
            col2H.Content = "Model";
            col2.Header = col2H;
            col2.DisplayMemberBinding = new Binding("Model");

            GridViewColumn col3 = new GridViewColumn();
            col3.Header = "Photo";

            DataTemplate DT_Cell = new DataTemplate();
            FrameworkElementFactory ImageF = new FrameworkElementFactory(typeof(Image));
            ImageF.SetValue(Image.SourceProperty, new Binding("Photo"));
            ImageF.SetValue(Image.WidthProperty, Width = 60);
            DT_Cell.VisualTree = ImageF; 
            col3.CellTemplate = DT_Cell;

            GV.Columns.Add(col1);
            GV.Columns.Add(col2);
            GV.Columns.Add(col3);

            Girland.View = GV;
            IPT_Tabel = new ItemsPanelTemplate();
            FrameworkElementFactory WPF_Table = new FrameworkElementFactory(typeof(StackPanel));
            WPF_Table.SetValue(WrapPanel.OrientationProperty, Orientation.Vertical);
            IPT_Tabel.VisualTree = WPF_Table;

        }

        private void CreateBig()
        {
            FrameworkElementFactory StackPanelF_Big = new FrameworkElementFactory(typeof(StackPanel));
            StackPanelF_Big.SetValue(StackPanel.BackgroundProperty, Background = new SolidColorBrush(Colors.Beige));

            FrameworkElementFactory ImageFB = new FrameworkElementFactory(typeof(Image));
            ImageFB.SetValue(Image.SourceProperty, new Binding("Photo"));
            ImageFB.SetValue(Image.WidthProperty, Width = 200);
            StackPanelF_Big.AppendChild(ImageFB);

            FrameworkElementFactory LableF = new FrameworkElementFactory(typeof(Label));
            LableF.SetValue(Label.ContentProperty, new Binding("Brand"));
            LableF.SetValue(Label.WidthProperty, Width = 80);
            StackPanelF_Big.AppendChild(LableF);

            FrameworkElementFactory LableC = new FrameworkElementFactory(typeof(Label));
            LableC.SetValue(Label.ContentProperty, new Binding("Model"));
            LableC.SetValue(Label.WidthProperty, Width = 80);
            StackPanelF_Big.AppendChild(LableC);

            DT_Big = new DataTemplate();

            DT_Big.VisualTree = StackPanelF_Big;

            IPT_Big = new ItemsPanelTemplate();

            FrameworkElementFactory WPF_Big = new FrameworkElementFactory(typeof(WrapPanel));
            WPF_Big.SetValue(WrapPanel.OrientationProperty, Orientation.Horizontal);

            Binding B_W = new Binding("ActualWidth");
            B_W.Source = this.Girland;
            WPF_Big.SetValue(WrapPanel.WidthProperty, B_W);

            Binding B_H = new Binding("ActualHeight");
            B_H.Source = this.Girland;
            WPF_Big.SetValue(WrapPanel.HeightProperty, B_H);

            IPT_Big.VisualTree = WPF_Big;
        }

        private void CreateSmall()
        {
            FrameworkElementFactory StackPanelF_Small = new FrameworkElementFactory(typeof(StackPanel));
            StackPanelF_Small.SetValue(StackPanel.BackgroundProperty, Background = new SolidColorBrush(Colors.Beige));
            
            FrameworkElementFactory ImageFS = new FrameworkElementFactory(typeof(Image));
            ImageFS.SetValue(Image.SourceProperty, new Binding("Photo"));
            ImageFS.SetValue(Image.WidthProperty, Width = 20);
            StackPanelF_Small.AppendChild(ImageFS);

            FrameworkElementFactory LableF = new FrameworkElementFactory(typeof(Label));
            LableF.SetValue(Label.ContentProperty, new Binding("Brand"));
            LableF.SetValue(Label.WidthProperty, Width = 80);
            StackPanelF_Small.AppendChild(LableF);

            FrameworkElementFactory LableC = new FrameworkElementFactory(typeof(Label));
            LableC.SetValue(Label.ContentProperty, new Binding("Model"));
            LableC.SetValue(Label.WidthProperty, Width = 80);
            StackPanelF_Small.AppendChild(LableC);

            DT_Small = new DataTemplate();

            DT_Small.VisualTree = StackPanelF_Small;

            IPT_Small = new ItemsPanelTemplate();

            FrameworkElementFactory WPF_Small = new FrameworkElementFactory(typeof(WrapPanel));
            WPF_Small.SetValue(WrapPanel.OrientationProperty, Orientation.Horizontal);

            Binding S_W = new Binding("ActualWidth");
            S_W.Source = this.Girland;
            WPF_Small.SetValue(WrapPanel.WidthProperty, S_W);

            Binding S_H = new Binding("ActualHeight");
            S_H.Source = this.Girland;
            WPF_Small.SetValue(WrapPanel.HeightProperty, S_H);

            IPT_Small.VisualTree = WPF_Small;
        }

        public void CreateList()
        {
            FrameworkElementFactory StackPanelF_List = new FrameworkElementFactory(typeof(StackPanel));
                       
            FrameworkElementFactory LableC = new FrameworkElementFactory(typeof(Label));
            LableC.SetValue(Label.ContentProperty, new Binding("Model"));
            StackPanelF_List.AppendChild(LableC);

            DT_List = new DataTemplate();

            DT_List.VisualTree = StackPanelF_List;

            IPT_List = new ItemsPanelTemplate();

            FrameworkElementFactory WPF_List = new FrameworkElementFactory(typeof(StackPanel));
           
            Binding S_H = new Binding("ActualHeight");
            S_H.Source = this.Girland;
            WPF_List.SetValue(WrapPanel.HeightProperty, S_H);

            IPT_List.VisualTree = WPF_List;

        }

        private void ViewType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Girland == null) return;
            switch (((ComboBox)sender).SelectedIndex)
            {
                case 0:
                    Girland.ItemsPanel = IPT_Tabel;
                    Girland.View = GV;
                    break;

                case 1:
                    Girland.ItemTemplate = DT_Big;
                    Girland.ItemsPanel = IPT_Big;
                    Girland.View = null;
                    break;
                
                case 2:
                    Girland.ItemTemplate = DT_Small;
                    Girland.ItemsPanel = IPT_Small;
                    Girland.View = null;
                    break;

                case 3:
                    Girland.ItemTemplate = DT_List;
                    Girland.ItemsPanel = IPT_List;
                    Girland.View = null;
                    break;

                default:
                    break;

            }
        }

    }
}
