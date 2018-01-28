using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DatPlex.Common;
using GalaSoft.MvvmLight.Ioc;

namespace DatPlex.ViewModel
{
    public class ViewModelLocator : BaseViewModel
    {
        private MainViewModel _main;
             
        public ViewModelLocator()
        {
            _main = new MainViewModel();
        }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
    
        public MainViewModel Main
        {
            get
            {
                return _main;
            }
        }
    }
}