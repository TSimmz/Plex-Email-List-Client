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
    /// Interaction logic for LogView.xaml
    /// </summary>
    public partial class LogView : UserControl
    {
        MainViewModel _ViewModel;

        public LogView()
        {
            InitializeComponent();
        }

        public MainViewModel ViewModel
        {
            set { _ViewModel = value; }
        }

        public void SetDataContext(MainViewModel iViewModel)
        {
            this.DataContext = iViewModel;
        }
    }
}
