﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using YPS.Application.Auth.Helpers;
using YPS.Application.Exceptions;
using YPS.Application.Interfaces;


namespace YPS.Application.Auth.Command.Login
{
    public sealed class LoginCommandHandler : IRequestHandler<LoginCommand, string>
    {
        private readonly IYPSDbContext _dbContext;
        private readonly IMapper _mapper;

        public LoginCommandHandler(IYPSDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<string> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _dbContext.Users
                .SingleOrDefaultAsync(x => 
                        x.Email.ToUpper() == request.Email.ToUpper() &&
                        x.Password == request.Password, cancellationToken: cancellationToken)
                .ConfigureAwait(false);

            var role = await _dbContext.Roles.SingleOrDefaultAsync(x => x.Id == user.RoleId);

            if (user == null)
            {
                throw new ValidationException();
            }
            var claims = new List<Claim> {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Role, role.Name),
                new Claim(ClaimTypes.Name, user.FirstName),
                new Claim(ClaimTypes.GivenName, user.SchoolId.ToString())
            };

            var token = AuthHelpers.GenerateToken(request.ApiKey, claims);
            return token;
        }
    }
}
