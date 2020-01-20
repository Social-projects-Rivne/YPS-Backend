using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using YPS.Application.Event.Models;
using YPS.Application.Interfaces;

namespace YPS.Application.Event.Query.GetAllEvents
{
    public sealed class EventQueryHandler: IRequestHandler<GetAllEventsQuery,EventListViewModel>
    {
        private readonly IYPSDbContext _dbContext;
        private readonly IMapper _mapper;
        public EventQueryHandler(IYPSDbContext dbContext , IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<EventListViewModel> Handle(GetAllEventsQuery request,CancellationToken cancellationToken)
        {
            var query = await _dbContext.UpcomingEvents.Where(x=>x.SchoolId == request.SchoolId)
                .ToListAsync(cancellationToken).ConfigureAwait(false);
            return new EventListViewModel
            {
                Events = query.Select(x => _mapper.Map<EventDto>(x)).ToList()
            };
        }
    }
}
