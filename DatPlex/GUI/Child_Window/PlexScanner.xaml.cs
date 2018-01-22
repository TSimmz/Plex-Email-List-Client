using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Shapes;

namespace DatPlex.GUI.Child_Window
{
    /// <summary>
    /// Interaction logic for PlexScanner.xaml
    /// </summary>
    public partial class PlexScanner : Window
    {
        private int progress = 0;
        public PlexScanner()
        {
            InitializeComponent();
            //this.Owner = App.Current.MainWindow;

            //while(!this.IsVisible);

            //StartPlexScan();
        }

        private void StartPlexScan()
        {
            BackgroundWorker wBgWorker = new BackgroundWorker();
            wBgWorker.WorkerReportsProgress = true;

            wBgWorker.DoWork += delegate (object obj, DoWorkEventArgs args)
            {

            };

            wBgWorker.RunWorkerCompleted += delegate (object obj, RunWorkerCompletedEventArgs args)
            {
                mScanProgress.Value = 0;
                
            };

            wBgWorker.ProgressChanged += delegate (object obj, ProgressChangedEventArgs args)
            {

            };
        }

        public void UpdateProgress(BackgroundWorker bw, int p)
        {
            progress = (p == 1) ? (progress + 1) : (progress + p);

            bw.ReportProgress(Convert.ToInt32(((decimal)progress / 100)));  // Look up C# map function for this
        }

        private void Finish_Click(object obj, RoutedEventArgs e)
        {
            this.DialogResult = true;
            this.Close();
        }

        private void Cancel_Click(object obj, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
    }
}
