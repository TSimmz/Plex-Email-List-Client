using DevX.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace DevX.Resources.Controls
{
    /// <summary>
    /// Interaction logic for FolderTreeControl.xaml
    /// </summary>
    public partial class FolderTreeControl : UserControl
    {

        public ObservableCollection<TreeViewModel> ItemsSource_FolderTree
        {
            get { return (ObservableCollection<TreeViewModel>)GetValue(FolderTree_Source_Property); }
            set { SetValue(FolderTree_Source_Property, value); }
        }
        public static readonly DependencyProperty FolderTree_Source_Property =
            DependencyProperty.Register("ItemsSource_FolderTree", typeof(ObservableCollection<TreeViewModel>),
              typeof(FolderTreeControl), new PropertyMetadata(default(ObservableCollection<TreeViewModel>)));

        private void ScrollViewer_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            ScrollViewer scv = (ScrollViewer)sender;
            scv.ScrollToVerticalOffset(scv.VerticalOffset - e.Delta);
            e.Handled = true;
        }

        public TreeViewModel SelectedItem_FolderTree
        {
            get { return (TreeViewModel)GetValue(SelectedItem_Source_Property); }
            set { SetValue(SelectedItem_Source_Property, value); }
        }
        public static readonly DependencyProperty SelectedItem_Source_Property =
            DependencyProperty.Register("SelectedItem_FolderTree", typeof(TreeViewModel),
              typeof(FolderTreeControl), new PropertyMetadata(default(TreeViewModel)));

        public bool LoadingVisiblity_FolderTree
        {
            get { return (bool)GetValue(LoadingVisibility_Source_Property); }
            set { SetValue(SelectedItem_Source_Property, value); }
        }

        public static readonly DependencyProperty LoadingVisibility_Source_Property =
            DependencyProperty.Register("LoadingVisiblity_FolderTree", typeof(bool),
              typeof(FolderTreeControl), new PropertyMetadata(true));

        private void OnSelectedItemChanged(object sender, RoutedEventArgs e)
        {
            if (mTreeView.SelectedItem is TreeViewModel)
                SelectedItem_FolderTree = (TreeViewModel)mTreeView.SelectedItem;
        }

        public ICommand AddFolder_FolderTree
        {
            get { return (ICommand)GetValue(AddFolder_Property); }
            set { SetValue(SelectedItem_Source_Property, value); }
        }
        public static readonly DependencyProperty AddFolder_Property =
            DependencyProperty.Register("AddFolder_FolderTree", typeof(ICommand),
              typeof(FolderTreeControl), new PropertyMetadata(default(ICommand)));
        
        public ICommand RemoveFolder_FolderTree
        {
            get { return (ICommand)GetValue(RemoveFolder_Property); }
            set { SetValue(SelectedItem_Source_Property, value); }
        }

        public static readonly DependencyProperty RemoveFolder_Property =
            DependencyProperty.Register("RemoveFolder_FolderTree", typeof(ICommand),
              typeof(FolderTreeControl), new PropertyMetadata(default(ICommand)));

        public bool Enable_RightClickMenu
        {
            get { return (bool)GetValue(Enable_Source_Property); }
            set { SetValue(SelectedItem_Source_Property, value); }
        }

        public static readonly DependencyProperty Enable_Source_Property =
            DependencyProperty.Register("Enable_RightClickMenu", typeof(bool),
              typeof(FolderTreeControl), new PropertyMetadata(true));

        public FolderTreeControl()
        {
            InitializeComponent();
            ElementRoot.DataContext = this;
        }
    }
}
