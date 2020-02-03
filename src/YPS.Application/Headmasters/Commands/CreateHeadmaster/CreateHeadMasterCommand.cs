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
    public sealed class CreateHeadMasterCommand : IRequest<long>
    {
        public UserPartial User { get; set; }

        public class CreateHeadMasterCommandHandler : IRequestHandler<CreateHeadMasterCommand, long>
        {
            private readonly IUserService _userService;

            public CreateHeadMasterCommandHandler(IUserService userService)
            {
                _userService = userService;
            }

            public async Task<long> Handle(CreateHeadMasterCommand request, CancellationToken cancellationToken)
            {
                User createdUser = await _userService.CreateUser(request.User);

                return createdUser.Id;
            }
        }
    }
}

