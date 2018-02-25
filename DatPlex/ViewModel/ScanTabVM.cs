using System;
using System.Timers;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using DatPlex.Common;
using DatPlex.DataModel;
using DatPlex.GUI.Main_Window;
using DatPlex.GUI.Child_Window;

namespace DatPlex.ViewModel
{
    public class ScanTabVM : BaseViewModel
    {
        #region Data Fields

        private Window _Parent;

        #endregion Data Fields

        #region Constructor

        public ScanTabVM()
        {

        }

        public void SetParent(Window iParent)
        {
            _Parent = iParent;
        }

        #endregion Constructor

        #region General

        public void SendSelectedUsers(object obj)
        {

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
                    Time.Interval = Timer * Utility.DAYS;
                    Time.Enabled = true;
                    break;
                //case 2:
                //    Time.Interval = Timer * Utility.HOURS;
                //    Time.Enabled = true;
                //    break;
                //case 3:
                //    Time.Interval = Timer * Utility.DAYS;
                //    Time.Enabled = true;
                //    break;
            }

        }

        private static void Auto_Scan_Plex(object obj, ElapsedEventArgs e)
        {
            //TODO: Auto Scan Logic
            Console.WriteLine("1 MORE MINUTE!");
        }

        private void Man_Scan_Plex(object obj)
        {
            App.MainViewModel.Get_Libraries();
            App.MainViewModel.Get_Media();
            App.MainViewModel.Get_Friends();
        }

        public void UpdateServerInfo(object obj)
        {
            ServerInformation wInfo = new ServerInformation();
            wInfo.DataContext = this;
            wInfo.ShowInTaskbar = false;
            wInfo.ShowDialog();

            if ((bool)wInfo.DialogResult)
            {
                Tuple<string, string, string> info = new Tuple<string, string, string>(IP_Address, Port_Number, Plex_Token);
                App.MainViewModel.PlexApp.ServerInfo = info;
            }
        }

        #endregion General

        #region Setters/Getters

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

        private Timer _time;
        public Timer Time
        {
            get { return _time; }
            set { _time = value; }
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
                OnPropertyChanged();
            }
        }

        private List<Friend> mSharedUsers = new List<Friend> { new Friend("Default", "Default", "Default") };
        public List<Friend> SharedUsers
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

        private string _IP_Address;
        public string IP_Address
        {
            get { return _IP_Address; }
            set
            {
                _IP_Address = (_IP_Address != value) ? value : _IP_Address;
            }
        }

        private string _Port_Number;
        public string Port_Number
        {
            get { return _Port_Number; }
            set
            {
                _Port_Number = (_Port_Number != value) ? value : _Port_Number;
            }
        }

        private string _Plex_Token;
        public string Plex_Token
        {
            get { return _Plex_Token; }
            set
            {
                _Plex_Token = (_Plex_Token != value) ? value : _Plex_Token;
            }
        }

        private string mProgress_Lbl = "Test Label";
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

        #endregion

        #region Command Bindings

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

        DelegateCommand mSettings_Cmd;
        public ICommand Settings_Cmd
        {
            get
            {
                if (null == mSettings_Cmd)
                    mSettings_Cmd = new DelegateCommand(UpdateServerInfo);
                return mSettings_Cmd;
            }
        }
        #endregion
    }

}
