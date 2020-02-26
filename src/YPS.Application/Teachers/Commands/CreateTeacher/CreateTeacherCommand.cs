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

namespace YPS.Application.Teachers.Commands.CreateTeacher
{
    public sealed class CreateTeacherCommand : IRequest<CreateUserResponse>
    {
        public UserPartial User { get; set; }
        public string Degree { get; set; }
        public long SchoolId { get; set; }

        public sealed class CreateTeacherCommandHandler : IRequestHandler<CreateTeacherCommand, CreateUserResponse>
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

            public async Task<CreateUserResponse> Handle(CreateTeacherCommand request, CancellationToken cancellationToken)
            {
                CreateUserResponse res = new CreateUserResponse();

                IDictionary<string, string> failures = await _userService.CheckFailuresAsync(request.User.Email, request.User.PhoneNumber);

                res.Failures = failures;

                if (res.Failures == null || !res.Failures.Any())
                { 
                    string password = _randomGenerator.RandomPassword();
                    User createdUser = await _userService.CreateUser(request.User, password, 2, request.SchoolId);

                    if (createdUser != null)
                    {
                        Teacher teacher = new Teacher
                        {
                            Id = createdUser.Id,
                            Degree = request.Degree,
                        };

                        res.CreatedId = createdUser.Id;
                        _context.Teachers.Add(teacher);
                        await _context.SaveChangesAsync(cancellationToken);
                    }
                }

                return res;
            }
        }
    }
}
