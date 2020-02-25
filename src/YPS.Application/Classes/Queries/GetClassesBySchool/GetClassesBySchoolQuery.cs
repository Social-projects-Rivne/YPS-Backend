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

namespace YPS.Application.Classes.Queries.GetClassesBySchool
{
    public class GetClassesBySchoolQuery : IRequest<List<ClassBySchoolVm>>
    {
        public long SchoolId { get; set; }
        public class GetClassesBySchoolQueryHandler : IRequestHandler<GetClassesBySchoolQuery, List<ClassBySchoolVm>>
        {
            private readonly IYPSDbContext _context;
            private readonly IMapper _mapper;

            public GetClassesBySchoolQueryHandler(IYPSDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<ClassBySchoolVm>> Handle(GetClassesBySchoolQuery request, CancellationToken cancellationToken) =>
                await  _context.Classes
                    .Where(cl => cl.TeacherOf.User.SchoolId == request.SchoolId)
                    .ProjectTo<ClassBySchoolVm>(_mapper.ConfigurationProvider)
                    .ToListAsync();
        }
    }
}
