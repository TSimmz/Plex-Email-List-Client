using System;
using System.Windows;
using System.Windows.Input;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatPlex.Common;
using DatPlex.DataModel;
using DatPlex.GUI.Main_Window;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace DatPlex.ViewModel
{
    public class LoginVM : ViewModelBase
    {
        public LoginVM()
        {
            //onLogin_Cmd = new RelayCommand(() => onLogin(), () => true);
        }

        public ICommand onLogin_Cmd { get; private set; }
        
        private string _email;
        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                RaisePropertyChanged();
            }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                RaisePropertyChanged();
            }
        }

        private bool _rememberMe;
        public bool RememberMe
        {
            get { return _rememberMe; }
            set
            {
                _rememberMe = value;
                RaisePropertyChanged();
            }
        }

        DelegateCommand mLogin_Cmd;
        public ICommand Login_Cmd
        {
            get
            {
                if (null == mLogin_Cmd)
                    mLogin_Cmd = new DelegateCommand(onLogin);
                return mLogin_Cmd;
            }
        }

        public void onLogin()
        {
            Console.WriteLine("Login pressed");
        }
    }
}
