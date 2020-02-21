using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;
using YPS.Application.Interfaces;

namespace YPS.Infrastructure.Services
{
    public class MailSenderService : IMailSenderService
    {
        private SmtpClient client { get; set; }
        public MailSenderService()
        {
            client = new SmtpClient("smtp.gmail.com", 587);
            client.Credentials = new NetworkCredential("yps.schools@gmail.com", "BeterAndEasier");
            client.EnableSsl = true;
        }

        public async void SendMessageAsync(string receiver,string subject,string text)
        {
            MailAddress from = new MailAddress("yps.schools@gmail.com");
            MailAddress to = new MailAddress(receiver);
            MailMessage msg = new MailMessage(from,to);
            msg.Subject = subject;
            msg.IsBodyHtml = true;
            msg.Body = text;
            await client.SendMailAsync(msg);
        }
    }
}
