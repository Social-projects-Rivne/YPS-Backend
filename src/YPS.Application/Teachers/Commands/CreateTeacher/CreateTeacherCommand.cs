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
    public sealed class CreateTeacherCommand : IRequest<CreatedResponse>
    {
        public UserPartial User { get; set; }
        public string Degree { get; set; }
        public long SchoolId { get; set; }
        public DateTime DateOfBirthday { get; set; }

        public sealed class CreateTeacherCommandHandler : IRequestHandler<CreateTeacherCommand, CreatedResponse>
        {
            private readonly IYPSDbContext _context;
            private readonly IUserService _userService;
            private readonly IRandomGeneratorService _randomGenerator;
            private readonly IMailSenderService _mailSender;

            public CreateTeacherCommandHandler(IYPSDbContext context, IUserService userService, IRandomGeneratorService randomGenerator, IMailSenderService mailSender)
            {
                _context = context;
                _userService = userService;
                _randomGenerator = randomGenerator;
                _mailSender = mailSender;
            }

            public async Task<CreatedResponse> Handle(CreateTeacherCommand request, CancellationToken cancellationToken)
            {
                CreatedResponse res = new CreatedResponse();

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
                        await _mailSender.SendRegistrationMessage(createdUser.Email, password);
                    }
                }
                return res;
            }
        }
    }
}
