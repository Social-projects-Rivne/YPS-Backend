using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MediatR;
using YPS.Application.Auth.Helpers;
using YPS.Application.Exceptions;
using YPS.Application.Interfaces;
using YPS.Domain.Entities;
using YPS.Application.Models;

namespace YPS.Application.Auth.Command.CreateHeadMaster
{
    public sealed class CreateHeadMasterCommand : IRequest<CreateUserResponse>
    {
        public UserPartial User { get; set; }
        public string Password { get; set; }

        public class CreateHeadMasterCommandHandler : IRequestHandler<CreateHeadMasterCommand, CreateUserResponse>
        {
            
            private readonly IUserService _userService;
            private readonly IYPSDbContext _context;

            public CreateHeadMasterCommandHandler(IUserService userService, IYPSDbContext context)
            {
                _context = context;
                _userService = userService;
            }

            public async Task<CreateUserResponse> Handle(CreateHeadMasterCommand request, CancellationToken cancellationToken)
            {
                CreateUserResponse res = new CreateUserResponse();

                IDictionary<string, string> failures = await _userService.CheckFailuresAsync(request.User.Email, request.User.PhoneNumber);

                res.Failures = failures;

                if (res.Failures == null || !res.Failures.Any())
                {
                    User createdUser = await _userService.CreateUser(request.User, request.Password, 6, 1);

                    if (createdUser != null)
                    {
                        Teacher headmaster = new Teacher
                        {
                            Id = createdUser.Id
                        };

                        res.CreatedId = createdUser.Id;
                        _context.Teachers.Add(headmaster);
                        await _context.SaveChangesAsync(cancellationToken);
                    }
                }

                return res;
            }
        }
    }
}

