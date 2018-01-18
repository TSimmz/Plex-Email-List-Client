using DevX.DataModel;
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
    /// Interaction logic for TreeView_DevX.xaml
    /// </summary>
    public partial class TreeView_DevX : UserControl
    {
        public ObservableCollection<TreeViewModel> TreeView_Source
        {
            get { return (ObservableCollection<TreeViewModel>)GetValue(TreeView_Source_Property); }
            set { SetValue(TreeView_Source_Property, value); }
        }
        public static readonly DependencyProperty TreeView_Source_Property =
            DependencyProperty.Register("TreeView_Source", typeof(ObservableCollection<TreeViewModel>),
              typeof(TreeView_DevX), new PropertyMetadata(default(ObservableCollection<TreeViewModel>)));

        public TreeViewModel TreeView_Item
        {
            get { return (TreeViewModel)GetValue(TreeView_Item_Property); }
            set { SetValue(TreeView_Item_Property, value); }
        }
        public static readonly DependencyProperty TreeView_Item_Property =
            DependencyProperty.Register("TreeView_Item", typeof(TreeViewModel),
              typeof(TreeView_DevX), new PropertyMetadata(default(TreeViewModel)));





        public ICommand tvNewCmd
        {
            get { return (ICommand)GetValue(tvNewCmd_Property); }
            set { SetValue(tvNewCmd_Property, value); }
        }
        public static readonly DependencyProperty tvNewCmd_Property =
            DependencyProperty.Register("tvNewCmd", typeof(ICommand),
              typeof(TreeView_DevX), new PropertyMetadata(default(ICommand)));

        public bool tvNew_IsEnabled
        {
            get { return (bool)GetValue(tvNew_IsEnabled_Property); }
            set { SetValue(tvNew_IsEnabled_Property, value); }
        }
        public static readonly DependencyProperty tvNew_IsEnabled_Property =
            DependencyProperty.Register("tvNew_IsEnabled", typeof(bool),
              typeof(TreeView_DevX), new PropertyMetadata(default(bool)));


        public List<ATGProc_DataProcess> tvNewMenuOptions
        {
            get { return (List<ATGProc_DataProcess>)GetValue(tvNewMenuOptions_Property); }
            set { SetValue(tvNewMenuOptions_Property, value); }
        }
        public static readonly DependencyProperty tvNewMenuOptions_Property =
            DependencyProperty.Register("tvNewMenuOptions", typeof(List<ATGProc_DataProcess>),
              typeof(TreeView_DevX), new PropertyMetadata(default(List<ATGProc_DataProcess>)));


        public ICommand tvAddCmd
        {
            get { return (ICommand)GetValue(tvAddCmd_Property); }
            set { SetValue(tvAddCmd_Property, value); }
        }
        public static readonly DependencyProperty tvAddCmd_Property =
            DependencyProperty.Register("tvAddCmd", typeof(ICommand),
              typeof(TreeView_DevX), new PropertyMetadata(default(ICommand)));

        public bool tvAdd_IsEnabled
        {
            get { return (bool)GetValue(tvAdd_IsEnabled_Property); }
            set { SetValue(tvAdd_IsEnabled_Property, value); }
        }
        public static readonly DependencyProperty tvAdd_IsEnabled_Property =
            DependencyProperty.Register("tvAdd_IsEnabled", typeof(bool),
              typeof(TreeView_DevX), new PropertyMetadata(default(bool)));


        public ICommand tvEditCmd
        {
            get { return (ICommand)GetValue(tvEditCmd_Property); }
            set { SetValue(tvEditCmd_Property, value); }
        }
        public static readonly DependencyProperty tvEditCmd_Property =
            DependencyProperty.Register("tvEditCmd", typeof(ICommand),
              typeof(TreeView_DevX), new PropertyMetadata(default(ICommand)));

        public bool tvEdit_IsEnabled
        {
            get { return (bool)GetValue(tvEdit_IsEnabled_Property); }
            set { SetValue(tvEdit_IsEnabled_Property, value); }
        }
        public static readonly DependencyProperty tvEdit_IsEnabled_Property =
            DependencyProperty.Register("tvEdit_IsEnabled", typeof(bool),
              typeof(TreeView_DevX), new PropertyMetadata(default(bool)));

        public ICommand tvDeleteCmd
        {
            get { return (ICommand)GetValue(tvDeleteCmd_Property); }
            set { SetValue(tvDeleteCmd_Property, value); }
        }
        public static readonly DependencyProperty tvDeleteCmd_Property =
            DependencyProperty.Register("tvDeleteCmd", typeof(ICommand),
              typeof(TreeView_DevX), new PropertyMetadata(default(ICommand)));

        public bool tvDelete_IsEnabled
        {
            get { return (bool)GetValue(tvDelete_IsEnabled_Property); }
            set { SetValue(tvDelete_IsEnabled_Property, value); }
        }
        public static readonly DependencyProperty tvDelete_IsEnabled_Property =
            DependencyProperty.Register("tvDelete_IsEnabled", typeof(bool),
              typeof(TreeView_DevX), new PropertyMetadata(default(bool)));


        public ICommand tvRemoveOverrideCmd
        {
            get { return (ICommand)GetValue(tvRemoveOverrideCmd_Property); }
            set { SetValue(tvRemoveOverrideCmd_Property, value); }
        }
        public static readonly DependencyProperty tvRemoveOverrideCmd_Property =
            DependencyProperty.Register("tvRemoveOverrideCmd", typeof(ICommand),
              typeof(TreeView_DevX), new PropertyMetadata(default(ICommand)));

        public bool tvRemoveOverride_IsEnabled
        {
            get { return (bool)GetValue(tvRemoveOverride_IsEnabled_Property); }
            set { SetValue(tvRemoveOverride_IsEnabled_Property, value); }
        }
        public static readonly DependencyProperty tvRemoveOverride_IsEnabled_Property =
            DependencyProperty.Register("tvRemoveOverride_IsEnabled", typeof(bool),
              typeof(TreeView_DevX), new PropertyMetadata(default(bool)));

        public TreeView_DevX()
        {
            InitializeComponent();
            LayoutRoot.DataContext = this;
        }

        private void LayoutRoot_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            ScrollViewer scv = (ScrollViewer)sender;
            scv.ScrollToVerticalOffset(scv.VerticalOffset - e.Delta);
            e.Handled = true;
        }

        private void LayoutRoot_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            TreeViewItem treeViewItem = VisualUpwardSearch(e.OriginalSource as DependencyObject);

            if (treeViewItem != null)
            {
                treeViewItem.Focus();
                e.Handled = true;
            }
        }

        static TreeViewItem VisualUpwardSearch(DependencyObject source)
        {
            while (source != null && !(source is TreeViewItem))
                source = VisualTreeHelper.GetParent(source);

            return source as TreeViewItem;
        }
    }
}
