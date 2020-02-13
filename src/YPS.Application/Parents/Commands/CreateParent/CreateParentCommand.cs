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
        public long SchoolId { get; set; }

        public sealed class CreateParentCommandHandler : IRequestHandler<CreateParentCommand, long>
        {
            private readonly IYPSDbContext _context;
            private readonly IUserService _userService;

            public CreateParentCommandHandler(IYPSDbContext context, IUserService userService)
            {
                _context = context;
                _userService = userService;
            }
            public async Task<long> Handle(CreateParentCommand request, CancellationToken cancellationToken)
            {
                User createdUser = await _userService.CreateUser(request.User);

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
