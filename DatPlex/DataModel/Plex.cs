using System;
using System.IO;
using System.Windows;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
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
        private Tuple<string, string, string> _serverInfo;
        private Account _owner;
        private FriendList _friendList;
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

        public FriendList FriendList
        {
            get { return _friendList; }
            set
            {
                _friendList = value;
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
            _friendList.ReadXml(reader);

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
            _friendList.WriteXml(writer);

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

        //public void Login_Task(string email, string password)
        //{
        //    //var token = GetToken(email, password);
        //}

        //TODO: URI is https://[ExternalIP]:[PORT]/

        //private static async Task<string> GetToken(string email, string password)
        //{
        //    using (var PlexAPI = new HttpClient())
        //    {
        //        PlexAPI.BaseAddress = new Uri(Utility.PLEX_URL);
        //        PlexAPI.DefaultRequestHeaders.Accept.Clear();
        //        //PlexAPI.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(Utility.PLEX_CLIENT_ID + "=q6j4irkusklo4164j61u6ea0"));
        //        PlexAPI.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        //        var login_credentials = new FormUrlEncodedContent(new[]
        //        {
        //             new KeyValuePair<string, string>("grant_type", "password"),
        //             new KeyValuePair<string, string>("email", email),
        //             new KeyValuePair<string, string>("password", password)
        //        });

        //        HttpResponseMessage response = await PlexAPI.PostAsync(Utility.POST_SIGNIN, login_credentials);

        //        var responseJSON = await response.Content.ReadAsStringAsync();
        //        var jObject = JObject.Parse(responseJSON);

        //        return jObject.GetValue("authToken").ToString();
        //    }
        //}

        public void Get_Friends()
        {
            try
            {

                #region HTTPCLIENT

                //using (var api = new HttpClient())
                //{
                //    api.BaseAddress = new Uri("https://192.168.0.5:32400");
                //    api.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));

                //    HttpRequestMessage request = new HttpRequestMessage
                //    (
                //        HttpMethod.Get,
                //        new Uri("/libary/sections/?X-Plex-Token=yedx66JT2HqyEd2xxf4m")
                //    );



                //    request.Content.Headers.ContentLength = 2065;
                //    request.Content.Headers.ContentType = new MediaTypeHeaderValue("text/xml;charset=utf-8");

                //    api.SendAsync(request).ContinueWith(responseTask =>
                //    {
                //        Console.WriteLine("Response: {0}", responseTask.Result);
                //    });

                //    HttpResponseMessage response = null;

                //    foreach (int i in Enumerable.Range(0, 25))
                //    {
                //        try
                //        {
                //            response = api.GetAsync(Utility.GET_LIBRARIES + "/?X-Plex-Token=yedx66JT2HqyEd2xxf4m").Result;
                //            break;
                //        }
                //        catch
                //        {
                //            Console.WriteLine("Error");
                //        }

                //    }


                //    string res = "";

                //    using (HttpContent c = response.Content)
                //    {
                //        Task<string> r = c.ReadAsStringAsync();
                //        res = r.Result;
                //    }
                //}
                #endregion

                string url = "https://192.168.0.5:32400/library/sections/?X-Plex-Token=yedx66JT2HqyEd2xxf4m";

                WebRequest request = WebRequest.CreateHttp(url);
                request.Method = "GET";
                //request.ContentType = "application/xml;charset=utf-8";

                ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

                using (WebResponse response = request.GetResponse())
                {
                    using (Stream stream = response.GetResponseStream())
                    {
                        StreamReader s = new StreamReader(stream);
                        string s1 = s.ReadToEnd();
                    }
                }



            }
            catch (Exception e)
            {
                Console.WriteLine("Response error:" + e.ToString());
            }
        }

        #endregion
    }
}
