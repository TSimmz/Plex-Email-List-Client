﻿using System;
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
    public partial class ScanView : UserControl
    {
        private MainViewModel _ViewModel;

        public ScanView()
        {
            InitializeComponent();
        }

        public MainViewModel ViewModel
        {
            set { _ViewModel = value; }
        }

        public void SetDataContext(ScanTabVM iViewModel)
        {
            this.DataContext = iViewModel;
        }

    }
}
