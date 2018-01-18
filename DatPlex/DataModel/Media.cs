using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatPlex.DataModel
{
    class Media
    {
        private int _id;
        private string _type;
        private string _title;
        private string _metadata;      

        public Media()
        {

        }

        public Media(string n)
        {
            Name = n;
        }

        public Media(string n, string l, string m)
        {
            Name = n;
            Library = l;
            MetaData = m;
        }

        public int Length
        {
            get { return _length; }
            set
            {
                _length = value;
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
            }
        }

        public string Library
        {
            get { return _library; }
            set
            {
                _library = value;
            }
        }

        public string MetaData
        {
            get { return _metadata; }
            set
            {
                _metadata = value;
            }
        }
    }
}
