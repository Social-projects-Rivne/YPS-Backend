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
                Class classOfPupil = await _context.ClassesToPupils
                    .Where(x => x.PupilId == request.PupilId)
                    .Select(x => x.Class)
                    .FirstOrDefaultAsync(x => x.YearFrom == DateTime.Now.Year || x.YearTo == DateTime.Now.Year);

                List<UpcomingEventByPupilVm> upcomingEvents = await _context.UpcomingEvents
                    .Where(x => x.ClassId == classOfPupil.Id && x.ScheduledDate >= DateTime.Now)
                    .ProjectTo<UpcomingEventByPupilVm>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);

                return upcomingEvents;
            }
        }
    }
}