using System;
using System.Net;
using System.Net.Mail;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DatPlex.DataModel
{
    class Email
    {
        #region Data Fields

        private string _from;
        private List<string> _to;
        private string _subject;
        private string _body;

        MailMessage message;
        SmtpClient gmail;

        #endregion

        #region Constructor

        public Email()
        {
            message = new MailMessage();
            gmail = new SmtpClient("smtp.gmail.com");
        }

        #endregion

        #region Send Logic

        public bool Send()
        {
            try
            {
                message.From = new MailAddress(From);
                foreach (string t in To)
                {
                    message.To.Add(t);
                }
                message.Subject = Subject;
                message.Body = Body;

                gmail.Port = 25;
                gmail.EnableSsl = true;
                gmail.Credentials = new NetworkCredential(From, ConfirmPassword());

                gmail.SendAsync(message, message.Subject);

                return true;
            }
            catch
            {
                MessageBox.Show("Update email failed to send. Try again.", "EMAIL FAILED", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }

        public bool CanSend()
        {
            if (From != null && To != null && Subject != null && Body != null)
                return true;
            return false;
        }

        public string ConfirmPassword()
        {
            string pass = "";
            //TODO: Add password confirmation window
            return pass;
        }

        #endregion

        #region Setters/Getters

        public string From
        {
            get { return _from; }
            set { _from = value; }
        }

        public List<string> To
        {
            get { return _to; }
            set { _to = value; }
        }

        public string Subject
        {
            get { return _subject; }
            set { _subject = value; }
        }

        public string Body
        {
            get { return _body; }
            set { _body = value; }
        }

        #endregion

    }
}