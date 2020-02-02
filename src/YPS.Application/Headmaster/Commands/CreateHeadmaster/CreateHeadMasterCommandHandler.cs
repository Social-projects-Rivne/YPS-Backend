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
    public sealed class CreateHeadMasterCommand : IRequest<CreateHeadMasterVM>
    {
        public UserPartial User { get; set; }

        public sealed class CreateHeadMasterCommandHandler : IRequestHandler<CreateHeadMasterCommand, CreateHeadMasterVM>
        {
            private readonly IUserService _userService;

            public CreateHeadMasterCommandHandler(IUserService userService)
            {
                _userService = userService;
            }

            public async Task<CreateHeadMasterVM> Handle(CreateHeadMasterCommand request, CancellationToken cancellationToken)
            {
                User user = await _userService.CreateUser(request.User);

                return new CreateHeadMasterVM
                {
                    Id = user.Id,
                    Email = user.Email,
                    FirstName = user.FirstName,
                    Surname = user.Surname,
                    MiddleName = user.MiddleName,
                    PhoneNumber = user.PhoneNumber,
                    Password = user.Password
                };
            }
        }
    }
}

