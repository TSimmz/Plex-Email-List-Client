﻿using DevX.Common;
using DevX.DataModel;
using DevX.ViewModel.Tests;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace DevX.Resources.Controls
{
    /// <summary>
    /// InterICommand logic for ContextMenu_DevX.xaml
    /// </summary>

    public partial class Table_DevX : UserControl
    {

        public ObservableCollection<ObservableCollection<ListBoxItemDevX>> Table_Source
        {
            get
            {
                return (ObservableCollection<ObservableCollection<ListBoxItemDevX>>)GetValue(Table_Source_Property);
            }
            set { SetValue(Table_Source_Property, value); }
        }
        public static readonly DependencyProperty Table_Source_Property =
            DependencyProperty.Register("Table_Source", typeof(ObservableCollection<ObservableCollection<ListBoxItemDevX>>),
              typeof(Table_DevX), new PropertyMetadata(new ObservableCollection<ObservableCollection<ListBoxItemDevX>>()));


        public int Table_Row
        {
            get { return (int)GetValue(Table_Row_Property); }
            set { SetValue(Table_Row_Property, value); }
        }
        public static readonly DependencyProperty Table_Row_Property =
            DependencyProperty.Register("Table_Row", typeof(int),
              typeof(Table_DevX), new PropertyMetadata((default(int))));

        public int Table_Column
        {
            get { return (int)GetValue(Table_Col_Property); }
            set { SetValue(Table_Col_Property, value); }
        }
        public static readonly DependencyProperty Table_Col_Property =
            DependencyProperty.Register("Table_Column", typeof(int),
              typeof(Table_DevX), new PropertyMetadata((default(int))));


        public ICommand NewCmd
        {
            get { return (ICommand)GetValue(NewCmd_Property); }
            set { SetValue(NewCmd_Property, value); }
        }
        public static readonly DependencyProperty NewCmd_Property =
            DependencyProperty.Register("NewCmd", typeof(ICommand),
              typeof(Table_DevX), new PropertyMetadata(default(ICommand)));

        public bool New_IsEnabled
        {
            get { return (bool)GetValue(New_IsEnabled_Property); }
            set { SetValue(New_IsEnabled_Property, value); }
        }
        public static readonly DependencyProperty New_IsEnabled_Property =
            DependencyProperty.Register("New_IsEnabled", typeof(bool),
              typeof(Table_DevX), new PropertyMetadata(default(bool)));


        public List<ContextMenu_DevX> NewMenuOptions
        {
            get { return (List<ContextMenu_DevX>)GetValue(NewMenuOptions_Property); }
            set { SetValue(NewMenuOptions_Property, value); }
        }
        public static readonly DependencyProperty NewMenuOptions_Property =
            DependencyProperty.Register("NewMenuOptions", typeof(List<ContextMenu_DevX>),
              typeof(Table_DevX), new PropertyMetadata(default(List<ContextMenu_DevX>)));


        public ICommand AddCmd
        {
            get { return (ICommand)GetValue(AddCmd_Property); }
            set { SetValue(AddCmd_Property, value); }
        }
        public static readonly DependencyProperty AddCmd_Property =
            DependencyProperty.Register("AddCmd", typeof(ICommand),
              typeof(Table_DevX), new PropertyMetadata(default(ICommand)));

        public bool Add_IsEnabled
        {
            get { return (bool)GetValue(Add_IsEnabled_Property); }
            set { SetValue(Add_IsEnabled_Property, value); }
        }
        public static readonly DependencyProperty Add_IsEnabled_Property =
            DependencyProperty.Register("Add_IsEnabled", typeof(bool),
              typeof(Table_DevX), new PropertyMetadata(default(bool)));

        public ICommand EditCmd
        {
            get { return (ICommand)GetValue(EditCmd_Property); }
            set { SetValue(EditCmd_Property, value); }
        }
        public static readonly DependencyProperty EditCmd_Property =
            DependencyProperty.Register("EditCmd", typeof(ICommand),
              typeof(Table_DevX), new PropertyMetadata(default(ICommand)));

        public bool Edit_IsEnabled
        {
            get { return (bool)GetValue(Edit_IsEnabled_Property); }
            set { SetValue(Edit_IsEnabled_Property, value); }
        }
        public static readonly DependencyProperty Edit_IsEnabled_Property =
            DependencyProperty.Register("Edit_IsEnabled", typeof(bool),
              typeof(Table_DevX), new PropertyMetadata(default(bool)));


        public ICommand DeleteCmd
        {
            get { return (ICommand)GetValue(DeleteCmd_Property); }
            set { SetValue(DeleteCmd_Property, value); }
        }
        public static readonly DependencyProperty DeleteCmd_Property =
            DependencyProperty.Register("DeleteCmd", typeof(ICommand),
              typeof(Table_DevX), new PropertyMetadata(default(ICommand)));

        public bool Delete_IsEnabled
        {
            get { return (bool)GetValue(Delete_IsEnabled_Property); }
            set { SetValue(Delete_IsEnabled_Property, value); }
        }
        public static readonly DependencyProperty Delete_IsEnabled_Property =
            DependencyProperty.Register("Delete_IsEnabled", typeof(bool),
              typeof(Table_DevX), new PropertyMetadata(default(bool)));


        public ICommand RemoveOverrideCmd
        {
            get { return (ICommand)GetValue(RemoveOverrideCmd_Property); }
            set { SetValue(RemoveOverrideCmd_Property, value); }
        }
        public static readonly DependencyProperty RemoveOverrideCmd_Property =
            DependencyProperty.Register("RemoveOverrideCmd", typeof(ICommand),
              typeof(Table_DevX), new PropertyMetadata(default(ICommand)));

        public bool RemoveOverride_IsEnabled
        {
            get { return (bool)GetValue(RemoveOverride_IsEnabled_Property); }
            set { SetValue(RemoveOverride_IsEnabled_Property, value); }
        }
        public static readonly DependencyProperty RemoveOverride_IsEnabled_Property =
            DependencyProperty.Register("RemoveOverride_IsEnabled", typeof(bool),
              typeof(Table_DevX), new PropertyMetadata(default(bool)));

        public SnapshotParameterVM ViewModel
        {
            get { return (SnapshotParameterVM)GetValue(ViewModel_Property); }
            set { SetValue(ViewModel_Property, value); }
        }
        public static readonly DependencyProperty ViewModel_Property =
            DependencyProperty.Register("ViewModel", typeof(SnapshotParameterVM),
              typeof(Table_DevX), new PropertyMetadata(default(SnapshotParameterVM)));


        private void yoloFunc(object x, object y)
        {
            int R = Table_Source.Count;
            if (Table_Source.Count > 0)
            {
                int C = Table_Source[0].Count;
                LayoutRoot.Columns.Clear();
                for (int i = -1; i < C; i++)
                {
                    LayoutRoot.Columns.Add(CreateTextBoxColumn(i));
                }
                LayoutRoot.ItemsSource = Table_Source;
            }
        }
        public Table_DevX()
        {
            InitializeComponent();
            LayoutRoot.DataContext = this;
        }

        private void LayoutRoot_Loaded(object sender, RoutedEventArgs e)
        {
            if (!Equals(null, ViewModel))
            {
                ViewModel.Changed -= yoloFunc;
                ViewModel.Changed += yoloFunc;
                yoloFunc(null, null);
            }
        }
        private DataGridTemplateColumn CreateTextBoxColumn(int i)
        {
            int index = (i >= 0) ? i : 0;
            //create a template column
            DataGridTemplateColumn templateColumn = new DataGridTemplateColumn();
            //set title of column
            //create the data template
            DataTemplate cardLayout = new DataTemplate();
            cardLayout.DataType = typeof(ListBoxItemDevX);

            //set up the stack panel
            FrameworkElementFactory spFactory = new FrameworkElementFactory(typeof(StackPanel));
            spFactory.Name = "myComboFactory";
            spFactory.SetValue(StackPanel.OrientationProperty, Orientation.Horizontal);

            templateColumn.Header = "Name";
            if (i >= 0)
            {
                templateColumn.Header = "Point " + i;
                //set up the card number textblock
                FrameworkElementFactory cardNumber = new FrameworkElementFactory(typeof(Image));
                cardNumber.SetBinding(Image.SourceProperty, new Binding("[" + index + "]." + "Image"));
                cardNumber.SetValue(ToolTipProperty, new Binding("[" + index + "]." + "Tooltip"));
                double size = 16.0;
                Thickness margin = new Thickness(0, 0, 2, 0);
                cardNumber.SetValue(WidthProperty, size);
                cardNumber.SetValue(HeightProperty, size);
                cardNumber.SetValue(MarginProperty, margin);
                spFactory.AppendChild(cardNumber);
            }

            //set up the card holder textblock
            FrameworkElementFactory cardHolder = new FrameworkElementFactory(typeof(TextBlock));
            cardHolder.SetBinding(TextBlock.TextProperty, new Binding("[" + index + "]." + ((i >= 0) ? "Item_1" : "Item_0")));
            cardHolder.SetValue(TextBlock.ToolTipProperty, new Binding("[" + index + "]." + "Tooltip"));
            spFactory.AppendChild(cardHolder);

            //set the visual tree of the data template
            cardLayout.VisualTree = spFactory;

            //set the item template to be our shiny new data template
            templateColumn.CellTemplate = cardLayout;
            // drpCreditCardNumberWpf.ItemTemplate = cardLayout;
            return templateColumn;
        }


        private void LayoutRoot_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            int column = 0;
            if (LayoutRoot.CurrentColumn.Header.ToString() != "Name")
                column = int.Parse(LayoutRoot.CurrentColumn.Header.ToString().Replace("Point ", ""));
            else
                column = -1;

            ListBoxItemDevX obj = ((ObservableCollection<ListBoxItemDevX>)LayoutRoot.CurrentItem)[(column >= 0) ? column : 0];
            Table_Column = column;
            for (int i = 0; i < Table_Source.Count; i++)
                if (Table_Source[i][0].Item_0 == obj.Item_0)
                {
                    Table_Row = i;
                    break;
                }
        }

        private void LayoutRoot_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (Edit_IsEnabled)
            {
                EditCmd.Execute(null);
            }
        }
    }
}
