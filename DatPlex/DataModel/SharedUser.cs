using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DatPlex.DataModel
{
    public class SharedUser : User
    {
        private bool _include;

        #region Constructor

        public SharedUser(string title, string username, string email): base(title, username, email)
        {
            Title = title;
            Username = username;
            Email = email;
        }

        #endregion

        #region General

        public bool Include_SharedUser
        {
            get { return _include; }
            set
            {
                _include = value;
            }
        }

        #endregion

    }

    public class SharedUsers : ObservableCollection<SharedUsers>
    {
        #region Data Fields

        private ObservableCollection<SharedUser> _sharedUserList;

        #endregion

        #region Constructor

        public SharedUsers()
        {
            _sharedUserList = new ObservableCollection<SharedUser>();  
        }

        #endregion

        #region Add/Remove Logic

        public bool AddUser(SharedUser user)
        {
            try
            {
                _sharedUserList.Add(user);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool RemoveUser(SharedUser user)
        {
            try
            {
                _sharedUserList.Remove(user);
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
            reader.ReadStartElement("SharedUserList");

            while (reader.Name.Equals("SharedUser") && reader.NodeType == XmlNodeType.Element)
            {
                    SharedUser s = new SharedUser(
                        reader.GetAttribute("title"),
                        reader.GetAttribute("username"),
                        reader.GetAttribute("email"));

                    _sharedUserList.Add(s);
            }
            reader.ReadEndElement();
        }


        public void WriteXml(XmlWriter writer)
        {
            writer.WriteStartElement("SharedUserList");

            foreach(SharedUser s in _sharedUserList)
            {
                writer.WriteStartElement("SharedUser");

                writer.WriteAttributeString("title", s.Title);
                writer.WriteAttributeString("username", s.Username);
                writer.WriteAttributeString("email", s.Email);

                writer.WriteEndElement();
            }

            writer.WriteEndElement();

        }

        #endregion

    }
}
