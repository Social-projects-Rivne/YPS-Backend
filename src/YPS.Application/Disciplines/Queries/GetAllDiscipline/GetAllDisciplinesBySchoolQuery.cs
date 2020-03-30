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
using YPS.Application.Disciplines.Queries.GetAllDiscipline;
using YPS.Application.Interfaces;

namespace YPS.Application.Disciplines.Queries.GetAllDiscipline
{
    public class GetAllDisciplinesBySchoolQuery : IRequest<List<DisciplineBySchoolVm>>
    {
        public long SchoolId { get; set; }
        public class GetAllDisciplinesBySchoolQueryHandler : IRequestHandler<GetAllDisciplinesBySchoolQuery, List<DisciplineBySchoolVm>>
        {
            private readonly IYPSDbContext _context;
            private readonly IMapper _mapper;

            public GetAllDisciplinesBySchoolQueryHandler(IYPSDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<DisciplineBySchoolVm>> Handle(GetAllDisciplinesBySchoolQuery request, CancellationToken cancellationToken)
            {
                List<DisciplineBySchoolVm> disciplines = await _context.Disciplines.Where(e => e.SchoolId == request.SchoolId).
                    ProjectTo<DisciplineBySchoolVm>(_mapper.ConfigurationProvider).OrderBy(e => e.Name).ToListAsync();

                return disciplines;
            }
        }
    }
}
