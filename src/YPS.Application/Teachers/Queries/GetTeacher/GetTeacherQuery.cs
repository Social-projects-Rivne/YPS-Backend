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
    public class GetTeacherQuery : IRequest<TeacherVM>
    {
        public long Id;
        public class GetTeachersQueryHandler : IRequestHandler<GetTeacherQuery, TeacherVM>
        {
            private readonly IYPSDbContext _dbContext;
            private readonly IMapper _mapper;

            public GetTeachersQueryHandler(IYPSDbContext dbContext, IMapper mapper)
            {
                _dbContext = dbContext;
                _mapper = mapper;
            }
            public async Task<TeacherVM> Handle(GetTeacherQuery request, CancellationToken cancellationToken)
            {

                TeacherVM teacher = await _dbContext.Teachers
                    .ProjectTo<TeacherVM>(_mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync(x => x.UserId == request.Id);

                return teacher;
            }
        }
    }
}
