using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
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

        public async Task SendMessageAsync(string reciever,string subject,string text)
        {
            MailAddress from = new MailAddress("yps.schools@gmail.com");
            MailAddress to = new MailAddress(reciever);
            MailMessage msg = new MailMessage(from,to);
            msg.Subject = subject;
            msg.IsBodyHtml = true;
            msg.Body = text;
            await client.SendMailAsync(msg);
        }

        public async Task SendRegistrationMessage(string reciever,string password)
        {
            MailAddress from = new MailAddress("yps.schools@gmail.com");
            MailAddress to = new MailAddress(reciever);
            MailMessage msg = new MailMessage(from, to);
            msg.Subject = "You've been aded to YPS service";
            msg.IsBodyHtml = true;
            msg.Body = "<h1>Congradulations, You've been registered in the YPS System. </h1>" +
                "<p>Use this data for login</p>" +
                "<p>Email: " + reciever + "<br>" +
                "Password: " + password + "</p>";
            await client.SendMailAsync(msg);
        }
    }
}
