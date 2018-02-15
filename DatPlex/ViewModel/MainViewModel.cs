using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            _scanTabVM = new ScanTabVM();
            _libraryTabVM = new LibraryTabVM();
            _friendsTabVM = new FriendsTabVM();
            
            _PlexApp = new Plex();

            ScanViewVisibility = Visibility.Visible;
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
