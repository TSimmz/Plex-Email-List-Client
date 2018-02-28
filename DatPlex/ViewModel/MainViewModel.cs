using System;
using System.Net;
using System.IO;
using System.Xml;
using System.Windows;
using System.Windows.Input;
using System.Collections.Generic;
using DatPlex.DataModel;
using DatPlex.Common;

namespace DatPlex.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        #region Data Fields

        Window Parent;
        private bool _IsPlexLoaded;

        #endregion

        #region Constructor
        public MainViewModel()
        {
            _PlexApp = new Plex();

            _scanTabVM = new ScanTabVM(this);
            _sharingTabVM = new SharingTabVM();

            _scanTabVM.SetParent(App.MainWindow);
            _sharingTabVM.SetParent(App.MainWindow);

            ScanViewVisibility = Visibility.Hidden;
            _SharingViewVisibility = Visibility.Hidden;
        }

        public void SetParent(Window iParent)
        {
            Parent = iParent;
        }

        #endregion

        #region General

        //TODO: Open method
        public bool OpenPlex()
        {
            //If XML file exists for account, load from disk

            //else, create new file

            //create new plex object once complete

            return true;
        }

        public void ImportExport()
        {
            
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

        private void ExitApp(object obj)
        {
            App.Current.Shutdown();
        }

        #endregion

        #region Get Requests


        public XmlDocument Get_Request(string url)
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


        public void Get_Account_Info()
        {
            XmlDocument account = Get_Request(Utility.PLEX_URL + Utility.GET_ACCOUNT_INFO + PlexApp.PlexToken);
        }

        public void Get_Libraries()
        {
            XmlDocument libraries = Get_Request(PlexApp.LocalURL + Utility.GET_LIBRARIES + PlexApp.PlexToken);
            XmlNodeList lib_nodes = libraries.GetElementsByTagName("Directory");
            Library lib;

            foreach (XmlNode i in lib_nodes)
            {
                string type = (i.Attributes["type"]?.Value != null) ? i.Attributes["type"].Value : "n/a";
                string title = (i.Attributes["title"]?.Value != null) ? i.Attributes["title"].Value : "n/a";

                lib = new Library(Convert.ToInt32(i.Attributes["key"].Value), type, title);
                PlexApp.Libraries.Add(lib);
            }

            _sharingTabVM.LibraryList = PlexApp.Libraries;
        }

        public void Get_Media()
        {
            XmlDocument mediaList;
            XmlNodeList media_nodes;

            foreach (Library lib in PlexApp.Libraries)
            {
                string section = "/" + lib.GetLibKey + "/all";
                mediaList = Get_Request(PlexApp.LocalURL + Utility.GET_LIBRARIES + section + PlexApp.PlexToken);

                media_nodes = mediaList.GetElementsByTagName("MediaContainer");
                lib.ItemCount = Convert.ToInt32(media_nodes[0].Attributes["size"].Value);

                media_nodes = mediaList.GetElementsByTagName(MediaType(lib.GetLibType));

                foreach(XmlNode i in media_nodes)
                {
                    string type = (i.Attributes["type"]?.Value != null) ? i.Attributes["type"].Value : "n/a";
                    string title = (i.Attributes["title"]?.Value != null) ? i.Attributes["title"].Value : "n/a";
                    string content = (i.Attributes["contentRating"]?.Value != null) ? i.Attributes["contentRating"].Value : "n/a";
                    string summary = (i.Attributes["summary"]?.Value != null) ? i.Attributes["summary"].Value : "n/a";

                    Media media = new Media(Convert.ToInt32(i.Attributes["ratingKey"].Value), type, title, content, summary);
                    lib.AddMedia(media);
                }

            }
        }


        public void Get_Friends()
        {
            XmlDocument friends = Get_Request(Utility.PLEX_URL + Utility.GET_SERVER_SHARES + PlexApp.PlexToken);
            XmlNodeList friend_nodes = friends.GetElementsByTagName("User");
            FriendList friendList = new FriendList();
            Friend friend;

            foreach (XmlNode i in friend_nodes)
            {
                friend = new Friend(
                   i.Attributes["title"].Value,
                   i.Attributes["username"].Value,
                   i.Attributes["email"].Value
                    );

                friendList.AddUser(friend);
            }
            PlexApp.FriendList = friendList;
            _sharingTabVM.FriendList = PlexApp.FriendList;

        }

        #endregion

        #region Setter/Getters

        private string mWindowTitle = "Plex Email Updates : Blurgh";
        public string WindowTitle
        {
            get { return mWindowTitle; }
            set
            {
                mWindowTitle = value;
                OnPropertyChanged();
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

        private static ScanTabVM _scanTabVM;
        public ScanTabVM ScanTabVM
        {
            get { return _scanTabVM; }
            set
            {
                _scanTabVM = value;
                OnPropertyChanged();
            }
        }

        private static SharingTabVM _sharingTabVM;
        public SharingTabVM SharingTabVM
        {
            get { return _sharingTabVM; }
            set
            {
                _sharingTabVM = value;
                OnPropertyChanged();
            }
        }

        public bool IsPlexLoaded
        {
            get { return _IsPlexLoaded; }
            set
            {
                _IsPlexLoaded = value;
                OnPropertyChanged();
            }
        }

        private int _SelectedTabIndex;
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
                            break;

                        case 1:         // Sharing Tab
                            ScanViewVisibility = Visibility.Hidden;
                            SharingViewVisibility = Visibility.Visible;
                            break;

                        default:
                            break;
                    }
                }

            }
        }

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

        #endregion

        #region Command Bindings

        //DelegateCommand _Tray_Manual_Cmd;
        //public ICommand Tray_Manual_Cmd
        //{
        //    get
        //    {
        //        if (_Tray_Manual_Cmd == null)
        //            _Tray_Manual_Cmd = new DelegateCommand(_scanTabVM.Manual_State);
        //    }
        //}

        DelegateCommand _Tray_Scan_Cmd;
        public ICommand Tray_Scan_Cmd
        {
            get
            {
                if (_Tray_Scan_Cmd == null)
                    _Tray_Scan_Cmd = new DelegateCommand(_scanTabVM.Man_Scan_Plex);
                return _Tray_Scan_Cmd;
            }
        }

        DelegateCommand _Tray_Settings_Cmd;
        public ICommand Tray_Settings_Cmd
        {
            get
            {
                if (_Tray_Settings_Cmd == null)
                    _Tray_Settings_Cmd = new DelegateCommand(_scanTabVM.UpdateServerInfo);
                return _Tray_Settings_Cmd;
            }
        }

        DelegateCommand _Tray_RefreshLibaries_Cmd;
        public ICommand Tray_RefreshLibaries_Cmd
        {
            get
            {
                if (_Tray_RefreshLibaries_Cmd == null)
                    _Tray_RefreshLibaries_Cmd = new DelegateCommand(_sharingTabVM.RefreshLibraries);
                return _Tray_RefreshLibaries_Cmd;
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

        #endregion
    }
}
