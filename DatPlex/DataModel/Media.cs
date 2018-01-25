﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

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

    public partial class MediaList : ObservableCollection<Media>
    {
        ObservableCollection<Media> _mediaList;

        public MediaList()
        {
            _mediaList = new ObservableCollection<Media>();
        }

        public void ReadXml(XmlReader reader)
        {

        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteStartElement("MediaList");

            foreach (Media m in _mediaList)
            {
                writer.WriteStartElement("Media");

                writer.WriteElementString("ID", m.ID.ToString());
                writer.WriteElementString("Type", m.Type);
                writer.WriteElementString("Title", m.Title);
                writer.WriteElementString("MetaData", m.MetaData);

                writer.WriteEndElement();
            }

            writer.WriteEndElement();
        }
    }
}
