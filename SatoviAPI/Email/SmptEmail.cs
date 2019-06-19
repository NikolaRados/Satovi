﻿using SatoviApplication.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace SatoviAPI.Email
{
    public class SmptEmail : IEmail
    {
        private string host;
        private int port;
        private string from;
        private string password;

        public SmptEmail(string host, int port, string from, string password)
        {
            this.host = host;
            this.port = port;
            this.from = from;
            this.password = password;
        }

        public string ToEmail { get; set; }
        public string Body { get; set; }
        public string Subject { get; set; }

        public void Send()
        {
            var smtp = new SmtpClient
            {
                Host = host,
                Port = port,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(from, password)
            };

            using (var message = new MailMessage(from, ToEmail)
            {
                Subject = Subject,
                Body = Body
            })
            {
                smtp.Send(message);
            }
        }
    }
}
