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
using YPS.Domain.Entities;

namespace YPS.Application.UpcomingEvents.Queries.GetUpcomingEventsByPupil
{
    public class GetUpcomingEventsByPupilQuery : IRequest<List<UpcomingEventByPupilVm>>
    {
        public long PupilId { get; set; }
        public long SchoolId { get; set; }
        public class GetUpcomingEventsByPupilQueryHandler : IRequestHandler<GetUpcomingEventsByPupilQuery, List<UpcomingEventByPupilVm>>
        {
            private readonly IYPSDbContext _context;
            private readonly IMapper _mapper;

            public GetUpcomingEventsByPupilQueryHandler(IYPSDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<UpcomingEventByPupilVm>> Handle(GetUpcomingEventsByPupilQuery request, CancellationToken cancellationToken)
            {
                List<UpcomingEventByPupilVm> upcomingEvets = await _context.UpcomingEvents
                    .Where(x => 
                        x.SchoolId == request.SchoolId && 
                        x.Class.ClassToPupils.First().PupilId == request.PupilId &&
                        x.ScheduledDate >= DateTime.Now)
                    .ProjectTo<UpcomingEventByPupilVm>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);

                return upcomingEvets;
            }
        }
    }
}