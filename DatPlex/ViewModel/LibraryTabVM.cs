using System;
using System.Timers;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using DatPlex.Common;
using DatPlex.DataModel;
using DatPlex.GUI.Main_Window;
using DatPlex.GUI.Child_Window;

namespace DatPlex.ViewModel
{
    public class LibraryTabVM : BaseViewModel
    {
        #region Data Fields

        Window Parent;



        private List<Library> _LibraryList;

        #endregion Data Fields

        #region Constructor

        public LibraryTabVM()
        {
            _LibraryList = new List<Library>();
            Library lib = new Library(1, 200, "movies");
            _LibraryList.Add(lib);
        }

        public void SetParent(Window iParent)
        {
            Parent = iParent;
        }

        #endregion


        #region Setters/Getters

        private int _SelIndex_Library;
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
