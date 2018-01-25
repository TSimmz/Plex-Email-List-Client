using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DatPlex.DataModel
{
    public class Account : User
    {
        private bool _signedin;
        private List<Media> _media;

        public Account(string u, string e, string p) : base(u, e, p)   
        {
            Username = u;
            Email = e;
            Password = p;
        }

        public bool SignedIn
        {
            get { return _signedin; }
            set
            {
                _signedin = value;
            }
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteStartElement("Account");

            writer.WriteElementString("Username", Username);
            writer.WriteElementString("Email", Email);
            writer.WriteElementString("Password", Password);

            writer.WriteEndElement();
        }

    }
}
