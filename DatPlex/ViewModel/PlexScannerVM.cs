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

            Progress_Lbl = "Progress";
            NewUsers_Lbl = "New Users";
            NewItems_Lbl = "New Items";
            RemItems_Lbl = "Rem Items";
        }

        private string mProgress_Lbl;
        public string Progress_Lbl
        {
            get { return mProgress_Lbl; }
            set
            {
                if (mProgress_Lbl == value)
                    return;
                mProgress_Lbl = value;
                OnPropertyChanged();
            }
        }

        private string mNewUsers_Lbl;
        public string NewUsers_Lbl
        {
            get { return mNewUsers_Lbl; }
            set
            {
                if (mNewUsers_Lbl == value)
                    return;
                mNewUsers_Lbl = value;
                OnPropertyChanged();
            }
        }

        private string mNewItems_Lbl;
        public string NewItems_Lbl
        {
            get { return mNewItems_Lbl; }
            set
            {
                if (mNewItems_Lbl == value)
                    return;
                mNewItems_Lbl = value;
                OnPropertyChanged();
            }
        }

        private string mRemItems_Lbl;
        public string RemItems_Lbl
        {
            get { return mRemItems_Lbl; }
            set
            {
                if (mRemItems_Lbl == value)
                    return;
                mRemItems_Lbl = value;
                OnPropertyChanged();
            }
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
