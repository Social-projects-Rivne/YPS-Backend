using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using YPS.Application.Interfaces;
using YPS.Domain.Entities;

namespace YPS.Application.Classes.Commands.CreateClass
{
    public sealed class CreateClassCommandHandler : IRequestHandler<CreateClassRequestCommand, long>
    {
        private readonly IYPSDbContext _context;
        private readonly IMapper _mapper;

        public CreateClassCommandHandler(IYPSDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<long> Handle(CreateClassRequestCommand request, CancellationToken cancellationToken)
        {
            var classRequest = new Class
            {
                Character = request.Character,
                Number = request.Number,
                ClassTeacherId = request.ClassTeacherId
            };

            _context.Classes.Add(classRequest);

            await _context.SaveChangesAsync(cancellationToken)
                .ConfigureAwait(false);

            return classRequest.Id;
        }
    }
}
