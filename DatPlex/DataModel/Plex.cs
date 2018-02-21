﻿using System;
using System.IO;
using System.Windows;
using System.Collections.Generic;
using System.Threading.Tasks;
using DatPlex.Common;
using System.Xml;
using System.Threading;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace DatPlex.DataModel
{
    public class Plex
    {
        #region Data Fields

        private string _plexdata;
        private Tuple<string, string, string> _serverInfo;
        private Account _owner;
        private SharedUsers _sharedUserList;
        private List<Library> _libraries;

        #endregion

        #region Constructors

        public Plex()
        {

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

        public SharedUsers SharedUserList
        {
            get { return _sharedUserList; }
            set
            {
                _sharedUserList = value;
            }
        }

        public List<Library> Libraries
        {
            get { return _libraries; }
            set
            {
                _libraries = value;
            }
        }

        public Tuple<string, string, string> ServerInfo
        {
            get { return _serverInfo; }
            set
            {
                _serverInfo = value;
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
            _sharedUserList.ReadXml(reader);

            reader.ReadStartElement("Libraries");
            foreach (Library library in _libraries)
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
            _sharedUserList.WriteXml(writer);

            writer.WriteStartElement("Libraries");
            foreach (Library library in _libraries)
            {
                library.WriteXml(writer);
            }
            writer.WriteEndElement();

            writer.WriteEndElement();

        }

        #endregion

        #region WebAPI

        public bool Get_Plex_Data()
        {
            try
            {

                XmlDocument doc = new XmlDocument();
                //doc.Load(Utility.PLEX_URL + Utility.GET_SERVER_SHARES + Utility.Plex_Token);
                doc.Load("https://192.168.0.5:32400/" + Utility.GET_LIBRARIES + Utility.Plex_Token);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool GetRequest()
        {
            try
            {
                //using (var api = new HttpClient())
                //{
                //    api.BaseAddress = new Uri("https://192.168.0.5:32400/");
                //    api.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //    var response = api.GetAsync(Utility.GET_LIBRARIES + Utility.Plex_Token).Result;

                //    string res = "";

                //    using (HttpContent c = response.Content)
                //    {
                //        Task<string> r = c.ReadAsStringAsync();
                //        res = r.Result;
                //    }
                //}

                HttpRequest req = WebRequest.CreateHttp(@"https://192.168.0.5:32400/library/sections/?X-Plex-Token=yedx66JT2HqyEd2xxf4m");

                WebResponse res = req.GetResponse();

                return true;
            }
            catch (HttpRequestException e)
            {
                Console.Write(e.ToString());
                return false;
            }
        }

        #endregion
    }
}
