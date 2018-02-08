using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;
using System.Threading.Tasks;
using DatPlex.Common;

namespace DatPlex.ViewModel
{
    public class PlexScannerVM : BaseViewModel
    {
        public PlexScannerVM()
        {
            IsScanComplete = false;
            ScanInProgressVisibility = Visibility.Visible;
            ScanCompleteVisibility = Visibility.Hidden;
        }

        DelegateCommand mNext_Cmd;
        public ICommand Next_Cmd
        {
            get
            {
                if (null == mNext_Cmd)
                    mNext_Cmd = new DelegateCommand(Next);
                return mNext_Cmd;
            }
        }

        public void Next()
        {
            //TODO: Next method

            ScanInProgressVisibility = Visibility.Hidden;
            ScanCompleteVisibility = Visibility.Visible;
        }

        DelegateCommand mFinish_Cmd;
        public ICommand Finish_Cmd
        {
            get
            {
                if (null == mFinish_Cmd)
                    mFinish_Cmd = new DelegateCommand(Finish_Scan);

                return mFinish_Cmd;
            }
        }

        public void Finish_Scan()
        {
            //TODO: Finish method
        }

        private bool _IsScanComplete;
        public bool IsScanComplete
        {
            get { return _IsScanComplete; }
            set
            {
                _IsScanComplete = value;
                OnPropertyChanged();
            }
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
