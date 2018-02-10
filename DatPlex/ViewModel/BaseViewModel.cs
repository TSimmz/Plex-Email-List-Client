using System;
using System.ComponentModel;
using System.Collections.Generic;
using DatPlex.DataModel;
using System.Windows;
using System.Windows.Threading;

namespace DatPlex.ViewModel
{
    [Serializable]
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        #region Data Fields

        private static readonly Dictionary<string, PropertyChangedEventArgs> eventArgCache;

        #endregion

        #region Constructor

        static BaseViewModel()
        {
            eventArgCache = new Dictionary<string, PropertyChangedEventArgs>();
        }

        protected BaseViewModel() { }

        #endregion

        #region Event Handlers
        public event EventHandler _setKeyboardFocus;
        protected virtual void SetKeyboardFocus()
        {
            EventHandler handler = _setKeyboardFocus;
            if (handler != null)
            {
                //handler(this, e);
                Application.Current.Dispatcher.BeginInvoke(
                    DispatcherPriority.Background,
                    new Action(() => _setKeyboardFocus.Invoke(this, null)));
            }
        }

        public event EventHandler _registerScrollPosition;
        protected virtual void registerScrollPosition()
        {
            if (_registerScrollPosition != null)
                _registerScrollPosition.Invoke(this, null);
        }

        public event EventHandler _returnToScrollPosition;
        protected virtual void returnToScrollPosition()
        {
            if (_returnToScrollPosition != null)
                _returnToScrollPosition.Invoke(this, null);
        }
        #endregion Event Handlers

        #region INotifyPropertyChanged Members

        /// <summary>
        /// Raised when a public property of this object is set.
        /// </summary>
        [field: NonSerialized]
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion 

        #region Protected Methods

        protected virtual void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] String caller = null)
        {
            var handler = PropertyChanged;
            if (handler != null && this.PropertyChanged != null)
            {
                handler(this, new PropertyChangedEventArgs(caller));
            }
        }

        #endregion Protect Methods
    }
}
