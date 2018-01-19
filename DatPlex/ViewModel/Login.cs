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

namespace DatPlex.ViewModel
{
    public class Login : BaseViewModel
    {
        Window Parent;
        
        public Login()
        {

        }

        public void SetParent(Window iParent)
        {
            Parent = iParent;
        }

        private string _email;
        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyChanged();
            }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged();
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
            //Allows user to log into tool. 
        }
    }
}
