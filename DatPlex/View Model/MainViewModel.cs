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
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Documents;
using System.Windows.Threading;
using System.Threading;
using Microsoft.Win32;

namespace DatPlex.View_Model
{
    class MainViewModel
    {
        #region Data Fields

        Window Parent;

        public BackgroundWorker BgWorker;
        string mSelectedFileType;

        public event EventHandler TaskStarting = (s, e) => { };

        int mFileViewIndex = -1;

        #endregion Data Fields

        #region Constructor

        public MainViewModel()
        {
            BgWorker = new BackgroundWorker();
            BgWorker.WorkerReportsProgress = true;

            //
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
                //OnPropertyChanged();
            }
        }

        #endregion General
    }
}
