using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using YPS.Application.Interfaces;
using YPS.Application.UpcomingEvents.Queries.GetUpcomingEventsBySchool;

namespace YPS.Application.UpcomingEvents.Queries.GetUpcomingEventsByPupil
{
    public class GetUpcomingEventsByPupilQuery : IRequest<List<UpcomingEventVm>>
    {
        public long PupilId { get; set; }
        public long SchoolId { get; set; }
        public class GetAllUpcomingEventsHandler : IRequestHandler<GetUpcomingEventsByPupilQuery, List<UpcomingEventVm>>
        {
            private readonly IYPSDbContext _context;
            private readonly IMapper _mapper;

            public GetAllUpcomingEventsHandler(IYPSDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<UpcomingEventVm>> Handle(GetUpcomingEventsByPupilQuery request, CancellationToken cancellationToken)
            {
                var pupil = await _context.Pupils
                   .FirstOrDefaultAsync(x => x.UserId == request.PupilId);

                var upcomingEvets = await _context.UpcomingEvents
                    .Where(x => x.SchoolId == request.SchoolId && x.ClassId == pupil.ClassId)
                    .Where(x => x.ScheduledDate >= DateTime.Now)
                    .ProjectTo<UpcomingEventVm>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);
                return upcomingEvets;
            }
        }
    }
}