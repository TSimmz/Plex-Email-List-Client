using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatPlex.DataModel
{
    class User
    {
        private string _name;
        private string _email;
        private List<string> _libraries;

        public User(string n, string e)
        {
            Name = n;
            Email = e;
        }

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
            }
        }

        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
            }
        }

        public List<string> Libraries
        {
            get { return _libraries; }
            set
            {
                if (value != null)
                    _libraries.Add(value.ToString());
            }
        }
    }
}
