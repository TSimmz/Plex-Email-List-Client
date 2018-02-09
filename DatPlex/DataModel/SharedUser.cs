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

        #region Constructor

        public SharedUser(string u, string e): base(u, e)
        {
            Username = u;
            Email = e;
        }

        #endregion

    }

    public partial class SharedUsers : ObservableCollection<SharedUsers>
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
                        reader.GetAttribute("Username"),
                        reader.GetAttribute("Email"));

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

                writer.WriteAttributeString("Username", s.Username);
                writer.WriteAttributeString("Email", s.Email);

                writer.WriteEndElement();
            }

            writer.WriteEndElement();

        }

        #endregion

    }
}
