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
using DatPlex.ViewModel;

namespace DatPlex.GUI.Main_Window
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainViewModel mViewModel;
        public MainWindow()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception e)
            {
                string message = e.ToString();
                string caption = "Plex Updater Closing";
                var result = MessageBox.Show(message, caption, MessageBoxButton.YesNo, MessageBoxImage.Question);
            }

            mViewModel = App.mMainViewModel;
        }

        private void plex_account_combo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void units_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void listView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void add_btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void rem_btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void manual_rb_Checked(object sender, RoutedEventArgs e)
        {
            //if ((bool)manual_rb.IsChecked)
            //{
            //    timer.IsEnabled = false;
            //    units.IsEnabled = false;
            //    scan_button.IsEnabled = true;
            
                
            //}
        }

        private void auto_rb_Checked(object sender, RoutedEventArgs e)
        {
            //if ((bool)auto_rb.IsChecked)
            //{
            //    timer.IsEnabled = true;
            //    units.IsEnabled = true;
            //    scan_button.IsEnabled = false;
            //}
        }


    }
}
