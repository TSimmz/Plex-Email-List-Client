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

        private string _title;
        private string _username;
        private string _email;

        #endregion

        #region Constructors

        public User(string title, string username, string email)
        {
            _title = title;
            _username = username;
            _email = email;
        }

        #endregion

        #region Setters/Getters

        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
            }
        }

        public string Username
        {
            get { return _username; }
            set
            {
                _username = value;
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

        #endregion
    }
}
