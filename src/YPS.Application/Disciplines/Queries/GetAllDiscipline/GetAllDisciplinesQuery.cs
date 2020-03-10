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
    public class GetAllDisciplineQuery : IRequest<List<GetAllDisciplineVm>>
    {
        public class GetAllDisciplineQueryHandler : IRequestHandler<GetAllDisciplineQuery, List<GetAllDisciplineVm>>
        {
            private readonly IYPSDbContext _context;
            private readonly IMapper _mapper;

            public GetAllDisciplineQueryHandler(IYPSDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<GetAllDisciplineVm>> Handle(GetAllDisciplineQuery request, CancellationToken cancellationToken)
            {
                List<GetAllDisciplineVm> disciplines = await _context.Disciplines.ProjectTo<GetAllDisciplineVm>(_mapper.ConfigurationProvider).ToListAsync();

                return disciplines;
            }
        }
    }
}
