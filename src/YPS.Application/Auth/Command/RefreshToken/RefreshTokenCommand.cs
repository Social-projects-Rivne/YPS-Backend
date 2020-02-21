using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace YPS.Application.Auth.Command.RefreshToken
{
    public sealed class RefreshTokenCommand : IRequest<RefreshTokenViewModel>
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }

    }
}
