using System;
using System.Collections.Generic;
using System.Text;

namespace YPS.Application.Auth.Command.Login
{
    public sealed class LoginViewModel
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public string Role { get; set; }
    }
}
