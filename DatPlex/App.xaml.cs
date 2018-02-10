using System;
using System.Windows;
using DatPlex.ViewModel;
using DatPlex.GUI.Main_Window;
using System.Reflection;
using System.Diagnostics;
using System.IO;


namespace DatPlex
{

    public partial class App : Application
    {
        #region Data Fields

        public static MainViewModel MainViewModel;
        public static MainWindow MainWindow;

        #endregion

        #region Constructor

        App()
        {
            InitializeComponent();
        }

        #endregion

        #region Entry Point
        [STAThread]
        static void Main()
        {
            try
            {
                MainViewModel = new MainViewModel();

                App wApp = new App();

                MainWindow = new MainWindow();
                
                MainWindow.DataContext = MainViewModel;

                wApp.Run(MainWindow);
            }
            catch
            {
                string caption = "Plex User Update Closing";
                var result = MessageBox.Show("Plex has received an unexpected error and will now close.", caption,
                    MessageBoxButton.OK, MessageBoxImage.Question);
            }
        }

        #endregion

    }
}
