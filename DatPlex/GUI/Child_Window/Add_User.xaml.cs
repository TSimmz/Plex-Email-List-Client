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
using System.Windows.Shapes;
using DatPlex.ViewModel;

namespace DatPlex.GUI.Child_Window
{
    /// <summary>
    /// Interaction logic for Add_User.xaml
    /// </summary>
    public partial class Add_User : Window
    {
        public Add_User()
        {
            InitializeComponent();
            DataContext = new Add_UserVM();
        }


    }
}
