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

namespace YPS.Application.Classes.Queries.GetClassesBySchoolWithFullInfo
{
    public sealed class GetClassesBySchoolWithFullInfoQuery : IRequest<List<ClassWithFullInfoVm>>
    {
        public long SchoolId { get; set; }
        public sealed class GetClassesBySchoolWithFullInfoQueryHandler : IRequestHandler<GetClassesBySchoolWithFullInfoQuery, List<ClassWithFullInfoVm>>
        {
            private readonly IYPSDbContext _context;
            private readonly IMapper _mapper;

            public GetClassesBySchoolWithFullInfoQueryHandler(IYPSDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<ClassWithFullInfoVm>> Handle(GetClassesBySchoolWithFullInfoQuery request, CancellationToken cancellationToken) =>
                await _context.Classes
                    .Where(c => c.TeacherOf.User.SchoolId == request.SchoolId)
                    .ProjectTo<ClassWithFullInfoVm>(_mapper.ConfigurationProvider)
                    .ToListAsync();
        }
    }
}
