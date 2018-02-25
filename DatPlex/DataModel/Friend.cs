using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DatPlex.DataModel
{
    public class Friend : User
    {
        private bool _include;

        #region Constructor

        public Friend(string title, string username, string email) : base(title, username, email)
        {
            _include = false;
            Title = title;
            Username = username;
            Email = email;
        }

        #endregion

        #region General

        public bool Include_Friend
        {
            get { return _include; }
            set
            {
                _include = value;
            }
        }

        #endregion

    }

    public class FriendList : List<Friend>
    {
        #region Data Fields

        private List<Friend> _friendList;

        #endregion

        #region Constructor

        public FriendList()
        {
            _friendList = new List<Friend>();
        }

        #endregion

        #region General
        
        #region Add/Remove Logic

        public bool AddUser(Friend friend)
        {
            try
            {
                _friendList.Add(friend);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool RemoveUser(Friend friend)
        {
            try
            {
                _friendList.Remove(friend);
                return true;
            }
            catch
            {
                return false;
            }
        }

        #endregion

        public List<Friend> GetList { get { return _friendList; } }

        #endregion

        #region Setters/Getters

        public List<Friend> GetFriendList
        {
            get { return _friendList; }
        }

        #endregion

        #region Read/Write Xml

        public void ReadXml(XmlReader reader)
        {
            reader.ReadStartElement("FriendList");

            while (reader.Name.Equals("Friend") && reader.NodeType == XmlNodeType.Element)
            {
                Friend s = new Friend(
                    reader.GetAttribute("title"),
                    reader.GetAttribute("username"),
                    reader.GetAttribute("email"));

                _friendList.Add(s);
            }
            reader.ReadEndElement();
        }


        public void WriteXml(XmlWriter writer)
        {
            writer.WriteStartElement("SharedUserList");

            foreach (Friend f in _friendList)
            {
                writer.WriteStartElement("SharedUser");

                writer.WriteAttributeString("title", f.Title);
                writer.WriteAttributeString("username", f.Username);
                writer.WriteAttributeString("email", f.Email);

                writer.WriteEndElement();
            }

            writer.WriteEndElement();

        }

        #endregion

    }
}
