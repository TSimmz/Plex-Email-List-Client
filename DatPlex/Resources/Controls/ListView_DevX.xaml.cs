using DevX.Common;
using DevX.DataModel;
using DevX.ViewModel;
using Microsoft.CSharp.RuntimeBinder;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace DevX.Resources.Controls
{
    /// <summary>
    /// InterICommand logic for ContextMenu_DevX.xaml
    /// </summary>

    public partial class ListView_DevX : UserControl
    {
        private double _scrollPosition = 0.0;
        public void SelectionChangedEventt(object j, object k)
        {
            LayoutRoot.SelectedIndex = (Equals(ListView_Item, null)) ? -1 : ListView_Source.IndexOf(ListView_Item);
            if (!Equals(ListView_Item, null))
                LayoutRoot.ScrollIntoView(ListView_Item);
        }

        public BaseViewModel ViewModel
        {
            get { return (BaseViewModel)GetValue(ViewModel_Property); }
            set { SetValue(ViewModel_Property, value); }
        }
        public static readonly DependencyProperty ViewModel_Property =
            DependencyProperty.Register("ViewModel", typeof(BaseViewModel),
              typeof(ListView_DevX), new PropertyMetadata(default(BaseViewModel)));

        public ICommand SetKeyboardFocusCmd
        {
            get { return (ICommand)GetValue(SetKeyboardFocusCmd_Property); }
            set { SetValue(SetKeyboardFocusCmd_Property, value); }
        }
        public static readonly DependencyProperty SetKeyboardFocusCmd_Property =
            DependencyProperty.Register("SetKeyboardFocusCmd", typeof(ICommand),
              typeof(ListView_DevX), new PropertyMetadata(default(ICommand)));


        public ObservableCollection<ListBoxItemDevX> ListView_Source
        {
            get { return (ObservableCollection<ListBoxItemDevX>)GetValue(ListView_Source_Property); }
            set { SetValue(ListView_Source_Property, value); }
        }
        public static readonly DependencyProperty ListView_Source_Property =
            DependencyProperty.Register("ListView_Source", typeof(ObservableCollection<ListBoxItemDevX>),
              typeof(ListView_DevX), new PropertyMetadata(default(ObservableCollection<ListBoxItemDevX>)));

        public ListBoxItemDevX ListView_Item
        {
            get { return (ListBoxItemDevX)GetValue(ListView_Item_Property); }
            set { SetValue(ListView_Item_Property, value); }
        }
        public static readonly DependencyProperty ListView_Item_Property =
            DependencyProperty.Register("ListView_Item", typeof(ListBoxItemDevX),
              typeof(ListView_DevX), new PropertyMetadata(null));

        public DataGridHeadersVisibility HideHeader
        {
            get { return (DataGridHeadersVisibility)GetValue(HideHeader_Property); }
            set { SetValue(HideHeader_Property, value); }
        }
        public static readonly DependencyProperty HideHeader_Property =
            DependencyProperty.Register("HideHeader", typeof(DataGridHeadersVisibility),
              typeof(ListView_DevX), new PropertyMetadata(DataGridHeadersVisibility.All));

        private int _ColumnCount = 1;
        public int ListView_Column_Number
        {
            get { return _ColumnCount; }
            set { _ColumnCount = value; }
        }

        private string[] _ColumnNames = new string[4] { "Name", "Value", "Comment", "Comment 2" };
        public string[] ListView_ColumnNames
        {
            get { return _ColumnNames; }
            set { _ColumnNames = value; }
        }

        public string Header_0
        {
            get { return ListView_ColumnNames[0]; }
            set { ListView_ColumnNames[0] = value; }
        }
        public string Header_1
        {
            get { return ListView_ColumnNames[1]; }
            set { ListView_ColumnNames[1] = value; }
        }
        public string Header_2
        {
            get { return (ListView_ColumnNames.Length > 2) ? ListView_ColumnNames[2] : "NullName"; }
            set { ListView_ColumnNames[2] = value; }
        }
        public string Header_3
        {
            get { return (ListView_ColumnNames.Length > 3) ? ListView_ColumnNames[3] : "NullName"; }
            set { ListView_ColumnNames[3] = value; }
        }

        public Visibility Column_0_Visibility
        {
            get { return (ListView_Column_Number > 0) ? Visibility.Visible : Visibility.Collapsed; }
            set { }
        }

        public Visibility Column_1_Visibility
        {
            get { return (ListView_Column_Number > 1) ? Visibility.Visible : Visibility.Collapsed; }
        }

        public Visibility Column_2_Visibility
        {
            get { return (ListView_Column_Number > 2) ? Visibility.Visible : Visibility.Collapsed; }
        }

        public Visibility Column_3_Visibility
        {
            get { return (ListView_Column_Number > 3) ? Visibility.Visible : Visibility.Collapsed; }
        }

        public ICommand NewCmd
        {
            get { return (ICommand)GetValue(NewCmd_Property); }
            set { SetValue(NewCmd_Property, value); }
        }
        public static readonly DependencyProperty NewCmd_Property =
            DependencyProperty.Register("NewCmd", typeof(ICommand),
              typeof(ListView_DevX), new PropertyMetadata(default(ICommand)));

        public bool New_IsEnabled
        {
            get { return (bool)GetValue(New_IsEnabled_Property); }
            set { SetValue(New_IsEnabled_Property, value); }
        }
        public static readonly DependencyProperty New_IsEnabled_Property =
            DependencyProperty.Register("New_IsEnabled", typeof(bool),
              typeof(ListView_DevX), new PropertyMetadata(default(bool)));


        public List<ContextMenu_DevX> NewMenuOptions
        {
            get { return (List<ContextMenu_DevX>)GetValue(NewMenuOptions_Property); }
            set { SetValue(NewMenuOptions_Property, value); }
        }
        public static readonly DependencyProperty NewMenuOptions_Property =
            DependencyProperty.Register("NewMenuOptions", typeof(List<ContextMenu_DevX>),
              typeof(ListView_DevX), new PropertyMetadata(default(List<ContextMenu_DevX>)));


        public ICommand AddCmd
        {
            get { return (ICommand)GetValue(AddCmd_Property); }
            set { SetValue(AddCmd_Property, value); }
        }
        public static readonly DependencyProperty AddCmd_Property =
            DependencyProperty.Register("AddCmd", typeof(ICommand),
              typeof(ListView_DevX), new PropertyMetadata(default(ICommand)));

        public bool Add_IsEnabled
        {
            get { return (bool)GetValue(Add_IsEnabled_Property); }
            set { SetValue(Add_IsEnabled_Property, value); }
        }
        public static readonly DependencyProperty Add_IsEnabled_Property =
            DependencyProperty.Register("Add_IsEnabled", typeof(bool),
              typeof(ListView_DevX), new PropertyMetadata(default(bool)));

        public ICommand EditCmd
        {
            get { return (ICommand)GetValue(EditCmd_Property); }
            set { SetValue(EditCmd_Property, value); }
        }
        public static readonly DependencyProperty EditCmd_Property =
            DependencyProperty.Register("EditCmd", typeof(ICommand),
              typeof(ListView_DevX), new PropertyMetadata(default(ICommand)));

        public bool Edit_IsEnabled
        {
            get { return (bool)GetValue(Edit_IsEnabled_Property); }
            set { SetValue(Edit_IsEnabled_Property, value); }
        }
        public static readonly DependencyProperty Edit_IsEnabled_Property =
            DependencyProperty.Register("Edit_IsEnabled", typeof(bool),
              typeof(ListView_DevX), new PropertyMetadata(default(bool)));


        public ICommand DeleteCmd
        {
            get { return (ICommand)GetValue(DeleteCmd_Property); }
            set { SetValue(DeleteCmd_Property, value); }
        }
        public static readonly DependencyProperty DeleteCmd_Property =
            DependencyProperty.Register("DeleteCmd", typeof(ICommand),
              typeof(ListView_DevX), new PropertyMetadata(default(ICommand)));

        public bool Delete_IsEnabled
        {
            get { return (bool)GetValue(Delete_IsEnabled_Property); }
            set { SetValue(Delete_IsEnabled_Property, value); }
        }
        public static readonly DependencyProperty Delete_IsEnabled_Property =
            DependencyProperty.Register("Delete_IsEnabled", typeof(bool),
              typeof(ListView_DevX), new PropertyMetadata(default(bool)));


        public ICommand RemoveOverrideCmd
        {
            get { return (ICommand)GetValue(RemoveOverrideCmd_Property); }
            set { SetValue(RemoveOverrideCmd_Property, value); }
        }
        public static readonly DependencyProperty RemoveOverrideCmd_Property =
            DependencyProperty.Register("RemoveOverrideCmd", typeof(ICommand),
              typeof(ListView_DevX), new PropertyMetadata(default(ICommand)));

        public bool RemoveOverride_IsEnabled
        {
            get { return (bool)GetValue(RemoveOverride_IsEnabled_Property); }
            set { SetValue(RemoveOverride_IsEnabled_Property, value); }
        }
        public static readonly DependencyProperty RemoveOverride_IsEnabled_Property =
            DependencyProperty.Register("RemoveOverride_IsEnabled", typeof(bool),
              typeof(ListView_DevX), new PropertyMetadata(default(bool)));

        public void ListViewItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (Edit_IsEnabled)
            {
                EditCmd.Execute(null);
            }
        }

        public ListView_DevX()
        {
            InitializeComponent();
            LayoutRoot.DataContext = this;
        }
        private void setKeyboardFocus(object x, object y)
        {
            var row = LayoutRoot.ItemContainerGenerator.ContainerFromItem(LayoutRoot.SelectedItem);
            if (Equals(row, null))
                return;
            FocusManager.SetIsFocusScope(row, true);
            FocusManager.SetFocusedElement(row, row as IInputElement);

            InputManager.Current.ProcessInput(
                new KeyEventArgs(Keyboard.PrimaryDevice,
                Keyboard.PrimaryDevice.ActiveSource,
                0, Key.Left)
                { RoutedEvent = Keyboard.KeyDownEvent });
        }
        private void registerScrollPosition(object x, object y)
        {
            ScrollViewer sv = GetVisualChild<ScrollViewer>(LayoutRoot);
            if (sv != null)
            {
                _scrollPosition = sv.VerticalOffset;
            }
        }

        private void returnToScrollPosition(object x, object y)
        {
            ScrollViewer sv = GetVisualChild<ScrollViewer>(LayoutRoot);
            if (sv != null)
            {
                sv.ScrollToVerticalOffset(_scrollPosition);
            }
        }
        public void MainGrid_SearchByKey(object sender, KeyEventArgs e)
        {
            if (Key.OemPlus == e.Key || Key.Add == e.Key)
                if (Add_IsEnabled)
                    AddCmd.Execute(null);
            if (Key.OemMinus == e.Key || Key.Subtract == e.Key)
                if (Delete_IsEnabled)
                    DeleteCmd.Execute(null);
                else if (RemoveOverride_IsEnabled)
                    RemoveOverrideCmd.Execute(null);

            DataGrid dataGrid = sender as DataGrid;
            if (dataGrid.Items.Count == 0 || e.Key < Key.A || e.Key > Key.Z || Keyboard.Modifiers.HasFlag(ModifierKeys.Control))
                return;

            Func<object, bool> doesItemStartWithChar = (item) =>
            {
                ListBoxItemDevX account = item as ListBoxItemDevX;
                return account.Item_0.StartsWith(e.Key.ToString(), true, System.Globalization.CultureInfo.InvariantCulture);
            };

            int currentIndex = dataGrid.SelectedIndex;
            int foundIndex = currentIndex;

            // Search in following rows
            foundIndex = FindMatchingItemInRange(dataGrid, currentIndex, dataGrid.Items.Count - 1, doesItemStartWithChar);

            // If not found, search again in the previous rows
            if (foundIndex == -1)
            {
                foundIndex = FindMatchingItemInRange(dataGrid, 0, currentIndex - 1, doesItemStartWithChar);
            }

            if (foundIndex > -1) // Found
            {
                dataGrid.ScrollIntoView(dataGrid.Items[foundIndex]);
                dataGrid.SelectedIndex = foundIndex;
            }
        }

        private static int FindMatchingItemInRange(DataGrid dataGrid, int min, int max, Func<object, bool> doesItemStartWithChar)
        {
            for (int i = min; i <= max; i++)
            {
                if (dataGrid.SelectedIndex == i) // Skip the current selection
                    continue;

                if (doesItemStartWithChar(dataGrid.Items[i])) // If current item matches the string, return index
                    return i;
            }
            return -1;
        }

        private void LayoutRoot_Loaded(object sender, RoutedEventArgs e)
        {
            if (!Equals(ViewModel, null))
            {
                ViewModel._setKeyboardFocus -= new EventHandler(setKeyboardFocus);
                ViewModel._setKeyboardFocus += new EventHandler(setKeyboardFocus);
                ViewModel._registerScrollPosition -= new EventHandler(registerScrollPosition);
                ViewModel._registerScrollPosition += new EventHandler(registerScrollPosition);
                ViewModel._returnToScrollPosition -= new EventHandler(returnToScrollPosition);
                ViewModel._returnToScrollPosition += new EventHandler(returnToScrollPosition);
            }
        }

        private static T GetVisualChild<T>(DependencyObject parent) where T : Visual
        {
            T child = default(T);

            int numVisuals = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < numVisuals; i++)
            {
                Visual v = (Visual)VisualTreeHelper.GetChild(parent, i);
                child = v as T;
                if (child == null)
                {
                    child = GetVisualChild<T>(v);
                }
                if (child != null)
                {
                    break;
                }
            }
            return child;
        }
    }

    public class BindingProxy : Freezable
    {
        #region Overrides of Freezable

        protected override Freezable CreateInstanceCore()
        {
            return new BindingProxy();
        }

        #endregion

        public object Data
        {
            get { return (object)GetValue(DataProperty); }
            set { SetValue(DataProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Data.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DataProperty =
            DependencyProperty.Register("Data", typeof(object), typeof(BindingProxy), new UIPropertyMetadata(null));
    }

}
