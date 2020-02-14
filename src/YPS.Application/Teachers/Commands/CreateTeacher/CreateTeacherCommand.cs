using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using YPS.Application.Interfaces;
using YPS.Application.Models;
using YPS.Domain.Entities;

namespace YPS.Application.Teachers.Commands.CreateTeacher
{
    public sealed class CreateTeacherCommand : IRequest<long>
    {
        public UserPartial User { get; set; }
        public string Degree { get; set; }
        public long RoleId { get; set; }
        public long SchoolId { get; set; }

        public sealed class CreateTeacherCommandHandler : IRequestHandler<CreateTeacherCommand, long>
        {
            private readonly IYPSDbContext _context;
            private readonly IUserService _userService;
            private readonly IRandomGeneratorService _randomGenerator;

            public CreateTeacherCommandHandler(IYPSDbContext context, IUserService userService, IRandomGeneratorService randomGenerator)
            {
                _context = context;
                _userService = userService;
                _randomGenerator = randomGenerator;
            }

            public async Task<long> Handle(CreateTeacherCommand request, CancellationToken cancellationToken)
            {
                string password = _randomGenerator.RandomPassword();
                User createdUser = await _userService.CreateUser(request.User, password, 2, 1);

                if (createdUser != null)
                {
                    Teacher teacher = new Teacher
                    {
                        UserId = createdUser.Id,
                        Degree = request.Degree,
                    };

                    _context.Teachers.Add(teacher);
                    await _context.SaveChangesAsync(cancellationToken);
                }

                return createdUser.Id;
            }
        }
    }
}
