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

        //int mFileViewIndex = -1;

        #endregion Data Fields

        #region Constructor

        public MainViewModel()
        {
            BgWorker = new BackgroundWorker();
            BgWorker.WorkerReportsProgress = true;
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

        DelegateCommand mDel_User_Cmd;
        public ICommand Del_User_Cmd
        {
            get
            {
                if (null == mDel_User_Cmd)
                    mDel_User_Cmd = new DelegateCommand(Del_User_Button);
                return mDel_User_Cmd;
            }
        }

        public void Del_User_Button(object obj)
        {
            Console.WriteLine("Remove Button Pressed");
        }

        DelegateCommand mScan_Plex_Cmd;
        public ICommand Scan_Plex_Cmd
        {
            get
            {
                if (null == mScan_Plex_Cmd)
                    mScan_Plex_Cmd = new DelegateCommand(Scan_Plex_Button);
                return mScan_Plex_Cmd;
            }
        }

        public void Scan_Plex_Button(object obj)
        {
            Console.WriteLine("Scan Plex Button Pressed");
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
            Application.Current.Shutdown();
        }
    }
}
