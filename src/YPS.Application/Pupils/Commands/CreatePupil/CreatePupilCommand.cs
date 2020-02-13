using AutoMapper;
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
    public sealed class CreatePupilCommand : IRequest<long>
    {
        public UserPartial User { get; set; }
        public long ClassId { get; set; }

        public class CreatePupilCommandHandler : IRequestHandler<CreatePupilCommand, long>
        {
            private readonly IYPSDbContext _context;
            private readonly IUserService _userService;

            public CreatePupilCommandHandler(IYPSDbContext context, IUserService userService)
            {
                _context = context;
                _userService = userService;
            }

            public async Task<long> Handle(CreatePupilCommand request, CancellationToken cancellationToken)
            {
                User createdUser = await _userService.CreateUser(request.User);

                if (createdUser != null)
                {
                    Pupil pupil = new Pupil
                    {
                        UserId = createdUser.Id,
                        ClassId = 2
                    };

                    _context.Pupils.Add(pupil);
                    await _context.SaveChangesAsync(cancellationToken);
                }

                return createdUser.Id;
            }
        }
    }
}
