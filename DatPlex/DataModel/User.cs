using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatPlex.DataModel
{
    public class User
    {
        #region Data Fields

        private string _uname;
        private string _email;
        private string _password;

        #endregion

        #region Constructors

        public User()
        {

        }

        public User(string u, string e, string p)
        {
            Username = u;
            Email = e;
            Password = p;
        }

        public User(string u, string e)
        {
            Username = u;
            Email = e;
            Password = "";
        }

        #endregion

        #region Setters/Getters

        public string Username
        {
            get { return _uname; }
            set
            {
                _uname = value;
            }
        }

        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
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
    }
}
