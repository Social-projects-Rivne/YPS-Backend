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

namespace YPS.Application.Pupils.Commands.CreatePupil
{
    public sealed class CreatePupilCommand : IRequest<CreateUserResponse>
    {
        public UserPartial User { get; set; }
        public long ClassId { get; set; }
        public long SchoolId { get; set; }

        public class CreatePupilCommandHandler : IRequestHandler<CreatePupilCommand, CreateUserResponse>
        {
            private readonly IYPSDbContext _context;
            private readonly IUserService _userService;
            private readonly IRandomGeneratorService _randomGenerator;
            private readonly IMailSenderService _mailSender;

            public CreatePupilCommandHandler(IYPSDbContext context, IUserService userService, IRandomGeneratorService randomGenerator,IMailSenderService mailSender)
            {
                _context = context;
                _userService = userService;
                _randomGenerator = randomGenerator;
                _mailSender = mailSender;
            }

            public async Task<CreateUserResponse> Handle(CreatePupilCommand request, CancellationToken cancellationToken)
            {
                CreateUserResponse res = new CreateUserResponse();

                IDictionary<string, string> failures = await _userService.CheckFailuresAsync(request.User.Email, request.User.PhoneNumber);

                res.Failures = failures;

                if (res.Failures == null || !res.Failures.Any())
                { 
                    string password = _randomGenerator.RandomPassword();
                    User createdUser = await _userService.CreateUser(request.User, password, 1, request.SchoolId);

                    if (createdUser != null)
                    {
                        Pupil pupil = new Pupil
                        {
                            Id = createdUser.Id,
                            ClassId = request.ClassId
                        };

                        res.CreatedId = createdUser.Id;
                        _context.Pupils.Add(pupil);
                        await _context.SaveChangesAsync(cancellationToken);
                        await _mailSender.SendRegistrationMessage(createdUser.Email,password);
                    }
                }

                return res;
            }
        }
    }
}
