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

namespace YPS.Application.Parents.Commands.CreateParent
{
    public sealed class CreateParentCommand : IRequest<CreatedResponse>
    {
        public UserPartial User { get; set; }
        public string WorkInfo { get; set; }
        public long PupilId { get; set; }
        public long SchoolId { get; set; }

        public sealed class CreateParentCommandHandler : IRequestHandler<CreateParentCommand, CreatedResponse>
        {
            private readonly IYPSDbContext _context;
            private readonly IUserService _userService;
            private readonly IRandomGeneratorService _randomGenerator;

            public CreateParentCommandHandler(IYPSDbContext context, IUserService userService, IRandomGeneratorService randomGenerator)
            {
                _context = context;
                _userService = userService;
                _randomGenerator = randomGenerator;
            }
            public async Task<CreatedResponse> Handle(CreateParentCommand request, CancellationToken cancellationToken)
            {
                CreatedResponse res = new CreatedResponse();

                IDictionary<string, string> failures = await _userService.CheckFailuresAsync(request.User.Email, request.User.PhoneNumber);

                res.Failures = failures;

                if (res.Failures == null || !res.Failures.Any())
                {
                    string password = _randomGenerator.RandomPassword();
                    User createdUser = await _userService.CreateUser(request.User, password, 3, request.SchoolId);

                    if (createdUser != null)
                    {
                        Parent parent = new Parent
                        {
                            Id = createdUser.Id,
                            WorkInfo = request.WorkInfo
                        };

                        res.CreatedId = createdUser.Id;
                        _context.Parents.Add(parent);
                        await _context.SaveChangesAsync(cancellationToken);

                        Parent createdParent = await _context.Parents.FindAsync(parent.Id);

                        if (createdParent != null)
                        {
                            ParentToPupil parentToPupil = new ParentToPupil
                            {
                                ParentId = createdParent.Id,
                                PupilId = request.PupilId
                            };

                            _context.ParentToPupils.Add(parentToPupil);
                            await _context.SaveChangesAsync(cancellationToken);
                        }
                    }
                }

                return res;
            }
        }
    }
}
