using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Media;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Documents;
using System.Windows.Threading;
using System.Threading;
using Microsoft.Win32;
using DatPlex.Common;
using DatPlex.DataModel;

namespace DatPlex.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        #region Data Fields

        Window Parent;

        public BackgroundWorker BgWorker;
        public event EventHandler TaskStarting = (s, e) => { };

        //int mFileViewIndex = -1;

        #endregion Data Fields

        #region Constructor

        public MainViewModel()
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
                OnPropertyChanged("WindowTitle");
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
        }

        private int _timer = 0;
        public int Timer
        {
            get { return _timer; }
            set
            {
                _timer = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<string> mUnits = new ObservableCollection<string>{"--", "MN", "HR", "DY" };
        public ObservableCollection<string> Units
        {
            get { return mUnits; }
            //set
            //{
            //    mUnits = value;
            //    OnPropertyChanged();
            //}
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
                OnPropertyChanged();
            }
        }

        private int mSharedUsers_SelIndex;
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
                OnPropertyChanged();
                OnPropertyChanged("Automatic_State");
            }
        }

        private bool mAutomatic_State;
        public bool Automatic_State
        {
            get { return mAutomatic_State; }
            set
            {
                mAutomatic_State = value;
                OnPropertyChanged();
                OnPropertyChanged("Manual_State");
            }
        }

        DelegateCommand mFile_Exit_Cmd;
        public ICommand File_ExitCommand
        {
            get
            {
                if (mFile_Exit_Cmd == null)
                    mFile_Exit_Cmd = new DelegateCommand(ExitApp);
                return mFile_Exit_Cmd;
            }
        }

        private void ExitApp(object obj)
        {
            Application.Current.Shutdown();
        }
    }
}
