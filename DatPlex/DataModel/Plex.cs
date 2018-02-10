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
using System.Xml.Linq;
using Newtonsoft.Json.Linq;

namespace DatPlex.DataModel
{
    public class Plex
    {
        #region Data Fields

        private string _plexdata;
        private Account _owner;
        private SharedUsers _sharedUserList;
        private MediaList _mediaList;

        #endregion

        #region Constructors

        public Plex()
        {
            _owner = new Account();
            _sharedUserList = new SharedUsers();
            _mediaList = new MediaList();
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

        #endregion

        #region WebAPI

        public void Login_Task(string email, string password)
        {
            var token = GetToken(email, password);

        }

        //TODO: URI is https://[ExternalIP]:[PORT]/web

        private static async Task<string> GetToken(string email, string password)
        {
            using (var PlexAPI = new HttpClient())
            {
                PlexAPI.BaseAddress = new Uri(Utility.PLEX_URL);
                PlexAPI.DefaultRequestHeaders.Accept.Clear();
                PlexAPI.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var login_credentials = new FormUrlEncodedContent(new[]
                {
                     new KeyValuePair<string, string>("grant_type", "password"),
                     new KeyValuePair<string, string>("email", email),
                     new KeyValuePair<string, string>("password", password)
                });

                HttpResponseMessage response = await PlexAPI.PostAsync(Utility.GET_AUTH_KEY, login_credentials);

                var responseJSON = await response.Content.ReadAsStringAsync();
                var jObject = JObject.Parse(responseJSON);

                return jObject.GetValue("access_token").ToString();
            }
        }

        #endregion
    }
}
