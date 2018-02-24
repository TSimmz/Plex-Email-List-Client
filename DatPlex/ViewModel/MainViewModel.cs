using System;
using System.Net;
using System.IO;
using System.Xml;
using System.Windows;
using System.Windows.Input;
using DatPlex.DataModel;
using DatPlex.Common;

namespace DatPlex.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        #region Data Fields

        Window Parent;

        #endregion

        #region Constructor
        public MainViewModel()
        {
            _PlexApp = new Plex();

            _scanTabVM = new ScanTabVM();
            _libraryTabVM = new LibraryTabVM();
            _friendsTabVM = new FriendsTabVM();

            _scanTabVM.SetParent(App.MainWindow);
            _libraryTabVM.SetParent(App.MainWindow);
            _friendsTabVM.SetParent(App.MainWindow);

            ScanViewVisibility = Visibility.Hidden;
            LibraryViewVisibility = Visibility.Hidden;
            FriendsViewVisibility = Visibility.Hidden;
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

        public XmlDocument Get_Request(string url)
        {
            XmlDocument data = new XmlDocument();
            XmlReader reader;

            //try
            //{
                //string url = "https://192.168.0.4:32400/library/sections/?X-Plex-Token=yedx66JT2HqyEd2xxf4m";
                //string url = "https://plex.tv/pms/friends/all/?X-Plex-Token=yedx66JT2HqyEd2xxf4m";
                

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
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine("Response error:" + e.ToString());
                
            //    return reader;
            //}

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

            foreach(XmlNode i in lib_nodes)
            {
                lib = new Library(
                    Convert.ToInt32(i.Attributes["key"].Value),
                    i.Attributes["type"].Value,
                    i.Attributes["title"].Value
                );

                PlexApp.Libraries.Add(lib);
            }

            _libraryTabVM.LibraryList = PlexApp.Libraries;
           
        }

        private void ExitApp(object obj)
        {
            App.Current.Shutdown();
        }

        #endregion

        #region Setter/Getters

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

        private static LibraryTabVM _libraryTabVM;
        public LibraryTabVM LibraryTabVM
        {
            get { return _libraryTabVM; }
            set
            {
                _libraryTabVM = value;
                OnPropertyChanged();
            }
        }

        private static FriendsTabVM _friendsTabVM;
        public FriendsTabVM FriendsTabVM
        {
            get { return _friendsTabVM; }
            set
            {
                _friendsTabVM = value;
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
                            LibraryViewVisibility = Visibility.Hidden;
                            FriendsViewVisibility = Visibility.Hidden;

                            break;

                        case 1:         // Libraries Tab
                            ScanViewVisibility = Visibility.Hidden;
                            LibraryViewVisibility = Visibility.Visible;
                            FriendsViewVisibility = Visibility.Hidden;

                            break;

                        case 2:         // Friends Tab
                            ScanViewVisibility = Visibility.Hidden;
                            LibraryViewVisibility = Visibility.Hidden;
                            FriendsViewVisibility = Visibility.Visible;

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

        private Visibility _LibraryViewVisibility;
        public Visibility LibraryViewVisibility
        {
            get { return _LibraryViewVisibility; }
            set
            {
                _LibraryViewVisibility = value;
                OnPropertyChanged();
            }
        }

        private Visibility _FriendsViewVisibility;
        public Visibility FriendsViewVisibility
        {
            get { return _FriendsViewVisibility; }
            set
            {
                _FriendsViewVisibility = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Command Bindings

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
