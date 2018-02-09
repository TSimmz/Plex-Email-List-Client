using System;
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
        #region Data Fields

        private int _id;
        private string _type;
        private string _title;
        private string _metadata;

        #endregion

        #region Constructors

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

        public Media(int i, string s, string t, string m)
        {
            ID = i;
            Type = s;
            Title = t;
            MetaData = m;
        }

        #endregion

        #region Properties

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

        #endregion
    }

    public partial class MediaList : ObservableCollection<Media>
    {

        #region Data Fields

        private ObservableCollection<Media> _mediaList;

        #endregion

        #region Constructor

        public MediaList()
        {
            _mediaList = new ObservableCollection<Media>();
        }

        #endregion

        #region Properties

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
            reader.ReadStartElement("MediaList");

            while (reader.Name.Equals("Media") && reader.NodeType == XmlNodeType.Element)
            {
                    Media m = new Media(
                        Convert.ToInt32(reader.GetAttribute("ID")),
                        reader.ReadElementString("Type"),
                        reader.ReadElementString("Title"),
                        reader.ReadElementString("MetaData"));

                    _mediaList.Add(m);                
            }

            reader.ReadEndElement();
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteStartElement("MediaList");

            foreach (Media m in _mediaList)
            {
                writer.WriteStartElement("Media");

                writer.WriteAttributeString("ID", m.ID.ToString());
                writer.WriteElementString("Type", m.Type);
                writer.WriteElementString("Title", m.Title);
                writer.WriteElementString("MetaData", m.MetaData);

                writer.WriteEndElement();
            }

            writer.WriteEndElement();
        }

        #endregion
    }
}
