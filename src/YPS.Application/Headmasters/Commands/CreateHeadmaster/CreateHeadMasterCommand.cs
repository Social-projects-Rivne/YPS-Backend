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
    public sealed class CreateHeadMasterCommand : IRequest<CreatedResponse>
    {
        public UserPartial User { get; set; }
        public string Password { get; set; }
        public string Link { get; set; }

        public class CreateHeadMasterCommandHandler : IRequestHandler<CreateHeadMasterCommand, CreatedResponse>
        {

            private readonly IUserService _userService;
            private readonly IYPSDbContext _context;

            public CreateHeadMasterCommandHandler(IUserService userService, IYPSDbContext context)
            {
                _context = context;
                _userService = userService;
            }

            public async Task<CreatedResponse> Handle(CreateHeadMasterCommand request, CancellationToken cancellationToken)
            {
                CreatedResponse res = new CreatedResponse();

                IDictionary<string, string> failures = await _userService.CheckFailuresAsync(request.User.Email, request.User.PhoneNumber);

                res.Failures = failures;

                if (res.Failures == null || !res.Failures.Any())
                {
                    var schoolId = _context.Schools.FirstOrDefault(x => x.RegistrationLink == request.Link).Id;
                    User createdUser = await _userService.CreateUser(request.User, request.Password, 6, schoolId);

                    if (createdUser != null)
                    {
                        Teacher headmaster = new Teacher
                        {
                            Id = createdUser.Id
                        };

                        res.CreatedId = createdUser.Id;
                        _context.Teachers.Add(headmaster);
                        await _context.SaveChangesAsync(cancellationToken);
                        _context.Schools.FirstOrDefault(x => x.Id == schoolId).RegistrationLink = null;
                        await _context.SaveChangesAsync();
                    }
                }

                return res;
            }
        }
    }
}

