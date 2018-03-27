using System;
using System.Net;
//using System.Net.Mail;
using System.Collections.Generic;
using System.Windows;
using Spire.Email;
using Spire.Email.Smtp;
using Spire.Email.IMap;
using System.Threading;

namespace DatPlex.DataModel
{
    class Email
    {
        #region Data Fields

        private string _from;
        private List<string> _to;
        private string _subject;
        private string _body = @"<html>
                                  <body>
                                  <p>Dear Tyler,</p>
                                  <p>This is only a test</p>
                                  <p>Sincerely,<br>Tyler</br></p>
                                  </body>
                                  </html>
                                 ";

        MailMessage message;
        SmtpClient gmail;

        #endregion

        #region Constructor

        public Email()
        {
            gmail = new SmtpClient("smtp.gmail.com");
        }

        #endregion

        #region Send Logic

        public bool Send()
        {
            try
            {
                new Thread(() =>
                {
                    //message.From = new MailAddress(From);

                    MailAddress from = new MailAddress(From);
                    //List<MailAddress> to_List = new List<MailAddress>();
                    //foreach(string t in To)
                    //{
                    //    to_List.Add(new MailAddress(t));
                    //}
                    //MailAddress[] to = to_List.ToArray();
                    MailAddress to = new MailAddress(From);

                    message = new MailMessage(from, to);

                    message.Subject = "Test from Plex";
                    message.BodyHtml = Body;

                    gmail.Port = 587;
                    gmail.Username = From;
                    gmail.Password = "H4ckm3br0@";
                    gmail.ConnectionProtocols = ConnectionProtocols.Ssl;

                    gmail.SendOne(message);

                    MessageBox.Show("Email sent successfully", "Email Test", MessageBoxButton.OK, MessageBoxImage.Information);

                    //gmail.Credentials = new NetworkCredential(From, ConfirmPassword());

                    //gmail.SendAsync(message, message.Subject);

                }).Start();

               
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