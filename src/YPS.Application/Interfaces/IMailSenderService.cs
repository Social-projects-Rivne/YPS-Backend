using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace YPS.Application.Interfaces
{
    public interface IMailSenderService
    {
        public Task SendMessageAsync(string reciever, string subject, string text);
        public Task SendRegistrationMessage(string reciever, string password);
    }
}
