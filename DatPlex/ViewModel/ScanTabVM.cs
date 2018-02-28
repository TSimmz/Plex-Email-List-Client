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
        private MainViewModel _MainViewModel;

        #endregion Data Fields

        #region Constructor

        public ScanTabVM(MainViewModel mainViewModel)
        {
            _MainViewModel = mainViewModel;
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
                    Utility.LogEntry("Timer Disabled");
                    break;
                case 1:
                    Time.Interval = Timer * Utility.DAYS;
                    Time.Enabled = true;
                    Utility.LogEntry("Timer Set : " + Timer.ToString() + " days");
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

        public void Auto_Scan_Plex(object obj, ElapsedEventArgs e)
        {
            //TODO: Auto Scan Logic
            Console.WriteLine("1 MORE MINUTE!");
        }

        public void Man_Scan_Plex(object obj)
        {
            App.MainViewModel.Get_Libraries();
            App.MainViewModel.Get_Media();
            App.MainViewModel.Get_Friends();
        }

        public void UpdateServerInfo(object obj)
        {
            ServerInformation wInfo = new ServerInformation();
            wInfo.DataContext = this;
            //wInfo.ShowInTaskbar = false;
            wInfo.ShowDialog();

            if ((bool)wInfo.DialogResult)
            {
                Tuple<string, string, string> info = new Tuple<string, string, string>(IP_Address, Port_Number, Plex_Token);
                App.MainViewModel.PlexApp.ServerInfo = info;

                Utility.LogEntry("Server information updated.");
            }
        }

        public void LogEntry_ModeChange()
        {
            if(Manual_State)
            {
                Utility.LogEntry("Manual State Enabled");
                Units_SelIndex = 0;
                SetPeriod();
            }
            else
                Utility.LogEntry("Automatic State Enabled");
        }

        #endregion General

        #region Setters/Getters

        public MainViewModel MainViewModel { get { return _MainViewModel; } }

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


        private bool mManual_State = true;
        public bool Manual_State
        {
            get { return mManual_State; }
            set
            {
                mManual_State = value;
                OnPropertyChanged();
                OnPropertyChanged("Automatic_State");
                LogEntry_ModeChange();
            }
        }

        private bool mAutomatic_State = false;
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

        private string _IP_Address = "75.115.71.34";
        public string IP_Address
        {
            get { return _IP_Address; }
            set
            {
                _IP_Address = (_IP_Address != value) ? value : _IP_Address;
            }
        }

        private string _Port_Number="32400";
        public string Port_Number
        {
            get { return _Port_Number; }
            set
            {
                _Port_Number = (_Port_Number != value) ? value : _Port_Number;
            }
        }

        private string _Plex_Token= "yedx66JT2HqyEd2xxf4m";
        public string Plex_Token
        {
            get { return _Plex_Token; }
            set
            {
                _Plex_Token = (_Plex_Token != value) ? value : _Plex_Token;
            }
        }

        private string mProgress_Lbl = "Test Label: This is only a test.";
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

        DelegateCommand mImportExport_Cmd;
        public ICommand ImportExport_Cmd
        {
            get
            {
                if (null == mImportExport_Cmd)
                    mImportExport_Cmd = new DelegateCommand(MainViewModel.ImportExport);
                return mImportExport_Cmd;
            }
        }

        #endregion
    }

}
