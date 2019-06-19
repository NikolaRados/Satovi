using System;
using System.Collections.Generic;
using System.Text;

namespace SatoviApplication.Interfaces
{
    public interface IEmail
    {
        string ToEmail { get; set; }
        string Body { get; set; }
        string Subject { get; set; }

        void Send();
    }
}
