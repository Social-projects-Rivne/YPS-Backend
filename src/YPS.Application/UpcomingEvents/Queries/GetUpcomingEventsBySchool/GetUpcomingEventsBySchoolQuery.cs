using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using YPS.Application.Interfaces;
using System.Linq;

namespace YPS.Application.UpcomingEvents.Queries.GetUpcomingEventsBySchool
{
    public class GetUpcomingEventsBySchoolQuery : IRequest<List<UpcomingEventVm>>
    {
        public long SchoolId { get; set; }
        public class GetAllUpcomingEventsHandler : IRequestHandler<GetUpcomingEventsBySchoolQuery, List<UpcomingEventVm>>
        {
            private readonly IYPSDbContext _context;
            private readonly IMapper _mapper;

            public GetAllUpcomingEventsHandler(IYPSDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<UpcomingEventVm>> Handle(GetUpcomingEventsBySchoolQuery request, CancellationToken cancellationToken)
            {
                var upcomingEvets = await _context.UpcomingEvents
                    .Where(x => x.SchoolId == request.SchoolId && x.ClassId == null)
                    .ProjectTo<UpcomingEventVm>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);
                return upcomingEvets;
            }
        }
    }
}
