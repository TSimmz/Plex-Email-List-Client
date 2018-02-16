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

namespace DatPlex.GUI.Child_Window
{
    /// <summary>
    /// Interaction logic for LogEntryViewer.xaml
    /// </summary>
    public partial class LogEntryViewer : UserControl
    {
        private string TestData = "Hello";
        private List<string> words;
        private int maxword;
        private int index;
        private Timer Timer;
        private Random random;

        public ObservableCollection<LogEntry> LogEntries { get; set; }

        public LogEntryViewer()
        {
            InitializeComponent();

            random = new Random();
            words = TestData.Split(' ').ToList();
            maxword = words.Count - 1;

            DataContext = LogEntries = new ObservableCollection<LogEntry>();

            Enumerable.Range(0, 5)
                      .ToList()
                      .ForEach(x => LogEntries.Add(GetRandomEntry()));

            Timer = new Timer(x => AddRandomEntry(), null, 100000, 1000);
        }


        private void AddRandomEntry()
        {
            Dispatcher.BeginInvoke((Action)(() => LogEntries.Add(GetRandomEntry())));
        }

        private LogEntry GetRandomEntry()
        {
            if (random.Next(1, 10) > 1)
            {
                return new LogEntry()
                {
                    Index = index++,
                    DateTime = DateTime.Now,
                    Message = string.Join(" ", Enumerable.Range(5, random.Next(10, 50))
                                                         .Select(x => words[random.Next(0, maxword)])),
                };
            }

            return new CollapsibleLogEntry()
            {
                Index = index++,
                DateTime = DateTime.Now,
                Message = string.Join(" ", Enumerable.Range(5, random.Next(10, 50))
                                                        .Select(x => words[random.Next(0, maxword)])),
                Contents = Enumerable.Range(5, random.Next(5, 10))
                                                .Select(i => GetRandomEntry())
                                                .ToList()
            };

        }
    }
}
