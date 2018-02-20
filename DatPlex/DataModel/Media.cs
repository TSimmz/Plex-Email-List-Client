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

        public Media(int id, string type, string title, string summary, string content)
        {
            _id = id;
            _type = type;
            _title = title;
            _summary = summary;
            _contentRating = content;
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

        private bool _include;
        private int _key;
        private int _itemCount;
        private string _title;
        private CheckBox _included;
        private List<Media> _mediaList;

        #endregion

        #region Constructor

        public Library(int key, int count, string title)
        {
            _include = false;
            _included = new CheckBox();
            _key = key;
            _itemCount = count;
            _title = title;
            _mediaList = new List<Media>();
        }

        public int GetLibKey { get { return _key; } }

        public int GetItemCount { get { return _itemCount; } }

        public string GetLibTitle { get { return _title; } }

        public CheckBox Include { get { return _included; } }

        #endregion

        #region General

        public bool Include_Library
        {
            get { return _include; }
            set
            {
                _include = value;
            }
        }

        #endregion

        #region Add/Remove Logic

        public bool AddMedia(Media media)
        {
            try
            {
                _mediaList.Add(media);
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
                _mediaList.Remove(media);
                return true;
            }
            catch
            {
                return false;
            }
        }

        #endregion

        #region Read/Write Xml

        public void ReadXml(XmlReader reader)
        {

            reader.ReadStartElement("Library");
            _key = Convert.ToInt32(reader.GetAttribute("key"));
            _title = reader.GetAttribute("title");

            while (reader.Name.Equals("Media") && reader.NodeType == XmlNodeType.Element)
            {
                Media m = new Media(
                    Convert.ToInt32(reader.GetAttribute("id")),
                    reader.GetAttribute("type"),
                    reader.GetAttribute("title"),
                    reader.GetAttribute("contentRating"),
                    reader.GetAttribute("summary"));

                _mediaList.Add(m);
            }

            reader.ReadEndElement();
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
