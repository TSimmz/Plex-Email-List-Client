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
using DatPlex.GUI.Child_Window;
using DatPlex.GUI.Main_Window;
using DatPlex.Common;

namespace DatPlex
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainViewModel mViewModel;

        //MainViewModel mViewModel;
        public MainWindow()
        {
            try
            {
                InitializeComponent();
                //DataContext = new MainViewModel();
            }
            catch (Exception e)
            {
                string message = e.ToString();
                string caption = "Plex Updater Closing";
                var result = MessageBox.Show(message, caption, MessageBoxButton.YesNo, MessageBoxImage.Question);
            }

            mViewModel = App.MainViewModel;

            mLoginView.ViewModel = mViewModel;
            mMainScreenView.ViewModel = mViewModel;

            //mViewModel.TaskStarting += TaskStarted;
            //mViewModel.ProgressChanged += ProgressChanged;
            //mViewModel.TaskCompleted += TaskCompleted;

            mLoginView.SetDataContext(mViewModel.LoginVM);
            mMainScreenView.SetDataContext(mViewModel.MainScreenVM);
        }
    }
}
