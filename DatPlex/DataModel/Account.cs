using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatPlex.DataModel
{
    public class Account : User
    {
        private List<Media> _media;

        public Account(string u, string e, string p) : base(u, e, p)   
        {
            Username = u;
            Email = e;
            Password = p;
        }

    }
}
