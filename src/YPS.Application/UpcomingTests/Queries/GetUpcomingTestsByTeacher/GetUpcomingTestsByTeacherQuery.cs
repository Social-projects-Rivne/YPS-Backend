using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using YPS.Application.Interfaces;
using YPS.Application.UpcomingTests.Queries.GetUpcomingTestsByPupil;
using YPS.Domain.Entities;

namespace YPS.Application.UpcomingTests.Queries.GetUpcomingTestsByTeacher
{
    public class GetUpcomingTestsByTeacherQuery : IRequest<List<UpcomingTestVm>>
    {
        public long TeacherId { get; set; }

        public class GetUpcomingTestsByTeacherQueryHandler : IRequestHandler<GetUpcomingTestsByTeacherQuery, List<UpcomingTestVm>>
        {
            private readonly IYPSDbContext _context;
            private readonly IMapper _mapper;

            public GetUpcomingTestsByTeacherQueryHandler(IYPSDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<UpcomingTestVm>> Handle(GetUpcomingTestsByTeacherQuery request, CancellationToken cancellationToken)
            {
                Teacher teacher = await _context.Teachers.FirstOrDefaultAsync(x => x.Id == request.TeacherId);

                List<UpcomingTestVm> upcomingTests = await _context.UpcomingTests
                    .Where(x => x.TeacherId == request.TeacherId &&
                        x.ScheduledDate >= DateTime.Now)
                    .ProjectTo<UpcomingTestVm>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);

                return upcomingTests;  
            }
        }
    }
}
