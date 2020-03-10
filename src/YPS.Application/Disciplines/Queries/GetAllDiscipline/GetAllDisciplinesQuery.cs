using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using YPS.Application.Disciplines.Queries.GetDisciplinesByTeacher;
using YPS.Application.Interfaces;

namespace YPS.Application.Disciplines.Queries.GetAllDiscipline
{
    public class GetAllDisciplinesQuery : IRequest<List<GetAllDisciplinesVm>>
    {
        public class GetAllDisciplineQueryHandler : IRequestHandler<GetAllDisciplinesQuery, List<GetAllDisciplinesVm>>
        {
            private readonly IYPSDbContext _context;
            private readonly IMapper _mapper;

            public GetAllDisciplineQueryHandler(IYPSDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<GetAllDisciplinesVm>> Handle(GetAllDisciplinesQuery request, CancellationToken cancellationToken)
            {
                List<GetAllDisciplinesVm> disciplines = await _context.Disciplines.ProjectTo<GetAllDisciplinesVm>(_mapper.ConfigurationProvider).ToListAsync();

                return disciplines;
            }
        }
    }
}
