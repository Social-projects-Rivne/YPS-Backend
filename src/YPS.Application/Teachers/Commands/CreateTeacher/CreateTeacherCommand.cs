using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace YPS.Application.Teachers.Commands.CreateTeacher
{
    public sealed class CreateTeacherCommand : IRequest<long>
    {
        public sealed class CreateTeacherCommandHandler : IRequestHandler<CreateTeacherCommand, long>
        {
            public async Task<long> Handle(CreateTeacherCommand request, CancellationToken cancellationToken)
            {
            }
        }
    }
}
