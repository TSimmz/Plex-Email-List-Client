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
using DevX.DataModel;

namespace DevX.Resources.Controls
{
    /// <summary>
    /// Interaction logic for RecursiveContextMenuItem.xaml
    /// </summary>
    public partial class RecursiveContextMenuItem : MenuItem
    {
        public RecursiveContextMenuItem()
        {
            InitializeComponent();
        }

        private void MenuItem_SubmenuOpened(object sender, RoutedEventArgs e)
        {
            ((MenuItem)sender).GetBindingExpression(MenuItem.ItemsSourceProperty).UpdateTarget();
        }
    }
}
