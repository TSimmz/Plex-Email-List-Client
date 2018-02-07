using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DatPlex.DataModel;
using DatPlex.Common;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Windows;

namespace DatPlex.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        public MainViewModel()
        {

            _loginVM = new LoginVM();
            _mainScreenVM = new MainScreenVM();
            
            LoginVisibility = Visibility.Visible;
            MainScreenVisibility = Visibility.Hidden;
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

        //private BaseViewModel _currentViewModel;
        //public BaseViewModel CurrentViewModel
        //{
        //    get { return _currentViewModel; }
        //    set
        //    {
        //        if (_currentViewModel == value)
        //            return;

        //        _currentViewModel = value;
        //        OnPropertyChanged("CurrentViewModel");
        //    }
        //}

        private static LoginVM _loginVM;
        public LoginVM LoginVM
        {
            get { return _loginVM; }
            set
            {
                _loginVM = value;
                OnPropertyChanged();
            }
        }

        private static MainScreenVM _mainScreenVM;
        public MainScreenVM MainScreenVM
        {
            get { return _mainScreenVM; }
            set
            {
                _mainScreenVM = value;
                OnPropertyChanged();
            }
        }

        private Visibility _LoginVisibility;
        public Visibility LoginVisibility
        {
            get { return _LoginVisibility; }
            set
            {
                _LoginVisibility = value;
                OnPropertyChanged();
            }
        }

        private Visibility _MainScreenVisibility;
        public Visibility MainScreenVisibility
        {
            get { return _MainScreenVisibility; }
            set
            {
                _MainScreenVisibility = value;
                OnPropertyChanged();
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
            App.Current.Shutdown();
        }
    }
}
