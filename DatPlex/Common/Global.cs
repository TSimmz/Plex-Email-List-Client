using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatPlex.Common
{
    class Global
    {
        public static string PLEX_URL = "https://plex.tv";                             //Plex Base url
        //public static string LOCAL_URL = "https://" + Plex_IP + ":" + Plex_Port + "/";  //Local plex url
        //public static string TOKEN = "/?X-Plex-Token=yedx66JT2HqyEd2xxf4m";                                 //Plex Account Token 

        //###########################################
        // Plex URL Requests
        //###########################################
        public static string GET_ACCOUNT_INFO = "/users/account";                //Gets account information
        public static string GET_SERVER_SHARES = "/pms/friends/all";             //Gets PMS server shares
        public static string GET_SERVER_REQS = "/pms/friends/requests";          //Gets PMS server share requests
        public static string GET_CLIENT_IP = "/pms/:/ip";                        //Gets current client remote IP

        //###########################################
        //Local URL Requests
        //###########################################
        public static string GET_LIBRARIES = "/library/sections";
        public static string GET_METADATA = "/library/metadata";

        public static string XML_SAVE_PATH = "%APPDATA%/Plex Email/Account Data/";

        public static string FOUND_LIBRARY = "**FOUND NEW LIBRARY** : ";
        public static string FOUND_FRIEND = "**FOUND NEW FRIEND** : ";

        public static int MINUTES { get { return 60000; } }
        public static int HOURS { get { return 3600000; } }
        public static int DAYS { get { return 86400000; } }
    }
}
