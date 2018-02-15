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

    public partial class MainWindow : Window
    {
        #region Data Fields

        MainViewModel _ViewModel;

        #endregion

        #region Constructor

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

            _ViewModel = App.MainViewModel;

            _ScanView.ViewModel = _ViewModel;
            _LibraryView.ViewModel = _ViewModel;
            _FriendsView.ViewModel = _ViewModel;

            _ScanView.SetDataContext(_ViewModel.ScanTabVM);
            _LibraryView.SetDataContext(_ViewModel.LibraryTabVM);
            _FriendsView.SetDataContext(_ViewModel.FriendsTabVM);

            //_ViewModel.TaskStarting += TaskStarted;
            //_ViewModel.ProgressChanged += ProgressChanged;
            //_ViewModel.TaskCompleted += TaskCompleted;



        }

        #endregion
    }
}
