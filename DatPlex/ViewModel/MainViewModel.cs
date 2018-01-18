using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Media;
//using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Documents;
using System.Windows.Threading;
using System.Threading;
using Microsoft.Win32;
using DatPlex.Common;

namespace DatPlex.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        #region Data Fields

        Window Parent;

        public BackgroundWorker BgWorker;
        string mSelectedFileType;

        public event EventHandler TaskStarting = (s, e) => { };

        int mFileViewIndex = -1;

        #region Button Declaration

        private readonly Button _Add_User;
        public Button Add_User { get { return _Add_User; } }

        private readonly Button _Del_User;
        public Button Del_User { get { return _Del_User; } }

        private readonly Button _Scan_Plex;
        public Button Scan_Plex { get { return _Scan_Plex; } }
        
        //private readonly RadioButton _Manual;
        //public RadioButton Manual { get { return _Manual; } }

        //private readonly RadioButton _Automatic;
        //public RadioButton Automatic { get { return _Automatic; } }

        //private readonly ComboBox _Plex_Accounts;
        //public ComboBox Plex_Accounts { get { return _Plex_Accounts; } }

        //private readonly TextBox _Timer_Box;
        //public TextBox Timer_Box { get { return _Timer_Box; } }

        //private readonly ComboBox _Units;
        //public ComboBox Units { get { return _Units; } }

        //private readonly ListView _User_List;
        //public ListView User_List { get { return User_List; } }

        #endregion Button Declaration

        #endregion Data Fields

        #region Constructor

        public MainViewModel()
        {
            BgWorker = new BackgroundWorker();
            BgWorker.WorkerReportsProgress = true;

            _Add_User = new Button(Add_User_Button);
            //_Del_User = new Button(del_user);
            //_Scan_Plex = new Button(scan_plex);

            //_Manual = new RadioButton(manual);
            //_Automatic = new RadioButton(automatic);

            //_Plex_Accounts = new ComboBox(plex_accounts);
            //_Units = new ComboBox(units);

            //_Timer_Box = new TextBox(timer_box);

            //_User_List = new ListView(user_list);
        }

        public void SetParent(Window iParent)
        {
            Parent = iParent;
        }

        #endregion Constructor

        #region General

        private string mWindowTitle = "Plex Email Updates";
        public string WindowTitle
        {
            get { return mWindowTitle; }
            set
            {
                mWindowTitle = value;
                OnPropertyChanged("WindowTitle");
            }
        }

        #endregion General

        DelegateCommand mAdd_User_Cmd;
        public ICommand Add_User_Cmd
        {
            get
            {
                if (null == mAdd_User_Cmd)
                    mAdd_User_Cmd = new DelegateCommand(Add_User_Button);
                return mAdd_User_Cmd;
            }
        }

        public void Add_User_Button(object obj)
        {
            Console.WriteLine("Add Button Pressed");
        }
    }
}
