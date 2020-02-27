using System;
using System.Collections.Generic;
using System.Text;

namespace YPS.Application.Interfaces
{
    public interface IMailSenderService
    {
        public void SendMessageAsync(string reciever, string subject, string text);

        public void SendRegistrationMessage(string reciever, string password);
    }
}
