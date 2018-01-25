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
        public SharedUser(string u, string e): base(u, e)
        {
            Username = u;
            Email = e;
        }
    }

    public partial class SharedUsers : ObservableCollection<SharedUsers>
    {
        ObservableCollection<SharedUser> _sharedUserList;

        public SharedUsers()
        {
            _sharedUserList = new ObservableCollection<SharedUser>();  
        }

        public void ReadXml(XmlReader reader)
        {
            reader.ReadStartElement("SharedUserList");

            while (reader.Read())
            {
                if (reader.Name.Equals("SharedUser") && reader.NodeType == XmlNodeType.Element)
                {
                    SharedUser s = new SharedUser(
                        reader.ReadElementString("Username"),
                        reader.ReadElementString("Email"));

                    _sharedUserList.Add(s);
                }
            }

            reader.ReadEndElement();
        }


        public void WriteXml(XmlWriter writer)
        {
            writer.WriteStartElement("SharedUserList");

            foreach(SharedUser s in _sharedUserList)
            {
                writer.WriteStartElement("SharedUser");

                writer.WriteElementString("Username", s.Username);
                writer.WriteElementString("Email", s.Email);

                writer.WriteEndElement();
            }

            writer.WriteEndElement();

        }

    }
}
