using System;
using System.Windows;
using System.Collections.Generic;
using DatPlex.Common;

namespace DatPlex.GUI.Child_Window
{
    /// <summary>
    /// Interaction logic for ServerInformation.xaml
    /// </summary>
    public partial class CustomFriend : Window
    {
        public CustomFriend()
        {
            InitializeComponent();
        }

        private void OK_Click(object obj, RoutedEventArgs e)
        {
            DialogResult = true;
            return;
        }

        private void Cancel_Click(object obj, RoutedEventArgs e)
        {
            DialogResult = false;
            this.Close();
            return;
        }
    }
}
