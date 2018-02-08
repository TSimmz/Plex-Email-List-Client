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
using DatPlex.Common;

namespace DatPlex.GUI.Child_Window
{
    /// <summary>
    /// Interaction logic for ScanInProgress.xaml
    /// </summary>
    public partial class ScanInProgress : UserControl
    {
        public ScanInProgress()
        {
            InitializeComponent();
        }

        private MainViewModel _ViewModel;
        public MainViewModel ViewModel
        {
            set { _ViewModel = value; }
        }
        public void SetDataContext(PlexScannerVM iViewModel)
        {
            this.DataContext = iViewModel;
        }
    }
}
