using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using YPS.Application.Interfaces;

namespace YPS.Application.Auth.Command.Event
{
    public sealed class EventCommandHandler : IRequestHandler<EventCommand, EventViewModel>
    {
        private readonly IYPSDbContext _dbContext;
        private readonly IMapper _mapper;

        public EventCommandHandler(IYPSDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public Task<EventViewModel> Handle(EventCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
