using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using YPS.Application.Interfaces;

namespace YPS.Infrastructure.Services
{
    public class MailSenderService : IMailSenderService
    {
        const string MailSenderKey = "MailSender";
        const string SMTPHostKey = "SMTPHost";
        const string SMTPPortKey = "SMTPPort";
        const string MailPasswordKey = "MailPassword";
        const string MailTemplateFolderKey = "MailTemplateFolder";
        
        private readonly IConfiguration _config;

        private SmtpClient client { get; set; }
        
        public MailSenderService(IConfiguration config)
        {
            _config = config;
            client = new SmtpClient(_config.GetValue<string>(SMTPHostKey), _config.GetValue<int>(SMTPPortKey));
            client.Credentials = new NetworkCredential(_config.GetValue<string>(MailSenderKey), _config.GetValue<string>(MailPasswordKey));
            client.EnableSsl = true;
        }

        public async Task SendMessageAsync(string reciever,string subject,string text)
        {
            MailAddress from = new MailAddress(_config.GetValue<string>(MailSenderKey));
            MailAddress to = new MailAddress(reciever);
            MailMessage msg = new MailMessage(from,to);
            msg.Subject = subject;
            msg.IsBodyHtml = true;
            msg.Body = text;
            await client.SendMailAsync(msg);
        }

        public async Task SendRegistrationMessage(string reciever,string password)
        {
            try
            {
                MailAddress from = new MailAddress(_config.GetValue<string>(MailSenderKey));
                MailAddress to = new MailAddress(reciever);
                MailMessage msg = new MailMessage(from, to);
                msg.Subject = "You've been aded to YPS service";
                msg.IsBodyHtml = true;

                var location = Assembly.GetEntryAssembly().Location;
                var root = Path.GetDirectoryName(location);
                var registration = File.ReadAllText(Path.Combine(root, _config.GetValue<string>(MailTemplateFolderKey), "Registration.html"));

                registration = registration.Replace("{{reciever}}", reciever)
                    .Replace("{{password}}", password);

                msg.Body = registration;

                await client.SendMailAsync(msg);
            }
            catch(Exception)
            {
                throw;
            }
        }
    }
}
