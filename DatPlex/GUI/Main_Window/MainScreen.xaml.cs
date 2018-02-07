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
using DatPlex.GUI.Child_Window;
using DatPlex.ViewModel;
using DatPlex.Common;

namespace DatPlex.GUI.Main_Window
{
    /// <summary>
    /// Interaction logic for MainScreen.xaml
    /// </summary>
    public partial class MainScreen : UserControl
    {
        private MainViewModel _ViewModel;

        public MainScreen()
        {
            InitializeComponent();
            //DataContext = new MainScreenVM();
        }

        public MainViewModel ViewModel
        {
            set { _ViewModel = value; }
        }

        public void SetDataContext(MainScreenVM iViewModel)
        {
            this.DataContext = iViewModel;
        }
    }
}
