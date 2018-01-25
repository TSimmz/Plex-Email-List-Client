using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using DatPlex.Common;
using DatPlex.DataModel;
using DatPlex.GUI.Main_Window;
using DatPlex.GUI.Child_Window;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace DatPlex.ViewModel
{
    public class MainScreenVM : ViewModelBase
    {
        #region Data Fields

        Window Parent;

        public BackgroundWorker BgWorker;
        public event EventHandler TaskStarting = (s, e) => { };

        //int mFileViewIndex = -1;

        #endregion Data Fields

        #region Constructor

        public MainScreenVM()
        {
            BgWorker = new BackgroundWorker();
            BgWorker.WorkerReportsProgress = true;
        }

        public void SetParent(Window iParent)
        {
            Parent = iParent;
        }

        #endregion Constructor

        #region General

        private string mWindowTitle = "Plex Email Updates";
        public string WindowTitle
        {
            get { return mWindowTitle; }
            set
            {
                mWindowTitle = value;
                RaisePropertyChanged("WindowTitle");
            }
        }

        #endregion General

        DelegateCommand mAdd_User_Cmd;
        public ICommand Add_User_Cmd
        {
            get
            {
                if (null == mAdd_User_Cmd)
                    mAdd_User_Cmd = new DelegateCommand(Add_User_Button);
                return mAdd_User_Cmd;
            }
        }

        public void Add_User_Button(object obj)
        {
            Console.WriteLine("Add Button Pressed");

            Add_User mAddWindow = new Add_User();
            Add_UserVM mAddViewModel;

            if (SharedUsers_SelIndex != 0)
                mAddViewModel = new Add_UserVM(SharedUsers[SharedUsers_SelIndex]);
            else
                mAddViewModel = new Add_UserVM();

            mAddWindow.DataContext = mAddViewModel;
            mAddWindow.Show();
        }

        DelegateCommand mDel_User_Cmd;
        public ICommand Del_User_Cmd
        {
            get
            {
                if (null == mDel_User_Cmd)
                    mDel_User_Cmd = new DelegateCommand(Del_User_Button);
                return mDel_User_Cmd;
            }
        }

        public void Del_User_Button(object obj)
        {
            Console.WriteLine("Remove Button Pressed");
        }

        DelegateCommand mScan_Plex_Cmd;
        public ICommand Scan_Plex_Cmd
        {
            get
            {
                if (null == mScan_Plex_Cmd)
                    mScan_Plex_Cmd = new DelegateCommand(Scan_Plex_Button); 
                return mScan_Plex_Cmd;
            }
        }

        public void Scan_Plex_Button(object obj)
        {
            Console.WriteLine("Scan Plex Button Pressed");
            Console.WriteLine("Timer: " + Timer);

            PlexScanner mScanWindow = new PlexScanner();
            mScanWindow.Show();
        }

        private int _timer = 0;
        public int Timer
        {
            get { return _timer; }
            set
            {
                _timer = value;
                RaisePropertyChanged();
            }
        }

        private int mUnits_SelIndex;
        public int Units_SelIndex
        {
            get { return mUnits_SelIndex; }
            set
            {
                mUnits_SelIndex = value;
            }
        }

        private ObservableCollection<SharedUser> mSharedUsers = new ObservableCollection<SharedUser> { new SharedUser("Default", "Default") };
        public ObservableCollection<SharedUser> SharedUsers
        {
            get { return mSharedUsers; }
            set
            {
                mSharedUsers = value;
                RaisePropertyChanged();
            }
        }

        private int mSharedUsers_SelIndex = 0;
        public int SharedUsers_SelIndex
        {
            get { return mSharedUsers_SelIndex; }
            set
            {
                mSharedUsers_SelIndex = value;
            }
        }

        private bool mManual_State;
        public bool Manual_State
        {
            get { return mManual_State; }
            set
            {
                mManual_State = value;
                RaisePropertyChanged();
                RaisePropertyChanged("Automatic_State");
            }
        }

        private bool mAutomatic_State;
        public bool Automatic_State
        {
            get { return mAutomatic_State; }
            set
            {
                mAutomatic_State = value;
                RaisePropertyChanged();
                RaisePropertyChanged("Manual_State");
            }
        }

    }
}
