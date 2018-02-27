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
        NotifyIcon _NotifyIcon;
        #endregion

        #region Constructor

        public MainWindow()
        {
            try
            {
                InitializeComponent();
                //InitializeSystemTray();

            }
            catch (Exception e)
            {
                string message = e.ToString();
                string caption = "Plex Updater Closing";
                var result = System.Windows.MessageBox.Show(message, caption, MessageBoxButton.YesNo, MessageBoxImage.Question);
            }

            _ViewModel = App.MainViewModel;

            _ScanView.ViewModel = _ViewModel;
            _SharingView.ViewModel = _ViewModel;

            _ScanView.SetDataContext(_ViewModel.ScanTabVM);
            _SharingView.SetDataContext(_ViewModel.SharingTabVM);

            //_ViewModel.TaskStarting += TaskStarted;
            //_ViewModel.ProgressChanged += ProgressChanged;
            //_ViewModel.TaskCompleted += TaskCompleted;
        }

        //protected void InitializeSystemTray()
        //{
        //    _NotifyIcon = new NotifyIcon();
        //    _NotifyIcon.Icon = new Icon("../../Images/test_icon.ico");
        //    _NotifyIcon.BalloonTipText = "Plex Email Updater";
        //    _NotifyIcon.BalloonTipTitle = "Plex Email Updater";

        //    _NotifyIcon.DoubleClick += delegate (object sender, EventArgs e)
        //    {
        //        this.Show();

        //        if (this.WindowState == WindowState.Normal)
        //            this.WindowState = WindowState.Minimized;
        //        else
        //            this.WindowState = WindowState.Normal;
        //    };
        //    _NotifyIcon.Visible = true;
        //}

        protected override void OnStateChanged(EventArgs e)
        {
            if (WindowState == WindowState.Minimized)
                this.Hide();

            base.OnStateChanged(e);
        }


        #endregion
    }
}
