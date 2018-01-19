using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatPlex.DataModel
{
    public class Media
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
            Title = n;
        }

        public Media(string n, string l)
        {
            Type = n;
            Title = l;
        }

        public int ID
        {
            get { return _id; }
            set
            {
                _id = value;
            }
        }

        public string Type
        {
            get { return _type; }
            set
            {
                _type = value;
            }
        }

        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
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
