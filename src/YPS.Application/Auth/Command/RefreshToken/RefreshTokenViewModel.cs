using System;
using System.Collections.Generic;
using System.Text;

namespace YPS.Application.Auth.Command.RefreshToken
{
    public sealed class RefreshTokenViewModel
    {
        public string Token { get; }
        public string RefreshToken { get; }
        public RefreshTokenViewModel(string token, string refreshToken)
        {
            Token = token;
            RefreshToken = refreshToken;
        }
    }
}
