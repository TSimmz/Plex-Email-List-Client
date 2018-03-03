using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;
using DatPlex.DataModel;
using DatPlex.Common;

namespace DatPlex.GUI.Child_Window
{
    /// <summary>
    /// Interaction logic for LogEntryViewer.xaml
    /// </summary>
    public partial class LogEntryViewer : UserControl
    {
        public LogEntryViewer()
        {
            InitializeComponent();
            this.DataContext = App.MainViewModel.LogEntryList;
        }



        #region Random

        //private void AddRandomEntry()
        //{
        //    Dispatcher.BeginInvoke((Action)(() => LogEntries.Add(GetRandomEntry())));
        //}

        //private LogEntry GetRandomEntry()
        //{
        //    if (random.Next(1, 10) > 1)
        //    {
        //        return new LogEntry()
        //        {
        //            Index = index++,
        //            DateTime = DateTime.Now,
        //            Message = string.Join(" ", Enumerable.Range(5, random.Next(10, 50))
        //                                                 .Select(x => words[random.Next(0, maxword)])),
        //        };
        //    }

        //    return new CollapsibleLogEntry()
        //    {
        //        Index = index++,
        //        DateTime = DateTime.Now,
        //        Message = string.Join(" ", Enumerable.Range(5, random.Next(10, 50))
        //                                                .Select(x => words[random.Next(0, maxword)])),
        //        Contents = Enumerable.Range(5, random.Next(5, 10))
        //                                        .Select(i => GetRandomEntry())
        //                                        .ToList()
        //    };

        //}

        #endregion

    }
}
