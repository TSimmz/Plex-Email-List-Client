using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DatPlex.Common;

namespace DatPlex.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        private BaseViewModel _currentViewModel;

        readonly static LoginVM _loginVM = new LoginVM();
        readonly static MainScreenVM _mainScreenVM = new MainScreenVM();
        
        public BaseViewModel CurrentViewModel
        {
            get { return _currentViewModel; }
            set
            {
                if (_currentViewModel == value)
                    return;

                _currentViewModel = value;
                OnPropertyChanged();
            }
        }

        public ICommand Login_Cmd { get; private set; }
        public ICommand MainScreen_Cmd { get; private set; }

        public MainViewModel()
        {
            CurrentViewModel = MainViewModel._loginVM;
            Login_Cmd = new DelegateCommand(() => ExecuteLogin_Cmd());
            MainScreen_Cmd = new DelegateCommand(() => ExecuteMainScreen_Cmd());
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
