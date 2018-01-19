using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using DatPlex.Common;

namespace DatPlex.DataModel
{
    public class Plex
    {
        private HttpClient _plex_api;
        private Account _owner;
        private List<Media> _media;
        private List<SharedUser> _sharedUsers;

        public Plex(Account a)
        {
            Owner = a;
            _plex_api = new HttpClient();

        }

        public Account Owner
        {
            get { return _owner; }
            set
            {
                _owner = value;
            }
        }

        //static async Task RunAsync(HttpClient p)
        //{
        //    // Update port # in the following line.
        //    p.BaseAddress = new Uri(Utility.PLEX_URL);
        //    p.DefaultRequestHeaders.Accept.Clear();
        //    p.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //}
    }
}
