using System;
using System.Windows;
using DatPlex.ViewModel;
using DatPlex.GUI.Main_Window;
using System.Reflection;
using System.Diagnostics;
using System.IO;


namespace DatPlex
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static MainViewModel mMainViewModel;
        public static MainWindow mMainWindow;

        App()
        {
            InitializeComponent();
        }

        [STAThread]
        static void Main()
        {
            try
            {
                mMainViewModel = new MainViewModel();

                App wApp = new App();

                mMainWindow = new MainWindow();
                
                mMainWindow.DataContext = mMainViewModel;
                wApp.Run(mMainWindow);
            }
            catch
            {
                string caption = "Plex User Update Closing";
                var result = MessageBox.Show("Plex has received an unexpected error and will now close.", caption,
                    MessageBoxButton.OK, MessageBoxImage.Question);
            }
        }


    }
}
