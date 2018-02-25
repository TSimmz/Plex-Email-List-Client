using System.Collections.Generic;
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
            //_LibraryList = new List<Library>();
            //Library lib = new Library(1, 200, "movies");
            //Library lib1 = new Library(3, 59, "tv shows");
            //_LibraryList.Add(lib);
            //_LibraryList.Add(lib1);
        }

        public void SetParent(Window iParent)
        {
            Parent = iParent;
        }

        #endregion

        #region General

        public void UpdateLibraries()
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

        private bool _Include;
        public bool Include_Library
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

        #region Command Bindings

        DelegateCommand _UpdateLibrary_Cmd;
        public ICommand UpdateLibrary_Cmd
        {
            get
            {
                if (_UpdateLibrary_Cmd == null)
                    _UpdateLibrary_Cmd = new DelegateCommand(UpdateLibraries);
                return _UpdateLibrary_Cmd;
            }
        }

        #endregion
    }
}
