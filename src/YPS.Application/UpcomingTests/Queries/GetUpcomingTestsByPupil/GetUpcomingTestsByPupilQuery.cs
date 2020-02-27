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
using YPS.Domain.Entities;

namespace YPS.Application.UpcomingTests.Queries.GetUpcomingTestsByPupil
{
    public class GetUpcomingTestsByPupilQuery : IRequest<List<UpcomingTestVm>>
    {
        public long PupilId { get; set; }

        public class GetUpcomingTestsByPupilQueryHandler : IRequestHandler<GetUpcomingTestsByPupilQuery, List<UpcomingTestVm>>
        {
            private readonly IYPSDbContext _context;
            private readonly IMapper _mapper;

            public GetUpcomingTestsByPupilQueryHandler(IYPSDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<UpcomingTestVm>> Handle(GetUpcomingTestsByPupilQuery request, CancellationToken cancellationToken)
            {
                Pupil pupil = await _context.Pupils.FirstOrDefaultAsync(x => x.Id == request.PupilId);

                List<UpcomingTestVm> upcomingTests = await _context.UpcomingTests
                    .Where(x =>
                        x.ClassId == pupil.ClassId &&
                        x.ScheduledDate >= DateTime.Now)
                    .ProjectTo<UpcomingTestVm>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);

                return upcomingTests;
            }
        }
    }
}
