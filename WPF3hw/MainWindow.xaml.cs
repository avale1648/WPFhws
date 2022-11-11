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

namespace WPF3hw
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string text = string.Empty;
        private int count = 0;
        public MainWindow()
        {
            InitializeComponent();
            textBox.Text = string.Empty;
            maxTextBox.Text = "0";
            passwordBox.IsEnabled = false;
            checkBoxUnlimited.IsChecked = true; maxTextBox.IsEnabled = false;
        }

        private void buttonPaste_Click(object sender, RoutedEventArgs e)
        {
            if (text == string.Empty) return;
            passwordBox.Password = text;
        }

        private void buttonClear_Click(object sender, RoutedEventArgs e)
        {
            passwordBox.Password = string.Empty;
        }

        private void buttonShow_Click(object sender, RoutedEventArgs e)
        {
        }

        private void buttonCopy_Click(object sender, RoutedEventArgs e)
        {
            if (textBox.Text == string.Empty) return;
            text = textBox.Text;
        }

        private void passwordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            count++;
            changesLabel.Content = $"Changes: {count}";
        }

        private void comboBoxMask_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboBoxMask.SelectedIndex == 0)
                passwordBox.PasswordChar = '@';
            if (comboBoxMask.SelectedIndex == 1)
                passwordBox.PasswordChar = '*';
            if (comboBoxMask.SelectedIndex == 2)
                passwordBox.PasswordChar = '#';
        }

        private void checkBoxUnlimited_Checked(object sender, RoutedEventArgs e)
        {
            maxTextBox.IsEnabled = !maxTextBox.IsEnabled;
            if(maxTextBox.IsEnabled)
                textBox.MaxLength = int.Parse(maxTextBox.Text);
        }

        private void checkBoxUnlimited_Click(object sender, RoutedEventArgs e)
        {
            maxTextBox.IsEnabled = !maxTextBox.IsEnabled;
            if (maxTextBox.IsEnabled)
                textBox.MaxLength = int.Parse(maxTextBox.Text);
        }
    }
}
