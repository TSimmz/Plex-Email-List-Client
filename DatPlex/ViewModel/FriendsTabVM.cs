using System;
using System.Timers;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using DatPlex.Common;
using DatPlex.DataModel;
using DatPlex.GUI.Main_Window;
using DatPlex.GUI.Child_Window;

namespace DatPlex.ViewModel
{
    public class FriendsTabVM : BaseViewModel
    {
        #region Data Fields

        Window Parent;

        private SharedUsers _FriendsList;

        #endregion Data Fields

        #region Constructor

        public FriendsTabVM()
        {
            _FriendsList = new SharedUsers();
            SharedUser u = new SharedUser("title", "username", "email@email");
            _FriendsList.AddUser(u);
        }

        public void SetParent(Window iParent)
        {
            Parent = iParent;
        }

        public SharedUsers FriendsList
            {
            get { return _FriendsList; }
            set
            {
                _FriendsList = value;
                OnPropertyChanged();
            }
        }

        private bool _Include;
        public bool Include
        {
            get { return _Include; }
            set
            {
                _Include = value;
            }
        }

        private bool _IsSelected = false;
        public bool IsSelected
        {
            get { return _IsSelected; }
            set
            {
                _IsSelected = value;
                OnPropertyChanged("Include");
            }
        }

        #endregion

    }
}
