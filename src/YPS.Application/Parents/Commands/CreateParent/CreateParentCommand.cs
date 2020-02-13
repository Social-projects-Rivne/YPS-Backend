using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using YPS.Application.Interfaces;
using YPS.Application.Models;
using YPS.Domain.Entities;

namespace YPS.Application.Parents.Commands.CreateParent
{
    public sealed class CreateParentCommand : IRequest<long>
    {
        public UserPartial User { get; set; }
        public string WorkInfo { get; set; }

        public sealed class CreateParentCommandHandler : IRequestHandler<CreateParentCommand, long>
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
            public async Task<long> Handle(CreateParentCommand request, CancellationToken cancellationToken)
            {
                string password = _randomGenerator.RandomPassword();
                User createdUser = await _userService.CreateUser(request.User, password, 3, 1);

                if (createdUser != null)
                {
                    Parent parent = new Parent
                    {
                        UserId = createdUser.Id,
                    };

                    _context.Parents.Add(parent);
                    await _context.SaveChangesAsync(cancellationToken);
                }

                return createdUser.Id;
            }
        }
    }
}
