﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using DatPlex.DataModel;

namespace DatPlex.Common
{
    class Utility
    {
        public static string PLEX_URL = "https://plex.tv/";             //Plex Base url
        public static string POST_SIGNIN = "users/sign_in.xml";         //Basic auth to sign in to plex.tv
        public static string GET_AUTH_KEY = "?X-Plex-Client-Identifier=unique"; //Gets server token from pms/servers.xml
        public static string GET_SERVERS = "servers.xml";               //Gets a list of servers and their sections
        public static string GET_DEVICES = "devices.xml";               //Gets a list of available clients and servers
        public static string GET_ACCOUNT_INFO = "users/account";        //Gets account information
        public static string GET_SERVER_SHARES = "pms/friends/all";     //Gets PMS server shares
        public static string GET_SERVER_REQS = "pms/friends/requests";  //Gets PMS server share requests
        public static string GET_CLIENT_IP = "pms/:/ip";                //Gets current client remote IP

        public static string XML_SAVE_PATH = "%APPDATA%/Plex Email/Account Data/";

        public static string USER_LABEL = "New Users: ";
        public static string NITEM_LABEL = "New Items: ";
        public static string RITEM_LABEL = "Removed Items: ";

        public static int MINUTES { get { return 60000; } }
        public static int HOURS { get { return 3600000; } }
        public static int DAYS { get { return 86400000; } }

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

