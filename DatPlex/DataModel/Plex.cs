using System;
using System.IO;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using DatPlex.Common;
using System.Xml;
using System.Threading;

namespace DatPlex.DataModel
{
    public class Plex
    {
        private HttpClient _plex_api;

        private string _plexdata;
        private Account _owner;
        private SharedUsers _sharedUserList;
        private MediaList _mediaList;

        public Plex(Account a)
        {
            _owner = a;
            _sharedUserList = new SharedUsers();
            _mediaList = new MediaList();

            _plex_api = new HttpClient();
        }

        public string PlexSaveData
        {
            get { return _plexdata; }
            set
            {
                _plexdata = value;
            }
        }

        public Account Owner
        {
            get { return _owner; }
            set
            {
                _owner = value;
                PlexSaveData = "PlexData_" + Owner.Email + ".xml";
            }
        }

        public SharedUsers SharedUserList
        {
            get { return _sharedUserList; }
            set
            {
                _sharedUserList = value;
            }
        }

        public MediaList MediaList
        {
            get { return _mediaList; }
            set
            {
                _mediaList = value;
            }
        }

        public HttpClient PlexAPI
        {
            get { return _plex_api; }
            set
            {
                _plex_api = value;
            }
        }
       
        public bool Load()
        {
            try
            {
                XmlReaderSettings settings = new XmlReaderSettings();
                settings.IgnoreWhitespace = true;

                try
                {
                    using (XmlReader reader = XmlReader.Create(PlexSaveData, settings))
                    {
                        this.ReadXml(reader);
                    }
                }
                catch (IOException ex)
                {
                    Thread.Sleep(50);
                    using (XmlReader reader = XmlReader.Create(PlexSaveData, settings))
                    {
                        this.ReadXml(reader);
                    }
                }

                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("Failed to read the input file. Returning with error: " + e.ToString(), "Error Reading File",
                   MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }
        
        public bool Save()
        {
            try
            {
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;
                settings.IndentChars = "\t";
                settings.ConformanceLevel = ConformanceLevel.Fragment;

                Directory.CreateDirectory(Utility.XML_SAVE_PATH);

                using (XmlWriter writer = XmlWriter.Create(PlexSaveData, settings))
                {
                    this.WriteXml(writer, false);
                    writer.Flush();
                    writer.Close();
                }

                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("Failed to read the input file. Returning with error: " + e.ToString(), "Error Reading File",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }
        
        public void ReadXml(XmlReader reader)
        {
            reader.ReadStartElement("Plex");
            Owner.SignedIn = Convert.ToBoolean(reader.ReadElementString("SignedIn"));

            _owner.ReadXml(reader);
            _sharedUserList.ReadXml(reader);
            _mediaList.ReadXml(reader);

            reader.ReadEndElement();
        }

        public void WriteXml(XmlWriter writer, bool hasWrittenVersion)
        {
            writer.WriteStartElement("Plex");

            writer.WriteElementString("SignedIn", Owner.SignedIn.ToString());

            Owner.WriteXml(writer);
            SharedUserList.WriteXml(writer);
            MediaList.WriteXml(writer);

            writer.WriteEndElement();

        }

        //static async Task RunAsync(HttpClient p)
        //{
        //    // Update port # in the following line.
        //    p.BaseAddress = new Uri(Utility.PLEX_URL);
        //    p.DefaultRequestHeaders.Accept.Clear();
        //    p.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //}
    }
}
