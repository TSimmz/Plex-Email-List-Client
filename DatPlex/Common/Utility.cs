using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}

