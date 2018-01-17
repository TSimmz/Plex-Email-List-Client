using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatPlex.DataModel
{
    class Account : User
    {
        private List<Media> _media;

        public Account(string n, string e) : base(n, e)
        {
            Name = n;
            Email = e;
        }

        public List<Media> Media { get { return _media; } }
    }
}
