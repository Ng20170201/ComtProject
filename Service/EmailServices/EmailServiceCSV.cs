using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using ServicesInterfaces;

namespace Service.EmailServices
{
    public class EmailServiceCSV : IEmailServiceCSV
    {
        private readonly string _smtpServer;
        private readonly int _smtpPort;
        private readonly string _smtpUsername;
        private readonly string _smtpPassword;

        public EmailServiceCSV()
        {
            _smtpServer = "smtp.gmail.com";
            _smtpPort = 465;
            _smtpUsername = "nikolag857@gmail.com";
            _smtpPassword = "Ng012345!";
        }

        public async Task<bool> SendEmail(string from, string to, string subject, string body, Attachment att)
        {
            var message = new MailMessage(from, to, subject, body);
            message.Attachments.Add(att);
            using (var client = new SmtpClient(_smtpServer, _smtpPort))
            {
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(_smtpUsername, _smtpPassword);
                client.EnableSsl = true;

                await client.SendMailAsync(message);
            }
            return true;                    
        }
    }
}
