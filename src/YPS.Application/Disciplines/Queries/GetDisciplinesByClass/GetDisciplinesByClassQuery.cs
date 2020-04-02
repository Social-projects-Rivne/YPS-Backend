using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using YPS.Application.Interfaces;

namespace YPS.Application.Disciplines.Queries.GetDisciplinesByClass
{
    public class GetDisciplinesByClassQuery : IRequest<GetDisciplineByClassResponse>
    {
        public long TeacherId { get; set; }
        public class GetDisciplinesByClassQueryHandler : IRequestHandler<GetDisciplinesByClassQuery, GetDisciplineByClassResponse>
        {
            private readonly IYPSDbContext _context;
            private readonly IMapper _mapper;

            public GetDisciplinesByClassQueryHandler(IYPSDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<GetDisciplineByClassResponse> Handle(GetDisciplinesByClassQuery request, CancellationToken cancellationToken)
            {
                var class_ = await _context.Classes
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => 
                        x.ClassTeacherId == request.TeacherId && 
                        (x.YearTo == DateTime.Now.Year || x.YearTo == DateTime.Now.AddYears(1).Year)
                );

                if (class_ != null)
                {
                    List<DisciplineByClassVm> disciplinesList = await _context.ClassesToDisciplines
                        .Where(x => x.ClassId == class_.Id)
                        .ProjectTo<DisciplineByClassVm>(_mapper.ConfigurationProvider)
                        .OrderBy(x => x.Name)
                        .ToListAsync();

                    return new GetDisciplineByClassResponse 
                    {
                        Disciplines = disciplinesList,
                        IsClassTeacher = true,
                        ClassId = class_.Id
                    };
                }
                else
                {
                    return new GetDisciplineByClassResponse
                    {
                        Disciplines = null,
                        IsClassTeacher = false,
                        ClassId = 0
                    };
                }
            }
        }
    }
}
