using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace YPS.Application.Parents.Commands.CreateParent
{
    public sealed class CreateParentCommand : IRequest<long>
    {
        public sealed class CreateParentCommandHandler : IRequestHandler<CreateParentCommand, long>
        {
            public Task<long> Handle(CreateParentCommand request, CancellationToken cancellationToken)
            {
            }
        }
    }
}
