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
    public class GetTeachersBySchoolIdQuery : IRequest<List<GetTeachersBySchoolIdVM>>
    {
        public long SchoolId { get; set; }

        public class GetTeachersQueryHandler : IRequestHandler<GetTeachersBySchoolIdQuery, List<GetTeachersBySchoolIdVM>>
        {
            private readonly IYPSDbContext _dbContext;
            private readonly IMapper _mapper;

            public GetTeachersQueryHandler(IYPSDbContext dbContext, IMapper mapper)
            {
                _dbContext = dbContext;
                _mapper = mapper;
            }

            public async Task<List<GetTeachersBySchoolIdVM>> Handle(GetTeachersBySchoolIdQuery request, CancellationToken cancellationToken)
            {
                var teachers = await _dbContext.Teachers
                    .Where(x => x.SchoolId == request.SchoolId)
                    .ProjectTo<GetTeachersBySchoolIdVM>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);
                return teachers;
            }
        }
    }
}
