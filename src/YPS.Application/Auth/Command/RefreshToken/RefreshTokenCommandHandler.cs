using MediatR;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using YPS.Application.Auth.Helpers;
using YPS.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using Microsoft.IdentityModel.Tokens;
using YPS.Domain.Entities;
using Microsoft.Extensions.Configuration;

namespace YPS.Application.Auth.Command.RefreshToken
{
    public sealed class RefreshTokenCommandHandler : IRequestHandler<RefreshTokenCommand, RefreshTokenViewModel>
    {
        private readonly IYPSDbContext _dbContext;
        private readonly string _apiKey;

        public RefreshTokenCommandHandler(IYPSDbContext dbContext,IConfiguration config)
        {
            _dbContext = dbContext;
            _apiKey = config.GetValue<string>("ApiKey");
        }
        public async Task<RefreshTokenViewModel> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
        {
            var principal = AuthHelpers.GetPrincipalFromExpiredToken(_apiKey, request.Token);
            var userIdStr = principal.FindFirst(ClaimTypes.NameIdentifier).Value;
            var userId = long.Parse(userIdStr, new NumberFormatInfo());
            var userRefreshToken = await _dbContext.UserRefreshTokens
                .SingleOrDefaultAsync(x => x.UserId == userId && x.RefreshToken == request.RefreshToken, cancellationToken)
                .ConfigureAwait(false);
            if (userRefreshToken == null)
            {
                throw new SecurityTokenException("Invalid refresh token");
            }
            _dbContext.UserRefreshTokens.Remove(userRefreshToken);
            if (userRefreshToken.ExpiryDate < DateTime.UtcNow)
            {

                await _dbContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
                throw new SecurityTokenException("Token is expired");
            }
            var newJwtToken = AuthHelpers.GenerateToken(_apiKey, principal.Claims);
            var newRefreshToken = AuthHelpers.GenerateRefreshToken();
            await _dbContext.UserRefreshTokens.AddAsync(new UserRefreshToken
            {
                UserId = userId,
                RefreshToken = newRefreshToken,
                ExpiryDate = DateTime.UtcNow.AddMonths(1),
            }, cancellationToken).ConfigureAwait(false);
            await _dbContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return new RefreshTokenViewModel(newJwtToken, newRefreshToken);
        }
    }
}
