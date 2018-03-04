using System;
using System.Collections.ObjectModel;
using DatPlex.DataModel;

namespace DatPlex.Common
{
    public class Global
    {
        public static string PLEX_URL = "https://plex.tv";                             //Plex Base url
        public static string LOCAL_URL;                                                //Local Url         
        public static string TOKEN;                                                    //Plex Account Token 

        
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
        public static string GET_LIBRARIES = "/library/sections";                //Gets library details
        public static string GET_METADATA = "/library/metadata";

        //###########################################
        //Save Locations
        //###########################################
        public static string APPDATA = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        public static string XML_SAVE_PATH = APPDATA + @"\Plex Email Updater\";
        public static string LOG_SAVE_PATH = APPDATA + @"\Plex Email Updater\Logging\";


        public static string FOUND_LIBRARY = "**FOUND NEW LIBRARY** : ";
        public static string FOUND_FRIEND = "**FOUND NEW FRIEND** : ";
    }
}
