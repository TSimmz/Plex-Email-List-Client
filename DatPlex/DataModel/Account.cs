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
        #region Data Fields

        private bool _signedin;

        #endregion

        #region Constructors

        public Account() : base()
        {

        }

        public Account(string u, string e, string p) : base(u, e, p)   
        {
            Username = u;
            Email = e;
            Password = p;
        }

        #endregion

        #region Properties

        public bool SignedIn
        {
            get { return _signedin; }
            set
            {
                _signedin = value;
            }
        }



        #endregion

        #region Read/Write Xml

        public void ReadXml(XmlReader reader)
        {
            reader.ReadStartElement("Account");

            this.Username = reader.ReadElementString("Username");
            this.Email = reader.ReadElementString("Email");
            this.Password = reader.ReadElementString("Password");

            reader.ReadEndElement();
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteStartElement("Account");

            writer.WriteElementString("Username", Username);
            writer.WriteElementString("Email", Email);
            writer.WriteElementString("Password", Password);

            writer.WriteEndElement();
        }

        #endregion

    }
}
