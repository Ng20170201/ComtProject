using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ServicesInterfaces
{
    public interface IEmailServiceCSV
    {
        public Task<bool> SendEmail(string from, string to, string subject, string body,Attachment att);
    }
}
