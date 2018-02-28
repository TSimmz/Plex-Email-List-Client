using System;
using System.Windows;
using System.Windows.Input;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatPlex.Common;
using DatPlex.DataModel;

namespace DatPlex.ViewModel
{
    public class SharingTabVM : BaseViewModel
    {
        Window Parent;
        private FriendList _FriendList;
        private List<Library> _LibraryList;

        public SharingTabVM()
        {
            _FriendList = new FriendList();
            _LibraryList = new List<Library>();
        }


        public void SetParent(Window iParent)
        {
            Parent = iParent;
        }

        private int _SelIndex_Friend = -1;
        public int SelIndex_Friend
        {
            get { return _SelIndex_Friend; }
            set
            {
                _SelIndex_Friend = value;
                OnPropertyChanged();
            }
        }

        public FriendList FriendList
        {
            get { return _FriendList; }
            set
            {
                _FriendList = value;
                OnPropertyChanged();
            }
        }

        public List<Friend> FriendsList
        {
            get { return _FriendList.GetList; }
        }
        private bool _Include_Friend;
        public bool Include_Friend
        {
            get { return _Include_Friend; }
            set
            {
                _Include_Friend = value;
            }
        }

        private bool _IsLibrarySelected = false;
        public bool IsLibrarySelected
        {
            get { return _IsLibrarySelected; }
            set
            {
                _IsLibrarySelected = value;
                OnPropertyChanged("Include");
            }
        }

        #region General

        public void RefreshLibraries()
        {
            // TODO: Update Libraries function
        }

        #endregion

        #region Setters/Getters

        private int _SelIndex_Library = -1;
        public int SelIndex_Library
        {
            get { return _SelIndex_Library; }
            set
            {
                _SelIndex_Library = value;
                OnPropertyChanged();
            }
        }

        public List<Library> LibraryList
        {
            get { return _LibraryList; }
            set
            {
                _LibraryList = value;
                OnPropertyChanged();
            }
        }

        private bool _Include_Library;
        public bool Include_Library
        {
            get { return _Include_Library; }
            set
            {
                _Include_Library = value;
            }
        }

        private bool _IsFriendSelected = false;
        public bool IsFriendSelected
        {
            get { return _IsFriendSelected; }
            set
            {
                _IsFriendSelected = value;
                OnPropertyChanged("Include");
            }
        }

        #endregion

        #region Command Bindings

        DelegateCommand _RefreshLibraries_Cmd;
        public ICommand RefreshLibraries_Cmd
        {
            get
            {
                if (_RefreshLibraries_Cmd == null)
                    _RefreshLibraries_Cmd = new DelegateCommand(RefreshLibraries);
                return _RefreshLibraries_Cmd;
            }
        }

        #endregion
    }
}
