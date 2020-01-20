using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using MediatR;

namespace YPS.Application.Auth.Command.Login
{
    public sealed  class LoginCommand : IRequest<LoginViewModel>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        [IgnoreDataMember]
        public string ApiKey { get; set; }
    }
}
