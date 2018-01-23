using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DatPlex.Common;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace DatPlex.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private ViewModelBase _currentViewModel;

        readonly static LoginVM _loginVM = new LoginVM();
        readonly static MainScreenVM _mainScreenVM = new MainScreenVM();
        
        public ViewModelBase CurrentViewModel
        {
            get { return _currentViewModel; }
            set
            {
                if (_currentViewModel == value)
                    return;

                _currentViewModel = value;
                RaisePropertyChanged("CurrentViewModel");
            }
        }

        public ICommand Login_Cmd { get; private set; }
        public ICommand MainScreen_Cmd { get; private set; }

        public MainViewModel()
        {
            CurrentViewModel = MainViewModel._loginVM;
            Login_Cmd = new RelayCommand(() => ExecuteLogin_Cmd());
            MainScreen_Cmd = new RelayCommand(() => ExecuteMainScreen_Cmd());
        }

        private void ExecuteLogin_Cmd()
        {
            CurrentViewModel = MainViewModel._loginVM;
        }

        private void ExecuteMainScreen_Cmd()
        {
            CurrentViewModel = MainViewModel._mainScreenVM;
        }
    }
}
