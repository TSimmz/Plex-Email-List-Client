using System;
using System.Windows;
using System.Windows.Forms;
using System.Drawing;
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
                var result = System.Windows.MessageBox.Show(message, caption, MessageBoxButton.YesNo, MessageBoxImage.Question);
            }

            _ViewModel = App.MainViewModel;

            _ScanView.SetDataContext(_ViewModel);
            _SharingView.SetDataContext(_ViewModel);
            _LogView.SetDataContext(_ViewModel);

            //_ViewModel.TaskStarting += TaskStarted;
            //_ViewModel.ProgressChanged += ProgressChanged;
            //_ViewModel.TaskCompleted += TaskCompleted;
        }

        #endregion
    }
}
