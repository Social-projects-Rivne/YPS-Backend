using System;
using System.Collections.Generic;
using System.Text;

namespace YPS.Application.Auth.Command.Login
{
    public sealed class LoginViewModel
    {
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
    }
}
