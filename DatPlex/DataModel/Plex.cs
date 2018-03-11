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
        #region Properties

        public string Filename { get; set; }
        public Account Owner { get; set; }
        public Tuple<string, string, string> ServerInfo { get; set; }
        public List<Library> LibraryList { get; set; }
        public List<Friend> FriendsList { get; set; }

        #endregion

        #region Constructors

        public Plex()
        {
            Owner = new Account();
            LibraryList = new List<Library>();
            FriendsList = new List<Friend>();

            //GenerateTestData();
        }

        #endregion

        public void GenerateTestData()
        {
            for (int i = 0; i < 5; i++)
            {
                Library l = new Library(i+1, "movie" + (i+1).ToString(), "title" + (i+1).ToString());
                LibraryList.Add(l);

                Friend f = new Friend("title" + i.ToString(), "username" + i.ToString(), "email" + i.ToString());
                FriendsList.Add(f);
            }
        }

        #region Load/Save

        public bool Load()
        {
            try
            {
                XmlReaderSettings settings = new XmlReaderSettings();
                settings.IgnoreWhitespace = true;

                try
                {
                    using (XmlReader reader = XmlReader.Create(Global.XML_SAVE_PATH, settings))
                    {
                        this.ReadXml(reader);
                    }
                }
                catch
                {
                    Thread.Sleep(50);
                    using (XmlReader reader = XmlReader.Create(Global.XML_SAVE_PATH, settings))
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

                using (XmlWriter writer = XmlWriter.Create(Global.XML_SAVE_PATH, settings))
                {
                    this.WriteXml(writer);
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
            // Plex 
            reader.MoveToContent();
            reader.ReadStartElement("Plex");

            // Server information
            reader.ReadStartElement("Server");
            ServerInfo = new Tuple<string, string, string>(reader.GetAttribute("ip"),
                                                            reader.GetAttribute("port"),
                                                            reader.GetAttribute("token"));
            reader.ReadEndElement();

            // Account information
            Owner.ReadXml(reader);

            // Libraries and media
            reader.ReadStartElement("LibraryList");
            while (reader.Name.Equals("Library") && reader.NodeType == XmlNodeType.Element)
            {
                LibraryList.Add(Library.ReadXml(reader));
            }
            reader.ReadEndElement();

            // Friends list 
            reader.ReadStartElement("FriendsList");
            while (reader.Name.Equals("Friend") && reader.NodeType == XmlNodeType.Element)
            {
                Friend friend = new Friend(
                    reader.GetAttribute("title"),
                    reader.GetAttribute("username"),
                    reader.GetAttribute("email"));

                FriendsList.Add(friend);
            }

            reader.ReadEndElement();
        }

        public void WriteXml(XmlWriter writer)
        {
            // Plex
            writer.WriteStartElement("Plex");

            // Server Information 
            writer.WriteStartElement("Server");
            writer.WriteAttributeString("ip", ServerInfo.Item1);
            writer.WriteAttributeString("port", ServerInfo.Item2);
            writer.WriteAttributeString("token", ServerInfo.Item3);
            writer.WriteEndElement();

            // Account information
            Owner.WriteXml(writer);
            
            // Libraries and media
            writer.WriteStartElement("LibraryList");
            foreach (Library library in LibraryList)
            {
                library.WriteXml(writer);
            }
            writer.WriteEndElement();

            // Friends list
            writer.WriteStartElement("FriendsList");
            foreach (Friend friend in FriendsList)
            {
                friend.WriteXml(writer);
            }

            writer.WriteEndElement();
            
            writer.WriteEndElement();

        }

        #endregion

        #region WebAPI



        #endregion
    }
}
