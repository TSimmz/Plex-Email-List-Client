using System;
using System.Windows;
using System.Windows.Input;
using System.Security.Cryptography;
using DatPlex.Common;
using DatPlex.DataModel;
using DatPlex.GUI.Main_Window;

namespace DatPlex.ViewModel
{
    public class LoginVM : BaseViewModel
    {
        #region Data Fields

        Window Parent;

        #endregion

        #region Constructor 

        public LoginVM()
        {
           
        }
        public void SetParent(Window iParent)
        {
            Parent = iParent;
        }

        #endregion

        #region General

        public void onLogin()
        {
            App.MainViewModel.PlexApp.Login_Task(Email, Password);
            App.MainViewModel.LoginVisibility = Visibility.Hidden;
            App.MainViewModel.MainScreenVisibility = Visibility.Visible;
        }

        #endregion

        #region Setters/Getters

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
            {
                //SHA256 hash = new SHA256Managed();
                //_password = hash.ComputeHash(value).ToString();  
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

        #endregion

        #region Command Bindings

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

        #endregion
    }
}
