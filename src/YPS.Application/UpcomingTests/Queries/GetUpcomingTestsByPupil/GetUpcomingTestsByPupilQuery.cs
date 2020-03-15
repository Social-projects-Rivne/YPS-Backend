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
                Class classOfPupil = await _context.ClassesToPupils
                    .Where(x => x.PupilId == request.PupilId)
                    .Select(x => x.Class)
                    .FirstOrDefaultAsync(x => x.YearFrom == DateTime.Now.Year || x.YearTo == DateTime.Now.Year);

                List<UpcomingTestVm> upcomingTests = await _context.UpcomingTests
                    .Where(x => x.ClassId == classOfPupil.Id && x.ScheduledDate >= DateTime.Now)
                    .ProjectTo<UpcomingTestVm>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken); 

                return upcomingTests;
            }
        }
    }
}
