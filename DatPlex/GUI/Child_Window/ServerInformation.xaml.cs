using System;
using System.Windows;
using System.Collections.Generic;
using DatPlex.Common;

namespace DatPlex.GUI.Child_Window
{
    /// <summary>
    /// Interaction logic for ServerInformation.xaml
    /// </summary>
    public partial class ServerInformation : Window
    {
        public ServerInformation()
        {
            InitializeComponent();
        }

        private string _IP_Address;
        public string IP_Address
        {
            get { return _IP_Address; }
            set
            {
                _IP_Address = (_IP_Address != value) ? value : _IP_Address;
            }
        }

        private string _Port_Number;
        public string Port_Number
        {
            get { return _Port_Number; }
            set
            {
                _Port_Number = (_Port_Number != value) ? value : _Port_Number;
            }
        }

        private string _Plex_Token;
        public string Plex_Token
        {
            get { return _Plex_Token; }
            set
            {
                _Plex_Token = (_Plex_Token != value) ? value : _Plex_Token;
            }
        }

        private void OK_Click(object obj, RoutedEventArgs e)
        {
            Utility.Plex_IP = IP_Address;
            Utility.Plex_Port = Port_Number;
            Utility.Plex_Token = Plex_Token;

            Tuple<string, string, string> info = new Tuple<string, string, string>(IP_Address, Port_Number, Plex_Token);

            App.MainViewModel.PlexApp.ServerInfo = info;
        }

        private void Cancel_Click(object obj, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
