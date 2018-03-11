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

        private bool _rememberMe;
        private string _password;

        #endregion

        #region Constructors

        public Account() : base(null, null, null)
        {

        }

        public Account(string title, string username, string email) : base(title, username, email)   
        {
            Title = title;
            Username = username;
            Email = email;
            Password = "";
        }

        #endregion

        #region Setters/Getters

        public bool RememberMe
        {
            get { return _rememberMe; }
            set
            {
                _rememberMe = value;
            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
            }
        }


        #endregion

        #region Read/Write Xml

        public void ReadXml(XmlReader reader)
        {
            reader.ReadStartElement("Account");

            this.Title = reader.GetAttribute("title");
            this.Username = reader.GetAttribute("username");
            this.Email = reader.GetAttribute("email");
            this.Password = reader.GetAttribute("password");

            reader.ReadEndElement();
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteStartElement("Account");

            writer.WriteAttributeString("title", Title);
            writer.WriteAttributeString("username", Username);
            writer.WriteAttributeString("email", Email);

            //if (RememberMe)
            //    writer.WriteAttributeString("password", Password);
            //else
            //    writer.WriteAttributeString("password", "");

            writer.WriteEndElement();
        }

        #endregion

    }
}
