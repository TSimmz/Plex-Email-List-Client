using System;
using System.IO;
using System.Windows;
using System.Xml;
using System.Threading;
using System.Collections.Generic;
using System.Net;
using DatPlex.Common;

namespace DatPlex.DataModel
{
    public class Plex
    {
        #region Data Fields

        private string _plexdata;
        private string _localURL;
        private string _plexToken;
        private Tuple<string, string, string> _serverInfo;
        private Account _owner;
        private List<Friend> _friendsList;
        private List<Library> _libraryList;

        #endregion

        #region Constructors

        public Plex()
        {
            _libraryList = new List<Library>();
        }

        #endregion

        #region Setters/Getters

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
                _plexdata = "PlexData_" + _owner.Email + ".xml";
            }
        }

        public List<Friend> FriendsList
        {
            get { return _friendsList; }
            set
            {
                _friendsList = value;
            }
        }

        public List<Library> LibraryList
        {
            get { return _libraryList; }
            set
            {
                _libraryList = value;
            }
        }

        public void AddLibrary(Library l)
        {
            _libraryList.Add(l);
        }

        public Tuple<string, string, string> ServerInfo
        {
            get { return _serverInfo; }
            set
            {
                _serverInfo = value;
                LocalURL = "https://" + _serverInfo.Item1 + ":" + _serverInfo.Item2;
                PlexToken = "/?X-Plex-Token=" + _serverInfo.Item3;
            }
        }

        public string LocalURL
        {
            get { return _localURL; }
            set
            {
                _localURL = value;
            }
        }
        public string PlexToken
        {
            get { return _plexToken; }
            set
            {
                _plexToken = value;
            }
        }


        #endregion

        #region Load/Save

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
                catch
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

                Directory.CreateDirectory(Global.XML_SAVE_PATH);

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

        #endregion

        #region Read/Write Xml

        public void ReadXml(XmlReader reader)
        {
            reader.MoveToContent();
            reader.ReadStartElement("Plex");

            reader.ReadStartElement("Server");
            _serverInfo = new Tuple<string, string, string>(reader.GetAttribute("ip"),
                                                            reader.GetAttribute("port"),
                                                            reader.GetAttribute("token"));
            reader.ReadEndElement();

            _owner.ReadXml(reader);
            //_friendList.ReadXml(reader);

            reader.ReadStartElement("Libraries");
            foreach (Library library in _libraryList)
            {
                library.ReadXml(reader);
            }
            reader.ReadEndElement();

            reader.ReadEndElement();
        }

        public void WriteXml(XmlWriter writer, bool hasWrittenVersion)
        {
            writer.WriteStartElement("Plex");

            writer.WriteStartElement("Server");
            writer.WriteAttributeString("ip", ServerInfo.Item1);
            writer.WriteAttributeString("port", ServerInfo.Item2);
            writer.WriteAttributeString("token", ServerInfo.Item3);
            writer.WriteEndElement();

            _owner.WriteXml(writer);
            //_friendList.WriteXml(writer);

            writer.WriteStartElement("Libraries");
            foreach (Library library in _libraryList)
            {
                library.WriteXml(writer);
            }
            writer.WriteEndElement();

            writer.WriteEndElement();

        }

        #endregion

        #region WebAPI



        #endregion
    }
}
