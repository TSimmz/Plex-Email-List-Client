using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Threading.Tasks;

namespace DatPlex.ViewModel
{
    public class PlexScannerVM : BaseViewModel
    {
        public PlexScannerVM()
        {
            ScanInProgressVisibility = Visibility.Visible;
            ScanCompleteVisibility = Visibility.Hidden;
        }

        private Visibility _ScanInProgressVisibility;
        public Visibility ScanInProgressVisibility
        {
            get { return _ScanInProgressVisibility; }
            set
            {
                _ScanInProgressVisibility = value;
                OnPropertyChanged();
            }
        }

        private Visibility _ScanCompleteVisibility;
        public Visibility ScanCompleteVisibility
        {
            get { return _ScanCompleteVisibility; }
            set
            {
                _ScanCompleteVisibility = value;
                OnPropertyChanged();
            }
        }
    }
}
