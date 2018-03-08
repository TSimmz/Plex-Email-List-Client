using System;
using System.Net;
using System.IO;
using System.Xml;
using System.Windows;
using System.Windows.Input;
using System.Reflection;
using System.ComponentModel;
using System.Collections.Generic;
using System.Threading;
using System.Timers;
using System.Collections.ObjectModel;
using DatPlex.DataModel;
using DatPlex.Common;
using DatPlex.GUI.Child_Window;

namespace DatPlex.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        #region Data Fields
        
        BackgroundWorker BgWorker;
        private bool [] CurrentSchedule;
        private DateTime CurrentTimer;

        #endregion

        #region Constructor
        public MainViewModel()
        {
            // Background worker
            BgWorker = new BackgroundWorker();
            BgWorker.WorkerReportsProgress = true;
            LockVisibility = Visibility.Visible;
            UnlockVisibility = Visibility.Collapsed;

            // Scan Tab
            ScanViewVisibility = Visibility.Visible;
            CurrentSchedule = new bool[7];

            // Sharing Tab
            SharingViewVisibility = Visibility.Hidden;
            LibraryList = new ObservableCollection<Library>();
            FriendsList = new ObservableCollection<Friend>();

            // Logging Tab
            LogViewVisibility = Visibility.Hidden;
            LogEntryList = new ObservableCollection<LogEntry>();
            LogIndex++;

            GenerateTestData();
        }

        #endregion

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

        private bool _UI_Enabled = true;
        public bool UI_Enabled
        {
            get { return _UI_Enabled; }
            set
            {
                _UI_Enabled = value;
                OnPropertyChanged();
            }
        }

        public void GenerateTestData()
        {
            for (int i = 0; i < 5; i++)
            {
                Library l = new Library(i, "movie" + i.ToString(), "title" + i.ToString());
                LibraryList.Add(l);

                Friend f = new Friend("title" + i.ToString(), "username" + i.ToString(), "email" + i.ToString());
                FriendsList.Add(f);
            }
        }

        //TODO: Open method
        public bool OpenPlex()
        {
            //If XML file exists for account, load from disk

            //else, create new file

            //create new plex object once complete

            return true;
        }

        public void Scan_Plex(object obj)
        {
            //App.MainViewModel.Get_Libraries();
            //App.MainViewModel.Get_Media();
            //App.MainViewModel.Get_Friends();

            //Utility.IMPLEMENT(MethodBase.GetCurrentMethod().Name);
            //return;

            // PROGRESS UPDATES
            // **   SCANNING  **
            // ** IN PROGRESS **
            // **   FAILURE   **
            // **   SUCCESS   **
            // **   COMPLETE  **

            // Test connection to Plex

            Thread t = new Thread(() =>
            {
                // Get Libraries
                Scan_Label = "Checking for new libraries...";
                LogEntry(Get_Libraries());

                // Get Media

                Scan_Label = "Checking for new media...";
                LogEntry(Get_Media());

                // Get Friends
                Scan_Label = "Checking for new friends...";
                LogEntry(Get_Friends());

                // Scan complete
                Scan_Label = "Scan Complete!";
            });
            t.Start();

            SetNextTimer();
        }

        public void ImportExport()
        {
            Utility.IMPLEMENT(MethodBase.GetCurrentMethod().Name);
        }

        public string MediaType(string type)
        {
            switch (type)
            {
                case "movie":
                    return "Video";
                case "show":
                    return "Directory";
                //case "photo":
                //    break;
                //case "music":
                //    break;
                default:
                    return "MediaList";
            }
        }

        private Plex _PlexApp;
        public Plex PlexApp
        {
            get { return _PlexApp; }
            set
            {
                _PlexApp = value;
            }
        }

        private int _SelectedTabIndex = 0;
        public int SelectedTabIndex
        {
            get { return _SelectedTabIndex; }
            set
            {
                if (_SelectedTabIndex != value)
                {
                    _SelectedTabIndex = value;

                    switch (_SelectedTabIndex)
                    {
                        case 0:         // Scan Tab
                            ScanViewVisibility = Visibility.Visible;
                            SharingViewVisibility = Visibility.Hidden;
                            LogViewVisibility = Visibility.Hidden;
                            break;

                        case 1:         // Sharing Tab
                            ScanViewVisibility = Visibility.Hidden;
                            SharingViewVisibility = Visibility.Visible;
                            LogViewVisibility = Visibility.Hidden;
                            break;

                        case 2:         // Logging Tab
                            ScanViewVisibility = Visibility.Hidden;
                            SharingViewVisibility = Visibility.Hidden;
                            LogViewVisibility = Visibility.Visible;
                            break;

                        default:
                            break;
                    }
                }
            }
        }

        public void LockView (object obj)
        {
            UI_Enabled = false;
            LockVisibility = Visibility.Collapsed;
            UnlockVisibility = Visibility.Visible;

        }

        public void UnlockView(object obj)
        {
            UI_Enabled = true;
            UnlockVisibility = Visibility.Collapsed;
            LockVisibility = Visibility.Visible;
        }

        private Visibility _LockVisibility;
        public Visibility LockVisibility
        {
            get { return _LockVisibility; }
            set
            {
                _LockVisibility = value;
                OnPropertyChanged();
            }
        }

        private Visibility _UnlockVisibility;
        public Visibility UnlockVisibility
        {
            get { return _UnlockVisibility; }
            set
            {
                _UnlockVisibility = value;
                OnPropertyChanged();
            }
        }

        private void ExitApp(object obj)
        {
            MessageBoxResult save = MessageBox.Show("Would you like to save your Plex server data before closing?", "Closing Plex Email Updater", MessageBoxButton.YesNo, MessageBoxImage.Exclamation);
            if (save == MessageBoxResult.Yes)
            {
                //SAVE
            }
            else
                App.Current.Shutdown();
        }

        #endregion

        #region Scan Tab

        private Visibility _ScanViewVisibility;
        public Visibility ScanViewVisibility
        {
            get { return _ScanViewVisibility; }
            set
            {
                _ScanViewVisibility = value;
                OnPropertyChanged();
            }
        }

        private bool _Manual_State = true;
        public bool Manual_State
        {
            get { return _Manual_State; }
            set
            {
                _Manual_State = value;
                OnPropertyChanged();
                OnPropertyChanged("Automatic_State");

                if (Manual_State)
                {
                    SubLogEntry("** MODE CHANGED **",
                        new LogEntry() {DateTime = DateTime.Now, Index = LogIndex++, Message = "Manual State Enabled"},
                        new LogEntry() { DateTime = DateTime.Now, Index = LogIndex++, Message = "Scan Timer Disabled" });
                }
                else
                {
                    SubLogEntry("** MODE CHANGED **",
                        new LogEntry() { DateTime = DateTime.Now, Index = LogIndex++, Message = "Automatic State Enabled" },
                        new LogEntry() { DateTime = DateTime.Now, Index = LogIndex++, Message = "Scan Timer Enabled" });
                }


                Scan_Timer.Enabled = false;
            }
        }

        private bool _Automatic_State = false;
        public bool Automatic_State
        {
            get { return _Automatic_State; }
            set
            {
                _Automatic_State = value;
                OnPropertyChanged();
                OnPropertyChanged("Manual_State");

                Scan_Timer.Enabled = true;
            }
        }

        public void SendSelectedUsers(object obj)
        {
            Utility.IMPLEMENT(MethodBase.GetCurrentMethod().Name);
        }

        public void SetPeriod()
        {
            #region Old Timer
            //Time = new Timer();
            //Time.Elapsed += new ElapsedEventHandler(Auto_Scan_Plex);

            //switch (Units_SelIndex)
            //{
            //    case 0:
            //        Time.Enabled = false;
            //        Timer = 0;
            //        Utility.LogEntry("Timer Disabled");
            //        break;
            //    case 1:
            //        Time.Interval = Timer * Utility.DAYS;
            //        Time.Enabled = true;
            //        Utility.LogEntry("Timer Set : Next Scan on " + DateTime.Now.AddDays(Timer));
            //        break;
            //    case 2:
            //        Time.Interval = Timer * Utility.HOURS;
            //        Time.Enabled = true;
            //        break;
            //    case 3:
            //        Time.Interval = Timer * Utility.DAYS;
            //        Time.Enabled = true;
            //        break;
            //}
            #endregion

            //Utility.IMPLEMENT(MethodBase.GetCurrentMethod().Name);

            CurrentSchedule = DaysofWeek;
            CurrentTimer = UpdateTime;

            //Scan_Timer.Elapsed += new ElapsedEventHandler(Scan_Plex);
            Scan_Timer.Interval = GetNextTimer();          

        }

        public int GetNextTimer()
        {
            TimeSpan timeUntilNext = new TimeSpan(0);
            DateTime today = DateTime.Now;
            int today_index = (int)today.DayOfWeek;

            CurrentTimer = CurrentTimer.AddMonths(today.Month - 1).AddDays(today.Day - 1).AddYears(today.Year - 1);

            int days = 0;
            int daysUntilNext = 0;
            int hoursUntilNext = 0;
            int minsUntilNext = 0;

            for (int i = today_index; days < 7; i = (i + 1) % 7)
            {
                if (CurrentSchedule[i])
                {
                    daysUntilNext = (i - today_index + 7) % 7;
                    CurrentTimer = CurrentTimer.AddDays(daysUntilNext);

                    timeUntilNext = CurrentTimer - today;

                    break;                 
                }

                days++;
            }

            LogEntry(string.Format("** NEXT SCAN ** : {0} Days, {1} Hours, {2} Minutes", timeUntilNext.Days, timeUntilNext.Hours, timeUntilNext.Minutes));

            daysUntilNext = timeUntilNext.Days * Global.DAYS;
            hoursUntilNext = timeUntilNext.Hours * Global.HOURS;
            minsUntilNext = timeUntilNext.Minutes * Global.MINUTES;


            return daysUntilNext + hoursUntilNext + minsUntilNext;
        }

        public void SetNextTimer()
        {
            Utility.IMPLEMENT(MethodBase.GetCurrentMethod().Name);
        }

        private System.Timers.Timer _Scan_Timer = new System.Timers.Timer();
        public System.Timers.Timer Scan_Timer
        {
            get { return _Scan_Timer; }
            set
            {
                _Scan_Timer = value;
            }
        }

        private DateTime _UpdateTime;
        public DateTime UpdateTime
        {
            get { return _UpdateTime; }
            set
            {
                _UpdateTime = value;
                OnPropertyChanged();
            }
        }
        
        private bool[] DaysofWeek = new bool[7];
        public bool IsChecked_Sun
        {
            get { return DaysofWeek[0]; }
            set { DaysofWeek[0] = value; }
        }

        public bool IsChecked_Mon
        {
            get { return DaysofWeek[1]; }
            set { DaysofWeek[1] = value; }
        }

        public bool IsChecked_Tue
        {
            get { return DaysofWeek[2]; }
            set { DaysofWeek[2] = value; }
        }

        public bool IsChecked_Wed
        {
            get { return DaysofWeek[3]; }
            set { DaysofWeek[3] = value; }
        }

        public bool IsChecked_Thu
        {
            get { return DaysofWeek[4]; }
            set { DaysofWeek[4] = value; }
        }

        public bool IsChecked_Fri
        {
            get { return DaysofWeek[5]; }
            set { DaysofWeek[5] = value; }
        }

        public bool IsChecked_Sat
        {
            get { return DaysofWeek[6]; }
            set { DaysofWeek[6] = value; }
        }

        #region Progress Bar


        private string _Scan_Label = "Test Label: This is only a test.";
        public string Scan_Label
        {
            get { return _Scan_Label; }
            set
            {
                _Scan_Label = value;
                OnPropertyChanged();
            }
        }

        private int _ScanProgress;
        public int ScanProgress
        {
            get { return _ScanProgress; }
            set
            {
                _ScanProgress = value;
                OnPropertyChanged();
            }
        }

        #endregion Progress Bar

        #endregion Scan Tab

        #region Sharing Tab

        private Visibility _SharingViewVisibility;
        public Visibility SharingViewVisibility
        {
            get { return _SharingViewVisibility; }
            set
            {
                _SharingViewVisibility = value;
                OnPropertyChanged();
            }
        }

        #region Library List

        private ObservableCollection<Library> _LibraryList;
        public ObservableCollection<Library> LibraryList
        {
            get { return _LibraryList; }
            set
            {
                if (value != null)
                    _LibraryList = value;

                OnPropertyChanged();
            }
        }

        private bool _IsLibrarySelected = false;
        public bool IsLibrarySelected
        {
            get { return _IsLibrarySelected; }
            set
            {
                _IsLibrarySelected = value;
                OnPropertyChanged();
            }
        }
        
        public void RefreshLibraries()
        {
            Utility.IMPLEMENT(MethodBase.GetCurrentMethod().Name);
        }

        private int _SelIndex_Library = -1;
        public int SelIndex_Library
        {
            get { return _SelIndex_Library; }
            set
            {
                _SelIndex_Library = value;
                OnPropertyChanged();
            }
        }


        private bool _Include_Library;
        public bool Include_Library
        {
            get { return _Include_Library; }
            set
            {
                _Include_Library = value;
            }
        }

        #endregion Library List

        #region Friends List

        private ObservableCollection<Friend> _FriendsList;
        public ObservableCollection<Friend> FriendsList
        {
            get { return _FriendsList; }
            set
            {
                if (value != null)
                    _FriendsList = value;

                OnPropertyChanged();
            }
        }

        private int _SelIndex_Friend = -1;
        public int SelIndex_Friend
        {
            get { return _SelIndex_Friend; }
            set
            {
                _SelIndex_Friend = value;
                OnPropertyChanged();
            }
        }

        private bool _Include_Friend;
        public bool Include_Friend
        {
            get { return _Include_Friend; }
            set
            {
                _Include_Friend = value;
                OnPropertyChanged();
            }
        }

        private bool _IsFriendSelected = false;
        public bool IsFriendSelected
        {
            get { return _IsFriendSelected; }
            set
            {
                _IsFriendSelected = value;
                OnPropertyChanged();
            }
        }


        public void AddFriends(object obj)
        {
            //Utility.IMPLEMENT(MethodBase.GetCurrentMethod().Name);
            CustomFriend wFriend = new CustomFriend();
            wFriend.DataContext = this;
            wFriend.Show();

            if ((bool)wFriend.DialogResult)
            {
                if (!Friend_Name.Equals("") && !Friend_Email.Equals(""))
                {
                    Friend newFriend = new Friend(Friend_Name, Friend_Email);
                    FriendsList.Add(newFriend);
                }
                else
                {
                    MessageBox.Show("New friend information is invalid.", "Add Friend Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private string _Friend_Name;
        public string Friend_Name
        {
            get { return _Friend_Name; }
            set { _Friend_Name = value; }
        }

        private string _Friend_Email;
        public string Friend_Email
        {
            get { return _Friend_Email; }
            set { _Friend_Email = value; }
        }

        public void UpdateFriends()
        {
            Utility.IMPLEMENT(MethodBase.GetCurrentMethod().Name);
        }

        #endregion Friends List

        #endregion Sharing Tab

        #region Logging Tab       

        private Visibility _LogViewVisibility;
        public Visibility LogViewVisibility
        {
            get { return _LogViewVisibility; }
            set
            {
                _LogViewVisibility = value;
                OnPropertyChanged();
            }
        }

        public bool SaveLogs()
        {
            try
            {
                string timeStamp = DateTime.Now.ToShortDateString();
                timeStamp = timeStamp.Replace("/", "-");

                string fileName = "Plex_Logs_" + timeStamp + ".txt";
                
                DirectoryInfo dir = Directory.CreateDirectory(Global.LOG_SAVE_PATH);
                string filePath = Path.Combine(Global.LOG_SAVE_PATH, fileName);

                using (StreamWriter file = File.CreateText(filePath))
                {
                    foreach (CollapsibleLogEntry log in LogEntryList)
                    {
                        string log_txt = log.DateTime.ToString() + "\t" + log.Message + "\n";
                        file.WriteLine(log_txt);

                        if (log.Contents != null)
                        {
                            foreach (LogEntry l in log.Contents)
                            {
                                string sub_log_txt = "\t" + l.DateTime.ToString() + "\t" + l.Message + "\n";
                                file.WriteLine(sub_log_txt);
                            }
                        }
                    }
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        public void ClearLogs()
        {
            //Utility.IMPLEMENT(MethodBase.GetCurrentMethod().Name);
            if (MessageBox.Show("Would you like to save the logs first?", "Clear Logs", MessageBoxButton.YesNo, MessageBoxImage.Exclamation) == MessageBoxResult.No)
                LogEntryList.Clear();
            else
            {
                if (SaveLogs())
                {
                    MessageBox.Show("Logs saved successfully.", "Logs Saved!", MessageBoxButton.OK, MessageBoxImage.Information);
                    LogEntryList.Clear();
                }
                else
                    MessageBox.Show("Logs were unable to be saved.", "Saving Failed!", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
            }

        }

        public static int LogIndex { get; set; }

        private ObservableCollection<LogEntry> _LogEntryList;
        public ObservableCollection<LogEntry> LogEntryList
        {
            get { return _LogEntryList; }
            set
            {
                _LogEntryList = value;
                OnPropertyChanged();
            }
        }

        public void LogEntry(string message)
        {
            LogEntryList.Add(new LogEntry() { DateTime = DateTime.Now, Index = LogIndex++, Message = message });
        }

        public void SubLogEntry(string message, params LogEntry [] logs)
        {
            List<LogEntry> sublogs = new List<LogEntry>();
            foreach (LogEntry l in logs)
            {
                sublogs.Add(l);
            }

            LogEntryList.Add(new CollapsibleLogEntry() { DateTime = DateTime.Now, Index = LogIndex++, Message = message, Contents = sublogs });
        }

        #endregion Logging Tab

        #region System Tray

        #endregion System Tray

        #region Settings

        public void Settings(object obj)
        {
            ServerInformation wInfo = new ServerInformation();
            wInfo.DataContext = this;
            //wInfo.ShowInTaskbar = false;
            wInfo.ShowDialog();

            if ((bool)wInfo.DialogResult)
            {
                Global.LOCAL_URL = "https://" + IP_Address + ":" + Port_Number;
                Global.TOKEN = "/?X-Plex-Token=" + Plex_Token;
            }
        }

        private bool _ServerInfo_State;
        public bool ServerInfo_State
        {
            get { return _ServerInfo_State; }
            set
            {
                _ServerInfo_State = value;
                OnPropertyChanged();
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

        private string _Port_Number = "32400";
        public string Port_Number
        {
            get { return _Port_Number; }
            set
            {
                _Port_Number = (_Port_Number != value) ? value : _Port_Number;
            }
        }

        private string _Plex_Token = "yedx66JT2HqyEd2xxf4m";
        public string Plex_Token
        {
            get { return _Plex_Token; }
            set
            {
                _Plex_Token = (_Plex_Token != value) ? value : _Plex_Token;
            }
        }

        #endregion Settings

        #region Get Requests

        public XmlDocument Get_Request(string url)
        {
            try
            {
                XmlDocument data = new XmlDocument();

                WebRequest request = WebRequest.CreateHttp(url);
                request.Method = "GET";
                request.ContentType = "application/xml;charset=utf-8";

                ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream stream = response.GetResponseStream())
                    {
                        data.Load(stream);
                    }
                }
                return data;
            }
            catch
            {
                return null;
            }
        }


        public void Get_Account_Info()
        {
            //XmlDocument account = Get_Request(Global.PLEX_URL + Global.GET_ACCOUNT_INFO + PlexApp.PlexToken);

            Utility.IMPLEMENT(MethodBase.GetCurrentMethod().Name);

            // Add Window title update here. 
        }

        public string Get_Libraries()
        {
            try
            {
                XmlDocument libraries = Get_Request(Global.LOCAL_URL + Global.GET_LIBRARIES + Global.TOKEN);
                XmlNodeList lib_nodes = libraries.GetElementsByTagName("Directory");
                Library lib;

                foreach (XmlNode i in lib_nodes)
                {
                    string type = (i.Attributes["type"]?.Value != null) ? i.Attributes["type"].Value : "n/a";
                    string title = (i.Attributes["title"]?.Value != null) ? i.Attributes["title"].Value : "n/a";

                    lib = new Library(Convert.ToInt32(i.Attributes["key"].Value), type, title);

                    LibraryList.Add(lib);
                }

                OnPropertyChanged("LibraryList");

                return "Library Scan : " + Global.SUCCESS;
            }
            catch (Exception e)
            {

                return "Library Scan : " + Global.FAILURE + " " + e.ToString();
            }
        }

        public string Get_Media()
        {
            try
            {
                XmlDocument mediaList;
                XmlNodeList media_nodes;

                foreach (Library lib in PlexApp.LibraryList)
                {
                    string section = "/" + lib.GetLibKey + "/all";
                    mediaList = Get_Request(PlexApp.LocalURL + Global.GET_LIBRARIES + section + PlexApp.PlexToken);

                    media_nodes = mediaList.GetElementsByTagName("MediaContainer");
                    lib.ItemCount = Convert.ToInt32(media_nodes[0].Attributes["size"].Value);

                    media_nodes = mediaList.GetElementsByTagName(MediaType(lib.GetLibType));

                    foreach (XmlNode i in media_nodes)
                    {
                        string type = (i.Attributes["type"]?.Value != null) ? i.Attributes["type"].Value : "n/a";
                        string title = (i.Attributes["title"]?.Value != null) ? i.Attributes["title"].Value : "n/a";
                        string content = (i.Attributes["contentRating"]?.Value != null) ? i.Attributes["contentRating"].Value : "n/a";
                        string summary = (i.Attributes["summary"]?.Value != null) ? i.Attributes["summary"].Value : "n/a";

                        Media media = new Media(Convert.ToInt32(i.Attributes["ratingKey"].Value), type, title, content, summary);
                        lib.AddMedia(media);
                    }
                }

                return "Media Scan : " + Global.SUCCESS;
            }
            catch (Exception e)
            {
                return "Media Scan : " + Global.FAILURE + " " + e.ToString();
            }
        }


        public string Get_Friends()
        {
            try
            {
                XmlDocument friends = Get_Request(Global.PLEX_URL + Global.GET_SERVER_SHARES + PlexApp.PlexToken);
                XmlNodeList friend_nodes = friends.GetElementsByTagName("User");
                Friend friend;

                foreach (XmlNode i in friend_nodes)
                {
                    friend = new Friend(
                       i.Attributes["title"].Value,
                       i.Attributes["username"].Value,
                       i.Attributes["email"].Value
                        );

                    FriendsList.Add(friend);
                }

                OnPropertyChanged("FriendsList");

                return "Friend Scan : " + Global.SUCCESS;
            }
            catch (Exception e)
            {
                return "Friend Scan : " + Global.FAILURE + " " + e.ToString();
            }
        }

        #endregion

        #region Command Bindings

        //DelegateCommand _SendSel_Cmd;
        //public ICommand SendSel_Cmd
        //{
        //    get
        //    {
        //        if (_SendSel_Cmd == null)
        //            _SendSel_Cmd = new DelegateCommand(SendSelectedUsers);
        //        return _SendSel_Cmd;
        //    }
        //}
        DelegateCommand _LockView_Cmd;
        public ICommand LockView_Cmd
        {
            get
            {
                if (_LockView_Cmd == null)
                    _LockView_Cmd = new DelegateCommand(LockView);
                return _LockView_Cmd;
            }
        }

        DelegateCommand _UnlockView_Cmd;
        public ICommand UnlockView_Cmd
        {
            get
            {
                if (_UnlockView_Cmd == null)
                    _UnlockView_Cmd = new DelegateCommand(UnlockView);
                return _UnlockView_Cmd;
            }
        }


        DelegateCommand _SetPeriod_Cmd;
        public ICommand SetPeriod_Cmd
        {
            get
            {
                if (_SetPeriod_Cmd == null)
                    _SetPeriod_Cmd = new DelegateCommand(SetPeriod);
                return _SetPeriod_Cmd;
            }
        }

        DelegateCommand _Scan_Plex_Cmd;
        public ICommand Scan_Plex_Cmd
        {
            get
            {
                if (_Scan_Plex_Cmd == null)
                    _Scan_Plex_Cmd = new DelegateCommand(Scan_Plex);
                return _Scan_Plex_Cmd;
            }
        }

        DelegateCommand _Settings_Cmd;
        public ICommand Settings_Cmd
        {
            get
            {
                if (_Settings_Cmd == null)
                    _Settings_Cmd = new DelegateCommand(Settings);
                return _Settings_Cmd;
            }
        }

        DelegateCommand _ImportExport_Cmd;
        public ICommand ImportExport_Cmd
        {
            get
            {
                if (_ImportExport_Cmd == null)
                    _ImportExport_Cmd = new DelegateCommand(ImportExport);
                return _ImportExport_Cmd;
            }
        }

        //DelegateCommand _SaveLogs_Cmd;
        //public ICommand SaveLogs_Cmd
        //{
        //    get
        //    {
        //        if (_SaveLogs_Cmd == null)
        //            _SaveLogs_Cmd = new DelegateCommand(SaveLogs);
        //        return _SaveLogs_Cmd;
        //    }
        //}

        DelegateCommand _ClearLogs_Cmd;
        public ICommand ClearLogs_Cmd
        {
            get
            {
                if (_ClearLogs_Cmd == null)
                    _ClearLogs_Cmd = new DelegateCommand(ClearLogs);
                return _ClearLogs_Cmd;
            }
        }

        DelegateCommand _RefreshLibraries_Cmd;
        public ICommand RefreshLibraries_Cmd
        {
            get
            {
                if (_RefreshLibraries_Cmd == null)
                    _RefreshLibraries_Cmd = new DelegateCommand(RefreshLibraries);
                return _RefreshLibraries_Cmd;
            }
        }

        DelegateCommand _AddFriends_Cmd;
        public ICommand AddFriends_Cmd
        {
            get
            {
                if (_AddFriends_Cmd == null)
                    _AddFriends_Cmd = new DelegateCommand(AddFriends);
                return _AddFriends_Cmd;
            }
        }

        DelegateCommand _UpdateFriends_Cmd;
        public ICommand UpdateFriends_Cmd
        {
            get
            {
                if (_UpdateFriends_Cmd == null)
                    _UpdateFriends_Cmd = new DelegateCommand(UpdateFriends);
                return _UpdateFriends_Cmd;
            }
        }

        DelegateCommand _FileExit_Cmd;
        public ICommand FileExit_Cmd
        {
            get
            {
                if (_FileExit_Cmd == null)
                    _FileExit_Cmd = new DelegateCommand(ExitApp);
                return _FileExit_Cmd;
            }
        }

        #endregion
    }
}
