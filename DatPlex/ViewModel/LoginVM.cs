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
    public class LoginVM : BaseViewModel
    {
        public LoginVM()
        {
           
        }
                
        private string _email;
        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyChanged();
                OnPropertyChanged("Login_Enabled");
            }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set
            {                               // TODO: Binding password not safe. Stores in memory. 
                _password = value;  
                OnPropertyChanged();
                OnPropertyChanged("Login_Enabled");
            }
        }

        private bool _rememberMe;
        public bool RememberMe
        {
            get { return _rememberMe; }
            set
            {
                _rememberMe = value;
                OnPropertyChanged();
            }
        }

        private bool _Login_Enabled;
        public bool Login_Enabled
        {
            get
            {
                _Login_Enabled = (_email != null && _password != null);
                return _Login_Enabled;
            }
        }

        DelegateCommand _onLogin_Cmd;
        public ICommand onLogin_Cmd
        {
            get
            {
                if (_onLogin_Cmd == null)
                    _onLogin_Cmd = new DelegateCommand(onLogin);
                return _onLogin_Cmd;
            }
        }
        public void onLogin()
        {

            App.MainViewModel.PlexApp.Login_Task(Email, Password);
            App.MainViewModel.LoginVisibility = Visibility.Hidden;
            App.MainViewModel.MainScreenVisibility = Visibility.Visible;   
        }
    }
}
