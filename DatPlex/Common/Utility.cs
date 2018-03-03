using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;
using DatPlex.DataModel;

namespace DatPlex.Common
{
    public class Utility
    {
        public static ObservableCollection<LogEntry> LogEntryList { get; set; }
        public static int LogIndex { get; set; }
        public static void LogEntry(string message)
        {
            LogEntryList.Add(new LogEntry() { DateTime = DateTime.Now, Index = LogIndex++, Message = message });
        }

        public static void IMPLEMENT(string method)
        {
            MessageBox.Show(method + " not implemented.", "NOT IMPLEMENTED", MessageBoxButton.OK, MessageBoxImage.Exclamation);
        }
        public static Object LoadXmlData(string path)
        {
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.IgnoreWhitespace = true;

            using (XmlReader reader = XmlReader.Create(path, settings))
            {
                Plex obj = new Plex();
                obj.ReadXml(reader);
                return obj;
            }
        }
    }
}

