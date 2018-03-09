using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Windows.Controls;

namespace DatPlex.DataModel
{
    public class Media
    {
        #region Data Fields

        private int _id;
        private string _type;
        private string _title;
        private string _summary;
        private string _contentRating;

        #endregion

        #region Constructors

        public Media(int id, string type, string title, string content, string summary)
        {
            _id = id;
            _type = type;
            _title = title;
            _contentRating = content;
            _summary = summary;
           
        }

        #endregion

        #region Setters/Getters

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

        public string Summary
        {
            get { return _summary; }
            set
            {
                _summary = value;
            }
        }

        public string ContentRating
        {
            get { return _contentRating; }
            set
            {
                _contentRating = value;
            }
        }

        #endregion
    }

    public class Library
    {
        #region Data Fields

        #endregion

        #region Constructor

        public Library ()
        {

        }
        
        public Library(int key, string type, string title)
        {
            Include_Library = false;
            KeyID = key;
            //_itemCount = count;
            Type = type;
            Title = title;
            _MediaList = new List<Media>();
        }

        public bool Include_Library { get; set; }

        public int KeyID { get; set; }

        public string Type { get; set; }

        public int ItemCount { get; set; }

        public string Title { get; set; }

        public List<Media> MediaList { get; set; }
        
        #endregion

        #region Add/Remove Logic

        public bool AddMedia(Media media)
        {
            try
            {
                MediaList.Add(media);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool RemoveMedia(Media media)
        {
            try
            {
                MediaList.Remove(media);
                return true;
            }
            catch
            {
                return false;
            }
        }

        #endregion

        #region Read/Write Xml

        public static Library ReadXml(XmlReader reader)
        {
            Library library = new Library();

            reader.ReadStartElement("Library");

            library.KeyID = Convert.ToInt32(reader.GetAttribute("key"));
            library.Title = reader.GetAttribute("title");

            while (reader.Name.Equals("Media") && reader.NodeType == XmlNodeType.Element)
            {
                Media m = new Media(
                    Convert.ToInt32(reader.GetAttribute("id")),
                    reader.GetAttribute("type"),
                    reader.GetAttribute("title"),
                    reader.GetAttribute("contentRating"),
                    reader.GetAttribute("summary"));

                library.MediaList.Add(m);
            }

            reader.ReadEndElement();

            return library;
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteStartElement("Library");
            writer.WriteAttributeString("key", _key.ToString());
            writer.WriteAttributeString("title", _title);

            foreach (Media m in _mediaList)
            {
                writer.WriteStartElement("Media");

                writer.WriteAttributeString("id", m.ID.ToString());
                writer.WriteAttributeString("type", m.Type);
                writer.WriteAttributeString("title", m.Title);
                writer.WriteAttributeString("contentRating", m.ContentRating);
                writer.WriteAttributeString("summary", m.Summary);

                writer.WriteEndElement();
            }

            writer.WriteEndElement();
        }

        #endregion
    }
}
