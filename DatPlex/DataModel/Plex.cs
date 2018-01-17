using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatPlex.DataModel
{
    class Plex
    {
        private Account _owner;
        private List<Media> _media;
        private List<SharedUser> _sharedUsers;

        public Plex(Account a)
        {
            Owner = a;
        }

        public Account Owner
        {
            get { return _owner; }
            set
            {
                _owner = value;
            }
        }
    }
}
