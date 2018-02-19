using System;
using System.Timers;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
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


        
        #endregion
    }
}
