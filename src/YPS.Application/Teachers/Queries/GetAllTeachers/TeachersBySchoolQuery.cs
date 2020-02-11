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


namespace YPS.Application.Teachers.Queries.GetTeacher
{
    public class TeachersBySchoolQuery : IRequest<List<TeachersBySchoolVm>>
    {
        public long SchoolId { get; set; }

        public class GetTeachersQueryHandler : IRequestHandler<TeachersBySchoolQuery, List<TeachersBySchoolVm>>
        {
            private readonly IYPSDbContext _dbContext;
            private readonly IMapper _mapper;

            public GetTeachersQueryHandler(IYPSDbContext dbContext, IMapper mapper)
            {
                _dbContext = dbContext;
                _mapper = mapper;
            }

            public async Task<List<TeachersBySchoolVm>> Handle(TeachersBySchoolQuery request, CancellationToken cancellationToken)
            {
                var teachers = await _dbContext.Teachers
                    .Where(x => x.SchoolId == request.SchoolId)
                    .ProjectTo<TeachersBySchoolVm>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);
                
                return teachers;
            }
        }
    }
}
