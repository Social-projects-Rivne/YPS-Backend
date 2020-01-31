﻿using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using YPS.Application.Interfaces;
using YPS.Application.Models;
using YPS.Domain.Entities;

namespace YPS.Application.Pupils.Commands.AddPupil
{
    public sealed class CreatePupilCommand : IRequest<long>
    {
        public UserPartial User { get; set; }
        public string RoleId { get; set; }
        public string ClassId { get; set; }

        public class CreatePupilCommandHandler : IRequestHandler<CreatePupilCommand, long>
        {
            private readonly IYPSDbContext _context;
            private readonly IMapper _mapper;
            private readonly IUserService _userService;

            public CreatePupilCommandHandler(IYPSDbContext context, IMapper mapper, IUserService userService)
            {
                _context = context;
                _mapper = mapper;
                _userService = userService;
            }

            public async Task<long> Handle(CreatePupilCommand request, CancellationToken cancellationToken)
            {
                User createUserResult = await _userService.CreateUser(request.User);

                if (createUserResult != null)
                {
                    Pupil pupil = new Pupil
                    {
                        UserId = createUserResult.Id,
                        SchoolId = 1,
                        ClassId = 2
                    };

                    _context.Pupils.Add(pupil);
                    await _context.SaveChangesAsync(cancellationToken);
                }

                return createUserResult.Id;
            }
        }
    }
}
