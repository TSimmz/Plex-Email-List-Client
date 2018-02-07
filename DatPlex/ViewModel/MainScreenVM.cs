﻿using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using DatPlex.Common;
using DatPlex.DataModel;
using DatPlex.GUI.Main_Window;
using DatPlex.GUI.Child_Window;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace DatPlex.ViewModel
{
    public class MainScreenVM : BaseViewModel
    {
        #region Data Fields

        Window Parent;

        //int mFileViewIndex = -1;

        #endregion Data Fields

        #region Constructor

        public MainScreenVM()
        {
 
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

        DelegateCommand mSendSel_Cmd;
        public ICommand SendSel_Cmd
        {
            get
            {
                if (null == mSendSel_Cmd)
                    mSendSel_Cmd = new DelegateCommand(SendSelectedUsers);
                return mSendSel_Cmd;
            }
        }

        public void SendSelectedUsers(object obj)
        {

        }

        //public void Add_User_Button(object obj)
        //{
        //    Console.WriteLine("Add Button Pressed");

        //    Add_User mAddWindow = new Add_User();
        //    Add_UserVM mAddViewModel;

        //    if (SharedUsers_SelIndex != 0)
        //        mAddViewModel = new Add_UserVM(SharedUsers[SharedUsers_SelIndex]);
        //    else
        //        mAddViewModel = new Add_UserVM();

        //    mAddWindow.DataContext = mAddViewModel;
        //    mAddWindow.Show();
        //}

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
            Console.WriteLine("Timer: " + Timer);

            PlexScanner mScanWindow = new PlexScanner();
            mScanWindow.ShowDialog();
        }

        DelegateCommand mLogout_Cmd;
        public ICommand Logout_Cmd
        {
            get
            {
                if (null == mLogout_Cmd)
                    mLogout_Cmd = new DelegateCommand(Logout_Button);
                return mLogout_Cmd;
            }
        }

        public void Logout_Button(object obj)
        {
            //TODO: Logout procedure
        }

        private int _timer = 0;
        public int Timer
        {
            get { return _timer; }
            set
            {
                _timer = value;
                OnPropertyChanged();
            }
        }

        private int mUnits_SelIndex;
        public int Units_SelIndex
        {
            get { return mUnits_SelIndex; }
            set
            {
                mUnits_SelIndex = value;
            }
        }

        private ObservableCollection<SharedUser> mSharedUsers = new ObservableCollection<SharedUser> { new SharedUser("Default", "Default") };
        public ObservableCollection<SharedUser> SharedUsers
        {
            get { return mSharedUsers; }
            set
            {
                mSharedUsers = value;
                OnPropertyChanged();
            }
        }

        private int mSharedUsers_SelIndex = 0;
        public int SharedUsers_SelIndex
        {
            get { return mSharedUsers_SelIndex; }
            set
            {
                mSharedUsers_SelIndex = value;
            }
        }

        private bool mManual_State;
        public bool Manual_State
        {
            get { return mManual_State; }
            set
            {
                mManual_State = value;
                OnPropertyChanged();
                OnPropertyChanged("Automatic_State");
            }
        }

        private bool mAutomatic_State;
        public bool Automatic_State
        {
            get { return mAutomatic_State; }
            set
            {
                mAutomatic_State = value;
                OnPropertyChanged();
                OnPropertyChanged("Manual_State");
            }
        }

        private bool mSendSel_State;
        public bool SendSel_State
        {
            get { return mSendSel_State; }
            set
            {
                mSendSel_State = value;
                OnPropertyChanged();
                OnPropertyChanged("SendAll_State");
            }
        }

        private bool mSendAll_State;
        public bool SendAll_State
        {
            get { return mSendAll_State; }
            set
            {
                mSendAll_State = value;
                OnPropertyChanged();
                OnPropertyChanged("SendSel_State");
            }
        }

    }
}
