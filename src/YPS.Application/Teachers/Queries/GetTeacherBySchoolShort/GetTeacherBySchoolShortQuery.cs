using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using YPS.Application.Interfaces;
using YPS.Application.Teachers.Queries.GetTeachersBySchool;

namespace YPS.Application.Teachers.Queries.GetTeacherBySchoolShort
{
    public sealed class GetTeacherBySchoolShortQuery : IRequest<List<GetTeacherBySchoolShortVm>>
    {
        public long SchoolId { get; set; }

        public class GetTeacherBySchoolShortQueryHandler : IRequestHandler<GetTeacherBySchoolShortQuery, List<GetTeacherBySchoolShortVm>>
        {
            private readonly IYPSDbContext _context;
            private readonly IMapper _mapper;

            public GetTeacherBySchoolShortQueryHandler(IYPSDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<GetTeacherBySchoolShortVm>> Handle(GetTeacherBySchoolShortQuery request, CancellationToken cancellationToken)
            {
                List<GetTeacherBySchoolShortVm> result = await _context.Teachers
                    .Where(x => x.User.SchoolId == request.SchoolId)
                    .Where(x => x.User.Role.Name == "teacher")
                    .ProjectTo<GetTeacherBySchoolShortVm>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);

                return result;
            }
        }
    }
}
