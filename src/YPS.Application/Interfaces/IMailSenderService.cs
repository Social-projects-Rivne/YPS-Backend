using System;
using System.Collections.Generic;
using System.Text;

namespace YPS.Application.Interfaces
{
    public interface IMailSenderService
    {
        public void SendMessageAsync(string receiver, string subject, string text);
    }
}
