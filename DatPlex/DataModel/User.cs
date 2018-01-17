using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatPlex.DataModel
{
    class User
    {
        private string _Name;
        private string _Email;
        private List<string> _Libraries;

        public User(string n, string e)
        {
            Name = n;
            Email = e;
        }

        public string Name
        {
            get { return _Name; }
            set
            {
                _Name = value;
            }
        }

        public string Email
        {
            get { return _Email; }
            set
            {
                _Email = value;
            }
        }

        public List<string> Libraries
        {
            get { return _Libraries; }
            set
            {
                if (value != null)
                    _Libraries.Add(value.ToString());
            }
        }
    }
}
