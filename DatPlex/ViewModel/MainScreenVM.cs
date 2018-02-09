using System;
using System.Timers;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using DatPlex.Common;
using DatPlex.DataModel;
using DatPlex.GUI.Main_Window;
using DatPlex.GUI.Child_Window;

namespace DatPlex.ViewModel
{
    public class MainScreenVM : BaseViewModel
    {
        #region Data Fields

        Window Parent;

        //int mFileViewIndex = -1;

        #endregion Data Fields

        #region Constructor

        public MainScreenVM()
        {
 
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
                OnPropertyChanged();
            }
        }

        #endregion General

        DelegateCommand mSendSel_Cmd;
        public ICommand SendSel_Cmd
        {
            get
            {
                if (null == mSendSel_Cmd)
                    mSendSel_Cmd = new DelegateCommand(SendSelectedUsers);
                return mSendSel_Cmd;
            }
        }

        public void SendSelectedUsers(object obj)
        {

        }

        private Timer _time;
        public Timer Time
        {
            get { return _time; }
            set { _time = value; }
        }

        DelegateCommand mSetPeriod_Cmd;
        public ICommand SetPeriod_Cmd
        {
            get
            {
                if (null == mSetPeriod_Cmd)
                    mSetPeriod_Cmd = new DelegateCommand(SetPeriod);
                return mSetPeriod_Cmd;
            }
        }

        public void SetPeriod()
        {
            Time = new Timer();
            Time.Elapsed += new ElapsedEventHandler(Auto_Scan_Plex);
           
            switch (Units_SelIndex)
            {
                case 0:
                    Time.Enabled = false;
                    Timer = 0;
                    break;
                case 1:
                    Time.Interval = Timer * Utility.MINUTES;
                    Time.Enabled = true;
                    break;
                case 2:
                    Time.Interval = Timer * Utility.HOURS;
                    Time.Enabled = true;
                    break;
                case 3:
                    Time.Interval = Timer * Utility.DAYS;
                    Time.Enabled = true;
                    break;
            }

        }

        private static void Auto_Scan_Plex(object obj, ElapsedEventArgs e)
        {
            //TODO: Auto Scan Logic
            Console.WriteLine("1 MORE MINUTE!");
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
                    mScan_Plex_Cmd = new DelegateCommand(Man_Scan_Plex); 
                return mScan_Plex_Cmd;
            }
        }

        private void Man_Scan_Plex(object obj)
        {
            Console.WriteLine("Scan Plex Button Pressed");
            Console.WriteLine("Timer: " + Timer);

            PlexScanner mScanWindow = new PlexScanner();
            mScanWindow.Show();
        }

        DelegateCommand mLogout_Cmd;
        public ICommand Logout_Cmd
        {
            get
            {
                if (null == mLogout_Cmd)
                    mLogout_Cmd = new DelegateCommand(Logout_Button);
                return mLogout_Cmd;
            }
        }

        public void Logout_Button(object obj)
        {
            //TODO: Logout procedure
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

        private bool mSendSel_State;
        public bool SendSel_State
        {
            get { return mSendSel_State; }
            set
            {
                mSendSel_State = value;
                OnPropertyChanged();
                OnPropertyChanged("SendAll_State");
            }
        }

        private bool mSendAll_State;
        public bool SendAll_State
        {
            get { return mSendAll_State; }
            set
            {
                mSendAll_State = value;
                OnPropertyChanged();
                OnPropertyChanged("SendSel_State");
            }
        }

    }
}
