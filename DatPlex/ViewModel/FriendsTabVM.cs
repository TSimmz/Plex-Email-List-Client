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
    public class FriendsTabVM
    {
        #region Data Fields

        Window Parent;

        #endregion Data Fields

        #region Constructor

        public FriendsTabVM()
        {

        }

        public void SetParent(Window iParent)
        {
            Parent = iParent;
        }

        #endregion

    }
}
