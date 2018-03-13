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
    public partial class LogView : UserControl
    {
        public LogView()
        {
            InitializeComponent();
        }

        public void SetDataContext(MainViewModel context)
        {
            this.DataContext = context;
        }

        private void _LogViewer_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
