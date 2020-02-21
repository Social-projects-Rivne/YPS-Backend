using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace YPS.Application.Auth.Command.RefreshToken
{
    public sealed class RefreshTokenCommand : IRequest<RefreshTokenViewModel>
    {
        public string ApiKey { get; }
        public string Token { get; }
        public string RefreshToken { get; }

        public RefreshTokenCommand(string apiKey, string token, string refreshToken)
        {
            ApiKey = apiKey;
            Token = token;
            RefreshToken = refreshToken;
        }
    }

}
