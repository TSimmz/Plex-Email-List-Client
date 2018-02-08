using DevX.Common;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace DevX.Resources.Controls
{
    /// <summary>
    /// Interaction logic for TextBlockDevX.xaml
    /// </summary>
    public partial class TextBlockDevX : UserControl
    {

        public ObservableCollection<ListBoxItemDevX> RowList
        {
            get
            {
                return (ObservableCollection<ListBoxItemDevX>)GetValue(RowList_Property);
            }
            set
            {
                SetValue(RowList_Property, value);
            }
        }
        public static readonly DependencyProperty RowList_Property =
            DependencyProperty.Register("RowList", typeof(ObservableCollection<ListBoxItemDevX>),
              typeof(TextBlockDevX), new PropertyMetadata(default(ObservableCollection<ListBoxItemDevX>)));
        

        

        public TextBlockDevX()
        {
            InitializeComponent();
            ListOfRows.DataContext = this;
        }
    }
}
