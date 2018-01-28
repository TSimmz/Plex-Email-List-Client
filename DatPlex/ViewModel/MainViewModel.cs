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

namespace DatPlex.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        private BaseViewModel _currentViewModel;

        readonly static LoginVM _loginVM = new LoginVM();
        readonly static MainScreenVM _mainScreenVM = new MainScreenVM();

        private Plex _PlexApp;
        public Plex PlexApp
        {
            get { return _PlexApp; }
            set
            {
                _PlexApp = value;
            }
        }

        public BaseViewModel CurrentViewModel
        {
            get { return _currentViewModel; }
            set
            {
                if (_currentViewModel == value)
                    return;

                _currentViewModel = value;
                OnPropertyChanged("CurrentViewModel");
            }
        }
        
        public MainViewModel()
        {
            CurrentViewModel = MainViewModel._loginVM;
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
