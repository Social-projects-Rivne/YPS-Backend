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
    public class GetAllDisciplinesQuery : IRequest<List<DisciplineShortVm>>
    {
        public class GetAllDisciplinesQueryHandler : IRequestHandler<GetAllDisciplinesQuery, List<DisciplineShortVm>>
        {
            private readonly IYPSDbContext _context;
            private readonly IMapper _mapper;

            public GetAllDisciplinesQueryHandler(IYPSDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<DisciplineShortVm>> Handle(GetAllDisciplinesQuery request, CancellationToken cancellationToken)
            {
                List<DisciplineShortVm> disciplines = await _context.Disciplines.ProjectTo<DisciplineShortVm>(_mapper.ConfigurationProvider).OrderBy(e => e.Name).ToListAsync();

                return disciplines;
            }
        }
    }
}
